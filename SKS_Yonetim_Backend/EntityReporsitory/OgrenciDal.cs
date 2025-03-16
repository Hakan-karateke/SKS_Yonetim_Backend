using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
          public class OgrenciDal : IOgrenciDal
          {
                    private readonly SKSDbContext _context;

                    public OgrenciDal(SKSDbContext context)
                    {
                              _context = context;
                    }

                    public Ogrenci GetOgrenciByKullaniciId(int kullaniciId)
                    {
                              try
                              {
                                        var result = _context.Ogrenci.Where(x => x.KullaniciId == kullaniciId).FirstOrDefault()!;
                                        return result;
                              }
                              catch (Exception ex )
                              {
                                        throw new Exception("Entity Katmanında Hata",ex);
                              }
                    }

                    public Ogrenci GetOgrenciByOgrenciNo(string numara)
                    {
                              try
                              {
                                        var result = _context.Ogrenci.Where(x => x.OgrenciNo == numara).FirstOrDefault()!;
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Add(Ogrenci entity)
                    {
                              try
                              {
                                        _context.Ogrenci.Add(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Delete(Ogrenci entity)
                    {
                              try
                              {
                                        _context.Ogrenci.Remove(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Delete(int id)
                    {
                              try
                              {
                                        var entity = GetById(id);
                                        _context.Ogrenci.Remove(entity);
                                        int affectedRows = _context.SaveChanges(); // Etkilenen satır sayısını al
                                        return affectedRows > 0; // Satır sayısı 0'dan büyükse işlem başarılıdır
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public IEnumerable<Ogrenci> GetAll()
                    {
                              try
                              {
                                        return _context.Ogrenci.AsEnumerable();
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public Ogrenci GetById(int id)
                    {
                              try
                              {
                                        return _context.Ogrenci.Find(id)!;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public bool Update(Ogrenci entity)
                    {
                              try
                              {
                                        _context.Ogrenci.Update(entity);
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