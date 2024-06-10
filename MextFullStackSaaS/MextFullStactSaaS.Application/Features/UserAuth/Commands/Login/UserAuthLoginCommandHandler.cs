using MediatR;
using MextFullStackSaaS.Application.Common.Models;
using MextFullStactSaaS.Application.Common.Interfaces;
using MextFullStactSaaS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStactSaaS.Application.Features.UserAuth.Commands.Login
{
    public class UserAuthLoginCommandHandler : IRequestHandler<UserAuthLoginCommand, ResponseDto<JwtDto>>
    {
        private readonly IIdentityService _identityService;

        public UserAuthLoginCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseDto<JwtDto>> Handle(UserAuthLoginCommand request, CancellationToken cancellationToken)
        {
            var jwtDto = await _identityService.LoginAsync(request, cancellationToken);

            return new ResponseDto<JwtDto>(jwtDto, "Welcome back!");
        }
    }
}
