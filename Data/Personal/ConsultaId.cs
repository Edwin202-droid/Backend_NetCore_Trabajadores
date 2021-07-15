using System;
using System.Threading;
using System.Threading.Tasks;
using Data.ADOconexion.Personal;
using Entity;
using MediatR;

namespace Data.Personal
{
    public class ConsultaId
    {
        public class Ejecuta : IRequest<PersonalEntity>
        {
            public Guid Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, PersonalEntity>
        {
            private readonly IPersonal personalRepositorio;

            public Manejador(IPersonal personalRepositorio)
            {
                this.personalRepositorio = personalRepositorio;
            }

            public async Task<PersonalEntity> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var personal = await personalRepositorio.ObtenerPorId(request.Id);
                if(personal == null)
                {
                    throw new Exception("No se encontro el personal");
                }
                return personal;
            }
        }
    }
}