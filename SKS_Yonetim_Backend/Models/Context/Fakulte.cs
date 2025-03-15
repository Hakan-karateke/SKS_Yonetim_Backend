using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.Context
{
          public class Fakulte
          {
                    [Key]
                    public int Id { get; set; }
                    public required string Ad { get; set; }
          }
}