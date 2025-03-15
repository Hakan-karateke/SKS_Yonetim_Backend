namespace SKS_Yonetim_Backend.Models.Context
{
          public class RandevuYeri
          {
                    public int Id { get; set; }
                    public required string RandevuYeriAdi { get; set; }
                    public required string RandevuYeriAdres { get; set; }
                    public required string RandevuYeriTelefon { get; set; }
                    public required string RandevuYeriMail { get; set; }
                    public bool Aktif { get; set; }
                    public bool AyniAndaRandevu { get; set; }
                    public int AyniAndaRandevuSayisi { get; set; }

          }
}