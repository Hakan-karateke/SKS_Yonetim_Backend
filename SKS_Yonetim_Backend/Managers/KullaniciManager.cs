using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Helpers;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Interfaces.IManagers;
using SKS_Yonetim_Backend.Models.Context;
using SKS_Yonetim_Backend.Models.DtoViewModels;

namespace SKS_Yonetim_Backend.Managers
{
    public class KullaniciManager : IKullaniciManager
    {
        private readonly IKullaniciDal _kullaniciDal;
        private readonly IRandevuDal _randevuDal;
        private readonly IRandevumDal _randevumDal;
        private readonly IRandevuYetkilendirmeDal _randevuYetkilendirmeDal;
        private readonly ILogDal _logDal;
        private IDbContextTransaction? _transaction = null;

        public KullaniciManager(
            IKullaniciDal kullaniciDal,
            IRandevuDal randevuDal,
            IRandevumDal randevumDal,
            IRandevuYetkilendirmeDal randevuYetkilendirmeDal,
            ILogDal logDal)
        {
            _kullaniciDal = kullaniciDal;
            _randevuDal = randevuDal;
            _randevumDal = randevumDal;
            _randevuYetkilendirmeDal = randevuYetkilendirmeDal;
            _logDal = logDal;
        }

        public Kullanici? GetKullaniciById(int id)
        {
            try
            {
                return _kullaniciDal.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Manager katmaninda hata", ex);
            }
        }

        public bool ChangePassword(ChangePasswordModel changePasswordModel)
        {
            try
            {
                Kullanici kullanici = _kullaniciDal.GetById(changePasswordModel.KullaniciId)
                    ?? throw new Exception("Kullanıcı bulunamadı");
                if (kullanici == null || kullanici.Sifre != GeneralTools.ComputeSha1Password(changePasswordModel.OldPassword!))
                {
                    return false;
                }
                kullanici.Sifre = GeneralTools.ComputeSha1Password(changePasswordModel.NewPassword!);
                return _kullaniciDal.Update(kullanici);
            }
            catch (Exception ex)
            {
                throw new Exception("Manager katmaninda hata", ex);
            }
        }

        public bool UpdateKullanici(Kullanici kullanici)
        {
            try
            {
                return _kullaniciDal.Update(kullanici);
            }
            catch (Exception ex)
            {
                throw new Exception("Manager katmaninda hata", ex);
            }
        }

        /// <summary>
        /// Kullanıcıyı ve ilişkili tüm verileri siler.
        /// İşlemler bir _transaction içinde gerçekleştirilir.
        /// </summary>
        /// <param name="id">Silinecek kullanıcının id'si</param>
        /// <returns>İşlemin başarılı olup olmadığı</returns>
        public bool DeleteKullanici(int id)
        {
            try
            {
                // _transaction başlat
                _transaction = _kullaniciDal.BeginTransaction();

                // Kullanıcı bilgilerini al
                var kullanici = _kullaniciDal.GetById(id);
                if (kullanici == null)
                {
                    return false;
                }

                // Kullanıcının oluşturduğu randevuları sil
                if (_randevuDal != null)
                {
                    var randevular = _randevuDal.GetAll().Where(r => r.KullaniciId == id).ToList();
                    foreach (var randevu in randevular)
                    {
                        // Randevu silme metodunu çağır (bu metot zaten kendi içinde ilişkili verileri siliyor)
                        if (_randevuDal is IRandevuDal randevuDal)
                        {
                            var randevuManager = new RandevuManager(randevuDal);
                            randevuManager.DeleteRandevuById(randevu.Id);
                        }
                    }
                }

                // Kullanıcının aldığı randevuları sil
                if (_randevumDal != null)
                {
                    var randevularim = _randevumDal.GetAll().Where(r => r.KullaniciID == id).ToList();
                    foreach (var randevum in randevularim)
                    {
                        _randevumDal.Delete(randevum);
                    }
                }

                // Kullanıcıya ait hata loglarını sil
                if (_logDal != null)
                {
                    var hataLoglar = _logDal.GetAll().Where(h => h.UserId == id).ToList();
                    foreach (var hataLog in hataLoglar)
                    {
                        _logDal.Delete(hataLog);
                    }
                }

                // Son olarak kullanıcıyı sil
                bool result = _kullaniciDal.Delete(id);

                // İşlem başarılıysa _transaction'ı onayla
                _transaction.Commit();

                return result;
            }
            catch (Exception ex)
            {
                // Hata durumunda _transaction'ı geri al
                _transaction?.Rollback();

                throw new Exception("Kullanıcı ve ilişkili veriler silinirken hata oluştu", ex);
            }
        }

        public bool CreateRandevum(Randevum randevum)
        {
            try
            {
                return _randevumDal.Add(randevum);
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu eklenirken hata oluştu", ex);
            }
        }

        public async Task<List<Randevum>> GetKullaniciRandevumList(int kullaniciId, int page)
        {
            try
            {
                return await _randevumDal.GetRandevularByKullaniciIdAndPageSize(kullaniciId, page);
            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcı randevuları listelenirken hata oluştu", ex);
            }
        }

        public bool DeleteRandevum(int id)
        {
            try
            {
                return _randevumDal.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Manager katmaninda hata", ex);
            }
        }
        public Randevu? GetKullaniciRandevum(int kullaniciId)
        {
            try
            {
                return _randevuDal.GetAll().FirstOrDefault(r => r.KullaniciId == kullaniciId);
            }
            catch (Exception ex)
            {
                throw new Exception("Manager katmaninda hata", ex);
            }
        }
    }
}