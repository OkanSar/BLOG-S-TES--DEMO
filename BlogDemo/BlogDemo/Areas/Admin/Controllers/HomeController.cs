using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
