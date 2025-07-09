using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarcodeController : ControllerBase
    {
        private readonly IBarcodeService _barcodeService;

        public BarcodeController(IBarcodeService barcodeService)
        {
            _barcodeService = barcodeService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateBarcode([FromBody] GenerateBarcodeRequest request)
        {
            if (string.IsNullOrEmpty(request.Content))
                return BadRequest("Content is required");

            var barcode = _barcodeService.GenerateBarcode(request.Content);
            var qrCode = _barcodeService.GenerateQRCode(request.Content);

            return Ok(new
            {
                Barcode = barcode,
                QRCode = qrCode,
                Content = request.Content
            });
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateBarcode([FromBody] ValidateBarcodeRequest request)
        {
            if (string.IsNullOrEmpty(request.Barcode))
                return BadRequest("Barcode is required");

            var isValid = _barcodeService.ValidateBarcode(request.Barcode);

            return Ok(new
            {
                Barcode = request.Barcode,
                IsValid = isValid
            });
        }

        [HttpGet("scan/pallet/{barcode}")]
        public async Task<IActionResult> ScanPalletBarcode(string barcode)
        {
            var pallet = await _barcodeService.GetPalletByBarcodeAsync(barcode);

            if (pallet == null)
                return NotFound("Pallet not found");

            return Ok(new
            {
                PalletID = pallet.PalletID,
                PalletName = pallet.PalletName,
                Status = pallet.Status.ToString(),
                RackName = pallet.Rack?.RackName,
                CustomerName = pallet.Customer?.CompanyName
            });
        }

        [HttpGet("scan/product/{barcode}")]
        public async Task<IActionResult> ScanProductBarcode(string barcode)
        {
            var product = await _barcodeService.GetProductByBarcodeAsync(barcode);

            if (product == null)
                return NotFound("Product not found");

            return Ok(new
            {
                ProductID = product.ProductID,
                Name = product.Name,
                SKU = product.SKU,
                Barcode = product.Barcode,
                CategoryName = product.Category?.CategoryName,
                IsActive = product.IsActive
            });
        }

        [HttpGet("generate/pallet/{palletId}")]
        public async Task<IActionResult> GeneratePalletBarcode(int palletId)
        {
            var barcode = await _barcodeService.GeneratePalletBarcodeAsync(palletId);

            if (string.IsNullOrEmpty(barcode))
                return NotFound("Pallet not found");

            return Ok(new { Barcode = barcode, PalletId = palletId });
        }

        [HttpGet("generate/product/{productId}")]
        public async Task<IActionResult> GenerateProductBarcode(int productId)
        {
            var barcode = await _barcodeService.GenerateProductBarcodeAsync(productId);

            if (string.IsNullOrEmpty(barcode))
                return NotFound("Product not found");

            return Ok(new { Barcode = barcode, ProductId = productId });
        }
    }

    public class GenerateBarcodeRequest
    {
        public string Content { get; set; }
    }

    public class ValidateBarcodeRequest
    {
        public string Barcode { get; set; }
    }
} 