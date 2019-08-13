using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alexandria.Repository.Migrations
{
    public partial class @as : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avatar",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Literary_genre = table.Column<string>(nullable: false),
                    Line = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatar", x => x.Id);
                });

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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CPF = table.Column<string>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Coin = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    AvatarId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Avatar_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "Avatar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_User_AvatarId",
                table: "User",
                column: "AvatarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookcase");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Avatar");
        }
    }
}
