using SKS_Yonetim_Backend.Models.Context;
using SKS_Yonetim_Backend.Models.DtoViewModels;

namespace SKS_Yonetim_Backend.Interfaces.IManagers
{
    public interface IKullaniciManager
    {
        Kullanici? GetKullaniciById(int id);
        bool ChangePassword(ChangePasswordModel changePasswordModel);
        bool UpdateKullanici (Kullanici kullanici);
        bool DeleteKullanici(int id);
        Task<List<Randevum>> GetKullaniciRandevumList(int kullaniciId, int page);
        bool CreateRandevum(Randevum randevum);
        bool DeleteRandevum(int id);
        Randevu? GetKullaniciRandevum(int kullaniciId);
    }
}