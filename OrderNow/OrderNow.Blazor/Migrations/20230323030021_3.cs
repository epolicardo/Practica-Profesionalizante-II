using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderNow.Blazor.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteBusinessesByUser");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "UsersBusinesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastVisit",
                table: "UsersBusinesses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "FavoriteProductsByUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "UsersBusinesses");

            migrationBuilder.DropColumn(
                name: "LastVisit",
                table: "UsersBusinesses");

            migrationBuilder.DropColumn(
                name: "Added",
                table: "FavoriteProductsByUser");

            migrationBuilder.CreateTable(
                name: "FavoriteBusinessesByUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteBusinessesByUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteBusinessesByUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteBusinessesByUser_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBusinessesByUser_BusinessId",
                table: "FavoriteBusinessesByUser",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBusinessesByUser_UsersId",
                table: "FavoriteBusinessesByUser",
                column: "UsersId");
        }
    }
}
