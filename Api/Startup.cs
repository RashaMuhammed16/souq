using BL.AppServices;
using BL.Bases;
using BL.Interfaces;
using DataAccessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            services.AddDbContext<ApplicationDBContext>(option => {
                option.UseSqlServer(Configuration.GetConnectionString("Souq"),
                options => options.EnableRetryOnFailure());
            });
            services.AddControllers();
            services.AddDbContext<ApplicationDBContext>(option => {
                option.UseSqlServer(Configuration.GetConnectionString("CS"),
                    options => options.EnableRetryOnFailure());
            });
            
            services.AddControllers(); services.AddIdentity<ApplicationUserIdentity, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<UserManager<ApplicationUserIdentity>>();
            services.AddTransient<OrderDetailsAppService>();
            services.AddTransient<PaymentAppService>();
            services.AddTransient<ShipperAppService>();
            services.AddTransient<BillingAddressAppService>();
            services.AddTransient<ProductAppService>();
            services.AddTransient<OrderAppService>();
            services.AddTransient<ModelAppService>();
            services.AddTransient<BrandAppService>();
            services.AddHttpContextAccessor();//allow me to get user information such as id
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
