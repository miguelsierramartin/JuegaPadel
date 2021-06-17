using Catalog.Persistence.Database;
using Catalog.Service.Queries;
using Common.Logging;
using HealthChecks.UI.Client;
using MediatR;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Catalog.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // DbContext
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Catalog")
                )
            );

            services.AddHealthChecks()
                        .AddCheck("self", () => HealthCheckResult.Healthy())
                        .AddDbContextCheck<ApplicationDbContext>();

            services.AddHealthChecksUI()
                .AddInMemoryStorage(); //nuget: AspNetCore.HealthChecks.UI.InMemory.Storage

            services.AddMediatR(Assembly.Load("Catalog.Service.EventHandlers"));
            
            services.AddTransient<IProductQueryService, ProductQueryService>();
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                loggerFactory.AddSyslog(
                    Configuration.GetValue<string>("Papertrail:host"),
                    Configuration.GetValue<int>("Papertrail:port"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                //nuget: AspNetCore.HealthChecks.UI
                app.UseHealthChecksUI(options =>
                {
                    options.UIPath = "/healthchecks-ui";
                    options.ApiPath = "/health-ui-api";
                });

                endpoints.MapHealthChecksUI();
                endpoints.MapControllers();
            });
        }
    }
}
