using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.Context
{
          public class RandevuYeri 
          {
                    [Key]
                    public int Id { get; set; }
                    [MaxLength(100)]
                    public required string RandevuYeriAdi { get; set; }
                    public required string RandevuYeriAdres { get; set; }
                    [Phone]
                    public required string RandevuYeriTelefon { get; set; }
                    [EmailAddress]
                    public required string RandevuYeriMail { get; set; }
                    public bool Aktif { get; set; }
                    public bool AyniAndaRandevu { get; set; }
                    public int AyniAndaRandevuSayisi { get; set; }

          }
}