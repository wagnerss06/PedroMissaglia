using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alexandria.Repository.Migrations
{
    public partial class CreateDBAvatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id_avatar",
                table: "User",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "AvatarId",
                table: "User",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_User_AvatarId",
                table: "User",
                column: "AvatarId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Avatar_AvatarId",
                table: "User",
                column: "AvatarId",
                principalTable: "Avatar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Avatar_AvatarId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Avatar");

            migrationBuilder.DropIndex(
                name: "IX_User_AvatarId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AvatarId",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Id_avatar",
                table: "User",
                nullable: false,
                oldClrType: typeof(Guid));
        }
    }
}
