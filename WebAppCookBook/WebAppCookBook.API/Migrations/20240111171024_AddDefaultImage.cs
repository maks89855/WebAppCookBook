using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCookBook.Migrations
{
    public partial class AddDefaultImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Recipes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "D:\\Visual Studio Repos\\ASP.NET_CORE_6_WEB_API_Course_Best_Practices\\WebAppCookBook\\wwwroot\\images\\default.jpg");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "D:\\Visual Studio Repos\\ASP.NET_CORE_6_WEB_API_Course_Best_Practices\\WebAppCookBook\\wwwroot\\images\\default.jpg");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "D:\\Visual Studio Repos\\ASP.NET_CORE_6_WEB_API_Course_Best_Practices\\WebAppCookBook\\wwwroot\\images\\default.jpg");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "D:\\Visual Studio Repos\\ASP.NET_CORE_6_WEB_API_Course_Best_Practices\\WebAppCookBook\\wwwroot\\images\\default.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Recipes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: null);
        }
    }
}
