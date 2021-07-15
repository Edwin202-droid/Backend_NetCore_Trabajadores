using System;
using System.Threading;
using System.Threading.Tasks;
using Data.ADOconexion.Hijos;
using FluentValidation;
using MediatR;

namespace Data.Hijos
{
    public class Actualizar
    {
        public class Ejecuta : IRequest
        {
            public Guid DerHabId { get; set; }
            public string ApPaterno { get; set; }
            public string ApMaterno { get; set; }
            public string Nombre1 { get; set; }
            public string Nombre2 { get; set; }
            public DateTime FechaNacimiento { get; set; }
        }

        public class EjecutaValida : AbstractValidator<Ejecuta>
        {
            public EjecutaValida()
            {
                RuleFor(x => x.ApPaterno).NotEmpty();
                RuleFor(x => x.ApMaterno).NotEmpty();
                RuleFor(x => x.Nombre1).NotEmpty();
                RuleFor(x => x.Nombre2).NotEmpty();
                RuleFor(x => x.FechaNacimiento).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly IHijos hijoRepositorio;

            public Manejador(IHijos hijoRepositorio)
            {
                this.hijoRepositorio = hijoRepositorio;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var resultado = await hijoRepositorio.ActualizarHijo(
                    request.DerHabId,
                    request.ApPaterno,
                    request.ApMaterno,
                    request.Nombre1,
                    request.Nombre2,
                    request.FechaNacimiento
                );

                if(resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo actualizar hijo");
            }
        }
        
    }
}