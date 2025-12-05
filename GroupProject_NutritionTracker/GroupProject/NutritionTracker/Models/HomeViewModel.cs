namespace NutritionTracker.Models
{
    public class HomeViewModel
    {
        public DateTime SelectedDate { get; set; }

        public double TotalCalories { get; set; }
        public double TotalProtein { get; set; }
        public double TotalCarbs { get; set; }
        public double TotalFat { get; set; }

        // User's chosen max daily calorie limit
        public int MaxCalorieIntake { get; set; }

        public List<MealSummary> Meals { get; set; } = new();
    }

    public class MealSummary
    {
        public int MealId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double TotalCalories { get; set; }   // changed to double
    }
}
