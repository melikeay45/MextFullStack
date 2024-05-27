using MextFullStackSaaS.Domain.Identity;
using MextFullStactSaaS.Application.Common.Interfaces;
using MextFullStactSaaS.Application.Common.Models;
using MextFullStactSaaS.Application.Common.Models.Auth;
using MextFullStactSaaS.Application.Features.UserAuth.Commands.Register;
using Microsoft.AspNetCore.Identity;

namespace MextFullStackSaaS.Infrastructure.Services
{
    public class IdentityManager : IIdentityService
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;

        public IdentityManager(UserManager<User> userManager, IJwtService jwtService)
        {
            _userManager=userManager;
            _jwtService=jwtService;
        }

        public async Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            var user = UserAuthRegisterCommand.ToUser(command);
          
            var result=await _userManager.CreateAsync(user,command.Password);

            if(!result.Succeeded)
            {
                throw new Exception("User register failed.");
            }
            return new UserAuthRegisterResponseDto(user.Id, user.Email);
        }

        public Task<JwtDto> SignInAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
