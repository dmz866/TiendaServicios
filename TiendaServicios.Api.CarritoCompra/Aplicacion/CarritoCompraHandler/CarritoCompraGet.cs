using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Aplicacion.Dtos;
using TiendaServicios.Api.CarritoCompra.Dtos;
using TiendaServicios.Api.CarritoCompra.InterfaceRemoto;
using TiendaServicios.Api.CarritoCompra.Modelo;
using TiendaServicios.Api.CarritoCompra.ModeloRemoto;
using TiendaServicios.Api.CarritoCompra.Persistencia;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion.CarritoCompraHandler
{
    public class CarritoCompraGet
    {
        public class Request: IRequest<CarritoSesionDto>
        {
            public int CarritoSesionId { get; set; }
        }
        public class Handler : IRequestHandler<Request, CarritoSesionDto>
        {
            private readonly ContextoCarrito _contexto;
            private readonly ILibroService _libroService;
            private readonly IMapper _mapper;
            public Handler(ContextoCarrito contexto, ILibroService libroService, IMapper mapper)
            {
                _contexto = contexto;
                _libroService = libroService;
                _mapper = mapper;
            }
            public async Task<CarritoSesionDto> Handle(Request request, CancellationToken cancellationToken)
            {                
                var carritoSesion = await _contexto.CarritoSesion
                                    .FirstOrDefaultAsync(c => c.CarritoSesionId == request.CarritoSesionId);

                var carritoSesionDetalle = await _contexto.CarritoSesionDetalle
                                                        .Where(d => d.CarritoSesionId == request.CarritoSesionId)
                                                        .ToListAsync();
                var carritoSesionDto = _mapper.Map<CarritoSesion, CarritoSesionDto>(carritoSesion);

                foreach(var elemento in carritoSesionDetalle)
                {
                    var res = await _libroService.Get(elemento.LibroSeleccionado);
                    var libroDto = _mapper.Map<LibroRemoto, CarritoSesionDetalleDto>(res.Libro);

                    if (res.Resultado)
                    {
                        carritoSesionDto.ListaCarritoSesionDetalle.Add(libroDto);
                    }
                }


                return carritoSesionDto;
            }
        }
    }
}
