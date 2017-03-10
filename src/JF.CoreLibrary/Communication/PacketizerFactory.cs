using System;
using System.Collections.Concurrent;

namespace JF.Communication
{
	public class PacketizerFactory<TPacketizer> : MarshalByRefObject, IPacketizerFactory, IDisposable where TPacketizer : class, IPacketizer
	{
		#region 私有变量

		private Func<IChannel, TPacketizer> _creator;
		private readonly ConcurrentDictionary<int, TPacketizer> _items;

		#endregion

		#region 构造方法

		public PacketizerFactory() : this(null)
		{
		}

		public PacketizerFactory(Func<IChannel, TPacketizer> creator)
		{
			if(creator == null)
			{
				_creator = (channel) =>
				{
					return Activator.CreateInstance<TPacketizer>();
				};
			}
			else
			{
				_creator = creator;
			}

			_items = new ConcurrentDictionary<int, TPacketizer>();
		}

		#endregion

		#region 获取方法

		public TPacketizer GetPacketizer(IChannel channel)
		{
			if(channel == null)
			{
				return null;
			}

			TPacketizer result;

			if(_items.TryGetValue(channel.ChannelId, out result))
			{
				return result;
			}

			result = this.CreatePacketizer(channel);

			if(_items.TryAdd(channel.ChannelId, result))
			{
				return result;
			}
			else
			{
				return _items[channel.ChannelId];
			}
		}

		IPacketizer IPacketizerFactory.GetPacketizer(IChannel channel)
		{
			return this.GetPacketizer(channel);
		}

		#endregion

		#region 创建元素

		protected virtual TPacketizer CreatePacketizer(IChannel channel)
		{
			if(_creator != null)
			{
				return _creator(channel);
			}

			return null;
		}

		#endregion

		#region 处置方法

		public void Dispose()
		{
			if(_items.IsEmpty)
			{
				return;
			}

			TPacketizer packetizer;

			while(!_items.IsEmpty)
			{
				var keys = _items.Keys;

				foreach(var key in keys)
				{
					if(_items.TryRemove(key, out packetizer))
					{
						if(packetizer is IDisposable)
						{
							((IDisposable)packetizer).Dispose();
						}
					}
				}
			}
		}

		#endregion
	}
}