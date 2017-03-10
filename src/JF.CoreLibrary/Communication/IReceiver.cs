using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication
{
	public interface IReceiver
	{
		event EventHandler<ChannelFailureEventArgs> Failed;

		event EventHandler<ReceivedEventArgs> Received;
	}
}