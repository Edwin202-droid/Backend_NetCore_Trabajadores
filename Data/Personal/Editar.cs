using System;
using System.Threading;
using System.Threading.Tasks;
using Data.ADOconexion.Personal;
using FluentValidation;
using MediatR;

namespace Data.Personal
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid PersonalId { get; set; }
            public string Dni { get; set; }
            public string ApPaterno { get; set; }
            public string ApMaterno { get; set; }
            public string Nombre1 { get; set; }
            public string Nombre2 { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public DateTime FechaIngreso { get; set; }
        }

        public class EjecutaValida : AbstractValidator<Ejecuta>
        {
            public EjecutaValida()
            {
                RuleFor(x => x.ApPaterno).NotEmpty();
                RuleFor(x => x.ApMaterno).NotEmpty();
                RuleFor(x => x.Nombre1).NotEmpty();
                RuleFor(x => x.Nombre2).NotEmpty();
                RuleFor(x => x.Dni).NotEmpty();
                RuleFor(x => x.FechaNacimiento).NotEmpty();
                RuleFor( x => x.FechaIngreso).NotEmpty();
            }
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
                var resultado = await personalRepositorio.ActualizarPersonal(
                    request.PersonalId,
                    request.Dni,
                    request.ApPaterno,
                    request.ApMaterno,
                    request.Nombre1,
                    request.Nombre2,
                    request.FechaNacimiento,
                    request.FechaIngreso
                );

                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo actualizar la data del personal");
            }
        }
    }
}