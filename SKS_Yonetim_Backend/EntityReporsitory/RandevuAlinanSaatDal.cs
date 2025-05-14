using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
    public class RandevuAlinanSaatDal(SKSDbContext context) : IRandevuAlinanSaatDal
    {
        private readonly SKSDbContext _context = context;

        public IEnumerable<RandevuAlinanSaat> GetList(Expression<Func<RandevuAlinanSaat, bool>> filter)
        {
            try
            {
                var result = _context.RandevuAlinanSaat.Where(filter);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }

        }

        public RandevuAlinanSaat Get(Expression<Func<RandevuAlinanSaat, bool>> filter)
        {
            try
            {
                var result = _context.RandevuAlinanSaat.Where(filter).AsNoTracking().SingleOrDefault();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public IQueryable<RandevuAlinanSaat> ListQueryable()
        {
            try
            {
                var result = _context.RandevuAlinanSaat.AsNoTracking();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public bool Add(RandevuAlinanSaat entity)
        {
            try
            {
                _context.RandevuAlinanSaat.Add(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu alınan saat eklenirken hata oluştu", ex);
            }
        }

        public bool Delete(RandevuAlinanSaat entity)
        {
            try
            {
                _context.RandevuAlinanSaat.Remove(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu alınan saat silinirken hata oluştu", ex);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _context.RandevuAlinanSaat.Find(id);
                if (entity != null)
                {
                    return Delete(entity);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu alınan saat silinirken hata oluştu", ex);
            }
        }

        public IEnumerable<RandevuAlinanSaat> GetAll()
        {
            try
            {
                return [.. _context.RandevuAlinanSaat];
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu alınan saatler listelenirken hata oluştu", ex);
            }
        }

        public RandevuAlinanSaat GetById(int id)
        {
            try
            {
                var result = _context.RandevuAlinanSaat.Find(id) ?? throw new Exception("Randevu alınan saat bulunamadı");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu alınan saat bulunurken hata oluştu", ex);
            }
        }

        public bool Update(RandevuAlinanSaat entity)
        {
            try
            {
                _context.RandevuAlinanSaat.Update(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu alınan saat güncellenirken hata oluştu", ex);
            }
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}