<<<<<<< HEAD
using DataAccessLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
=======
using BL.AppServices;
using BL.Bases;
using BL.Interfaces;
using DataAccessLayer;
>>>>>>> 6fc95b019d49c2f5dc1203fa14d86f7531d3c8be
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public class Startup
    {
       
        public IConfiguration Configuration { get; }
        public bool ValidateIssuer { get; private set; }
        public bool ValidateAudience { get; private set; }
        public string ValidAudience { get; private set; }
        public string ValidIssuer { get; private set; }
        public SymmetricSecurityKey IssuerSigningKey { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
<<<<<<< HEAD
            //services.AddIdentity<ApplicationUser, IdentityRole>()
              // .AddEntityFrameworkStores<ApplicationDbContext>()
              //.AddDefaultTokenProviders();
            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                 opt.TokenLifespan = TimeSpan.FromHours(2));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            })
               .AddJwtBearer(options =>
               {
                   options.SaveToken = true;
                   options.RequireHttpsMetadata = false;
                   options.TokenValidationParameters = new TokenValidationParameters();
                   {
                       ValidateIssuer = true;
                       ValidateAudience = true;
                       ValidAudience = Configuration["JWT:ValidAudience"];
                       ValidIssuer = Configuration["JWT:ValidIssuer"];
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]));
                   }

               });

            services.AddControllers();
            services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CS")));
=======
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
>>>>>>> 6fc95b019d49c2f5dc1203fa14d86f7531d3c8be
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
            app.UseCors(options => options
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials()
                ); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
