using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SKS_Yonetim_Backend.Migrations
{
    /// <inheritdoc />
    public partial class akademi_class_kaldirildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevum_Randevu_randevuID",
                table: "Randevum");

            migrationBuilder.DropTable(
                name: "Ogrenci");

            migrationBuilder.DropTable(
                name: "Ogretmen");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.RenameColumn(
                name: "randevuID",
                table: "Randevum",
                newName: "RandevuID");

            migrationBuilder.RenameIndex(
                name: "IX_Randevum_randevuID",
                table: "Randevum",
                newName: "IX_Randevum_RandevuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevum_Randevu_RandevuID",
                table: "Randevum",
                column: "RandevuID",
                principalTable: "Randevu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevum_Randevu_RandevuID",
                table: "Randevum");

            migrationBuilder.RenameColumn(
                name: "RandevuID",
                table: "Randevum",
                newName: "randevuID");

            migrationBuilder.RenameIndex(
                name: "IX_Randevum_RandevuID",
                table: "Randevum",
                newName: "IX_Randevum_randevuID");

            migrationBuilder.CreateTable(
                name: "Ogrenci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolumId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    OgrenciNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Onay = table.Column<int>(type: "int", nullable: false),
                    Sinif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ogretmen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolumId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    OgretmenNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Onay = table.Column<int>(type: "int", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolumId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FakulteId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    Onay = table.Column<int>(type: "int", nullable: false),
                    PersonelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnvanId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Randevum_Randevu_randevuID",
                table: "Randevum",
                column: "randevuID",
                principalTable: "Randevu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
