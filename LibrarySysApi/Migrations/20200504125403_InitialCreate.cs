using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySysApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookC",
                columns: table => new
                {
                    BookCID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleC = table.Column<string>(nullable: true),
                    AuthorC = table.Column<string>(nullable: true),
                    Rented = table.Column<bool>(nullable: false),
                    RentedbyReader = table.Column<int>(nullable: false),
                    RentData = table.Column<DateTime>(nullable: false),
                    DropOfData = table.Column<DateTime>(nullable: false),
                    AliasofReader = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookC", x => x.BookCID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookC");
        }
    }
}
