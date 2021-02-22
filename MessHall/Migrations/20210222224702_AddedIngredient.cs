using Microsoft.EntityFrameworkCore.Migrations;

namespace MessHall.Migrations
{
    public partial class AddedIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CaloriesPerUnit = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "CaloriesPerUnit", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 50.0, "An apple", "Apple" },
                    { 2, 10.0, "Some flour", "Flour" },
                    { 3, 100.0, "Some sauce", "Sauce" },
                    { 4, 150.0, "Turkey pepperoni", "Pepperoni" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
