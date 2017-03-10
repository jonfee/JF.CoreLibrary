using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JF.Diagnostics;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 储存（上传）文件到服务器上
	/// </summary>
	internal class FtpStorCommand : FtpCommand
	{
		public FtpStorCommand() : base("STOR")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			context.Channel.CheckLogin();
			context.Channel.CheckDataChannel();

			var dataChannel = context.Channel.DataChannel;

			try
			{
				context.Channel.Status = FtpSessionStatus.Upload;

				var path = context.Statement.Argument;
				if(string.IsNullOrWhiteSpace(path))
				{
					throw new SyntaxException();
				}

				var localPath = context.Channel.MapVirtualPathToLocalPath(path);
				context.Statement.Result = localPath;

				var fileInfo = new FileInfo(localPath);
				if(fileInfo.Exists && context.Channel.FileOffset > 0)
				{
					context.Channel.UpFileStream = fileInfo.Open(FileMode.Open, FileAccess.Write, FileShare.Read);
					context.Channel.UpFileStream.Seek(context.Channel.FileOffset, SeekOrigin.Begin);
					context.Channel.FileOffset = 0;
				}
				else
				{
					if(!fileInfo.Directory.Exists)
					{
						fileInfo.Directory.Create();
					}

					context.Channel.UpFileStream = fileInfo.Open(FileMode.Create, FileAccess.Write, FileShare.Read);
				}

				context.Channel.UpFileLocalPath = localPath;
				context.Channel.UpFileFailed = false;

				dataChannel.Closed += DataChannel_Closed;
				dataChannel.Error += DataChannel_Failed;
				dataChannel.Received += DataChannel_Received;

				dataChannel.Receive();

				context.Channel.Send("150 Opening data connection for file transfer.");

				return null;
			}
			catch(Exception ex)
			{
				Logger.Error(ex);

				if(context.Channel.UpFileStream != null)
				{
					context.Channel.UpFileStream.Close();
					context.Channel.UpFileStream = null;
				}
				context.Channel.CloseDataChannel();

				if(ex is FtpException)
				{
					throw ex;
				}

				throw new InternalException("store file");
			}
		}

		private void DataChannel_Received(object sender, byte[] buffer, int offset, int count)
		{
			var dataCon = sender as IFtpDataChannel;
			if(dataCon == null)
			{
				throw new ArgumentOutOfRangeException("sender");
			}

			var dataServer = dataCon.ServerChannel;
			if(dataServer == null)
			{
				return;
			}

			if(dataServer.Status != FtpSessionStatus.Upload)
			{
				return;
			}

			if(dataServer.UpFileStream == null)
			{
				return;
			}

			try
			{
				dataServer.UpFileStream.Write(buffer, offset, count);
			}
			catch(Exception)
			{
				dataServer.UpFileFailed = true;
				dataCon.Close();
			}
		}

		private void DataChannel_Closed(object sender, EventArgs e)
		{
			var dataChannel = sender as IFtpDataChannel;
			if(dataChannel == null)
			{
				throw new ArgumentOutOfRangeException("sender");
			}

			dataChannel.Received -= DataChannel_Received;
			dataChannel.Error -= DataChannel_Failed;
			dataChannel.Closed -= DataChannel_Closed;

			var channel = dataChannel.ServerChannel;
			if(channel == null)
			{
				return;
			}

			if(channel.Status != FtpSessionStatus.Upload)
			{
				return;
			}

			var stream = channel.UpFileStream;
			channel.UpFileStream = null;

			if(stream != null)
			{
				stream.Dispose();
			}

			try
			{
				if(channel.UpFileFailed)
				{
					File.Delete(channel.UpFileLocalPath);
				}
			}
			catch
			{
			}

			channel.Status = FtpSessionStatus.Wait;

			if(!channel.UpFileFailed)
			{
				var statement = channel.CurrentStatement;

				channel.Send("226 Transfer complete.");

				if(statement != null && string.Equals(statement.Name, "STOR", StringComparison.OrdinalIgnoreCase))
				{
					var args = new ReceivedEventArgs(channel, statement);
					Task.Factory.StartNew(() => channel.Server.NotifiyReceived(args));
				}
			}

			channel.UpFileLocalPath = null;
		}

		private void DataChannel_Failed(object sender, Exception e)
		{
			var dataServer = ((IFtpDataChannel)sender).ServerChannel;
			if(dataServer.Status != FtpSessionStatus.Upload)
			{
				return;
			}

			dataServer.UpFileFailed = true;
			dataServer.Send("426 Connection closed; transfer aborted.");
		}
	}
}