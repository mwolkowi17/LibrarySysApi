using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySysApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LibrarySysApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibrarySysApiContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("LibrarySysApiContext")));
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder

                                             .WithOrigins("http://example.com",
                                                          "http://www.contoso.com",
                                                          "http://localhost:8080",
                                                          "https://localhost:44380/",
                                                          "https://localhost:5001")
                                             //.SetIsOriginAllowedToAllowWildcardSubdomains();
                                             .AllowAnyHeader()
                                             .AllowAnyMethod()
                                             .AllowCredentials()
                                             //.WithExposedHeaders("Token-Expired")
                                             .Build();
                                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            // dodana obs³uga cors
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
