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
    public class ResponsavelDAO : IDados<ResponsavelDTO>
    {
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); //37959
        DbCommand dbCommand = null;

        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        /// <summary>
        /// Instância básica para ResponsavelDAO.
        /// </summary>
        public ResponsavelDAO()
        { }

        /// <summary>
        /// Instância para ResponsavelDAO com controle de transação.
        /// </summary>
        public ResponsavelDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(ResponsavelDTO responsavel)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1106, 'Resp.: " + responsavel.Nome + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" INSERT INTO public.responsavel(" +
                                                           "    nome," +
                                                           "    endereco," +
                                                           "    numero," +
                                                           "    complemento," +
                                                           "    bairro," +
                                                           "    cep," +
                                                           "    id_municipio," +
                                                           "    dddtelefone," +
                                                           "    telefone," +
                                                           "    dddfax," +
                                                           "    fax," +
                                                           "    email," +
                                                           "    cnpj," +
                                                           "    cpf," +
                                                           "    cei," +
                                                           "    nit," +
                                                           "    rg," +
                                                           "    rgemissor," +
                                                           "    id_ufrg," +
                                                           "    numeroregistro," +
                                                           "    id_ufnumeroregistro," +
                                                           "    contador," +
                                                           "    responsa," +
                                                           "    cargo," +
                                                           "    contato," +
                                                           "    url," +
                                                           "    inicioatividade," +
                                                           "    fimatividade," +
                                                           "    datanascimento," +
                                                           "    dddcelular," +
                                                           "    celular" +
                                                           ") VALUES (" +
                                                           "    @nome," +
                                                           "    @endereco," +
                                                           "    @numero," +
                                                           "    @complemento," +
                                                           "    @bairro," +
                                                           "    @cep," +
                                                           "    @id_municipio," +
                                                           "    @dddtelefone," +
                                                           "    @telefone," +
                                                           "    @dddfax," +
                                                           "    @fax," +
                                                           "    @email," +
                                                           "    @cnpj," +
                                                           "    @cpf," +
                                                           "    @cei," +
                                                           "    @nit," +
                                                           "    @rg," +
                                                           "    @rgemissor," +
                                                           "    @id_ufrg," +
                                                           "    @numeroregistro," +
                                                           "    @id_ufnumeroregistro," +
                                                           "    @contador," +
                                                           "    @responsa," +
                                                           "    @cargo," +
                                                           "    @contato," +
                                                           "    @url," +
                                                           "    @inicioatividade," +
                                                           "    @fimatividade," +
                                                           "    @datanascimento," +
                                                           "    @dddcelular," +
                                                           "    @celular);" +
                                                           " SELECT currval('responsavel_id_seq');");
                        db.AddInParameter(dbCommand, "@nome", DbType.String, responsavel.Nome);
                        db.AddInParameter(dbCommand, "@endereco", DbType.String, responsavel.Endereco);
                        db.AddInParameter(dbCommand, "@numero", DbType.String, responsavel.Numero);
                        db.AddInParameter(dbCommand, "@complemento", DbType.String, responsavel.Complemento);
                        db.AddInParameter(dbCommand, "@bairro", DbType.String, responsavel.Bairro);
                        db.AddInParameter(dbCommand, "@cep", DbType.String, responsavel.Cep);
                        db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, responsavel.Municipio.Id);
                        db.AddInParameter(dbCommand, "@dddtelefone", DbType.String, responsavel.Dddtelefone);
                        db.AddInParameter(dbCommand, "@telefone", DbType.String, responsavel.Telefone);
                        db.AddInParameter(dbCommand, "@dddfax", DbType.String, responsavel.Dddfax);
                        db.AddInParameter(dbCommand, "@fax", DbType.String, responsavel.Fax);
                        db.AddInParameter(dbCommand, "@email", DbType.String, responsavel.Email);
                        db.AddInParameter(dbCommand, "@cnpj", DbType.String, responsavel.Cnpj);
                        db.AddInParameter(dbCommand, "@cpf", DbType.String, responsavel.Cpf);
                        db.AddInParameter(dbCommand, "@cei", DbType.String, responsavel.Cei);
                        db.AddInParameter(dbCommand, "@nit", DbType.String, responsavel.Nit);
                        db.AddInParameter(dbCommand, "@rg", DbType.String, responsavel.Rg);
                        db.AddInParameter(dbCommand, "@rgemissor", DbType.String, responsavel.Rgemissor);
                        if (responsavel.UFRG.Id == 0)
                            db.AddInParameter(dbCommand, "@id_ufrg", DbType.Int32, Convert.DBNull);
                        else
                            db.AddInParameter(dbCommand, "@id_ufrg", DbType.Int32, responsavel.UFRG.Id);
                        db.AddInParameter(dbCommand, "@numeroregistro", DbType.String, responsavel.Numeroregistro);
                        if (responsavel.UFNumeroRegistro.Id == 0)
                            db.AddInParameter(dbCommand, "@id_ufnumeroregistro", DbType.Int32, Convert.DBNull);
                        else
                            db.AddInParameter(dbCommand, "@id_ufnumeroregistro", DbType.Int32, responsavel.UFNumeroRegistro.Id);
                        db.AddInParameter(dbCommand, "@contador", DbType.Boolean, responsavel.Contador);
                        db.AddInParameter(dbCommand, "@responsa", DbType.Boolean, responsavel.Responsa);
                        db.AddInParameter(dbCommand, "@cargo", DbType.String, responsavel.Cargo);
                        db.AddInParameter(dbCommand, "@contato", DbType.String, responsavel.Contato);
                        db.AddInParameter(dbCommand, "@url", DbType.String, responsavel.URL);
                        db.AddInParameter(dbCommand, "@inicioatividade", DbType.Date, (DateTime?)responsavel.InicioAtividade);
                        db.AddInParameter(dbCommand, "@fimatividade", DbType.Date, (DateTime?)responsavel.FimAtividade);
                        db.AddInParameter(dbCommand, "@datanascimento", DbType.Date, (DateTime?)responsavel.DataNascimento);
                        db.AddInParameter(dbCommand, "@dddcelular", DbType.String, responsavel.Dddcelular);
                        db.AddInParameter(dbCommand, "@celular", DbType.String, responsavel.Celular);
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
        public bool Update(ResponsavelDTO responsavel)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1107, 'Resp.: " + responsavel.Nome + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" UPDATE public.responsavel SET" +
                                                           "    nome = @nome," +
                                                           "    endereco = @endereco," +
                                                           "    numero = @numero," +
                                                           "    complemento = @complemento," +
                                                           "    bairro = @bairro," +
                                                           "    cep = @cep," +
                                                           "    id_municipio = @id_municipio," +
                                                           "    dddtelefone = @dddtelefone," +
                                                           "    telefone = @telefone," +
                                                           "    dddfax = @dddfax," +
                                                           "    fax = @fax," +
                                                           "    email = @email," +
                                                           "    cnpj = @cnpj," +
                                                           "    cpf = @cpf," +
                                                           "    cei = @cei," +
                                                           "    nit = @nit," +
                                                           "    rg = @rg," +
                                                           "    rgemissor = @rgemissor," +
                                                           "    id_ufrg = @id_ufrg," +
                                                           "    numeroregistro = @numeroregistro," +
                                                           "    id_ufnumeroregistro = @id_ufnumeroregistro," +
                                                           "    contador = @contador," +
                                                           "    responsa = @responsa," +
                                                           "    cargo = @cargo," +
                                                           "    contato = @contato," +
                                                           "    inicioatividade = @inicioatividade," +
                                                           "    fimatividade = @fimatividade," +
                                                           "    url = @url," +
                                                           "    datanascimento = @datanascimento," +
                                                           "    dddcelular = @dddcelular," +
                                                           "    celular = @celular" +
                                                           " WHERE" +
                                                           "    id = @id");
                        db.AddInParameter(dbCommand, "@id", DbType.Int32, responsavel.Id);
                        db.AddInParameter(dbCommand, "@nome", DbType.String, responsavel.Nome);
                        db.AddInParameter(dbCommand, "@endereco", DbType.String, responsavel.Endereco);
                        db.AddInParameter(dbCommand, "@numero", DbType.String, responsavel.Numero);
                        db.AddInParameter(dbCommand, "@complemento", DbType.String, responsavel.Complemento);
                        db.AddInParameter(dbCommand, "@bairro", DbType.String, responsavel.Bairro);
                        db.AddInParameter(dbCommand, "@cep", DbType.String, responsavel.Cep);
                        db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, responsavel.Municipio.Id);
                        db.AddInParameter(dbCommand, "@dddtelefone", DbType.String, responsavel.Dddtelefone);
                        db.AddInParameter(dbCommand, "@telefone", DbType.String, responsavel.Telefone);
                        db.AddInParameter(dbCommand, "@dddfax", DbType.String, responsavel.Dddfax);
                        db.AddInParameter(dbCommand, "@fax", DbType.String, responsavel.Fax);
                        db.AddInParameter(dbCommand, "@email", DbType.String, responsavel.Email);
                        db.AddInParameter(dbCommand, "@cnpj", DbType.String, responsavel.Cnpj);
                        db.AddInParameter(dbCommand, "@cpf", DbType.String, responsavel.Cpf);
                        db.AddInParameter(dbCommand, "@cei", DbType.String, responsavel.Cei);
                        db.AddInParameter(dbCommand, "@nit", DbType.String, responsavel.Nit);
                        db.AddInParameter(dbCommand, "@rg", DbType.String, responsavel.Rg);
                        db.AddInParameter(dbCommand, "@rgemissor", DbType.String, responsavel.Rgemissor);
                        if (responsavel.UFRG.Id == 0)
                            db.AddInParameter(dbCommand, "@id_ufrg", DbType.Int32, Convert.DBNull);
                        else
                            db.AddInParameter(dbCommand, "@id_ufrg", DbType.Int32, responsavel.UFRG.Id);
                        db.AddInParameter(dbCommand, "@numeroregistro", DbType.String, responsavel.Numeroregistro);
                        if (responsavel.UFNumeroRegistro.Id == 0)
                            db.AddInParameter(dbCommand, "@id_ufnumeroregistro", DbType.Int32, Convert.DBNull);
                        else
                            db.AddInParameter(dbCommand, "@id_ufnumeroregistro", DbType.Int32, responsavel.UFNumeroRegistro.Id);
                        db.AddInParameter(dbCommand, "@contador", DbType.Boolean, responsavel.Contador);
                        db.AddInParameter(dbCommand, "@responsa", DbType.Boolean, responsavel.Responsa);
                        db.AddInParameter(dbCommand, "@cargo", DbType.String, responsavel.Cargo);
                        db.AddInParameter(dbCommand, "@contato", DbType.String, responsavel.Contato);
                        db.AddInParameter(dbCommand, "@url", DbType.String, responsavel.URL);
                        db.AddInParameter(dbCommand, "@inicioatividade", DbType.Date, (DateTime?)responsavel.InicioAtividade);
                        db.AddInParameter(dbCommand, "@fimatividade", DbType.Date, (DateTime?)responsavel.FimAtividade);
                        db.AddInParameter(dbCommand, "@datanascimento", DbType.Date, (DateTime?)responsavel.DataNascimento);
                        db.AddInParameter(dbCommand, "@dddcelular", DbType.String, responsavel.Dddcelular);
                        db.AddInParameter(dbCommand, "@celular", DbType.String, responsavel.Celular);
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1108, '','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" DELETE FROM public.responsavel" +
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
        /// Retorna um objeto ResponsavelDTO para a instrução do conteúdo especificado.
        /// </summary>
        public ResponsavelDTO GetResponsavel(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetResponsavel");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    ResponsavelDTO tab = new ResponsavelDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nome = DR["nome"].ToString();
                    tab.Endereco = DR["endereco"].ToString();
                    tab.Numero = DR["numero"].ToString();
                    tab.Complemento = DR["complemento"].ToString();
                    tab.Bairro = DR["bairro"].ToString();
                    tab.Cep = DR["cep"].ToString();

                    MunicipioDTO municipio = new MunicipioDTO();
                    if (DR["id_municipio"] != Convert.DBNull)
                    {
                        MunicipioDAO municipioDAO = new MunicipioDAO();
                        municipio.Id = Convert.ToInt32(DR["id_municipio"]);
                        municipio = municipioDAO.GetMunicipio(municipio.Id);
                    }
                    tab.Municipio = municipio;

                    tab.Dddtelefone = DR["dddtelefone"].ToString();
                    tab.Telefone = DR["telefone"].ToString();
                    tab.Dddfax = DR["dddfax"].ToString();
                    tab.Fax = DR["fax"].ToString();
                    tab.Email = DR["email"].ToString();
                    tab.Cnpj = DR["cnpj"].ToString();
                    tab.Cpf = DR["cpf"].ToString();
                    tab.Cei = DR["cei"].ToString();
                    tab.Nit = DR["nit"].ToString();
                    tab.Rg = DR["rg"].ToString();
                    tab.Rgemissor = DR["rgemissor"].ToString();

                    UFDTO ufRG = new UFDTO();
                    if (DR["id_ufrg"] != Convert.DBNull)
                    {
                        UFDAO ufDAO = new UFDAO();
                        ufRG.Id = Convert.ToInt32(DR["id_ufrg"]);
                        ufRG = ufDAO.GetUF(ufRG.Id);
                    }
                    tab.UFRG = ufRG;

                    tab.Numeroregistro = DR["numeroregistro"].ToString();

                    UFDTO ufNumeroRegistro = new UFDTO();
                    if (DR["id_ufnumeroregistro"] != Convert.DBNull)
                    {
                        UFDAO ufDAO = new UFDAO();
                        ufNumeroRegistro.Id = Convert.ToInt32(DR["id_ufnumeroregistro"]);
                        ufNumeroRegistro = ufDAO.GetUF(ufNumeroRegistro.Id);
                    }
                    tab.UFNumeroRegistro = ufNumeroRegistro;

                    tab.Contador = (bool)DR["contador"];
                    tab.Responsa = (bool)DR["responsa"];
                    tab.Cargo = DR["cargo"].ToString();
                    tab.Contato = DR["contato"].ToString();
                    tab.URL = DR["url"].ToString();

                    if (Convert.IsDBNull(DR["inicioatividade"]))
                        tab.InicioAtividade = null;
                    else
                        tab.InicioAtividade = (DateTime)DR["inicioatividade"];
                    if (Convert.IsDBNull(DR["fimatividade"]))
                        tab.FimAtividade = null;
                    else
                        tab.FimAtividade = (DateTime)DR["fimatividade"];

                    if (Convert.IsDBNull(DR["datanascimento"]))
                        tab.DataNascimento = null;
                    else
                        tab.DataNascimento = (DateTime)DR["datanascimento"];

                    tab.Dddcelular = DR["dddcelular"].ToString();
                    tab.Celular = DR["celular"].ToString();

                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos ResponsavelDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<ResponsavelDTO> GetGridResponsavel(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridResponsavel");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<ResponsavelDTO> List = new List<ResponsavelDTO>();
                    while (DR.Read())
                    {
                        ResponsavelDTO tab = new ResponsavelDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nome = DR["nome"].ToString();
                        tab.Dddtelefone = DR["dddtelefone"].ToString();
                        tab.Telefone = DR["telefone"].ToString();
                        tab.Cpf = DR["cpf"].ToString();
                        tab.Contador = (bool)DR["contador"];
                        tab.Responsa = (bool)DR["responsa"];
                        tab.Cargo = DR["cargo"].ToString();
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
        /// Retorna uma lista de objetos ResponsavelDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<ResponsavelDTO> GetResponsaveis(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridResponsavel");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<ResponsavelDTO> List = new List<ResponsavelDTO>();
                    while (DR.Read())
                    {
                        ResponsavelDTO tab = GetResponsavel(int.Parse(DR["id"].ToString()));

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
        /// Checa se o responsável já se encontra cadastrado no sistema, através de algum documento.
        /// </summary>
        /// <param name="campo">nome do campo no banco de dados que será pesquisado</param>
        /// <param name="valorPesquisa">número do documento que será pesquisado</param>
        /// <param name="valorID">ID atual do responsável</param>
        /// <returns>true se já existir, false se não existir</returns>
        public bool ChecaResponsavel(string campo, string valorPesquisa, int valorID)
        {
            try
            {
                using (dbCommand = db.GetStoredProcCommand("ChecaResponsavel"))
                {
                    db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                    db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);
                    db.AddInParameter(dbCommand, "valorID", DbType.Int32, valorID);
                    db.AddOutParameter(dbCommand, "return_value", DbType.Boolean, 5);
                    db.ExecuteScalar(dbCommand);

                    DbParameter retorno = dbCommand.Parameters["return_value"];
                    return (bool)retorno.Value;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}