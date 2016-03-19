using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

using Devart.Data.PostgreSql;

#region MECHTECH
using MechTech.Util;
using MechTech.Entities;
using MechTech.Interfaces;
using MechTech.Data;
#endregion

namespace MechTech.Data
{
    public class ProdutoServicoDAO : IDados<ProdutoServicoDTO>
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
        /// Instância básica para ProdutoServicoDAO.
        /// </summary>
        public ProdutoServicoDAO()
        { }

        /// <summary>
        /// Instância para ProdutoServicoDAO com controle de transação.
        /// </summary>
        public ProdutoServicoDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(ProdutoServicoDTO produto)
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
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1489, 'Inserindo Registro','" + Main.Util.Global.UsuarioAtivo + "');"); 
                    }

                    dbCommand = db.GetSqlStringCommand(" INSERT INTO " + "public.produto_servico(" +
                                                       " codbarras," +
                                                       " descricao," +
                                                       " referencia," +
                                                       " referencia2," +
                                                       " unidade," +
                                                       " custo," +
                                                       " venda," +
                                                       " tipolucro," +
                                                       " id_categoria," +
                                                       " id_fornecedor," +
                                                       " localizacao," +
                                                       " estoqueminimo," +
                                                       " estoqueatual," +
                                                       " usadoemveic," +
                                                       " anosparauso," +
                                                       " observacoes," +
                                                       " foto," +
                                                       " produtoservico," +
                                                       " aplicacao" +
                                                       ") VALUES (" +
                                                       " @codbarras," +
                                                       " @descricao," +
                                                       " @referencia," +
                                                       " @referencia2," +
                                                       " @unidade," +
                                                       " @custo," +
                                                       " @venda," +
                                                       " @tipolucro," +
                                                       " @id_categoria," +
                                                       " @id_fornecedor," +
                                                       " @localizacao," +
                                                       " @estoqueminimo," +
                                                       " @estoqueatual," +
                                                       " @usadoemveic," +
                                                       " @anosparauso," +
                                                       " @observacoes," +
                                                       " @foto," +
                                                       " @produtoservico," +
                                                       " @aplicacao);" +
                                                       " SELECT currval('" + "public.produto_servico_id_seq');");
                    db.AddInParameter(dbCommand, "@codbarras", DbType.String, produto.CodBarras);
                    db.AddInParameter(dbCommand, "@descricao", DbType.String, produto.Descricao);
                    db.AddInParameter(dbCommand, "@referencia", DbType.String, produto.Referencia);
                    db.AddInParameter(dbCommand, "@referencia2", DbType.String, produto.Referencia2);
                    db.AddInParameter(dbCommand, "@unidade", DbType.String, produto.Unidade);
                    db.AddInParameter(dbCommand, "@custo", DbType.Decimal, produto.Custo);
                    db.AddInParameter(dbCommand, "@venda", DbType.Decimal, produto.Venda);
                    if (produto.TipoLucro != string.Empty)
                        db.AddInParameter(dbCommand, "@tipolucro", DbType.String, produto.TipoLucro.Substring(0, 1));
                    else
                        db.AddInParameter(dbCommand, "@tipolucro", DbType.String, "");
                    if (produto.Categoria != null)
                        db.AddInParameter(dbCommand, "@id_categoria", DbType.Int32, produto.Categoria.Id);
                    else
                        db.AddInParameter(dbCommand, "@id_categoria", DbType.String, 0);

                    if (produto.Fornecedor != null)
                        db.AddInParameter(dbCommand, "@id_fornecedor", DbType.Int32, produto.Fornecedor.Id);
                    else
                        db.AddInParameter(dbCommand, "@id_fornecedor", DbType.Int32, 0);
                    db.AddInParameter(dbCommand, "@localizacao", DbType.String, produto.Localizacao);
                    db.AddInParameter(dbCommand, "@estoqueminimo", DbType.Int32, produto.EstoqueMinimo);
                    db.AddInParameter(dbCommand, "@estoqueatual", DbType.Int32, produto.EstoqueAtual);
                    db.AddInParameter(dbCommand, "@usadoemveic", DbType.String, produto.UsadoEmVeic);
                    db.AddInParameter(dbCommand, "@anosparauso", DbType.String, produto.AnosParaUso);
                    db.AddInParameter(dbCommand, "@observacoes", DbType.String, produto.Observacoes);
                    db.AddInParameter(dbCommand, "@foto", DbType.Binary, produto.Foto);
                    db.AddInParameter(dbCommand, "@produtoservico", DbType.Int32, produto.Produtoservico);
                    db.AddInParameter(dbCommand, "@aplicacao", DbType.String, produto.Aplicacao);
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
        public bool Update(ProdutoServicoDTO produto)
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
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1489, 'Atualizando Registro','" + Main.Util.Global.UsuarioAtivo + "');"); 
                    }

                    dbCommand = db.GetSqlStringCommand(" UPDATE " + "public.produto_servico SET" +
                                                       " codbarras = @codbarras," +
                                                       " descricao = @descricao," +
                                                       " referencia = @referencia," +
                                                       " referencia2 = @referencia2," +
                                                       " unidade = @unidade," +
                                                       " custo = @custo," +
                                                       " venda = @venda," +
                                                       " tipolucro = @tipolucro," +
                                                       " id_categoria = @id_categoria," +
                                                       " id_fornecedor = @id_fornecedor," +
                                                       " localizacao = @localizacao," +
                                                       " estoqueminimo = @estoqueminimo," +
                                                       " estoqueatual = @estoqueatual," +
                                                       " usadoemveic = @usadoemveic," +
                                                       " anosparauso = @anosparauso," +
                                                       " observacoes = @observacoes," +
                                                       " foto = @foto," +
                                                       " produtoservico = @produtoservico," +
                                                       " aplicacao = @aplicacao" +
                                                       " WHERE" +
                                                       " id = @id");
                    db.AddInParameter(dbCommand, "@id", DbType.Int32, produto.Id);
                    db.AddInParameter(dbCommand, "@codbarras", DbType.String, produto.CodBarras);
                    db.AddInParameter(dbCommand, "@descricao", DbType.String, produto.Descricao);
                    db.AddInParameter(dbCommand, "@referencia", DbType.String, produto.Referencia);
                    db.AddInParameter(dbCommand, "@referencia2", DbType.String, produto.Referencia2);
                    db.AddInParameter(dbCommand, "@unidade", DbType.String, produto.Unidade);
                    db.AddInParameter(dbCommand, "@custo", DbType.Decimal, produto.Custo);
                    db.AddInParameter(dbCommand, "@venda", DbType.Decimal, produto.Venda);
                    if (produto.TipoLucro != string.Empty)
                        db.AddInParameter(dbCommand, "@tipolucro", DbType.String, produto.TipoLucro.Substring(0, 1));
                    else
                        db.AddInParameter(dbCommand, "@tipolucro", DbType.String, "");
                    if (produto.Categoria != null)
                        db.AddInParameter(dbCommand, "@id_categoria", DbType.Int32, produto.Categoria.Id);
                    else
                        db.AddInParameter(dbCommand, "@id_categoria", DbType.String, 0);

                    if (produto.Fornecedor != null)
                        db.AddInParameter(dbCommand, "@id_fornecedor", DbType.Int32, produto.Fornecedor.Id);
                    else
                        db.AddInParameter(dbCommand, "@id_fornecedor", DbType.Int32, 0);
                    db.AddInParameter(dbCommand, "@localizacao", DbType.String, produto.Localizacao);
                    db.AddInParameter(dbCommand, "@estoqueminimo", DbType.Int32, produto.EstoqueMinimo);
                    db.AddInParameter(dbCommand, "@estoqueatual", DbType.Int32, produto.EstoqueAtual);
                    db.AddInParameter(dbCommand, "@usadoemveic", DbType.String, produto.UsadoEmVeic);
                    db.AddInParameter(dbCommand, "@anosparauso", DbType.String, produto.AnosParaUso);
                    db.AddInParameter(dbCommand, "@observacoes", DbType.String, produto.Observacoes);
                    db.AddInParameter(dbCommand, "@foto", DbType.Binary, produto.Foto);
                    db.AddInParameter(dbCommand, "@produtoservico", DbType.Int32, produto.Produtoservico);
                    db.AddInParameter(dbCommand, "@aplicacao", DbType.String, produto.Aplicacao);
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
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1489, 'Excluindo Registro','" + Main.Util.Global.UsuarioAtivo + "');"); 
                    }

                    dbCommand = db.GetSqlStringCommand(" DELETE FROM " + "public.produto_servico" +
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
        /// Retorna um objeto ProdutoServicoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public ProdutoServicoDTO GetProdutoServico(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("public.GetProdutoServico");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    DR.Read();
                    ProdutoServicoDTO tab = new ProdutoServicoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Descricao = DR["descricao"].ToString();
                    tab.CodBarras = DR["codbarras"].ToString();
                    tab.Referencia = DR["referencia"].ToString();
                    tab.Referencia2 = DR["referencia2"].ToString();
                    tab.Unidade = DR["unidade"].ToString();
                    tab.Custo = double.Parse(DR["custo"].ToString());
                    tab.Venda = double.Parse(DR["venda"].ToString());
                    tab.TipoLucro = (DR["tipolucro"].ToString() == "P") ? "Percentual" : "Valor";
                    tab.Categoria = new CategoriaProdutoDAO().GetCategoriaProduto(int.Parse(DR["id_categoria"].ToString()));
                    tab.Fornecedor = new FornecedorDAO().GetFornecedor(int.Parse(DR["id_fornecedor"].ToString()));
                    tab.Localizacao = DR["localizacao"].ToString();
                    tab.EstoqueMinimo = int.Parse(DR["estoqueminimo"].ToString());
                    tab.EstoqueAtual = int.Parse(DR["estoqueatual"].ToString());
                    tab.UsadoEmVeic = DR["usadoemveic"].ToString();
                    tab.AnosParaUso = DR["anosparauso"].ToString();
                    tab.Observacoes = DR["observacoes"].ToString();
                    tab.Foto = (Convert.IsDBNull(DR["foto"]) ? null : (byte[])DR["foto"]);
                    tab.Produtoservico = int.Parse(DR["produtoservico"].ToString());
                    tab.Aplicacao = DR["aplicacao"].ToString();
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos ProdutoServicoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<ProdutoServicoDTO> GetGridProdutoServico(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("public.GetGridProdutoServico");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    List<ProdutoServicoDTO> List = new List<ProdutoServicoDTO>();
                    while (DR.Read())
                    {
                        ProdutoServicoDTO tab = new ProdutoServicoDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Descricao = DR["descricao"].ToString();
                        tab.Referencia = DR["referencia"].ToString();
                        tab.EstoqueAtual = int.Parse(DR["estoqueatual"].ToString());
                        tab.Aplicacao = DR["aplicacao"].ToString();
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
