namespace PaletYonetimApplication.DTOs
{
	public class CustomerDto
	{
		public int CustomerID { get; set; }
		public string CompanyName { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedTime { get; set; } 
		public DateTime? UpdatedTime { get; set; }
	}
}
