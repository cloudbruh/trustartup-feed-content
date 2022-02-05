using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudBruh.Trustartup.FeedContent.Migrations
{
    public partial class CommentFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Comments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");
        }
    }
}
