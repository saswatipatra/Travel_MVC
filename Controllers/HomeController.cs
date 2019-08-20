using Microsoft.AspNetCore.Mvc;
using travel_mvc.Models;

namespace travel_mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}