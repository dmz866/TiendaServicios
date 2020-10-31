using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autores.Aplicacion.Dtos;
using TiendaServicios.Api.Autores.Modelo;
using TiendaServicios.Api.Autores.Persistencia;

namespace TiendaServicios.Api.Autores.Aplicacion.AutorHandler
{
    public class AutorGet
    {
        public class Request: IRequest<AutorDto>
        {
            public string AutorGuid { get; set; }
        }
        public class Handler : IRequestHandler<Request, AutorDto>
        {
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;
            public Handler(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<AutorDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var autor = await _contexto.Autor.Where(autor => autor.AutorGuid == request.AutorGuid).FirstOrDefaultAsync();
                
                if (autor == null)
                {
                    throw new Exception("No se encontro el autor");
                }

                var autorDto = _mapper.Map<Autor, AutorDto>(autor);
                return autorDto;
            }
        }
    }
}
