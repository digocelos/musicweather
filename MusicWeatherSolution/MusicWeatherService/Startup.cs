using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MusicWeatherService.Services;
using MusicWeatherService.Services.OpenWeatherMap;
using MusicWeatherService.Services.Spotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeatherService
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
            services.AddScoped<IMusicaService, SpotifyService>();
            services.AddScoped<ITemperaturaService, OpenWeatherMapService>();
            services.AddScoped<ITemperaturaMusicalService, TemperaturaMusicalService>();

            services.AddControllers();
            services.AddHttpClient("OpenWeatherMap", client =>
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/weather");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
            });
            services.AddHttpClient("Spotify");
            services.AddSwaggerGen(s => {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Music Weather Service",
                    Description = "Temperatura musical"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger(s =>
            {
                s.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicWeatherService");
            });

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
