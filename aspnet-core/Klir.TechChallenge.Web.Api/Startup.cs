using AutoMapper;
using Klir.TechChallenge.AppService.Config;
using Klir.TechChallenge.Infrastructure.Configurator;
using Klir.TechChallenge.Repository.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KlirTechChallenge.Web.Api
{
    public class Startup
    {
        readonly string AllowSpecificOrigins = "_allowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ServiceConfigurator.ConfigureServices(services);
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<DataContext>(context => context.UseSqlite(Configuration.GetConnectionString("Default")));
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200")
                                             .WithMethods("GET", "POST", "PUT", "DELETE")
                                             .AllowAnyHeader();
                                  });
            });

            services.AddControllers();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfiguration());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(AllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
