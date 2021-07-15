using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity;

namespace Data.ADOconexion.Personal
{
    public interface IPersonal
    {
        Task<IEnumerable<PersonalEntity>> ObtenerLista();
        Task<PersonalEntity> ObtenerPorId(Guid id);
        Task<int> NuevoPersonal(string Dni, string ApPaterno, string ApMaterno, string Nombre1, string Nombre2, DateTime FechaNacimiento, DateTime FechaIngreso);
        Task<int> ActualizarPersonal(Guid PersonalId, string Dni, string ApPaterno, string ApMaterno, string Nombre1, string Nombre2, DateTime FechaNacimiento, DateTime FechaIngreso);
        Task<int> EliminarPersonal (Guid id);
    }
}