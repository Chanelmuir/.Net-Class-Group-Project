namespace NutritionTracker.Models
{
    public class Meal
    {
        // Primary Key
        public Meal() => Foods = new HashSet<Food>();
        public int MealId { get; set; }

        // 1:M with Day
        public int DayId { get; set; }
        public Day Day { get; set; } = null!;

        // 1:M with Dish
        public int DishId { get; set; }
        public Dish Dish { get; set; } = null!;

        // M:M with Food (custom meals)
        public ICollection<Food> Foods { get; set; }
    }

}
