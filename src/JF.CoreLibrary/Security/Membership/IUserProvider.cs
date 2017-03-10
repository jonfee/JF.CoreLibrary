﻿using System;
using System.Collections.Generic;

namespace JF.Security.Membership
{
	/// <summary>
	/// 提供关于用户管理的接口。
	/// </summary>
	public interface IUserProvider
	{
		#region 用户管理

		/// <summary>
		/// 获取指定编号对应的用户对象。
		/// </summary>
		/// <param name="userId">要查找的用户编号。</param>
		/// <returns>返回由<paramref name="userId"/>参数指定的用户对象，如果没有找到指定编号的用户则返回空。</returns>
		User GetUser(long userId);

		/// <summary>
		/// 获取指定标识对应的用户对象。
		/// </summary>
		/// <param name="identity">要查找的用户标识，可以是 <seealso cref="User.Name"/>、<seealso cref="User.Email"/>或<seealso cref="User.PhoneNumber"/>。</param>
		/// <param name="namespace">要查找的用户标识所属的命名空间。</param>
		/// <returns>返回找到的用户对象；如果在指定的命名空间内没有找到指定标识的用户则返回空(null)。</returns>
		/// <exception cref="System.ArgumentNullException">当<paramref name="identity"/>参数为空(null)或者全空格字符。</exception>
		User GetUser(string identity, string @namespace);

		/// <summary>
		/// 获取当前命名空间中的所有用户。
		/// </summary>
		/// <param name="namespace">要获取的用户集所属的命名空间。</param>
		/// <param name="paging">查询的分页设置，默认为第一页。</param>
		/// <returns>返回当前命名空间中的所有用户对象集。</returns>
		IEnumerable<User> GetAllUsers(string @namespace, JF.Data.Paging paging = null);

		/// <summary>
		/// 确定指定编号的用户是否存在。
		/// </summary>
		/// <param name="userId">指定要查找的用户编号。</param>
		/// <returns>如果指定编号的用户是存在的则返回真(True)，否则返回假(False)。</returns>
		bool Exists(long userId);

		/// <summary>
		/// 确定指定的用户标识在指定的命名空间内是否已经存在。
		/// </summary>
		/// <param name="identity">要确定的用户标识，可以是“用户名”或“邮箱地址”或“手机号码”。</param>
		/// <param name="namespace">要确定的用户标识所属的命名空间。</param>
		/// <returns>如果指定的用户标识在命名空间内已经存在则返回真(True)，否则返回假(False)。</returns>
		bool Exists(string identity, string @namespace);

		/// <summary>
		/// 设置指定编号的用户头像标识。
		/// </summary>
		/// <param name="userId">要设置的用户编号。</param>
		/// <param name="avatar">要设置的用户头像标识(头像代码或头像图片的URL)。</param>
		/// <returns>如果设置成功则返回真(True)，否则返回假(False)。</returns>
		bool SetAvatar(long userId, string avatar);

		/// <summary>
		/// 设置指定编号的用户邮箱地址。
		/// </summary>
		/// <param name="userId">要设置的用户编号。</param>
		/// <param name="email">要设置的邮箱地址。</param>
		/// <returns>如果设置成功则返回真(True)，否则返回假(False)。</returns>
		bool SetEmail(long userId, string email);

		/// <summary>
		/// 设置指定编号的用户手机号码。
		/// </summary>
		/// <param name="userId">要设置的用户编号。</param>
		/// <param name="phoneNumber">要设置的手机号码。</param>
		/// <returns>如果设置成功则返回真(True)，否则返回假(False)。</returns>
		bool SetPhoneNumber(long userId, string phoneNumber);

		/// <summary>
		/// 设置指定编号的用户名称。
		/// </summary>
		/// <param name="userId">要设置的用户编号。</param>
		/// <param name="name">要设置的用户名称。</param>
		/// <returns>如果设置成功则返回真(True)，否则返回假(False)。</returns>
		bool SetName(long userId, string name);

		/// <summary>
		/// 设置指定编号的用户全称(昵称)。
		/// </summary>
		/// <param name="userId">要设置的用户编号。</param>
		/// <param name="fullName">要设置的用户全称(昵称)。</param>
		/// <returns>如果设置成功则返回真(True)，否则返回假(False)。</returns>
		bool SetFullName(long userId, string fullName);

		/// <summary>
		/// 设置指定编号的用户描述信息。
		/// </summary>
		/// <param name="userId">要设置的用户编号。</param>
		/// <param name="description">要设置的用户描述信息。</param>
		/// <returns>如果设置成功则返回真(True)，否则返回假(False)。</returns>
		bool SetDescription(long userId, string description);

