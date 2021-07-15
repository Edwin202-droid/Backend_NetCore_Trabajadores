using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Data.ADOconexion.Hijos;
using Entity;
using MediatR;
using System.Linq;

namespace Data.Hijos
{
    public class ConsultaId
    {
        public class Ejecuta : IRequest<List<HijosEntity>>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, List<HijosEntity>>
        {
            private readonly IHijos hijosRepositorio;

            public Manejador(IHijos hijosRepositorio)
            {
                this.hijosRepositorio = hijosRepositorio;
            }

            public async Task<List<HijosEntity>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var resultado = await hijosRepositorio.ObtenerPorId(request.Id);
                return resultado.ToList();
            }
        }
    }
}