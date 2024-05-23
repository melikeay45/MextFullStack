using MextFullStactSaaS.Application.Common.Interfaces;
using System.Security.Claims;

namespace MextFullStackSaaS.WebApi.Services
{
    public class CurrentUserManager:ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId => new("");
        //public Guid UserId => GetUserId();

        private Guid GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");

            return userId is null ? Guid.Empty : Guid.Parse(userId);
        }
    }
}
