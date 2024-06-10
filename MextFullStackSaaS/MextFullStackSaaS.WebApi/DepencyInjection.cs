using MextFullStackSaaS.WebApi.Services;
using MextFullStactSaaS.Application.Common.Interfaces;
using Microsoft.OpenApi.Models;
using System.Globalization;

namespace MextFullStackSaaS.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Çeviriler resources klasörü altında belirttik
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

            //Varsayılan dili belirledik
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var defaultCalture = new CultureInfo("en-GB");

                //Desteklenen dilleri belirttik
                var supportedCultures = new List<CultureInfo>
                {
                    defaultCalture,
                    new CultureInfo("tr-TR")
                };

                //Frontendden dil ayarı gönderilmezse ing cevap ver
                options.DefaultRequestCulture = new RequestCulture(defaultCalture);


                options.SupportedCultures = supportedCultures;

                options.SupportedUICultures = supportedCultures;
                
//Uygulama hangi dilde kullanılıyorsa cevaplarda bunu ilet
options.ApplyCurrentCultureToResponseHeaders = true;
            });
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc(
                    "v1",
                    new OpenApiInfo()
                    {
                        Title = "MextFullStackSaaS Web API",
                        Version = "1",
                        Description = "Through this API you can access MextFullStackSaaS App's details",
                        Contact = new OpenApiContact()
                        {
                            Email = "alper.tunga@yazilim.academy",
                            Name = "Alper Tunga",
                            Url = new Uri("https://yazilim.academy/")
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "© 2024 Yazılım Academy Tüm Hakları Saklıdır",
                            Url = new Uri("https://yazilim.academy/")
                        }
                    });

                setupAction.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = $"Input your Bearer token in this format - Bearer token to access this API",
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                    }, new List<string>()
                },
            });
            });

            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserManager>();

            // Install Microsoft.AspNetCore.Authentication.JwtBearer nuget
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]!))
                    };

                });
            return services;
        }
    }
}
