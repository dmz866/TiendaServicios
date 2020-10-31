using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libros.Modelo;
using TiendaServicios.Api.Libros.Persistencia;

namespace TiendaServicios.Api.Libros.Aplicacion.LibroHandler
{
    public class LibroInsert
    {
        public class Request: IRequest
        {
            public string Titulo { get; set; }
            public DateTime? FechaPublicacion { get; set; }
            public Guid? Autor { get; set; }
        }
        public class Handler : IRequestHandler<Request>
        {
            private readonly ContextoLibro _contexto;
            public Handler(ContextoLibro contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var libro = new Libro() 
                {
                    Titulo = request.Titulo,
                    FechaPublicacion = request.FechaPublicacion,
                    Autor = request.Autor
                };
                 _contexto.Libro.Add(libro);
                var res = await _contexto.SaveChangesAsync();
                
                if(res > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se puede crear un libro");
            }
        }
    }
}
