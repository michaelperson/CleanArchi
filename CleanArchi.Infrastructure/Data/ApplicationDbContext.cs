using CleanArchi.Application.Common.Interfaces;
using CleanArchi.Infrastructure.Identity.Model;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Emit;
using CleanArchi.Domain.Entities;

namespace CleanArchi.Infrastructure.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options) { }
		public DbSet<Member> TodoLists => Set<Member>();

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(builder);
		}
		 
		 
	}
}
