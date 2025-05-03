using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.Context
{
          public class Kullanici
          {
                    [Key]
                    public int Id { get; set; }
                    public required string KullaniciAdi { get; set; }
                    public required string Sifre { get; set; }
                    public required string Ad { get; set; }
                    public required string Soyad { get; set; }
                    public required string Email { get; set; }
                    public required string Telefon { get; set; }
                    public required string Adres { get; set; }
                    public required int Rol { get; set; }
                    public int Onay { get; set; }
                    public DateTime? KayitTarihi { get; set; }
                    public DateTime? GuncellemeTarihi { get; set; }
                    public string? OnayToken { get; set; }
          }
}