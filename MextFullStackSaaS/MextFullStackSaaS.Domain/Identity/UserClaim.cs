using Microsoft.AspNetCore.Identity;

namespace MextFullStackSaaS.Domain.Identity
{

    //"User claim" kavramı, bir kullanıcının kimlik doğrulama ve yetkilendirme süreçlerinde sahip olduğu yetkileri veya hakları temsil eder.
    //Bu, bir kullanıcının bir uygulamada ne yapabileceğini veya hangi kaynaklara erişebileceğini belirten bir veri parçasıdır.
    public class UserClaim:IdentityUserClaim<Guid>
    {
    }
}
