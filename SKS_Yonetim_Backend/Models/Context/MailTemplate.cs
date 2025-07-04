using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.Context
{
          public class MailTemplate 
          {
                    [Key]
                    public int Id { get; set; }
                    public int MailTip { get; set; }
                    public int DilId { get; set; }
                    public required string MailIcerik { get; set; }
                    public bool Aktif { get; set; }
          }
}