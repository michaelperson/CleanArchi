using CleanArchi.Application.Repository;
using CleanArchi.Application.Services.Interfaces;

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
		List<Domain.Member> IMemberService.GetAllMembers()
		{
			return this.memberRepository.GetAllMembers();
		}
	}
}
