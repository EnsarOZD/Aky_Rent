namespace PaletYonetimDomain.Entities
{
	public class CustomerEntity
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CustomerAddress { get; set; }

        //Navigation Property

        public ICollection<PaletEntity> Palets { get; set; }
    }
}
