using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.Context
{
          public class Dil
          {
                    [Key]
                    public int Id { get; set; }
                    public required string DilAdi { get; set; }
                    public required string DilKodu { get; set; }
          }
}