using BSAM.Identity.Api.Extensions;
using BSAM.Identity.Api.Extensions.User;
using BSAM.Identity.Api.Requests;
using BSAM.Identity.Api.Requests.Validators;
using BSAM.Identity.Api.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace BSAM.Identity.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .AddFluentValidation(options =>
                {
                    
                    options.ImplicitlyValidateChildProperties = true;
                    options.ImplicitlyValidateRootCollectionElements = true;
                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

            services.AddScoped<TokenService>();
            services.AddScoped<AuthenticationService>();
            services.AddScoped<IAspNetUser, AspNetUser>();
          

            services.AddJwtConfiguration(configuration);

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

            return app;
        }
    }
}
