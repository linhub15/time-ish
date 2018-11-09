using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Environment.GetEnvironmentVariable("MYSQLCONNSTR_default");
            if (_connectionString == null)
            {
                _connectionString = Configuration.GetConnectionString("default");
            }
            if (_connectionString == null) 
            { 
                throw new Exception("Missing db connection string. Check environment variables or timeish-proxy/local.settings.json");
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

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => {
                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
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