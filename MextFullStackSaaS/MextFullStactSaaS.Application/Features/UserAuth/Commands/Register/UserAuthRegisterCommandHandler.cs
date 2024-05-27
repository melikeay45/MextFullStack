using MediatR;
using MextFullStackSaaS.Application.Common.Models;
using MextFullStactSaaS.Application.Common.Interfaces;
using MextFullStactSaaS.Application.Common.Models;

namespace MextFullStactSaaS.Application.Features.UserAuth.Commands.Register
{
    public class UserAuthRegisterCommandHandler : IRequestHandler<UserAuthRegisterCommand, ResponseDto<JwtDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtService _jwtservice;
        public UserAuthRegisterCommandHandler(IIdentityService ıdentityService,     IJwtService jwtService)
        {

            _identityService = ıdentityService;
            _jwtservice = jwtService;

        }
        public async Task<ResponseDto<JwtDto>> Handle(UserAuthRegisterCommand request, CancellationToken cancellationToken)
        {
            var response =await _identityService.RegisterAsync(request, cancellationToken);
            var jwtDto=await _jwtservice.GenerateTokenAsync(response.Id, response.Email, cancellationToken);
            return new ResponseDto<JwtDto>(jwtDto, "Welcome to our application");
        }
    }
}
