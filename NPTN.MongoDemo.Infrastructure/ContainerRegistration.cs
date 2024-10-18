using Microsoft.Extensions.DependencyInjection;
using NPTN.MongoDemo.Application.UseCases.Movies;
using NPTN.MongoDemo.Application.UseCases.Users;
using NPTN.MongoDemo.Infrastructure.DatabaseConnection;
using NPTN.MongoDemo.Infrastructure.Repositories;

namespace NPTN.MongoDemo.Infrastructure
{
    public static class ContainerRegistration
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddSingleton<IMongoConnection, MongoConnection>();

            services
                .AddScoped<IReadOnlyMovieRepository, ReadOnlyMovieRepository>()
                .AddScoped<IReadOnlyUserRepository, ReadOnlyUserRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IMovieCommentsMaterialisedViewRepository, MovieCommentsMaterialisedViewRepository>();

            return services;
        }
    }
}
