using Application.DTOs;
using Application.Repositories.MenuItemRepositories;
using Application.UseCases.MenuItemUseCases;
using Application.UseCases.OrderUseCases;
using Blazored.Toast;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Infrastructure;
using Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SelfOrderingClientUI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Blazored.SessionStorage;
using Syncfusion.Blazor;

namespace SelfOrderingClientUI
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
            services.AddBlazoredSessionStorage();

            services.AddDbContext<EntityFrameworkDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });

            //An object repository that has the framework implementation from the Infrastructure layer will be created
            services.AddScoped<IMenuItemRepository, SqliteDB>();
            services.AddScoped<IOrderRepository, SqliteDBOrdersContext>();
            //Use cases
            services.AddTransient<ICreateMenuItem, CreateMenuItem>();
            services.AddTransient<IGetMenuItemById, GetMenuItemById>();
            services.AddTransient<IGetAllMenuTypeMenuItems, GetAllMenuTypeMenuItems>();
            services.AddTransient<IChangeOrderAddMenuItem, ChangeOrderAddMenuItem>();
            services.AddTransient<ICreateOrder, CreateOrder>();

            services.AddScoped<OrderDTO>();

            services.AddBlazoredToast();

            services.AddBlazorise(options =>
              { options.ChangeTextOnKeyPress = true; })
              .AddBootstrapProviders()
              .AddFontAwesomeIcons();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
