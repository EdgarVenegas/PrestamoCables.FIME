using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PrestamoCables.FIME.Infraestructure;
using PrestamoCables.FIME.Mapper;
using PrestamoCables.FIME.Repository;
using PrestamoCables.FIME.Repository.IRepository;

namespace PrestamoCables.FIME
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
            //AutoMapper
            services.AddAutoMapper(typeof(UsuarioMapper));
            services.AddAutoMapper(typeof(CableMapper));
            services.AddAutoMapper(typeof(PrestamoMapper));
            //Referencia
            services.AddScoped<IUsuarioRepository,UsuarioRepository>();
            services.AddScoped<ICableRepository, CableRepository>();
            services.AddScoped<IPrestamoRepository, PrestamoRepository>();
            //Contexto
            services.AddDbContext<PrestamoCablesDbContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Controllers
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
