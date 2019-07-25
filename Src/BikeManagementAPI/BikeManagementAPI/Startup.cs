using BikeManagementAPI.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BikeManagementAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly string Domain;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Domain = $"https://{Configuration["Auth0:Domain"]}/";
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddApplicationPart(typeof(Startup).Assembly);
            AddAuth0Authentication(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void AddAuth0Authentication(IServiceCollection services)
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