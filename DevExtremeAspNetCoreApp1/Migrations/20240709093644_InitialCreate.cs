using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevExtremeAspNetCoreApp1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "kisiler",
                columns: table => new
                {
                    KisiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kisiler", x => x.KisiId);
                });

            migrationBuilder.CreateTable(
                name: "tanimlar",
                columns: table => new
                {
                    TanimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tanimlar", x => x.TanimId);
                });

            migrationBuilder.CreateTable(
                name: "personelGorevler",
                columns: table => new
                {
                    PGID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KisiId = table.Column<int>(type: "int", nullable: false),
                    TanimId = table.Column<int>(type: "int", nullable: false),
                    BaslamaTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personelGorevler", x => x.PGID);
                    table.ForeignKey(
                        name: "FK_personelGorevler_kisiler_KisiId",
                        column: x => x.KisiId,
                        principalTable: "kisiler",
                        principalColumn: "KisiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_personelGorevler_tanimlar_TanimId",
                        column: x => x.TanimId,
                        principalTable: "tanimlar",
                        principalColumn: "TanimId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personelGorevler_KisiId",
                table: "personelGorevler",
                column: "KisiId");

            migrationBuilder.CreateIndex(
                name: "IX_personelGorevler_TanimId",
                table: "personelGorevler",
                column: "TanimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "birim");

            migrationBuilder.DropTable(
                name: "personelGorevler");

            migrationBuilder.DropTable(
                name: "kisiler");

            migrationBuilder.DropTable(
                name: "tanimlar");
        }
    }
}
