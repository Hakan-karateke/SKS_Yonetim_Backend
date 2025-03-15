using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.Context
{
          public class RandevuYetkilendirme
          {
                    [Key]
                    public int Id { get; set; }
                    public int RandevuId { get; set; }
                    public int? KullaniciId { get; set; }
                    public int? RolTip { get; set; }
                    public bool Aktif { get; set; }
          }
}