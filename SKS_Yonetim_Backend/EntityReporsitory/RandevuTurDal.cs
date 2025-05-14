using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
          public class RandevuTurDal(SKSDbContext context) : IRandevuTurDal
          {
                    private readonly SKSDbContext _context = context;

                    public IEnumerable<RandevuTur> GetList(Expression<Func<RandevuTur, bool>> filter)
                    {
                              try
                              {
                                        var result = _context.RandevuTur.Where(filter);
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }

                    }

                    public RandevuTur Get(Expression<Func<RandevuTur, bool>> filter)
                    {
                              try
                              {
                                        var result = _context.RandevuTur.Where(filter).AsNoTracking().SingleOrDefault();
                                        return result!;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public IQueryable<RandevuTur> ListQueryable()
                    {
                              try
                              {
                                        var result = _context.RandevuTur.AsNoTracking();
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
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

                    public int GetRandevuTurCount()
                    {
                              try
                              {
                                        return _context.RandevuTur.Count();
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Randevu türü sayısı alınırken hata oluştu", ex);
                              }
                    }

                    public int GetRandevuTurCountByAktif(bool aktif)
                    {
                              try
                              {
                                        return _context.RandevuTur.Count(x => x.Aktif == aktif);
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Aktif randevu türü sayısı alınırken hata oluştu", ex);
                              }
                    }
          }
}