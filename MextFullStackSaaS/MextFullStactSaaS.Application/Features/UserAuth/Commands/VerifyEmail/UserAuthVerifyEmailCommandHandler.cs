using MediatR;
using MextFullStackSaaS.Application.Common.Models;
using MextFullStactSaaS.Application.Common.Interfaces;
using Microsoft.Extensions.Localization;

namespace MextFullStactSaaS.Application.Features.UserAuth.Commands.VerifyEmail
{
    public class UserAuthVerifyEmailCommandHandler : IRequestHandler<UserAuthVerifyEmailCommand, ResponseDto<string>>
    {
        private readonly IIdentityService _identityService;
        private readonly IStringLocalizer<CommonTranslations> _localizer;

        public UserAuthVerifyEmailCommandHandler(IIdentityService identityService, IStringLocalizer<CommonTranslations> localizer)
        {
            _identityService = identityService;
            _localizer = localizer;
        }

        public async Task<ResponseDto<string>> Handle(UserAuthVerifyEmailCommand request, CancellationToken cancellationToken)
        {
            await _identityService.VerifyEmailAsync(request, cancellationToken);

            return new ResponseDto<string>(request.Email, _localizer[CommonTranslationKeys.UserAuthVerifyEmailSucceededMessage, request.Email]);
        }
    }
}
