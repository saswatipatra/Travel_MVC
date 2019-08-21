using Microsoft.AspNetCore.Mvc;
using travel_mvc.Models;

namespace travel_mvc.Controllers
{
    public class ReviewsController : Controller
    {
        public ActionResult Create(int id)
        {
            ViewBag.DestinationId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            Review.PostReview(review);
            return RedirectToAction("Details", "Destinations", new { id = review.DestinationId });
        }
    }
}