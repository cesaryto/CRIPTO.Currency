using Currency.Database;
using Currency.Service.Queries;
using Currrency.Proxies;
using Currrency.Proxies.Currency;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Currency.Api
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
            // DbContext
            services.AddDbContext<ApplicationDbContext>(opts =>
               opts.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection"),
                   x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Currency")
                   )
               );
            services.Configure<ApiUrls>(
                opts => Configuration.GetSection("ApiUrls").Bind(opts)
                );

            // Event handlers
            services.AddMediatR(Assembly.Load("Currency.Service.EventHandlers"));

            // Query services
            services.AddHttpClient<ICurrencyProxy, CurrencyProxy>();
            services.AddTransient<ICurrencyService, CurrencyQueryService>();
            services.AddTransient<ICurrencyDbQueryService, CurrencyDbQueryService>();

            // API Controllers
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
