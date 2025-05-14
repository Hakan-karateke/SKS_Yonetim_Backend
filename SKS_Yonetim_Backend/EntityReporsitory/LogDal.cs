using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.EntityReporsitory
{
    public class LogDal(SKSDbContext context) : ILogDal
    {
        private readonly SKSDbContext _context = context;

        public IEnumerable<Log> GetList(Expression<Func<Log, bool>> filter)
        {
            try
            {
                var result = _context.Log.Where(filter);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }

        }

        public Log Get(Expression<Func<Log, bool>> filter)
        {
            try
            {
                var result = _context.Log.Where(filter).AsNoTracking().SingleOrDefault();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public IQueryable<Log> ListQueryable()
        {
            try
            {
                var result = _context.Log.AsNoTracking();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Entity Katmanında Hata", ex);
            }
        }

        public bool Add(Log entity)
        {
            try
            {
                _context.Log.Add(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                // Can't log this error because we're the logging system!
                Console.WriteLine($"Logging error: {ex.Message}");
                return false;
            }
        }

        public bool Delete(Log entity)
        {
            try
            {
                _context.Log.Remove(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting log: {ex.Message}");
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _context.Log.Find(id);
                if (entity != null)
                {
                    return Delete(entity);
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting log by ID: {ex.Message}");
                return false;
            }
        }

        public IEnumerable<Log> GetAll()
        {
            try
            {
                return [.. _context.Log];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all logs: {ex.Message}");
                return Enumerable.Empty<Log>();
            }
        }

        public List<Log> GetAllLogsByPageSizeByTakeSize(int pageSize, int takeSize)
        {
            try
            {
                return _context.Log
                    .OrderByDescending(l => l.Logged)
                    .Skip(pageSize)
                    .Take(takeSize)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving paginated logs: {ex.Message}");
                return new List<Log>();
            }
        }

        public Log GetById(int id)
        {
            try
            {
                var result = _context.Log.Find(id);
                if (result == null)
                {
                    throw new Exception("Log bulunamadı");
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving log by ID: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Log> GetLogsByAction(string actionName)
        {
            try
            {
                return _context.Log
                    .Where(l => l.ActionName == actionName)
                    .OrderByDescending(l => l.Logged)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving logs by action: {ex.Message}");
                return Enumerable.Empty<Log>();
            }
        }

        public IEnumerable<Log> GetLogsByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                return _context.Log
                    .Where(l => l.Logged >= startDate && l.Logged <= endDate)
                    .OrderByDescending(l => l.Logged)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving logs by date range: {ex.Message}");
                return Enumerable.Empty<Log>();
            }
        }

        public IEnumerable<Log> GetLogsByEntity(string entityName, int? entityId = null)
        {
            try
            {
                var query = _context.Log.Where(l => l.EntityName == entityName);

                if (entityId.HasValue)
                {
                    query = query.Where(l => l.EntityId == entityId.Value);
                }

                return query.OrderByDescending(l => l.Logged).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving logs by entity: {ex.Message}");
                return Enumerable.Empty<Log>();
            }
        }

        public IEnumerable<Log> GetLogsByLevel(string level)
        {
            try
            {
                return _context.Log
                    .Where(l => l.Level == level)
                    .OrderByDescending(l => l.Logged)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving logs by level: {ex.Message}");
                return Enumerable.Empty<Log>();
            }
        }

        public IEnumerable<Log> GetLogsByType(string logType)
        {
            try
            {
                return _context.Log
                    .Where(l => l.LogType == logType)
                    .OrderByDescending(l => l.Logged)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving logs by type: {ex.Message}");
                return Enumerable.Empty<Log>();
            }
        }

        public IEnumerable<Log> GetLogsByUser(int userId)
        {
            try
            {
                return _context.Log
                    .Where(l => l.UserId == userId)
                    .OrderByDescending(l => l.Logged)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving logs by user: {ex.Message}");
                return Enumerable.Empty<Log>();
            }
        }

        public bool LogError(string message, Exception exception, int? userId = null, string? username = null, string? requestInfo = null)
        {
            try
            {
                var log = new Log
                {
                    Message = message,
                    Exception = exception?.ToString(),
                    Level = "Error",
                    LogType = "Error",
                    UserId = userId,
                    Username = username,
                    RequestInfo = requestInfo,
                    Logged = DateTime.Now,
                    MachineName = Environment.MachineName,
                    IsSuccess = false
                };

                return Add(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while logging error: {ex.Message}");
                return false;
            }
        }

        public bool LogSecurityEvent(int? userId, string username, string action, bool isSuccess, string ipAddress, string message)
        {
            try
            {
                var log = new Log
                {
                    UserId = userId,
                    Username = username,
                    ActionName = action,
                    LogType = "Security",
                    Level = isSuccess ? "Info" : "Warning",
                    IPAddress = ipAddress,
                    Message = message,
                    Logged = DateTime.Now,
                    MachineName = Environment.MachineName,
                    IsSuccess = isSuccess
                };

                return Add(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while logging security event: {ex.Message}");
                return false;
            }
        }

        public bool LogSystemAction(string action, string entity, int? entityId, bool isSuccess, string message)
        {
            try
            {
                var log = new Log
                {
                    ActionName = action,
                    EntityName = entity,
                    EntityId = entityId,
                    LogType = "SystemAction",
                    Level = isSuccess ? "Info" : "Warning",
                    Message = message,
                    Logged = DateTime.Now,
                    MachineName = Environment.MachineName,
                    IsSuccess = isSuccess
                };

                return Add(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while logging system action: {ex.Message}");
                return false;
            }
        }

        public bool LogUserAction(int userId, string username, string action, string entity, int? entityId, bool isSuccess, string message, string? ipAddress = null)
        {
            try
            {
                var log = new Log
                {
                    UserId = userId,
                    Username = username,
                    ActionName = action,
                    EntityName = entity,
                    EntityId = entityId,
                    LogType = "UserAction",
                    Level = isSuccess ? "Info" : "Warning",
                    IPAddress = ipAddress,
                    Message = message,
                    Logged = DateTime.Now,
                    MachineName = Environment.MachineName,
                    IsSuccess = isSuccess
                };

                return Add(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while logging user action: {ex.Message}");
                return false;
            }
        }

        public bool Update(Log entity)
        {
            try
            {
                _context.Log.Update(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating log: {ex.Message}");
                return false;
            }
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}