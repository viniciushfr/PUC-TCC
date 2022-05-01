using BSAM.Identity.Api.Extensions;
using BSAM.Identity.Api.Extensions.User;
using BSAM.Identity.Api.Services;
using MediatR;
using NetDevPack.Security.JwtSigningCredentials.AspNetCore;
using System.Reflection;

namespace BSAM.Identity.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<AuthenticationService>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerConfiguration();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthConfiguration();

            app.UseJwksDiscovery();

            return app;
        }
    }
}
