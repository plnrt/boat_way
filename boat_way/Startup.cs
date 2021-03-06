using Business.ResumeManager;
using Business.ResumeManager.Impl;
using Business.UserManager;
using Business.UserManager.Impl;
using Business.VacancyManager;
using Business.VacancyManager.Impl;
using Common.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistance.DataBase.Impl;
using Persistance.DataBaseManager;
using System.Data.Entity;
using System.Reflection;

namespace boat_way
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "boat_way", Version = "v1" });
            });

            services.AddSingleton(typeof(IDataBaseManager<>), typeof(DataBaseManager<>));
            services.AddTransient<IVacancyManager, VacancyManager>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IResumeManager, ResumeManager>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "boat_way v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
