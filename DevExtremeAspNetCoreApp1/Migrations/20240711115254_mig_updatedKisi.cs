using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevExtremeAspNetCoreApp1.Migrations
{
    public partial class mig_updatedKisi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "kisiler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KullaniciAdi",
                table: "kisiler",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "kisiler");

            migrationBuilder.DropColumn(
                name: "KullaniciAdi",
                table: "kisiler");

            
        }
    }
}
