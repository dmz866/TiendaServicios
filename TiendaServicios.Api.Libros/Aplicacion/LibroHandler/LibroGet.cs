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
    public class LibroGet
    {
        public class Request: IRequest<LibroDto>
        {
            public int LibroId { get; set; }
        }
        public class Handler: IRequestHandler<Request, LibroDto>
        {
            private readonly ContextoLibro _contexto;
            private readonly IMapper _mapper;
            public Handler(ContextoLibro contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<LibroDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var libro =  await _contexto.Libro.Where(l => l.LibroId == request.LibroId).FirstOrDefaultAsync();

                if(libro == null)
                {
                    throw new Exception("No se encuentra el libro");
                }

                var libroDto = _mapper.Map<Libro, LibroDto>(libro);
                return libroDto;
            }
        }
    }
}
