namespace SKS_Yonetim_Backend.Models.Context
{
          public class Personel
          {
                    public int Id { get; set; }
                    public required string PersonelNo { get; set; }
                    public required string Ad { get; set; }
                    public required string Soyad { get; set; }
                    public required string Email { get; set; }
                    public required string Telefon { get; set; }
                    public required string Adres { get; set; }
                    public required string Sifre { get; set; }
                    public required string UnvanId { get; set; }
                    public required int BolumId { get; set; }
                    public required string FakulteId { get; set; }
                    public int Onay { get; set; }
                    public int KullaniciId { get; set; }
          }
}