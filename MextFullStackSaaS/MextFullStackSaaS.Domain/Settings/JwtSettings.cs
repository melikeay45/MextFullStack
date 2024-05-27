namespace MextFullStackSaaS.Domain.Settings
{
    public class JwtSettings
    {

            public string SecretKey { get; set; }
            public int AccessTokenExpirationInMinutes { get; set; }
            public int RefreshTokenExprationDays { get; set; }
            public string Issuer { get; set; }
            public string Audience { get; set; }

    }
}
