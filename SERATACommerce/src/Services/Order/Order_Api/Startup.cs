using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Order.PersistenceDataBase;
using Order.ProxyServices;
using Order.ProxyServices.Catolog;
using Product.QueryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Order_Api
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
            services.AddControllers();
            services.AddDbContext<AplicationDBContext>(opts =>
            opts.UseSqlServer(
                Configuration.GetConnectionString("DefaulConnection"),
                x => x.MigrationsHistoryTable("__EFMigrationHistory", "orders")));
            services.AddTransient<IProductQueryService, OrderQueryService>();
            services.AddHttpClient<ICatalogProxy, CatalogProxy>();
            services.AddMediatR(Assembly.Load("Order.ServiceEventHandlers"));

            services.Configure<ApiUrls>(opts => Configuration.GetSection("APiUrls").Bind(opts));
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
