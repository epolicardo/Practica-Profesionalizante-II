using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderNow.API.Migrations
{
    public partial class _18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersBusinesses_AspNetUsers_IdUsersId",
                table: "CustomersBusinesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AspNetUsers_GeneratedById",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteBusinessesByCustomer_AspNetUsers_IdUsersId",
                table: "FavoriteBusinessesByCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProductsByCustomer_AspNetUsers_IdUsersId",
                table: "FavoriteProductsByCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UsersId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "BusinessesUsers");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UsersId",
                table: "Products",
                newName: "IX_Products_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsersId",
                table: "FavoriteProductsByCustomer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsersId",
                table: "FavoriteBusinessesByCustomer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "GeneratedById",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsersId",
                table: "CustomersBusinesses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "BusinessesUser",
                columns: table => new
                {
                    CustomersListId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FavoriteBusinessId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessesUser", x => new { x.CustomersListId, x.FavoriteBusinessId });
                    table.ForeignKey(
                        name: "FK_BusinessesUser_AspNetUsers_CustomersListId",
                        column: x => x.CustomersListId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessesUser_Businesses_FavoriteBusinessId",
                        column: x => x.FavoriteBusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessesUser_FavoriteBusinessId",
                table: "BusinessesUser",
                column: "FavoriteBusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersBusinesses_AspNetUsers_IdUsersId",
                table: "CustomersBusinesses",
                column: "IdUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AspNetUsers_GeneratedById",
                table: "Documents",
                column: "GeneratedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteBusinessesByCustomer_AspNetUsers_IdUsersId",
                table: "FavoriteBusinessesByCustomer",
                column: "IdUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProductsByCustomer_AspNetUsers_IdUsersId",
                table: "FavoriteProductsByCustomer",
                column: "IdUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersBusinesses_AspNetUsers_IdUsersId",
                table: "CustomersBusinesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AspNetUsers_GeneratedById",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteBusinessesByCustomer_AspNetUsers_IdUsersId",
                table: "FavoriteBusinessesByCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProductsByCustomer_AspNetUsers_IdUsersId",
                table: "FavoriteProductsByCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "BusinessesUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Products",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "Products",
                newName: "IX_Products_UsersId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdUsersId",
                table: "FavoriteProductsByCustomer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdUsersId",
                table: "FavoriteBusinessesByCustomer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GeneratedById",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdUsersId",
                table: "CustomersBusinesses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
                name: "FK_Documents_AspNetUsers_GeneratedById",
                table: "Documents",
                column: "GeneratedById",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UsersId",
                table: "Products",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
