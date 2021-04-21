using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UncleProductTracking.Biz.Interfaces;
using UncleProductTracking.Biz.Manager;
using UncleProductTracking.Repo.Context;
using UncleProductTracking.Repo.Interfaces;
using UncleProductTracking.Repo.Manager;
using UncleProductTracking.Repo.UnitOfWork.Interfaces;
using UncleProductTracking.Repo.UnitOfWork.Manager;
using UncleProductTracking.Report.Interfaces;
using UncleProductTracking.Report.Manager;

namespace UncleProductTracking.API
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

            services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source = testdb.db"));

            services.AddSwaggerGen();

            services.AddCors();

            services.AddTransient<IDeviceRepo, DeviceRepoManager>();
            services.AddTransient<IDeviceBiz, DeviceBizManager>();

            services.AddTransient<IUnitBiz, UnitBizManager>();
            services.AddTransient<IUnitRepo, UnitRepoManager>();

            services.AddTransient<IDeviceTypeBiz, DeviceTypeBizManager>();
            services.AddTransient<IDeviceTypeRepo, DeviceTypeRepoManager>();

            services.AddTransient<IUserBiz, UserBizManager>();
            services.AddTransient<IUserRepo, UserRepoManager>();

            services.AddTransient<IDeviceReport, DeviceReportManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseAuthentication();

            //app.UseHsts();
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rapor Takip API - Emre Kirman");
                c.DocumentTitle = "Rapor Takip Rest API - Emre Kirman";
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
