using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quick.Controllers.Filters;

namespace Quick.Controllers.Areas.Administrator
{
    [Area("Administrator")]
    [Authorize(Policy = "Administrator")]
    public class HomeController : QuickController
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}