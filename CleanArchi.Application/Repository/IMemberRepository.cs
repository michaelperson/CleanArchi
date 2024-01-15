using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchi.Domain.Entities;

namespace CleanArchi.Application.Repository
{
    public interface IMemberRepository
	{
		List<Member> GetAllMembers();
	}
}
