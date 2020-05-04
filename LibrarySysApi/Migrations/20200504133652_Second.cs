using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySysApi.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReaderID",
                table: "BookC",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reader",
                columns: table => new
                {
                    ReaderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader", x => x.ReaderID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookC_ReaderID",
                table: "BookC",
                column: "ReaderID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookC_Reader_ReaderID",
                table: "BookC",
                column: "ReaderID",
                principalTable: "Reader",
                principalColumn: "ReaderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookC_Reader_ReaderID",
                table: "BookC");

            migrationBuilder.DropTable(
                name: "Reader");

            migrationBuilder.DropIndex(
                name: "IX_BookC_ReaderID",
                table: "BookC");

            migrationBuilder.DropColumn(
                name: "ReaderID",
                table: "BookC");
        }
    }
}
