namespace CleanArchi.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
		public required string Email { get; set; }
		public required string Gender { get; set; }
	}
}
