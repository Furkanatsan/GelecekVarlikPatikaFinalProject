using Apmasy.Bll;
using Apmasy.Dal.Abstract;
using Apmasy.Dal.Concrete.EntityFramework.Context;
using Apmasy.Dal.Concrete.EntityFramework.Repository;
using Apmasy.Dal.Concrete.EntityFramework.UnitOfWork;
using Apmasy.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

namespace Apmasy.API
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
            #region JwtTokenService
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer=true,
                        ValidateAudience=true,
                        ValidIssuer=Configuration["Tokens:Issuer"],
                        ValidAudience=Configuration["Tokens:Audience"],
                        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                        RequireSignedTokens=true,
                        RequireExpirationTime=true,
                    };
                });
            #endregion

            #region ApplicationContext
            services.AddDbContext<ApmasyDbContext>(ob => ob.UseSqlServer(Configuration.GetConnectionString("SqlBaglantim")));
            services.AddScoped<DbContext, ApmasyDbContext>();
            #endregion

            #region ServiceSection
            services.AddScoped<IApartmentService,ApartmentManager>();
            services.AddScoped<IBillPaymentService,BillPaymentManager>();
            services.AddScoped<IUserService,UserManager>();
            services.AddScoped<IMessageService,MessageManager>();
            #endregion

            #region RepositorySection
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IBillPaymentRepository, BillPaymentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            #endregion

            #region UnitOFwork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Apmasy.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Apmasy.API v1"));
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
