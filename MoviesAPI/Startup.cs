using AutoMapper;
using DataAccess.Contract;
using DataAccess.Implementation;
using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO;
using Infrastructure.Implementation;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI
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

            services.AddControllers();
            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MoviesAPI", Version = "v1" });
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Movies, MoviesDTO>()
                    .ForMember(p => p.TitleMovie, org => org.MapFrom(p => p.Title.ToUpper()))
                    .ForMember(p => p.DescriptionMovie, org => org.MapFrom(p => p.Description.ToLower()));
                //mc.AddProfile();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IActorsDataAccess, ActorsDataAccess>();
            services.AddScoped<IGenresDataAccess, GenresDataAccess>();
            services.AddScoped<IMoviesActorsDataAccess, MoviesActorsDataAccess>();
            services.AddScoped<IMoviesDataAccess, MoviesDataAccess>();
            services.AddScoped<IAwardsDataAccess, AwardsDataAccess>();
            services.AddScoped<IMoviesInfrastructure, MoviesInfrastructure>();
            services.AddScoped<IAwardsInfrastructure, AwardsInfrastructure>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SQL")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MoviesAPI v1"));
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
