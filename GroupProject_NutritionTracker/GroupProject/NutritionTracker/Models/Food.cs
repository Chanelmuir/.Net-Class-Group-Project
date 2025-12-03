namespace NutritionTracker.Models
{
    public class Food
    {
        public Food()
        {
            Dishes = new HashSet<Dish>();
            Meals = new HashSet<Meal>();
        }
        // Primary Key
        public int FoodId { get; set; }

        // Fields
        public string Name { get; set; } = string.Empty;
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }

        // M:M with Dish
        public ICollection<Dish> Dishes { get; set; }

        // M:M with Meal
        public ICollection<Meal> Meals { get; set; }
    }
}
