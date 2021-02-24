using Microsoft.EntityFrameworkCore.Migrations;

namespace MessHall.Migrations
{
    public partial class MoreRelationalRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "CaloriesPerUnit", "Description", "Name", "RecipeId" },
                values: new object[,]
                {
                    { 3, 350.0, "Some meat", "Meat", 2 },
                    { 4, 10.0, "Some garlic", "Garlic", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "A description of a lasagna", "Lasagna" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "Description", "Name", "Notes" },
                values: new object[] { 3, "A description of spaghetti", "Spaghetti", "Sample notes" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "CaloriesPerUnit", "Description", "Name", "RecipeId" },
                values: new object[] { 5, 200.0, "Some sauce", "Sauce", 3 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "CaloriesPerUnit", "Description", "Name", "RecipeId" },
                values: new object[] { 6, 100.0, "Some pasta", "Pasta", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "A description of a soup", "Chicken Soup" });
        }
    }
}
