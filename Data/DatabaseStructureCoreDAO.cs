using System;
using System.Data;
using System.Data.Common;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Data;

#region DEVART
using Devart.Data.PostgreSql;
#endregion

namespace MechTech.Data
{
    /// <summary>
    /// Representa um conjunto de métodos para manipulação a nível de estrutura do Banco de dados.
    /// </summary>
    public class DatabaseStructureCoreDAO
    {
        Assembly assembly = null;
        Type classe = null;
        PropertyInfo propriedade = null;
        GenericDatabase db = null;
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para DatabaseStructureCoreDAO.
        /// </summary>
        public DatabaseStructureCoreDAO()
        {
            assembly = Assembly.Load("MechTech.Util");
            classe = assembly.GetType("MechTech.Util.Global");
            propriedade = classe.GetProperty("ConnectionStringPg");
            db = new GenericDatabase(propriedade.GetValue(null, null).ToString(), PgSqlProviderFactory.Instance);
        }

        /// <summary>
        /// Verifica a existência de um Banco de dados específico no servidor.
        /// </summary>
        /// <param name="databasename">Nome do Banco de dados</param>
        /// <returns>VERDADEIRO caso já exista o Banco de dados</returns>
        public bool ExistsDatabase(string databasename)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand("SELECT datname FROM pg_database" +
                                                   " WHERE datname = @databasename;");
                db.AddInParameter(dbCommand, "@databasename", DbType.String, databasename);
                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    DR["datname"].ToString();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cria um novo usuário para o Banco de dados.
        /// </summary>
        /// <param name="id_user">Chave do usuário</param>
        /// <param name="username">Login do usuário</param>
        /// <param name="password">Senha do usuário</param>
        public void CreateRole(int id_user, string username, string password)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand("CREATE ROLE " + username.ToLower() + " LOGIN ENCRYPTED PASSWORD '" + password.ToLower() + "mechtech" + id_user.ToString() + "' SUPERUSER NOINHERIT;");
                db.ExecuteNonQuery(dbCommand);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Ativa/Desativa a permissão de acesso no Banco de dados.
        /// </summary>
        /// <param name="username">Login do usuário</param>
        /// <param name="haslogin">Verdadeiro caso o usuário tenha permissão de login no Sistema</param>
        public void AlterRole(string username, bool haslogin)
        {
            try
            {
                string sqlcommand = string.Empty;
                if (haslogin)
                    sqlcommand = "ALTER ROLE " + username.ToLower() + " LOGIN;";
                else
                    sqlcommand = "ALTER ROLE " + username.ToLower() + " NOLOGIN;";

                dbCommand = db.GetSqlStringCommand(sqlcommand);
                db.ExecuteNonQuery(dbCommand);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Altera a senha de um usuário para um login existente.
        /// </summary>
        /// <param name="id_user">Chave do usuário</param>
        /// <param name="username">Login do usuário</param>
        /// <param name="newpassword">Nova senha do usuário</param>
        public void AlterRole(int id_user, string username, string newpassword)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand("ALTER ROLE " + username.ToLower() + " ENCRYPTED PASSWORD '" + newpassword.ToLower() + "mechtech" + id_user.ToString() + "';");
                db.ExecuteNonQuery(dbCommand);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Remove o usuário do Banco de dados.
        /// </summary>
        /// <param name="username">Login do usuário</param>
        public void DropRole(string username)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand("DROP ROLE " + username.ToLower() + ";");
                db.ExecuteNonQuery(dbCommand);
            }
            catch
            {
                throw;
            }
        }

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

    }
}