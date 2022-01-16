using Microsoft.EntityFrameworkCore.Migrations;

namespace PrismCore.Server.Common.Migrations
{
    public partial class updateUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RealName",
                table: "sys_user_info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserIcon",
                table: "sys_user_info",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealName",
                table: "sys_user_info");

            migrationBuilder.DropColumn(
                name: "UserIcon",
                table: "sys_user_info");
        }
    }
}
