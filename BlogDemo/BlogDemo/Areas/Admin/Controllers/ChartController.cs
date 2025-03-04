using BlogDemo.Areas.Admin.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        CategoryManager wm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            categorys = wm.GetList().Select(w => new CategoryClass
            {
                categorycount = w.CategoryID, // Eğer kategori sayısı ID değilse, doğru alanı kullan!
                categoryname = w.CategoryName,
            }).ToList();

            return Json(new { jsonlist = categorys }); // ✅ JSON formatını düzelttik
        }

        public static List<CategoryClass> categorys = new List<CategoryClass>
        {

        };
    }
}
