using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCookBook.Migrations
{
    public partial class defaultImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "main_default.jpg");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "main_default.jpg");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "main_default.jpg");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "main_default.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
