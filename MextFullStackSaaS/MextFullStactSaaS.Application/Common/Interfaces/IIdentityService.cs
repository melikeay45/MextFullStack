using MextFullStactSaaS.Application.Common.Models;
using MextFullStactSaaS.Application.Common.Models.Auth;
using MextFullStactSaaS.Application.Features.UserAuth.Commands.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStactSaaS.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken);
        Task<JwtDto> SignInAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken);
        Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken);
    }
}
