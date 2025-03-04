using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writermessage = new WriterManager(new EfWriterRepository());

        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            ViewBag.name = username;
            var usermail = c.Users.Where(x=>x.UserName==username).Select(y=>y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WirterID).FirstOrDefault();
            var values = writermessage.GetWriterById(writerID);
            return View(values);
        }
    }
}
