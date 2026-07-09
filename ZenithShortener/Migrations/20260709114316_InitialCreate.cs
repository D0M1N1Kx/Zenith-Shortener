using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenithShortener.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortenedLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShortCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    OriginalUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortenedLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClickAnalytics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShortenedLinkId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClickedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserAgent = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Referrer = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClickAnalytics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClickAnalytics_ShortenedLinks_ShortenedLinkId",
                        column: x => x.ShortenedLinkId,
                        principalTable: "ShortenedLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClickAnalytics_ShortenedLinkId",
                table: "ClickAnalytics",
                column: "ShortenedLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortenedLinks_ShortCode",
                table: "ShortenedLinks",
                column: "ShortCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClickAnalytics");

            migrationBuilder.DropTable(
                name: "ShortenedLinks");
        }
    }
}
