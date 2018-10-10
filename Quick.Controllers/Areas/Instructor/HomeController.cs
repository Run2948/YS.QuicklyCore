using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quick.Controllers.Filters;

namespace Quick.Controllers.Areas.Instructor
{
    [Area("Instructor")]
    [Authorize(Policy = "Instructor")]
    public class HomeController : QuickController
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}