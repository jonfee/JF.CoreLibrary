using System;
using System.IO;

namespace JF.Runtime.Serialization
{
	/// <summary>
	/// 提供序列化写入功能的类。
	/// </summary>
	public interface ISerializationWriter
	{
		event EventHandler<SerializationWritingEventArgs> Writing;
		event EventHandler<SerializationWroteEventArgs> Wrote;

		void OnSerializing(SerializationContext context);
		void OnSerialized(SerializationContext context);
		void OnWrote(SerializationWriterContext context);

		/*
		/// <summary>
		/// 当序列化处于特定阶段时，该方法被回调。
		/// </summary>
		/// <param name="context">当前序列化操作的上下文。</param>
		/// <param name="step">指定当前所处的序列化阶段。</param>
		void OnStep(SerializationWriterContext context, SerializationWriterStep step);
		*/

		/// <summary>
		/// 根据序列化的<seealso cref="SerializationWriterContext"/>上下文对象执行具体的写入操作。
		/// </summary>
		/// <param name="context">执行序列化操作的上下文。</param>
		/// <returns>如果当前写入的对象后不再需要进行后续的成员序列化写入则可以设置<paramref name="context"/>参数指定的<seealso cref="SerializationWriterContext.Terminated"/>属性为真(True)。</returns>
		void Write(SerializationWriterContext context);
	}
}
