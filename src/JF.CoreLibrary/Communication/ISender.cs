using System;
using System.IO;
using System.Text;

namespace JF.Communication
{
	public interface ISender
	{
		event EventHandler<ChannelFailureEventArgs> Failed;

		event EventHandler<SentEventArgs> Sent;

		void Send(string text, object asyncState = null);

		void Send(string text, Encoding encoding, object asyncState = null);

		void Send(Stream stream, object asyncState = null);

		void Send(byte[] buffer, object asyncState = null);

		void Send(byte[] buffer, int offset, object asyncState = null);

		void Send(byte[] buffer, int offset, int count, object asyncState = null);
	}
}