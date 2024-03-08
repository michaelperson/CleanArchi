using System.ComponentModel.DataAnnotations;

namespace CleanArchi.Application.Dtos
{
    public class MemberDTO : IMemberDTO
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Type { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Gender { get; set; }
    }
}
