using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.Context
{
          public class Randevum
          {
                    [Key]
                    public int ID { get; set; }
                    public int randevuID { get; set; }
                    public Randevu? RandevuBilgi { get; set; }
                    public int KullaniciID { get; set; }
                    public DateTime AlinmaTarihi { get; set; }
                    public DateTime RandevuTarihi { get; set; }
                    public string? RandevuNotu { get; set; }
                    public bool OnaylandiMi { get; set; }
          }
}