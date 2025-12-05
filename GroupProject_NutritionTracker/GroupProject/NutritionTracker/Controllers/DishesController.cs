using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutritionTracker.Models;

namespace NutritionTracker.Controllers
{
    public class DishesController : Controller
    {
        private readonly NutritionContext context;

        public DishesController(NutritionContext ctx)
        {
            context = ctx;
        }

        // Dishes/Details/5
        public IActionResult Details(int id)
        {
            var dish = context.Dishes
                .Include(d => d.Foods)
                .FirstOrDefault(d => d.DishId == id);

            if (dish == null)
            {
                return NotFound();
            }

            // Get favorite IDs for the current user
            var favoriteIds = context.Favorites.Select(f => f.DishId).ToHashSet();
            ViewBag.FavoriteIds = favoriteIds;

            return View(dish);
        }
    }
}
