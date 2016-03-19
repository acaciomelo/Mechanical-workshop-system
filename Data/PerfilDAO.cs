using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;

using Devart.Data.PostgreSql;

#region MECHTECH
using MechTech.Entities;
using MechTech.Interfaces;
using MechTech.Data;
using MechTech.Util;

#endregion

namespace MechTech.Data
{
    public class PerfilDAO : IDados<PerfilDTO>
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
        /// Instância básica para PerfilDAO.
        /// </summary>
        public PerfilDAO()
        { }

        /// <summary>
        /// Instância para PerfilDAO com controle de transação.
        /// </summary>
        public PerfilDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(PerfilDTO perfil)
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
                        db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1448, 'Perfil: " + perfil.Descricao + "', '" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }

                    dbCommand = db.GetSqlStringCommand(" INSERT INTO public.perfil(" +
                                                       " descricao" +
                                                       ") VALUES (" +
                                                       " @descricao);" +
                                                       " SELECT currval('perfil_id_seq');");
                    db.AddInParameter(dbCommand, "@descricao", DbType.String, perfil.Descricao);
                    int id = Convert.ToInt32(db.ExecuteScalar(dbCommand, Transaction));
                    PersisteListas(perfil, id);

                    if (transactionstart)
                    {
                        Transaction.Commit();
                        Transaction = null;
                    }
                    connection.Close();
                    return id;
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

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(PerfilDTO perfil)
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
                        db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1449, 'Perfil: " + perfil.Descricao + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }

                    dbCommand = db.GetSqlStringCommand(" UPDATE public.perfil SET" +
                                                       " descricao = @descricao" +
                                                       " WHERE" +
                                                       " id = @id");
                    db.AddInParameter(dbCommand, "@id", DbType.Int32, perfil.Id);
                    db.AddInParameter(dbCommand, "@descricao", DbType.String, perfil.Descricao);
                    db.ExecuteNonQuery(dbCommand, Transaction);
                    PersisteListas(perfil, perfil.Id);

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

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Delete(int id)
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
                        db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1450, '', '" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }

                    dbCommand = db.GetSqlStringCommand(" DELETE FROM public.perfil" +
                                                       " WHERE" +
                                                       " id = @id;");
                    db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
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

        /// <summary>
        /// Retorna um objeto PerfilDTO caso a instrução seja bem sucedida.
        /// </summary>
        public PerfilDTO GetPerfil(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetPerfil");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    DR.Read();
                    PerfilDTO tab = new PerfilDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Descricao = DR["descricao"].ToString();
                    tab.Rotinas = new PerfilRotinaDAO().GetPerfilRotinaPerfil(tab.Id);
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos PerfilDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<PerfilDTO> GetGridPerfil(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridPerfil");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    List<PerfilDTO> List = new List<PerfilDTO>();
                    while (DR.Read())
                    {
                        PerfilDTO tab = new PerfilDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Descricao = DR["descricao"].ToString();
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

        //TODO: Implemente códigos adicionais aqui.

        /// <summary>
        /// Método responsável pela persistência das listas agregadas a classe PerfilDTO.
        /// </summary>
        /// <param name="perfil">Objeto do tipo PerfilDTO gerado na camada de apresentação</param>
        /// <param name="id_perfil">Chave primária do perfil gerada no Banco de dados</param>
        private void PersisteListas(PerfilDTO perfil, int id_perfil)
        {
            //TABELA PERFILROTINA
            PerfilRotinaDAO perfilrotinadata = new PerfilRotinaDAO(transaction);
            if (perfilrotinadata.DeletePerfil(id_perfil))
            {
                foreach (PerfilRotinaDTO itemperfil in perfil.Rotinas)
                {
                    itemperfil.Id_Perfil = id_perfil;
                    perfilrotinadata.Insert(itemperfil);
                }
            }
        }
    }
}