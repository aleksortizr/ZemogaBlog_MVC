using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using LinqToDB;
using Blog_Repositories;
using Blog_BusinessLogic.Services;
using Blog_BusinessLogic;
using LinqToDB.Data;
using Blog_API.Configurations;

namespace ZemogaBlog_API
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

            services.AddSingleton<IDataContext, DataContext>();
            services.AddSingleton<ICommentsRepository, CommentsRepository>();
            services.AddSingleton<IUsersRepository, UserRepository>();
            services.AddSingleton<IPostsRepository, PostsRepository>();
            services.AddSingleton<IBlogUserManager, BlogUserManager>();
            services.AddSingleton<IBlogManager, BlogManager>();
            //services.AddSingleton<IPostManagerService, PostManagerService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            DataConnection.DefaultSettings = new LinqToDbSettingsDevelopment();
            app.UseDeveloperExceptionPage();

            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
        }
    }
}
