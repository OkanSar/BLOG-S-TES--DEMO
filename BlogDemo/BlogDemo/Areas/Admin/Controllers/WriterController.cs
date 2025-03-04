using BlogDemo.Areas.Admin.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult WriterList()
        {
            writers = wm.GetList().Select(w => new WriterClass
            {
                Id = w.WirterID,
                Name = w.WriterName
            }).ToList();
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        [HttpGet]
        public IActionResult GetWriterByID(int writerid)
        {
            var findwriter = writers.FirstOrDefault(x => x.Id == writerid);
            if (findwriter == null)
            {
                return Json(null); // Yazar bulunamazsa boş JSON döndür
            }
            return Json(findwriter); // JSON Çevrim İşlemi Gerekli Değil
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }    
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.Id == w.Id);
            writer.Name = w.Name;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }


        public static List<WriterClass> writers = new List<WriterClass>
        {

        };
    }
}
