using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MJ_Rent_Login.Data.Migrations
{
    public partial class InitialNotifylnfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifylnfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InfoContext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaveNotify = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifylnfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifylnfo");
        }
    }
}
