using CleanArchi.Application.Common.Interfaces;
using CleanArchi.Domain.Constants;
using CleanArchi.Infrastructure.Data;
using CleanArchi.Infrastructure.Identity.Model;
using CleanArchi.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration, string cnstr)
		{

			string? connectionString = configuration.GetConnectionString(cnstr);

			if (connectionString == null) { throw new ArgumentException($"{nameof(connectionString)} n'existe pas"); }
			 

			services.AddDbContext<ApplicationDbContext>((sp, options) =>
			{ 
				options.UseSqlServer(connectionString);
			});

			services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

			services.AddScoped<ApplicationDbContextInitialiser>();
			 
			services 
				.AddIdentityCore<ApplicationUser>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddSingleton(TimeProvider.System);
			services.AddTransient<IIdentityService, IdentityService>();

			services.AddAuthorizationCore(options =>
				options.AddPolicy(Policies.CanDelete, policy => policy.RequireRole(Roles.Administrator)));

			return services;
		}
	}
}
