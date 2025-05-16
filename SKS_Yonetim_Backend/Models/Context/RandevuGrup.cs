using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.Context
{
          public class RandevuGrup 
          {
                    [Key]
                    public int Id { get; set; }
                    public int RandevuId { get; set; }
                    public int RolTip { get; set; }
                    public bool Aktif { get; set; }
          }
}