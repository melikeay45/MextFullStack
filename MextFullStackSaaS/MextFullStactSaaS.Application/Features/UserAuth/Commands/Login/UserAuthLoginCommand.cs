using MediatR;
using MextFullStackSaaS.Application.Common.Models;
using MextFullStactSaaS.Application.Common.Models;

namespace MextFullStactSaaS.Application.Features.UserAuth.Commands.Login
{
    public class UserAuthLoginCommand : IRequest<ResponseDto<JwtDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
