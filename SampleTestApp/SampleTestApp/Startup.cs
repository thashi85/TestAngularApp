using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Domain;
using Newtonsoft.Json;
using TestApp.Domain.TestDBContext;
using Microsoft.EntityFrameworkCore;
using TestApp.Domain.Interfaces;
using TestApp.DBAccess.Common;
using TestApp.Business;

namespace SampleTestApp
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
            //services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SampleTestApp", Version = "v1" });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
          

            //Custom app settings
            services.Configure<ApplicationSetting>(Configuration.GetSection("ApplicationSetting"));
            // change your database provider here
            string sqlConnectionStr = Configuration.GetConnectionString("SampleTestDB");
            services.AddDbContext<SampleDBContext>(options =>
            {  
                options.UseSqlServer(sqlConnectionStr);
            });

            #region Repositories
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<UserLogicHandler>();
            #endregion

            //services.AddSingleton<ILoggerManager, LoggerManager>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SampleTestApp v1"));
            }
            // Add Cors
            app.UseCors(x => x
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
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
