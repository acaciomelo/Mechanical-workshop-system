using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

#region DEVART
using Devart.Data.PostgreSql;
#endregion

#region MechTech
using MechTech.Entities;
using MechTech.Util;
#endregion

namespace MechTech.Data
{
    public class RotinaDAO
    {

        //Database db = DatabaseFactory.CreateDatabase(); 
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        /// <summary>
        /// Instância básica para RotinaDAO.
        /// </summary>
        public RotinaDAO()
        { }

        /// <summary>
        /// Instância para RotinaDAO com controle de transação.
        /// </summary>
        public RotinaDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(RotinaDTO rotina)
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
                        db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(11, 'Inserindo registro','" + MechTech.Util.Global.UsuarioAtivo + "');"); 
                    }

                    dbCommand = db.GetSqlStringCommand(" INSERT INTO public.rotina(" +
                                                       " indiceimagem," +
                                                       " descricao," +
                                                       " nivel," +
                                                       " assembler," +
                                                       " classe," +
                                                       " metodo," +
                                                       " ativaempresa," +
                                                       " acao," +
                                                       " menu," +
                                                       " acesso," +
                                                       " log" +
                                                       ") VALUES (" +
                                                       " @indiceimagem," +
                                                       " @descricao," +
                                                       " @nivel," +
                                                       " @assembler," +
                                                       " @classe," +
                                                       " @metodo," +
                                                       " @ativaempresa," +
                                                       " @acao," +
                                                       " @menu," +
                                                       " @acesso," +
                                                       " @log);" +
                                                       " SELECT currval('rotina_id_seq');");
                    db.AddInParameter(dbCommand, "@indiceimagem", DbType.Int32, rotina.Indiceimagem);
                    db.AddInParameter(dbCommand, "@descricao", DbType.String, rotina.Descricao);
                    db.AddInParameter(dbCommand, "@nivel", DbType.String, rotina.Nivel);
                    db.AddInParameter(dbCommand, "@assembler", DbType.String, rotina.Assembler);
                    db.AddInParameter(dbCommand, "@classe", DbType.String, rotina.Classe);
                    db.AddInParameter(dbCommand, "@metodo", DbType.String, rotina.Metodo);
                    db.AddInParameter(dbCommand, "@ativaempresa", DbType.Boolean, rotina.Ativaempresa);
                    db.AddInParameter(dbCommand, "@acao", DbType.String, rotina.Acao);
                    db.AddInParameter(dbCommand, "@menu", DbType.Boolean, rotina.Menu);
                    db.AddInParameter(dbCommand, "@acesso", DbType.Boolean, rotina.Acesso);
                    db.AddInParameter(dbCommand, "@log", DbType.Boolean, rotina.Log);
                    int id = Convert.ToInt32(db.ExecuteScalar(dbCommand, Transaction));

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
        public bool Update(RotinaDTO rotina)
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
                        db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(12, 'Atualizando registro','" + MechTech.Util.Global.UsuarioAtivo + "');"); 
                    }

                    dbCommand = db.GetSqlStringCommand(" UPDATE public.rotina SET" +
                                                       " indiceimagem = @indiceimagem," +
                                                       " descricao = @descricao," +
                                                       " nivel = @nivel," +
                                                       " assembler = @assembler," +
                                                       " classe = @classe," +
                                                       " metodo = @metodo," +
                                                       " ativaempresa = @ativaempresa," +
                                                       " acao = @acao," +
                                                       " menu = @menu," +
                                                       " acesso = @acesso," +
                                                       " log = @log" +
                                                       " WHERE" +
                                                       " id = @id");
                    db.AddInParameter(dbCommand, "@id", DbType.Int32, rotina.Id);
                    db.AddInParameter(dbCommand, "@indiceimagem", DbType.Int32, rotina.Indiceimagem);
                    db.AddInParameter(dbCommand, "@descricao", DbType.String, rotina.Descricao);
                    db.AddInParameter(dbCommand, "@nivel", DbType.String, rotina.Nivel);
                    db.AddInParameter(dbCommand, "@assembler", DbType.String, rotina.Assembler);
                    db.AddInParameter(dbCommand, "@classe", DbType.String, rotina.Classe);
                    db.AddInParameter(dbCommand, "@metodo", DbType.String, rotina.Metodo);
                    db.AddInParameter(dbCommand, "@ativaempresa", DbType.Boolean, rotina.Ativaempresa);
                    db.AddInParameter(dbCommand, "@acao", DbType.String, rotina.Acao);
                    db.AddInParameter(dbCommand, "@menu", DbType.Boolean, rotina.Menu);
                    db.AddInParameter(dbCommand, "@acesso", DbType.Boolean, rotina.Acesso);
                    db.AddInParameter(dbCommand, "@log", DbType.Boolean, rotina.Log);
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
                        db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(13, 'Excluindo registro','" + MechTech.Util.Global.UsuarioAtivo + "');"); 
                    }

                    dbCommand = db.GetSqlStringCommand(" DELETE FROM public.rotina" +
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
        /// Retorna um objeto RotinaDTO caso a instrução seja bem sucedida.
        /// </summary>
        public RotinaDTO GetRotina(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetRotina");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    DR.Read();
                    RotinaDTO tab = new RotinaDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Indiceimagem = int.Parse(DR["indiceimagem"].ToString());
                    tab.Descricao = DR["descricao"].ToString();
                    tab.Nivel = DR["nivel"].ToString();
                    tab.Assembler = DR["assembler"].ToString();
                    tab.Classe = DR["classe"].ToString();
                    tab.Metodo = DR["metodo"].ToString();
                    tab.Ativaempresa = bool.Parse(DR["ativaempresa"].ToString());
                    tab.Acao = DR["acao"].ToString();
                    tab.Menu = bool.Parse(DR["menu"].ToString());
                    tab.Acesso = bool.Parse(DR["acesso"].ToString());
                    tab.Log = bool.Parse(DR["log"].ToString());
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos RotinaDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<RotinaDTO> GetGridRotina(string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("getrotinamodulo");
                db.AddInParameter(dbCommand, "modulo", DbType.String, valorPesquisa);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    List<RotinaDTO> List = new List<RotinaDTO>();
                    while (DR.Read())
                    {
                        RotinaDTO tab = new RotinaDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Indiceimagem = int.Parse(DR["indiceimagem"].ToString());
                        tab.Descricao = DR["descricao"].ToString();
                        tab.Nivel = DR["nivel"].ToString();
                        tab.Assembler = DR["assembler"].ToString();
                        tab.Classe = DR["classe"].ToString();
                        tab.Metodo = DR["metodo"].ToString();
                        tab.Ativaempresa = bool.Parse(DR["ativaempresa"].ToString());
                        tab.Acao = DR["acao"].ToString();
                        tab.Menu = bool.Parse(DR["menu"].ToString());
                        tab.Acesso = bool.Parse(DR["acesso"].ToString());
                        tab.Log = bool.Parse(DR["log"].ToString());
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

        public List<RotinaDTO> GetRotinaModulo(string modulo)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetRotinaModulo");
                db.AddInParameter(dbCommand, "Modulo", DbType.String, modulo);
                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<RotinaDTO> List = new List<RotinaDTO>();
                    while (DR.Read())
                    {
                        RotinaDTO tab = new RotinaDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Descricao = DR["descricao"].ToString();
                        tab.Nivel = DR["nivel"].ToString();
                        tab.Menu = bool.Parse(DR["menu"].ToString());
                        tab.Acesso = bool.Parse(DR["acesso"].ToString());
                        tab.Log = bool.Parse(DR["log"].ToString());
                        tab.Assembler = DR["assembler"].ToString();
                        tab.Classe = DR["classe"].ToString();
                        tab.Metodo = DR["metodo"].ToString();
                        tab.Ativaempresa = bool.Parse(DR["ativaempresa"].ToString());
                        tab.Acao = DR["acao"].ToString();
                        tab.Indiceimagem = int.Parse(DR["indiceimagem"].ToString());
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
