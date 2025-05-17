using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Helpers;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Interfaces.IManagers;
using SKS_Yonetim_Backend.Models.Context;
using SKS_Yonetim_Backend.Models.DtoViewModels;
using System;

namespace SKS_Yonetim_Backend.Managers
{
    public class AdminManager : IAdminManager
    {
        private readonly IKullaniciDal _kullaniciDal;
        private readonly IRandevuTurDal _randevuTurDal;
        private readonly IRandevuDal _randevuDal;
        private readonly ILogDal _logDal;
        private readonly IRandevumDal _randevumDal;
        private readonly IRandevuYeriDal _randevuYeriDal;

        public AdminManager(IKullaniciDal kullaniciDal, IRandevuTurDal randevuTurDal,
            IRandevuDal randevuDal, ILogDal logDal, IRandevumDal randevumDal, IRandevuYeriDal randevuYeriDal)
        {
            _kullaniciDal = kullaniciDal;
            _randevuTurDal = randevuTurDal;
            _randevuDal = randevuDal;
            _logDal = logDal;
            _randevumDal = randevumDal;
            _randevuYeriDal = randevuYeriDal;
        }

        public bool DeleteKullanici(int id)
        {
            try
            {
                return _kullaniciDal.Delete(id);
            }
            catch
            {
                return false;
            }
        }

        public DashboardModel GetDashboardData()
        {
            try
            {
                return new DashboardModel
                {
                    ToplamKullaniciSayisi = _kullaniciDal.GetAll().Count(),
                    ToplamPersonelSayisi = _kullaniciDal.GetKullaniciByRol(RolTip.Personel.GetHashCode()).Count,
                    ToplamOnaysizKullaniciSayisi = _kullaniciDal.GetKullaniciByRolAndOnay(
                                    IslemTip.Onaylandi.GetHashCode(),
                                    RolTip.Kullanici.GetHashCode()
                          ).Count,
                    ToplamOnaysizPersonelSayisi = _kullaniciDal.GetKullaniciByRolAndOnay(
                                    IslemTip.Onaylandi.GetHashCode(),
                                    RolTip.Personel.GetHashCode()
                          ).Count,
                    ToplamRandevuSayisi = _randevuDal.GetAllRandevuCount(),
                    ToplamRandevuTurSayisi = _randevuTurDal.GetRandevuTurCount(),
                    ToplamRandevumSayisi = _randevumDal.GetAllRandevumCount(),
                    ToplamRandevuTurSayisiAktif = _randevuTurDal.GetRandevuTurCountByAktif(true),
                    ToplamRandevuTurSayisiPasif = _randevuTurDal.GetRandevuTurCountByAktif(false),
                    ToplamBekleyenRandevuSayisi = _randevumDal.GetRandevuCountByOnaylandiMi(false),
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Manager katmaninda hata", ex);
            }
        }

        public List<Kullanici> GetKullaniciByRol(int rol)
        {
            try
            {
                return _kullaniciDal.GetKullaniciByRol(rol);
            }
            catch (Exception ex)
            {
                throw new Exception("Manager katmaninda hata", ex);
            }
        }

        public List<Log> GetLogList(int page)
        {
            try
            {
                int pageSize = 20;
                return [.. _logDal.GetAll()
                                                  .OrderByDescending(l => l.Logged)
                                                  .Skip((page - 1) * pageSize)
                                                  .Take(pageSize)];
            }
            catch (Exception ex)
            {
                throw new Exception("Manager katmaninda hata", ex);
            }
        }

        public bool ChangeAdminPassword(ChangePasswordModel changePasswordModel)
        {
            try
            {
                if (string.IsNullOrEmpty(changePasswordModel.Email) || string.IsNullOrEmpty(changePasswordModel.OldPassword) || string.IsNullOrEmpty(changePasswordModel.NewPassword))
                    return false;

                var kullanici = _kullaniciDal.GetKullaniciByEmailandSifre(
                          changePasswordModel.Email,
                          GeneralTools.ComputeSha1Password(changePasswordModel.OldPassword)
                );
                if (kullanici == null)
                    return false;

                kullanici.Sifre = GeneralTools.ComputeSha1Password(changePasswordModel.NewPassword);
                _kullaniciDal.Update(kullanici);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Manager katmaninda hata", ex);
            }
        }
    }
}