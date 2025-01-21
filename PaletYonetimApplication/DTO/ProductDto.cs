namespace PaletYonetimApplication.DTO
{
	public class ProductDto
	{
		public int ProductID { get; set; }
		public string Name { get; set; }
		public string Barcode { get; set; }
		public string Description { get; set; }
		public string Unit { get; set; }
		public int CategoryID { get; set; }
		public string CustomerStockCode { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime? UpdatedTime { get; set; }
	}
}
