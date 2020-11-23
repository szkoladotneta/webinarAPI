using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebinarAPI.Infrastructure.Migrations
{
    public partial class AuditEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PresentWishList_WishLists_WishListsId",
                table: "PresentWishList");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_AspNetUsers_ApplicationUserId",
                table: "WishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishLists",
                table: "WishLists");

            migrationBuilder.RenameTable(
                name: "WishLists",
                newName: "Wishlists");

            migrationBuilder.RenameIndex(
                name: "IX_WishLists_ApplicationUserId",
                table: "Wishlists",
                newName: "IX_Wishlists_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Wishlists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Wishlists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Wishlists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Wishlists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Presents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Presents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Presents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Presents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PresentWishList_Wishlists_WishListsId",
                table: "PresentWishList",
                column: "WishListsId",
                principalTable: "Wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_AspNetUsers_ApplicationUserId",
                table: "Wishlists",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PresentWishList_Wishlists_WishListsId",
                table: "PresentWishList");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_AspNetUsers_ApplicationUserId",
                table: "Wishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Presents");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Presents");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Presents");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Presents");

            migrationBuilder.RenameTable(
                name: "Wishlists",
                newName: "WishLists");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlists_ApplicationUserId",
                table: "WishLists",
                newName: "IX_WishLists_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishLists",
                table: "WishLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PresentWishList_WishLists_WishListsId",
                table: "PresentWishList",
                column: "WishListsId",
                principalTable: "WishLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_AspNetUsers_ApplicationUserId",
                table: "WishLists",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
