using SKS_Yonetim_Backend.Models.Context;
namespace SKS_Yonetim_Backend.Models.DtoViewModels
{
          public class DtoCalender
          {
                    public Randevu? Randevu { get; set; }
                    public List<RandevuGrup>? RandevuGruplar { get; set; }
                    public List<RandevuAlinmayacakSaat>? RandevuAlinmayacakSaatler { get; set; }
                    public List<RandevuAlinanSaat>? RandevuAlinanSaatler { get; set; }
          }
}