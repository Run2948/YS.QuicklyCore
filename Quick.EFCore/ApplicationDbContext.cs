/* ==============================================================================
* 命名空间：Quick.EFCore
* 类 名 称：ApplicationDbContext
* 创 建 者：Qing
* 创建时间：2018-10-09 19:38:51
* CLR 版本：4.0.30319.42000
* 保存的文件名：ApplicationDbContext
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
using Microsoft.EntityFrameworkCore;
using Quick.Entity.Basic;

namespace Quick.EFCore
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        /// <summary>
        /// 网站登录日志表
        /// </summary>
        public virtual DbSet<Logging> Logging { get; set; }

        /// <summary>
        /// 账号操作记录表
        /// </summary>
        public virtual DbSet<Record> Record { get; set; }

        /// <summary>
        /// 账号信息表
        /// </summary>
        public virtual DbSet<IdentityUser> IdentityUser { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            #region Add ConcurrencyToken

            //modelBuilder.Entity<Goods>().Property(p => p.ModifiedOn).IsConcurrencyToken();

            #endregion
        }
    }
}
