using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
    public class RandevuAlinmayacakSaatDal(SKSDbContext context) : IRandevuAlinmayacakSaatDal
    {
        private readonly SKSDbContext _context = context;

        public IEnumerable<RandevuAlinmayacakSaat> GetList(Expression<Func<RandevuAlinmayacakSaat, bool>> filter)
        {
            try
            {
                var result = _context.RandevuAlinmayacakSaat.Where(filter);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }

        }

        public RandevuAlinmayacakSaat Get(Expression<Func<RandevuAlinmayacakSaat, bool>> filter)
        {
            try
            {
                var result = _context.RandevuAlinmayacakSaat.Where(filter).AsNoTracking().SingleOrDefault();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public IQueryable<RandevuAlinmayacakSaat> ListQueryable()
        {
            try
            {
                var result = _context.RandevuAlinmayacakSaat.AsNoTracking();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public bool Add(RandevuAlinmayacakSaat entity)
        {
            try
            {
                _context.RandevuAlinmayacakSaat.Add(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu alınmayacak saat eklenirken hata oluştu", ex);
            }
        }

        public bool Delete(RandevuAlinmayacakSaat entity)
        {
            try
            {
                _context.RandevuAlinmayacakSaat.Remove(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu alınmayacak saat silinirken hata oluştu", ex);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _context.RandevuAlinmayacakSaat.Find(id);
                if (entity != null)
                {
                    return Delete(entity);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu alınmayacak saat silinirken hata oluştu", ex);
            }
        }

        public IEnumerable<RandevuAlinmayacakSaat> GetAll()
        {
            try
            {
                return [.. _context.RandevuAlinmayacakSaat];
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu alınmayacak saatler listelenirken hata oluştu", ex);
            }
        }

        public RandevuAlinmayacakSaat GetById(int id)
        {
            try
            {
                var result = _context.RandevuAlinmayacakSaat.Find(id) ?? throw new Exception("Randevu alınmayacak saat bulunamadı");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu alınmayacak saat bulunurken hata oluştu", ex);
            }
        }

        public bool Update(RandevuAlinmayacakSaat entity)
        {
            try
            {
                _context.RandevuAlinmayacakSaat.Update(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Randevu alınmayacak saat güncellenirken hata oluştu", ex);
            }
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}