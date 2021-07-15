using System;
using System.Threading;
using System.Threading.Tasks;
using Data.ADOconexion.Hijos;
using MediatR;

namespace Data.Hijos
{
    public class Eliminar
    {
        public class Ejecuta: IRequest
        {
            public Guid Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly IHijos hijosRepositorio;

            public Manejador(IHijos hijosRepositorio)
            {
                this.hijosRepositorio = hijosRepositorio;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var resultados = await hijosRepositorio.EliminarHijo(request.Id);
                if(resultados > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo eliminar al hijo");
            }
        } 
    }
}