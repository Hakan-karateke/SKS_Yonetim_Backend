namespace SKS_Yonetim_Backend.Models.Context
{
          public class RandevuTur
          {
                    public int Id { get; set; }
                    public required string RandevuTipAdi { get; set; }
                    public required string RandevuTipAciklama { get; set; }
                    public bool Aktif { get; set; }
          }
}