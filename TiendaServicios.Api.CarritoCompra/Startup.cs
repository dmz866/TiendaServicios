using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TiendaServicios.Api.CarritoCompra.Aplicacion.CarritoCompraHandler;
using TiendaServicios.Api.CarritoCompra.InterfaceRemoto;
using TiendaServicios.Api.CarritoCompra.Persistencia;
using TiendaServicios.Api.CarritoCompra.ServiciosRemoto;
using Newtonsoft.Json;

namespace TiendaServicios.Api.CarritoCompra
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
            services.AddControllers();//.add(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<ContextoCarrito>(options => options.UseMySql(Configuration.GetConnectionString("DatabaseConexion")));
            services.AddMediatR(typeof(CarritoCompraInsert.Handler).Assembly);
            services.AddHttpClient("Libros", options => 
            {
                options.BaseAddress = new Uri(Configuration["Services:Libros"]);
            });
            services.AddHttpClient("Autores", options =>
            {
                options.BaseAddress = new Uri(Configuration["Services:Autores"]);
            });
            services.AddScoped<ILibroService, LibroService>();
            services.AddAutoMapper(typeof(CarritoCompraGet.Handler));
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
