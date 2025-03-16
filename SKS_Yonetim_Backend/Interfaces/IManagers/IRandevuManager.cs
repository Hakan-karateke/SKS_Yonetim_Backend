using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Interfaces.IManagers
{
    public interface IRandevuManager
    {
          bool CreateRandevuTur(RandevuTur randevuTur);
          bool UpdateRandevuTur(RandevuTur randevuTur);
          bool DeleteRandevuTur(int id);
          IEnumerable<RandevuTur> GetAllRandevuTur();
          RandevuTur GetRandevuTurById(int id);
          IEnumerable<Randevu> GetRandevuByRandevuTurId(int randevuTurId);
          IEnumerable<Randevu> GetRandevuByKullaniciId(int kullaniciId);
          bool DeleteRandevuById(int id);
          bool UpdateRandevu(Randevu randevu);
          IEnumerable<Randevu> GetAllRandevu();
    }
}