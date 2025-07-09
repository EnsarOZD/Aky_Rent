using MediatR;
using System;

namespace PaletYonetimApplication.Features.Products.Commands
{
	public class UpdateProductCommand: IRequest<bool>
	{
		public int ProductID { get; set; }
		public string Name { get; set; }
		public string Barcode { get; set; }
		public string QRCode { get; set; }
		public string Description { get; set; }
		public string Unit { get; set; }
		public int CategoryID { get; set; }
		public string CustomerStockCode { get; set; }
		public string SKU { get; set; }
		public decimal Weight { get; set; }
		public decimal? Length { get; set; }
		public decimal? Width { get; set; }
		public decimal? Height { get; set; }
		public int? MinimumStockLevel { get; set; }
		public int? MaximumStockLevel { get; set; }
		public int? ReorderPoint { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public string LotNumber { get; set; }
		public string SerialNumber { get; set; }
		public bool IsHazardous { get; set; }
		public bool RequiresColdStorage { get; set; }
		public bool IsActive { get; set; }
	}
}
