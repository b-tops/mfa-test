using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Duende.IdentityServer.Models;
using MFATest.Repositories;


namespace MFATest
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryApiResources(new List<ApiResource>()
                    {
                        new ApiResource("api.sample", "Sample API")
                    })
                    .AddInMemoryClients(new List<Client>()
                    {
                        new Client
                        {
                            ClientId = "Authentication",
                            ClientSecrets =
                            {
                                new Secret("clientsecret".Sha256())
                            },
                            AllowedGrantTypes = { "authentication" },
                            AllowedScopes =
                            {
                                "api.sample"
                            },
                            AllowOfflineAccess = true
                        }
                    });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("MFATest")
            );

            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddMvc()
                    .AddControllersAsServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("default");
            app.UseIdentityServer();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
