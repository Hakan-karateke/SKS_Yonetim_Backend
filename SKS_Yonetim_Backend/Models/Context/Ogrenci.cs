namespace SKS_Yonetim_Backend.Models.Context
{
          public class Ogrenci
          {
                    public int Id { get; set; }
                    public required string OgrenciNo { get; set; }
                    public required string Ad { get; set; }
                    public required string Soyad { get; set; }
                    public required string Email { get; set; }
                    public required string Telefon { get; set; }
                    public required string Adres { get; set; }
                    public required string Bolum { get; set; }
                    public required string Sinif { get; set; }
                    public required string Sifre { get; set; }
                    public int Onay { get; set; }
                    public int KullaniciId { get; set; }
          }
}