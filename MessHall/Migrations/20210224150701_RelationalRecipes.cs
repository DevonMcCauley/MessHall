using Microsoft.EntityFrameworkCore.Migrations;

namespace MessHall.Migrations
{
    public partial class RelationalRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CaloriesPerUnit = table.Column<double>(type: "float", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "Description", "Name", "Notes" },
                values: new object[] { 1, "A description of a pie", "Apple Pie", "Sample notes" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "Description", "Name", "Notes" },
                values: new object[] { 2, "A description of a soup", "Chicken Soup", "Sample notes" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "CaloriesPerUnit", "Description", "Name", "RecipeId" },
                values: new object[] { 1, 50.0, "An apple", "Apple", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "CaloriesPerUnit", "Description", "Name", "RecipeId" },
                values: new object[] { 2, 150.0, "Some sugar", "Sugar", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
