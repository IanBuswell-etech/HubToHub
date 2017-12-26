using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MiniHub.Services;
using MiniHub.Data.LiteDb;
using System.IO;
using MiniHub.MessagePusher;

namespace MiniHub.Api
{
    public class Startup
    {
        ////public Startup(IConfiguration configuration)
        ////{
        ////    Configuration = configuration;
        ////}

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My Api", Version = "v1" });
            });

            // Register our context! Scoped == per request to app
            services.AddScoped<DatabaseContext>();

            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddTransient<IJobService, JobService>();

            services.AddTransient<IMessagePusher, NullPusher>();

            services.AddTransient<IFirmService, FirmService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ////app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller}/{action=Index}/{id?}"
                );

                // Testing route
                routes.MapRoute(
                  name: "test",
                  template: "{controller=Test}/{action=TestConnection}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Job}/{action=Index}/{id?}");
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
