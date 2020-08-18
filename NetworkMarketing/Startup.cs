using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NetworkMarketing.AutoMapperProfiles;
using NetworkMarketing.BL;
using NetworkMarketing.BL.Entities;
using NetworkMarketing.BL.Interfaces;
using NetworkMarketing.BL.Services;
using NetworkMarketing.BL.Services.DistributorService;
using NetworkMarketing.DB;
using NetworkMarketing.DB.Implementations;

namespace NetworkMarketing
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
            services.AddControllers();

            IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            AppSettings appSettings = appSettingsSection.Get<AppSettings>();

            var connectionSql = $"Server=tcp:{appSettings.SqlServerHostName},{appSettings.SqlServerPort};Initial Catalog={appSettings.SqlServerCatalog};Persist Security Info=False;User ID={appSettings.SqlServerUser};Password={appSettings.SqlServerPassword};MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;";

            var connectionPostgre = appSettings.PostgreConnectionString;

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(connectionPostgre);
            });

         
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDistributorService, DistributorService>();


            services.AddAutoMapper(c => c.AddProfile<DistibutorProfile>(), typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<ItemProfile>(), typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(
                    @"Server=(localdb)\mssqllocaldb;Database=CourseLibraryDB;Trusted_Connection=True;");
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
