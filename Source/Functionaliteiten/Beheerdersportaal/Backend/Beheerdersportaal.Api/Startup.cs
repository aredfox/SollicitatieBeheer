using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Beheerdersportaal.Api.Infrastructuur.Controllers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OdeToCode.AddFeatureFolders;
using Sollicitatiebeheer.Data.EFCore;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Linq;
using System.Reflection;

namespace Beheerdersportaal.Api
{
    public class Startup
    {
        private IContainer ApplicationContainer { get; set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // MIDDLEWARE
            services.AddCors();
            services.AddDbContext<SollicitatiebeheerDatabase>(
                ctx => ctx.UseSqlServer(new DefaultDbContextFactory().GetConnectionString()));
            services.AddMediatR();
            services                
                .AddMvc()
                .AddControllersAsServices()
                .AddFeatureFolders(new FeatureFolderOptions
                {
                    FeatureFolderName = nameof(Beheerdersportaal.Api.Functionaliteiten)                    
                });
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Info { Title = "Sollicitatiebeheer API", Version = "v1" });
                config.DescribeAllEnumsAsStrings();                
            });


            // DI
            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t =>
                    typeof(BaseController).IsAssignableFrom(t)
                    && !t.IsAbstract && !t.IsInterface
                    && t.Name.EndsWith("Controller"))
                .PropertiesAutowired();

            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowCredentials();
                builder.WithOrigins("http://localhost:4200");                
            });

            app.UseSwagger();            
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sollicitatiebeheer API v1");                
            });

            app.UseMvc();            
        }
    }
}
