using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    /// <summary>
    /// Representa um conjunto de métodos para manipulação a nível de estrutura do Banco de dados.
    /// </summary>
    public class DatabaseStructureBO
    {
        DatabaseStructureDAO regrasdados = new DatabaseStructureDAO();

        /// <summary>
        /// Instância básica para DatabaseStructureBO.
        /// </summary>
        public DatabaseStructureBO()
        { }

        /// <summary>
        /// Retorna a versão do servidor de Banco de dados.
        /// </summary>
        public string GetVersion()
        {
            try
            {
                return regrasdados.GetVersion();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
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
                return regrasdados.GetSchema(schema);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
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
                return regrasdados.GetTables(schema);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
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
                return regrasdados.GetObjects(schema);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
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
                return regrasdados.GetProcs(schema);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
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
                regrasdados.CreateSchema(schema);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}