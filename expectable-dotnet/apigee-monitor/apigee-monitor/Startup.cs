using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using apigee_monitor.Models;
using apigee_monitor.Repository;
using apigee_monitor.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace apigee_monitor
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Load Configuration to options
            services.Configure<List<Service>>(options =>
                Configuration.GetSection("Services:Service").Bind(options));
            services.Configure<List<Server>>(options =>
                Configuration.GetSection("Servers:Server").Bind(options));

            //add Interfaces and Implementations for for DI

            string username = Configuration["ApigeeCredential:Username"];
            string secret = Configuration["ApigeeCredential:Secret"];

            var auth = Convert.ToBase64String(Encoding.Default.GetBytes($"{username}:{secret}"));

            services.AddHttpClient("monitor", o =>
            {
                o.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
            });

            services.AddTransient<IMonitorService, MonitorService>();

            services.AddTransient<IServerRepository, ServerList>();
            // we could aslo use Repo with EF DBContext and configure DB
            // services.AddTransient<IServerRepository, ServerRespoitory>();

            services.AddTransient<IServiceRepository, ServiceList>();
            // we could aslo use Repo with EF DBContext and configure DB
            // services.AddTransient<IServiceRepository, ServiceRepository>();

            // Use implementation that will return random bool for service status
            services.AddTransient<IApigeeClient, ApigeeRandomClient>();
            // real implementation of apigee client to get service status
            // services.AddTransient<IApigeeClient, ApigeeClient>();

 

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
