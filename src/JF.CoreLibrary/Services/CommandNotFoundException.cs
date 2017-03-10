using System;
using System.Runtime.Serialization;

namespace JF.Services
{
	public class CommandNotFoundException : CommandException
	{
		#region 成员字段

		private string _path;

		#endregion

		#region 构造方法

		public CommandNotFoundException(string path)
		{
			_path = path ?? string.Empty;
		}

		protected CommandNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_path = info.GetString("Path");
		}

		#endregion

		#region 公共属性

		public string Path
		{
			get
			{
				return _path;
			}
		}

		#endregion

		#region 重写属性

		public override string Message
		{
			get
			{
				return Resources.ResourceUtility.GetString("CommandNotFound", _path);
			}
		}

		#endregion

		#region 重写方法

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			//调用基类同名方法
			base.GetObjectData(info, context);

			//将定义的属性值加入持久化信息集中
			info.AddValue("Path", _path);
		}

		#endregion
	}
}