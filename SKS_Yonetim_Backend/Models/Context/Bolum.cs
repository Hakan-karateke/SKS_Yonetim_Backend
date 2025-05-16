using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.Context
{
          public class Bolum 
          {
                    [Key]
                    public int Id { get; set; }
                    public required string Ad { get; set; }
                    public required string FakulteId { get; set; }
          }
}