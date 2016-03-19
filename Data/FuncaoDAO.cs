using System;
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
using MechTech.Interfaces;
using System.Data.SqlClient;
#endregion

namespace MechTech.Data
{
    public class FuncaoDAO : IDados<FuncaoDTO>
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
        /// Instância básica para FuncaoDAO.
        /// </summary>
        public FuncaoDAO()
        { }

        /// <summary>
        /// Instância para FuncaoDAO com controle de transação.
        /// </summary>
        public FuncaoDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(FuncaoDTO funcao)
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
                            string ocorrencia = (MechTech.Util.Global.RotinaLOG == MechTech.Util.Enumeradores.RotinaLOG.ImportacaoDados ? "Importação de Dados" : string.Empty);
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1122, '" + ocorrencia + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" INSERT INTO " + Global.EmpresaAtiva + ".funcao(" +
                                                           "    id_cbo," +
                                                           "    nome," +
                                                           "    salariofuncao," +
                                                           "    id_salariotipo," +
                                                           "    horas," +
                                                           "    atividade," +
                                                           "    cargo," +
                                                           "    calculohoras" +
                                                           ") VALUES (" +
                                                           "    @id_cbo," +
                                                           "    @nome," +
                                                           "    @salariofuncao," +
                                                           "    @id_salariotipo," +
                                                           "    @horas," +
                                                           "    @atividade," +
                                                           "    @cargo," +
                                                           "    @calculohoras);" +
                                                           " SELECT currval('" + Global.EmpresaAtiva + ".funcao_id_seq');");
                        if (funcao.CBO.Id != 0)
                            db.AddInParameter(dbCommand, "@id_cbo", DbType.Int32, funcao.CBO.Id);
                        else
                            db.AddInParameter(dbCommand, "@id_cbo", DbType.Int32, null);
                        db.AddInParameter(dbCommand, "@nome", DbType.String, funcao.Nome);
                        db.AddInParameter(dbCommand, "@salariofuncao", DbType.Decimal, funcao.Salariofuncao);
                        db.AddInParameter(dbCommand, "@id_salariotipo", DbType.Int32, funcao.Salariotipo.Id);
                        db.AddInParameter(dbCommand, "@horas", DbType.Int32, funcao.Horas);
                        db.AddInParameter(dbCommand, "@atividade", DbType.String, funcao.Atividade);
                        db.AddInParameter(dbCommand, "@cargo", DbType.String, funcao.Cargo);
                        db.AddInParameter(dbCommand, "@calculohoras", DbType.Boolean, funcao.CalculoHoras);
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
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(FuncaoDTO funcao)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1124, '" + funcao.Nome + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" UPDATE " + Global.EmpresaAtiva + ".funcao SET" +
                                                           "    id_cbo = @id_cbo," +
                                                           "    nome = @nome," +
                                                           "    salariofuncao = @salariofuncao," +
                                                           "    id_salariotipo = @id_salariotipo," +
                                                           "    horas = @horas," +
                                                           "    atividade = @atividade," +
                                                           "    cargo = @cargo," +
                                                           "    calculohoras = @calculohoras" +
                                                           " WHERE" +
                                                           "    id = @id");
                        db.AddInParameter(dbCommand, "@id", DbType.Int32, funcao.Id);
                        if (funcao.CBO.Id != 0)
                            db.AddInParameter(dbCommand, "@id_cbo", DbType.Int32, funcao.CBO.Id);
                        else
                            db.AddInParameter(dbCommand, "@id_cbo", DbType.Int32, null);
                        db.AddInParameter(dbCommand, "@nome", DbType.String, funcao.Nome);
                        db.AddInParameter(dbCommand, "@salariofuncao", DbType.Decimal, funcao.Salariofuncao);
                        db.AddInParameter(dbCommand, "@id_salariotipo", DbType.Int32, funcao.Salariotipo.Id);
                        db.AddInParameter(dbCommand, "@horas", DbType.Int32, funcao.Horas);
                        db.AddInParameter(dbCommand, "@atividade", DbType.String, funcao.Atividade);
                        db.AddInParameter(dbCommand, "@cargo", DbType.String, funcao.Cargo);
                        db.AddInParameter(dbCommand, "@calculohoras", DbType.Boolean, funcao.CalculoHoras);
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
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1125, '','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" DELETE FROM " + Global.EmpresaAtiva + ".funcao" +
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
        /// Retorna um objeto FuncaoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FuncaoDTO GetFuncao(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFuncao");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    FuncaoDTO tab = new FuncaoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nome = DR["nome"].ToString();
                    tab.Salariofuncao = decimal.Parse(DR["salariofuncao"].ToString());
                    tab.Horas = int.Parse(DR["horas"].ToString());
                    tab.Atividade = DR["atividade"].ToString();
                    tab.Cargo = DR["cargo"].ToString();
                    tab.CalculoHoras = bool.Parse(DR["calculohoras"].ToString());
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FuncaoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncaoDTO> GetGridFuncao(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetGridFuncao");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<FuncaoDTO> List = new List<FuncaoDTO>();
                    while (DR.Read())
                    {
                        FuncaoDTO tab = new FuncaoDTO();
                        tab.Id = int.Parse(DR["id"].ToString());

                        //CBO
                        CBODTO cbo = new CBODTO();
                        cbo.Codigo = DR["cbo"].ToString();
                        tab.CBO = cbo;
                        //

                        tab.Nome = DR["nome"].ToString();
                        tab.Salariofuncao = decimal.Parse(DR["salariofuncao"].ToString());
                        tab.Salariotipo.Descricao = DR["descricao"].ToString();

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
        /// Responsável apenas por verificar a existência da Função no Banco de dados (Importação de dados).
        /// </summary>
        /// <param name="id">ID da Função</param>
        /// <returns>true = existe, não = não existe</returns>
        public bool ExistsFuncao(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFuncao");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    while (DR.Read())
                    {
                        return true;
                    }
                }
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Responsável por atualizar o ID e definir nova sequência para a tabela (Importação de dados).
        /// </summary>
        /// <param name="oldid_funcao">ID gerado pelo Banco de dados</param>
        /// <param name="newid_funcao">ID especificado no arquivo de importação</param>
        public void UpdateSequence(int oldid_funcao, int newid_funcao)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1188, '','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" UPDATE " + Global.EmpresaAtiva + ".funcao SET" +
                                                           "    id = @newid_funcao" +
                                                           " WHERE" +
                                                           "    id = @oldid_funcao");
                        db.AddInParameter(dbCommand, "@oldid_funcao", DbType.Int32, oldid_funcao);
                        db.AddInParameter(dbCommand, "@newid_funcao", DbType.Int32, newid_funcao);
                        db.ExecuteNonQuery(dbCommand, Transaction);
                        Transaction.Commit();
                        connection.Close();
                        Transaction = null;
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

                dbCommand = db.GetSqlStringCommand(" Select setval('" + Global.EmpresaAtiva + ".funcao_id_seq',(select max(id)+1 from " + Global.EmpresaAtiva + ".funcao),true)");
                db.ExecuteNonQuery(dbCommand);

                //int max = 0;
                //dbCommand = db.GetSqlStringCommand(" SELECT id FROM " + Global.EmpresaAtiva + ".funcao" +
                //                                   " ORDER BY id DESC LIMIT 1");

                //max = Convert.ToInt32(db.ExecuteScalar(dbCommand));
                //max++;

                //GenericDatabase db2 = new GenericDatabase(Global.ConnectionStringPg, PgSqlProviderFactory.Instance);
                //dbCommand = db2.GetSqlStringCommand(" ALTER SEQUENCE " + Global.EmpresaAtiva + ".funcao_id_seq" +
                //                                    "     INCREMENT 1  MINVALUE 1" +
                //                                    "     MAXVALUE 9223372036854775807  START @max" +
                //                                    "     CACHE 1  NO CYCLE;");
                //db2.AddInParameter(dbCommand, "@max", DbType.Int32, max);
                //db2.ExecuteNonQuery(dbCommand);
                //db2 = null;
            }
            catch
            {
                throw;
            }
        }
    }
}