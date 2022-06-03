using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderNow.API.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_People_PersonId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_Businesses_BusinessesId",
                table: "PaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Businesses_BusinessesId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_BusinessesId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_BusinessesId",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "BusinessesId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "BusinessesId",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Customers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_PersonId",
                table: "Customers",
                newName: "IX_Customers_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Customers",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                newName: "IX_Customers_PersonId");

            migrationBuilder.AddColumn<string>(
                name: "BusinessesId",
                table: "People",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessesId",
                table: "PaymentMethods",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_People_BusinessesId",
                table: "People",
                column: "BusinessesId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_BusinessesId",
                table: "PaymentMethods",
                column: "BusinessesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_People_PersonId",
                table: "Customers",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_Businesses_BusinessesId",
                table: "PaymentMethods",
                column: "BusinessesId",
                principalTable: "Businesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Businesses_BusinessesId",
                table: "People",
                column: "BusinessesId",
                principalTable: "Businesses",
                principalColumn: "Id");
        }
    }
}
