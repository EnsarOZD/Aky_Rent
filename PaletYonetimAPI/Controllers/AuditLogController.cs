using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;

namespace PaletYonetimAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuditLogs(
            [FromQuery] string entityName = null,
            [FromQuery] int? entityId = null,
            [FromQuery] string userId = null,
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            var auditLogs = await _auditLogService.GetAuditLogsAsync(
                entityName, entityId, userId, fromDate, toDate);

            return Ok(auditLogs);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserAuditLogs(
            string userId,
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            var auditLogs = await _auditLogService.GetUserAuditLogsAsync(userId, fromDate, toDate);
            return Ok(auditLogs);
        }

        [HttpGet("entity/{entityName}/{entityId}")]
        public async Task<IActionResult> GetEntityAuditLogs(string entityName, int entityId)
        {
            var auditLogs = await _auditLogService.GetEntityAuditLogsAsync(entityName, entityId);
            return Ok(auditLogs);
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetAuditSummary(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            var auditLogs = await _auditLogService.GetAuditLogsAsync(
                fromDate: fromDate, toDate: toDate);

            var summary = new
            {
                TotalLogs = auditLogs.Count,
                SuccessfulLogs = auditLogs.Count(l => l.IsSuccessful),
                FailedLogs = auditLogs.Count(l => !l.IsSuccessful),
                TopUsers = auditLogs.GroupBy(l => l.UserName)
                    .Select(g => new { UserName = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .Take(10),
                TopEntities = auditLogs.GroupBy(l => l.EntityName)
                    .Select(g => new { EntityName = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .Take(10),
                TopActions = auditLogs.GroupBy(l => l.Action)
                    .Select(g => new { Action = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .Take(10)
            };

            return Ok(summary);
        }
    }
} 