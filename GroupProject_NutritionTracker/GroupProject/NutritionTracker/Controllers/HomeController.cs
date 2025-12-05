using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutritionTracker.Models;

namespace NutritionTracker.Controllers
{
    public class HomeController : Controller
    {
        private NutritionContext context;

        public HomeController(NutritionContext ctx)
        {
            context = ctx;
        }

        // Home Page
        public IActionResult Index()
        {
            var today = DateTime.Today;

            // Load today's day entries
            var day = context.Days
                .Where(d => d.Date == today)
                .Include(d => d.Meals)
                    .ThenInclude(m => m.Dish)
                        .ThenInclude(dh => dh.Foods)
                .FirstOrDefault();

            // If no day exists yet, show blank screen
            if (day == null)
            {
                return View(new HomeViewModel
                {
                    SelectedDate = today,
                    Meals = new List<MealSummary>(),
                    MaxCalorieIntake = 2500,
                    TotalCalories = 0,
                    TotalProtein = 0,
                    TotalCarbs = 0,
                    TotalFat = 0
                });
            }

            double totalCals = 0;
            double totalProtein = 0;
            double totalCarbs = 0;
            double totalFat = 0;

            List<MealSummary> summaries = new();

            foreach (var meal in day.Meals)
            {
                var foods = meal.Dish.Foods;

                double mealCals = foods.Sum(f => f.Calories);
                double mealProtein = foods.Sum(f => f.Protein);
                double mealCarbs = foods.Sum(f => f.Carbohydrates);
                double mealFat = foods.Sum(f => f.Fat);

                totalCals += mealCals;
                totalProtein += mealProtein;
                totalCarbs += mealCarbs;
                totalFat += mealFat;

                summaries.Add(new MealSummary
                {
                    MealId = meal.MealId,
                    Name = meal.Dish.Name,
                    TotalCalories = mealCals
                });
            }

            var vm = new HomeViewModel
            {
                SelectedDate = today,
                Meals = summaries,
                TotalCalories = totalCals,
                TotalProtein = totalProtein,
                TotalCarbs = totalCarbs,
                TotalFat = totalFat,
                MaxCalorieIntake = 2500
            };

            return View(vm);
        }

        // Show all days with their items
        public IActionResult Planner()
        {
            var days = context.Days
                .Include(d => d.Meals)
                    .ThenInclude(m => m.Dish)
                .OrderBy(d => d.Date)
                .ToList();

            return View(days);
        }

        // List all items
        public IActionResult Menu()
        {
            var dishes = context.Dishes
                .Include(d => d.Foods)
                .ToList();

            return View(dishes);
        }

        // List all favorite items
        public IActionResult Favorites()
        {
            var favorites = context.Favorites
                .Include(f => f.Dish)
                    .ThenInclude(d => d.Foods)
                .ToList();

            return View(favorites);
        }

        // Delete today's meals
        public IActionResult ResetDay()
        {
            var today = DateTime.Today;

            var day = context.Days
                .Include(d => d.Meals)
                .FirstOrDefault(d => d.Date == today);

            if (day != null)
            {
                // Delete today's meals
                context.Meals.RemoveRange(day.Meals);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
