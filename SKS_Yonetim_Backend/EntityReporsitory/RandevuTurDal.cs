using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
          public class RandevuTurDal : IRandevuTurDal
          {
                    private readonly SKSDbContext _context;
                    public RandevuTurDal(SKSDbContext context)
                    {
                              _context = context;
                    }

                    public bool Add(RandevuTur entity)
                    {
                              try
                              {
                                        _context.RandevuTur.Add(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Delete(RandevuTur entity)
                    {
                              try
                              {
                                        _context.RandevuTur.Remove(entity);
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
                                        var entity = _context.RandevuTur.Find(Id);
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

                    public RandevuTur GetById(int Id)
                    {
                              try
                              {
                                        var result = _context.RandevuTur.Where(x => x.Id == Id).FirstOrDefault()!;
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public IEnumerable<RandevuTur> GetAll()
                    {
                              try
                              {
                                        var result = _context.RandevuTur.ToList();
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Update(RandevuTur entity)
                    {
                              try
                              {
                                        _context.RandevuTur.Update(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
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