		/// <summary>
		/// 设置指定编号的用户所对应的主体标识。
		/// </summary>
		/// <param name="userId">要设置的用户编号。</param>
		/// <param name="principalId">要设置的用户主体标识。</param>
		/// <returns>如果设置成功则返回真(True)，否则返回假(False)。</returns>
		bool SetPrincipalId(long userId, string principalId);

		/// <summary>
		/// 设置指定编号的用户状态。
		/// </summary>
		/// <param name="userId">要设置的用户编号。</param>
		/// <param name="status">指定的用户状态。</param>
		/// <returns>如果设置成功则返回真(True)，否则返回假(False)。</returns>
		bool SetStatus(long userId, UserStatus status);

		/// <summary>
		/// 删除指定编号集的多个用户。
		/// </summary>
		/// <param name="userIds">要删除的用户编号数组。</param>
		/// <returns>如果删除成功则返回删除的数量，否则返回零。</returns>
		int DeleteUsers(params int[] userIds);

		/// <summary>
		/// 创建一个用户，并为其设置密码。
		/// </summary>
		/// <param name="user">要创建的<seealso cref="User"/>用户对象。</param>
		/// <param name="password">为新创建用户的设置的密码。</param>
		/// <returns>如果创建成功则返回真(true)，否则返回假(false)。</returns>
		bool CreateUser(User user, string password);

		/// <summary>
		/// 创建单个或者多个用户。
		/// </summary>
		/// <param name="users">要创建的用户对象集。</param>
		/// <returns>返回创建成功的用户数量。</returns>
		int CreateUsers(IEnumerable<User> users);

		/// <summary>
		/// 更新单个或多个用户信息。
		/// </summary>
		/// <param name="users">要更新的用户对象数组。</param>
		/// <returns>返回更新成功的用户数量。</returns>
		int UpdateUsers(params User[] users);

		/// <summary>
		/// 更新单个或多个用户信息。
		/// </summary>
		/// <param name="users">要更新的用户对象集。</param>
		/// <param name="scope">指定需要更新的字段集，字段名之间使用逗号分隔。</param>
		/// <returns>返回更新成功的用户数量。</returns>
		int UpdateUsers(IEnumerable<User> users, string scope = null);

		#endregion

		#region 密码管理

		/// <summary>
		/// 判断指定编号的用户是否设置了密码。
		/// </summary>
		/// <param name="userId">指定的用户编号。</param>
		/// <returns>如果返回真(True)表示指定编号的用户已经设置了密码，否则未设置密码。</returns>
		bool HasPassword(long userId);

		/// <summary>
		/// 判断指定标识的用户是否设置了密码。
		/// </summary>
		/// <param name="identity">指定的用户标识。</param>
		/// <param name="namespace">指定的用户标识所属的命名空间。</param>
		/// <returns>如果返回真(True)表示指定标识的用户已经设置了密码，否则未设置密码。</returns>
		bool HasPassword(string identity, string @namespace);

		/// <summary>
		/// 修改指定用户的密码。
		/// </summary>
		/// <param name="userId">要修改密码的用户编号。</param>
		/// <param name="oldPassword">指定的用户的当前密码。</param>
		/// <param name="newPassword">指定的用户的新密码。</param>
		bool ChangePassword(long userId, string oldPassword, string newPassword);

		/// <summary>
		/// 准备重置指定用户的密码。
		/// </summary>
		/// <param name="identity">要重置密码的用户标识，仅限用户的“邮箱地址”或“手机号码”。</param>
		/// <param name="namespace">指定的用户标识所属的命名空间。</param>
		/// <param name="secret">指定的验证码。</param>
		/// <param name="timeout">指定验证码的有效期，默认为60分钟。</param>
		/// <exception cref="System.ArgumentNullException"><paramref name="secret"/>参数为空(null)或全空白字符串。</exception>
		/// <returns>返回<paramref name="identity"/>参数对应的用户编号，如果指定用户标识不存在则返回负数(-1)。</returns>
		int ForgetPassword(string identity, string @namespace, string secret, TimeSpan? timeout = null);

