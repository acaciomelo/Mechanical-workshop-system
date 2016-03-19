using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

#region DEVART
using Devart.Data.PostgreSql;
#endregion

#region MECHTECH
using MechTech.Util;
using MechTech.Entities;
#endregion

namespace MechTech.Data
{
    /// <summary>
    /// Representa um conjunto de métodos para manipulação a nível de estrutura do Banco de dados.
    /// </summary>
    public class DatabaseStructureDAO
    {
        GenericDatabase db = new GenericDatabase(Global.ConnectionStringPg, PgSqlProviderFactory.Instance);
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para DatabaseStructureDAO.
        /// </summary>
        public DatabaseStructureDAO()
        { }

        /// <summary>
        /// Retorna a versão do servidor de Banco de dados.
        /// </summary>
        public string GetVersion()
        {
            try
            {
                dbCommand = db.GetSqlStringCommand("SELECT version();");
                return db.ExecuteScalar(dbCommand).ToString();
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
                dbCommand = db.GetSqlStringCommand("SELECT nspname FROM pg_namespace" +
                                                   " WHERE nspname = @schema;");
                db.AddInParameter(dbCommand, "@schema", DbType.String, schema);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    DatabaseStructureDTO tab = new DatabaseStructureDTO();
                    tab.Name = DR["nspname"].ToString();
                    return tab;
                }
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
                dbCommand = db.GetSqlStringCommand("SELECT relname AS clsname FROM pg_class cls" +
                                                   " LEFT JOIN pg_namespace nsp ON (cls.relnamespace = nsp.oid)" +
                                                   " WHERE nsp.nspname = @schema AND cls.relkind = 'r'" +
                                                   " ORDER BY relname;");
                db.AddInParameter(dbCommand, "@schema", DbType.String, schema);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<DatabaseStructureDTO> List = new List<DatabaseStructureDTO>();
                    while (DR.Read())
                    {
                        DatabaseStructureDTO tab = new DatabaseStructureDTO();
                        tab.Name = DR["clsname"].ToString();
                        List.Add(tab);
                    }
                    return List;
                }
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
                dbCommand = db.GetSqlStringCommand("SELECT conname AS objname FROM pg_constraint cnt" +
                                                   " LEFT JOIN pg_namespace nsp ON (cnt.connamespace = nsp.oid)" +
                                                   " WHERE nsp.nspname = @schema AND cnt.contype = 'f'" + //GET FOREING KEYS
                                                   " UNION" +
                                                   " SELECT conname AS objname FROM pg_constraint cnt" +
                                                   " LEFT JOIN pg_namespace nsp ON (cnt.connamespace = nsp.oid)" +
                                                   " WHERE nsp.nspname = @schema AND cnt.contype = 'c'" + //GET CHECKS
                                                   " UNION" +
                                                   " SELECT conname AS objname FROM pg_constraint cnt" +
                                                   " LEFT JOIN pg_namespace nsp ON (cnt.connamespace = nsp.oid)" +
                                                   " WHERE nsp.nspname = @schema AND cnt.contype = 'p'" + //GET PK´S
                                                   " UNION" +
                                                   " SELECT relname AS objname FROM pg_class cls" +
                                                   " LEFT JOIN pg_namespace nsp ON (cls.relnamespace = nsp.oid)" +
                                                   " WHERE nsp.nspname = @schema AND cls.relkind = 'i'" + //GET INDICES
                                                   " UNION" +
                                                   " SELECT relname AS objname FROM pg_class cls" +
                                                   " LEFT JOIN pg_namespace nsp ON (cls.relnamespace = nsp.oid)" +
                                                   " WHERE nsp.nspname = @schema AND cls.relkind = 'c'" + //GET COMPOSITE TYPES
                                                   " ORDER BY 1;");
                db.AddInParameter(dbCommand, "@schema", DbType.String, schema);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<DatabaseStructureDTO> List = new List<DatabaseStructureDTO>();
                    while (DR.Read())
                    {
                        DatabaseStructureDTO tab = new DatabaseStructureDTO();
                        tab.Name = DR["objname"].ToString();
                        List.Add(tab);
                    }
                    return List;
                }
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
                dbCommand = db.GetSqlStringCommand("SELECT proname AS prcname FROM pg_proc prc" +
                                                   " LEFT JOIN pg_namespace nsp ON (prc.pronamespace = nsp.oid)" +
                                                   " WHERE nsp.nspname = @schema" +
                                                   " ORDER BY proname;");
                db.AddInParameter(dbCommand, "@schema", DbType.String, schema);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<DatabaseStructureDTO> List = new List<DatabaseStructureDTO>();
                    while (DR.Read())
                    {
                        DatabaseStructureDTO tab = new DatabaseStructureDTO();
                        tab.Name = DR["prcname"].ToString();
                        List.Add(tab);
                    }
                    return List;
                }
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
                dbCommand = db.GetSqlStringCommand("CREATE SCHEMA " + schema + " AUTHORIZATION postgres;");
                db.ExecuteNonQuery(dbCommand);
            }
            catch
            {
                throw;
            }
        }
    }
}