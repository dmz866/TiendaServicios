using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaServicios.Api.Libros.Aplicacion.Dtos;
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
        [HttpGet]
        public async Task<ActionResult<List<LibroDto>>> GetList()
        {
            return await _mediator.Send(new LibroGetList.Request());
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Insert(LibroInsert.Request data)
        {
            return await _mediator.Send(data);
        }
    }
}
