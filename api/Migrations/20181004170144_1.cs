using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimesheetId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TimesheetId",
                table: "Activities",
                column: "TimesheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Timesheets_TimesheetId",
                table: "Activities",
                column: "TimesheetId",
                principalTable: "Timesheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Timesheets_TimesheetId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_TimesheetId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TimesheetId",
                table: "Activities");
        }
    }
}
