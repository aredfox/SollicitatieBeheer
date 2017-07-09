using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OdeToCode.AddFeatureFolders;

namespace Beheerdersportaal.Api
{
    public class Startup
    {        
        public void ConfigureServices(IServiceCollection services)
        {
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
