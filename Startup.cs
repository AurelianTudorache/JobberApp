using System;
using System.Text;
using JobberApp.Data;
using JobberApp.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using JobberApp.Repositories;
using JobberApp.Contracts;
using JobberApp.ViewModels;
using JobberApp.Services;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using JobberApp.SignalRHub;

namespace JobberApp
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
            ));           

            services.AddAutoMapper();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddScoped<IGenericRepository, GenericRepository<ApplicationDbContext>>();
            services.AddScoped<ISkillService<SkillViewModel>, SkillService>();
            services.AddScoped<IEmployerService<EmployerViewModel,SaveEmployerModel>, EmployerService>();
            services.AddScoped<ILocationService<LocationViewModel,SaveLocationModel>, LocationService>();
            services.AddScoped<ICardService<CardViewModel,SaveCardModel>, CardService>();
            services.AddScoped<IJobAdService<JobAdViewModel,SaveJobAdModel>, JobAdService>();
            services.AddEntityFrameworkSqlServer();


            // Add ASP.NET Identity support
            services.AddIdentity<ApplicationUser, IdentityRole>(opts =>
            {
                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = true;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequiredLength = 7;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            // Add Authentication
            services.AddAuthentication(opts => 
            {
                opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Add Jwt token support
            .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    // standard configuration
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Auth:Jwt:Key"])),
                    ValidateIssuerSigningKey = true,
                    
                    ValidIssuer = Configuration["Auth:Jwt:Issuer"],
                    ValidateIssuer = true,

                    ValidAudience = Configuration["Auth:Jwt:Audience"],
                    ValidateAudience = true,

                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero,

                };
                cfg.IncludeErrorDetails = true;
            });        
            
            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            

            app.UseHttpsRedirection();       

            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();

            app.UseSignalR(routes =>
            {            
                routes.MapHub<CommsHub>("/messages");    
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });            
        }
    }
}
