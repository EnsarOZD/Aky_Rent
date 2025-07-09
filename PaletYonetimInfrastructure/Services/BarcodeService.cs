using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;
using System.Text.RegularExpressions;

namespace PaletYonetimInfrastructure.Services
{
    public class BarcodeService : IBarcodeService
    {
        private readonly IApplicationDbContext _context;

        public BarcodeService(IApplicationDbContext context)
        {
            _context = context;
        }

        public string GenerateBarcode(string content)
        {
            if (string.IsNullOrEmpty(content))
                return string.Empty;

            // Basit barkod formatı: PALET-{ID} veya PROD-{ID}
            return $"BAR-{content}-{DateTime.Now:yyyyMMdd}";
        }

        public string GenerateQRCode(string content)
        {
            if (string.IsNullOrEmpty(content))
                return string.Empty;

            // QR kod formatı: JSON formatında daha fazla bilgi
            var qrData = new
            {
                Content = content,
                GeneratedAt = DateTime.Now,
                Type = "QR"
            };

            return System.Text.Json.JsonSerializer.Serialize(qrData);
        }

        public bool ValidateBarcode(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
                return false;

            // Barkod formatı kontrolü: BAR-{CONTENT}-{DATE}
            var pattern = @"^BAR-[A-Z0-9]+-\d{8}$";
            return Regex.IsMatch(barcode, pattern);
        }

        public async Task<PalletEntity> GetPalletByBarcodeAsync(string barcode, CancellationToken cancellationToken = default)
        {
            if (!ValidateBarcode(barcode))
                return null;

            // Barkod'dan palet ID'sini çıkar
            var parts = barcode.Split('-');
            if (parts.Length < 2)
                return null;

            // Palet adından ID'yi bul
            var palletName = parts[1];
            return await _context.Pallets
                .Include(p => p.Rack)
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(p => p.PalletName == palletName, cancellationToken);
        }

        public async Task<ProductEntity> GetProductByBarcodeAsync(string barcode, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(barcode))
                return null;

            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Barcode == barcode, cancellationToken);
        }

        public async Task<string> GeneratePalletBarcodeAsync(int palletId, CancellationToken cancellationToken = default)
        {
            var pallet = await _context.Pallets
                .FirstOrDefaultAsync(p => p.PalletID == palletId, cancellationToken);

            if (pallet == null)
                return string.Empty;

            return GenerateBarcode(pallet.PalletName);
        }

        public async Task<string> GenerateProductBarcodeAsync(int productId, CancellationToken cancellationToken = default)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductID == productId, cancellationToken);

            if (product == null)
                return string.Empty;

            return GenerateBarcode(product.SKU ?? product.Name);
        }
    }
} 