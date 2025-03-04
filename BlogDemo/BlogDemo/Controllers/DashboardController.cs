using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
    public class DashboardController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
           
            Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x=>x.UserName == username).Select(y=>y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WirterID).FirstOrDefault();
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x=>x.WriterID== writerID).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
