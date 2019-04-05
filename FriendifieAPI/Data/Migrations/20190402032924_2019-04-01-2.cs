using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendifieAPI.Data.Migrations
{
    public partial class _201904012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Posts",
                newName: "Deleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Posts",
                newName: "IsDeleted");
        }
    }
}