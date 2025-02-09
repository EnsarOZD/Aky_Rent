namespace PaletYonetimApplication.DTO
{
	public class UserDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }

		public DateTime CreatedTime { get; set; }
		public DateTime? UpdatedTime { get; set; }

		// İsteğe bağlı: Tam adı hesaplamak için
		public string FullName => $"{FirstName} {LastName}";
	}
}
