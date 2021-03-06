using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data;
using Marvel.Services.CastCrew;
using Marvel.Services.Movie;
using Marvel.Services.Team;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Marvel.WebAPI
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

            // var connectionString = Configuration.GetConnectionString("DefaultConnection");
            IConfigurationBuilder cBuilder = new ConfigurationBuilder().AddUserSecrets<Startup>();
            var config = cBuilder.Build();
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<MarvelDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddHttpContextAccessor();

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ICastCrewService, CastCrewService>();

            services.AddHttpsRedirection(options => options.HttpsPort = 443);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Marvel.WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marvel.WebAPI v1"));
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
