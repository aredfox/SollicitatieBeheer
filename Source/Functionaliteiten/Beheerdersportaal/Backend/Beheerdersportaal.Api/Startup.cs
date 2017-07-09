using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OdeToCode.AddFeatureFolders;
using Sollicitatiebeheer.Data.EFCore;

namespace Beheerdersportaal.Api
{
    public class Startup
    {        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SollicitatiebeheerDatabase>(
                ctx => ctx.UseSqlServer(new DefaultDbContextFactory().GetConnectionString()));
            services.AddMediatR();
            services                
                .AddMvc()
                .AddFeatureFolders(new FeatureFolderOptions
                {
                    FeatureFolderName = nameof(Beheerdersportaal.Api.Functionaliteiten)                    
                });
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app
                .UseMvc();
        }
    }
}
