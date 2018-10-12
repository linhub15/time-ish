using System;
using api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(); // Used for Development testing

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            // Prevent self reference exception when using LINQ to get a collection
                .AddJsonOptions(options => {
                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });


            services.AddDbContextPool<TimeishContext>(
                options => options.UseMySql(Configuration.GetConnectionString("MySqlProvider"),
                mySqlOptions => {
                    mySqlOptions.ServerVersion(new Version(8,0,12), ServerType.MySql);
                })
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                 // TODO: Remove in prod - For Development only
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

            app.UseStaticFiles();   // Allows wwwroot files to be served
            app.UseDefaultFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
            // ensures index.html is served for any requests with a path other than "/"
            // prevents 404 when user refreshes browser
            app.Use(async (context, next) => 
            {
                if (context.Request.Path.HasValue && context.Request.Path.Value != "/")
                {
                    context.Response.ContentType = "text/html";
                    await context.Response.SendFileAsync(
                        env.ContentRootFileProvider.GetFileInfo("wwwroot/index.html")
                    );
                    return;
                }
                await next();
            });
        }
    }
}
