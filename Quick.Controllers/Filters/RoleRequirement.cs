using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Quick.Controllers.Filters
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Role { get; private set; }

        public RoleRequirement(string role)
        {
            this.Role = role;
        }
    }
}
