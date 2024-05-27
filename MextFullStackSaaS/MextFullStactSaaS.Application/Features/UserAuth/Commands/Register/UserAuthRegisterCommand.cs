using MediatR;
using MextFullStackSaaS.Application.Common.Models;
using MextFullStackSaaS.Domain.Identity;
using MextFullStactSaaS.Application.Common.Models;

namespace MextFullStactSaaS.Application.Features.UserAuth.Commands.Register
{
    public class UserAuthRegisterCommand:IRequest<ResponseDto<JwtDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }  
        public string ConfirmPassword { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }

        public static User ToUser(UserAuthRegisterCommand command)
        {
            var id = Guid.NewGuid();
            return new User()
            {
                Id = Guid.NewGuid(),
                Email = command.Email,
                UserName = command.Email,
                FirstName = command.FirsName,
                LastName = command.FirsName,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = id.ToString(),
                EmailConfirmed = true,
                Balance = new MextFullStackSaaS.Domain.Entities.UserBalance()
                {
                    Id = Guid.NewGuid(),
                    Credits = 10,
                    UserId = id,
                    CreatedOn = DateTimeOffset.Now,
                    CreatedByUserId = id.ToString(),
                }
            };
        }
    }
}
