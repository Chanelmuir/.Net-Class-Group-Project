namespace NutritionTracker.Models
{
    public class Day
    {
        
        public Day() => Meals = new HashSet<Meal>();
        public int DayId { get; set; }
        public DateTime Date { get; set; }

        // 1:M with Meal
        public ICollection<Meal> Meals { get; set; }
    }
}
