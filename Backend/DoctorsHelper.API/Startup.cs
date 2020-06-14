using System.Reflection;
using AutoMapper;
using AutoMapper.Configuration;
using DoctorsHelper.API.Initialization.ConfigureApplication;
using DoctorsHelper.API.Initialization.ConfigureServices;
using DoctorsHelper.ArterialPressure.BL;
using DoctorsHelper.Calculators.BL;
using DoctorsHelper.Dictionaries.BL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleInjector;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace DoctorsHelper.API
{
    //TODO: Move long registrations of services to separate class
    public class Startup
    {
        private Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            // Set to false. This will be the default in v5.x and going forward.
            container.Options.ResolveUnregisteredConcreteTypes = false;

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistence(Configuration);
            services.AddIdentity();

            services.AddControllers();

            services.AddSwagger();

            services.AddLogging();
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddSimpleInjectorCore(container);
            
            services.AddCors();
            services.AddJwt(Configuration);

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(x => {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });

            services.AddAutoMapper((provider, expression) => expression.AddDictionariesAutoMapperConfiguration()
                .AddArterialPressureAutoMapperConfiguration(), typeof(Startup).Assembly);

            services.AddCalculatorsBusinessLogic(container);
            services.AddDictionariesBusinessLogic(container);
            services.AddArterialPressureBusinessLogic(container,Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
                app.UseHttpsRedirection();

            app.UseExceptionHandlerWithJsonResponse();

            // подключаем  CORS
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
