namespace NutritionTracker.Models
{
    public class HomeViewModel
    {
        public DateTime SelectedDate { get; set; }

        public int TotalCalories { get; set; }
        public int TotalProtein { get; set; }
        public int TotalCarbs { get; set; }
        public int TotalFat { get; set; }

        // user's chosen max daily calorie limit
        public int MaxCalorieIntake { get; set; }

        public List<MealSummary> Meals { get; set; } = new();
    }

    public class MealSummary
    {
        public int MealId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TotalCalories { get; set; }
    }
}
