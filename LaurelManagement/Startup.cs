using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaurelManagement.Business.Abstract;
using LaurelManagement.Business.Services;
using LaurelManagement.Config;
using LaurelManagement.Data;
using LaurelManagement.Data.EntityFramework;
using LaurelManagement.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace LaurelManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<LaurelDbContext>(a => a.UseSqlServer(@"Server=.;Database=ReactDatabase; Trusted_Connection=true" ));
            services.AddMvc();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<ICustomerDal, EfCustomersDal>();
            services.AddScoped<IUserDal, EfUsersDal>();
            services.AddScoped<TokenAttribute>();
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder => builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
            });



            // JWT TOKEN 
            services.Configure<JwtConfig>(Configuration.GetSection("jwt"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = Configuration.GetValue<string>("jwt:Issuer"),
                    ValidateIssuer = true,
                    ValidIssuer = Configuration.GetValue<string>("jwt:Issuer"),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("jwt:secret")))

                };
            });

         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("MyPolicy");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Customer}/{action=GetList}");
            });


        }

    }
}
