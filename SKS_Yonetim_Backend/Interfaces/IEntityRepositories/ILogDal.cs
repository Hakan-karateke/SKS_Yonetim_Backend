using Microsoft.EntityFrameworkCore.Storage;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Interfaces.IEntityRepositories
{
    public interface ILogDal : IEntityRepository<Log>
    {
        // Get logs by various parameters
        IEnumerable<Log> GetLogsByLevel(string level);
        IEnumerable<Log> GetLogsByType(string logType);
        IEnumerable<Log> GetLogsByUser(int userId);
        IEnumerable<Log> GetLogsByDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<Log> GetLogsByAction(string actionName);
        IEnumerable<Log> GetLogsByEntity(string entityName, int? entityId = null);

        // Pagination support
        List<Log> GetAllLogsByPageSizeByTakeSize(int pageSize, int takeSize);

        // Quick logging methods for common scenarios
        bool LogUserAction(int userId, string username, string action, string entity, int? entityId, bool isSuccess, string message, string? ipAddress = null);
        bool LogError(string message, Exception exception, int? userId = null, string? username = null, string? requestInfo = null);
        bool LogSecurityEvent(int? userId, string username, string action, bool isSuccess, string ipAddress, string message);
        bool LogSystemAction(string action, string entity, int? entityId, bool isSuccess, string message);
    }
}