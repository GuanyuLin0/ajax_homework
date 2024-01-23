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
            return View();
        }

        public IActionResult Cities()
        {
            var cities = _dbContext.Addresses.Select(a=> a.City).Distinct();
            return Json(cities);
        }
    }
}
