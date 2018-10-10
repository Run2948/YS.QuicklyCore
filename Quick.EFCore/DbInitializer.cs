/* ==============================================================================
* 命名空间：Quick.EFCore
* 类 名 称：DbInitializer
* 创 建 者：Qing
* 创建时间：2018-10-09 19:40:01
* CLR 版本：4.0.30319.42000
* 保存的文件名：DbInitializer
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
using Quick.Entity.Basic;
using Quick.Utility.System;

namespace Quick.EFCore
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.IdentityUser.Any())
                return;

            var salt = Guid.NewGuid().ToString();

            IdentityUser admin = new IdentityUser
            {
                Name = "管理员",
                Account = "admin",
                AccountType = 0,
                Age = 0,
                Birthday = new DateTime(),
                Salt = salt,
                Password = Md5Utility.Sign("123456", salt),
                Gender = true,
                IsEnabled = true,
                Email = "admin@163.com",
                HomePage = "Administrator",
                IdNumber = "0",
                DepartmentId = 0,
                Department = "管理员部门"
            };

            context.IdentityUser.Add(admin);
            context.SaveChanges();

        }
    }
}
