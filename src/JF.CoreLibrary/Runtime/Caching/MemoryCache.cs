﻿using System;
using System.Collections.Generic;

namespace JF.Runtime.Caching
{
	public class MemoryCache : ICache, JF.Common.IDisposableObject, JF.Common.IAccumulator
	{
		#region 单例字段

		public static readonly MemoryCache Default = new MemoryCache("JF.Runtime.Caching.MemoryCache");

		#endregion

		#region 事件声明

		public event EventHandler<Common.DisposedEventArgs> Disposed;

		public event EventHandler<CacheChangedEventArgs> Changed;

		#endregion

		#region 成员字段

		private ICacheCreator _creator;
		private System.Runtime.Caching.MemoryCache _innerCache;

		#endregion

		#region 构造方法

		public MemoryCache(string name) : this(name, null)
		{
		}

		public MemoryCache(string name, ICacheCreator creator)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("name");
			}

			_innerCache = new System.Runtime.Caching.MemoryCache(name);
			_creator = creator;
		}

		#endregion

		#region 公共属性

		public string Name
		{
			get
			{
				return _innerCache.Name;
			}
		}

		public long Count
		{
			get
			{
				return _innerCache.GetCount();
			}
		}

		public ICacheCreator Creator
		{
			get
			{
				return _creator;
			}
			set
			{
				_creator = value;
			}
		}

		public bool IsDisposed
		{
			get
			{
				return _innerCache == null;
			}
		}

		#endregion

		#region 公共方法

		public bool Exists(string key)
		{
			return _innerCache.Contains(key);
		}

		public TimeSpan? GetDuration(string key)
		{
			throw new NotSupportedException();
		}

		public void SetDuration(string key, TimeSpan duration)
		{
			throw new NotSupportedException();
		}

		public T GetValue<T>(string key)
		{
			return JF.Common.Convert.ConvertValue<T>(this.GetValue(key));
		}

		public object GetValue(string key)
		{
			var creator = this.Creator;

			if(creator == null || _innerCache.Contains(key))
			{
				return _innerCache.Get(key);
			}

			return this.GetValue(key, _ =>
			{
				TimeSpan duration;
				var value = creator.Create(this.Name, _, out duration);
				return new Tuple<object, TimeSpan>(value, duration);
			});
		}

		public object GetValue(string key, Func<string, Tuple<object, TimeSpan>> valueCreator)
		{
			if(valueCreator == null)
			{
				return _innerCache.Get(key);
			}

			var result = valueCreator(key);

			return _innerCache.AddOrGetExisting(key, result.Item1, new System.Runtime.Caching.CacheItemPolicy()
			{
				SlidingExpiration = result.Item2,
				//UpdateCallback = this.OnUpdateCallback,
				RemovedCallback = this.OnRemovedCallback,
			});
		}

		public object GetValue(string key, Func<string, Tuple<object, DateTime>> valueCreator)
		{
			if(valueCreator == null)
			{
				return _innerCache.Get(key);
			}

			var result = valueCreator(key);

			return _innerCache.AddOrGetExisting(key, result.Item1, new System.Runtime.Caching.CacheItemPolicy()
			{
				AbsoluteExpiration = result.Item2 > DateTime.Now ? result.Item2 : System.Runtime.Caching.ObjectCache.InfiniteAbsoluteExpiration,
				//UpdateCallback = this.OnUpdateCallback,
				RemovedCallback = this.OnRemovedCallback,
			});
		}

		public bool SetValue(string key, object value)
		{
			return this.SetValue(key, value, TimeSpan.Zero);
		}

		public bool SetValue(string key, object value, TimeSpan duration, bool requiredNotExists = false)
		{
			if(requiredNotExists)
			{
				var exists = _innerCache.Contains(key);

				if(exists)
				{
					return false;
				}
			}

			if(duration == TimeSpan.Zero)
			{
				_innerCache.Set(key, value, new System.Runtime.Caching.CacheItemPolicy()
				{
					AbsoluteExpiration = System.Runtime.Caching.ObjectCache.InfiniteAbsoluteExpiration,
					//UpdateCallback = this.OnUpdateCallback,
					RemovedCallback = this.OnRemovedCallback,
				});
			}
			else
			{
				_innerCache.Set(key, value, new System.Runtime.Caching.CacheItemPolicy()
				{
					SlidingExpiration = duration,
					//UpdateCallback = this.OnUpdateCallback,
					RemovedCallback = this.OnRemovedCallback,
				});
			}

			return true;
		}

		public bool SetValue(string key, object value, DateTime expires, bool requiredNotExists = false)
		{
			if(requiredNotExists)
			{
				var exists = _innerCache.Contains(key);

				if(exists)
				{
					return false;
				}
			}

			if(expires < DateTime.Now)
			{
				_innerCache.Set(key, value, new System.Runtime.Caching.CacheItemPolicy()
				{
					AbsoluteExpiration = System.Runtime.Caching.ObjectCache.InfiniteAbsoluteExpiration,
					//UpdateCallback = this.OnUpdateCallback,
					RemovedCallback = this.OnRemovedCallback,
				});
			}
			else
			{
				_innerCache.Set(key, value, new System.Runtime.Caching.CacheItemPolicy()
				{
					AbsoluteExpiration = expires.ToUniversalTime(),
					//UpdateCallback = this.OnUpdateCallback,
					RemovedCallback = this.OnRemovedCallback,
				});
			}

			return true;
		}

		public bool Rename(string key, string newKey)
		{
			if(string.IsNullOrWhiteSpace(newKey))
			{
				throw new ArgumentNullException("newKey");
			}

			var orignalValue = _innerCache.Remove(key);

			if(orignalValue != null)
			{
				_innerCache.Add(newKey, orignalValue, System.Runtime.Caching.ObjectCache.InfiniteAbsoluteExpiration);
			}

			return orignalValue != null;
		}

		public bool Remove(string key)
		{
			return _innerCache.Remove(key) != null;
		}

		public void Clear()
		{
			_innerCache.Trim(100);

			//System.Runtime.Caching.MemoryCache 没有Clear方法，它的Trim()也不一定会回收缓存项
			throw new NotSupportedException();
		}

		#endregion

		#region 缓存事件

		private void OnUpdateCallback(System.Runtime.Caching.CacheEntryUpdateArguments args)
		{
			this.OnChanged(new CacheChangedEventArgs(CacheChangedReason.Updated, args.Key, null, args.UpdatedCacheItem.Key, args.UpdatedCacheItem.Value));
		}

		private void OnRemovedCallback(System.Runtime.Caching.CacheEntryRemovedArguments args)
		{
			this.OnChanged(new CacheChangedEventArgs(this.ConvertReason(args.RemovedReason), args.CacheItem.Key, args.CacheItem.Value));
		}

		#endregion

		#region 激发事件

		protected virtual void OnChanged(CacheChangedEventArgs args)
		{
			var changed = this.Changed;

			if(changed != null)
			{
				changed(this, args);
			}
		}

		#endregion

		#region 私有方法

		private CacheChangedReason ConvertReason(System.Runtime.Caching.CacheEntryRemovedReason reason)
		{
			switch(reason)
			{
				case System.Runtime.Caching.CacheEntryRemovedReason.Expired:
					return CacheChangedReason.Expired;
				case System.Runtime.Caching.CacheEntryRemovedReason.Removed:
					return CacheChangedReason.Removed;
				case System.Runtime.Caching.CacheEntryRemovedReason.ChangeMonitorChanged:
					return CacheChangedReason.Dependented;
				default:
					return CacheChangedReason.None;
			}
		}

		#endregion

		#region 处置方法

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			var cache = System.Threading.Interlocked.Exchange(ref _innerCache, null);

			if(cache == null)
			{
				return;
			}

			cache.Dispose();

			var disposed = this.Disposed;

			if(disposed != null)
			{
				disposed(this, new Common.DisposedEventArgs(disposing));
			}
		}

		#endregion

		#region 递增接口

		public long Increment(string key, int interval = 1)
		{
			var value = this.GetValue(key);

			if(value == null)
			{
				this.SetValue(key, interval);
				return interval;
			}

			long number;

			if(!JF.Common.Convert.TryConvertValue<long>(value, out number))
			{
				throw new InvalidOperationException();
			}

			number += interval;

			this.SetValue(key, number);

			return number;
		}

		public long Decrement(string key, int interval = 1)
		{
			return this.Increment(key, -interval);
		}

		#endregion
	}
}