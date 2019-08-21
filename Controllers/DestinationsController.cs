using Microsoft.AspNetCore.Mvc;
using System;
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

        public IActionResult Details(int id)
        {
            var particularDestination = Destination.GetPaticularDestinations(id);
            return View(particularDestination);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Destination destination)
        {
            Destination.PostDestination(destination);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Destination.DeleteDestination(id);
            return RedirectToAction("Index");
        }
    }
}