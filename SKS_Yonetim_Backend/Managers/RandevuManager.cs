using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Interfaces.IManagers;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Managers
{
          public class RandevuManager : IRandevuManager
          {
                    private readonly IRandevuTurDal _randevuTur;
                    private readonly IRandevuDal _randevu;

                    public RandevuManager(IRandevuTurDal randevuTur, IRandevuDal randevu)
                    {
                              _randevuTur = randevuTur;
                              _randevu = randevu;
                    }
                    public bool CreateRandevuTur(RandevuTur randevuTur)
                    {
                              try
                              {
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
                                        return _randevuTur.Update(randevuTur);
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Manager Katmaninda Hata", ex);
                              }
                    }

                    /// <summary>
                    /// Randevu Tur Id'sine göre randevu tur silme işlemi yapar.
                    /// Bu method daha sonra düzenlenecek bir randevuTur silinirse ona bağlı olan tüm veriler silinmeli
                    /// </summary>
                    /// <param name="id"></param>
                    /// <returns>bool true or false</returns>
                    /// <exception cref="Exception"></exception>
                    public bool DeleteRandevuTur(int id)
                    {
                              try
                              {
                                        return _randevuTur.Delete(id);
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Manager Katmaninda Hata", ex);
                              }
                    }

                    public List<RandevuTur> GetAllRandevuTur()
                    {
                              try
                              {
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
                                        return _randevuTur.GetById(id);
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
                    /// Bu method daha sonra düzenlenecek bir randevu silinirse ona bağlı olan tüm veriler silinmeli
                    /// </summary>
                    /// <param name="id"></param>
                    /// <returns>bool true or false</returns>
                    /// <exception cref="Exception"></exception>
                    public bool DeleteRandevuById(int id)
                    {
                              try
                              {
                                        return _randevu.Delete(id);
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Manager Katmaninda Hata", ex);
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
          }
}