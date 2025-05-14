using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
          public class RandevuDal(SKSDbContext context) : IRandevuDal
          {
                    private readonly SKSDbContext _context = context;

                    public IEnumerable<Randevu> GetList(Expression<Func<Randevu, bool>> filter)
                    {
                              try
                              {
                                        var result = _context.Randevu.Where(filter);
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }

                    }

                    public Randevu Get(Expression<Func<Randevu, bool>> filter)
                    {
                              try
                              {
                                        var result = _context.Randevu.Where(filter).AsNoTracking().SingleOrDefault();
                                        return result!;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public IQueryable<Randevu> ListQueryable()
                    {
                              try
                              {
                                        var result = _context.Randevu.AsNoTracking();
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
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

                    public int GetAllRandevuCount()
                    {
                              try
                              {
                                        var result = _context.Randevu.Count();
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public int GetRandevuCountByKullaniciId(int kullaniciId)
                    {
                              try
                              {
                                        var result = _context.Randevu.Count(x => x.KullaniciId == kullaniciId);
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }
          }
}