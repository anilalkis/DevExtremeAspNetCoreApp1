using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevExtremeAspNetCoreApp1.Migrations
{
    public partial class mig_filePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DosyaYolu",
                table: "kararlar");


            migrationBuilder.CreateTable(
                name: "filePaths",
                columns: table => new
                {
                    FilePathId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KararId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filePaths", x => x.FilePathId);
                    table.ForeignKey(
                        name: "FK_filePaths_kararlar_KararId",
                        column: x => x.KararId,
                        principalTable: "kararlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_filePaths_KararId",
                table: "filePaths",
                column: "KararId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "filePaths");


            migrationBuilder.AddColumn<string>(
                name: "DosyaYolu",
                table: "kararlar",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
