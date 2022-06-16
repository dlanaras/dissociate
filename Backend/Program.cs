using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
//using Dissociate.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Dissociate;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

/*services.AddDbContext<DissociateContext>(options =>
                options.UseMySql("server=localhost;user=pma;password=pmapass;database=ef", new MySqlServerVersion(new Version(10, 7, 3)))); //TODO: add config file for this*/

services.AddControllersWithViews();
services.AddDistributedMemoryCache();
services.AddSession(
    options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(60);
        options.Cookie.IsEssential = true;
    });

services.AddHttpContextAccessor();

services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
            policy =>
            {
                policy.WithOrigins("https://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
            });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseWebSockets();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

using(var scope = app.Services.CreateScope())
{
    /*var dbContext = scope.ServiceProvider.GetRequiredService<DissociateContext>();

    try
    {
        DbSeed.Initialize(dbContext);
    }
    catch (Exception ex)
    {
        throw new Exception("Error seeding the database", ex);
    }*/
}

app.Run();

