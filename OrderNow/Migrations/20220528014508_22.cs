using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderNow.API.Migrations
{
    public partial class _22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteBusinessesByCustomer_AspNetUsers_IdUsersId",
                table: "FavoriteBusinessesByCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteBusinessesByCustomer_Businesses_IdBusinessId",
                table: "FavoriteBusinessesByCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProductsByCustomer_AspNetUsers_IdUsersId",
                table: "FavoriteProductsByCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProductsByCustomer_Products_IdProductId",
                table: "FavoriteProductsByCustomer");

            migrationBuilder.DropTable(
                name: "CustomersBusinesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteProductsByCustomer",
                table: "FavoriteProductsByCustomer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteBusinessesByCustomer",
                table: "FavoriteBusinessesByCustomer");

            migrationBuilder.RenameTable(
                name: "FavoriteProductsByCustomer",
                newName: "FavoriteProductsByUser");

            migrationBuilder.RenameTable(
                name: "FavoriteBusinessesByCustomer",
                newName: "FavoriteBusinessesByUser");

            migrationBuilder.RenameColumn(
                name: "IdUsersId",
                table: "FavoriteProductsByUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "IdProductId",
                table: "FavoriteProductsByUser",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteProductsByCustomer_IdUsersId",
                table: "FavoriteProductsByUser",
                newName: "IX_FavoriteProductsByUser_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteProductsByCustomer_IdProductId",
                table: "FavoriteProductsByUser",
                newName: "IX_FavoriteProductsByUser_ProductId");

            migrationBuilder.RenameColumn(
                name: "IdUsersId",
                table: "FavoriteBusinessesByUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "IdBusinessId",
                table: "FavoriteBusinessesByUser",
                newName: "BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteBusinessesByCustomer_IdUsersId",
                table: "FavoriteBusinessesByUser",
                newName: "IX_FavoriteBusinessesByUser_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteBusinessesByCustomer_IdBusinessId",
                table: "FavoriteBusinessesByUser",
                newName: "IX_FavoriteBusinessesByUser_BusinessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteProductsByUser",
                table: "FavoriteProductsByUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteBusinessesByUser",
                table: "FavoriteBusinessesByUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UsersBusinesses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersBusinesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersBusinesses_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersBusinesses_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersBusinesses_BusinessId",
                table: "UsersBusinesses",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersBusinesses_UsersId",
                table: "UsersBusinesses",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteBusinessesByUser_AspNetUsers_UsersId",
                table: "FavoriteBusinessesByUser",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteBusinessesByUser_Businesses_BusinessId",
                table: "FavoriteBusinessesByUser",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProductsByUser_AspNetUsers_UsersId",
                table: "FavoriteProductsByUser",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProductsByUser_Products_ProductId",
                table: "FavoriteProductsByUser",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteBusinessesByUser_AspNetUsers_UsersId",
                table: "FavoriteBusinessesByUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteBusinessesByUser_Businesses_BusinessId",
                table: "FavoriteBusinessesByUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProductsByUser_AspNetUsers_UsersId",
                table: "FavoriteProductsByUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProductsByUser_Products_ProductId",
                table: "FavoriteProductsByUser");

            migrationBuilder.DropTable(
                name: "UsersBusinesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteProductsByUser",
                table: "FavoriteProductsByUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteBusinessesByUser",
                table: "FavoriteBusinessesByUser");

            migrationBuilder.RenameTable(
                name: "FavoriteProductsByUser",
                newName: "FavoriteProductsByCustomer");

            migrationBuilder.RenameTable(
                name: "FavoriteBusinessesByUser",
                newName: "FavoriteBusinessesByCustomer");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "FavoriteProductsByCustomer",
                newName: "IdUsersId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "FavoriteProductsByCustomer",
                newName: "IdProductId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteProductsByUser_UsersId",
                table: "FavoriteProductsByCustomer",
                newName: "IX_FavoriteProductsByCustomer_IdUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteProductsByUser_ProductId",
                table: "FavoriteProductsByCustomer",
                newName: "IX_FavoriteProductsByCustomer_IdProductId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "FavoriteBusinessesByCustomer",
                newName: "IdUsersId");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "FavoriteBusinessesByCustomer",
                newName: "IdBusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteBusinessesByUser_UsersId",
                table: "FavoriteBusinessesByCustomer",
                newName: "IX_FavoriteBusinessesByCustomer_IdUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteBusinessesByUser_BusinessId",
                table: "FavoriteBusinessesByCustomer",
                newName: "IX_FavoriteBusinessesByCustomer_IdBusinessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteProductsByCustomer",
                table: "FavoriteProductsByCustomer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteBusinessesByCustomer",
                table: "FavoriteBusinessesByCustomer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CustomersBusinesses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdBusinessId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdUsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersBusinesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersBusinesses_AspNetUsers_IdUsersId",
                        column: x => x.IdUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomersBusinesses_Businesses_IdBusinessId",
                        column: x => x.IdBusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersBusinesses_IdBusinessId",
                table: "CustomersBusinesses",
                column: "IdBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersBusinesses_IdUsersId",
                table: "CustomersBusinesses",
                column: "IdUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteBusinessesByCustomer_AspNetUsers_IdUsersId",
                table: "FavoriteBusinessesByCustomer",
                column: "IdUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteBusinessesByCustomer_Businesses_IdBusinessId",
                table: "FavoriteBusinessesByCustomer",
                column: "IdBusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProductsByCustomer_AspNetUsers_IdUsersId",
                table: "FavoriteProductsByCustomer",
                column: "IdUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProductsByCustomer_Products_IdProductId",
                table: "FavoriteProductsByCustomer",
                column: "IdProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
