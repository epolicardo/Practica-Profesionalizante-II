using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderNow.API.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_AspNetUsers_UsersId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersBusinesses_Customers_IdCustomerId",
                table: "CustomersBusinesses");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteBusinessesByCustomer_Customers_IdCustomerId",
                table: "FavoriteBusinessesByCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProductsByCustomer_Customers_IdCustomerId",
                table: "FavoriteProductsByCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_UsersId",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Businesses");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameColumn(
                name: "IdCustomerId",
                table: "FavoriteProductsByCustomer",
                newName: "IdUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteProductsByCustomer_IdCustomerId",
                table: "FavoriteProductsByCustomer",
                newName: "IX_FavoriteProductsByCustomer_IdUsersId");

            migrationBuilder.RenameColumn(
                name: "IdCustomerId",
                table: "FavoriteBusinessesByCustomer",
                newName: "IdUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteBusinessesByCustomer_IdCustomerId",
                table: "FavoriteBusinessesByCustomer",
                newName: "IX_FavoriteBusinessesByCustomer_IdUsersId");

            migrationBuilder.RenameColumn(
                name: "IdCustomerId",
                table: "CustomersBusinesses",
                newName: "IdUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomersBusinesses_IdCustomerId",
                table: "CustomersBusinesses",
                newName: "IX_CustomersBusinesses_IdUsersId");

            migrationBuilder.CreateTable(
                name: "BusinessesUsers",
                columns: table => new
                {
                    CustomersListId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FavoriteBusinessId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessesUsers", x => new { x.CustomersListId, x.FavoriteBusinessId });
                    table.ForeignKey(
                        name: "FK_BusinessesUsers_AspNetUsers_CustomersListId",
                        column: x => x.CustomersListId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessesUsers_Businesses_FavoriteBusinessId",
                        column: x => x.FavoriteBusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessesUsers_FavoriteBusinessId",
                table: "BusinessesUsers",
                column: "FavoriteBusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersBusinesses_AspNetUsers_IdUsersId",
                table: "CustomersBusinesses",
                column: "IdUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteBusinessesByCustomer_AspNetUsers_IdUsersId",
                table: "FavoriteBusinessesByCustomer",
                column: "IdUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProductsByCustomer_AspNetUsers_IdUsersId",
                table: "FavoriteProductsByCustomer",
                column: "IdUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersBusinesses_AspNetUsers_IdUsersId",
                table: "CustomersBusinesses");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteBusinessesByCustomer_AspNetUsers_IdUsersId",
                table: "FavoriteBusinessesByCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProductsByCustomer_AspNetUsers_IdUsersId",
                table: "FavoriteProductsByCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "BusinessesUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameColumn(
                name: "IdUsersId",
                table: "FavoriteProductsByCustomer",
                newName: "IdCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteProductsByCustomer_IdUsersId",
                table: "FavoriteProductsByCustomer",
                newName: "IX_FavoriteProductsByCustomer_IdCustomerId");

            migrationBuilder.RenameColumn(
                name: "IdUsersId",
                table: "FavoriteBusinessesByCustomer",
                newName: "IdCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteBusinessesByCustomer_IdUsersId",
                table: "FavoriteBusinessesByCustomer",
                newName: "IX_FavoriteBusinessesByCustomer_IdCustomerId");

            migrationBuilder.RenameColumn(
                name: "IdUsersId",
                table: "CustomersBusinesses",
                newName: "IdCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomersBusinesses_IdUsersId",
                table: "CustomersBusinesses",
                newName: "IX_CustomersBusinesses_IdCustomerId");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Businesses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_UsersId",
                table: "Businesses",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_AspNetUsers_UsersId",
                table: "Businesses",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersBusinesses_Customers_IdCustomerId",
                table: "CustomersBusinesses",
                column: "IdCustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteBusinessesByCustomer_Customers_IdCustomerId",
                table: "FavoriteBusinessesByCustomer",
                column: "IdCustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProductsByCustomer_Customers_IdCustomerId",
                table: "FavoriteProductsByCustomer",
                column: "IdCustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
