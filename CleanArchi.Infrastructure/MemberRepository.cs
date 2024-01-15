using CleanArchi.Application.Repository;
using CleanArchi.Domain.Entities;

namespace CleanArchi.Infrastructure
{
    public class MemberRepository : IMemberRepository
	{
		public static List<Member> lstMembers = new List<Member>()
		{
		   new Member{  Id =1 ,Name= "Kirtesh Shah", Type ="G" , Email="Vadodara@gmail.com"},
		   new Member{  Id =2 ,Name= "Mahesh Shah", Type ="S" , Email="Dalhoi@gmail.com"},
		   new Member{  Id =3 ,Name= "Nitya Shah", Type ="G" , Email="Mumbai@gmail.com"},
		   new Member{  Id =4 ,Name= "Dilip Shah", Type ="S" , Email="Sabhoi@gmail.com"},
		   new Member{  Id =5 ,Name= "Hansa Shah", Type ="S" , Email="Mabloi@gmail.com"},
		   new Member{  Id =6 ,Name= "Mita Shah", Type ="G" , Email="Sura@gmail.com"}
		};

		public List<Member> GetAllMembers()
		{
			return lstMembers;
		}
	}
}
