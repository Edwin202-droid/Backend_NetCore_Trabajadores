using System;
using System.Threading;
using System.Threading.Tasks;
using Data.ADOconexion.Hijos;
using FluentValidation;
using MediatR;

namespace Data.Hijos
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string ApPaterno { get; set; }
            public string ApMaterno { get; set; }
            public string Nombre1 { get; set; }
            public string Nombre2 { get; set; }
            public Guid PersonalId { get; set; }
            public DateTime FechaNacimiento { get; set; }
        }

        public class EjecutaValida : AbstractValidator<Ejecuta>
        {
            public EjecutaValida()
            {
                RuleFor( x=> x.ApPaterno).NotEmpty();
                RuleFor( x=> x.ApMaterno).NotEmpty();
                RuleFor( x=> x.Nombre1).NotEmpty();
                RuleFor( x=> x.Nombre2).NotEmpty();
                RuleFor( x=> x.FechaNacimiento).NotEmpty();
            }
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
                var resultado =  await hijosRepositorio.NuevoHijo(
                    request.ApPaterno,
                    request.ApMaterno,
                    request.Nombre1,
                    request.Nombre2,
                    request.PersonalId,
                    request.FechaNacimiento
                );

                if(resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar al hijo");
            }
        }
    }
}