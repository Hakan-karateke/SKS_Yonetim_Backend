namespace SKS_Yonetim_Backend.Models.Context
{
          public class RandevuAlinanSaat
          {
                    public int Id { get; set; }
                    public int RandevuId { get; set; }
                    public int BaslangicSaat { get; set; }
                    public int BaslangicDakika { get; set; }
                    public int BitisSaat { get; set; }
                    public int BitisDakika { get; set; }
                    public bool Aktif { get; set; }
          }
}