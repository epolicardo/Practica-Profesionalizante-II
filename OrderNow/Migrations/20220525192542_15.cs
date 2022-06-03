using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderNow.API.Migrations
{
    public partial class _15 : Migration
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
        }
    }
}
