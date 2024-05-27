using MextFullStackSaaS.Domain.Identity;
using MextFullStactSaaS.Application.Common.Models;

namespace MextFullStactSaaS.Application.Common.Interfaces
{
    public interface IJwtService
    {

        JwtDto GenerateToken(User user, List<string> roles);

        Task<JwtDto> GenerateTokenAsync(Guid userId, string email,CancellationToken cancellationToken);
        
    }
}
