using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CloudBruh.Trustartup.FeedContent.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommentableId = table.Column<long>(type: "bigint", nullable: false),
                    CommentableType = table.Column<int>(type: "integer", nullable: false),
                    RepliedId = table.Column<long>(type: "bigint", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_RepliedId",
                        column: x => x.RepliedId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LikeableId = table.Column<long>(type: "bigint", nullable: false),
                    LikeableType = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaRelationships",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MediaId = table.Column<long>(type: "bigint", nullable: false),
                    MediableId = table.Column<long>(type: "bigint", nullable: false),
                    MediableType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaRelationships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Startups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    EndingAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FundsGoal = table.Column<decimal>(type: "numeric", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Startups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    StartupId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follows_Startups_StartupId",
                        column: x => x.StartupId,
                        principalTable: "Startups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartupId = table.Column<long>(type: "bigint", nullable: false),
                    Header = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Startups_StartupId",
                        column: x => x.StartupId,
                        principalTable: "Startups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartupId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DonationMinimum = table.Column<decimal>(type: "numeric", nullable: false),
                    MediaId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rewards_Startups_StartupId",
                        column: x => x.StartupId,
                        principalTable: "Startups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RepliedId",
                table: "Comments",
                column: "RepliedId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_StartupId",
                table: "Follows",
                column: "StartupId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_StartupId",
                table: "Posts",
                column: "StartupId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_StartupId",
                table: "Rewards",
                column: "StartupId");
            
            migrationBuilder.Sql(
                @"
                    CREATE FUNCTION update_modified_column()
                    RETURNS TRIGGER AS $$
                    BEGIN
                        NEW.""UpdatedAt"" = now();
                        NEW.""CreatedAt"" = OLD.""CreatedAt"";
                        RETURN NEW;
                    END;
                    $$ language 'plpgsql';");
            
            migrationBuilder.Sql(
                @"
                    CREATE FUNCTION persist_created_column()
                    RETURNS TRIGGER AS $$
                    BEGIN
                        NEW.""UpdatedAt"" = now();
                        NEW.""CreatedAt"" = OLD.""CreatedAt"";
                        RETURN NEW;
                    END;
                    $$ language 'plpgsql';");

            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER ""Startups_update_modified""
                        BEFORE UPDATE ON ""Startups""
                        FOR EACH ROW
                        EXECUTE PROCEDURE update_modified_column();
                ");
            
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER ""Posts_update_modified""
                        BEFORE UPDATE ON ""Posts""
                        FOR EACH ROW
                        EXECUTE PROCEDURE update_modified_column();
                ");
            
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER ""Comments_update_modified""
                        BEFORE UPDATE ON ""Comments""
                        FOR EACH ROW
                        EXECUTE PROCEDURE update_modified_column();
                ");
            
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER ""Likes_persist_created""
                        BEFORE UPDATE ON ""Likes""
                        FOR EACH ROW
                        EXECUTE PROCEDURE persist_created_column();
                ");
            
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER ""Follows_persist_created""
                        BEFORE UPDATE ON ""Follows""
                        FOR EACH ROW
                        EXECUTE PROCEDURE persist_created_column();
                ");
            
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER ""Rewards_update_modified""
                        BEFORE UPDATE ON ""Rewards""
                        FOR EACH ROW
                        EXECUTE PROCEDURE update_modified_column();
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "MediaRelationships");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "Startups");
        }
    }
}
