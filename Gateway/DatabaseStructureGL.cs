using System.Collections.Generic;

#region MECHTECH
using MechTech.Business;
using MechTech.Entities;
#endregion

namespace MechTech.Gateway
{
    /// <summary>
    /// Representa um conjunto de métodos para manipulação a nível de estrutura do Banco de dados.
    /// </summary>
    public class DatabaseStructureGL
    {
        DatabaseStructureBO regrasnegocio = new DatabaseStructureBO();

        /// <summary>
        /// Instância básica para DatabaseStructureGL.
        /// </summary>
        public DatabaseStructureGL()
        { }

        /// <summary>
        /// Retorna a versão do servidor de Banco de dados.
        /// </summary>
        public string GetVersion()
        {
            try
            {
                return regrasnegocio.GetVersion();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto DatabaseStructureDTO contendo o schema do Banco de dados.
        /// </summary>
        /// <param name="schema">Nome do schema representado no Banco de dados. Ex.: emp0001</param>
        public DatabaseStructureDTO GetSchema(string schema)
        {
            try
            {
                return regrasnegocio.GetSchema(schema);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos DatabaseStructureDTO contendo as tabelas referente ao schema.
        /// </summary>
        /// <param name="schema">Nome do schema representado no Banco de dados. Ex.: emp0001</param>
        /// <returns></returns>
        public List<DatabaseStructureDTO> GetTables(string schema)
        {
            try
            {
                return regrasnegocio.GetTables(schema);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos DatabaseStructureDTO contendo os objetos (FK´s, PK´s, Índices, Checks, etc) referente ao schema.
        /// </summary>
        /// <param name="schema">Nome do schema representado no Banco de dados. Ex.: emp0001</param>
        /// <returns></returns>
        public List<DatabaseStructureDTO> GetObjects(string schema)
        {
            try
            {
                return regrasnegocio.GetObjects(schema);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos DatabaseStructureDTO contendo as funções (Stored Procedures) referente ao schema.
        /// </summary>
        /// <param name="schema">Nome do schema representado no Banco de dados. Ex.: emp0001</param>
        /// <returns></returns>
        public List<DatabaseStructureDTO> GetProcs(string schema)
        {
            try
            {
                return regrasnegocio.GetProcs(schema);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Cria o schema (estrutura) do Banco de dados.
        /// </summary>
        /// <param name="schema">Nome do schema representado no Banco de dados. Ex.: emp0001</param>
        public void CreateSchema(string schema)
        {
            try
            {
                regrasnegocio.CreateSchema(schema);
            }
            catch
            {
                throw;
            }
        }
    }
}