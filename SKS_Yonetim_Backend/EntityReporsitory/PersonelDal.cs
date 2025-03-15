using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
          public class PersonelDal : IPersonelDal
          {
                    private readonly SKSDbContext _context;
                    public PersonelDal(SKSDbContext context)
                    {
                              _context = context;
                    }

                    public Personel GetPersonelByKullaniciId(int kullaniciId)
                    {
                              try
                              {
                                        var result = _context.Personel.Where(x => x.KullaniciId == kullaniciId).FirstOrDefault()!;
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Add(Personel entity)
                    {
                              try
                              {
                                        _context.Personel.Add(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Delete(Personel entity)
                    {
                              try
                              {
                                        _context.Personel.Remove(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public Personel GetById(int id)
                    {
                              try
                              {
                                        var result = _context.Personel.Find(id)!;
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public IEnumerable<Personel> GetAll()
                    {
                              try
                              {
                                        var result = _context.Personel.ToList();
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Update(Personel entity)
                    {
                              try
                              {
                                        _context.Personel.Update(entity);
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