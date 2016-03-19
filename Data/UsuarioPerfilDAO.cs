using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

using Microsoft.Practices.EnterpriseLibrary.Data;

using Devart.Data.PostgreSql;

#region MECHTECH
using MechTech.Entities;
using MechTech.Util;

#endregion

namespace MechTech.Data
{
    public class UsuarioPerfilDAO
    {
        
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        /// <summary>
        /// Instância básica para UsuarioPerfilDAO.
        /// </summary>
        public UsuarioPerfilDAO()
        { }

        /// <summary>
        /// Instância para UsuarioPerfilDAO com controle de transação.
        /// </summary>
        public UsuarioPerfilDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        public void Insert(List<UsuarioPerfilDTO> collection, int id_usuario)
        {
            DbConnection connection = null;
            bool transactionstart = false;

            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    if (Transaction == null)
                    {
                        Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                        transactionstart = true;
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1, 'Perfis de Acesso','" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }

                    if (Delete(id_usuario))
                    {
                        foreach (UsuarioPerfilDTO item in collection)
                        {
                            dbCommand = db.GetSqlStringCommand(" INSERT INTO public.usuarioperfil(" +
                                                               " id_usuario," +
                                                               " id_perfil" +
                                                               ") VALUES (" +
                                                               " @id_usuario," +
                                                               " @id_perfil);");
                            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, id_usuario);
                            db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, item.Id_Perfil);
                            db.ExecuteNonQuery(dbCommand, Transaction);
                        }
                    }

                    if (transactionstart)
                    {
                        Transaction.Commit();
                        Transaction = null;
                    }
                    connection.Close();
                }
            }
            catch
            {
                if (transactionstart)
                {
                    if (Transaction.Connection.State == ConnectionState.Open)
                        Transaction.Rollback();
                    Transaction = null;
                }
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                throw;
            }
        }

        public bool Delete(int id_usuario)
        {
            DbConnection connection = null;
            bool transactionstart = false;

            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    if (Transaction == null)
                    {
                        Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                        transactionstart = true;
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1, 'Perfis de Acesso','" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }
                    dbCommand = db.GetSqlStringCommand(" DELETE FROM public.usuarioperfil" +
                                                       " WHERE" +
                                                       " id_usuario = @id_usuario;");
                    db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, id_usuario);
                    db.ExecuteNonQuery(dbCommand, Transaction);
                    if (transactionstart)
                    {
                        Transaction.Commit();
                        Transaction = null;
                    }
                    connection.Close();
                    return true;
                }
            }
            catch
            {
                if (transactionstart)
                {
                    if (Transaction.Connection.State == ConnectionState.Open)
                        Transaction.Rollback();
                    Transaction = null;
                }
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                throw;
            }
        }

        public List<UsuarioPerfilDTO> GetUsuarioPerfilUsuario(int id_usuario)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetUsuarioPerfilUsuario");
                db.AddInParameter(dbCommand, "id_usuario", DbType.Int32, id_usuario);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    List<UsuarioPerfilDTO> List = new List<UsuarioPerfilDTO>();
                    while (DR.Read())
                    {
                        UsuarioPerfilDTO tab = new UsuarioPerfilDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Id_Usuario = int.Parse(DR["id_usuario"].ToString());
                        tab.Id_Perfil = int.Parse(DR["id_perfil"].ToString());
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
    }
}