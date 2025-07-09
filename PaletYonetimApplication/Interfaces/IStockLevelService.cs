using PaletYonetimApplication.DTO;

namespace PaletYonetimApplication.Interfaces
{
    public interface IStockLevelService
    {
        Task<int> GetCurrentStockLevelAsync(int productID, CancellationToken cancellationToken = default);
        Task<bool> IsLowStockAsync(int productID, CancellationToken cancellationToken = default);
        Task<bool> IsOverStockAsync(int productID, CancellationToken cancellationToken = default);
        Task<List<ProductDto>> GetLowStockProductsAsync(CancellationToken cancellationToken = default);
        Task<List<ProductDto>> GetOverStockProductsAsync(CancellationToken cancellationToken = default);
        Task<List<ProductDto>> GetProductsNeedingReorderAsync(CancellationToken cancellationToken = default);
        Task<StockLevelReportDto> GetStockLevelReportAsync(CancellationToken cancellationToken = default);
    }

    public class StockLevelReportDto
    {
        public int TotalProducts { get; set; }
        public int LowStockProducts { get; set; }
        public int OverStockProducts { get; set; }
        public int ProductsNeedingReorder { get; set; }
        public decimal TotalStockValue { get; set; }
        public List<ProductDto> CriticalProducts { get; set; } = new();
    }
} 