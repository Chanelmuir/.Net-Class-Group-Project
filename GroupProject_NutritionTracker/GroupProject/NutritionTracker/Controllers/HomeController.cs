using Microsoft.AspNetCore.Mvc;
using NutritionTracker.Models;

namespace NutritionTracker.Controllers
{
    public class HomeController : Controller
    {
        private NutritionContext context { get; set; }
        public HomeController(NutritionContext ctx) => context = ctx;
        public IActionResult Index()
        {
            return View();
        }
    }
}
