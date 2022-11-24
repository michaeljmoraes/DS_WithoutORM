using Application.Services;
using Core.Data;
using Data;
using Data.Repository.Users;
using Domain.Repository.User;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace DocumentStorage.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserCommandsRepository, UserCommandsRepository>();
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();
            services.AddScoped<IUserApplicationService, UserApplicationService>();

            services.AddScoped<IGroupCommandsRepository, GroupCommandsRepository>();
            services.AddScoped<IGroupQueryRepository, GroupQueryRepository>();
            services.AddScoped<IGroupApplicationService, GroupApplicationService>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        }

        public static void SetConnectionData(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO - Change to AddScoped
            services.AddSingleton<IDatabaseContext>(new DatabaseContext(configuration));
        }
    }
}
