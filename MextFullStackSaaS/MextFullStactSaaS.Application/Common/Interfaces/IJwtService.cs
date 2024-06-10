using MextFullStackSaaS.Application.Common.Models;
using MextFullStackSaaS.Domain.Identity;

namespace MextFullStactSaaS.Application.Common.Interfaces
{
    public interface IJwtService
    {
        JwtDto GenerateToken(User user, List<string> roles);
        Task<JwtDto> GenerateTokenAsync(Guid userId, string email, CancellationToken cancellationToken);
    }
}
