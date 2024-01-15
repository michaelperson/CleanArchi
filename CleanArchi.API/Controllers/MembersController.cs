using CleanArchi.Application.Services.Interfaces;
using CleanArchi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchi.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class MembersController : ControllerBase
	{
		private readonly IMemberService memberService;

		public MembersController(IMemberService memberService)
		{
			this.memberService = memberService;
		}
		// GET: api/<MembersController>
		[HttpGet]
		public ActionResult<IList<Member>> Get()
		{
			return Ok(this.memberService.GetAllMembers());
		}
	}
}
