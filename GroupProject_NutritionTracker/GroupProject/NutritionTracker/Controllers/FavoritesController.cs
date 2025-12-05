using Microsoft.AspNetCore.Mvc;
using NutritionTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace NutritionTracker.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly NutritionContext _context;

        public FavoritesController(NutritionContext context)
        {
            _context = context;
        }

        // List favorites
        public IActionResult Index()
        {
            var favorites = _context.Favorites
                .Include(f => f.Dish)
                    .ThenInclude(d => d.Foods)
                .ToList();

            return View(favorites);
        }

        // Toggle favorite (add if missing, remove if exists)
        public IActionResult Toggle(int id)
        {
            var fav = _context.Favorites.FirstOrDefault(f => f.DishId == id);

            if (fav == null)
            {
                _context.Favorites.Add(new Favorite { DishId = id });
            }
            else
            {
                _context.Favorites.Remove(fav);
            }

            _context.SaveChanges();

            // Go back to where the user was
            return Redirect(Request.Headers["Referer"].ToString());
        }

        // Delete by FavoriteId (used by the Favorites page)
        public IActionResult Delete(int id)
        {
            var fav = _context.Favorites.Find(id);

            if (fav != null)
            {
                _context.Favorites.Remove(fav);
                _context.SaveChanges();
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
