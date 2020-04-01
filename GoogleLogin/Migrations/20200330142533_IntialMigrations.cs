using Microsoft.EntityFrameworkCore.Migrations;

namespace GoogleLogin.Migrations
{
    public partial class IntialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    InternalUserId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    ReturnUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.InternalUserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
