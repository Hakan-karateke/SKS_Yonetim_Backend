using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
          public class RandevuDal : IRandevuDal
          {
                    private readonly SKSDbContext _context;
                    public RandevuDal(SKSDbContext context)
                    {
                              _context = context;
                    }

                    public bool Add(Randevu entity)
                    {
                              try
                              {
                                        _context.Randevu.Add(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Update(Randevu entity)
                    {
                              try
                              {
                                        _context.Randevu.Update(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Delete(Randevu entity)
                    {
                              try
                              {
                                        _context.Randevu.Remove(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Delete(int Id)
                    {
                              try
                              {
                                        var entity = _context.Randevu.Find(Id);
                                        if (entity != null)
                                        {
                                                  return Delete(entity);
                                        }
                                        return false;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }
                    public Randevu GetById(int Id)
                    {
                              try
                              {
                                        var result = _context.Randevu.Where(x => x.Id == Id).FirstOrDefault()!;
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }
          
                    public IEnumerable<Randevu> GetAll()
                    {
                              try
                              {
                                        var result = _context.Randevu.ToList();
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public IDbContextTransaction BeginTransaction()
                    {
                              return _context.Database.BeginTransaction();
                    }
          }
}