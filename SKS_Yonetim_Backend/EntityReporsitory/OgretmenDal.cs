using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
          public class OgretmenDal : IOgretmenDal
          {
                    private readonly SKSDbContext _context;
                    public OgretmenDal(SKSDbContext context)
                    {
                              _context = context;
                    }

                    public Ogretmen GetOgretmenByKullaniciId(int kullaniciId)
                    {
                              try
                              {
                                        var result = _context.Ogretmens.Where(x => x.KullaniciId == kullaniciId).FirstOrDefault()!;
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Add(Ogretmen entity)
                    {
                              try
                              {
                                        _context.Ogretmens.Add(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Delete(Ogretmen entity)
                    {
                              try
                              {
                                        _context.Ogretmens.Remove(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public Ogretmen GetOgretmenByOgretmenNo(string numara)
                    {
                              try
                              {
                                        var result = _context.Ogretmens.Where(x => x.OgretmenNo == numara).FirstOrDefault()!;
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public Ogretmen GetOgretmenByEmail(string email)
                    {
                              try
                              {
                                        var result = _context.Ogretmens.Where(x => x.Email == email).FirstOrDefault()!;
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public IEnumerable<Ogretmen> GetAll()
                    {
                              try
                              {
                                        return _context.Ogretmens.AsEnumerable();
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public Ogretmen GetById(int id)
                    {
                              try
                              {
                                        var result = _context.Ogretmens.Where(x => x.Id == id).FirstOrDefault()!;
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Update(Ogretmen entity)
                    {
                              try
                              {
                                        _context.Ogretmens.Update(entity);
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