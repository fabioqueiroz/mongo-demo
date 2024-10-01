using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NPTN.MongoDemo.Application.Behaviours;

namespace NPTN.MongoDemo.Application
{
    public static class ContainerRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(ContainerRegistration).Assembly);
                config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            });

            services.AddValidatorsFromAssembly(typeof(ContainerRegistration).Assembly, includeInternalTypes: true);

            return services;
        }
    }
}
