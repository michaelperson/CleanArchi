namespace CleanArchi.Application.Dtos
{
    public interface IMemberDTO
    {
        string Email { get; set; }
        string Gender { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string Type { get; set; }
    }
}