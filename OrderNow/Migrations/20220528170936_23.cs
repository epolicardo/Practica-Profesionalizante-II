using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderNow.API.Migrations
{
    public partial class _23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDetail_Products_ProductId",
                table: "OrdersDetail");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "OrdersDetail",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "GroupsId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UGI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GroupsId",
                table: "AspNetUsers",
                column: "GroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Grupos_GroupsId",
                table: "AspNetUsers",
                column: "GroupsId",
                principalTable: "Grupos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDetail_Products_ProductId",
                table: "OrdersDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Grupos_GroupsId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDetail_Products_ProductId",
                table: "OrdersDetail");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GroupsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GroupsId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "OrdersDetail",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDetail_Products_ProductId",
                table: "OrdersDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
