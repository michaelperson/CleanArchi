using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Application.Dtos
{
	public class MemberDTO
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
