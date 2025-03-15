namespace SKS_Yonetim_Backend.Models.Context
{
          public class RandevuYetkilendirme
          {
                    public int Id { get; set; }
                    public int RandevuId { get; set; }
                    public int? KullaniciId { get; set; }
                    public int? RolTip { get; set; }
                    public bool Aktif { get; set; }
          }
}