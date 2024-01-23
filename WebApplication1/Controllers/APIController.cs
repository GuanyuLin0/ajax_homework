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
    }
}
