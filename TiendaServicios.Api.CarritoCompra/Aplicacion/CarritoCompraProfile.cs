using AutoMapper;
using TiendaServicios.Api.CarritoCompra.Aplicacion.Dtos;
using TiendaServicios.Api.CarritoCompra.Dtos;
using TiendaServicios.Api.CarritoCompra.Modelo;
using TiendaServicios.Api.CarritoCompra.ModeloRemoto;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class CarritoCompraProfile: Profile
    {
        public CarritoCompraProfile()
        {
            CreateMap<LibroRemoto, CarritoSesionDetalleDto>();
            CreateMap<CarritoSesion, CarritoSesionDto>();
            CreateMap<CarritoSesionDetalle, CarritoSesionDetalleDto>(); 
        }
    }
}
