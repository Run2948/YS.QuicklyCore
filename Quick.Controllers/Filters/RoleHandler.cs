using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Quick.Controllers.Filters
{
    public class RoleHandler : AuthorizationHandler<RoleRequirement>
    {
        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Issuer == "LOCAL AUTHORITY"))
            {
                return Task.CompletedTask;
            }

            var role = context.User.FindFirst(c => c.Type == ClaimTypes.Role && c.Issuer == "LOCAL AUTHORITY").Value;

            if (role.Equals(requirement.Role))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
