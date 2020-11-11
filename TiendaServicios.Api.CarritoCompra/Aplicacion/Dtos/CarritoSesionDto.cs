using System;
using System.Collections.Generic;
using TiendaServicios.Api.CarritoCompra.Aplicacion.Dtos;

namespace TiendaServicios.Api.CarritoCompra.Dtos
{
    public class CarritoSesionDto
    {
        public int CarritoSesionId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public ICollection<CarritoSesionDetalleDto> ListaCarritoSesionDetalle { get; set; }
    }
}
