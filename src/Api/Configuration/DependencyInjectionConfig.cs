using Application.Services;
using Core.Data;
using Data;
using Data.Repository;
using Domain.Repository;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            //services.AddScoped<IUserCommandsRepository, UserCommandsRepository>();
            //services.AddScoped<IUserQueryRepository, UserQueryRepository>();
            //services.AddScoped<IUserApplicationService, UserApplicationService>();

            //---  Category -----
            services.AddScoped<ICategoryCommandsRepository, CategoryCommandsRepository>();
            services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
            services.AddScoped<ICategoryApplicationService, CategoryApplicationService>();
            //---  Document -----
            services.AddScoped<IDocumentCommandsRepository, DocumentCommandsRepository>();
            services.AddScoped<IDocumentQueryRepository, DocumentQueryRepository>();
            services.AddScoped<IDocumentApplicationService, DocumentApplicationService>();
            //---  DownloadHistory -----
            services.AddScoped<IDownloadHistoryCommandsRepository, DownloadHistoryCommandsRepository>();
            services.AddScoped<IDownloadHistoryQueryRepository, DownloadHistoryQueryRepository>();
            services.AddScoped<IDownloadHistoryApplicationService, DownloadHistoryApplicationService>();
            //---  Group -----
            services.AddScoped<IGroupCommandsRepository, GroupCommandsRepository>();
            services.AddScoped<IGroupQueryRepository, GroupQueryRepository>();
            services.AddScoped<IGroupApplicationService, GroupApplicationService>();
            //---  Role -----
            services.AddScoped<IRoleCommandsRepository, RoleCommandsRepository>();
            services.AddScoped<IRoleQueryRepository, RoleQueryRepository>();
            services.AddScoped<IRoleApplicationService, RoleApplicationService>();
            //---  UserGroup -----
            services.AddScoped<IUserGroupCommandsRepository, UserGroupCommandsRepository>();
            services.AddScoped<IUserGroupQueryRepository, UserGroupQueryRepository>();
            services.AddScoped<IUserGroupApplicationService, UserGroupApplicationService>();
            //---  UserProfile -----
            services.AddScoped<IUserProfileCommandsRepository, UserProfileCommandsRepository>();
            services.AddScoped<IUserProfileQueryRepository, UserProfileQueryRepository>();
            services.AddScoped<IUserProfileApplicationService, UserProfileApplicationService>();
            //DependencyInjectionAppendTag















            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        }

        public static void SetConnectionData(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO - Change to AddScoped
            services.AddSingleton<IDatabaseContext>(new DatabaseContext(configuration));
        }
    }
}
