using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace JF.SMS
{
	/// <summary>
	/// 表示实现该接口的是一个短信发送器。
	/// </summary>
	public interface IMessageSender
	{
		/// <summary>
		/// 针对指定的手机号发送单条短信。
		/// </summary>
		/// <param name="mobile">接收的手机号，仅支持单号码发送。</param>
		/// <param name="template">短信模板。</param>
		/// <returns>发送结果。</returns>
		Task<MessageResponse> SendAsync(string mobile, MessageTemplate template);

		/// <summary>
		/// 针对指定的手机号发送相同的短信。
		/// </summary>
		/// <param name="mobiles">接收的手机号列表，一次不能超过1000个。</param>
		/// <param name="template">短信模板。</param>
		/// <returns>发送结果。</returns>
		Task<MessageResponse> SendAsync(IEnumerable<string> mobiles, MessageTemplate template);

		/// <summary>
		/// 针对指定的手机号发送不同的短信。
		/// </summary>
		/// <param name="mobiles">接收的手机号列表，一次不要超过1000个。</param>
		/// <param name="templates">短信模板，一次不能超过1000条且短信内容，且条数必须与手机号个数相等。</param>
		/// <returns>发送结果。</returns>
		Task<MessageResponse> SendAsync(IEnumerable<string> mobiles, IEnumerable<MessageTemplate> templates);
	}
}
