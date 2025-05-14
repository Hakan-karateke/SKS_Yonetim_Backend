using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
    public class UnvanDal(SKSDbContext context) : IUnvanDal
    {
        private readonly SKSDbContext _context = context;

        public IEnumerable<Unvan> GetList(Expression<Func<Unvan, bool>> filter)
        {
            try
            {
                var result = _context.Unvan.Where(filter);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }

        }

        public Unvan Get(Expression<Func<Unvan, bool>> filter)
        {
            try
            {
                var result = _context.Unvan.Where(filter).AsNoTracking().SingleOrDefault();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public IQueryable<Unvan> ListQueryable()
        {
            try
            {
                var result = _context.Unvan.AsNoTracking();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public bool Add(Unvan entity)
        {
            try
            {
                _context.Unvan.Add(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yetkilendirme eklenirken hata oluştu", ex);
            }
        }

        public bool Delete(Unvan entity)
        {
            try
            {
                _context.Unvan.Remove(entity);
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
                var entity = _context.Unvan.Find(id);
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

        public IEnumerable<Unvan> GetAll()
        {
            try
            {
                return [.. _context.Unvan];
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu yetkilendirmeler listelenirken hata oluştu", ex);
            }
        }

        public Unvan GetById(int id)
        {
            try
            {
                var result = _context.Unvan.Find(id);
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

        public bool Update(Unvan entity)
        {
            try
            {
                _context.Unvan.Update(entity);
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