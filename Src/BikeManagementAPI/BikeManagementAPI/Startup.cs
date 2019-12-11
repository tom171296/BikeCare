using BikeManagementAPI.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace BikeManagementAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly string Domain;
        private const string SERVICENAME = "BikeManagement";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Domain = $"https://{Configuration["Auth0:Domain"]}/";
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();
            AddAuth0Authentication(services);
            AddSwagger(services);
            services.AddHttpClient();
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = SERVICENAME,
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Tom van den Berg",
                        Email = "mail@here.com",
                        Url = new Uri("https://github.com/tom171296")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", SERVICENAME);
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();
            app.UseHttpsRedirection();
        }

        protected virtual void AddAuth0Authentication(IServiceCollection services)
        {
            AddAuthentication(services);
            AddPolicies(services);

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
        }

        private void AddPolicies(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:bike", policy => policy.Requirements.Add(new HasScopeRequirement("read:bike", Domain)));
            });
        }

        private void AddAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Domain;
                options.Audience = Configuration["Auth0:ApiIdentifier"];
            });
        }
    }
}