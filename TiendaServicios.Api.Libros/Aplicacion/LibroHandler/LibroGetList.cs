using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libros.Aplicacion.Dtos;
using TiendaServicios.Api.Libros.Modelo;
using TiendaServicios.Api.Libros.Persistencia;

namespace TiendaServicios.Api.Libros.Aplicacion.LibroHandler
{
    public class LibroGetList
    {
        public class Request: IRequest<List<LibroDto>>
        {
        }
        public class Handler: IRequestHandler<Request, List<LibroDto>>
        {
            private readonly ContextoLibro _contexto;
            private readonly IMapper _mapper;
            public Handler(ContextoLibro contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<LibroDto>> Handle(Request request, CancellationToken cancellationToken)
            {
                var libros = await _contexto.Libro.ToListAsync();
                var librosDto = _mapper.Map<List<Libro>, List<LibroDto>>(libros);
                return librosDto;
            }
        }
    }
}
