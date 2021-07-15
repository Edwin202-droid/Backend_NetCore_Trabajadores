using System.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Entity;

namespace Data.ADOconexion.Personal
{
    public class PersonalRepositorio : IPersonal
    {
        private readonly IFactoryConnection factoryConnection;
        public PersonalRepositorio(IFactoryConnection factoryConnection)
        {
            this.factoryConnection= factoryConnection;
        }

        public async Task<int> ActualizarPersonal(Guid PersonalId, string Dni, string ApPaterno, string ApMaterno, string Nombre1, string Nombre2, DateTime FechaNacimiento, DateTime FechaIngreso)
        {
            var store = "usp_personal_editar";
            try
            {
                var connection = factoryConnection.GetDbConnection();
                var resultados = await connection.ExecuteAsync(
                    store,
                    new{
                        PersonalId= PersonalId,
                        Dni=Dni,
                        ApPaterno= ApPaterno,
                        ApMaterno= ApMaterno,
                        Nombre1= Nombre1,
                        Nombre2= Nombre2,
                        FechaNacimiento = FechaNacimiento,
                        FechaIngreso = FechaIngreso
                    },
                    commandType: CommandType.StoredProcedure
                );
                factoryConnection.CloseConnection();
                return resultados;
            }
            catch(Exception e)
            {
                throw new Exception("No se pudo editar la data del personal",e );
            }
        }

        public async Task<int> EliminarPersonal(Guid id)
        {
            var store = "usp_personal_eliminar";
            try
            {
                var connection = factoryConnection.GetDbConnection();
                var resultados = await connection.ExecuteAsync(
                    store,
                    new {
                        PersonalId = id
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

        public async Task<int> NuevoPersonal(string Dni, string ApPaterno, string ApMaterno, string Nombre1, string Nombre2, DateTime FechaNacimiento, DateTime FechaIngreso)
        {
            var store = "usp_Personal_Nuevo";
            try
            {
                var connection = factoryConnection.GetDbConnection();
                var resultado = await connection.ExecuteAsync(store, new {
                    PersonalId = Guid.NewGuid(),
                    Dni=Dni,
                    ApPaterno = ApPaterno,
                    ApMaterno = ApMaterno,
                    Nombre1 = Nombre1,
                    Nombre2= Nombre2,
                    FechaNacimiento= FechaNacimiento,
                    FechaIngreso= FechaIngreso
                },
                 commandType: CommandType.StoredProcedure   
                );

                factoryConnection.CloseConnection();
                return resultado;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo insertar el nuevo personal", e);
            }
            
        }

        public async Task<IEnumerable<PersonalEntity>> ObtenerLista()
        {
            IEnumerable<PersonalEntity> personalLista = null;
            var store = "usp_Obtener_Personal";
            try
            {
                var connection = factoryConnection.GetDbConnection();
                personalLista = await connection.QueryAsync<PersonalEntity>(store, null, commandType: CommandType.StoredProcedure);

            }
            catch (Exception e)
            {
               throw new Exception("Error en la consulta de datos", e);
            }
            finally
            {
                factoryConnection.CloseConnection();
            }
            return personalLista;
        }

        public async Task<PersonalEntity> ObtenerPorId(Guid id)
        {
            var store = "usp_obtenerId_personal";
            PersonalEntity personal = null;
            try
            {
                var connection = factoryConnection.GetDbConnection();
                personal = await connection.QueryFirstAsync<PersonalEntity>(
                    store,
                    new {
                        PersonalId = id
                    },
                    commandType: CommandType.StoredProcedure
                );
                return personal;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo encontrar al personal",e);
            }
            
        }
    }
}