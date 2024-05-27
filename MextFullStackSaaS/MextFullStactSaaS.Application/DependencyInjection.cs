﻿using MediatR;
using MextFullStactSaaS.Application.Common.Behaviour;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;

namespace MextFullStactSaaS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => {

                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });

            return services;
        }
    }
}