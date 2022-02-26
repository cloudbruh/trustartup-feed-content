using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudBruh.Trustartup.FeedContent.Migrations
{
    public partial class StartupStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Startups",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Startups");
        }
    }
}
