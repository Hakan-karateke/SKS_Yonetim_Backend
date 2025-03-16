using SKS_Yonetim_Backend.Models.Context;
namespace SKS_Yonetim_Backend.Models.DtoViewModels
{
          public class DtoCalender
          {
                    public Randevu? Randevu { get; set; }
                    public RandevuTur? RandevuTur { get; set; }
                    public List<RandevuYetkilendirme>? RandevuYetkilendirmeler { get; set; }
                    public List<RandevuGrup>? RandevuGruplar { get; set; }
                    public List<RandevuAlinmayacakSaat>? randevuAlinmayacakSaatler { get; set; }
                    public List<RandevuAlinanSaat>? randevuAlinanSaatler { get; set; }
                    public List<RandevuYeri>? randevuYerleri { get; set; }
          }
}