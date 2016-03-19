using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
//using Microsoft.Practices.EnterpriseLibrary.Common;
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
    public class FornecedorDAO : IDados<FornecedorDTO>
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
        /// Instância básica para FornecedorDAO.
        /// </summary>
        public FornecedorDAO()
        { }

        /// <summary>
        /// Instância para FornecedorDAO com controle de transação.
        /// </summary>
        public FornecedorDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(FornecedorDTO fornecedor)
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

                    dbCommand = db.GetSqlStringCommand(" INSERT INTO public.fornecedor(" +
                                                       " nomefantasia," +
                                                       " razaosocial," +
                                                       " endereco," +
                                                       " numero," +
                                                       " complemento," +
                                                       " bairro," +
                                                       " cep," +
                                                       " id_municipio," +
                                                       " dddtelefone," +
                                                       " telefone," +
                                                       " dddfax," +
                                                       " fax," +
                                                       " cnpj," +
                                                       " cei," +
                                                       " iestadual," +
                                                       " imunicipal," +
                                                       " url," +
                                                       " email," +
                                                       " dirf," +

                                                       " ramoatividade," +
                                                       " nomecontato," +
                                                       " emailcontato," +
                                                       " dddtelcontato," +
                                                       " telcontato," +
                                                       " dddcelcontato," +
                                                       " celcontato," +
                                                       " ramalcontato," +

                                                       " registro" +
                                                       ") VALUES (" +
                                                       " @nomefantasia," +
                                                       " @razaosocial," +
                                                       " @endereco," +
                                                       " @numero," +
                                                       " @complemento," +
                                                       " @bairro," +
                                                       " @cep," +
                                                       " @id_municipio," +
                                                       " @dddtelefone," +
                                                       " @telefone," +
                                                       " @dddfax," +
                                                       " @fax," +
                                                       " @cnpj," +
                                                       " @cei," +
                                                       " @iestadual," +
                                                       " @imunicipal," +
                                                       " @url," +
                                                       " @email," +
                                                       " @dirf," +
                                                       " @ramoatividade," +
                                                       " @nomecontato," +
                                                       " @emailcontato," +
                                                       " @dddtelcontato," +
                                                       " @telcontato," +
                                                       " @dddcelcontato," +
                                                       " @celcontato," +
                                                       " @ramalcontato," +
                                                       " @registro);" +
                                                       " SELECT currval('fornecedor_id_seq');");
                    db.AddInParameter(dbCommand, "@nomefantasia", DbType.String, fornecedor.Nomefantasia);
                    db.AddInParameter(dbCommand, "@razaosocial", DbType.String, fornecedor.Razaosocial);
                    db.AddInParameter(dbCommand, "@endereco", DbType.String, fornecedor.Endereco);
                    db.AddInParameter(dbCommand, "@numero", DbType.String, fornecedor.Numero);
                    db.AddInParameter(dbCommand, "@complemento", DbType.String, fornecedor.Complemento);
                    db.AddInParameter(dbCommand, "@bairro", DbType.String, fornecedor.Bairro);
                    db.AddInParameter(dbCommand, "@cep", DbType.String, fornecedor.Cep);
                    db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, fornecedor.Municipio.Id);
                    db.AddInParameter(dbCommand, "@dddtelefone", DbType.String, fornecedor.Dddtelefone);
                    db.AddInParameter(dbCommand, "@telefone", DbType.String, fornecedor.Telefone);
                    db.AddInParameter(dbCommand, "@dddfax", DbType.String, fornecedor.Dddfax);
                    db.AddInParameter(dbCommand, "@fax", DbType.String, fornecedor.Fax);
                    db.AddInParameter(dbCommand, "@cnpj", DbType.String, fornecedor.Cnpj);
                    db.AddInParameter(dbCommand, "@cei", DbType.String, fornecedor.Cei);
                    db.AddInParameter(dbCommand, "@iestadual", DbType.String, fornecedor.Iestadual);
                    db.AddInParameter(dbCommand, "@imunicipal", DbType.String, fornecedor.Imunicipal);
                    db.AddInParameter(dbCommand, "@url", DbType.String, fornecedor.Url);
                    db.AddInParameter(dbCommand, "@email", DbType.String, fornecedor.Email);
                    db.AddInParameter(dbCommand, "@dirf", DbType.Boolean, fornecedor.Dirf);

                    db.AddInParameter(dbCommand, "@ramoatividade", DbType.String, fornecedor.RamoAtividade);
                    db.AddInParameter(dbCommand, "@nomecontato", DbType.String, fornecedor.NomeContato);
                    db.AddInParameter(dbCommand, "@emailcontato", DbType.String, fornecedor.EmailContato);
                    db.AddInParameter(dbCommand, "@dddtelcontato", DbType.String, fornecedor.DDDTelContato);
                    db.AddInParameter(dbCommand, "@telcontato", DbType.String, fornecedor.TelContato);
                    db.AddInParameter(dbCommand, "@dddcelcontato", DbType.String, fornecedor.DDDCelContato);
                    db.AddInParameter(dbCommand, "@celcontato", DbType.String, fornecedor.CelContato);
                    db.AddInParameter(dbCommand, "@ramalcontato", DbType.String, fornecedor.RamalContato);

                    db.AddInParameter(dbCommand, "@registro", DbType.String, fornecedor.Registro);
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
        public bool Update(FornecedorDTO fornecedor)
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

                    dbCommand = db.GetSqlStringCommand(" UPDATE public.fornecedor SET" +
                                                       " nomefantasia = @nomefantasia," +
                                                       " razaosocial = @razaosocial," +
                                                       " endereco = @endereco," +
                                                       " numero = @numero," +
                                                       " complemento = @complemento," +
                                                       " bairro = @bairro," +
                                                       " cep = @cep," +
                                                       " id_municipio = @id_municipio," +
                                                       " dddtelefone = @dddtelefone," +
                                                       " telefone = @telefone," +
                                                       " dddfax = @dddfax," +
                                                       " fax = @fax," +
                                                       " cnpj = @cnpj," +
                                                       " cei = @cei," +
                                                       " iestadual = @iestadual," +
                                                       " imunicipal = @imunicipal," +
                                                       " url = @url," +
                                                       " email = @email," +
                                                       " dirf = @dirf," +
                                                       " ramoatividade = @ramoatividade," +
                                                       " nomecontato = @nomecontato," +
                                                       " emailcontato = @emailcontato," +
                                                       " dddtelcontato = @dddtelcontato," +
                                                       " telcontato = @telcontato," +
                                                       " dddcelcontato = @dddcelcontato," +
                                                       " celcontato = @celcontato," +
                                                       " ramalcontato = @ramalcontato," +
                                                       " registro = @registro" +
                                                       " WHERE" +
                                                       " id = @id");
                    db.AddInParameter(dbCommand, "@id", DbType.Int32, fornecedor.Id);
                    db.AddInParameter(dbCommand, "@nomefantasia", DbType.String, fornecedor.Nomefantasia);
                    db.AddInParameter(dbCommand, "@razaosocial", DbType.String, fornecedor.Razaosocial);
                    db.AddInParameter(dbCommand, "@endereco", DbType.String, fornecedor.Endereco);
                    db.AddInParameter(dbCommand, "@numero", DbType.String, fornecedor.Numero);
                    db.AddInParameter(dbCommand, "@complemento", DbType.String, fornecedor.Complemento);
                    db.AddInParameter(dbCommand, "@bairro", DbType.String, fornecedor.Bairro);
                    db.AddInParameter(dbCommand, "@cep", DbType.String, fornecedor.Cep);
                    db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, fornecedor.Municipio.Id);
                    db.AddInParameter(dbCommand, "@dddtelefone", DbType.String, fornecedor.Dddtelefone);
                    db.AddInParameter(dbCommand, "@telefone", DbType.String, fornecedor.Telefone);
                    db.AddInParameter(dbCommand, "@dddfax", DbType.String, fornecedor.Dddfax);
                    db.AddInParameter(dbCommand, "@fax", DbType.String, fornecedor.Fax);
                    db.AddInParameter(dbCommand, "@cnpj", DbType.String, fornecedor.Cnpj);
                    db.AddInParameter(dbCommand, "@cei", DbType.String, fornecedor.Cei);
                    db.AddInParameter(dbCommand, "@iestadual", DbType.String, fornecedor.Iestadual);
                    db.AddInParameter(dbCommand, "@imunicipal", DbType.String, fornecedor.Imunicipal);
                    db.AddInParameter(dbCommand, "@url", DbType.String, fornecedor.Url);
                    db.AddInParameter(dbCommand, "@email", DbType.String, fornecedor.Email);
                    db.AddInParameter(dbCommand, "@dirf", DbType.Boolean, fornecedor.Dirf);
                    db.AddInParameter(dbCommand, "@ramoatividade", DbType.String, fornecedor.RamoAtividade);
                    db.AddInParameter(dbCommand, "@nomecontato", DbType.String, fornecedor.NomeContato);
                    db.AddInParameter(dbCommand, "@emailcontato", DbType.String, fornecedor.EmailContato);
                    db.AddInParameter(dbCommand, "@dddtelcontato", DbType.String, fornecedor.DDDTelContato);
                    db.AddInParameter(dbCommand, "@telcontato", DbType.String, fornecedor.TelContato);
                    db.AddInParameter(dbCommand, "@dddcelcontato", DbType.String, fornecedor.DDDCelContato);
                    db.AddInParameter(dbCommand, "@celcontato", DbType.String, fornecedor.CelContato);
                    db.AddInParameter(dbCommand, "@ramalcontato", DbType.String, fornecedor.RamalContato);
                    db.AddInParameter(dbCommand, "@registro", DbType.String, fornecedor.Registro);
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

                    dbCommand = db.GetSqlStringCommand(" DELETE FROM public.fornecedor" +
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
        /// Retorna um objeto FornecedorDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FornecedorDTO GetFornecedor(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetFornecedor");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    DR.Read();
                    FornecedorDTO tab = new FornecedorDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nomefantasia = DR["nomefantasia"].ToString();
                    tab.Razaosocial = DR["razaosocial"].ToString();
                    tab.Endereco = DR["endereco"].ToString();
                    tab.Numero = DR["numero"].ToString();
                    tab.Complemento = DR["complemento"].ToString();
                    tab.Bairro = DR["bairro"].ToString();
                    tab.Cep = DR["cep"].ToString();
                    tab.Municipio = new MunicipioDAO().GetMunicipio(int.Parse(DR["id_municipio"].ToString()));
                    tab.Dddtelefone = DR["dddtelefone"].ToString();
                    tab.Telefone = DR["telefone"].ToString();
                    tab.Dddfax = DR["dddfax"].ToString();
                    tab.Fax = DR["fax"].ToString();
                    tab.Cnpj = DR["cnpj"].ToString();
                    tab.Cei = DR["cei"].ToString();
                    tab.Iestadual = DR["iestadual"].ToString();
                    tab.Imunicipal = DR["imunicipal"].ToString();
                    tab.Url = DR["url"].ToString();
                    tab.Email = DR["email"].ToString();
                    tab.Dirf = bool.Parse(DR["dirf"].ToString());
                    tab.Registro = DR["registro"].ToString();

                    //Tarefa 22
                    tab.RamoAtividade = DR["ramoatividade"].ToString();
                    tab.NomeContato = DR["nomecontato"].ToString();
                    tab.EmailContato = DR["emailcontato"].ToString();
                    tab.DDDTelContato = DR["dddtelcontato"].ToString();
                    tab.TelContato = DR["telcontato"].ToString();
                    tab.DDDCelContato = DR["dddcelcontato"].ToString();
                    tab.CelContato = DR["celcontato"].ToString();
                    tab.RamalContato = DR["ramalcontato"].ToString();

                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FornecedorDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FornecedorDTO> GetGridFornecedor(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridFornecedor");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    List<FornecedorDTO> List = new List<FornecedorDTO>();
                    while (DR.Read())
                    {
                        FornecedorDTO tab = new FornecedorDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nomefantasia = DR["nomefantasia"].ToString();
                        tab.Razaosocial = DR["razaosocial"].ToString();
                        tab.Cnpj = DR["cnpj"].ToString();
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
