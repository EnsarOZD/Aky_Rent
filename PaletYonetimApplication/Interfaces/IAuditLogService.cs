using PaletYonetimDomain.Entities;

namespace PaletYonetimApplication.Interfaces
{
    public interface IAuditLogService
    {
        Task LogAsync(string action, string entityName, int entityId, string userId, string userName, 
            string oldValues = null, string newValues = null, string description = null, 
            bool isSuccessful = true, string errorMessage = null, CancellationToken cancellationToken = default);
        
        Task<List<AuditLogEntity>> GetAuditLogsAsync(string entityName = null, int? entityId = null, 
            string userId = null, DateTime? fromDate = null, DateTime? toDate = null, 
            CancellationToken cancellationToken = default);
        
        Task<List<AuditLogEntity>> GetUserAuditLogsAsync(string userId, DateTime? fromDate = null, 
            DateTime? toDate = null, CancellationToken cancellationToken = default);
        
        Task<List<AuditLogEntity>> GetEntityAuditLogsAsync(string entityName, int entityId, 
            CancellationToken cancellationToken = default);
    }
} 