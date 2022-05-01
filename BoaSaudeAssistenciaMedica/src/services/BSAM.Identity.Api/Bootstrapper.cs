using BSAM.Identity.Api.Configuration;
using BSAM.Identity.Api.Requests;
using BSAM.Identity.Api.Requests.Validators;
using FluentValidation;

namespace BSAM.Identity.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddIdentityConfiguration(configuration);

            services.AddApiConfiguration(configuration);

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
