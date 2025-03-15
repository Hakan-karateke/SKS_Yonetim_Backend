using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.Context
{
          public class Ogretmen
          {
                    [Key]
                    public int Id { get; set; }
                    public required string OgretmenNo { get; set; }
                    public required string Ad { get; set; }
                    public required string Soyad { get; set; }
                    public required string Email { get; set; }
                    public required string Telefon { get; set; }
                    public required string Adres { get; set; }
                    public required int BolumId { get; set; }
                    public int Onay { get; set; }
                    public int KullaniciId { get; set; }
                    
          }
}