using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Enums;

namespace PaletYonetimInfrastructure.Services
{
    public class StockLevelService : IStockLevelService
    {
        private readonly IApplicationDbContext _context;

        public StockLevelService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetCurrentStockLevelAsync(int productID, CancellationToken cancellationToken = default)
        {
            var stockMovements = await _context.StockMovements
                .Where(sm => sm.ProductID == productID)
                .ToListAsync(cancellationToken);

            var currentStock = stockMovements.Sum(sm => sm.Quantity);
            return currentStock;
        }

        public async Task<bool> IsLowStockAsync(int productID, CancellationToken cancellationToken = default)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductID == productID, cancellationToken);

            if (product == null) return false;

            var currentStock = await GetCurrentStockLevelAsync(productID, cancellationToken);
            var minStock = product.MinimumStockLevel ?? 0;
            return currentStock <= minStock;
        }

        public async Task<bool> IsOverStockAsync(int productID, CancellationToken cancellationToken = default)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductID == productID, cancellationToken);

            if (product == null) return false;

            var currentStock = await GetCurrentStockLevelAsync(productID, cancellationToken);
            var maxStock = product.MaximumStockLevel ?? int.MaxValue;
            return currentStock >= maxStock;
        }

        public async Task<List<ProductDto>> GetLowStockProductsAsync(CancellationToken cancellationToken = default)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .ToListAsync(cancellationToken);

            var lowStockProducts = new List<ProductDto>();

            foreach (var product in products)
            {
                var currentStock = await GetCurrentStockLevelAsync(product.ProductID, cancellationToken);
                
                var minStock = product.MinimumStockLevel ?? 0;
                if (currentStock <= minStock)
                {
                    lowStockProducts.Add(new ProductDto
                    {
                        ProductID = product.ProductID,
                        Name = product.Name,
                        SKU = product.SKU,
                        CategoryName = product.Category?.CategoryName,
                        CurrentStock = currentStock,
                        MinimumStockLevel = minStock,
                        MaximumStockLevel = product.MaximumStockLevel ?? 0,
                        IsLowStock = true,
                        IsOverStock = false
                    });
                }
            }

            return lowStockProducts;
        }

        public async Task<List<ProductDto>> GetOverStockProductsAsync(CancellationToken cancellationToken = default)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .ToListAsync(cancellationToken);

            var overStockProducts = new List<ProductDto>();

            foreach (var product in products)
            {
                var currentStock = await GetCurrentStockLevelAsync(product.ProductID, cancellationToken);
                
                var maxStock = product.MaximumStockLevel ?? int.MaxValue;
                if (currentStock >= maxStock)
                {
                    overStockProducts.Add(new ProductDto
                    {
                        ProductID = product.ProductID,
                        Name = product.Name,
                        SKU = product.SKU,
                        CategoryName = product.Category?.CategoryName,
                        CurrentStock = currentStock,
                        MinimumStockLevel = product.MinimumStockLevel ?? 0,
                        MaximumStockLevel = maxStock,
                        IsLowStock = false,
                        IsOverStock = true
                    });
                }
            }

            return overStockProducts;
        }

        public async Task<List<ProductDto>> GetProductsNeedingReorderAsync(CancellationToken cancellationToken = default)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive && p.ReorderPoint.HasValue && p.ReorderPoint > 0)
                .ToListAsync(cancellationToken);

            var reorderProducts = new List<ProductDto>();

            foreach (var product in products)
            {
                var currentStock = await GetCurrentStockLevelAsync(product.ProductID, cancellationToken);
                
                var reorderPoint = product.ReorderPoint ?? 0;
                if (currentStock <= reorderPoint)
                {
                    reorderProducts.Add(new ProductDto
                    {
                        ProductID = product.ProductID,
                        Name = product.Name,
                        SKU = product.SKU,
                        CategoryName = product.Category?.CategoryName,
                        CurrentStock = currentStock,
                        MinimumStockLevel = product.MinimumStockLevel ?? 0,
                        MaximumStockLevel = product.MaximumStockLevel ?? 0,
                        ReorderPoint = reorderPoint,
                        IsLowStock = currentStock <= (product.MinimumStockLevel ?? 0),
                        IsOverStock = false
                    });
                }
            }

            return reorderProducts;
        }

        public async Task<StockLevelReportDto> GetStockLevelReportAsync(CancellationToken cancellationToken = default)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .ToListAsync(cancellationToken);

            var report = new StockLevelReportDto
            {
                TotalProducts = products.Count
            };

            foreach (var product in products)
            {
                var currentStock = await GetCurrentStockLevelAsync(product.ProductID, cancellationToken);
                
                var minStock = product.MinimumStockLevel ?? 0;
                var maxStock = product.MaximumStockLevel ?? int.MaxValue;
                var reorderPoint = product.ReorderPoint ?? 0;

                if (currentStock <= minStock)
                {
                    report.LowStockProducts++;
                    
                    // Kritik ürünler (stok 0 veya minimum seviyenin altında)
                    if (currentStock == 0 || currentStock < minStock / 2)
                    {
                        report.CriticalProducts.Add(new ProductDto
                        {
                            ProductID = product.ProductID,
                            Name = product.Name,
                            SKU = product.SKU,
                            CategoryName = product.Category?.CategoryName,
                            CurrentStock = currentStock,
                            MinimumStockLevel = minStock,
                            IsLowStock = true
                        });
                    }
                }
                
                if (currentStock >= maxStock)
                {
                    report.OverStockProducts++;
                }
                
                if (currentStock <= reorderPoint)
                {
                    report.ProductsNeedingReorder++;
                }
            }

            return report;
        }
    }
} 