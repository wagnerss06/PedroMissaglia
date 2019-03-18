using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alexandria.Repository.Migrations
{
    public partial class CreateDBBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Avatar_AvatarId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Id_avatar",
                table: "User");

            migrationBuilder.AlterColumn<Guid>(
                name: "AvatarId",
                table: "User",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Title_long = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: false),
                    Authors = table.Column<string>(nullable: false),
                    Editora = table.Column<string>(nullable: false),
                    Edition = table.Column<string>(nullable: false),
                    Date_published = table.Column<DateTime>(nullable: false),
                    Language = table.Column<string>(nullable: false),
                    Pages = table.Column<int>(nullable: false),
                    Literary_genre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookcase",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookcase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookcase_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookcase_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookcase_BookId",
                table: "Bookcase",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookcase_UserId",
                table: "Bookcase",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Avatar_AvatarId",
                table: "User",
                column: "AvatarId",
                principalTable: "Avatar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Avatar_AvatarId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Bookcase");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.AlterColumn<Guid>(
                name: "AvatarId",
                table: "User",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "Id_avatar",
                table: "User",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_User_Avatar_AvatarId",
                table: "User",
                column: "AvatarId",
                principalTable: "Avatar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
