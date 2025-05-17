using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Interfaces.IManagers;
using SKS_Yonetim_Backend.Models.Context;
using SKS_Yonetim_Backend.Models.DtoViewModels;

namespace SKS_Yonetim_Backend.Managers
{
    public class RandevuManager(
        IRandevuDal randevu,
        IRandevuTurDal? randevuTur = null,
        IRandevumDal? randevum = null,
        IRandevuAlinanSaatDal? randevuAlinanSaat = null,
        IRandevuAlinmayacakSaatDal? randevuAlinmayacakSaat = null,
        IRandevuYetkilendirmeDal? randevuYetkilendirme = null,
        IRandevuYeriDal? randevuYeriDal = null,
        IRandevuGrupDal? randevuGrupDal = null) : IRandevuManager
    {
        private readonly IRandevuTurDal? _randevuTur = randevuTur;
        private readonly IRandevuDal _randevu = randevu;
        private readonly IRandevumDal? _randevum = randevum;
        private readonly IRandevuAlinanSaatDal? _randevuAlinanSaat = randevuAlinanSaat;
        private readonly IRandevuAlinmayacakSaatDal? _randevuAlinmayacakSaat = randevuAlinmayacakSaat;
        private readonly IRandevuYetkilendirmeDal? _randevuYetkilendirme = randevuYetkilendirme;
        private readonly IRandevuYeriDal? _randevuYeriDal = randevuYeriDal;
        private IDbContextTransaction? transaction = null;
        private readonly IRandevuGrupDal? _randevuGrupDal = randevuGrupDal;

        public bool CreateRandevuTur(RandevuTur randevuTur)
        {
            try
            {
                if (_randevuTur == null)
                {
                    throw new ArgumentNullException(nameof(_randevuTur), "Randevu türü boş olamaz.");
                }
                return _randevuTur.Add(randevuTur);
            }
            catch (Exception ex)
            {
                throw new Exception("Manager Katmaninda Hata", ex);
            }
        }

        public bool UpdateRandevuTur(RandevuTur randevuTur)
        {
            try
            {
                if (_randevuTur == null)
                {
                    throw new ArgumentNullException(nameof(_randevuTur), "Randevu türü boş olamaz.");
                }
                return _randevuTur.Update(randevuTur);
            }
            catch (Exception ex)
            {
                throw new Exception("Manager Katmaninda Hata", ex);
            }
        }

        /// <summary>
        /// Randevu Tur Id'sine göre randevu tur silme işlemi yapar.
        /// Bir randevuTur silindiğinde, ona bağlı olan tüm verileri siler
        /// İşlem transaction kullanılarak yapılır.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool DeleteRandevuTur(int id)
        {
            try
            {
                if (_randevuTur == null)
                {
                    throw new ArgumentNullException(nameof(_randevuTur), "Randevu türü boş olamaz.");
                }
                // Transaction başlat
                transaction = _randevuTur.BeginTransaction();

                // İlgili randevu türüne bağlı randevuları bul
                var randevular = GetRandevuByRandevuTurId(id);

                // Her bir randevu için bağlı kayıtları sil
                foreach (var randevu in randevular)
                {
                    DeleteRandevuById(randevu.Id);
                }

                // Randevu türünü sil
                bool result = _randevuTur.Delete(id);

                // İşlem başarılıysa transaction'ı onayla
                transaction.Commit();

                return result;
            }
            catch (Exception ex)
            {
                // Hata durumunda transaction'ı geri al
                transaction?.Rollback();

                throw new Exception("Randevu türü ve ilişkili veriler silinirken hata oluştu", ex);
            }
        }

        public List<RandevuTur> GetAllRandevuTur()
        {
            try
            {
                if (_randevuTur == null)
                {
                    throw new ArgumentNullException(nameof(_randevuTur), "Randevu türü boş olamaz.");
                }
                return [.. _randevuTur.GetAll()];
            }
            catch (Exception ex)
            {
                throw new Exception("Manager Katmaninda Hata", ex);
            }
        }

        public RandevuTur GetRandevuTurById(int id)
        {
            try
            {
                if (_randevuTur == null)
                {
                    throw new Exception("Randevu türü boş olamaz.");
                }
                var result = _randevuTur.GetById(id) ?? throw new Exception($"Randevu türü bulunamadı. Id: {id}");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Manager Katmaninda Hata", ex);
            }
        }

        public bool CreateRandevu(Randevu randevu)
        {
            try
            {
                return _randevu.Add(randevu);
            }
            catch (Exception ex)
            {
                throw new Exception("Manager Katmaninda Hata", ex);
            }
        }

        public bool UpdateRandevu(Randevu randevu)
        {
            try
            {
                return _randevu.Update(randevu);
            }
            catch (Exception ex)
            {
                throw new Exception("Manager Katmaninda Hata", ex);
            }
        }

        /// <summary>
        /// Randevu Id'sine göre randevu silme işlemi yapar.
        /// Bir randevu silindiğinde, ona bağlı olan tüm verileri siler
        /// İşlem transaction kullanılarak yapılır.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool DeleteRandevuById(int id)
        {
            try
            {
                // Transaction başlat
                transaction = _randevu.BeginTransaction();

                // Randevu bilgilerini al
                var randevu = _randevu.GetById(id);
                if (randevu == null)
                {
                    return false;
                }

                // İlişkili randevum kayıtlarını sil
                if (_randevum != null)
                {
                    var randevumKayitlari = _randevum.GetAll().Where(r => r.RandevuID == id).ToList();
                    foreach (var randevum in randevumKayitlari)
                    {
                        _randevum.Delete(randevum);
                    }
                }

                // İlişkili randevu saatleri kayıtlarını sil
                if (_randevuAlinanSaat != null)
                {
                    var alinanSaatler = _randevuAlinanSaat.GetAll().Where(s => s.RandevuId == id).ToList();
                    foreach (var saat in alinanSaatler)
                    {
                        _randevuAlinanSaat.Delete(saat);
                    }
                }

                // İlişkili alınmayacak saatler kayıtlarını sil
                if (_randevuAlinmayacakSaat != null)
                {
                    var alinmayacakSaatler = _randevuAlinmayacakSaat.GetAll().Where(s => s.RandevuId == id).ToList();
                    foreach (var saat in alinmayacakSaatler)
                    {
                        _randevuAlinmayacakSaat.Delete(saat);
                    }
                }

                // İlişkili yetkilendirme kayıtlarını sil
                if (_randevuYetkilendirme != null)
                {
                    var yetkilendirmeler = _randevuYetkilendirme.GetAll().Where(y => y.RandevuId == id).ToList();
                    foreach (var yetkilendirme in yetkilendirmeler)
                    {
                        _randevuYetkilendirme.Delete(yetkilendirme);
                    }
                }

                if (_randevuGrupDal != null)
                {
                    var randevuGruplari = _randevuGrupDal.GetAll().Where(g => g.RandevuId == id).ToList();
                    foreach (var grup in randevuGruplari)
                    {
                        _randevuGrupDal.Delete(grup);
                    }
                }

                // Son olarak randevuyu sil
                bool result = _randevu.Delete(id);

                // İşlem başarılıysa transaction'ı onayla
                transaction.Commit();

                return result;
            }
            catch (Exception ex)
            {
                // Hata durumunda transaction'ı geri al
                transaction?.Rollback();

                throw new Exception("Randevu ve ilişkili veriler silinirken hata oluştu", ex);
            }
        }

        public IEnumerable<Randevu> GetAllRandevu()
        {
            try
            {
                return _randevu.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Manager Katmaninda Hata", ex);
            }
        }

        public List<Randevu> GetRandevuByRandevuTurId(int randevuTurId)
        {
            try
            {
                return [.. _randevu.GetAll().Where(x => x.RandevuTurId == randevuTurId)];
            }
            catch (Exception ex)
            {
                throw new Exception("Manager Katmaninda Hata", ex);
            }
        }

        public List<Randevu> GetRandevuByKullaniciId(int kullaniciId)
        {
            try
            {
                return [.. _randevu.GetAll().Where(x => x.KullaniciId == kullaniciId)];
            }
            catch (Exception ex)
            {
                throw new Exception("Manager Katmaninda Hata", ex);
            }
        }

        /// <summary>
        /// Personel için dashboard verilerini getirir
        /// </summary>
        /// <param name="personelId">Personelin kullanıcı ID'si</param>
        /// <returns>Personel dashboard bilgileri</returns>
        public DashboardModel GetPersonelDashboardData(int personelId)
        {
            try
            {
                // Personelin oluşturduğu randevular
                var personelRandevulari = _randevu.GetList(r => r.KullaniciId == personelId);

                // Bu randevulardan alınan randevular (yani randevum tablosundaki)
                int alinanRandevuSayisi = 0;
                if (_randevum != null)
                {
                    // Personelin oluşturduğu randevuları ID listesi olarak al
                    var randevuIds = personelRandevulari.Select(r => r.Id).ToList();

                    // Bu randevulardan kaç randevum kaydı var
                    alinanRandevuSayisi = _randevum.GetList(rm => randevuIds.Contains(rm.RandevuID)).Count();
                }

                return new DashboardModel
                {
                    ToplamRandevuSayisi = personelRandevulari.Count(),  // Personelin açtığı tüm randevular
                    ToplamRandevumSayisi = alinanRandevuSayisi,      // Personelin açtığı randevulardan kullanıcıların aldığı randevu sayısı
                    ToplamBekleyenRandevuSayisi = _randevum != null ?
                        _randevum.GetList(r => !r.OnaylandiMi &&
                            personelRandevulari.Select(pr => pr.Id).Contains(r.RandevuID)).Count() : 0
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Personel dashboard bilgileri getirilirken hata oluştu", ex);
            }
        }

        /// <summary>
        /// Belirli bir personelin oluşturduğu tüm randevuları getirir
        /// </summary>
        /// <param name="personelId">Personelin kullanıcı ID'si</param>
        /// <returns>Personelin oluşturduğu randevular listesi</returns>
        public List<Randevu> GetRandevuByCreatedPersonelId(int personelId)
        {
            try
            {
                return [.. _randevu.GetList(r => r.KullaniciId == personelId)];
            }
            catch (Exception ex)
            {
                throw new Exception("Personelin oluşturduğu randevular listelenirken hata oluştu", ex);
            }
        }

        /// <summary>
        /// Yeni bir randevu yeri oluşturur
        /// </summary>
        /// <param name="randevuYeri">Oluşturulacak randevu yeri bilgileri</param>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        public bool CreateRandevuYeri(RandevuYeri randevuYeri)
        {
            try
            {
                if (_randevuYeriDal == null)
                {
                    throw new ArgumentNullException(nameof(_randevuYeriDal), "Randevu yeri dal nesnesi boş olamaz.");
                }
                return _randevuYeriDal.Add(randevuYeri);
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yeri oluşturulurken hata oluştu", ex);
            }
        }

        /// <summary>
        /// Belirli bir randevu yerine ait bilgileri getirir
        /// </summary>
        /// <param name="id">Randevu yeri ID'si</param>
        /// <returns>Randevu yeri bilgileri</returns>
        public RandevuYeri? GetRandevuYeriById(int id)
        {
            try
            {
                if (_randevuYeriDal == null)
                {
                    throw new Exception("Randevu yeri dal nesnesi boş olamaz.");
                }
                return _randevuYeriDal.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yeri bilgileri getirilirken hata oluştu", ex);
            }
        }

        /// <summary>
        /// Tüm randevu yerlerini listeler
        /// </summary>
        /// <returns>Randevu yerleri listesi</returns>
        public List<RandevuYeri> GetAllRandevuYeri()
        {
            try
            {
                if (_randevuYeriDal == null)
                {
                    throw new ArgumentNullException(nameof(_randevuYeriDal), "Randevu yeri dal nesnesi boş olamaz.");
                }
                return [.. _randevuYeriDal.GetAll()];
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yerleri listelenirken hata oluştu", ex);
            }
        }

        /// <summary>
        /// Bir randevu yerini günceller
        /// </summary>
        /// <param name="randevuYeri">Güncellenecek randevu yeri bilgileri</param>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        public bool UpdateRandevuYeri(RandevuYeri randevuYeri)
        {
            try
            {
                if (_randevuYeriDal == null)
                {
                    throw new ArgumentNullException(nameof(_randevuYeriDal), "Randevu yeri dal nesnesi boş olamaz.");
                }
                return _randevuYeriDal.Update(randevuYeri);
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yeri güncellenirken hata oluştu", ex);
            }
        }

        /// <summary>
        /// Bir randevu yerini siler
        /// </summary>
        /// <param name="id">Silinecek randevu yeri ID'si</param>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        public bool DeleteRandevuYeri(int id)
        {
            try
            {
                if (_randevuYeriDal == null)
                {
                    throw new ArgumentNullException(nameof(_randevuYeriDal), "Randevu yeri dal nesnesi boş olamaz.");
                }

                // Randevu yerine bağlı randevular var mı kontrol et
                var relatedRandevular = _randevu.GetList(r => r.RandevuYeriId == id);
                if (relatedRandevular.Any())
                {
                    List<Randevu> randevular = relatedRandevular.ToList();
                    foreach (var randevu in randevular)
                    {
                        // Randevuya ait tüm ilişkili verileri sil
                        DeleteRandevuById(randevu.Id);
                    }
                }

                return _randevuYeriDal.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yeri silinirken hata oluştu", ex);
            }
        }

        /// <summary>
        /// dtoCalender'ı kullanarak bir randevu oluşturur veya günceller
        /// </summary>
        /// <param name="dtoCalender">Randevu bilgilerini içeren DTO</param>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        public bool CreateOrUpdateRandevuWithCalender(DtoCalender dtoCalender)
        {
            try
            {
                transaction = _randevu.BeginTransaction();

                // Randevu bilgilerini set et
                var randevu = dtoCalender.Randevu ?? throw new Exception("Randevu bilgileri boş olamaz.");
                bool? result;
                // Yeni randevu ekleme veya güncelleme
                if (randevu.Id == 0)
                {
                    result = _randevu.Add(randevu);
                }
                else
                {
                    result = _randevu.Update(randevu);
                }

                // Randevuya ait alinan saatleri ekle
                if (dtoCalender.RandevuAlinanSaatler != null)
                {
                    foreach (var saat in dtoCalender.RandevuAlinanSaatler)
                    {
                        if (saat.Id == 0)
                        {
                            saat.RandevuId = randevu.Id;
                            result = _randevuAlinanSaat?.Add(saat);
                        }
                        else
                        {
                            // Güncelleme işlemi
                            var existingSaat = _randevuAlinanSaat?.GetById(saat.Id);
                            if (existingSaat != null)
                            {
                                existingSaat.RandevuId = randevu.Id;
                                result = _randevuAlinanSaat?.Update(existingSaat);
                            }
                        }
                    }
                }
                // Randevuya ait alınmayacak saatleri ekle
                if (dtoCalender.RandevuAlinmayacakSaatler != null && dtoCalender.RandevuAlinmayacakSaatler.Count > 0)
                {
                    foreach (var saat in dtoCalender.RandevuAlinmayacakSaatler)
                    {
                        if (saat.Id == 0)
                        {
                            saat.RandevuId = randevu.Id;
                            result = _randevuAlinmayacakSaat?.Add(saat);
                        }
                        else
                        {
                            // Güncelleme işlemi
                            var existingSaat = _randevuAlinmayacakSaat?.GetById(saat.Id);
                            if (existingSaat != null)
                            {
                                existingSaat.RandevuId = randevu.Id;
                                result = _randevuAlinmayacakSaat?.Update(existingSaat);
                            }
                        }
                    }
                }
                else
                {
                    // Randevuya ait alınmayacak saatleri sil
                    var alinmayacakSaatler = _randevuAlinmayacakSaat?.GetAll().Where(s => s.RandevuId == randevu.Id).ToList();
                    if (alinmayacakSaatler != null)
                    {
                        foreach (var saat in alinmayacakSaatler)
                        {
                            result = _randevuAlinmayacakSaat?.Delete(saat);
                        }
                    }
                }
                // Randevuya ait grupları ekle
                if (dtoCalender.RandevuGruplar != null && dtoCalender.RandevuGruplar.Count > 0)
                {
                    foreach (var grup in dtoCalender.RandevuGruplar)
                    {
                        if (grup.Id == 0)
                        {
                            grup.RandevuId = randevu.Id;
                            result = _randevuGrupDal?.Add(grup);
                        }
                        else
                        {
                            // Güncelleme işlemi
                            var existingGrup = _randevuGrupDal?.GetById(grup.Id);
                            if (existingGrup != null)
                            {
                                existingGrup.RandevuId = randevu.Id;
                                result = _randevuGrupDal?.Update(existingGrup);
                            }
                        }
                    }
                }
                else
                {
                    // Randevuya ait grupları sil
                    var gruplar = _randevuGrupDal?.GetAll().Where(g => g.RandevuId == randevu.Id).ToList();
                    if (gruplar != null)
                    {
                        foreach (var grup in gruplar)
                        {
                            result = _randevuGrupDal?.Delete(grup);
                        }
                    }
                }
                // tüm işlemler başarılıysa transaction'ı onayla
                if (result == null || !result.Value == false)
                {
                    transaction.Commit();
                    return true;
                }
                transaction.Rollback();
                return false;

            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw new Exception("Randevu oluşturulurken veya güncellenirken hata oluştu", ex);
            }
        }

        public DtoCalender GetDtoCalenderByRandevuId(int randevuId)
        {
            try
            {
                var randevu = _randevu.GetById(randevuId) ?? throw new Exception("Randevu bulunamadı.");
                var dtoCalender = new DtoCalender
                {
                    Randevu = randevu,
                    RandevuAlinanSaatler = _randevuAlinanSaat?.GetList(s => s.RandevuId == randevuId).ToList() ?? [],
                    RandevuAlinmayacakSaatler = _randevuAlinmayacakSaat?.GetList(s => s.RandevuId == randevuId).ToList() ?? [],
                    RandevuGruplar = _randevuGrupDal?.GetList(g => g.RandevuId == randevuId).ToList() ?? []
                };

                return dtoCalender;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu bilgileri getirilirken hata oluştu", ex);
            }
        }
    }
}