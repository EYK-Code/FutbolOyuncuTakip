using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutbolOyuncuTakip.UI.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Takim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LigId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Takim_Lig_LigId",
                        column: x => x.LigId,
                        principalTable: "Lig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Futbolcu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mevki = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TakimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Futbolcu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Futbolcu_Takim_TakimId",
                        column: x => x.TakimId,
                        principalTable: "Takim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Futbolcu_TakimId",
                table: "Futbolcu",
                column: "TakimId");

            migrationBuilder.CreateIndex(
                name: "IX_Takim_LigId",
                table: "Takim",
                column: "LigId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Futbolcu");

            migrationBuilder.DropTable(
                name: "Takim");

            migrationBuilder.DropTable(
                name: "Lig");
        }
    }
}
