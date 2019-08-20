using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
using travel_mvc.Models;

namespace travel_mvc.Controllers
{
    public class DestinationsController : Controller
    {
        public IActionResult Index()
        {
            var allDestinations = Destination.GetDestinations();
            return View(allDestinations);
        }

        public ActionResult Create()
        {
            // ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
            return View();
        }
    }
}