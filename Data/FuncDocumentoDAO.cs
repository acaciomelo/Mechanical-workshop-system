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
    public class FuncDocumentoDAO : IDados<FuncDocumentoDTO>
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
        /// Instância básica para FuncDocumentoDAO.
        /// </summary>
        public FuncDocumentoDAO()
        { }

        /// <summary>
        /// Instância para FuncDocumentoDAO com controle de transação.
        /// </summary>
        public FuncDocumentoDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(FuncDocumentoDTO funcdocumento)
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
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(0, 'Inserindo documento do funcionário','" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }

                    dbCommand = db.GetSqlStringCommand(" INSERT INTO " + Global.EmpresaAtiva + ".funcdocumento(" +
                                                   "    id," +
                                                   "    id_funcionario," +
                                                   "    cpf," +
                                                   "    rg," +
                                                   "    rgemissao," +
                                                   "    rgorgao," +
                                                   "    id_ufrg," +
                                                   "    carteiramodelo," +
                                                   "    ctps," +
                                                   "    ctpsserie," +
                                                   "    ctpsemissao," +
                                                   "    id_ufctps," +
                                                   "    titulo," +
                                                   "    titulozona," +
                                                   "    titulosecao," +
                                                   "    cnh," +
                                                   "    cnhcategoria," +
                                                   "    cnhvencimento," +
                                                   "    reservista," +
                                                   "    rescategoria," +
                                                   "    id_ufreservista," +
                                                   "    id_banco" +
                                                   ") VALUES (" +
                                                   "    @id_funcionario," +
                                                   "    @id_funcionario," +
                                                   "    @cpf," +
                                                   "    @rg," +
                                                   "    @rgemissao," +
                                                   "    @rgorgao," +
                                                   "    @id_ufrg," +
                                                   "    @carteiramodelo," +
                                                   "    @ctps," +
                                                   "    @ctpsserie," +
                                                   "    @ctpsemissao," +
                                                   "    @id_ufctps," +
                                                   "    @titulo," +
                                                   "    @titulozona," +
                                                   "    @titulosecao," +
                                                   "    @cnh," +
                                                   "    @cnhcategoria," +
                                                   "    @cnhvencimento," +
                                                   "    @reservista," +
                                                   "    @rescategoria," +
                                                   "    @id_ufreservista," +
                                                   "    @id_banco" +
                                                   ");");
                    db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, funcdocumento.Id_funcionario);
                    db.AddInParameter(dbCommand, "@cpf", DbType.String, funcdocumento.Cpf);
                    db.AddInParameter(dbCommand, "@rg", DbType.String, funcdocumento.Rg);
                    db.AddInParameter(dbCommand, "@rgemissao", DbType.Date, (DateTime?)funcdocumento.Rgemissao);
                    db.AddInParameter(dbCommand, "@rgorgao", DbType.String, funcdocumento.Rgorgao);
                    if (funcdocumento.UFRG.Id != 0)
                        db.AddInParameter(dbCommand, "@id_ufrg", DbType.Int32, funcdocumento.UFRG.Id);
                    else
                        db.AddInParameter(dbCommand, "@id_ufrg", DbType.Int32, null);
                    db.AddInParameter(dbCommand, "@carteiramodelo", DbType.String, funcdocumento.Carteiramodelo);
                    db.AddInParameter(dbCommand, "@ctps", DbType.String, funcdocumento.Ctps);
                    db.AddInParameter(dbCommand, "@ctpsserie", DbType.String, funcdocumento.Ctpsserie);
                    db.AddInParameter(dbCommand, "@ctpsemissao", DbType.Date, (DateTime?)funcdocumento.Ctpsemissao);
                    if (funcdocumento.UFCTPS.Id != 0)
                        db.AddInParameter(dbCommand, "@id_ufctps", DbType.Int32, funcdocumento.UFCTPS.Id);
                    else
                        db.AddInParameter(dbCommand, "@id_ufctps", DbType.Int32, null);
                    db.AddInParameter(dbCommand, "@titulo", DbType.String, funcdocumento.Titulo);
                    db.AddInParameter(dbCommand, "@titulozona", DbType.String, funcdocumento.Titulozona);
                    db.AddInParameter(dbCommand, "@titulosecao", DbType.String, funcdocumento.Titulosecao);
                    db.AddInParameter(dbCommand, "@cnh", DbType.String, funcdocumento.Cnh);
                    db.AddInParameter(dbCommand, "@cnhcategoria", DbType.String, funcdocumento.Cnhcategoria);
                    db.AddInParameter(dbCommand, "@cnhvencimento", DbType.Date, (DateTime?)funcdocumento.Cnhvencimento);
                    db.AddInParameter(dbCommand, "@reservista", DbType.String, funcdocumento.Reservista);
                    db.AddInParameter(dbCommand, "@rescategoria", DbType.String, funcdocumento.Rescategoria);
                    if (funcdocumento.UFreservista.Id != 0)
                        db.AddInParameter(dbCommand, "@id_ufreservista", DbType.Int32, funcdocumento.UFreservista.Id);
                    else
                        db.AddInParameter(dbCommand, "@id_ufreservista", DbType.Int32, null);

                    if (funcdocumento.Banco.Id != 0)
                        db.AddInParameter(dbCommand, "@id_banco", DbType.Int32, funcdocumento.Banco.Id);
                    else
                        db.AddInParameter(dbCommand, "@id_banco", DbType.Int32, null);
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
        public bool Update(FuncDocumentoDTO funcdocumento)
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
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(0, 'Atualizando documento do funcionário','" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }

                    dbCommand = db.GetSqlStringCommand(" UPDATE " + Global.EmpresaAtiva + ".funcdocumento SET" +
                                                   "    id_funcionario = @id_funcionario," +
                                                   "    cpf = @cpf," +
                                                   "    rg = @rg," +
                                                   "    rgemissao = @rgemissao," +
                                                   "    rgorgao = @rgorgao," +
                                                   "    id_ufrg = @id_ufrg," +
                                                   "    carteiramodelo = @carteiramodelo," +
                                                   "    ctps = @ctps," +
                                                   "    ctpsserie = @ctpsserie," +
                                                   "    ctpsemissao = @ctpsemissao," +
                                                   "    id_ufctps = @id_ufctps," +
                                                   "    titulo = @titulo," +
                                                   "    titulozona = @titulozona," +
                                                   "    titulosecao = @titulosecao," +
                                                   "    cnh = @cnh," +
                                                   "    cnhcategoria = @cnhcategoria," +
                                                   "    cnhvencimento = @cnhvencimento," +
                                                   "    reservista = @reservista," +
                                                   "    rescategoria = @rescategoria," +
                                                   "    id_ufreservista = @id_ufreservista" +
                                                   " WHERE" +
                                                   "    id = @id");
                    db.AddInParameter(dbCommand, "@id", DbType.Int32, funcdocumento.Id);
                    db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, funcdocumento.Id_funcionario);
                    db.AddInParameter(dbCommand, "@cpf", DbType.String, funcdocumento.Cpf);
                    db.AddInParameter(dbCommand, "@rg", DbType.String, funcdocumento.Rg);
                    db.AddInParameter(dbCommand, "@rgemissao", DbType.Date, (DateTime?)funcdocumento.Rgemissao);
                    db.AddInParameter(dbCommand, "@rgorgao", DbType.String, funcdocumento.Rgorgao);
                    if (funcdocumento.UFRG.Id != 0)
                        db.AddInParameter(dbCommand, "@id_ufrg", DbType.Int32, funcdocumento.UFRG.Id);
                    else
                        db.AddInParameter(dbCommand, "@id_ufrg", DbType.Int32, null);
                    db.AddInParameter(dbCommand, "@carteiramodelo", DbType.String, funcdocumento.Carteiramodelo);
                    db.AddInParameter(dbCommand, "@ctps", DbType.String, funcdocumento.Ctps);
                    db.AddInParameter(dbCommand, "@ctpsserie", DbType.String, funcdocumento.Ctpsserie);
                    db.AddInParameter(dbCommand, "@ctpsemissao", DbType.Date, (DateTime?)funcdocumento.Ctpsemissao);
                    if (funcdocumento.UFCTPS.Id != 0)
                        db.AddInParameter(dbCommand, "@id_ufctps", DbType.Int32, funcdocumento.UFCTPS.Id);
                    else
                        db.AddInParameter(dbCommand, "@id_ufctps", DbType.Int32, null);
                    db.AddInParameter(dbCommand, "@titulo", DbType.String, funcdocumento.Titulo);
                    db.AddInParameter(dbCommand, "@titulozona", DbType.String, funcdocumento.Titulozona);
                    db.AddInParameter(dbCommand, "@titulosecao", DbType.String, funcdocumento.Titulosecao);
                    db.AddInParameter(dbCommand, "@cnh", DbType.String, funcdocumento.Cnh);
                    db.AddInParameter(dbCommand, "@cnhcategoria", DbType.String, funcdocumento.Cnhcategoria);
                    db.AddInParameter(dbCommand, "@cnhvencimento", DbType.Date, (DateTime?)funcdocumento.Cnhvencimento);
                    db.AddInParameter(dbCommand, "@reservista", DbType.String, funcdocumento.Reservista);
                    db.AddInParameter(dbCommand, "@rescategoria", DbType.String, funcdocumento.Rescategoria);
                    if (funcdocumento.UFreservista.Id != 0)
                        db.AddInParameter(dbCommand, "@id_ufreservista", DbType.Int32, funcdocumento.UFreservista.Id);
                    else
                        db.AddInParameter(dbCommand, "@id_ufreservista", DbType.Int32, null);

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

            try
            {


                db.ExecuteNonQuery(dbCommand, Transaction);
                return true;
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
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(0, 'Excluindo documento do funcionário','" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }

                    dbCommand = db.GetSqlStringCommand(" DELETE FROM " + Global.EmpresaAtiva + ".funcdocumento" +
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
        /// Responsável por verificar a existência de CPF´s duplicados.
        /// </summary>
        /// <param name="id_funcionario">ID do funcionário ignorado na pesquisa</param>
        /// <param name="cpf">Número de um CPF válido</param>
        /// <returns>true=CPF encontrado, false=CPF não encontrado</returns>
        public bool ExistsCPF(int id_funcionario, string cpf)
        {
            try
            {
                using (dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".ExistsCPF"))
                {
                    db.AddInParameter(dbCommand, "id_funcionario", DbType.Int32, id_funcionario);
                    db.AddInParameter(dbCommand, "cpf", DbType.String, cpf);
                    db.AddInParameter(dbCommand, "mesano", DbType.Date, Global.MesanoAtivo);
                    db.AddOutParameter(dbCommand, "return_value", DbType.Boolean, 5);
                    db.ExecuteScalar(dbCommand);

                    DbParameter retorno = dbCommand.Parameters["return_value"];
                    return (bool)retorno.Value;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Retorna um objeto FuncdocumentoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public FuncDocumentoDTO GetFuncdocumentoFuncionario(int id_funcionario)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFuncdocumentoFuncionario");
                db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, id_funcionario);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    FuncDocumentoDTO tab = new FuncDocumentoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Cpf = DR["cpf"].ToString();
                    tab.Rg = DR["rg"].ToString();
                    if (Convert.IsDBNull(DR["rgemissao"]))
                        tab.Rgemissao = null;
                    else
                        tab.Rgemissao = (DateTime)DR["rgemissao"];
                    tab.Rgorgao = DR["rgorgao"].ToString();

                    //LOCALIZAR UF DE EMISSÃO DO RG
                    UFDTO ufrg = new UFDTO();
                    if (!Convert.IsDBNull(DR["id_ufrg"]))
                    {
                        UFDAO ufrgdata = new UFDAO();
                        ufrg.Id = Convert.ToInt32(DR["id_ufrg"]);
                        ufrg = ufrgdata.GetUF(ufrg.Id);
                    }
                    tab.UFRG = ufrg;
                    //

                    tab.Carteiramodelo = DR["carteiramodelo"].ToString();
                    tab.Ctps = DR["ctps"].ToString();
                    tab.Ctpsserie = DR["ctpsserie"].ToString();
                    if (Convert.IsDBNull(DR["ctpsemissao"]))
                        tab.Ctpsemissao = null;
                    else
                        tab.Ctpsemissao = (DateTime)DR["ctpsemissao"];

                    //LOCALIZAR UF DE EMISSÃO DA CTPS
                    UFDTO ufctps = new UFDTO();
                    if (!Convert.IsDBNull(DR["id_ufctps"]))
                    {
                        UFDAO ufctpsdata = new UFDAO();
                        ufctps.Id = Convert.ToInt32(DR["id_ufctps"]);
                        ufctps = ufctpsdata.GetUF(ufctps.Id);
                    }
                    tab.UFCTPS = ufctps;

                    tab.Titulo = DR["titulo"].ToString();
                    tab.Titulozona = DR["titulozona"].ToString();
                    tab.Titulosecao = DR["titulosecao"].ToString();
                    tab.Cnh = DR["cnh"].ToString();
                    tab.Cnhcategoria = DR["cnhcategoria"].ToString();
                    if (Convert.IsDBNull(DR["cnhvencimento"]))
                        tab.Cnhvencimento = null;
                    else
                        tab.Cnhvencimento = (DateTime)DR["cnhvencimento"];
                    tab.Reservista = DR["reservista"].ToString();
                    tab.Rescategoria = DR["rescategoria"].ToString();

                    //LOCALIZAR UF DE EMISSÃO DA RESERVISTA
                    UFDTO ufreservista = new UFDTO();
                    if (!Convert.IsDBNull(DR["id_ufreservista"]))
                    {
                        UFDAO ufreservistadata = new UFDAO();
                        ufreservista.Id = Convert.ToInt32(DR["id_ufreservista"]);
                        ufreservista = ufreservistadata.GetUF(ufreservista.Id);
                    }
                    tab.UFreservista = ufreservista;
                    //

                    //LOCALIZAR BANCO PARA DEPÓSITO DO PIS
                    BancoDTO banco = new BancoDTO();
                    if (!Convert.IsDBNull(DR["id_banco"]))
                    {
                        BancoDAO bancodata = new BancoDAO();
                        banco.Id = Convert.ToInt32(DR["id_banco"]);
                        banco = bancodata.GetBanco(banco.Id);
                    }
                    tab.Banco = banco;
                    //
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