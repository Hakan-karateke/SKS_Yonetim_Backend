using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
    public class RandevuGrupDal(SKSDbContext context) : IRandevuGrupDal
    {
        private readonly SKSDbContext _context = context;

        public IEnumerable<RandevuGrup> GetList(Expression<Func<RandevuGrup, bool>> filter)
        {
            try
            {
                var result = _context.RandevuGrup.Where(filter);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }

        }

        public RandevuGrup Get(Expression<Func<RandevuGrup, bool>> filter)
        {
            try
            {
                var result = _context.RandevuGrup.Where(filter).AsNoTracking().SingleOrDefault();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public IQueryable<RandevuGrup> ListQueryable()
        {
            try
            {
                var result = _context.RandevuGrup.AsNoTracking();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public bool Add(RandevuGrup entity)
        {
            try
            {
                _context.RandevuGrup.Add(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yetkilendirme eklenirken hata oluştu", ex);
            }
        }

        public bool Delete(RandevuGrup entity)
        {
            try
            {
                _context.RandevuGrup.Remove(entity);
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
                var entity = _context.RandevuGrup.Find(id);
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

        public IEnumerable<RandevuGrup> GetAll()
        {
            try
            {
                return [.. _context.RandevuGrup];
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yetkilendirmeler listelenirken hata oluştu", ex);
            }
        }

        public RandevuGrup GetById(int id)
        {
            try
            {
                var result = _context.RandevuGrup.Find(id);
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

        public bool Update(RandevuGrup entity)
        {
            try
            {
                _context.RandevuGrup.Update(entity);
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