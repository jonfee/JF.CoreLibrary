using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net
{
	[Obsolete]
	public class FtpClient
	{
		#region 成员字段

		private ICredentials _credentials;

		#endregion

		#region 构造方法

		public FtpClient()
		{
			KeepAlive = true;
			_credentials = null;
		}

		public FtpClient(ICredentials credentials)
		{
			_credentials = credentials;
		}

		public FtpClient(string userName, string password)
		{
			_credentials = new NetworkCredential(userName, password);
		}

		#endregion

		#region 公共属性

		public bool KeepAlive
		{
			get;
			set;
		}

		#endregion

		#region 公共方法

		public void UploadFile(Uri url, string fileName)
		{
			using(var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous))
			{
				this.Upload(url, stream, false);
			}
		}

		public void Upload(Uri url, Stream stream, bool closeStream)
		{
			var request = WebRequest.Create(url) as FtpWebRequest;

			if(request == null)
			{
				throw new InvalidOperationException();
			}

			request.KeepAlive = KeepAlive;
			request.Method = WebRequestMethods.Ftp.UploadFile;
			request.Credentials = _credentials;

			var requestStream = request.GetRequestStream();
			stream.CopyTo(requestStream);
			requestStream.Close();

			if(closeStream)
			{
				stream.Close();
			}
		}

		public Stream Download(Uri url)
		{
			var request = WebRequest.Create(url) as FtpWebRequest;

			if(request == null)
			{
				throw new InvalidOperationException();
			}

			request.KeepAlive = KeepAlive;
			request.Method = WebRequestMethods.Ftp.DownloadFile;
			request.Credentials = _credentials;

			FtpWebResponse response = (FtpWebResponse)request.GetResponse();
			return response.GetResponseStream();
		}

		public void DownloadToFile(Uri url, string fileName)
		{
			var stream = this.Download(url);

			if(stream != null)
			{
				using(var fileStream = File.OpenWrite(fileName))
				{
					stream.CopyTo(fileStream, 1024);
				}
			}
		}

		#endregion
	}
}