using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JobPusher.Services;
using System.Net.Http;

namespace JobPusher
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
            services.AddMvc();

            // Bind config sections to specific models
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

                       
            services.Add(new ServiceDescriptor(typeof(HttpClient), new HttpClient()));
            
            services.AddScoped<IPusherService, PusherService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{area:exists=Pusher}/{controller=Pusher}/{action=Index}/{id?}");
            });
        }
    }
}
