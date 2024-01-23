using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class APIController : Controller
    {
        private readonly MyDBContext _dbContext;
        public APIController(MyDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        
        public IActionResult Index()
        {
            //delay 5s
            System.Threading.Thread.Sleep(5000);
            //return Content("Hello Content");

            return Content("Content,你好","text/plain",System.Text.Encoding.UTF8);
        }
        
        public IActionResult First()
        {
            return View();
        }


        public IActionResult Cities()
        {
            var cities = _dbContext.Addresses.Select(a=> a.City).Distinct();
            return Json(cities);
        }

        public IActionResult Districts(string city)
        {
            var districts = _dbContext.Addresses.Where(a=>a.City == city).Select(a => a.SiteId).Distinct();
            return Json(districts);
        }

        public IActionResult CheckAccount()
        {
            var members = _dbContext.Members.Select(a=>a.Name);
            return Json(members);
        }

        public IActionResult Roads(string site)
        {
            var roads = _dbContext.Addresses.Where(a => a.SiteId == site).Select(a => a.Road);
            return Json(roads);
        }

        public IActionResult Avatar(int id = 1)
        {
            Member? member = _dbContext.Members.Find(id);
            if(member != null)
            {
                byte[] img = member.FileData;
                return File(img, "image/jpeg");
            }
            return NotFound();
        }

        public IActionResult Register(string name,int age = 26)
        {
            if(string.IsNullOrEmpty(name))
            {
                name = "Guest";
            }
            return Content($"Hello {name},You are {age} years old.");
        }
    }
}
