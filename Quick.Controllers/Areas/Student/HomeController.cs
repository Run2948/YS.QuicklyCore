using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quick.Controllers.Filters;

namespace Quick.Controllers.Areas.Student
{
    [Area("Student")]
    [Authorize(Policy = "Student")]
    public class HomeController : QuickController
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}