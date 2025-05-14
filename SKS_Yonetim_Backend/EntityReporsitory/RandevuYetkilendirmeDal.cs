using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
    public class RandevuYetkilendirmeDal(SKSDbContext context) : IRandevuYetkilendirmeDal
    {
        private readonly SKSDbContext _context = context;

        public IEnumerable<RandevuYetkilendirme> GetList(Expression<Func<RandevuYetkilendirme, bool>> filter)
        {
            try
            {
                var result = _context.RandevuYetkilendirme.Where(filter);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }

        }

        public RandevuYetkilendirme Get(Expression<Func<RandevuYetkilendirme, bool>> filter)
        {
            try
            {
                var result = _context.RandevuYetkilendirme.Where(filter).AsNoTracking().SingleOrDefault();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public IQueryable<RandevuYetkilendirme> ListQueryable()
        {
            try
            {
                var result = _context.RandevuYetkilendirme.AsNoTracking();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public bool Add(RandevuYetkilendirme entity)
        {
            try
            {
                _context.RandevuYetkilendirme.Add(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yetkilendirme eklenirken hata oluştu", ex);
            }
        }

        public bool Delete(RandevuYetkilendirme entity)
        {
            try
            {
                _context.RandevuYetkilendirme.Remove(entity);
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
                var entity = _context.RandevuYetkilendirme.Find(id);
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

        public IEnumerable<RandevuYetkilendirme> GetAll()
        {
            try
            {
                return [.. _context.RandevuYetkilendirme];
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yetkilendirmeler listelenirken hata oluştu", ex);
            }
        }

        public RandevuYetkilendirme GetById(int id)
        {
            try
            {
                var result = _context.RandevuYetkilendirme.Find(id);
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

        public bool Update(RandevuYetkilendirme entity)
        {
            try
            {
                _context.RandevuYetkilendirme.Update(entity);
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