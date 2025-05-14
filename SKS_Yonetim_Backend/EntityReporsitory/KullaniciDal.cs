using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
          public class KullaniciDal(SKSDbContext context) : IKullaniciDal
          {
                    private readonly SKSDbContext _context = context;

                    public IEnumerable<Kullanici> GetList(Expression<Func<Kullanici, bool>> filter)
                    {
                              try
                              {
                                        var result = _context.Kullanici.Where(filter);
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }

                    }

                    public Kullanici Get(Expression<Func<Kullanici, bool>> filter)
                    {
                              try
                              {
                                        var result = _context.Kullanici.Where(filter).AsNoTracking().SingleOrDefault();
                                        return result!;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public IQueryable<Kullanici> ListQueryable()
                    {
                              try
                              {
                                        var result = _context.Kullanici.AsNoTracking();
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public Kullanici GetKullaniciByEmail(string email)
                    {
                              try
                              {
                                        var result = _context.Kullanici.Where(x => x.Email == email).FirstOrDefault()!;
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
                                        var result = _context.Kullanici.Where(x => x.Email == email && x.Sifre == sifre && x.Onay == IslemTip.Onaylandi.GetHashCode()).FirstOrDefault()!;
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public List<Kullanici> GetKullaniciByRol(int rol)
                    {
                              try
                              {
                                        var result = _context.Kullanici.Where(x => x.Rol == rol).ToList();
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public List<Kullanici> GetKullaniciByRolAndOnay(int rol, int Onay)
                    {
                              try
                              {
                                        var result = _context.Kullanici.Where(x => x.Rol == rol && x.Onay == Onay).ToList();
                                        return result;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Entity Katmanında Hata", ex);
                              }
                    }

                    public List<Kullanici> GetKullaniciByOnay(int Onay)
                    {
                              try
                              {
                                        var result = _context.Kullanici.Where(x => x.Onay == Onay).ToList();
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
                                        _context.Kullanici.Add(entity);
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
                                        _context.Kullanici.Remove(entity);
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
                                        _context.Kullanici.Remove(entity);
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
                                        var result = _context.Kullanici.ToList();
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
                                        var result = _context.Kullanici.Find(id)!;
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
                                        _context.Kullanici.Update(entity);
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