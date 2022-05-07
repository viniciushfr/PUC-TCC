

using BSAM.Identity.Api;
using BSAM.Identity.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}



using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

    if (dbContext != null)
        dbContext.Database.Migrate();

    await seeder.SeedRoles();
    await seeder.SeedAdminUser();
}

app.UseHttpsRedirection();

app.UseDependencies(app.Environment);

app.MapControllers();

app.Run();
