using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderNow.API.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomersBusinesses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdCustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdBusinessId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersBusinesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersBusinesses_Businesses_IdBusinessId",
                        column: x => x.IdBusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersBusinesses_Customers_IdCustomerId",
                        column: x => x.IdCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteBusinessesByCustomer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdBusinessId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdCustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteBusinessesByCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteBusinessesByCustomer_Businesses_IdBusinessId",
                        column: x => x.IdBusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteBusinessesByCustomer_Customers_IdCustomerId",
                        column: x => x.IdCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteProductsByCustomer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdCustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProductsByCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteProductsByCustomer_Customers_IdCustomerId",
                        column: x => x.IdCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteProductsByCustomer_Products_IdProductId",
                        column: x => x.IdProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersBusinesses_IdBusinessId",
                table: "CustomersBusinesses",
                column: "IdBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersBusinesses_IdCustomerId",
                table: "CustomersBusinesses",
                column: "IdCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBusinessesByCustomer_IdBusinessId",
                table: "FavoriteBusinessesByCustomer",
                column: "IdBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBusinessesByCustomer_IdCustomerId",
                table: "FavoriteBusinessesByCustomer",
                column: "IdCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProductsByCustomer_IdCustomerId",
                table: "FavoriteProductsByCustomer",
                column: "IdCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProductsByCustomer_IdProductId",
                table: "FavoriteProductsByCustomer",
                column: "IdProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersBusinesses");

            migrationBuilder.DropTable(
                name: "FavoriteBusinessesByCustomer");

            migrationBuilder.DropTable(
                name: "FavoriteProductsByCustomer");
        }
    }
}
