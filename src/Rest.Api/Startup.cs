using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rest.DAL.Repository;
using Rest.Database;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Rest
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            
            // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
            builder.AddApplicationInsightsSettings(developerMode: true);

            Configuration = builder.Build();
            Console.WriteLine("started");
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);
            // Add framework services.
            services.AddMvc();
            services.AddSingleton<IDataStore, FakeDataStore>();
            services.AddSingleton<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\scripts")),
                RequestPath = new PathString("/scripts")
            });

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\pages")),
                RequestPath = new PathString("")
            });

            loggerFactory
                .WithFilter(new FilterLoggerSettings
                    {
                        { "Microsoft", LogLevel.Debug },
                        { "System", LogLevel.Debug },
                        { "Rest.Api", LogLevel.Debug }
                    })
                .AddConsole();
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();
            
            app.UseDeveloperExceptionPage();

            app.UseApplicationInsightsExceptionTelemetry();
        }
    }
}
