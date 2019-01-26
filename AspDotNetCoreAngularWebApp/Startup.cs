using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.Webpack;
using AspDotNetCoreAngularWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCoreAngularWebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Specify server name instead of "ALEX-PC\\SQLEXPRESS"
            string connectionString = "Server=ALEX-PC\\SQLEXPRESS;Database=newsdb;Trusted_Connection=True;";
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
