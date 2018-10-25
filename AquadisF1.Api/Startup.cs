using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AquadisF1.Model.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AquadisF1.Api
{
    public class Startup
    {
        public class AuthorizeMiddleware
        {
            private RequestDelegate _next;
            private AuthorizeOptions _options;

            public AuthorizeMiddleware(RequestDelegate next, AuthorizeOptions options)
            {
                _next = next;
                _options = options;
            }


            public async Task Invoke(HttpContext httpContext)
            {
                bool hasRole = false;
                if (hasRole)
                {
                    await httpContext.Response.WriteAsync($"Not authorized, you need role: {_options.Role}");     
                }
                else
                {
                    await _next(httpContext);
                }
            }

        }
        public struct AuthorizeOptions
        {
            public AuthorizeOptions(string role)
            {
                Role = role;
            }
            public string Role { get; set; }
        }

        private IRouter AuthenticatedRoutes(IApplicationBuilder applicationBuilder)
        {

            IRouteBuilder builder = new RouteBuilder(applicationBuilder);

            builder.MapMiddlewareGet("/api/values", appBuilder =>
            {
                appBuilder.UseMiddleware<AuthorizeMiddleware>(new AuthorizeOptions("User"));
                appBuilder.UseMvc();
            }).MapMiddlewarePost("/api/values", routeBuilder =>
                {
                    routeBuilder.UseMiddleware<AuthorizeMiddleware>(new AuthorizeOptions("User"));
                    routeBuilder.UseMvc();
                });
            return builder.Build();
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddTransient(s => new Factory.Factory(new Dictionary<Engine, string>
            {
                { Engine.MSSQL, Configuration.GetSection("ConnectionString")[Configuration.GetSection("Database")["MSSQL"]] }, 
                { Engine.Memory, null}
            }));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseRouter(AuthenticatedRoutes(app));
            
            app.UseMvc();
        }
     
    }
}