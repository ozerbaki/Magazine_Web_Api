using Microsoft.EntityFrameworkCore.Migrations;

namespace Magazine_Web_Api.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dergi",
                columns: table => new
                {
                    DergiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DergiAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İmtiyazSahibi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YayinTuru = table.Column<int>(type: "int", nullable: false),
                    YayinPeriyodu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dergi", x => x.DergiId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dergi");
        }
    }
}
