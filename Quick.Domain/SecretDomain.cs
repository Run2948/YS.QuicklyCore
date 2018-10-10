/* ==============================================================================
* 命名空间：Quick.Domain
* 类 名 称：SecretDomain
* 创 建 者：Qing
* 创建时间：2018-10-10 10:26:21
* CLR 版本：4.0.30319.42000
* 保存的文件名：SecretDomain
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
using Quick.IService;
using Quick.Repository;
using Quick.Utility;

namespace Quick.Domain
{
    public class SecretDomain : ISecretService
    {
        #region Interface Service Implement

        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<IdentityUser> GetUserAsync(string account, string password, ApplicationDbContext context)
        {
            return await QuickRepository.GetUserAsync(account, context);
        }

        /// <summary>
        /// 移除登录用户信息
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <returns></returns>
        public void RemoveCurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            httpContextAccessor.HttpContext.Session.SetString("CurrentUser_UserOID", "");
            httpContextAccessor.HttpContext.Session.SetString("CurrentUser_UserId", "0");
            httpContextAccessor.HttpContext.Session.SetString("CurrentUser_UserName", "");
            httpContextAccessor.HttpContext.Session.SetString("CurrentUser_UserAccount", "");
            httpContextAccessor.HttpContext.Session.SetString("CurrentUser_UserImage", "");
            httpContextAccessor.HttpContext.Session.SetString("CurrentUser_UserRole", "");
            httpContextAccessor.HttpContext.Session.SetString("CurrentUser_UserPage", "");
        }

        /// <summary>
        /// 清除Session数据
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <returns></returns>
        public void ClearSession(IHttpContextAccessor httpContextAccessor)
        {
            httpContextAccessor.HttpContext.Session.Clear();
        }

        /// <summary>
        /// 设置当前登录用户
        /// </summary>
        public async Task SetCurrentUser(string oid, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            CurrentUser.Configure(httpContextAccessor);

            var user = await QuickRepository.GetUserByOIDAsync(oid, context);

            if (user != null)
            {
                string role = string.Empty;
                switch (user.AccountType)
                {
                    case 0:
                        role = "Administrator";
                        break;
                    case 1:
                        role = "Instructor";
                        break;
                    case 2:
                        role = "Student";
                        break;
                }

                CurrentUser.UserAccount = user.Account;
                CurrentUser.UserId = user.Id;
                CurrentUser.UserImage = user.ImageSrc;
                CurrentUser.UserName = user.Name;
                CurrentUser.UserOID = user.IdentityUserOID;
                CurrentUser.UserRole = role;
                CurrentUser.UserPage = user.HomePage;
            }
        }

        #endregion
    }
}
