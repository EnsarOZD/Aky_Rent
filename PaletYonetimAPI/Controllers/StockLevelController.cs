using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockLevelController : ControllerBase
    {
        private readonly IStockLevelService _stockLevelService;

        public StockLevelController(IStockLevelService stockLevelService)
        {
            _stockLevelService = stockLevelService;
        }

        [HttpGet("current/{productId}")]
        public async Task<IActionResult> GetCurrentStockLevel(int productId)
        {
            var currentStock = await _stockLevelService.GetCurrentStockLevelAsync(productId);
            return Ok(new { ProductId = productId, CurrentStock = currentStock });
        }

        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStockProducts()
        {
            var lowStockProducts = await _stockLevelService.GetLowStockProductsAsync();
            return Ok(lowStockProducts);
        }

        [HttpGet("over-stock")]
        public async Task<IActionResult> GetOverStockProducts()
        {
            var overStockProducts = await _stockLevelService.GetOverStockProductsAsync();
            return Ok(overStockProducts);
        }

        [HttpGet("reorder")]
        public async Task<IActionResult> GetProductsNeedingReorder()
        {
            var reorderProducts = await _stockLevelService.GetProductsNeedingReorderAsync();
            return Ok(reorderProducts);
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetStockLevelReport()
        {
            var report = await _stockLevelService.GetStockLevelReportAsync();
            return Ok(report);
        }

        [HttpGet("check/{productId}")]
        public async Task<IActionResult> CheckStockLevel(int productId)
        {
            var currentStock = await _stockLevelService.GetCurrentStockLevelAsync(productId);
            var isLowStock = await _stockLevelService.IsLowStockAsync(productId);
            var isOverStock = await _stockLevelService.IsOverStockAsync(productId);

            return Ok(new
            {
                ProductId = productId,
                CurrentStock = currentStock,
                IsLowStock = isLowStock,
                IsOverStock = isOverStock
            });
        }
    }
} 