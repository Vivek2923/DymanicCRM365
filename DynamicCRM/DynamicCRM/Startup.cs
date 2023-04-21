using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using UoPeople.NGPortal.Service.Repository.MSDynamics;
using UoPeople.NGPortal.Service.Repository.MSDynamics.Connection;
using UoPeople.NGPortal.Service.Settings;
using UoPeople.NGPortal.Utility;

namespace UoPeople.NGPortal.Service
{
    public class Startup
    {
        private const string AllowedOriginSetting = "AllowedOrigin";
        public IConfiguration Configuration { get; }

        private ServiceSettings serviceSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        /***-------
        This methid is responsible for registering and configuring the various services required by the application.

        The code inside the method performs the following actions:
        Reads the ServiceSettings section from the appsettings.json file and binds it to the ServiceSettings class.
        Registers the required services for controllers, HTTP context accessor, and Swagger documentation generation.
        Configures localization options for the application, including supported cultures and date/time formats.
        Adds memory cache to the DI container.
        Registers various services as singletons with the DI container, including cache services, database context, and repository classes.
        Configures a CORS policy to allow requests from all origins.*/
        public void ConfigureServices(IServiceCollection services)
        {
            serviceSettings = Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });
            services.AddHttpContextAccessor();

            // Configure localization options.
            services.Configure<RequestLocalizationOptions>(options =>
            {
                // Set supported cultures (replace with your own).
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                };

                // Set default culture.
                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");

                // Configure supported cultures.
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                // Configure the date and time formats
                var enCulture = new CultureInfo("en-US");
                enCulture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
                enCulture.DateTimeFormat.LongTimePattern = "hh:mm:ss tt";
                CultureInfo.DefaultThreadCurrentCulture = enCulture;
                CultureInfo.DefaultThreadCurrentUICulture = enCulture;
            });


            // Add services as singletons.
            services.AddMemoryCache();
            
            services.AddSingleton<IDynamicsConnectionManager, DynamicsConnectionManager>();
            services.AddSingleton<IDynamicsRepository, DynamicsRepository>();
            services.AddSingleton<INGPortalCommonService, NGPortalCommonService>();
            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "UoPeople NGPortal Experience Layer MS", Version = "v1" });
            });

            // Add CORS policy for allowing all origins.
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder.AllowAnyOrigin()
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UoPeople NGPortal Experience Layer MicroService (v1)"));
                app.UseCors("AllowAllOrigins");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseCors("AllowAll");
        }

    }
}
