using MediatR;
using MextFullStactSaaS.Application.Features.UserAuth.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace MextFullStackSaaS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : Controller
    {
        private readonly ISender _mediatr;
        public UsersAuthController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }
    }
}
