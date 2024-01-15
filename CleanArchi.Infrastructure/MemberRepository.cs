using CleanArchi.Application.Repository;
using CleanArchi.Domain.Entities;

namespace CleanArchi.Infrastructure
{
    public class MemberRepository : IMemberRepository
	{
		public static List<Member> lstMembers = new List<Member>()
		{
		   new Member{  Id =1 ,Name= "Kirtesh Shah", Type ="G" , Address="Vadodara"},
		   new Member{  Id =2 ,Name= "Mahesh Shah", Type ="S" , Address="Dabhoi"},
		   new Member{  Id =3 ,Name= "Nitya Shah", Type ="G" , Address="Mumbai"},
		   new Member{  Id =4 ,Name= "Dilip Shah", Type ="S" , Address="Dabhoi"},
		   new Member{  Id =5 ,Name= "Hansa Shah", Type ="S" , Address="Dabhoi"},
		   new Member{  Id =6 ,Name= "Mita Shah", Type ="G" , Address="Surat"}
		};

		public List<Member> GetAllMembers()
		{
			return lstMembers;
		}
	}
}
