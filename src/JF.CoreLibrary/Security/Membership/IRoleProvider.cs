﻿using System;
using System.Collections.Generic;

namespace JF.Security.Membership
{
	/// <summary>
	/// 提供关于角色和角色成员管理的接口。
	/// </summary>
	public interface IRoleProvider
	{
		/// <summary>
		/// 确定指定编号的角色是否存在。
		/// </summary>
		/// <param name="roleId">指定要查找的角色编号。</param>
		/// <returns>如果指定编号的角色是存在的则返回真(True)，否则返回假(False)。</returns>
		bool Exists(long roleId);

		/// <summary>
		/// 确定指定的角色名在指定的命名空间内是否已经存在。
		/// </summary>
		/// <param name="name">要确定的角色名。</param>
		/// <param name="namespace">要确定的角色所属的命名空间。</param>
		/// <returns>如果指定名称的角色在命名空间内已经存在则返回真(True)，否则返回假(False)。</returns>
		bool Exists(string name, string @namespace);

		/// <summary>
		/// 获取指定编号对应的角色对象。
		/// </summary>
		/// <param name="roleId">要查找的角色编号。</param>
		/// <returns>返回由<paramref name="roleId"/>参数指定的角色对象，如果没有找到指定编号的角色则返回空。</returns>
		Role GetRole(long roleId);

		/// <summary>
		/// 获取指定名称对应的角色对象。
		/// </summary>
		/// <param name="name">要查找的角色名称。</param>
		/// <param name="namespace">要查找的角色所属的命名空间。</param>
		/// <returns>返回找到的角色对象；如果在指定的命名空间内没有找到指定名称的角色则返回空(null)。</returns>
		/// <exception cref="System.ArgumentNullException">当<paramref name="name"/>参数为空(null)或者全空格字符。</exception>
		Role GetRole(string name, string @namespace);

		/// <summary>
		/// 获取当前命名空间中的所有角色。
		/// </summary>
		/// <param name="namespace">要获取的用户集所属的命名空间。</param>
		/// <param name="paging">查询的分页设置，默认为第一页。</param>
		/// <returns>返回当前命名空间中的所有角色对象集。</returns>
		IEnumerable<Role> GetAllRoles(string @namespace, JF.Data.Paging paging = null);

		/// <summary>
		/// 删除指定编号集的多个角色。
		/// </summary>
		/// <param name="roleIds">要删除的角色编号集合。</param>
		/// <returns>如果删除成功则返回删除的数量，否则返回零。</returns>
		int DeleteRoles(params int[] roleIds);

		/// <summary>
		/// 创建单个或者多个角色。
		/// </summary>
		/// <param name="roles">要创建的角色对象数组。</param>
		/// <returns>返回创建成功的角色数量。</returns>
		int CreateRoles(params Role[] roles);

		/// <summary>
		/// 创建单个或者多个角色。
		/// </summary>
		/// <param name="roles">要创建的角色对象集。</param>
		/// <returns>返回创建成功的角色数量。</returns>
		int CreateRoles(IEnumerable<Role> roles);

		/// <summary>
		/// 更新单个或多个角色信息。
		/// </summary>
		/// <param name="roles">要更新的角色对象数组。</param>
		/// <returns>返回更新成功的角色数量。</returns>
		int UpdateRoles(params Role[] roles);

		/// <summary>
		/// 更新单个或多个角色信息。
		/// </summary>
		/// <param name="roles">要更新的角色对象集。</param>
		/// <param name="scope">指定需要更新的字段集，字段名之间使用逗号分隔。</param>
		/// <returns>返回更新成功的角色数量。</returns>
		int UpdateRoles(IEnumerable<Role> roles, string scope = null);
	}
}