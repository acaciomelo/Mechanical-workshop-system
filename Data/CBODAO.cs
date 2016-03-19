using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;

using Devart.Data.PostgreSql;

#region MECHTECH
using MechTech.Entities;
using MechTech.Interfaces;
using MechTech.Util;
#endregion

namespace MechTech.Data
{
    public class CBODAO : IDados<CBODTO>
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
        /// Instância básica para CBODAO.
        /// </summary>
        public CBODAO()
        { }

        /// <summary>
        /// Instância para CBODAO com controle de transação.
        /// </summary>
        public CBODAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(CBODTO cbo)
        {
            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    try
                    {
                        connection.Open();
                        if (Transaction == null)
                        {
                            Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                            //LOG
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1128, 'CBO: " + cbo.Descricao + "', '" + MechTech.Util.Global.UsuarioAtivo + "');"); 
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" INSERT INTO public.cbo(" +
                                                           "    descricao," +
                                                           "    codigo," +
                                                           "    grupo" +
                                                           ") VALUES (" +
                                                           "    @descricao," +
                                                           "    @codigo," +
                                                           "    @grupo);" +
                                                           " SELECT currval('cbo_id_seq');");
                        db.AddInParameter(dbCommand, "@descricao", DbType.String, cbo.Descricao);
                        db.AddInParameter(dbCommand, "@codigo", DbType.String, cbo.Codigo);
                        db.AddInParameter(dbCommand, "@grupo", DbType.String, cbo.Grupo);
                        int id = Convert.ToInt32(db.ExecuteScalar(dbCommand, Transaction));
                        Transaction.Commit();
                        connection.Close();
                        Transaction = null;
                        return id;
                    }
                    catch (DbException dbex)
                    {
                        if (Transaction != null)
                            Transaction.Rollback();
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        Transaction = null;
                        throw dbex;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(CBODTO cbo)
        {
            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    try
                    {
                        connection.Open();
                        if (Transaction == null)
                        {
                            Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                            //LOG
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1129, 'CBO: " + cbo.Descricao + "', '" + MechTech.Util.Global.UsuarioAtivo + "');"); 
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" UPDATE public.cbo SET" +
                                                           "    descricao = @descricao," +
                                                           "    codigo = @codigo," +
                                                           "    grupo = @grupo" +
                                                           " WHERE" +
                                                           "    id = @id");
                        db.AddInParameter(dbCommand, "@id", DbType.Int32, cbo.Id);
                        db.AddInParameter(dbCommand, "@descricao", DbType.String, cbo.Descricao);
                        db.AddInParameter(dbCommand, "@codigo", DbType.String, cbo.Codigo);
                        db.AddInParameter(dbCommand, "@grupo", DbType.String, cbo.Grupo);
                        db.ExecuteNonQuery(dbCommand, Transaction);
                        Transaction.Commit();
                        connection.Close();
                        Transaction = null;
                        return true;
                    }
                    catch (DbException dbex)
                    {
                        if (Transaction != null)
                            Transaction.Rollback();
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        Transaction = null;
                        throw dbex;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do conteúdo especificado, caso contrário FALSO.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    try
                    {
                        connection.Open();
                        if (Transaction == null)
                        {
                            Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                            //LOG
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1130, 'Còdigo: " + id.ToString() + "', '" + MechTech.Util.Global.UsuarioAtivo + "');"); 
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" DELETE FROM public.cbo" +
                                                           " WHERE" +
                                                           "    id = @id;");
                        db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
                        db.ExecuteNonQuery(dbCommand, Transaction);
                        Transaction.Commit();
                        connection.Close();
                        Transaction = null;
                        return true;
                    }
                    catch (DbException dbex)
                    {
                        if (Transaction != null)
                            Transaction.Rollback();
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        Transaction = null;
                        throw dbex;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto CBODTO para a instrução do conteúdo especificado.
        /// </summary>
        public CBODTO GetCBO(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetCBO");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    CBODTO tab = new CBODTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Descricao = DR["descricao"].ToString();
                    tab.Codigo = DR["codigo"].ToString();
                    tab.Grupo = DR["grupo"].ToString();
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos CBODTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<CBODTO> GetGridCBO(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridCBO");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<CBODTO> List = new List<CBODTO>();
                    while (DR.Read())
                    {
                        CBODTO tab = new CBODTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Descricao = DR["descricao"].ToString();
                        tab.Codigo = DR["codigo"].ToString();
                        tab.Grupo = DR["grupo"].ToString();
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
        /// Retorna um objeto CBODTO para a instrução do conteúdo especificado.
        /// </summary>
        public CBODTO GetCBOCodigo(string codigo)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetCBOCodigo");
                db.AddInParameter(dbCommand, "@codigo", DbType.String, codigo);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    CBODTO tab = new CBODTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Descricao = DR["descricao"].ToString();
                    tab.Codigo = DR["codigo"].ToString();
                    tab.Grupo = DR["grupo"].ToString();
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}