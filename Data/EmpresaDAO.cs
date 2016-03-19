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
    public class EmpresaDAO : IDados<EmpresaDTO>, IDisposable
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
        /// Instância básica para EmpresaDAO.
        /// </summary>
        public EmpresaDAO()
        { }

        /// <summary>
        /// Instância para EmpresaDAO com controle de transação.
        /// </summary>
        public EmpresaDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(EmpresaDTO empresa)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1091, '" + empresa.Razaosocial + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA

                        //remover cei,valorcapital,
                        dbCommand = db.GetSqlStringCommand(" INSERT INTO public.empresa(" +
                                                           "    nomefantasia," +
                                                           "    razaosocial," +
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
                                                           "    cnpj," +
                                                           "    iestadual," +
                                                           "    imunicipal," +
                                                           "    registro," +
                                                           "    orgaoregistro," +
                                                           "    dataregistro," +
                                                           "    inicioatividade," +
                                                           "    encerratividade," +
                                                           "    id_naturezajuridica," +
                                                           "    id_cnae," +
                                                           "    url," +
                                                           "    email," +
                                                           "    tipo," +
                                                           "    logotipo," +
                                                           "    especialidade" +
                                                           ") VALUES (" +
                                                           "    @nomefantasia," +
                                                           "    @razaosocial," +
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
                                                           "    @cnpj," +
                                                           "    @iestadual," +
                                                           "    @imunicipal," +
                                                           "    @registro," +
                                                           "    @orgaoregistro," +
                                                           "    @dataregistro," +
                                                           "    @inicioatividade," +
                                                           "    @encerratividade," +
                                                           "    @id_naturezajuridica," +
                                                           "    @id_cnae," +
                                                           "    @url," +
                                                           "    @email," +
                                                           "    @tipo," +
                                                           "    @logotipo," +
                                                           "    @especialidade); " +
                                                           " SELECT currval('empresa_id_seq');");
                        db.AddInParameter(dbCommand, "@nomefantasia", DbType.String, empresa.Nomefantasia);
                        db.AddInParameter(dbCommand, "@razaosocial", DbType.String, empresa.Razaosocial);
                        db.AddInParameter(dbCommand, "@endereco", DbType.String, empresa.Endereco);
                        db.AddInParameter(dbCommand, "@numero", DbType.String, empresa.Numero);
                        db.AddInParameter(dbCommand, "@complemento", DbType.String, empresa.Complemento);
                        db.AddInParameter(dbCommand, "@bairro", DbType.String, empresa.Bairro);
                        db.AddInParameter(dbCommand, "@cep", DbType.String, empresa.Cep);
                        db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, empresa.Municipio.Id);
                        db.AddInParameter(dbCommand, "@dddtelefone", DbType.String, empresa.Dddtelefone);
                        db.AddInParameter(dbCommand, "@telefone", DbType.String, empresa.Telefone);
                        db.AddInParameter(dbCommand, "@dddfax", DbType.String, empresa.Dddfax);
                        db.AddInParameter(dbCommand, "@fax", DbType.String, empresa.Fax);
                        db.AddInParameter(dbCommand, "@cnpj", DbType.String, empresa.Cnpj);
                        db.AddInParameter(dbCommand, "@iestadual", DbType.String, empresa.Iestadual);
                        db.AddInParameter(dbCommand, "@imunicipal", DbType.String, empresa.Imunicipal);
                        db.AddInParameter(dbCommand, "@registro", DbType.String, empresa.Registro);
                        db.AddInParameter(dbCommand, "@orgaoregistro", DbType.String, empresa.Orgaoregistro);
                        db.AddInParameter(dbCommand, "@dataregistro", DbType.Date, (DateTime?)empresa.Dataregistro);
                        db.AddInParameter(dbCommand, "@inicioatividade", DbType.Date, (DateTime?)empresa.Inicioatividade);
                        db.AddInParameter(dbCommand, "@encerratividade", DbType.Date, (DateTime?)empresa.Encerratividade);
                        db.AddInParameter(dbCommand, "@valorcapital", DbType.Decimal, empresa.Valorcapital);
                        db.AddInParameter(dbCommand, "@id_naturezajuridica", DbType.Int32, empresa.Naturezajuridica.Id);
                        db.AddInParameter(dbCommand, "@id_cnae", DbType.Int32, empresa.CNAE.Id);
                        db.AddInParameter(dbCommand, "@url", DbType.String, empresa.Url);
                        db.AddInParameter(dbCommand, "@tipo", DbType.String, empresa.Tipo);
                        db.AddInParameter(dbCommand, "@logotipo", DbType.Binary, empresa.Logotipo);
                        db.AddInParameter(dbCommand, "@email", DbType.String, empresa.Email);
                        db.AddInParameter(dbCommand, "@especialidade", DbType.String, empresa.Especialidade);

                        int id = Convert.ToInt32(db.ExecuteScalar(dbCommand, Transaction));
                        PersisteListas(empresa, id);
                        Transaction.Commit();
                        connection.Close();
                        Dispose();
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

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(EmpresaDTO empresa)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1092, '" + empresa.Razaosocial + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" UPDATE public.empresa SET" +
                                                           "    nomefantasia = @nomefantasia," +
                                                           "    razaosocial = @razaosocial," +
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
                                                           "    cnpj = @cnpj," +
                                                           "    iestadual = @iestadual," +
                                                           "    imunicipal = @imunicipal," +
                                                           "    registro = @registro," +
                                                           "    orgaoregistro = @orgaoregistro," +
                                                           "    dataregistro = @dataregistro," +
                                                           "    inicioatividade = @inicioatividade," +
                                                           "    encerratividade = @encerratividade," +
                                                           "    id_naturezajuridica = @id_naturezajuridica," +
                                                           "    id_cnae = @id_cnae," +
                                                           "    url = @url," +
                                                           "    email = @email," +
                                                           "    tipo = @tipo," +
                                                           "    logotipo = @logotipo," +
                                                           "    especialidade = @especialidade" +
                                                           " WHERE" +
                                                           "    id = @id");
                        db.AddInParameter(dbCommand, "@id", DbType.Int32, empresa.Id);
                        db.AddInParameter(dbCommand, "@nomefantasia", DbType.String, empresa.Nomefantasia);
                        db.AddInParameter(dbCommand, "@razaosocial", DbType.String, empresa.Razaosocial);
                        db.AddInParameter(dbCommand, "@endereco", DbType.String, empresa.Endereco);
                        db.AddInParameter(dbCommand, "@numero", DbType.String, empresa.Numero);
                        db.AddInParameter(dbCommand, "@complemento", DbType.String, empresa.Complemento);
                        db.AddInParameter(dbCommand, "@bairro", DbType.String, empresa.Bairro);
                        db.AddInParameter(dbCommand, "@cep", DbType.String, empresa.Cep);
                        db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, empresa.Municipio.Id);
                        db.AddInParameter(dbCommand, "@dddtelefone", DbType.String, empresa.Dddtelefone);
                        db.AddInParameter(dbCommand, "@telefone", DbType.String, empresa.Telefone);
                        db.AddInParameter(dbCommand, "@dddfax", DbType.String, empresa.Dddfax);
                        db.AddInParameter(dbCommand, "@fax", DbType.String, empresa.Fax);
                        db.AddInParameter(dbCommand, "@cnpj", DbType.String, empresa.Cnpj);
                        db.AddInParameter(dbCommand, "@iestadual", DbType.String, empresa.Iestadual);
                        db.AddInParameter(dbCommand, "@imunicipal", DbType.String, empresa.Imunicipal);
                        db.AddInParameter(dbCommand, "@registro", DbType.String, empresa.Registro);
                        db.AddInParameter(dbCommand, "@orgaoregistro", DbType.String, empresa.Orgaoregistro);
                        db.AddInParameter(dbCommand, "@dataregistro", DbType.Date, (DateTime?)empresa.Dataregistro);
                        db.AddInParameter(dbCommand, "@inicioatividade", DbType.Date, (DateTime?)empresa.Inicioatividade);
                        db.AddInParameter(dbCommand, "@encerratividade", DbType.Date, (DateTime?)empresa.Encerratividade);
                        db.AddInParameter(dbCommand, "@id_naturezajuridica", DbType.Int32, empresa.Naturezajuridica.Id);
                        db.AddInParameter(dbCommand, "@id_cnae", DbType.Int32, empresa.CNAE.Id);
                        db.AddInParameter(dbCommand, "@url", DbType.String, empresa.Url);
                        db.AddInParameter(dbCommand, "@email", DbType.String, empresa.Email);
                        db.AddInParameter(dbCommand, "@tipo", DbType.String, empresa.Tipo);
                        db.AddInParameter(dbCommand, "@logotipo", DbType.Binary, empresa.Logotipo);
                        db.AddInParameter(dbCommand, "@especialidade", DbType.String, empresa.Especialidade);

                        db.ExecuteNonQuery(dbCommand, Transaction);
                        PersisteListas(empresa, empresa.Id);
                        Transaction.Commit();
                        connection.Close();
                        Dispose();
                        return true;
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1093, 'Emp.: " + id.ToString() + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" DELETE FROM public.empresa" +
                                                           " WHERE" +
                                                           "    id = @id;");
                        db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
                        db.ExecuteNonQuery(dbCommand, Transaction);
                        Transaction.Commit();
                        connection.Close();
                        Dispose();
                        return true;
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

        /// <summary>
        /// Retorna um objeto EmpresaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public EmpresaDTO GetEmpresa(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetEmpresa");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    EmpresaDTO tab = new EmpresaDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nomefantasia = DR["nomefantasia"].ToString();
                    tab.Razaosocial = DR["razaosocial"].ToString();
                    tab.Endereco = DR["endereco"].ToString();
                    tab.Numero = DR["numero"].ToString();
                    tab.Complemento = DR["complemento"].ToString();
                    tab.Bairro = DR["bairro"].ToString();
                    tab.Cep = DR["cep"].ToString();

                    //LOCALIZAR MUNICÍPIO
                    MunicipioDTO municipio = new MunicipioDTO();
                    if (Convert.ToInt32(DR["id_municipio"]) != 0)
                    {
                        MunicipioDAO municipiodata = new MunicipioDAO();
                        municipio.Id = Convert.ToInt32(DR["id_municipio"]);
                        municipio = municipiodata.GetMunicipio(municipio.Id);
                    }
                    tab.Municipio = municipio;
                    //

                    tab.Dddtelefone = DR["dddtelefone"].ToString();
                    tab.Telefone = DR["telefone"].ToString();
                    tab.Dddfax = DR["dddfax"].ToString();
                    tab.Fax = DR["fax"].ToString();
                    tab.Cnpj = DR["cnpj"].ToString();
                    tab.Iestadual = DR["iestadual"].ToString();
                    tab.Imunicipal = DR["imunicipal"].ToString();
                    tab.Registro = DR["registro"].ToString();
                    tab.Orgaoregistro = DR["orgaoregistro"].ToString();
                    if (Convert.IsDBNull(DR["dataregistro"]))
                        tab.Dataregistro = null;
                    else
                        tab.Dataregistro = (DateTime)DR["dataregistro"];
                    if (Convert.IsDBNull(DR["inicioatividade"]))
                        tab.Inicioatividade = null;
                    else
                        tab.Inicioatividade = (DateTime)DR["inicioatividade"];
                    if (Convert.IsDBNull(DR["encerratividade"]))
                        tab.Encerratividade = null;
                    else
                        tab.Encerratividade = (DateTime)DR["encerratividade"];

                    //LOCALIZAR NATUREZA JURÍDICA
                    NaturezaJuridicaDTO naturezajuridica = new NaturezaJuridicaDTO();
                    if (Convert.ToInt32(DR["id_naturezajuridica"]) != 0)
                    {
                        NaturezaJuridicaDAO naturezajuridicadata = new NaturezaJuridicaDAO();
                        naturezajuridica.Id = Convert.ToInt32(DR["id_naturezajuridica"]);
                        naturezajuridica = naturezajuridicadata.GetNaturezajuridica(naturezajuridica.Id);
                    }
                    tab.Naturezajuridica = naturezajuridica;
                    //

                    if (Convert.IsDBNull(DR["datatrava"]))
                        tab.DataTrava = null;
                    else
                        tab.DataTrava = (DateTime)DR["datatrava"];

                    //LOCALIZAR CNAE
                    CNAEDTO cnae = new CNAEDTO();
                    if (Convert.ToInt32(DR["id_cnae"]) != 0)
                    {
                        CNAEDAO cnaedata = new CNAEDAO();
                        cnae.Id = Convert.ToInt32(DR["id_cnae"]);
                        cnae = cnaedata.GetCNAE(cnae.Id);
                    }
                    tab.CNAE = cnae;
                    //

                    tab.Url = DR["url"].ToString();
                    tab.Email = DR["email"].ToString();
                    tab.Tipo = DR["tipo"].ToString();
                    tab.Logotipo = (Convert.IsDBNull(DR["logotipo"]) ? null : (byte[])DR["logotipo"]);
                    tab.Especialidade = DR["especialidade"].ToString();

                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos EmpresaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<EmpresaDTO> GetGridEmpresa(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridEmpresa");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<EmpresaDTO> List = new List<EmpresaDTO>();
                    while (DR.Read())
                    {
                        EmpresaDTO tab = new EmpresaDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nomefantasia = DR["nomefantasia"].ToString();
                        tab.Razaosocial = DR["razaosocial"].ToString();
                        tab.Cnpj = DR["cnpj"].ToString();
                        tab.Tipo = DR["tipo"].ToString();
                        if (Convert.IsDBNull(DR["datatrava"]))
                            tab.DataTrava = null;
                        else
                            tab.DataTrava = (DateTime)DR["datatrava"];
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
        /// Trava de segurança.
        /// </summary>
        public void Update(int id_empresa, DateTime? data)
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
                            //if (data.HasValue)
                            //    db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1092, 'Lock','" + MechTech.Util.Global.UsuarioAtivo + "');");
                            //else
                            //    db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1092, 'Unlock','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" UPDATE public.empresa SET" +
                                                           "    datatrava = @datatrava" +
                                                           " WHERE" +
                                                           "    id = @id");
                        db.AddInParameter(dbCommand, "@id", DbType.Int32, id_empresa);
                        db.AddInParameter(dbCommand, "@datatrava", DbType.Date, data);
                        db.ExecuteNonQuery(dbCommand, Transaction);
                        Transaction.Commit();
                        connection.Close();
                        Dispose();
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

        public string GetRazaoSocial(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetEmpresa");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    return DR["razaosocial"].ToString();
                }
            }
            catch
            {
                throw;
            }
        }

        public int GetSimples(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetEmpresa");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    return int.Parse(DR["id_simples"].ToString());
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto EmpresaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public EmpresaDTO GetDadosImpressao(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetEmpresa");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    EmpresaDTO tab = new EmpresaDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Razaosocial = DR["razaosocial"].ToString();
                    tab.Nomefantasia = DR["nomefantasia"].ToString();
                    tab.Endereco = DR["endereco"].ToString();
                    tab.Numero = DR["numero"].ToString();
                    tab.Complemento = DR["complemento"].ToString();
                    tab.Bairro = DR["bairro"].ToString();
                    tab.Cep = DR["cep"].ToString();

                    //LOCALIZAR MUNICÍPIO
                    MunicipioDTO municipio = new MunicipioDTO();
                    if (Convert.ToInt32(DR["id_municipio"]) != 0)
                    {
                        MunicipioDAO municipiodata = new MunicipioDAO();
                        municipio.Id = Convert.ToInt32(DR["id_municipio"]);
                        municipio = municipiodata.GetMunicipio(municipio.Id);
                    }
                    tab.Municipio = municipio;
                    //

                    tab.Cnpj = DR["cnpj"].ToString();

                    //LOCALIZAR CNAE
                    CNAEDTO cnae = new CNAEDTO();
                    if (Convert.ToInt32(DR["id_cnae"]) != 0)
                    {
                        CNAEDAO cnaedata = new CNAEDAO();
                        cnae.Id = Convert.ToInt32(DR["id_cnae"]);
                        cnae = cnaedata.GetCNAE(cnae.Id);
                    }
                    tab.CNAE = cnae;
                    tab.Tipo = DR["tipo"].ToString();
                    //
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável pela persistência das listas agregadas a classe EmpresaDTO.
        /// </summary>
        /// <param name="Empresa">Objeto do tipo EmpresaDTO gerado na camada de apresentação</param>
        /// <param name="id_empresa">Chave primária do evento gerada no Banco de dados</param>
        private void PersisteListas(EmpresaDTO Empresa, int id_empresa)
        {
            //TABELA FAP
            FAPDAO fapdata = new FAPDAO(Transaction);

            if (fapdata.Delete(id_empresa))
            {
                foreach (FAPDTO itemfap in Empresa.FAPS)
                {
                    itemfap.ID_Empresa = id_empresa;
                    fapdata.Insert(itemfap);
                }
            }
            //
        }

        #region IDisposable Members
        public void Dispose()
        {
            Transaction = null;
        }
        #endregion
    }
}
