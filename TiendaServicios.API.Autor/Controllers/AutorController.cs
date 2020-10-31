using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Autores.Aplicacion.AutorHandler;
using TiendaServicios.Api.Autores.Aplicacion.Dtos;

namespace TiendaServicios.Api.Autores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<AutorDto>>> GetList()
        {
            return await _mediator.Send(new AutorGetList.Request());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> Get(string id)
        {
            return await _mediator.Send(new AutorGet.Request() { AutorGuid = id });
        }
        [HttpPost] 
        public async Task<ActionResult<Unit>> Insert(AutorInsert.Request data)
        {
            return await _mediator.Send(data);
        }
    }
}
