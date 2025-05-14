using SKS_Yonetim_Backend.Models.Context;
using SKS_Yonetim_Backend.Models.DtoViewModels;

namespace SKS_Yonetim_Backend.Interfaces.IManagers
{
          public interface IAdminManager
          {
                    bool DeleteKullanici(int id);
                    DashboardModel GetDashboardData();
                    List<Kullanici> GetKullaniciByRol(int rol);
                    List<Log> GetLogList(int page);
                    bool ChangeAdminPassword(ChangePasswordModel changePasswordModel);
                    bool CreateRandevuYeri(RandevuYeri randevuYeri);
                    bool CreateRandevuTur(RandevuTur randevuTur);
          }
}