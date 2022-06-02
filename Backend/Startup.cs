using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dissociate.Contexts;
using Microsoft.AspNetCore.Builder;

namespace Dissociate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DissociateContext>(options =>
                options.UseSqlite("Data Source=dissociate.db")); //TODO: add config file for this

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
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseSession();

            app.UseCors();

            /*app.Use(async (context, next) =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                    await Echo(webSocket);
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                }
            });*/

            app.Run();

        }
    }
}