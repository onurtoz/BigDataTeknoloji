using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigDataTeknoloji.Business.Model.ExternalModel.DarkSKY;
using BigDataTeknoloji.Business.Model.ExternalModel.LocationIQ;
using BigDataTeknoloji.Business.Services.ExternalServices.DarkSKY;
using BigDataTeknoloji.Business.Services.ExternalServices.LocationIQ;
using BigDataTeknoloji.Business.Services.Message.Producer;
using BigDataTeknoloji.Business.Services.Message.Consumer;
using BigDataTeknoloji.Business.Services.Services.Cache;
using BigDataTeknoloji.Business.Services.Services.Weather;
using BigDataTeknoloji.Business.Services.WeatherDTO;
using BigDataTeknoloji.Data.Entity.Data;
using BigDataTeknolojiData.Repository.WeatherRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace BigDataTeknolojiWebApp
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
            services.AddMemoryCache();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            services.AddDbContext<ApplicationDbContext>
              (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.Configure<DarkSKYConfig>(Configuration.GetSection("darksky"));
            services.Configure<LocationIQConfig>(Configuration.GetSection("locationIq"));
            services.Configure<ProducerConfig>(Configuration.GetSection("kafka"));



            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IDarkSKYService, DarkSKYService>();
            services.AddScoped<IWeatherDTO, WeatherDTO>();
            services.AddScoped<ICacheService, CacheManager>();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IWeatherRepository, WeatherRepository>();
            services.AddScoped<IMessageProducer, MessageProducer>();
            services.AddScoped<IMessageConsumer, MesageConsumer>();
           
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

       
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
