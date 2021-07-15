using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Hijos;
using Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HijosController : ControllerBase
    {
        private readonly IMediator mediator;

        public HijosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<HijosEntity>>> ObtenerPorId(Guid id)
        {
            return await mediator.Send(new ConsultaId.Ejecuta{Id = id} );
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await mediator.Send(data);
        }
         
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Actualizar(Guid id, Actualizar.Ejecuta data)
        {
            data.DerHabId = id;
            return await mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await mediator.Send(new Eliminar.Ejecuta{Id = id});
        }
        [HttpGet("mostrar/{id}")]
        public async Task<ActionResult<HijosEntity>> TraerHijo(Guid id)
        {
            return await mediator.Send(new TraerHijo.Ejecuta{Id = id});
        }
    }
}