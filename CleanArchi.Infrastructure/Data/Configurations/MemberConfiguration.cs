using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchi.Domain.Entities;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace CleanArchi.Infrastructure.Data.Configurations
{
	public class MemberConfiguration : IEntityTypeConfiguration<Member>
	{
		public void Configure(EntityTypeBuilder<Member> builder)
		{ 
			builder.HasKey(b => b.Id)
			.HasName("PK_Member");

			builder.Property(t => t.Name)
				.HasMaxLength(300)
				.IsRequired();

			builder.Property(t => t.Email)
				.HasMaxLength(320)
				.IsRequired();
		}
	}
	 
}
