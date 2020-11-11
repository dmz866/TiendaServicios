using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Modelo;
using TiendaServicios.Api.CarritoCompra.Persistencia;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion.CarritoCompraHandler
{
    public class CarritoCompraInsert
    {
        public class Request: IRequest
        {
            public DateTime? FechaCreacion { get; set; }
            public ICollection<int> ListaLibroSeleccionado { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly ContextoCarrito _contexto;
            public Handler(ContextoCarrito contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var carritoSesion = new CarritoSesion() 
                {
                    FechaCreacion = request.FechaCreacion ?? DateTime.Now
                };

                _contexto.CarritoSesion.Add(carritoSesion);
                var result = await _contexto.SaveChangesAsync();

                if(result < 1)
                {
                    throw new Exception("Error al crear carrito de compra");
                }

                foreach(var elemento in request.ListaLibroSeleccionado)
                {
                    var carritoSesionDetalle = new CarritoSesionDetalle()
                    {
                        FechaCreacion = DateTime.Now,
                        LibroSeleccionado = elemento,
                        CarritoSesionId = carritoSesion.CarritoSesionId
                    };

                    _contexto.CarritoSesionDetalle.Add(carritoSesionDetalle);
                }

                var result2 = await _contexto.SaveChangesAsync();

                if (result2 < 1)
                {
                    throw new Exception("Error al crear carrito de compra detalles");
                }

                return Unit.Value;
            }
        }
    }
}
