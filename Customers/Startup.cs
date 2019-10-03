using Customers.Infrastructure.DependencyBuilder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Customers.Authentication;
using Customers.Objects.Extensions;
using Customers.Objects.Objects;
using Customers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Customers
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            
            var developmentFolder = env.IsDevelopment() ? env.ContentRootPath + @"\BuilderDev\" : "";
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                
                //.AddJsonFile($"connectionstrings{(env.IsDevelopment() ? "_development" : "")}.json", false, true)
                .AddJsonFile($"connectionstrings.json", false, true)
                .AddJsonFile("apisecuritysettings.json", false, true)
                .AddEnvironmentVariables();

            EnvironmentExtensions.EnvironmentName = env.EnvironmentName;

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Authentication
                services.AddAuthenticationService(Configuration.BindSettings<ApiSecuritySettings>(Constants.ApiSecuritySettingsSectionName));
            // Add framework services.


            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // DI
            DependencyBuilder.AddDependencies(services, Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Applications API", Version = "v2" });
                c.DescribeAllEnumsAsStrings();
                c.AddSecurityDefinition("basic", new BasicAuthScheme { Type = "basic", Description = "Basic HTTP Authentication" });
                c.DocumentFilter<SecurityRequirementsDocumentFilter>();
            });

            services.ConfigureSwaggerGen(options =>
            {
                options.CustomSchemaIds(x => x.FullName);
            });

            #region New AutoMapper configuration 2.2
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new ObjectProfile());
            //    mc.AddProfile(new ModelProfile());
            //});

            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);
            #endregion

            #region New Logging builder 2.2
            //services.AddLogging(loggingBuilder =>
            //{
            //    loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
            //    loggingBuilder.AddConsole();
            //    loggingBuilder.AddDebug();
            //});
            #endregion

            //services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            app.UseAuthentication();
            //app.UseCors(builder => builder.AllowAnyHeader()
            //                              .AllowAnyMethod()
            //                              .AllowAnyOrigin());
            

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Applications API V2");
            });
            app.UseMvc();
        }
    }
}
