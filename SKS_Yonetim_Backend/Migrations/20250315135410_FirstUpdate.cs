using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SKS_Yonetim_Backend.Migrations
{
    /// <inheritdoc />
    public partial class FirstUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bolum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FakulteId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DilAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DilKodu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fakulte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakulte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HataLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Callsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HataLog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Iletisim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Konu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    Onay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MailTip = table.Column<int>(type: "int", nullable: false),
                    DilId = table.Column<int>(type: "int", nullable: false),
                    MailIcerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolumId = table.Column<int>(type: "int", nullable: false),
                    Sinif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Onay = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
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
                    OgretmenNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolumId = table.Column<int>(type: "int", nullable: false),
                    Onay = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
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
                    PersonelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnvanId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolumId = table.Column<int>(type: "int", nullable: false),
                    FakulteId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Onay = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Randevu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    RandevuAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RandevuAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RandevuYeriId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    BasvuruSayisi = table.Column<int>(type: "int", nullable: false),
                    RandevuTip = table.Column<int>(type: "int", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OnaylayanId = table.Column<int>(type: "int", nullable: false),
                    OnayDurumu = table.Column<int>(type: "int", nullable: false),
                    Kota = table.Column<int>(type: "int", nullable: false),
                    AyniAndaKatilimSayisi = table.Column<int>(type: "int", nullable: false),
                    AyniAndaKatilim = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RandevuAlinanSaat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RandevuId = table.Column<int>(type: "int", nullable: false),
                    BaslangicSaat = table.Column<int>(type: "int", nullable: false),
                    BaslangicDakika = table.Column<int>(type: "int", nullable: false),
                    BitisSaat = table.Column<int>(type: "int", nullable: false),
                    BitisDakika = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuAlinanSaat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RandevuAlinmayacakSaat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RandevuId = table.Column<int>(type: "int", nullable: false),
                    BaslangicSaat = table.Column<int>(type: "int", nullable: false),
                    BaslangicDakika = table.Column<int>(type: "int", nullable: false),
                    BitisSaat = table.Column<int>(type: "int", nullable: false),
                    BitisDakika = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Gun = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuAlinmayacakSaat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RandevuGrup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RandevuId = table.Column<int>(type: "int", nullable: false),
                    RolTip = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuGrup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RandevuTur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RandevuTipAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RandevuTipAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuTur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RandevuYeri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RandevuYeriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RandevuYeriAdres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RandevuYeriTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RandevuYeriMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    AyniAndaRandevu = table.Column<bool>(type: "bit", nullable: false),
                    AyniAndaRandevuSayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuYeri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RandevuYetkilendirme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RandevuId = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    RolTip = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuYetkilendirme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unvan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unvan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Randevum",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    randevuID = table.Column<int>(type: "int", nullable: false),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    AlinmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RandevuTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RandevuNotu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnaylandiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevum", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Randevum_Randevu_randevuID",
                        column: x => x.randevuID,
                        principalTable: "Randevu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Randevum_randevuID",
                table: "Randevum",
                column: "randevuID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bolum");

            migrationBuilder.DropTable(
                name: "Dil");

            migrationBuilder.DropTable(
                name: "Fakulte");

            migrationBuilder.DropTable(
                name: "HataLog");

            migrationBuilder.DropTable(
                name: "Iletisim");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "MailTemplate");

            migrationBuilder.DropTable(
                name: "Ogrenci");

            migrationBuilder.DropTable(
                name: "Ogretmen");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "RandevuAlinanSaat");

            migrationBuilder.DropTable(
                name: "RandevuAlinmayacakSaat");

            migrationBuilder.DropTable(
                name: "RandevuGrup");

            migrationBuilder.DropTable(
                name: "Randevum");

            migrationBuilder.DropTable(
                name: "RandevuTur");

            migrationBuilder.DropTable(
                name: "RandevuYeri");

            migrationBuilder.DropTable(
                name: "RandevuYetkilendirme");

            migrationBuilder.DropTable(
                name: "Unvan");

            migrationBuilder.DropTable(
                name: "Randevu");
        }
    }
}
