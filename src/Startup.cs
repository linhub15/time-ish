using System;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

using Tymish.Core.Entities;
using Tymish.Infrastructure.DataAccess;
using Tymish.Core.Interfaces;
using Tymish.Core.UseCases;

namespace Tymish
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Environment.GetEnvironmentVariable("MYSQLCONNSTR_default");
            if (_connectionString == null)
            {
                throw new Exception("Missing db connection string. Check environment variables in PROD or .vscode/launch.json in DEV");
            }

        }

        public IConfiguration Configuration { get; }
        private string _connectionString { get; } 

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(); // Used for Development testing
            
            services.AddDbContextPool<TimeishContext>(
                options => options.UseMySql(_connectionString));

            services.AddIdentity<IdentityUser,IdentityRole>()
                .AddEntityFrameworkStores<TimeishContext>()
                .AddDefaultTokenProviders();

              // ===== Add Jwt Authentication ========
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            
            services.AddDbContextPool<TimeishContext>(
                options => options.UseMySql(_connectionString));
                
            services.AddScoped<IRepository, EfCoreRepository>();

            // Use Case Dependency Injection
            services.AddScoped<IGetEmployee, GetEmployee>();
            services.AddScoped<IListEmployees, ListEmployees>();
            services.AddScoped<IAddEmployee, AddEmployee>();
            services.AddScoped<IUpdateEmployee, UpdateEmployee>();
            services.AddScoped<IDeleteEmployee, DeleteEmployee>();

            services.AddScoped<IListTimeSheets, ListTimeSheets>();
            services.AddScoped<IGetTimeSheet, GetTimeSheet>();
            services.AddScoped<IAddTimeSheet, AddTimeSheet>();
            services.AddScoped<IUpdateTimeSheet, UpdateTimeSheet>();
            services.AddScoped<IDeleteTimeSheet, DeleteTimeSheet>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TimeishContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

            context.Database.EnsureCreated();
        }
    }
}