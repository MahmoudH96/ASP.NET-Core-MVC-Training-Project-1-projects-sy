using ChefBox.Cooking.Data.Repositories;
using ChefBox.Cooking.IData.Interfaces;
using ChefBox.Security.Data.Repositories;
using ChefBox.Security.IData.Interfaces;
using ChefBox.SharedKernal.Configs;
using ChefBox.SqlServer.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ChefBox.Logging.IService.Interfaces;
using ChefBox.Logging.Service.Serilog;
using ChefBox.Model.Security;

namespace ChefBox.AdminUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<ISharedRepository, SharedRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddSingleton<ILogService, SerilogService>();

            services.AddDbContext<ChefBoxDbContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<CBUser, CBRole>()
                .AddEntityFrameworkStores<ChefBoxDbContext>();


            services.Configure<PageSettings>(Configuration.GetSection("pageSettings"));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env
            , ILoggerFactory loggerFactory
            , IApplicationLifetime appLifetime
            , ILogService logService)
        {
            logService.ConfigureCloudLog(appLifetime, loggerFactory);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