		/// <summary>
		/// 重置指定用户的密码，以验证码摘要的方式进行密码重置。
		/// </summary>
		/// <param name="userId">要重置的用户编号。</param>
		/// <param name="secret">重置密码的验证码。</param>
		/// <param name="newPassword">重置后的新密码，如果为空(null)或空字符串("")则不进行密码设置，只进行验证码摘要的校验（即判断验证码摘要是否正确）。</param>
		/// <returns>如果重置或者验证码摘要校验成功则返回真(True)，否则返回假(False)。</returns>
		/// <remarks>
		///		<para>本重置方法通常由Web请求的方式进行，请求的URL大致如下：<c><![CDATA[http://JF.com/security/user/resetpassword?userId=xxx&secret=xxxxxx]]></c></para>
		/// </remarks>
		bool ResetPassword(long userId, string secret, string newPassword = null);

		/// <summary>
		/// 重置指定用户的密码，以验证码的方式进行密码重置。
		/// </summary>
		/// <param name="identity">要重置的用户标识，可以是“用户名”、“邮箱地址”或“手机号码”。</param>
		/// <param name="namespace">指定的用户标识所属的命名空间。</param>
		/// <param name="secret">重置密码的验证码。</param>
		/// <param name="newPassword">重置后的新密码，如果为空(null)或空字符串("")则不进行密码设置，只进行验证码的校验（即判断验证码是否正确）。</param>
		/// <returns>如果重置或者验证码校验成功则返回真(True)，否则返回假(False)。</returns>
		bool ResetPassword(string identity, string @namespace, string secret, string newPassword = null);

		/// <summary>
		/// 重置指定用户的密码，以密码问答的方式进行密码重置。
		/// </summary>
		/// <param name="identity">要重置的用户标识，可以是“用户名”、“邮箱地址”或“手机号码”。</param>
		/// <param name="namespace">指定的用户标识所属的命名空间。</param>
		/// <param name="passwordAnswers">指定用户的密码问答的答案集。</param>
		/// <param name="newPassword">重置后的新密码，如果为空(null)或空字符串("")则不进行密码设置，只进行密码问答的校验（即判断密码问答的答案集是否全部正确）。</param>
		/// <returns>如果重置或者密码问答校验成功则返回真(True)，否则返回假(False)。</returns>
		bool ResetPassword(string identity, string @namespace, string[] passwordAnswers, string newPassword = null);

		/// <summary>
		/// 获取指定用户的密码问答的题面集。
		/// </summary>
		/// <param name="userId">指定的用户编号。</param>
		/// <returns>返回指定用户的密码问答的题面，即密码问答的提示部分。</returns>
		string[] GetPasswordQuestions(long userId);

		/// <summary>
		/// 获取指定用户的密码问答的题面集。
		/// </summary>
		/// <param name="identity">指定的用户标识，可以是“用户名”、“邮箱地址”或“手机号码”。</param>
		/// <param name="namespace">指定的用户标识所属的命名空间。</param>
		/// <returns>返回指定用户的密码问答的题面，即密码问答的提示部分。</returns>
		string[] GetPasswordQuestions(string identity, string @namespace);

		/// <summary>
		/// 设置指定用户的密码问答集。
		/// </summary>
		/// <param name="userId">要设置密码问答集的用户编号。</param>
		/// <param name="password">当前用户的密码，如果密码错误则无法更新密码问答。</param>
		/// <param name="passwordQuestions">当前用户的密码问答的题面集。</param>
		/// <param name="passwordAnswers">当前用户的密码问答的答案集。</param>
		/// <returns>如果设置成则返回真(True)，否则返回假(False)。</returns>
		bool SetPasswordQuestionsAndAnswers(long userId, string password, string[] passwordQuestions, string[] passwordAnswers);

		/// <summary>
		/// 设置指定用户的密码参数选项。
		/// </summary>
		/// <param name="userId">要设置的用户编号。</param>
		/// <param name="changePasswordOnFirstTime">用户第一次登入是否必须变更密码的参数选项。</param>
		/// <param name="maxInvalidPasswordAttempts">锁定用户前允许的无效密码或无效密码提示问题答案尝试次数。</param>
		/// <param name="minRequiredPasswordLength">密码所要求的最小长度。</param>
		/// <param name="passwordAttemptWindow">无效密码被锁定后到下次解锁的间隔分钟数。</param>
		/// <param name="passwordExpires">密码的过期时间。</param>
		/// <returns>如果设置成功则返回真(True)，否则返回假(False)。</returns>
		bool SetPasswordOptions(long userId, bool changePasswordOnFirstTime = false, byte maxInvalidPasswordAttempts = 3, byte minRequiredPasswordLength = 6, TimeSpan? passwordAttemptWindow = null, DateTime? passwordExpires = null);

		#endregion
	}
}