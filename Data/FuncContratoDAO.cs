using System;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;

using Devart.Data.PostgreSql;

#region MECHTECH
using MechTech.Util;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Data
{
    public class FuncContratoDAO : IDados<FuncContratoDTO>
    {
        
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        private DbTransaction transaction;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        /// <summary>
        /// Instância básica para FuncContratoDAO.
        /// </summary>
        public FuncContratoDAO()
        { }

        /// <summary>
        /// Instância para FuncContratoDAO com controle de transação.
        /// </summary>
        public FuncContratoDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }


        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(FuncContratoDTO funccontrato)
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
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(0, 'Inserindo contrato','" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }

                    dbCommand = db.GetSqlStringCommand(" INSERT INTO " + Global.EmpresaAtiva + ".funccontrato(" +
                                                   "    id_funcionario," +
                                                   "    dataadmissao," +
                                                   "    datademissao," +
                                                   "    datademissaoajuste," +
                                                   "    empresa" +
                                                   ") VALUES (" +
                                                   "    @id_funcionario," +
                                                   "    @dataadmissao," +
                                                   "    @datademissao," +
                                                   "    @datademissaoajuste," +
                                                   "    @empresa);" +
                                                   " SELECT currval('" + Global.EmpresaAtiva + ".funccontrato_id_seq');");
                    db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, funccontrato.Id_funcionario);
                    db.AddInParameter(dbCommand, "@dataadmissao", DbType.Date, (DateTime?)funccontrato.Dataadmissao);
                    db.AddInParameter(dbCommand, "@datademissao", DbType.Date, (DateTime?)funccontrato.Datademissao);
                    db.AddInParameter(dbCommand, "@datademissaoajuste", DbType.Date, (DateTime?)funccontrato.DataDemissaoAjuste);
                    db.AddInParameter(dbCommand, "@empresa", DbType.String, funccontrato.Empresa);

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
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(FuncContratoDTO funccontrato)
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
                        db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(0, 'Atualizando contrato','" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }
                    dbCommand = db.GetSqlStringCommand(" UPDATE " + Global.EmpresaAtiva + ".funccontrato SET" +
                                                   "    id_funcionario = @id_funcionario," +
                                                   "    dataadmissao = @dataadmissao," +
                                                   "    datademissao = @datademissao," +
                                                   "    datademissaoajuste = @datademissaoajuste," +
                                                   "    empresa = @empresa" +
                                                   " WHERE" +
                                                   "    id = @id");
                    db.AddInParameter(dbCommand, "@id", DbType.Int32, funccontrato.Id);
                    db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, funccontrato.Id_funcionario);
                    db.AddInParameter(dbCommand, "@dataadmissao", DbType.Date, (DateTime?)funccontrato.Dataadmissao);
                    db.AddInParameter(dbCommand, "@datademissao", DbType.Date, (DateTime?)funccontrato.Datademissao);
                    db.AddInParameter(dbCommand, "@datademissaoajuste", DbType.Date, (DateTime?)funccontrato.DataDemissaoAjuste);
                    db.AddInParameter(dbCommand, "@empresa", DbType.String, funccontrato.Empresa);
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
        /// Retorna um tipo VERDADEIRO para a instrução do conteúdo especificado, caso contrário FALSO.
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
                        db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(0, 'Excluindo contrato','" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }

                    dbCommand = db.GetSqlStringCommand(" DELETE FROM " + Global.EmpresaAtiva + ".funccontrato" +
                                                   " WHERE" +
                                                   "    id = @id;");
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
        /// Retorna um objeto FunccontratoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public FuncContratoDTO GetFunccontratoFuncionario(int id_funcionario)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFunccontratoFuncionario");
                db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, id_funcionario);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    DR.Read();
                    FuncContratoDTO tab = new FuncContratoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    if (Convert.IsDBNull(DR["dataadmissao"]))
                        tab.Dataadmissao = null;
                    else
                        tab.Dataadmissao = (DateTime)DR["dataadmissao"];
                    if (Convert.IsDBNull(DR["datademissao"]))
                        tab.Datademissao = null;
                    else
                        tab.Datademissao = (DateTime)DR["datademissao"];
                    if (Convert.IsDBNull(DR["datademissaoajuste"]))
                        tab.DataDemissaoAjuste = null;
                    else
                        tab.DataDemissaoAjuste = (DateTime)DR["datademissaoajuste"];
                    tab.Empresa = DR["empresa"].ToString();

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