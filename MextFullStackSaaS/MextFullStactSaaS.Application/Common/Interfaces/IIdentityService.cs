using MextFullStackSaaS.Application.Common.Models;
using MextFullStactSaaS.Application.Common.Models.Auth;
using MextFullStactSaaS.Application.Features.UserAuth.Commands.Login;
using MextFullStactSaaS.Application.Features.UserAuth.Commands.Register;
using MextFullStactSaaS.Application.Features.UserAuth.Commands.VerifyEmail;

namespace MextFullStactSaaS.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken);
        Task<JwtDto> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken);
        Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken);
        Task<bool> CheckPasswordSignInAsync(string email, string password, CancellationToken cancellationToken);
        Task<bool> VerifyEmailAsync(UserAuthVerifyEmailCommand command, CancellationToken cancellationToken);
        Task<bool> CheckIfEmailVerifiedAsync(string email, CancellationToken cancellationToken);
    }
}
