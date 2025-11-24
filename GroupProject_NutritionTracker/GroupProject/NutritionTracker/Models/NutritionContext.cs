using Microsoft.EntityFrameworkCore;

namespace NutritionTracker.Models
{
    public class NutritionContext : DbContext
    {
        public NutritionContext(DbContextOptions<NutritionContext> options)
            : base(options)
        { }

        public DbSet<Day> Days { get; set; } = null!;
        public DbSet<Meal> Meals { get; set; } = null!;
        public DbSet<Dish> Dishes { get; set; } = null!;
        public DbSet<Food> Foods { get; set; } = null!;
        public DbSet<Favorite> Favorites { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1:1 — Dish (to) Favorite
            modelBuilder.Entity<Dish>()
                .HasOne(d => d.Favorite)
                .WithOne(f => f.Dish)
                .HasForeignKey<Favorite>(f => f.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:M — Day (to) Meals
            modelBuilder.Entity<Day>()
                .HasMany(d => d.Meals)
                .WithOne(m => m.Day)
                .HasForeignKey(m => m.DayId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:M — Dish (to) Meals
            modelBuilder.Entity<Dish>()
                .HasMany(d => d.Meals)
                .WithOne(m => m.Dish)
                .HasForeignKey(m => m.DishId)
                .OnDelete(DeleteBehavior.Restrict);

            // M:M — Dishes (to) Foods  (DishFoods link)
            modelBuilder.Entity<Dish>()
                .HasMany(d => d.Foods)
                .WithMany(f => f.Dishes)
                .UsingEntity<Dictionary<string, object>>(
                    "DishFoods",
                    df => df.HasOne<Food>()
                        .WithMany()
                        .HasForeignKey("FoodId"),
                    df => df.HasOne<Dish>()
                        .WithMany()
                        .HasForeignKey("DishId")
                );

            // M:M — Meals ? Foods  (MealFoods link)
            modelBuilder.Entity<Meal>()
                .HasMany(m => m.Foods)
                .WithMany(f => f.Meals)
                .UsingEntity<Dictionary<string, object>>(
                    "MealFoods",
                    mf => mf.HasOne<Food>()
                        .WithMany()
                        .HasForeignKey("FoodId"),
                    mf => mf.HasOne<Meal>()
                        .WithMany()
                        .HasForeignKey("MealId")
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
