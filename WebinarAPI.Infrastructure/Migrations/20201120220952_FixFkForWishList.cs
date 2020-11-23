using Microsoft.EntityFrameworkCore.Migrations;

namespace WebinarAPI.Infrastructure.Migrations
{
    public partial class FixFkForWishList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_AspNetUsers_ApplicationUserId1",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_WishLists_ApplicationUserId1",
                table: "WishLists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "WishLists");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "WishLists",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_ApplicationUserId",
                table: "WishLists",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_AspNetUsers_ApplicationUserId",
                table: "WishLists",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_AspNetUsers_ApplicationUserId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_WishLists_ApplicationUserId",
                table: "WishLists");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "WishLists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "WishLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_ApplicationUserId1",
                table: "WishLists",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_AspNetUsers_ApplicationUserId1",
                table: "WishLists",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
