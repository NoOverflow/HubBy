using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HubBy.Database;
using Microsoft.Extensions.Options;
using HubBy.Services;
using HubBy.Middlewares;
using Microsoft.AspNetCore.Routing;

namespace HubBy
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
            services.Configure<HubbyDatabaseSettings>(Configuration.GetSection(nameof(HubbyDatabaseSettings)));
            services.AddSingleton<IHubbyDatabaseSettings>(sp => sp.GetRequiredService<IOptions<HubbyDatabaseSettings>>().Value);
            services.AddSingleton<ProjectService>();
            services.AddSingleton<ActivityService>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddRazorPages();
            services.AddServerSideBlazor();
        }

        public IRouter BuildRouter(IApplicationBuilder appBuilder)
        {
            RouteBuilder builder = new RouteBuilder(appBuilder);

            builder.MapMiddlewarePost("/api/activities", (appBuilder) =>
            {
                appBuilder.UseMiddleware<ApiAuthenticationMiddleware>();
            });
            return (builder.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            //app.UseRouter(BuildRouter(app));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
