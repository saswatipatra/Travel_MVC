using Microsoft.AspNetCore.Mvc;
using travel_mvc.Models;

namespace travel_mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var allDestinations = Destination.GetDestinations();
            return View(allDestinations);
        }
    }
}