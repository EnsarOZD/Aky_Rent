namespace PaletYonetimDomain.Entities
{
	public class CustomerEntity
	{
		public int CustomerID { get; set; } // Benzersiz kimlik
		public string CompanyName { get; set; } // Şirket adı
		public bool IsActive { get; set; } // Müşteri aktif mi?

		// Navigation Properties
		public ICollection<RepresentativeEntity> Representatives { get; set; } // Temsilciler

		public ICollection<PalletEntity> Pallets { get; set; } // Müşteriye ait paletler

	}
}
