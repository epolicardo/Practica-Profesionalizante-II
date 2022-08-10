using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderNow.API.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Grupos_GroupsId",
                table: "AspNetUsers");

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

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDetail_Products_ProductId",
                table: "OrdersDetail");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropColumn(
                name: "IsMarkedAsVIP",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "GroupsId",
                table: "AspNetUsers",
                newName: "personId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_GroupsId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_personId");

            migrationBuilder.AddColumn<string>(
                name: "BusinessId",
                table: "PublicityContracts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "OrdersDetail",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdCustomerId",
                table: "FavoriteProductsByCustomer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdCustomerId",
                table: "FavoriteBusinessesByCustomer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdCustomerId",
                table: "CustomersBusinesses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PublicityContracts_BusinessId",
                table: "PublicityContracts",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BusinessId",
                table: "Products",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UsersId",
                table: "Products",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_People_personId",
                table: "AspNetUsers",
                column: "personId",
                principalTable: "People",
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

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDetail_Products_ProductId",
                table: "OrdersDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UsersId",
                table: "Products",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Businesses_BusinessId",
                table: "Products",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicityContracts_Businesses_BusinessId",
                table: "PublicityContracts",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_People_personId",
                table: "AspNetUsers");

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

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDetail_Products_ProductId",
                table: "OrdersDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UsersId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Businesses_BusinessId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicityContracts_Businesses_BusinessId",
                table: "PublicityContracts");

            migrationBuilder.DropIndex(
                name: "IX_PublicityContracts_BusinessId",
                table: "PublicityContracts");

            migrationBuilder.DropIndex(
                name: "IX_Products_BusinessId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UsersId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "PublicityContracts");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "personId",
                table: "AspNetUsers",
                newName: "GroupsId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_personId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_GroupsId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "OrdersDetail",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IdCustomerId",
                table: "FavoriteProductsByCustomer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IdCustomerId",
                table: "FavoriteBusinessesByCustomer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IdCustomerId",
                table: "CustomersBusinesses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "IsMarkedAsVIP",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UGI = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Grupos_GroupsId",
                table: "AspNetUsers",
                column: "GroupsId",
                principalTable: "Grupos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersBusinesses_Customers_IdCustomerId",
                table: "CustomersBusinesses",
                column: "IdCustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteBusinessesByCustomer_Customers_IdCustomerId",
                table: "FavoriteBusinessesByCustomer",
                column: "IdCustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProductsByCustomer_Customers_IdCustomerId",
                table: "FavoriteProductsByCustomer",
                column: "IdCustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDetail_Products_ProductId",
                table: "OrdersDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
