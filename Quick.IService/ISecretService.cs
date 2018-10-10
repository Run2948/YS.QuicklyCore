/* ==============================================================================
* 命名空间：Quick.IService
* 类 名 称：ISecretService
* 创 建 者：Qing
* 创建时间：2018-10-10 10:24:46
* CLR 版本：4.0.30319.42000
* 保存的文件名：ISecretService
* 文件版本：V1.0.0.0
*
* 功能描述：N/A 
*
* 修改历史：
*
*
* ==============================================================================
*         CopyRight @ 班纳工作室 2018. All rights reserved
* ==============================================================================*/



using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Quick.EFCore;
using Quick.Entity.Basic;

namespace Quick.IService
{
    public interface ISecretService
    {
        #region Service

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="password">密码</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        Task<IdentityUser> GetUserAsync(string account, string password, ApplicationDbContext context);

        /// <summary>
        /// 设置当前登录用户
        /// </summary>
        /// <param name="oid"></param>
        /// <param name="context"></param>
        /// <param name="httpContextAccessor"></param>
        Task SetCurrentUser(string oid, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context);

        /// <summary>
        /// 移除当前用户
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <returns></returns>
        void RemoveCurrentUser(IHttpContextAccessor httpContextAccessor);

        /// <summary>
        /// 清除session数据
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <returns></returns>
        void ClearSession(IHttpContextAccessor httpContextAccessor);

        #endregion
    }
}
