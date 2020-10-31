using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autores.Aplicacion.Dtos;
using TiendaServicios.Api.Autores.Persistencia;

namespace TiendaServicios.Api.Autores.Aplicacion.AutorHandler
{
    public class AutorGetList
    {        
        public class Request : IRequest<List<AutorDto>>
        {
        }

        public class Handler : IRequestHandler<Request, List<AutorDto>>
        {
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;
            public Handler(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<AutorDto>> Handle(Request request, CancellationToken cancellationToken)
            {
                var autores = await _contexto.Autor.ToListAsync();
                var autoresDto = _mapper.Map<List<Modelo.Autor>, List<AutorDto>>(autores);
                return autoresDto;
            }
        }
    }
}
