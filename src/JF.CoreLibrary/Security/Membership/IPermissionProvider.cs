using System;
using System.Collections.Generic;

namespace JF.Security.Membership
{
	/// <summary>
	/// 提供关于权限管理的接口。
	/// </summary>
	public interface IPermissionProvider
	{
		/// <summary>
		/// 获取指定用户或角色的权限集。
		/// </summary>
		/// <param name="memberId">指定要获取的权限集的成员编号(用户或角色)。</param>
		/// <param name="memberType">指定要获取的权限集的成员类型。</param>
		/// <returns>返回指定用户或角色的权限集。注意：该结果集不包含指定成员所属的上级角色的权限设置。</returns>
		IEnumerable<Permission> GetPermissions(long memberId, MemberType memberType);

		/// <summary>
		/// 设置指定用户或角色的权限集。
		/// </summary>
		/// <param name="memberId">指定的要设置的权限集的成员编号(用户或角色)。</param>
		/// <param name="memberType">指定的要设置的权限集的成员类型。</param>
		/// <param name="permissions">要设置更新的权限集。</param>
		/// <remarks>
		///		<para>该方法默认以覆盖方式进行更新。即先清空指定成员的所有权限设置项，然后再将<paramref name="permissions"/>参数指定的权限项插入其中。</para>
		/// </remarks>
		void SetPermissions(long memberId, MemberType memberType, IEnumerable<Permission> permissions);

		/// <summary>
		/// 获取指定用户或角色的权限过滤集。
		/// </summary>
		/// <param name="memberId">指定要获取的权限过滤集的成员编号(用户或角色)。</param>
		/// <param name="memberType">指定要获取的权限过滤集的成员类型。</param>
		/// <returns>返回指定用户或角色的权限过滤集。注意：该结果集不包含指定成员所属的上级角色的权限设置。</returns>
		IEnumerable<PermissionFilter> GetPermissionFilters(long memberId, MemberType memberType);

		/// <summary>
		/// 设置指定用户或角色的权限过滤集。
		/// </summary>
		/// <param name="memberId">指定的要设置的权限过滤集的成员编号(用户或角色)。</param>
		/// <param name="memberType">指定的要设置的权限过滤集的成员类型。</param>
		/// <param name="permissionFilters">要设置更新的权限过滤集。</param>
		/// <remarks>
		///		<para>该方法默认以覆盖方式进行更新。即先清空指定成员的所有权限过滤设置项，然后再将<paramref name="permissionFilters"/>参数指定的权限过滤项插入其中。</para>
		/// </remarks>
		void SetPermissionFilters(long memberId, MemberType memberType, IEnumerable<PermissionFilter> permissionFilters);
	}
}