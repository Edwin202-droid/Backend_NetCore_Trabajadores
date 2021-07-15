using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity;

namespace Data.ADOconexion.Hijos
{
    public interface IHijos
    {
        Task<IEnumerable<HijosEntity>> ObtenerPorId(Guid id);
        Task<HijosEntity> TraerHijo(Guid id);
        Task<int> NuevoHijo(string ApPaterno, string ApMaterno, string Nombre1, string Nombre2, Guid PersonalId, DateTime FechaNacimiento);
        Task<int> ActualizarHijo(Guid DerHabId, string ApPaterno, string ApMaterno, string Nombre1, string Nombre2, DateTime FechaNacimiento);
        Task<int> EliminarHijo(Guid id);

    }
}