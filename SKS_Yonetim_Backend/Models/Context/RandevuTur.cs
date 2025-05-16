using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.Context
{
          public class RandevuTur 
          {
                    [Key]
                    public int Id { get; set; }
                    public required string RandevuTipAdi { get; set; }
                    public required string RandevuTipAciklama { get; set; }
                    public bool Aktif { get; set; }
                    public string? RenkKodu { get; set; }
          }
}