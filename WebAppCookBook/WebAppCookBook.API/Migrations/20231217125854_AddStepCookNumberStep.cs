using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCookBook.Migrations
{
    public partial class AddStepCookNumberStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberStep",
                table: "StepCooks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberStep",
                table: "StepCooks");
        }
    }
}
