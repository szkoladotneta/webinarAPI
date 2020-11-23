using Microsoft.EntityFrameworkCore.Migrations;

namespace WebinarAPI.Infrastructure.Migrations
{
    public partial class WishlistsAndPresentTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PresentTypeId",
                table: "Presents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PresentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishLists_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PresentWishList",
                columns: table => new
                {
                    PresentsId = table.Column<int>(type: "int", nullable: false),
                    WishListsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentWishList", x => new { x.PresentsId, x.WishListsId });
                    table.ForeignKey(
                        name: "FK_PresentWishList_Presents_PresentsId",
                        column: x => x.PresentsId,
                        principalTable: "Presents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresentWishList_WishLists_WishListsId",
                        column: x => x.WishListsId,
                        principalTable: "WishLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Presents_PresentTypeId",
                table: "Presents",
                column: "PresentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentWishList_WishListsId",
                table: "PresentWishList",
                column: "WishListsId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_ApplicationUserId1",
                table: "WishLists",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Presents_PresentTypes_PresentTypeId",
                table: "Presents",
                column: "PresentTypeId",
                principalTable: "PresentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presents_PresentTypes_PresentTypeId",
                table: "Presents");

            migrationBuilder.DropTable(
                name: "PresentTypes");

            migrationBuilder.DropTable(
                name: "PresentWishList");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_Presents_PresentTypeId",
                table: "Presents");

            migrationBuilder.DropColumn(
                name: "PresentTypeId",
                table: "Presents");
        }
    }
}
