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
                        .HasForeignKey("DishId"),
                    df => df.HasData(
                        new { DishId = 1, FoodId = 1 }, // Chicken in Chicken & Rice
                        new { DishId = 1, FoodId = 2 } // Rice in Chicken & Rice
                    )
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
                        .HasForeignKey("MealId"),
                    mf => mf.HasData(
                        new { MealId = 1, FoodId = 1 }, // Chicken in Meal 1
                        new { MealId = 1, FoodId = 2 }, // Rice in Meal 1

                        new { MealId = 2, FoodId = 3 }, // Broccoli in Meal 2
                        new { MealId = 2, FoodId = 4 }, // Oil in Meal 2
                        new { MealId = 2, FoodId = 2 } // Rice in Meal 2
                    )
                );

            modelBuilder.Entity<Day>().HasData(
                new Day { DayId = 1, Date = new DateTime(2025, 11, 1) },
                new Day { DayId = 2, Date = new DateTime(2025, 11, 2) }
            );
            modelBuilder.Entity<Food>().HasData(
                new Food { FoodId = 1, Name = "Chicken Breast", Calories = 165, Protein = 31, Carbohydrates = 0, Fat = 3.6 },
                new Food { FoodId = 2, Name = "White Rice", Calories = 130, Protein = 2.7, Carbohydrates = 28, Fat = 0.3 },
                new Food { FoodId = 3, Name = "Broccoli", Calories = 55, Protein = 3.7, Carbohydrates = 11, Fat = 0.6 },
                new Food { FoodId = 4, Name = "Olive Oil", Calories = 119, Protein = 0, Carbohydrates = 0, Fat = 13.5 }
            );
            modelBuilder.Entity<Dish>().HasData(
                new Dish { DishId = 1, Name = "Chicken & Rice" },
                new Dish { DishId = 2, Name = "Broccoli Stir Fry" }
            );
            modelBuilder.Entity<Favorite>().HasData(
                new Favorite { FavoriteId = 1, DishId = 1 },
                new Favorite { FavoriteId = 2, DishId = 2 }
            );
            modelBuilder.Entity<Meal>().HasData(
                new Meal { MealId = 1, DayId = 1, DishId = 1 },
                new Meal { MealId = 2, DayId = 2, DishId = 2 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
