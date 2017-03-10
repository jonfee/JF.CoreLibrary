using System;
using System.Collections.Generic;

namespace JF.Security.Membership
{
	/// <summary>
	/// 提供关于角色成员管理的接口。
	/// </summary>
	public interface IMemberProvider
	{
		/// <summary>
		/// 确定指定的用户是否属于指定的角色。
		/// </summary>
		/// <param name="userId">要检查的用户编号。</param>
		/// <param name="roleId">要确认的角色编号。</param>
		/// <returns>如果指定的用户是指定角色的成员则返回真(true)；否则返回假(false)。</returns>
		bool InRole(long userId, long roleId);

		/// <summary>
		/// 确定指定的用户是否属于指定的角色。
		/// </summary>
		/// <param name="userId">要检查的用户编号。</param>
		/// <param name="roleNames">要确认的角色名称数组。</param>
		/// <returns>如果指定的用户是指定角色名称中的任一成员则返回真(true)；否则返回假(false)。</returns>
		bool InRoles(long userId, params string[] roleNames);

		/// <summary>
		/// 获取指定成员的父级角色集。
		/// </summary>
		/// <param name="memberId">要搜索的成员编号(用户或角色)。</param>
		/// <param name="memberType">要搜索的成员类型。</param>
		/// <returns>返回指定成员的父级角色集。</returns>
		IEnumerable<Role> GetRoles(long memberId, MemberType memberType);

		/// <summary>
		/// 获取指定角色的直属成员集。
		/// </summary>
		/// <param name="roleId">要搜索的角色编号。</param>
		/// <returns>返回隶属于指定角色的直属子级成员集。</returns>
		IEnumerable<Member> GetMembers(long roleId);

		/// <summary>
		/// 设置更新指定角色下的成员。
		/// </summary>
		/// <param name="roleId">指定要更新的角色编号。</param>
		/// <param name="members">要更新的角色成员集。</param>
		/// <returns>如果更新成功则返回更新的数量，否则返回零。</returns>
		int SetMembers(long roleId, params Member[] members);

		/// <summary>
		/// 设置更新指定角色下的成员。
		/// </summary>
		/// <param name="roleId">指定要更新的角色编号。</param>
		/// <param name="members">要更新的角色成员集。</param>
		/// <param name="shouldResetting">指示是否以重置的方式更新角色成员，即是否在更新角色成员之前先清空指定角色下的所有成员。默认值为假(False)。</param>
		/// <returns>如果更新成功则返回更新的数量，否则返回零。</returns>
		int SetMembers(long roleId, IEnumerable<Member> members, bool shouldResetting = false);

		/// <summary>
		/// 删除一个或多个角色成员。
		/// </summary>
		/// <param name="members">要删除的角色成员数组。</param>
		/// <returns>如果删除成功则返回删除的数量，否则返回零。</returns>
		int DeleteMembers(params Member[] members);

		/// <summary>
		/// 删除单个或多个角色成员。
		/// </summary>
		/// <param name="members">要删除的角色成员集合。</param>
		/// <returns>如果删除成功则返回删除的数量，否则返回零。</returns>
		int DeleteMembers(IEnumerable<Member> members);

		/// <summary>
		/// 创建单个或多个角色成员。
		/// </summary>
		/// <param name="members">要创建的角色成员数组。</param>
		/// <returns>返回创建成功的角色成员数量。</returns>
		int CreateMembers(params Member[] members);

		/// <summary>
		/// 创建单个或多个角色成员。
		/// </summary>
		/// <param name="members">要创建的角色成员集合。</param>
		/// <returns>返回创建成功的角色成员数量。</returns>
		int CreateMembers(IEnumerable<Member> members);
	}
}