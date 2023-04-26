using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MJ_Rent_Login.Data.Migrations
{
    public partial class InitialBorrowRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BorrowRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorrowDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrevBorrowTime = table.Column<int>(type: "int", nullable: false),
                    ActualBorrowTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowRecord", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowRecord");
        }
    }
}
