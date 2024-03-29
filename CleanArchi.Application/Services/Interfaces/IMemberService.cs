﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchi.Application.Dtos;
using CleanArchi.Domain.Entities;

namespace CleanArchi.Application.Services.Interfaces
{
    //Cet interface est utilisé pour les règles business / Use cases
    public interface IMemberService
	{
		IEnumerable<IMemberDTO> GetAllMembers();
	}
}
