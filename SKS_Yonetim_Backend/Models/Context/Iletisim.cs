namespace SKS_Yonetim_Backend.Models.Context
{
          public class Iletisim
          {
                    public int Id { get; set; }
                    public required string Ad { get; set; }
                    public required string Soyad { get; set; }
                    public required string Email { get; set; }
                    public required string Konu { get; set; }
                    public required string Mesaj { get; set; }
                    public DateTime Tarih { get; set; }
          }
}