using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Quick.Utility;

namespace Quick.Controllers.Filters
{
    public class QuickController : Controller
    {
        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CurrentUser.UserId == 0)
            {
                string path = filterContext.HttpContext.Request.Path;
                filterContext.Result = new RedirectResult($"/Secret/Login?ReturnUrl={path}");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}