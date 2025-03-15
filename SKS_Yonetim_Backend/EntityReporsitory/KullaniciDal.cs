using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
          public class KullaniciDal : IKullaniciDal
          {
                    private readonly SKSDbContext _context;
                    public KullaniciDal(SKSDbContext context)
                    {
                              _context = context;
                    }

                    public Kullanici GetKullaniciByEmail(string email)
                    {
                              try
                              {
                                        var result = _context.Kullanicis.Where(x => x.Email == email).FirstOrDefault()!;
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public Kullanici GetKullaniciByEmailandSifre(string email, string sifre)
                    {
                              try
                              {
                                        var result = _context.Kullanicis.Where(x => x.Email == email && x.Sifre == sifre).FirstOrDefault()!;
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Add(Kullanici entity)
                    {
                              try
                              {
                                        _context.Kullanicis.Add(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }


                    public bool Delete(Kullanici entity)
                    {
                              try
                              {
                                        _context.Kullanicis.Remove(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public IEnumerable<Kullanici> GetAll()
                    {
                              try
                              {
                                        var result = _context.Kullanicis.ToList();
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public Kullanici GetById(int id)
                    {
                              try
                              {
                                        var result = _context.Kullanicis.Find(id)!;
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Update(Kullanici entity)
                    {
                              try
                              {
                                        _context.Kullanicis.Update(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }
          }
}