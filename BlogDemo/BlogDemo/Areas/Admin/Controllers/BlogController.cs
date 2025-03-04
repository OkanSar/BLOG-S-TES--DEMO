using BlogDemo.Areas.Admin.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1,1).Value = "Blog ID";
                worksheet.Cell(1,2).Value = "Blog Adı";

                int BlogRowCaunt = 2;
                foreach(var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCaunt, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCaunt, 2).Value = item.BlogName;
                    BlogRowCaunt++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,"application/vmd.openxmlformats-officedocument.spreadsheetml.sheet","Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{ID = 1,BlogName="C# Programlamaya Giriş"},
                new BlogModel{ID = 2,BlogName="Tesla Firmasının Araçları"},
                new BlogModel{ID = 2,BlogName="2020 Olimpiyatları"}
            };
            return bm;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCaunt = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCaunt, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCaunt, 2).Value = item.BlogName;
                    BlogRowCaunt++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vmd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm = new List<BlogModel2>();
            using (var c = new Context())
            {
                bm=c.Blogs.Select(x=>new BlogModel2 
                {
                    ID = x.BlogID,
                    BlogName=x.BlogTitle
                }).ToList();
            }
            return bm;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
