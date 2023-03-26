using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderNow.Blazor.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_People_personId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "personId",
                table: "AspNetUsers",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_personId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_PersonId");

            migrationBuilder.AddColumn<string>(
                name: "Neiborhood",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_People_PersonId",
                table: "AspNetUsers",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_People_PersonId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Neiborhood",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "AspNetUsers",
                newName: "personId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_PersonId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_personId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_People_personId",
                table: "AspNetUsers",
                column: "personId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}
