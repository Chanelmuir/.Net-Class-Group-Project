namespace NutritionTracker.Models
{
    public class Favorite
    {
        // Primary Key
        public int FavoriteId { get; set; }

        // Foreign Key to Dish
        public int DishId { get; set; }
        public Dish Dish { get; set; } = null!;
    }
}
