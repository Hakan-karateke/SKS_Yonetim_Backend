using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
    public class RandevuYeriDal(SKSDbContext context) : IRandevuYeriDal
    {
        private readonly SKSDbContext _context = context;

        public IEnumerable<RandevuYeri> GetList(Expression<Func<RandevuYeri, bool>> filter)
        {
            try
            {
                var result = _context.RandevuYeri.Where(filter);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }

        }

        public RandevuYeri Get(Expression<Func<RandevuYeri, bool>> filter)
        {
            try
            {
                var result = _context.RandevuYeri.Where(filter).AsNoTracking().SingleOrDefault();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public IQueryable<RandevuYeri> ListQueryable()
        {
            try
            {
                var result = _context.RandevuYeri.AsNoTracking();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public bool Add(RandevuYeri entity)
        {
            try
            {
                _context.RandevuYeri.Add(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yetkilendirme eklenirken hata oluştu", ex);
            }
        }

        public bool Delete(RandevuYeri entity)
        {
            try
            {
                _context.RandevuYeri.Remove(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yetkilendirme silinirken hata oluştu", ex);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _context.RandevuYeri.Find(id);
                if (entity != null)
                {
                    return Delete(entity);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yetkilendirme silinirken hata oluştu", ex);
            }
        }

        public IEnumerable<RandevuYeri> GetAll()
        {
            try
            {
                return [.. _context.RandevuYeri];
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yetkilendirmeler listelenirken hata oluştu", ex);
            }
        }

        public RandevuYeri GetById(int id)
        {
            try
            {
                var result = _context.RandevuYeri.Find(id);
                if (result == null)
                {
                    throw new Exception("Randevu yetkilendirme bulunamadı");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yetkilendirme bulunurken hata oluştu", ex);
            }
        }

        public bool Update(RandevuYeri entity)
        {
            try
            {
                _context.RandevuYeri.Update(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yetkilendirme güncellenirken hata oluştu", ex);
            }
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}