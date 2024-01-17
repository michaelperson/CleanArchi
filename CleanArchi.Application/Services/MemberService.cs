using CleanArchi.Application.Dtos;
using CleanArchi.Application.Repository;
using CleanArchi.Application.Services.Interfaces;
using CleanArchi.Domain.Entities;

namespace CleanArchi.Application.Services
{
    //Implémentation des règles business / Use cases
    public class MemberService : IMemberService
	{
		private readonly IMemberRepository memberRepository;
		public MemberService(IMemberRepository memberRepository)
		{
			this.memberRepository = memberRepository;
		}
		IEnumerable<MemberDTO> IMemberService.GetAllMembers()
		{
			return this.memberRepository.GetAllMembers().Select(m=>new MemberDTO() { Email = m.Email, Gender = m.Gender, Name = m.Name, Type = m.Type, Id = m.Id }) ;
		}
	}
}
