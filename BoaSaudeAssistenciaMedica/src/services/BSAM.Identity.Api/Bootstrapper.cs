using BSAM.Identity.Api.Configuration;

namespace BSAM.Identity.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddIdentityConfiguration(configuration);

            services.AddApiConfiguration();

            services.AddSwaggerConfiguration();

            return services;
        }

        public static IApplicationBuilder UseDependencies(this IApplicationBuilder app, IWebHostEnvironment env) 
        {
            app.UseApiConfiguration(env);

            return app;
        }
    }
}
