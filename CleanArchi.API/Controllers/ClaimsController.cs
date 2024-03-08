using CleanArchi.Application.Common.Interfaces;
using CleanArchi.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClaimsController : ControllerBase
    {

        public ClaimsController(IIdentityService _identityService)
        {
            IdentityService = _identityService;
        }

        public IIdentityService IdentityService { get; }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult Get()
        {
            if (User.Identity == null) return Unauthorized();
            string name = User.Identity.Name??"";
            return Ok(IdentityService.IsTwoFactorActivatedAsync(name));
        }
    }
}
