using Blog_API.Configurations;
using Blog_BusinessLogic;
using Blog_BusinessLogic.Services;
using Blog_MVC.Services;
using Blog_Repositories;
using LinqToDB;
using LinqToDB.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blog_MVC
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
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/auth/login";
                    options.AccessDeniedPath = "/auth/accessdenied";

                })
                .AddCookie("TempCookie");

            services.AddSingleton<IDataContext, DataContext>();
            services.AddSingleton<ICommentsRepository, CommentsRepository>();
            services.AddSingleton<IUsersRepository, UserRepository>();
            services.AddSingleton<IPostsRepository, PostsRepository>();
            services.AddSingleton<IBlogUserManager, BlogUserManager>();
            services.AddSingleton<IBlogManager, BlogManager>();
            services.AddSingleton<IPostManagerService, PostManagerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                DataConnection.DefaultSettings = new LinqToDbSettingsDevelopment();
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
