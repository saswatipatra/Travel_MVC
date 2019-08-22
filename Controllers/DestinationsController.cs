using Microsoft.AspNetCore.Mvc;
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

        public IActionResult IndexNext()
        {
            var nextDestinations = Destination.GetNextDestinations();
            return View("Index", nextDestinations);
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

        
        public IActionResult Edit(int id)
        {
            var particularDestination = Destination.GetPaticularDestinations(id);
            return View(particularDestination);
        }

        [HttpPost]
        public IActionResult Edit(int id, Destination destination)
        {
            Destination.EditDestination(id,destination);
            return RedirectToAction("Index");
        }
    }
}