using CleanArchi.Application.Dtos;
using CleanArchi.Application.Services.Interfaces;
using CleanArchi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchi.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	[Produces("application/json")] 
	public class MembersController : ControllerBase
	{
		private readonly IMemberService memberService;

		public MembersController(IMemberService memberService)
		{
			this.memberService = memberService;
		}
		// GET: api/<MembersController>
		/// <summary>
		/// Get all members
		/// </summary>
		/// <returns>an <see cref="IList{MemberDTO}"/></returns>
		/// <remarks>
		/// Sample request:
		///
		///     GET /api/Members		      
		///
		/// </remarks>
		/// <response code="200">Returns all members</response>
		/// <response code="401">If your are not authenticated</response>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize]
		public ActionResult<IList<MemberDTO>> Get()
		{
			return Ok(this.memberService.GetAllMembers());
		}
	}
}
