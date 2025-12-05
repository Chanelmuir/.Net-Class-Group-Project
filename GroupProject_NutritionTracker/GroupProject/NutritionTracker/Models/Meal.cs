namespace NutritionTracker.Models
{
    public class Meal
    {
        public Meal() => Foods = new HashSet<Food>();

        // Primary Key
        public int MealId { get; set; }

        // 1:M with Day
        public int DayId { get; set; }
        public Day Day { get; set; } = null!;

        // Dish-based meal or custom meal
        public int? DishId { get; set; }
        public Dish? Dish { get; set; }

        // Custom meal food items
        public ICollection<Food> Foods { get; set; }

        // Meal name
        public string Name => Dish?.Name ?? "Custom Meal";

        // All foods for nutrition calculations
        private IEnumerable<Food> AllFoods =>
            Dish != null ? Dish.Foods : Foods;

        // Totals
        public double TotalCalories => AllFoods.Sum(f => f.Calories);
        public double TotalProtein => AllFoods.Sum(f => f.Protein);
        public double TotalCarbs => AllFoods.Sum(f => f.Carbohydrates);
        public double TotalFat => AllFoods.Sum(f => f.Fat);
    }
}
