using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class ClienteDAO
    {
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance);
        DbCommand dbcommand = null;
        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        public ClienteDAO()
        { }

        public ClienteDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        public int Insert(ClienteDTO cliente)
        {
            bool transactionstart = false;
            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    try
                    {

                        connection.Open();
                        transactionstart = true;
                        if (Transaction == null)
                        {
                            Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                        }
                        dbcommand = db.GetSqlStringCommand("Insert Into public.clientes(" +
                            " nome," +
                            " datacadastro," +
                            " datanasc," +
                            " tipo_pessoa," +
                            " endereco," +
                            " numero," +
                            " bairro," +
                            " compl," +
                            " telefone," +
                            " celular," +
                            " cep," +
                            " uf," +
                            " email," +
                            " cpf_cnpj," +
                            " rg," +
                            " emissor," +
                            " obs1," +
                            " obs2," +
                            " obs3," +
                            " contato," +
                            " profissao," +
                            " time," +
                            " passatempo," +
                            " id_municipio" +
                            ") VALUES (" +
                            " @nome," +
                            " @datacadastro," +
                            " @datanasc," +
                            " @tipo_pessoa," +
                            " @endereco," +
                            " @numero," +
                            " @bairro," +
                            " @compl," +
                            " @telefone," +
                            " @celular," +
                            " @cep," +
                            " @uf," +
                            " @email," +
                            " @cpf_cnpj," +
                            " @rg," +
                            " @emissor," +
                            " @obs1," +
                            " @obs2," +
                            " @obs3," +
                            " @contato," +
                            " @profissao," +
                            " @time," +
                            " @passatempo," +
                            " @id_municipio);" +
                            " SELECT currval('clientes_id_seq');");

                        db.AddInParameter(dbcommand, "@nome", DbType.String, cliente.Nome);
                        db.AddInParameter(dbcommand, "@datacadastro", DbType.Date, (DateTime?)cliente.DataCadastro);
                        db.AddInParameter(dbcommand, "@datanasc", DbType.Date, (DateTime?)cliente.DataNasc);
                        db.AddInParameter(dbcommand, "@tipo_pessoa", DbType.String, cliente.Tipo_pessoa);
                        db.AddInParameter(dbcommand, "@endereco", DbType.String, cliente.Endereco);
                        db.AddInParameter(dbcommand, "@numero", DbType.String, cliente.Numero);
                        db.AddInParameter(dbcommand, "@bairro", DbType.String, cliente.Bairro);
                        db.AddInParameter(dbcommand, "@compl", DbType.String, cliente.Compl);
                        db.AddInParameter(dbcommand, "@telefone", DbType.String, cliente.Telefone);
                        db.AddInParameter(dbcommand, "@celular", DbType.String, cliente.Celular);
                        db.AddInParameter(dbcommand, "@cep", DbType.String, cliente.Cep);
                        db.AddInParameter(dbcommand, "@uf", DbType.String, cliente.UF);
                        db.AddInParameter(dbcommand, "@email", DbType.String, cliente.Email);
                        db.AddInParameter(dbcommand, "@cpf_cnpj", DbType.String, cliente.Cpf_Cnpj);
                        db.AddInParameter(dbcommand, "@rg", DbType.String, cliente.Rg);
                        db.AddInParameter(dbcommand, "@emissor", DbType.String, cliente.Emissor);
                        db.AddInParameter(dbcommand, "@obs1", DbType.String, cliente.Obs1);
                        db.AddInParameter(dbcommand, "@obs2", DbType.String, cliente.Obs2);
                        db.AddInParameter(dbcommand, "@obs3", DbType.String, cliente.Obs3);
                        db.AddInParameter(dbcommand, "@contato", DbType.String, cliente.Contato);
                        db.AddInParameter(dbcommand, "@profissao", DbType.String, cliente.Profissao);
                        db.AddInParameter(dbcommand, "@time", DbType.String, cliente.Time);
                        db.AddInParameter(dbcommand, "@passatempo", DbType.String, cliente.Passatempo);
                        db.AddInParameter(dbcommand, "@id_municipio", DbType.Int32, cliente.Cidade.Id);

                        int id = Convert.ToInt32(db.ExecuteScalar(dbcommand, Transaction));

                        if (transactionstart)
                        {
                            Transaction.Commit();
                            Transaction = null;
                        }
                        connection.Close();
                        return id;
                    }
                    catch (DbException dbex)
                    {
                        if (Transaction != null)
                            Transaction.Rollback();
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        Dispose();
                        throw dbex;
                    }
                }
            }

            catch
            {
                throw;
            }

        }

        public bool Update(ClienteDTO cliente)
        {
            Transaction = null;
            DbConnection connection = null;
            bool transactionstart = false;

            try
            {
                using (connection = db.CreateConnection())
                {
                    try
                    {
                        connection.Open();
                        if (Transaction == null)
                        {
                            Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                            transactionstart = true;
                        }

                        dbcommand = db.GetSqlStringCommand(" UPDATE public.clientes SET" +
                                                           "    nome = @nome," +
                                                           "    datacadastro = @datacadastro," +
                                                           "    datanasc = @datanasc," +
                                                           "    tipo_pessoa = @tipo_pessoa," +
                                                           "    endereco = @endereco," +
                                                           "    numero = @numero," +
                                                           "    bairro = @bairro," +
                                                           "    compl = @compl," +
                                                           "    telefone = @telefone," +
                                                           "    celular = @celular," +
                                                           "    cep = @cep," +
                                                           "    uf = @uf," +
                                                           "    email = @email," +
                                                           "    cpf_cnpj = @cpf_cnpj," +
                                                           "    rg = @rg," +
                                                           "    emissor = @emissor," +
                                                           "    obs1 = @obs1," +
                                                           "    obs2 = @obs2," +
                                                           "    obs3 = @obs3," +
                                                           "    contato = @contato," +
                                                           "    profissao = @profissao," +
                                                           "    time = @time," +
                                                           "    passatempo = @passatempo," +
                                                           "    id_municipio = @id_municipio" +
                                                           "     WHERE" +
                                                           "     id = @id");
                        db.AddInParameter(dbcommand, "@nome", DbType.String, cliente.Nome);
                        db.AddInParameter(dbcommand, "@datacadastro", DbType.Date, (DateTime?)cliente.DataCadastro);
                        db.AddInParameter(dbcommand, "@datanasc", DbType.Date, (DateTime?)cliente.DataNasc);
                        db.AddInParameter(dbcommand, "@tipo_pessoa", DbType.String, cliente.Tipo_pessoa);
                        db.AddInParameter(dbcommand, "@endereco", DbType.String, cliente.Endereco);
                        db.AddInParameter(dbcommand, "@numero", DbType.String, cliente.Numero);
                        db.AddInParameter(dbcommand, "@bairro", DbType.String, cliente.Bairro);
                        db.AddInParameter(dbcommand, "@compl", DbType.String, cliente.Compl);
                        db.AddInParameter(dbcommand, "@telefone", DbType.String, cliente.Telefone);
                        db.AddInParameter(dbcommand, "@celular", DbType.String, cliente.Celular);
                        db.AddInParameter(dbcommand, "@cep", DbType.String, cliente.Cep);
                        db.AddInParameter(dbcommand, "@uf", DbType.String, cliente.UF);
                        db.AddInParameter(dbcommand, "@email", DbType.String, cliente.Email);
                        db.AddInParameter(dbcommand, "@cpf_cnpj", DbType.String, cliente.Cpf_Cnpj);
                        db.AddInParameter(dbcommand, "@rg", DbType.String, cliente.Rg);
                        db.AddInParameter(dbcommand, "@emissor", DbType.String, cliente.Emissor);
                        db.AddInParameter(dbcommand, "@obs1", DbType.String, cliente.Obs1);
                        db.AddInParameter(dbcommand, "@obs2", DbType.String, cliente.Obs2);
                        db.AddInParameter(dbcommand, "@obs3", DbType.String, cliente.Obs3);
                        db.AddInParameter(dbcommand, "@contato", DbType.String, cliente.Contato);
                        db.AddInParameter(dbcommand, "@profissao", DbType.String, cliente.Profissao);
                        db.AddInParameter(dbcommand, "@time", DbType.String, cliente.Time);
                        db.AddInParameter(dbcommand, "@passatempo", DbType.String, cliente.Passatempo);
                        db.AddInParameter(dbcommand, "@id", DbType.String, cliente.Id);
                        db.AddInParameter(dbcommand, "@id_municipio", DbType.Int32, cliente.Cidade.Id);
                        db.ExecuteNonQuery(dbcommand, Transaction);

                        if (transactionstart)
                        {
                            Transaction.Commit();
                            Transaction = null;
                        }
                        connection.Close();
                        return true;

                    }
                    catch
                    {
                        throw;
                    }
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

                    dbcommand = db.GetSqlStringCommand(" DELETE FROM public.clientes" +
                                                       " WHERE" +
                                                       " id = @id;");

                    db.AddInParameter(dbcommand, "@id", DbType.Int32, id);
                    db.ExecuteNonQuery(dbcommand, Transaction);

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

        public ClienteDTO GetCliente(int id)
        {
            try
            {
                dbcommand = db.GetStoredProcCommand("GetCliente");
                db.AddInParameter(dbcommand, "@id", DbType.Int32, id);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbcommand) : db.ExecuteReader(dbcommand, Transaction)))
                {
                    DR.Read();
                    ClienteDTO cliente = new ClienteDTO();
                    cliente.Id = int.Parse(DR["id"].ToString());
                    cliente.Nome = DR["nome"].ToString();
                    if (Convert.IsDBNull(DR["datanasc"]))
                        cliente.DataNasc = null;
                    else
                        cliente.DataNasc = (DateTime)DR["datanasc"];

                    if (Convert.IsDBNull(DR["datacadastro"]))
                        cliente.DataCadastro = null;
                    else
                        cliente.DataCadastro = (DateTime)DR["datacadastro"];
                    cliente.Tipo_pessoa = DR["tipo_pessoa"].ToString();
                    cliente.Endereco = DR["endereco"].ToString();
                    cliente.Numero = DR["numero"].ToString();
                    cliente.Bairro = DR["bairro"].ToString();
                    MunicipioDTO municipio = new MunicipioDTO();
                    if (!Convert.IsDBNull(DR["id_municipio"]))
                    {
                        MunicipioDAO municipiodata = new MunicipioDAO();
                        municipio.Id = Convert.ToInt32(DR["id_municipio"]);
                        municipio = municipiodata.GetMunicipio(municipio.Id);
                    }
                    cliente.Cidade = municipio;
                    cliente.Compl = DR["compl"].ToString();
                    cliente.Telefone = DR["telefone"].ToString();
                    cliente.Celular = DR["celular"].ToString();
                    
                    cliente.Cep = DR["cep"].ToString();
                    cliente.UF = DR["uf"].ToString();
                    cliente.Email = DR["email"].ToString();
                    cliente.Cpf_Cnpj = DR["cpf_cnpj"].ToString();
                    cliente.Rg = DR["rg"].ToString();
                    cliente.Emissor = DR["emissor"].ToString();
                    cliente.Obs1 = DR["obs1"].ToString();
                    cliente.Obs2 = DR["obs2"].ToString();
                    cliente.Obs3 = DR["obs3"].ToString();
                    cliente.Contato = DR["contato"].ToString();
                    cliente.Profissao = DR["profissao"].ToString();
                    cliente.Time = DR["time"].ToString();
                    cliente.Passatempo = DR["passatempo"].ToString();
                    
                    return cliente;

                }
            }
            catch
            {
                throw;
            }
        }

        public List<ClienteDTO> GetGridCliente(string campo, string valorPesquisa)
        {
            try
            {
                dbcommand = db.GetStoredProcCommand("GetGridCliente");
                db.AddInParameter(dbcommand, "campo", DbType.String, campo);
                db.AddInParameter(dbcommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbcommand) : db.ExecuteReader(dbcommand, Transaction)))
                {
                    List<ClienteDTO> List = new List<ClienteDTO>();
                    while (DR.Read())
                    {
                        ClienteDTO cliente = new ClienteDTO();
                        cliente.Id = int.Parse(DR["id"].ToString());
                        cliente.Nome = DR["nome"].ToString();
                        cliente.Cpf_Cnpj = DR["cpf_cnpj"].ToString();
                        List.Add(cliente);
                    }
                    return List;
                }
            }
            catch
            {
                throw;
            }
        }

        #region IDisposable Members
        public void Dispose()
        {
            Transaction = null;
        }
        #endregion

        public bool ExistsCPF(int id_funcionario, string cpf)
        {
            try
            {
                using (dbcommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".ExistsCPF"))
                {
                    db.AddInParameter(dbcommand, "id_cliente", DbType.Int32, id_funcionario);
                    db.AddInParameter(dbcommand, "cpf_cnpj", DbType.String, cpf);
                    db.AddInParameter(dbcommand, "mesano", DbType.Date, Global.MesanoAtivo);
                    db.AddOutParameter(dbcommand, "return_value", DbType.Boolean, 5);
                    db.ExecuteScalar(dbcommand);

                    DbParameter retorno = dbcommand.Parameters["return_value"];
                    return (bool)retorno.Value;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
