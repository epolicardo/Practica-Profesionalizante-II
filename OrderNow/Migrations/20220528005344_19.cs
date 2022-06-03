using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderNow.API.Migrations
{
    public partial class _19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Addresses_AddressId",
                table: "Businesses");

            migrationBuilder.DropTable(
                name: "BusinessesUser");

            migrationBuilder.AlterColumn<string>(
                name: "AddressId",
                table: "Businesses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Businesses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_UserId",
                table: "Businesses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Addresses_AddressId",
                table: "Businesses",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_AspNetUsers_UserId",
                table: "Businesses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Addresses_AddressId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_AspNetUsers_UserId",
                table: "Businesses");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_UserId",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Businesses");

            migrationBuilder.AlterColumn<string>(
                name: "AddressId",
                table: "Businesses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
                name: "FK_Businesses_Addresses_AddressId",
                table: "Businesses",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
