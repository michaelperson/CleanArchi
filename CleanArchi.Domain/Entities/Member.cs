namespace CleanArchi.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Address { get; set; }
    }
}
