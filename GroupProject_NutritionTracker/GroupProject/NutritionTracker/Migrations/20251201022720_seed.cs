using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NutritionTracker.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "DayId", "Date" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "Name" },
                values: new object[,]
                {
                    { 1, "Chicken & Rice" },
                    { 2, "Broccoli Stir Fry" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Calories", "Carbohydrates", "Fat", "Name", "Protein" },
                values: new object[,]
                {
                    { 1, 165.0, 0.0, 3.6000000000000001, "Chicken Breast", 31.0 },
                    { 2, 130.0, 28.0, 0.29999999999999999, "White Rice", 2.7000000000000002 },
                    { 3, 55.0, 11.0, 0.59999999999999998, "Broccoli", 3.7000000000000002 },
                    { 4, 119.0, 0.0, 13.5, "Olive Oil", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "DishFoods",
                columns: new[] { "DishId", "FoodId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "FavoriteId", "DishId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "MealId", "DayId", "DishId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "MealFoods",
                columns: new[] { "FoodId", "MealId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DishFoods",
                keyColumns: new[] { "DishId", "FoodId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DishFoods",
                keyColumns: new[] { "DishId", "FoodId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Favorites",
                keyColumn: "FavoriteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Favorites",
                keyColumn: "FavoriteId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumns: new[] { "FoodId", "MealId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumns: new[] { "FoodId", "MealId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumns: new[] { "FoodId", "MealId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumns: new[] { "FoodId", "MealId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumns: new[] { "FoodId", "MealId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "MealId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "MealId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 2);
        }
    }
}
