namespace NutritionTracker.Models
{
    public class Dish
    {
        public Dish()
        {
            Foods = new HashSet<Food>();
            Meals = new HashSet<Meal>();
        }

        // Primary Key
        public int DishId { get; set; }
        public string Name { get; set; } = string.Empty;

        // 1:1 with Favorite
        public Favorite Favorite { get; set; } = null!;

        // M:M with Food
        public ICollection<Food> Foods { get; set; }

        // 1:M with Meal
        public ICollection<Meal> Meals { get; set; }

        // Nutrition totals
        public double TotalCalories => Foods?.Sum(f => f.Calories) ?? 0;
        public double TotalProtein => Foods?.Sum(f => f.Protein) ?? 0;
        public double TotalCarbs => Foods?.Sum(f => f.Carbohydrates) ?? 0;
        public double TotalFat => Foods?.Sum(f => f.Fat) ?? 0;
    }
}
