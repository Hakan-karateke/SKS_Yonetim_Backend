using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.Context
{
          public class RandevuAlinanSaat
          {
                    [Key]
                    public int Id { get; set; }
                    public int RandevuId { get; set; }
                    public TimeSpan BaslangicZamani { get; set; }
                    public TimeSpan BitisZamani { get; set; }
                    public bool Aktif { get; set; }
          }
}