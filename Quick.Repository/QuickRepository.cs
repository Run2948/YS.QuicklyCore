/* ==============================================================================
* 命名空间：Quick.Repository
* 类 名 称：QuickRepository
* 创 建 者：Qing
* 创建时间：2018-10-10 10:27:30
* CLR 版本：4.0.30319.42000
* 保存的文件名：QuickRepository
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quick.EFCore;
using Quick.Entity.Basic;
using Quick.Utility;

namespace Quick.Repository
{
    public class QuickRepository
    {
        #region Initialize

        public enum OperateCode
        {
            Insert = 0,
            Update = 1,
            Delete = 2
        }

        #endregion

        #region Service-Record

        /// <summary>
        /// 插入操作信息
        /// </summary>
        /// <param name="tableName">操作修改的表</param>
        /// <param name="className">操作所在类</param>
        /// <param name="methodName">操作方法</param>
        /// <param name="operate">操作内容</param>
        /// <param name="type">操作类型</param>
        /// <param name="dataId">操作表Id</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void InsertRecordAsync(string tableName, string className, string methodName, string operate, short type, long dataId, ApplicationDbContext context)
        {
            var model = new Record
            {
                TableName = tableName,
                ClassName = className,
                MethodName = methodName,
                Operate = operate,
                Type = type,
                DataId = dataId,
                UserOID = CurrentUser.UserOID,
                UserId = CurrentUser.UserId,
                UserName = CurrentUser.UserName
            };

            await context.Record.AddAsync(model);
        }

        /// <summary>
        /// 获取对同一对象操作信息
        /// </summary>
        /// <param name="objId">对象编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Record>> GetRecordListAsync(long objId, ApplicationDbContext context)
        {
            return await context.Record.AsNoTracking().Where(i => i.DataId == objId).ToListAsync();
        }

        #endregion

        #region Service-Account

        /// <summary>
        /// 获取登录账户信息
        /// </summary>
        /// <param name="account">帐户名</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<IdentityUser> GetUserAsync(string account, ApplicationDbContext context)
        {
            return await context.IdentityUser.AsNoTracking().Where(i => i.Account == account && i.IsEnabled == true).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// <param name="oid">主键</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<IdentityUser> GetUserByOIDAsync(string oid, ApplicationDbContext context)
        {
            return await context.IdentityUser.AsNoTracking().Where(i => i.IdentityUserOID == oid).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// <param name="account">帐户名</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<IdentityUser> GetUserByAccountAsync(string account, ApplicationDbContext context)
        {
            return await context.IdentityUser.AsNoTracking().Where(i => i.Account == account).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<IdentityUser> GetUserByIdAsync(long id, ApplicationDbContext context)
        {
            return await context.IdentityUser.AsNoTracking().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        #endregion
    }
}
