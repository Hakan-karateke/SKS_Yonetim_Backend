using SKS_Yonetim_Backend.Models.Context;
using SKS_Yonetim_Backend.Models.DtoViewModels;

namespace SKS_Yonetim_Backend.Interfaces.IManagers
{
    public interface IRandevuManager
    {
        bool CreateRandevuTur(RandevuTur randevuTur);
        bool UpdateRandevuTur(RandevuTur randevuTur);
        bool DeleteRandevuTur(int id);
        List<RandevuTur> GetAllRandevuTur();
        RandevuTur GetRandevuTurById(int id);
        bool CreateRandevu(Randevu randevu);
        bool UpdateRandevu(Randevu randevu);
        bool DeleteRandevuById(int id);
        IEnumerable<Randevu> GetAllRandevu();
        List<Randevu> GetRandevuByRandevuTurId(int randevuTurId);
        List<Randevu> GetRandevuByKullaniciId(int kullaniciId);

        // Yeni eklenen metotlar
        DashboardModel GetPersonelDashboardData(int personelId);
        List<Randevu> GetRandevuByCreatedPersonelId(int personelId);
        bool CreateRandevuYeri(RandevuYeri randevuYeri);
        RandevuYeri? GetRandevuYeriById(int id);
        List<RandevuYeri> GetAllRandevuYeri();
        bool UpdateRandevuYeri(RandevuYeri randevuYeri);
        bool DeleteRandevuYeri(int id);
        bool CreateOrUpdateRandevuWithCalender(DtoCalender dtoCalender);
        DtoCalender GetDtoCalenderByRandevuId(int randevuId);
    }
}