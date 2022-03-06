using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudBruh.Trustartup.FeedContent.Migrations
{
    public partial class Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId_LikeableId_LikeableType",
                table: "Likes",
                columns: new[] { "UserId", "LikeableId", "LikeableType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Follows_UserId_StartupId",
                table: "Follows",
                columns: new[] { "UserId", "StartupId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Likes_UserId_LikeableId_LikeableType",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Follows_UserId_StartupId",
                table: "Follows");
        }
    }
}
