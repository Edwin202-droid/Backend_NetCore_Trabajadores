using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Entity;

namespace Data.ADOconexion.Hijos
{
    public class HijosRepositorio : IHijos
    {
        private readonly IFactoryConnection factoryConnection;
        public HijosRepositorio(IFactoryConnection factoryConnection)
        {
            this.factoryConnection= factoryConnection;
        }

        public async Task<int> EliminarHijo(Guid id)
        {
            var store = "usp_hijos_eliminar";
            try
            {
                var connection = factoryConnection.GetDbConnection();
                var resultados = await connection.ExecuteAsync(
                    store,
                    new {
                        DerHabId = id
                    },
                    commandType: CommandType.StoredProcedure
                );
                factoryConnection.CloseConnection();
                return resultados;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo elimnar al personal",e);
            }
        }

        public async Task<int> NuevoHijo(string ApPaterno, string ApMaterno, string Nombre1, string Nombre2, Guid PersonalId, DateTime FechaNacimiento)
        {
            var store = "usp_Hijo_Nuevo";
            try
            {
                var connection = factoryConnection.GetDbConnection();
                var resultado = await connection.ExecuteAsync(store, new {
                    DerHabId = Guid.NewGuid(),
                    ApPaterno = ApPaterno,
                    ApMaterno = ApMaterno,
                    Nombre1 = Nombre1,
                    Nombre2= Nombre2,
                    PersonalId = PersonalId,
                    FechaNacimiento= FechaNacimiento
                },
                 commandType: CommandType.StoredProcedure   
                );

                factoryConnection.CloseConnection();
                return resultado;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo insertar dicho hijo", e);
            }
        }

        public async Task<int> ActualizarHijo(Guid DerHabId, string ApPaterno, string ApMaterno, string Nombre1, string Nombre2, DateTime FechaNacimiento)
        {
            var store = "usp_Hijo_Editar";
            try
            {
                var connection = factoryConnection.GetDbConnection();
                var resultados = await connection.ExecuteAsync(
                    store,
                    new{
                        DerHabId= DerHabId,
                        ApPaterno= ApPaterno,
                        ApMaterno= ApMaterno,
                        Nombre1= Nombre1,
                        Nombre2= Nombre2,
                        FechaNacimiento = FechaNacimiento
                    },
                    commandType: CommandType.StoredProcedure
                );
                factoryConnection.CloseConnection();
                return resultados;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo actualizar dicho hijo",e);
            }
        }

        public async Task<IEnumerable<HijosEntity>> ObtenerPorId(Guid id)
        {
            var store = "usp_obtenerId_hijos";
            IEnumerable<HijosEntity> hijos = null;
            try
            {
                var connection = factoryConnection.GetDbConnection();
                hijos = await connection.QueryAsync<HijosEntity>(
                    store,
                    new {
                        PersonalId = id
                    },
                    commandType: CommandType.StoredProcedure
                );
                return hijos;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo encontrar a los hijos del personal",e);
            }
            
        }

        public async Task<HijosEntity> TraerHijo(Guid id)
        {
            var store = "usp_traer_hijo";
            HijosEntity hijo = null;
            try
            {
                var connection = factoryConnection.GetDbConnection();
                hijo = await connection.QueryFirstAsync<HijosEntity>(
                    store,
                    new{
                        DerHabId = id
                    },
                    commandType: CommandType.StoredProcedure
                );
                return hijo;
            }
            catch (Exception e)
            {
                throw new Exception("No se encontro al hijo", e);
            }
        }
    }
}