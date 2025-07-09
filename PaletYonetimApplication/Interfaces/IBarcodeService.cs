using PaletYonetimDomain.Entities;

namespace PaletYonetimApplication.Interfaces
{
    public interface IBarcodeService
    {
        string GenerateBarcode(string content);
        string GenerateQRCode(string content);
        bool ValidateBarcode(string barcode);
        Task<PalletEntity> GetPalletByBarcodeAsync(string barcode, CancellationToken cancellationToken = default);
        Task<ProductEntity> GetProductByBarcodeAsync(string barcode, CancellationToken cancellationToken = default);
        Task<string> GeneratePalletBarcodeAsync(int palletId, CancellationToken cancellationToken = default);
        Task<string> GenerateProductBarcodeAsync(int productId, CancellationToken cancellationToken = default);
    }
} 