using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using VaultexTechTest.Data;

// https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio

namespace VaultexTechTest.WebAPI
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

            string cnString = Configuration.GetConnectionString("VaultexTestDB");
            services.AddDbContext<VaultexTechTestContext>(opt => opt
                    .UseSqlServer(cnString)
                    .EnableSensitiveDataLogging());

            services.AddScoped<VaultexTechTestContext, VaultexTechTestContext>();

            // Register Swagger generator for 1 or more documents.
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1",
                        new OpenApiInfo()
                        {
                            Title = "Vaultex Tech Test",
                            Description = "Created for the Vaultex Technical Test.",
                            Version = "v1",
                            Contact = new OpenApiContact()
                            {
                                Email = "jason.haughton@gmail.com",
                                Name = "Jason Haughton",
                                Url = new Uri("https://www.linkedin.com/in/jasonhaughton/")
                            }
                        });
                }
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve the generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable the middleware to server Swagger-UI ( HTML, CSS, JS etc...) specifying the swagger endpoint.
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                    c.RoutePrefix = string.Empty; // To server the swagger ui from the root url rather than the default url of /swagger.
                }
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
