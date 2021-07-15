using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data.ADOconexion.Personal;
using Entity;
using MediatR;

namespace Data.Personal
{
    public class Consulta
    {
        public class Lista : IRequest<List<PersonalEntity>>{}

        public class Manejador : IRequestHandler<Lista, List<PersonalEntity>>
        {
            private readonly IPersonal personalRepository;

            public Manejador(IPersonal personalRepository)
            {
                this.personalRepository = personalRepository;
            }
            public async Task<List<PersonalEntity>> Handle(Lista request, CancellationToken cancellationToken)
            {
                var resultado = await personalRepository.ObtenerLista();
                return resultado.ToList();
            }
        }
    }
}