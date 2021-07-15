using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Personal;
using Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController: ControllerBase
    {
        private readonly IMediator mediator;

        public PersonalController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonalEntity>>> ObtenerPersonal()
        {
            return await mediator.Send(new Consulta.Lista());
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Actualizar(Guid id, Editar.Ejecuta data)
        {
            data.PersonalId = id;
            return await mediator.Send(data);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await mediator.Send(new Eliminar.Ejecuta{Id = id});
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalEntity>> ObtenerPorId(Guid id)
        {
            return await mediator.Send(new ConsultaId.Ejecuta{Id = id});
        }
    }
}