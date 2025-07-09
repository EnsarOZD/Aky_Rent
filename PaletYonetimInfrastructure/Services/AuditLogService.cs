using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;

namespace PaletYonetimInfrastructure.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditLogService(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LogAsync(string action, string entityName, int entityId, string userId, string userName,
            string oldValues = null, string newValues = null, string description = null,
            bool isSuccessful = true, string errorMessage = null, CancellationToken cancellationToken = default)
        {
            var auditLog = new AuditLogEntity
            {
                Action = action,
                EntityName = entityName,
                EntityID = entityId,
                UserID = userId,
                UserName = userName,
                OldValues = oldValues,
                NewValues = newValues,
                Description = description,
                IsSuccessful = isSuccessful,
                ErrorMessage = errorMessage,
                IPAddress = GetClientIPAddress(),
                UserAgent = GetUserAgent()
            };

            _context.AuditLogs.Add(auditLog);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<AuditLogEntity>> GetAuditLogsAsync(string entityName = null, int? entityId = null,
            string userId = null, DateTime? fromDate = null, DateTime? toDate = null,
            CancellationToken cancellationToken = default)
        {
            var query = _context.AuditLogs.AsQueryable();

            if (!string.IsNullOrEmpty(entityName))
                query = query.Where(a => a.EntityName == entityName);

            if (entityId.HasValue)
                query = query.Where(a => a.EntityID == entityId.Value);

            if (!string.IsNullOrEmpty(userId))
                query = query.Where(a => a.UserID == userId);

            if (fromDate.HasValue)
                query = query.Where(a => a.CreatedTime >= fromDate.Value);

            if (toDate.HasValue)
                query = query.Where(a => a.CreatedTime <= toDate.Value);

            return await query
                .OrderByDescending(a => a.CreatedTime)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<AuditLogEntity>> GetUserAuditLogsAsync(string userId, DateTime? fromDate = null,
            DateTime? toDate = null, CancellationToken cancellationToken = default)
        {
            return await GetAuditLogsAsync(userId: userId, fromDate: fromDate, toDate: toDate, cancellationToken: cancellationToken);
        }

        public async Task<List<AuditLogEntity>> GetEntityAuditLogsAsync(string entityName, int entityId,
            CancellationToken cancellationToken = default)
        {
            return await GetAuditLogsAsync(entityName: entityName, entityId: entityId, cancellationToken: cancellationToken);
        }

        private string GetClientIPAddress()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null) return "Unknown";

            // X-Forwarded-For header'ı kontrol et (proxy arkasında)
            var forwardedHeader = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (!string.IsNullOrEmpty(forwardedHeader))
                return forwardedHeader.Split(',')[0].Trim();

            // Remote IP adresini al
            return httpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
        }

        private string GetUserAgent()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            return httpContext?.Request.Headers["User-Agent"].FirstOrDefault() ?? "Unknown";
        }
    }
} 