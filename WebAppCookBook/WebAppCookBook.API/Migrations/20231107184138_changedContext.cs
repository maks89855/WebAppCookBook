using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCookBook.Migrations
{
    public partial class changedContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipes_RecipeId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_StepCook_Recipes_RecipeId",
                table: "StepCook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StepCook",
                table: "StepCook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.RenameTable(
                name: "StepCook",
                newName: "StepCooks");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                newName: "Ingredients");

            migrationBuilder.RenameIndex(
                name: "IX_StepCook_RecipeId",
                table: "StepCooks",
                newName: "IX_StepCooks_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_RecipeId",
                table: "Ingredients",
                newName: "IX_Ingredients_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StepCooks",
                table: "StepCooks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Count", "NameIngredient", "RecipeId", "Units" },
                values: new object[] { 1, 1, "First", 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StepCooks_Recipes_RecipeId",
                table: "StepCooks",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_StepCooks_Recipes_RecipeId",
                table: "StepCooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StepCooks",
                table: "StepCooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "StepCooks",
                newName: "StepCook");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "Ingredient");

            migrationBuilder.RenameIndex(
                name: "IX_StepCooks_RecipeId",
                table: "StepCook",
                newName: "IX_StepCook_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredient",
                newName: "IX_Ingredient_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StepCook",
                table: "StepCook",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipes_RecipeId",
                table: "Ingredient",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StepCook_Recipes_RecipeId",
                table: "StepCook",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
