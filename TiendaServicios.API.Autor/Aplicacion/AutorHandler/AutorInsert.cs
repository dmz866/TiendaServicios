using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autores.Persistencia;

namespace TiendaServicios.Api.Autores.Aplicacion.AutorHandler
{
    public class AutorInsert 
    {        
        public class Request : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }
        public class RequestValidation: AbstractValidator<Request>
        {
            public RequestValidation()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<Request>
        {
            private readonly ContextoAutor _contexto;

            public Handler(ContextoAutor contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                Modelo.Autor autor = new Modelo.Autor()
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento,
                    AutorGuid = Guid.NewGuid().ToString()
                };

                _contexto.Autor.Add(autor);
                var res = await _contexto.SaveChangesAsync();

                if (res > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el autor del libro");
            }
        }        
    }
}
