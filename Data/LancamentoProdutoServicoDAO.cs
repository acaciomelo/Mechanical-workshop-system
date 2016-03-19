using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

using Microsoft.Practices.EnterpriseLibrary.Data;

using Devart.Data.PostgreSql;

#region MechTech
using MechTech.Util;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Data
{
    public class LancamentoProdutoServicoDAO : IDados<LancamentoProdutoServicoDTO>
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
        /// Instância básica para LancamentoProdutoServicoDAO.
        /// </summary>
        public LancamentoProdutoServicoDAO()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(LancamentoProdutoServicoDTO orcamentoitem)
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
                    }
                    dbCommand = db.GetSqlStringCommand(" INSERT INTO " + "public" + ".orcamentoitem(" +
                                                       "    id_orcamento," +
                                                       "    id_produto," +
                                                       "    valorunitario," +
                                                       "    valortotal," +
                                                       "    valordesconto," +
                                                       "    valorliquido" +
                                                       ") VALUES (" +
                                                       "    @id_orcamento," +
                                                       "    @id_produto," +
                                                       "    @valorunitario," +
                                                       "    @valortotal," +
                                                       "    @valordesconto," +
                                                       "    @valorliquido);" +
                                                       " SELECT currval('" + "public" + ".orcamentoitem_id_seq');");
                    db.AddInParameter(dbCommand, "@id_orcamento", DbType.Int32, orcamentoitem.Id_orcamento);
                    db.AddInParameter(dbCommand, "@id_produto", DbType.Int32, orcamentoitem.Produto.Id);
                    db.AddInParameter(dbCommand, "@valorunitario", DbType.Decimal, orcamentoitem.ValorUnitario);
                    db.AddInParameter(dbCommand, "@valortotal", DbType.Decimal, orcamentoitem.ValorTotal);
                    db.AddInParameter(dbCommand, "@valordesconto", DbType.Decimal, orcamentoitem.ValorDesconto);
                    db.AddInParameter(dbCommand, "@valorliquido", DbType.Decimal, orcamentoitem.ValorLiquido);

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
        public bool Update(LancamentoProdutoServicoDTO orcamentoitem)
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
                    }
                    dbCommand = db.GetSqlStringCommand(" UPDATE " + "public" + ".orcamentoitem SET" +
                                                       "    id_orcamento = @id_orcamento," +
                                                       "    id_produto = @id_produto," +
                                                       "    valorunitario = @valorunitario," +
                                                       "    valortotal = @valortotal," +
                                                       "    valordesconto = @valordesconto," +
                                                       "    valorliquido = @valorliquido," +
                                                       " WHERE" +
                                                       "    id = @id");
                    db.AddInParameter(dbCommand, "@id", DbType.Int32, orcamentoitem.Id);
                    db.AddInParameter(dbCommand, "@id_orcamento", DbType.Int32, orcamentoitem.Id_orcamento);
                    db.AddInParameter(dbCommand, "@id_produto", DbType.Int32, orcamentoitem.Produto.Id);
                    db.AddInParameter(dbCommand, "@valorunitario", DbType.Decimal, orcamentoitem.ValorUnitario);
                    db.AddInParameter(dbCommand, "@valortotal", DbType.Decimal, orcamentoitem.ValorTotal);
                    db.AddInParameter(dbCommand, "@valordesconto", DbType.Decimal, orcamentoitem.ValorDesconto);
                    db.AddInParameter(dbCommand, "@valorliquido", DbType.Decimal, orcamentoitem.ValorLiquido);
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
                    }
                    dbCommand = db.GetSqlStringCommand(" DELETE FROM " + "public" + ".orcamentoitem" +
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

        public bool DeleteOrcamento(int id_orcamento)
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
                    }
                dbCommand = db.GetSqlStringCommand(" DELETE FROM " + "public" + ".orcamentoitem" +
                                                   " WHERE" +
                                                   "    id_orcamento = @id_orcamento;");
                db.AddInParameter(dbCommand, "@id_orcamento", DbType.Int32, id_orcamento);
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

        //<summary>
        //Retorna um objeto LancamentoProdutoServicoDTO para a instrução do conteúdo especificado.
        //</summary>
        public List<LancamentoProdutoServicoDTO> GetListOrcamentoItem(int id_orcamento)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("public" + ".getlistorcamentoitem");
                db.AddInParameter(dbCommand, "@id_orcamento", DbType.Int32, id_orcamento);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    List<LancamentoProdutoServicoDTO> List = new List<LancamentoProdutoServicoDTO>();

                    while (DR.Read())
                    {
                        LancamentoProdutoServicoDTO tab = new LancamentoProdutoServicoDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Id_orcamento = int.Parse(DR["id_orcamento"].ToString());
                        tab.Produto = new ProdutoServicoDAO().GetProdutoServico(int.Parse(DR["id_produto"].ToString()));
                        if (tab.Produto.Produtoservico.Equals(0))
                            tab.Tipo = "P";
                        else
                            tab.Tipo = "S";
                        tab.ValorDesconto = decimal.Parse(DR["valordesconto"].ToString());
                        tab.ValorLiquido = decimal.Parse(DR["ValorLiquido"].ToString());
                        tab.ValorTotal = decimal.Parse(DR["ValorTotal"].ToString());
                        tab.ValorUnitario = decimal.Parse(DR["ValorUnitario"].ToString());
                        tab.Quantidade = int.Parse((tab.ValorTotal / tab.ValorUnitario).ToString());

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