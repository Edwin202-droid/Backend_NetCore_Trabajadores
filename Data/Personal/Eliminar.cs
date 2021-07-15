using System;
using System.Threading;
using System.Threading.Tasks;
using Data.ADOconexion.Personal;
using MediatR;

namespace Data.Personal
{
    public class Eliminar
    {
        public class Ejecuta: IRequest
        {
            public Guid Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly IPersonal personalRepositorio;

            public Manejador(IPersonal personalRepositorio)
            {
                this.personalRepositorio = personalRepositorio;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var resultados = await personalRepositorio.EliminarPersonal(request.Id);
                if(resultados > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo eliminar el personal");
            }
        }
    }
}