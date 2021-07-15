using System;
using System.Threading;
using System.Threading.Tasks;
using Data.ADOconexion.Hijos;
using Entity;
using MediatR;

namespace Data.Hijos
{
    public class TraerHijo
    {
        public class Ejecuta : IRequest<HijosEntity>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, HijosEntity>
        {
            private readonly IHijos hijosRepositorio;

            public Manejador(IHijos hijosRepositorio)
            {
                this.hijosRepositorio = hijosRepositorio;
            }
            public async Task<HijosEntity> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var hijo = await hijosRepositorio.TraerHijo(request.Id);
                if(hijo == null)
                {
                    throw new Exception("No se encontro al hijo");
                }
                return hijo;
            }
        }
    }
}