﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Application.Repository
{
	public interface IMemberRepository
	{
		List<Domain.Member> GetAllMembers();
	}
}
