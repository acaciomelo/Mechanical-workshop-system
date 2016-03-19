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
    public class UsuarioRotinaDAO
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
        /// Instância básica para UsuarioRotinaDAO.
        /// </summary>
        public UsuarioRotinaDAO()
        { }

        /// <summary>
        /// Instância para UsuarioRotinaDAO com controle de transação.
        /// </summary>
        public UsuarioRotinaDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        public void Insert(List<UsuarioRotinaDTO> collection, int id_usuario)
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
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1, 'Módulos de Acesso', '" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }

                    if (Delete(id_usuario))
                    {
                        foreach (UsuarioRotinaDTO item in collection)
                        {
                            dbCommand = db.GetSqlStringCommand(" INSERT INTO public.usuariorotina(" +
                                                               " id_usuario," +
                                                               " id_rotina" +
                                                               ") VALUES (" +
                                                               " @id_usuario," +
                                                               " @id_rotina);");
                            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, id_usuario);
                            db.AddInParameter(dbCommand, "@id_rotina", DbType.Int32, item.Id_Rotina);
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
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1, 'Módulos de Acesso','" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }
                    dbCommand = db.GetSqlStringCommand(" DELETE FROM public.usuariorotina" +
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

        public List<UsuarioRotinaDTO> GetUsuarioRotinaUsuario(int id_usuario)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetUsuarioRotinaUsuario");
                db.AddInParameter(dbCommand, "id_usuario", DbType.Int32, id_usuario);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    List<UsuarioRotinaDTO> List = new List<UsuarioRotinaDTO>();
                    while (DR.Read())
                    {
                        UsuarioRotinaDTO tab = new UsuarioRotinaDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Id_Usuario = int.Parse(DR["id_usuario"].ToString());
                        tab.Id_Rotina = int.Parse(DR["id_rotina"].ToString());
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