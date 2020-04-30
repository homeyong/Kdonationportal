using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetLearner.Blazor.Areas.Identity;
using NetLearner.Blazor.Data;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NetLearner.SharedLib.Models;

namespace NetLearner.Blazor
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
            services.AddDbContext<LibDbContext>(options =>
            {
                options
                   .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                      assembly =>
                      assembly.MigrationsAssembly
                         (typeof(LibDbContext).Assembly.FullName));
            });
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<LibDbContext>();

            //
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddHttpContextAccessor();
            services.AddScoped<HttpContextAccessor>();
            //

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddSingleton<WeatherForecastService>();

            services.AddTransient<ILearningResourceService, LearningResourceService>();
            services.AddTransient<IResourceListService, ResourceListService>();
            services.AddTransient<IDonationService, DonationService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // redirects to Error page in non-dev environment
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //
            app.UseCookiePolicy();
            //
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }


        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<LibDbContext>();
            context.Database.SetCommandTimeout(300);
            context.Database.Migrate();

            SeedSampleData(context);
        }

        private static void SeedSampleData(LibDbContext context)
        {
            if (!context.ResourceLists.Any())
            {
                context.ResourceLists.AddRange(
                               new ResourceList { Name = "Suppy" }
                           );
                context.SaveChanges();

                context.LearningResources.AddRange(
                    new LearningResource { Name = "Rice (10Kg)", Url = "https://images.reference.com/amg-cms-reference-images/media/many-cups-uncooked-rice-make-one-cup-cooked-rice_d59496a2bf3eafe8.jpg?width=760&height=411&fit=crop", Price = 20, ResourceListId = 1, ContentFeedUrl = "One Pack of White Rick (10Kg)"},
                    new LearningResource { Name = "Meat (2Kg)", Url = "https://img.etimg.com/thumb/width-640,height-480,imgsize-113532,resizemode-1,msid-72861899/protein-push-niti-aayog-mulls-pds-supply-of-eggs-fish-meat.jpg", Price = 50, ResourceListId = 1, ContentFeedUrl = "1KG of Chicken and 1KG of Fish" },
                    new LearningResource { Name = "Vege (2Kg)", Url = "https://peterrabbit.nz/wp-content/uploads/2016/02/fruit-vege-2.jpg", Price = 30, ResourceListId = 1, ContentFeedUrl = "1Kg of Apples, 1KG of Vegetable and 1Kg of Carrots" }
                );
                context.SaveChanges();
            }

        }
    }
}
