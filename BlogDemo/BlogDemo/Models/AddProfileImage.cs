using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogDemo.Models
{
    public class AddProfileImage
    {
        public int WirterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPasswprd { get; set; }
        public bool WriterStatus { get; set; }
    }
}
