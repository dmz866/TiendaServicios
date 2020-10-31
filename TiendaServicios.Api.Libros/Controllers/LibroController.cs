using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TiendaServicios.Api.Libros.Aplicacion.LibroHandler;

namespace TiendaServicios.Api.Libros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LibroController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Insert(LibroInsert.Request data)
        {
            return await _mediator.Send(data);
        }
    }
}
