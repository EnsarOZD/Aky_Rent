namespace PaletYonetimDomain.Entities
{
	public class PaletEntity
	{
		public int Id { get; set; }
        public string PaletNo { get; set; }
        public int AddressId { get; set; }
        public string Situation { get; set; }
        public int CustomerId { get; set; }
        public DateTime EnteryDate { get; set; }
        public DateTime? ExitDate { get; set; }

        //Navigation Property

        public CustomerEntity Customer { get; set; }
		public RackAddressEntity RackAddress { get; set; }

	}
}
