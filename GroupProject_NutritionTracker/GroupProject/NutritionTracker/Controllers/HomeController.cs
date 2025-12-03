using Microsoft.AspNetCore.Mvc;
using NutritionTracker.Models;

namespace NutritionTracker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Always use today's date
            var today = DateTime.Today;

            var model = new HomeViewModel
            {
                SelectedDate = today,
                TotalCalories = 0,
                TotalProtein = 0,
                TotalCarbs = 0,
                TotalFat = 0,
                MaxCalorieIntake = 2500,  // default placeholder (can change to a user set value - needs view)
                Meals = new List<MealSummary>()
            };

            return View(model);
        }

        public IActionResult Planner()
        {
            return View(); // new PlannerViewModel() ?
        }

        public IActionResult Menu()
        {
            return View(); // new MenuViewModel() ?
        }

        public IActionResult Favorites()
        {
            return View(); // new Favorites ViewModel() ?
        }

        // Wipe today's meals + totals in the DB
        public IActionResult ResetDay()
        {
            
            return RedirectToAction("Index");
        }
    }
}
