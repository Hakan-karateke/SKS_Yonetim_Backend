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
    public class RandevumDal(SKSDbContext context) : IRandevumDal
    {
        private readonly SKSDbContext _context = context;

        public IEnumerable<Randevum> GetList(Expression<Func<Randevum, bool>> filter)
        {
            try
            {
                var result = _context.Randevum.Where(filter);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }

        }

        public Randevum Get(Expression<Func<Randevum, bool>> filter)
        {
            try
            {
                var result = _context.Randevum.Where(filter).AsNoTracking().SingleOrDefault();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public IQueryable<Randevum> ListQueryable()
        {
            try
            {
                var result = _context.Randevum.AsNoTracking();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }
        public int GetAllRandevumCount()
        {
            try
            {
                return _context.Randevum.Count();
            }
            catch (Exception ex)
            {
                throw new Exception("Entity katmaninda hata", ex);
            }
        }
        public bool Add(Randevum entity)
        {
            try
            {
                _context.Randevum.Add(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu eklenirken hata oluştu", ex);
            }
        }

        public bool Delete(Randevum entity)
        {
            try
            {
                _context.Randevum.Remove(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu silinirken hata oluştu", ex);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _context.Randevum.Find(id);
                if (entity != null)
                {
                    return Delete(entity);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu silinirken hata oluştu", ex);
            }
        }

        public IEnumerable<Randevum> GetAll()
        {
            try
            {
                return [.. _context.Randevum];
            }
            catch (Exception ex)
            {
                throw new Exception("Randevular listelenirken hata oluştu", ex);
            }
        }

        public async Task<List<Randevum>> GetAllRandevularByPageSize(int pageSize)
        {
            try
            {
                return await _context.Randevum
                    .Skip((pageSize - 1) * 10)
                    .Take(10)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Randevular sayfalanırken hata oluştu", ex);
            }
        }

        public int GetAllRandevuCount()
        {
            try
            {
                return _context.Randevum.Count();
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu sayısı hesaplanırken hata oluştu", ex);
            }
        }

        public Randevum GetById(int id)
        {
            try
            {
                var result = _context.Randevum.Find(id);
                if (result == null)
                {
                    throw new Exception("Randevu bulunamadı");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu bulunurken hata oluştu", ex);
            }
        }

        public async Task<List<Randevum>> GetRandevularByDate(DateTime date)
        {
            try
            {
                return await _context.Randevum
                    .Where(r => r.RandevuTarihi.Date == date.Date)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Tarihe göre randevular listelenirken hata oluştu", ex);
            }
        }

        public async Task<List<Randevum>> GetRandevularByDateAndUserId(DateTime date, int userId)
        {
            try
            {
                return await _context.Randevum
                    .Where(r => r.RandevuTarihi.Date == date.Date && r.KullaniciID == userId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Tarihe ve kullanıcıya göre randevular listelenirken hata oluştu", ex);
            }
        }

        public int GetRandevuCountByDate(DateTime date)
        {
            try
            {
                return _context.Randevum.Count(r => r.RandevuTarihi.Date == date.Date);
            }
            catch (Exception ex)
            {
                throw new Exception("Tarihe göre randevu sayısı hesaplanırken hata oluştu", ex);
            }
        }

        public int GetRandevuCountByOnaylandiMi(bool onaylandiMi)
        {
            try
            {
                return _context.Randevum.Count(r => r.OnaylandiMi == onaylandiMi);
            }
            catch (Exception ex)
            {
                throw new Exception("Entity katmaninda hata", ex);
            }
        }

        public int GetRandevuCountByUserId(int userId)
        {
            try
            {
                return _context.Randevum.Count(r => r.KullaniciID == userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcıya göre randevu sayısı hesaplanırken hata oluştu", ex);
            }
        }

        public async Task<List<Randevum>> GetRandevularByKullaniciIdAndPageSize(int kullaniciId, int page)
        {
            try
            {
                return await _context.Randevum
                    .Where(r => r.KullaniciID == kullaniciId)
                    .Skip((page - 1) * 20)
                    .Take(20)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcıya göre randevular listelenirken hata oluştu", ex);
            }
        }

        public bool Update(Randevum entity)
        {
            try
            {
                _context.Randevum.Update(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu güncellenirken hata oluştu", ex);
            }
        }
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}