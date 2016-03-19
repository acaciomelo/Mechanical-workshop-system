using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

#region DEVEXPRESS
using Devart.Data.PostgreSql;
#endregion

#region MECHTECH
using MechTech.Util;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Data
{
    public class FuncionarioDAO : IDados<FuncionarioDTO>, IDisposable
    {
        
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        private bool transacaoExterna = false;
        public bool TransacaoExterna
        {
            get { return transacaoExterna; }
            set { transacaoExterna = value; }
        }

        /// <summary>
        /// Instância básica para FuncionarioDAO.
        /// </summary>
        public FuncionarioDAO()
        { }

        /// <summary>
        /// Instância para FuncionarioDAO com controle de transação.
        /// </summary>
        public FuncionarioDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Instância para FuncionarioDAO com controle de transação usada na transferencia.
        /// </summary>
        public FuncionarioDAO(DbTransaction transaction, bool Externo)
        {
            Transaction = transaction;
            TransacaoExterna = Externo;
        }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(FuncionarioDTO funcionario)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1117, 'Func.: " + funcionario.Nomecompleto + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" INSERT INTO " + Global.EmpresaAtiva + ".funcionario(" +
                                                           "    nomecompleto," +
                                                           "    endereco," +
                                                           "    numero," +
                                                           "    complemento," +
                                                           "    bairro," +
                                                           "    cep," +
                                                           "    id_municipio," +
                                                           "    dddtelefone," +
                                                           "    telefone," +
                                                           "    dddcelular," +
                                                           "    celular," +
                                                           "    email," +
                                                           "    sexo," +
                                                           "    foto," +
                                                           "    datanascimento," +
                                                           "    id_bancosalario," +
                                                           "    salconta," +
                                                           "    salcontadv1," +
                                                           "    salcontadv2," +
                                                           "    salagencia," +
                                                           "    salagenciadv," +
                                                           "    salcontatp" +
                                                           ") VALUES (" +
                                                           "    @nomecompleto," +
                                                           "    @endereco," +
                                                           "    @numero," +
                                                           "    @complemento," +
                                                           "    @bairro," +
                                                           "    @cep," +
                                                           "    @id_municipio," +
                                                           "    @dddtelefone," +
                                                           "    @telefone," +
                                                           "    @dddcelular," +
                                                           "    @celular," +
                                                           "    @email," +
                                                           "    @sexo," +
                                                           "    @foto," +
                                                           "    @datanascimento," +
                                                           "    @id_bancosalario," +
                                                           "    @salconta," +
                                                           "    @salcontadv1," +
                                                           "    @salcontadv2," +
                                                           "    @salagencia," +
                                                           "    @salagenciadv," +
                                                           "    @salcontatp" +
                                                           ");" +
                                                           " SELECT currval('" + Global.EmpresaAtiva + ".funcionario_id_seq');");
                        db.AddInParameter(dbCommand, "@nomecompleto", DbType.String, funcionario.Nomecompleto);
                        db.AddInParameter(dbCommand, "@endereco", DbType.String, funcionario.Endereco);
                        db.AddInParameter(dbCommand, "@numero", DbType.String, funcionario.Numero);
                        db.AddInParameter(dbCommand, "@complemento", DbType.String, funcionario.Complemento);
                        db.AddInParameter(dbCommand, "@bairro", DbType.String, funcionario.Bairro);
                        db.AddInParameter(dbCommand, "@cep", DbType.String, funcionario.Cep);
                        db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, funcionario.Municipio.Id);
                        db.AddInParameter(dbCommand, "@dddtelefone", DbType.String, funcionario.Dddtelefone);
                        db.AddInParameter(dbCommand, "@telefone", DbType.String, funcionario.Telefone);
                        db.AddInParameter(dbCommand, "@dddcelular", DbType.String, funcionario.Dddcelular);
                        db.AddInParameter(dbCommand, "@celular", DbType.String, funcionario.Celular);
                        db.AddInParameter(dbCommand, "@email", DbType.String, funcionario.Email);
                        db.AddInParameter(dbCommand, "@sexo", DbType.String, funcionario.Sexo);
                        db.AddInParameter(dbCommand, "@foto", DbType.Binary, funcionario.Foto); //LOW
                        db.AddInParameter(dbCommand, "@datanascimento", DbType.Date, (DateTime?)funcionario.Datanascimento);
                        if (funcionario.Bancosalario.Id != 0)
                            db.AddInParameter(dbCommand, "@id_bancosalario", DbType.Int32, funcionario.Bancosalario.Id);
                        else
                            db.AddInParameter(dbCommand, "@id_bancosalario", DbType.Int32, null);
                        db.AddInParameter(dbCommand, "@salconta", DbType.String, funcionario.Salconta);
                        db.AddInParameter(dbCommand, "@salcontadv1", DbType.String, funcionario.Salcontadv1);
                        db.AddInParameter(dbCommand, "@salcontadv2", DbType.String, funcionario.Salcontadv2);
                        db.AddInParameter(dbCommand, "@salagencia", DbType.String, funcionario.Salagencia);
                        db.AddInParameter(dbCommand, "@salagenciadv", DbType.String, funcionario.Salagenciadv);
                        db.AddInParameter(dbCommand, "@salcontatp", DbType.String, funcionario.Salcontatp);

                        int id = Convert.ToInt32(db.ExecuteScalar(dbCommand, Transaction));
                        PersisteListas(funcionario, id, "I");

                        if (!TransacaoExterna)
                        {
                            Transaction.Commit();
                            Dispose();
                        }

                        connection.Close();
                        return id;
                    }
                    catch (DbException dbex)
                    {
                        if (!TransacaoExterna)
                        {
                            if (Transaction != null)
                                Transaction.Rollback();
                            Dispose();
                        }
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
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
        public bool Update(FuncionarioDTO funcionario)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1118, 'Func.: " + funcionario.Nomecompleto + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" UPDATE " + Global.EmpresaAtiva + ".funcionario SET" +
                                                           "    nomecompleto = @nomecompleto," +
                                                           "    endereco = @endereco," +
                                                           "    numero = @numero," +
                                                           "    complemento = @complemento," +
                                                           "    bairro = @bairro," +
                                                           "    cep = @cep," +
                                                           "    id_municipio = @id_municipio," +
                                                           "    dddtelefone = @dddtelefone," +
                                                           "    telefone = @telefone," +
                                                           "    dddcelular = @dddcelular," +
                                                           "    celular = @celular," +
                                                           "    email = @email," +
                                                           "    sexo = @sexo," +
                                                           "    foto = @foto," +
                                                           "    datanascimento = @datanascimento," +
                                                           "    id_bancosalario = @id_bancosalario," +
                                                           "    salconta = @salconta," +
                                                           "    salcontadv1 = @salcontadv1," +
                                                           "    salcontadv2 = @salcontadv2," +
                                                           "    salagencia = @salagencia," +
                                                           "    salagenciadv = @salagenciadv," +
                                                           "    salcontatp = @salcontatp" +
                                                           " WHERE" +
                                                           "    id = @id");
                        db.AddInParameter(dbCommand, "@id", DbType.Int32, funcionario.Id);
                        db.AddInParameter(dbCommand, "@nomecompleto", DbType.String, funcionario.Nomecompleto);
                        db.AddInParameter(dbCommand, "@endereco", DbType.String, funcionario.Endereco);
                        db.AddInParameter(dbCommand, "@numero", DbType.String, funcionario.Numero);
                        db.AddInParameter(dbCommand, "@complemento", DbType.String, funcionario.Complemento);
                        db.AddInParameter(dbCommand, "@bairro", DbType.String, funcionario.Bairro);
                        db.AddInParameter(dbCommand, "@cep", DbType.String, funcionario.Cep);
                        db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, funcionario.Municipio.Id);
                        db.AddInParameter(dbCommand, "@dddtelefone", DbType.String, funcionario.Dddtelefone);
                        db.AddInParameter(dbCommand, "@telefone", DbType.String, funcionario.Telefone);
                        db.AddInParameter(dbCommand, "@dddcelular", DbType.String, funcionario.Dddcelular);
                        db.AddInParameter(dbCommand, "@celular", DbType.String, funcionario.Celular);
                        db.AddInParameter(dbCommand, "@email", DbType.String, funcionario.Email);
                        db.AddInParameter(dbCommand, "@sexo", DbType.String, funcionario.Sexo);
                        db.AddInParameter(dbCommand, "@foto", DbType.Binary, funcionario.Foto); //LOW
                        db.AddInParameter(dbCommand, "@datanascimento", DbType.Date, (DateTime?)funcionario.Datanascimento);
                        if (funcionario.Bancosalario.Id != 0)
                            db.AddInParameter(dbCommand, "@id_bancosalario", DbType.Int32, funcionario.Bancosalario.Id);
                        else
                            db.AddInParameter(dbCommand, "@id_bancosalario", DbType.Int32, null);
                        db.AddInParameter(dbCommand, "@salconta", DbType.String, funcionario.Salconta);
                        db.AddInParameter(dbCommand, "@salcontadv1", DbType.String, funcionario.Salcontadv1);
                        db.AddInParameter(dbCommand, "@salcontadv2", DbType.String, funcionario.Salcontadv2);
                        db.AddInParameter(dbCommand, "@salagencia", DbType.String, funcionario.Salagencia);
                        db.AddInParameter(dbCommand, "@salagenciadv", DbType.String, funcionario.Salagenciadv);
                        db.AddInParameter(dbCommand, "@salcontatp", DbType.String, funcionario.Salcontatp);
                        
                        db.ExecuteNonQuery(dbCommand, Transaction);
                        PersisteListas(funcionario, funcionario.Id, "U");

                        if (!TransacaoExterna)
                        {
                            Transaction.Commit();
                            Dispose();
                        }

                        connection.Close();
                        return true;
                    }
                    catch (DbException dbex)
                    {
                        if (!TransacaoExterna)
                        {
                            if (Transaction != null)
                                Transaction.Rollback();
                            Dispose();
                        }
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1119, 'Func.: " + id.ToString() + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" DELETE FROM " + Global.EmpresaAtiva + ".funcionario" +
                                                           " WHERE" +
                                                           "    id = @id;");
                        db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
                        db.ExecuteNonQuery(dbCommand, Transaction);

                        if (!TransacaoExterna)
                        {
                            Transaction.Commit();
                            Dispose();
                        }

                        connection.Close();
                        return true;
                    }
                    catch (DbException dbex)
                    {
                        if (!TransacaoExterna)
                        {
                            if (Transaction != null)
                                Transaction.Rollback();
                            Dispose();
                        }
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
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
        /// Retorna um objeto FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FuncionarioDTO GetFuncionario(int id)
        {
            try
            {
                FuncContratoDAO funccontratodata = null;
                if (Transaction == null)
                    funccontratodata = new FuncContratoDAO();
                else
                    funccontratodata = new FuncContratoDAO(Transaction);

                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFuncionario");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    DR.Read();
                    FuncionarioDTO tab = new FuncionarioDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nomecompleto = DR["nomecompleto"].ToString();
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
                    tab.Dddcelular = DR["dddcelular"].ToString();
                    tab.Celular = DR["celular"].ToString();
                    tab.Email = DR["email"].ToString();
                    tab.Sexo = DR["sexo"].ToString();
                    tab.Foto = (Convert.IsDBNull(DR["foto"]) ? null : (byte[])DR["foto"]);

                    if (Convert.IsDBNull(DR["datanascimento"]))
                        tab.Datanascimento = null;
                    else
                        tab.Datanascimento = (DateTime)DR["datanascimento"];

                    //LOCALIZAR BANCO PARA DEPÓSITO DE SALÁRIO
                    BancoDTO bancosalario = new BancoDTO();
                    if (!Convert.IsDBNull(DR["id_bancosalario"]))
                    {
                        BancoDAO bancosalariodata = new BancoDAO();
                        bancosalario.Id = Convert.ToInt32(DR["id_bancosalario"]);
                        bancosalario = bancosalariodata.GetBanco(bancosalario.Id);
                    }
                    tab.Bancosalario = bancosalario;
                    //

                    tab.Salconta = DR["salconta"].ToString();
                    tab.Salcontadv1 = DR["salcontadv1"].ToString();
                    tab.Salcontadv2 = DR["salcontadv2"].ToString();
                    tab.Salagencia = DR["salagencia"].ToString();
                    tab.Salagenciadv = DR["salagenciadv"].ToString();
                    tab.Salcontatp = DR["salcontatp"].ToString();

                    tab.Documento = new FuncDocumentoDAO().GetFuncdocumentoFuncionario(tab.Id);
                    tab.Contrato = funccontratodata.GetFunccontratoFuncionario(tab.Id);
                    tab.Salario = new FuncSalarioDAO().GetFuncsalarioFuncionario(tab.Id);
                    tab.SalarioAtual = new FuncSalarioDAO().GetFuncsalarioFuncionarioCurrent(tab.Id);

                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }




        public FuncionarioDTO GetFuncionario(int id, string tipo) //17145
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFuncionario");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    DR.Read();
                    FuncionarioDTO tab = new FuncionarioDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nomecompleto = DR["nomecompleto"].ToString();
                    tab.Documento = new FuncDocumentoDAO().GetFuncdocumentoFuncionario(tab.Id);

                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto FuncionarioDTO caso a instrução seja bem sucedida.
        /// Protótipo com seleção
        /// </summary>
        /// <param name="id">Id do funcionario</param>
        /// <param name="opcoes">Opções de pesquisa</param>
        public FuncionarioDTO GetFuncionario(int id, FuncPesquisaDTO opcoes)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFuncionario");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    DR.Read();
                    FuncionarioDTO tab = new FuncionarioDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nomecompleto = DR["nomecompleto"].ToString();
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
                    tab.Dddcelular = DR["dddcelular"].ToString();
                    tab.Celular = DR["celular"].ToString();
                    tab.Email = DR["email"].ToString();
                    tab.Sexo = DR["sexo"].ToString();
                    tab.Foto = (Convert.IsDBNull(DR["foto"]) ? null : (byte[])DR["foto"]);
                    if (Convert.IsDBNull(DR["datanascimento"]))
                        tab.Datanascimento = null;
                    else
                        tab.Datanascimento = (DateTime)DR["datanascimento"];

                    //LOCALIZAR BANCO PARA DEPÓSITO DE SALÁRIO
                    BancoDTO bancosalario = new BancoDTO();
                    if (!Convert.IsDBNull(DR["id_bancosalario"]))
                    {
                        BancoDAO bancosalariodata = new BancoDAO();
                        bancosalario.Id = Convert.ToInt32(DR["id_bancosalario"]);
                        bancosalario = bancosalariodata.GetBanco(bancosalario.Id);
                    }
                    tab.Bancosalario = bancosalario;
                    //
                    tab.Salconta = DR["salconta"].ToString();
                    tab.Salcontadv1 = DR["salcontadv1"].ToString();
                    tab.Salcontadv2 = DR["salcontadv2"].ToString();
                    tab.Salagencia = DR["salagencia"].ToString();
                    tab.Salagenciadv = DR["salagenciadv"].ToString();
                    tab.Salcontatp = DR["salcontatp"].ToString();
                    
                    if (opcoes.Documento)
                        tab.Documento = new FuncDocumentoDAO().GetFuncdocumentoFuncionario(tab.Id);
                    if (opcoes.Salario)
                        tab.Salario = new FuncSalarioDAO().GetFuncsalarioFuncionario(tab.Id);
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        public int GetTotalFuncionarios()
        {
            try
            {
                using (dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetTotalFuncionarios"))
                {
                    db.AddOutParameter(dbCommand, "return_value", DbType.Int32, 1);
                    db.ExecuteScalar(dbCommand);

                    DbParameter retorno = dbCommand.Parameters["return_value"];
                    return (int)retorno.Value;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Retorna uma lista de funcionários selecionados. Função original
        /// </summary>
        /// <param name="ids">Informar um ou mais códigos de funcionário separados por ponto-e-vírgula. Ex.: 3 ou 1;3;5;12;4</param>
        public List<FuncionarioDTO> GetFuncionarios(string ids, DateTime mesano, MechTech.Util.Enumeradores.Modulo modulo)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFuncionarios");
                db.AddInParameter(dbCommand, "ids", DbType.String, (ids.Contains(";") ? ids.Replace(";", ",") : ids));

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<FuncionarioDTO> funcionarios = new List<FuncionarioDTO>();
                    while (DR.Read())
                    {
                        FuncionarioDTO tab = GetFuncionario(int.Parse(DR["id"].ToString()));

                        /*FILTRAR FUNCIONÁRIOS DEMITIDOS*/
                        if (tab.Contrato.Datademissao.HasValue && !tab.Contrato.Datatransferencia.HasValue)
                        {
                            DateTime mesanodesligamento = Convert.ToDateTime("01/" + tab.Contrato.Datademissao.Value.Month.ToString() + "/" + tab.Contrato.Datademissao.Value.Year.ToString());
                            if (modulo == MechTech.Util.Enumeradores.Modulo.Media_MediaRemuneracao)
                            {
                                if (Global.MesanoAtivo >= mesanodesligamento)
                                {
                                    if (tab.Contrato.DataDemissaoAjuste.HasValue)
                                    {
                                        if (Global.MesanoAtivo != tab.Contrato.DataDemissaoAjuste.Value)
                                            continue;
                                    }
                                    else
                                        continue;
                                }
                            }
                        }

                        /*TRANSFERÊNCIA*/
                        if (tab.Contrato.Datatransferencia.HasValue)
                        {
                            DateTime mesanotransferencia = new DateTime(tab.Contrato.Datatransferencia.Value.Year, tab.Contrato.Datatransferencia.Value.Month, 1);
                            if (tab.Contrato.Datademissao != tab.Contrato.Datatransferencia) //DESTINO
                            {
                                if (mesano < mesanotransferencia)
                                    continue;
                            }
                            else if (tab.Contrato.Datademissao == tab.Contrato.Datatransferencia &&
                                modulo == MechTech.Util.Enumeradores.Modulo.ReajusteSalarial) //ORIGEM
                                continue;
                        }
                        /**/

                        funcionarios.Add(tab);
                    }
                    return funcionarios;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de funcionários selecionados. Protótipo com seleção
        /// </summary>
        /// <param name="ids">Informar um ou mais códigos de funcionário separados por ponto-e-vírgula. Ex.: 3 ou 1;3;5;12;4</param>
        /// <param name="mesano">MesAno de processamento</param>
        /// <param name="modulo">Modulo para pesquisa</param>
        /// <param name="opcoes">Estrutura indicando o que pesquisar em funcionarios</param>
        public List<FuncionarioDTO> GetFuncionarios(string ids, DateTime mesano, MechTech.Util.Enumeradores.Modulo modulo, FuncPesquisaDTO opcoes)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFuncionarios");
                db.AddInParameter(dbCommand, "ids", DbType.String, (ids.Contains(";") ? ids.Replace(";", ",") : ids));

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<FuncionarioDTO> funcionarios = new List<FuncionarioDTO>();
                    while (DR.Read())
                    {
                        FuncionarioDTO tab = GetFuncionario(int.Parse(DR["id"].ToString()), opcoes);

                        /*FILTRAR FUNCIONÁRIOS DEMITIDOS*/
                        if (((tab.Contrato.Datademissao.HasValue) && (!tab.Contrato.Datatransferencia.HasValue)) ||
                            ((tab.Contrato.Datademissao.HasValue) && (tab.Contrato.Datatransferencia.HasValue) && (tab.Contrato.Datatransferencia != tab.Contrato.Datademissao)) //17145
                           )
                        {
                            DateTime mesanodesligamento = Convert.ToDateTime("01/" + tab.Contrato.Datademissao.Value.Month.ToString() + "/" + tab.Contrato.Datademissao.Value.Year.ToString());
                            if (modulo == MechTech.Util.Enumeradores.Modulo.Nenhum)
                            {
                                if (Global.MesanoAtivo >= mesanodesligamento)
                                {
                                    if (tab.Contrato.DataDemissaoAjuste.HasValue)
                                    {
                                        if (Global.MesanoAtivo != tab.Contrato.DataDemissaoAjuste.Value)
                                            continue;
                                    }
                                    else
                                        continue;
                                }
                            }
                            else if (modulo == MechTech.Util.Enumeradores.Modulo.Adiantamento)
                            {
                                if (!tab.Contrato.Datatransferencia.HasValue)
                                {
                                    if (Global.MesanoAtivo >= mesanodesligamento)
                                        continue;
                                }
                                else
                                {
                                    DateTime mesanotransferencia = new DateTime(tab.Contrato.Datatransferencia.Value.Year, tab.Contrato.Datatransferencia.Value.Month, 1);
                                    if (tab.Contrato.Datademissao != tab.Contrato.Datatransferencia) //DESTINO
                                    {
                                        if (Global.MesanoAtivo < mesanotransferencia)
                                            continue;
                                    }
                                }
                            }
                            else if (modulo == MechTech.Util.Enumeradores.Modulo.Adiantamento13 ||
                                modulo == MechTech.Util.Enumeradores.Modulo.Salario13 ||
                                modulo == MechTech.Util.Enumeradores.Modulo.Recalculo13)
                            {
                                if (Global.MesanoAtivo >= mesanodesligamento)
                                    continue;
                            }
                            else if (modulo == MechTech.Util.Enumeradores.Modulo.Ferias)
                            {
                                if (Global.MesanoAtivo > mesanodesligamento)
                                    continue;
                            }
                            else if (modulo == MechTech.Util.Enumeradores.Modulo.Holerith)
                            {
                                if (Global.MesanoAtivo > mesanodesligamento)
                                {
                                    if (tab.Contrato.DataDemissaoAjuste.HasValue)
                                    {
                                        if (Global.MesanoAtivo != tab.Contrato.DataDemissaoAjuste.Value)
                                            continue;
                                    }
                                    else
                                        continue;
                                }
                            }
                            else if (modulo == MechTech.Util.Enumeradores.Modulo.Media_MediaRemuneracao)
                            {
                                if (!tab.Contrato.Datatransferencia.HasValue)
                                {
                                    if (Global.MesanoAtivo >= mesanodesligamento)
                                    {
                                        if (tab.Contrato.DataDemissaoAjuste.HasValue)
                                        {
                                            if (Global.MesanoAtivo != tab.Contrato.DataDemissaoAjuste.Value)
                                                continue;
                                        }
                                        else
                                            continue;
                                    }
                                }
                            }
                        }

                        /*TRANSFERÊNCIA*/
                        if (((tab.Contrato.Datademissao.HasValue) && (tab.Contrato.Datatransferencia.HasValue) &&
                                 (tab.Contrato.Datatransferencia == tab.Contrato.Datademissao)
                                )
                           )
                        {
                            DateTime aux = tab.Contrato.Datatransferencia.Value.AddDays(-1);
                            DateTime mesanotransferencia = new DateTime(aux.Year, aux.Month, 1);
                            if (tab.Contrato.Datademissao != tab.Contrato.Datatransferencia) //DESTINO
                            {
                                if (mesano < mesanotransferencia)
                                    continue;
                            }
                            else
                            {
                                if (tab.Contrato.Datademissao == tab.Contrato.Datatransferencia &&
                                    modulo == MechTech.Util.Enumeradores.Modulo.ReajusteSalarial) //ORIGEM
                                    continue;
                                else
                                {
                                    if (Global.MesanoAtivo > mesanotransferencia)
                                        continue;
                                }

                            }
                        }
                        /**/

                        funcionarios.Add(tab);
                    }
                    return funcionarios;
                }
            }
            catch
            {
                throw;
            }
        }


        public string GetNomeCompleto(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFuncionario");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    return DR["nomecompleto"].ToString();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Responsável apenas por verificar a existência do Funcionário no Banco de dados (Importação de dados).
        /// </summary>
        /// <param name="id">ID do Funcionário</param>
        /// <returns>true = existe, não = não existe</returns>
        public bool ExistsFuncionario(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFuncionario");
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
                        dbCommand = db.GetSqlStringCommand(" UPDATE " + Global.EmpresaAtiva + ".funcionario SET" +
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

                dbCommand = db.GetSqlStringCommand(" Select setval('" + Global.EmpresaAtiva + ".funcionario_id_seq',(select max(id)+1 from " + Global.EmpresaAtiva + ".funcionario),true)");
                db.ExecuteNonQuery(dbCommand);

                int max = 0;
                dbCommand = db.GetSqlStringCommand(" SELECT id FROM " + Global.EmpresaAtiva + ".funcionario" +
                                                   " ORDER BY id DESC LIMIT 1");
                max = Convert.ToInt32(db.ExecuteScalar(dbCommand));
                max++;

                GenericDatabase db2 = new GenericDatabase(Global.ConnectionStringPg, PgSqlProviderFactory.Instance);
                dbCommand = db2.GetSqlStringCommand(" ALTER SEQUENCE " + Global.EmpresaAtiva + ".funcionario_id_seq" +
                                                    "     INCREMENT 1  MINVALUE 1" +
                                                    "     MAXVALUE 9223372036854775807  START @max" +
                                                    "     CACHE 1  NO CYCLE;");
                db2.AddInParameter(dbCommand, "@max", DbType.Int32, max);
                db2.ExecuteNonQuery(dbCommand);
                db2 = null;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FuncionarioDTO GetFuncionarioDigitacao(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFuncionario");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    FuncionarioDTO tab = new FuncionarioDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nomecompleto = DR["nomecompleto"].ToString();
                    tab.Salario = new FuncSalarioDAO().GetFuncsalarioFuncionario(tab.Id);
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioDTO> GetGridFuncionario(string campo, string valorPesquisa, DateTime mesano)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetGridFuncionario");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<FuncionarioDTO> List = new List<FuncionarioDTO>();
                    while (DR.Read())
                    {
                        FuncionarioDTO tab = new FuncionarioDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nomecompleto = DR["nomecompleto"].ToString();
                        if (Convert.IsDBNull(DR["contrato_datademissao"]))
                            tab.Contrato.Datademissao = null;
                        else
                            tab.Contrato.Datademissao = (DateTime)DR["contrato_datademissao"];
                        if (Convert.IsDBNull(DR["contrato_datatransferencia"]))
                            tab.Contrato.Datatransferencia = null;
                        else
                            tab.Contrato.Datatransferencia = (DateTime)DR["contrato_datatransferencia"];

                        /*TRANSFERÊNCIA*/
                        if (tab.Contrato.Datatransferencia.HasValue)
                        {
                            DateTime mesanotransferencia = new DateTime(tab.Contrato.Datatransferencia.Value.Year, tab.Contrato.Datatransferencia.Value.Month, 1);
                            if (tab.Contrato.Datademissao != tab.Contrato.Datatransferencia) //DESTINO
                            {
                                if (mesano < mesanotransferencia)
                                    continue;
                            }
                        }
                        /**/

                        //41252
                        tab.SalarioAtual = new FuncSalarioDAO().GetFuncsalarioFuncionarioCurrent(tab.Id);
                        if (!tab.Contrato.Datademissao.HasValue)
                            tab.Situacao = "Ativo";
                        else
                            if (!tab.Contrato.Datatransferencia.HasValue)
                                tab.Situacao = "Demitido";
                            else
                                if (tab.Contrato.Datatransferencia == tab.Contrato.Datademissao)
                                    tab.Situacao = "Transferido";
                                else
                                    tab.Situacao = "Demitido";
                        //41252 fim
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
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioDTO> GetListFuncionario(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetListFuncionario");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<FuncionarioDTO> List = new List<FuncionarioDTO>();
                    while (DR.Read())
                    {
                        if (!Convert.IsDBNull(DR["datademissao"]))
                            continue;

                        if (!Convert.IsDBNull(DR["dataafastamento"]))
                        {
                            if (!Convert.IsDBNull(DR["dataretorno"]))
                            {
                                if ((DateTime)DR["dataretorno"] >= Global.MesanoAtivo)
                                    continue;
                            }

                            if (Convert.IsDBNull(DR["dataretorno"]))
                                continue;
                        }

                        FuncionarioDTO tab = new FuncionarioDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nomecompleto = DR["nomecompleto"].ToString();

                        if (Convert.IsDBNull(DR["datatransferencia"]))
                            tab.Contrato.Datatransferencia = null;
                        else
                            tab.Contrato.Datatransferencia = (DateTime)DR["datatransferencia"];

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
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioDTO> GetGridFuncionario(string campo, string valorPesquisa, MechTech.Util.Enumeradores.Modulo modulo)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetGridFuncionario");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DateTime mesanodesligamento;
                    FuncSalarioDAO salariodata = new FuncSalarioDAO();
                    List<FuncionarioDTO> List = new List<FuncionarioDTO>();
                    while (DR.Read())
                    {
                        FuncionarioDTO tab = new FuncionarioDTO();
                        tab.Id = int.Parse(DR["id"].ToString());

                        /*FILTRAR FUNCIONÁRIOS DEMITIDOS*/
                        if (((tab.Contrato.Datademissao.HasValue) && (!tab.Contrato.Datatransferencia.HasValue)) ||
                            ((tab.Contrato.Datademissao.HasValue) && (tab.Contrato.Datatransferencia.HasValue) && (tab.Contrato.Datatransferencia != tab.Contrato.Datademissao)) //17145
                           )
                        {
                            mesanodesligamento = Convert.ToDateTime("01/" + tab.Contrato.Datademissao.Value.Month.ToString() + "/" + tab.Contrato.Datademissao.Value.Year.ToString());
                            if (modulo == MechTech.Util.Enumeradores.Modulo.Nenhum)
                            {
                                if (Global.MesanoAtivo >= mesanodesligamento)
                                {
                                    if (tab.Contrato.DataDemissaoAjuste.HasValue)
                                    {
                                        if (Global.MesanoAtivo != tab.Contrato.DataDemissaoAjuste.Value)
                                            continue;
                                    }
                                    else
                                        continue;
                                }
                            }
                            else if (modulo == MechTech.Util.Enumeradores.Modulo.Adiantamento)
                            {
                                if (!tab.Contrato.Datatransferencia.HasValue)
                                {
                                    if (Global.MesanoAtivo >= mesanodesligamento)
                                        continue;
                                }
                                else
                                {
                                    DateTime mesanotransferencia = new DateTime(tab.Contrato.Datatransferencia.Value.Year, tab.Contrato.Datatransferencia.Value.Month, 1);
                                    if (tab.Contrato.Datademissao != tab.Contrato.Datatransferencia) //DESTINO
                                    {
                                        if (Global.MesanoAtivo < mesanotransferencia)
                                            continue;
                                    }
                                }
                            }
                            else if (modulo == MechTech.Util.Enumeradores.Modulo.Adiantamento13 ||
                                modulo == MechTech.Util.Enumeradores.Modulo.Salario13 ||
                                modulo == MechTech.Util.Enumeradores.Modulo.Recalculo13)
                            {
                                if (Global.MesanoAtivo >= mesanodesligamento)
                                    continue;
                            }
                            else if (modulo == MechTech.Util.Enumeradores.Modulo.Ferias)
                            {
                                if (Global.MesanoAtivo > mesanodesligamento)
                                    continue;
                            }
                            else if (modulo == MechTech.Util.Enumeradores.Modulo.Holerith)
                            {
                                if (Global.MesanoAtivo > mesanodesligamento)
                                {
                                    if (tab.Contrato.DataDemissaoAjuste.HasValue)
                                    {
                                        if (Global.MesanoAtivo != tab.Contrato.DataDemissaoAjuste.Value)
                                            continue;
                                    }
                                    else
                                        continue;
                                }
                            }
                        }

                        /**/


                        /*TRANSFERÊNCIA*/
                        if (modulo == Util.Enumeradores.Modulo.Nenhum) //17145
                        {
                            if (((tab.Contrato.Datademissao.HasValue) && (tab.Contrato.Datatransferencia.HasValue) &&
                                 (tab.Contrato.Datatransferencia == tab.Contrato.Datademissao)))
                            {
                                DateTime aux = tab.Contrato.Datatransferencia.Value.AddDays(-1);
                                DateTime mesanotransferencia = new DateTime(aux.Year, aux.Month, 1);
                                if (Global.MesanoAtivo > mesanotransferencia)
                                    continue;
                            }
                        } //17145 fim
                        else if (modulo == MechTech.Util.Enumeradores.Modulo.Adiantamento13 || //53352
                                 modulo == MechTech.Util.Enumeradores.Modulo.Salario13 ||
                                 modulo == MechTech.Util.Enumeradores.Modulo.Recalculo13)
                        {
                            if (((tab.Contrato.Datademissao.HasValue) && (tab.Contrato.Datatransferencia.HasValue) &&
                                 (tab.Contrato.Datatransferencia == tab.Contrato.Datademissao)))
                            {
                                DateTime mesanotransferencia = Convert.ToDateTime("01/" + tab.Contrato.Datademissao.Value.Month.ToString() + "/" + tab.Contrato.Datademissao.Value.Year.ToString());
                                if (Global.MesanoAtivo >= mesanotransferencia)
                                    continue;
                            }
                        } //53352 FIM
                        else if (((tab.Contrato.Datademissao.HasValue) && (tab.Contrato.Datatransferencia.HasValue) &&
                                 (tab.Contrato.Datatransferencia == tab.Contrato.Datademissao)))
                        {
                            DateTime mesanotransferencia = new DateTime(tab.Contrato.Datatransferencia.Value.Year, tab.Contrato.Datatransferencia.Value.Month, 1);
                            if (tab.Contrato.Datademissao != tab.Contrato.Datatransferencia) //DESTINO
                            {
                                if (Global.MesanoAtivo < mesanotransferencia)
                                    continue;
                            }
                            else if (tab.Contrato.Datademissao == tab.Contrato.Datatransferencia &&
                                modulo == MechTech.Util.Enumeradores.Modulo.ReajusteSalarial) //ORIGEM
                                continue;
                        }
                        /**/

                        tab.Numficharegistro = int.Parse(DR["numficharegistro"].ToString());
                        tab.Nomecompleto = DR["nomecompleto"].ToString();
                        tab.Dddtelefone = DR["dddtelefone"].ToString();
                        tab.Telefone = DR["telefone"].ToString();
                        if (Convert.IsDBNull(DR["datanascimento"]))
                            tab.Datanascimento = null;
                        else
                            tab.Datanascimento = (DateTime)DR["datanascimento"];

                        //DOCUMENTOS
                        FuncDocumentoDTO documento = new FuncDocumentoDTO();
                        documento.Id = Convert.ToInt32(DR["documento_id"]);
                        documento.Cpf = DR["documento_cpf"].ToString();
                        documento.Ctps = DR["documento_ctps"].ToString();
                        documento.Ctpsserie = DR["documento_ctpsserie"].ToString();
                        documento.UFCTPS.Codigo = DR["documento_ctpsuf"].ToString();
                        tab.Documento = documento;
                        //

                        tab.Foto = null;
                        tab.Salario = salariodata.GetFuncsalarioFuncionario(tab.Id);
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
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioSEDTO> GetGridFuncionarioSE(string campo, string valorPesquisa, MechTech.Util.Enumeradores.Modulo modulo, bool apresentardemitidos)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetGridFuncionarioSE");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);
                db.AddInParameter(dbCommand, "mesanoativo", DbType.Date, Global.MesanoAtivo);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DateTime mesanoadmissao;
                    DateTime mesanodesligamento;
                    List<FuncionarioSEDTO> List = new List<FuncionarioSEDTO>();
                    while (DR.Read())
                    {
                        FuncionarioSEDTO tab = new FuncionarioSEDTO();
                        tab.DataAdmissao = (DateTime)DR["dataadmissao"];
                        
                        if (modulo == MechTech.Util.Enumeradores.Modulo.Holerith)
                        {
                            mesanoadmissao = new DateTime(tab.DataAdmissao.Year, tab.DataAdmissao.Month, 1);
                            if (Global.MesanoAtivo < mesanoadmissao) //FILTRAR FUNCIONÁRIOS COM DATA DE ADMISSÃO POSTERIOR AO MÊS/ANO ATIVO
                                continue;
                        }

                        if (Convert.IsDBNull(DR["datademissao"]))
                            tab.DataDemissao = null;
                        else
                            tab.DataDemissao = (DateTime)DR["datademissao"];
                        if (Convert.IsDBNull(DR["datademissaoajuste"]))
                            tab.DataDemissaoAjuste = null;
                        else
                            tab.DataDemissaoAjuste = (DateTime)DR["datademissaoajuste"];

                        /*FILTRAR FUNCIONÁRIOS DEMITIDOS*/
                        if (!apresentardemitidos)
                        {
                            if (tab.DataDemissao.HasValue)
                            {
                                mesanodesligamento = Convert.ToDateTime("01/" + tab.DataDemissao.Value.Month.ToString() + "/" + tab.DataDemissao.Value.Year.ToString());
                                if (modulo == MechTech.Util.Enumeradores.Modulo.Nenhum)
                                {
                                    if (Global.MesanoAtivo >= mesanodesligamento)
                                    {
                                        if (tab.DataDemissaoAjuste.HasValue)
                                        {
                                            if (Global.MesanoAtivo != tab.DataDemissaoAjuste.Value)
                                                continue;
                                        }
                                        else
                                            continue;
                                    }
                                }
                                else if (modulo == MechTech.Util.Enumeradores.Modulo.Ferias ||
                                         modulo == MechTech.Util.Enumeradores.Modulo.Salario13)
                                {
                                    if (Global.MesanoAtivo > mesanodesligamento)
                                        continue;
                                }
                                else if (modulo == MechTech.Util.Enumeradores.Modulo.Holerith)
                                {
                                    if (Global.MesanoAtivo > mesanodesligamento)
                                    {
                                        if (tab.DataDemissaoAjuste.HasValue)
                                        {
                                            if (Global.MesanoAtivo != tab.DataDemissaoAjuste.Value)
                                                continue;
                                        }
                                        else
                                            continue;
                                    }
                                }
                            }
                        }
                        /**/

                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.NomeCompleto = DR["nomecompleto"].ToString();
                        tab.Funcao = DR["funcao"].ToString();
                        tab.Situacao = DR["situacao"].ToString();

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
        /// Extension
        /// </summary>
        //public List<FuncionarioSEexDTO> GetGridFuncionarioSEex(string campo, string valorPesquisa, MechTech.Util.Enumeradores.Modulo modulo)
        //{
        //    try
        //    {
        //        dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetGridFuncionarioSE");
        //        db.AddInParameter(dbCommand, "campo", DbType.String, campo);
        //        db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);
        //        db.AddInParameter(dbCommand, "mesanoativo", DbType.Date, Global.MesanoAtivo);

        //        using (IDataReader DR = db.ExecuteReader(dbCommand))
        //        {
        //            DateTime mesanoadmissao;
        //            DateTime? dataafastamento = null;
        //            DateTime? dataretorno = null;
        //            DateTime mesanodesligamento;
        //            FuncFeriasDAO feriasdata = new FuncFeriasDAO();
        //            List<FuncionarioSEexDTO> List = new List<FuncionarioSEexDTO>();
        //            while (DR.Read())
        //            {
        //                FuncionarioSEexDTO tab = new FuncionarioSEexDTO();
        //                tab.DataAdmissao = (DateTime)DR["dataadmissao"];
        //                if (modulo == MechTech.Util.Enumeradores.Modulo.Holerith)
        //                {
        //                    mesanoadmissao = new DateTime(tab.DataAdmissao.Year, tab.DataAdmissao.Month, 1);
        //                    if (Global.MesanoAtivo < mesanoadmissao) //FILTRAR FUNCIONÁRIOS COM DATA DE ADMISSÃO POSTERIOR AO MÊS/ANO ATIVO
        //                        continue;
        //                }

        //                if (Convert.IsDBNull(DR["datademissao"]))
        //                    tab.DataDemissao = null;
        //                else
        //                    tab.DataDemissao = (DateTime)DR["datademissao"];
        //                if (Convert.IsDBNull(DR["datademissaoajuste"]))
        //                    tab.DataDemissaoAjuste = null;
        //                else
        //                    tab.DataDemissaoAjuste = (DateTime)DR["datademissaoajuste"];

        //                /*FILTRAR FUNCIONÁRIOS DEMITIDOS*/
        //                if (tab.DataDemissao.HasValue)
        //                {
        //                    mesanodesligamento = Convert.ToDateTime("01/" + tab.DataDemissao.Value.Month.ToString() + "/" + tab.DataDemissao.Value.Year.ToString());
        //                    if (modulo == MechTech.Util.Enumeradores.Modulo.Nenhum)
        //                    {
        //                        if (Global.MesanoAtivo >= mesanodesligamento)
        //                        {
        //                            if (tab.DataDemissaoAjuste.HasValue)
        //                            {
        //                                if (Global.MesanoAtivo != tab.DataDemissaoAjuste.Value)
        //                                    continue;
        //                            }
        //                            else
        //                                continue;
        //                        }
        //                    }
        //                    else if (modulo == MechTech.Util.Enumeradores.Modulo.Ferias ||
        //                             modulo == MechTech.Util.Enumeradores.Modulo.Salario13)
        //                    {
        //                        if (Global.MesanoAtivo > mesanodesligamento)
        //                            continue;
        //                    }
        //                    else if (modulo == MechTech.Util.Enumeradores.Modulo.Holerith)
        //                    {
        //                        if (Global.MesanoAtivo > mesanodesligamento)
        //                        {
        //                            if (tab.DataDemissaoAjuste.HasValue)
        //                            {
        //                                if (Global.MesanoAtivo != tab.DataDemissaoAjuste.Value)
        //                                    continue;
        //                            }
        //                            else
        //                                continue;
        //                        }
        //                    }
        //                }
        //                /**/

        //                tab.Id = int.Parse(DR["id"].ToString());
        //                tab.NumFichaRegistro = int.Parse(DR["numficharegistro"].ToString());
        //                tab.NomeCompleto = DR["nomecompleto"].ToString();
        //                tab.Funcao = DR["funcao"].ToString();
        //                tab.TipoSalario = DR["tiposalario"].ToString();
        //                tab.Situacao = DR["situacao"].ToString();
        //                if (Convert.IsDBNull(DR["dataafastamento"]))
        //                    tab.DataAfastamento = null;
        //                else
        //                    tab.DataAfastamento = (DateTime)DR["dataafastamento"];
        //                if (Convert.IsDBNull(DR["dataretorno"]))
        //                    tab.DataRetorno = null;
        //                else
        //                    tab.DataRetorno = (DateTime)DR["dataretorno"];

        //                /*AFASTAMENTO*/
        //                if (tab.DataAfastamento.HasValue)
        //                {
        //                    dataafastamento = Convert.ToDateTime("01/" + tab.DataAfastamento.Value.Month.ToString() + "/" + tab.DataAfastamento.Value.Year.ToString());
        //                    dataretorno = null;
        //                    if (tab.DataRetorno.HasValue)
        //                        dataretorno = Convert.ToDateTime("01/" + tab.DataRetorno.Value.Month.ToString() + "/" + tab.DataRetorno.Value.Year.ToString());

        //                    if (dataafastamento <= Global.MesanoAtivo && (dataretorno == null || dataretorno > Global.MesanoAtivo))
        //                        tab.Situacao = "Afastado";
        //                }
        //                /**/

        //                /*ex*/
        //                tab.Ferias = feriasdata.GetFuncferiasFuncionario(tab.Id);
        //                /**/

        //                /*TRANSFERÊNCIA*/
        //                if (Convert.IsDBNull(DR["datatransferencia"]))
        //                    tab.DataTransferencia = null;
        //                else
        //                    tab.DataTransferencia = (DateTime)DR["datatransferencia"];
        //                if (modulo == MechTech.Util.Enumeradores.Modulo.Nenhum ||
        //                    modulo == MechTech.Util.Enumeradores.Modulo.Holerith ||
        //                    modulo == MechTech.Util.Enumeradores.Modulo.Ferias ||
        //                    modulo == MechTech.Util.Enumeradores.Modulo.Salario13 ||
        //                    modulo == MechTech.Util.Enumeradores.Modulo.Rescisao)
        //                {
        //                    if (tab.DataTransferencia.HasValue)
        //                    {
        //                        DateTime mesanotransferencia = new DateTime(tab.DataTransferencia.Value.Year, tab.DataTransferencia.Value.Month, 1);
        //                        if (tab.DataDemissao == tab.DataTransferencia) //ORIGEM
        //                        {
        //                            if (mesanotransferencia <= Global.MesanoAtivo &&
        //                                modulo == MechTech.Util.Enumeradores.Modulo.Rescisao)
        //                                continue;
        //                        }
        //                        else //DESTINO
        //                        {
        //                            if (Global.MesanoAtivo < mesanotransferencia)
        //                                continue;
        //                        }
        //                    }
        //                }
        //                /**/

        //                List.Add(tab);
        //            }
        //            return List;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        /// <summary>
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioDTO> GetListDadosProvisao(string campo, DateTime mesanoprocessamento)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetGridFuncionario");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, string.Empty);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DateTime mesanodesligamento;
                    FuncSalarioDAO salariodata = new FuncSalarioDAO();
                    List<FuncionarioDTO> List = new List<FuncionarioDTO>();
                    while (DR.Read())
                    {
                        FuncionarioDTO tab = new FuncionarioDTO();
                        tab.Id = int.Parse(DR["id"].ToString());

                        /*FILTRAR FUNCIONÁRIOS DEMITIDOS*/
                        if (tab.Contrato.Datademissao.HasValue)
                        {
                            mesanodesligamento = Convert.ToDateTime("01/" + tab.Contrato.Datademissao.Value.Month.ToString() + "/" + tab.Contrato.Datademissao.Value.Year.ToString());
                            if (mesanoprocessamento >= mesanodesligamento)
                                continue;
                        }
                        //

                        /*TRANSFERÊNCIA*/
                        if (tab.Contrato.Datatransferencia.HasValue)
                        {
                            DateTime mesanotransferencia = new DateTime(tab.Contrato.Datatransferencia.Value.Year, tab.Contrato.Datatransferencia.Value.Month, 1);
                            if (tab.Contrato.Datademissao != tab.Contrato.Datatransferencia) //DESTINO
                            {
                                if (mesanoprocessamento < mesanotransferencia)
                                    continue;
                            }
                        }
                        /**/
                        tab.Nomecompleto = DR["nomecompleto"].ToString();
                        tab.Salario = salariodata.GetFuncsalarioFuncionario(tab.Id);

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
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        /// <param name="campo">O valor especificado será a chave de indexação da pesquisa</param>
        public List<FuncionarioDTO> GetListDadosLayout(string campo, string valorpesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetGridFuncionario");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorpesquisa", DbType.String, valorpesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    FuncDocumentoDAO documentodata = new FuncDocumentoDAO();
                    FuncSalarioDAO salariodata = new FuncSalarioDAO();
                    List<FuncionarioDTO> List = new List<FuncionarioDTO>();
                    while (DR.Read())
                    {
                        FuncionarioDTO tab = new FuncionarioDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nomecompleto = DR["nomecompleto"].ToString();
                        tab.Numficharegistro = int.Parse(DR["numficharegistro"].ToString());
                        tab.Sexo = DR["sexo"].ToString();
                        tab.Cep = DR["cep"].ToString();
                        if (Convert.IsDBNull(DR["datanascimento"]))
                            tab.Datanascimento = null;
                        else
                            tab.Datanascimento = (DateTime)DR["datanascimento"];
                        if (Convert.IsDBNull(DR["fgtsdataopcao"]))
                            tab.Fgtsdataopcao = null;
                        else
                            tab.Fgtsdataopcao = (DateTime)DR["fgtsdataopcao"];

                        tab.Documento = documentodata.GetFuncdocumentoFuncionario(tab.Id);
                        tab.Salario = salariodata.GetFuncsalarioFuncionario(tab.Id);

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
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioDTO> GetListDadosDIRF()
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetGridFuncionario");
                db.AddInParameter(dbCommand, "campo", DbType.String, "f.nomecompleto");
                db.AddInParameter(dbCommand, "valorpesquisa", DbType.String, "%");

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    FuncDocumentoDAO documentodata = new FuncDocumentoDAO();
                    List<FuncionarioDTO> List = new List<FuncionarioDTO>();
                    while (DR.Read())
                    {
                        FuncionarioDTO tab = new FuncionarioDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nomecompleto = DR["nomecompleto"].ToString();
                        tab.Documento = documentodata.GetFuncdocumentoFuncionario(tab.Id);

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
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioDTO> GetListFuncionarioByDepartamento(string departamentos)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetListFuncionarioByDepartamento");
                db.AddInParameter(dbCommand, "departamentos", DbType.String, departamentos);
                db.AddInParameter(dbCommand, "data", DbType.Date, Global.MesanoAtivo);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DateTime mesanodesligamento;
                    FuncSalarioDAO salariodata = new FuncSalarioDAO();
                    List<FuncionarioDTO> List = new List<FuncionarioDTO>();
                    while (DR.Read())
                    {
                        FuncionarioDTO tab = new FuncionarioDTO();

                        if (Convert.IsDBNull(DR["datademissao"]))
                            tab.Contrato.Datademissao = null;
                        else
                            tab.Contrato.Datademissao = (DateTime)DR["datademissao"];

                        /*FILTRAR FUNCIONÁRIOS DEMITIDOS*/
                        if (tab.Contrato.Datademissao.HasValue)
                        {
                            mesanodesligamento = Convert.ToDateTime("01/" + tab.Contrato.Datademissao.Value.Month.ToString() + "/" + tab.Contrato.Datademissao.Value.Year.ToString());
                            if (Global.MesanoAtivo >= mesanodesligamento)
                                continue;
                        }
                        //

                        /*TRANSFERÊNCIA*/
                        if (tab.Contrato.Datatransferencia.HasValue)
                        {
                            DateTime mesanotransferencia = new DateTime(tab.Contrato.Datatransferencia.Value.Year, tab.Contrato.Datatransferencia.Value.Month, 1);
                            if (tab.Contrato.Datademissao != tab.Contrato.Datatransferencia) //DESTINO
                            {
                                if (Global.MesanoAtivo < mesanotransferencia)
                                    continue;
                            }
                        }
                        /**/

                        tab.Data = (DateTime)DR["data"];

                        if (!Convert.IsDBNull(DR["codigo"]))
                        {
                            tab.Departamento.Codigo = int.Parse(DR["codigo"].ToString());
                            tab.Departamento.Nome = DR["nome"].ToString();
                        }
                        else
                        {
                            tab.Departamento.Codigo = 0;
                            tab.Departamento.Nome = "NÃO INFORMADO";
                        }

                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nomecompleto = DR["nomecompleto"].ToString();
                        tab.Contrato.Dataadmissao = (DateTime)DR["dataadmissao"];
                        tab.Salario = salariodata.GetFuncsalarioFuncionario(tab.Id);
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
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        /// <param name="id_funcionario">"0" para todos os funcionários</param>
        public List<FuncionarioDTO> GetEtiqueta(int id_funcionario)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetEtiqueta");
                db.AddInParameter(dbCommand, "id_funcionario", DbType.Int32, id_funcionario);
                db.AddInParameter(dbCommand, "mesano", DbType.Date, Global.MesanoAtivo);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<FuncionarioDTO> List = new List<FuncionarioDTO>();
                    while (DR.Read())
                    {
                        FuncionarioDTO tab = new FuncionarioDTO();

                        if (Convert.IsDBNull(DR["datademissao"]))
                            tab.Contrato.Datademissao = null;
                        else
                            tab.Contrato.Datademissao = (DateTime)DR["datademissao"];
                        if (Convert.IsDBNull(DR["datatransferencia"]))
                            tab.Contrato.Datatransferencia = null;
                        else
                            tab.Contrato.Datatransferencia = (DateTime)DR["datatransferencia"];
                        tab.Contrato.Empresa = DR["empresa"].ToString();

                        tab.Id = int.Parse(DR["id_funcionario"].ToString());
                        tab.Nomecompleto = DR["nomecompleto"].ToString();
                        tab.Numficharegistro = int.Parse(DR["numficharegistro"].ToString());
                        tab.Contrato.Dataadmissao = (DateTime)DR["dataadmissao"];
                        if (Convert.IsDBNull(DR["fgtsdataopcao"]))
                            tab.Fgtsdataopcao = null;
                        else
                            tab.Fgtsdataopcao = (DateTime)DR["fgtsdataopcao"];
                        tab.Bancofgts.Codigo = DR["banco"].ToString();
                        tab.Bancofgts.Nome = DR["nomebanco"].ToString();
                        tab.Fgtsagencia = DR["fgtsagencia"].ToString();
                        tab.Fgtsagenciadv = DR["fgtsagenciadv"].ToString();
                        if (Convert.IsDBNull(DR["experienciainicio"]))
                            tab.Contrato.Experienciainicio = null;
                        else
                            tab.Contrato.Experienciainicio = (DateTime)DR["experienciainicio"];
                        if (Convert.IsDBNull(DR["experienciafim"]))
                            tab.Contrato.Experienciafim = null;
                        else
                            tab.Contrato.Experienciafim = (DateTime)DR["experienciafim"];
                        if (Convert.IsDBNull(DR["experienciaprorrogacao"]))
                            tab.Contrato.Experienciaprorrogacao = null;
                        else
                            tab.Contrato.Experienciaprorrogacao = (DateTime)DR["experienciaprorrogacao"];

                        if (Convert.IsDBNull(DR["diadescanso"]))
                            tab.Contrato.Diadescanso = 1;
                        else
                            tab.Contrato.Diadescanso = int.Parse(DR["diadescanso"].ToString());

                        FuncSalarioDTO salarioatual = new FuncSalarioDTO();
                        salarioatual.Funcao.CBO.Codigo = DR["cbo"].ToString();
                        salarioatual.Data = (DateTime)DR["data"];
                        salarioatual.Motivo = DR["motivo"].ToString();
                        salarioatual.Funcao.Nome = DR["funcao"].ToString();
                        salarioatual.Salario = decimal.Parse(DR["salario"].ToString());
                        salarioatual.Funcao.CalculoHoras = bool.Parse(DR["calculohoras"].ToString());
                        salarioatual.Departamento.Nome = DR["departamento"].ToString();

                        salarioatual.Funcao = new FuncaoDAO().GetFuncao(new FuncaoDAO().GetGridFuncao("nome", DR["funcao"].ToString())[0].Id);
                        tab.Salario.Add(salarioatual);

                        tab.Documento.Banco.Codigo = DR["bancopis"].ToString();
                        tab.Documento.Banco.Nome = DR["nomebancopis"].ToString();
                        tab.Documento.Ctps = DR["ctps"].ToString();
                        tab.Documento.Ctpsserie = DR["ctps_serie"].ToString();
                        tab.Documento.Cpf = DR["cpf"].ToString();

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
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        /// <param name="id_funcionario">"0" para todos os funcionários</param>
        public List<FuncionarioDTO> GetEtiquetaAlteracaoSalario(int id_funcionario, DateTime periodoinicial, DateTime periodofinal)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetEtiquetaAlteracaoSalario");
                db.AddInParameter(dbCommand, "id_funcionario", DbType.Int32, id_funcionario);
                db.AddInParameter(dbCommand, "periodoinicial", DbType.Date, periodoinicial);
                db.AddInParameter(dbCommand, "periodofinal", DbType.Date, periodofinal);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<FuncionarioDTO> List = new List<FuncionarioDTO>();
                    while (DR.Read())
                    {
                        FuncionarioDTO tab = new FuncionarioDTO();

                        if (Convert.IsDBNull(DR["datademissao"]))
                            tab.Contrato.Datademissao = null;
                        else
                            tab.Contrato.Datademissao = (DateTime)DR["datademissao"];

                        tab.Id = int.Parse(DR["id_funcionario"].ToString());
                        tab.Nomecompleto = DR["nomecompleto"].ToString();
                        tab.Numficharegistro = int.Parse(DR["numficharegistro"].ToString());
                        tab.Contrato.Dataadmissao = (DateTime)DR["dataadmissao"];
                        if (Convert.IsDBNull(DR["fgtsdataopcao"]))
                            tab.Fgtsdataopcao = null;
                        else
                            tab.Fgtsdataopcao = (DateTime)DR["fgtsdataopcao"];
                        tab.Bancofgts.Codigo = DR["banco"].ToString();
                        tab.Bancofgts.Nome = DR["nomebanco"].ToString();
                        tab.Fgtsagencia = DR["fgtsagencia"].ToString();
                        tab.Fgtsagenciadv = DR["fgtsagenciadv"].ToString();
                        if (Convert.IsDBNull(DR["experienciainicio"]))
                            tab.Contrato.Experienciainicio = null;
                        else
                            tab.Contrato.Experienciainicio = (DateTime)DR["experienciainicio"];
                        if (Convert.IsDBNull(DR["experienciafim"]))
                            tab.Contrato.Experienciafim = null;
                        else
                            tab.Contrato.Experienciafim = (DateTime)DR["experienciafim"];
                        if (Convert.IsDBNull(DR["experienciaprorrogacao"]))
                            tab.Contrato.Experienciaprorrogacao = null;
                        else
                            tab.Contrato.Experienciaprorrogacao = (DateTime)DR["experienciaprorrogacao"];

                        FuncSalarioDTO salario = new FuncSalarioDTO();
                        salario.Funcao.CBO.Codigo = DR["cbo"].ToString();
                        salario.Data = (DateTime)DR["data"];
                        salario.Motivo = DR["motivo"].ToString();
                        salario.Funcao.Nome = DR["funcao"].ToString();
                        salario.Salario = decimal.Parse(DR["salario"].ToString());
                        salario.Funcao.CalculoHoras = bool.Parse(DR["calculohoras"].ToString());
                        tab.Salario.Add(salario);
                        tab.Documento.Banco.Codigo = DR["bancopis"].ToString();
                        tab.Documento.Banco.Nome = DR["nomebancopis"].ToString();

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
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        /// <param name="id_funcionario">"0" para todos os funcionários</param>
        public List<FuncionarioDTO> GetEtiquetaFerias(int id_funcionario, DateTime periodoinicial, DateTime periodofinal)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetEtiquetaFerias");
                db.AddInParameter(dbCommand, "id_funcionario", DbType.Int32, id_funcionario);
                db.AddInParameter(dbCommand, "periodoinicial", DbType.Date, periodoinicial);
                db.AddInParameter(dbCommand, "periodofinal", DbType.Date, periodofinal);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<FuncionarioDTO> List = new List<FuncionarioDTO>();
                    while (DR.Read())
                    {
                        FuncionarioDTO tab = new FuncionarioDTO();

                        if (Convert.IsDBNull(DR["datademissao"]))
                            tab.Contrato.Datademissao = null;
                        else
                            tab.Contrato.Datademissao = (DateTime)DR["datademissao"];

                        tab.Id = int.Parse(DR["id_funcionario"].ToString());
                        tab.Nomecompleto = DR["nomecompleto"].ToString();
                        tab.Numficharegistro = int.Parse(DR["numficharegistro"].ToString());
                        tab.Contrato.Dataadmissao = (DateTime)DR["dataadmissao"];
                        if (Convert.IsDBNull(DR["fgtsdataopcao"]))
                            tab.Fgtsdataopcao = null;
                        else
                            tab.Fgtsdataopcao = (DateTime)DR["fgtsdataopcao"];
                        tab.Bancofgts.Codigo = DR["banco"].ToString();
                        tab.Bancofgts.Nome = DR["nomebanco"].ToString();
                        tab.Fgtsagencia = DR["fgtsagencia"].ToString();
                        tab.Fgtsagenciadv = DR["fgtsagenciadv"].ToString();
                        if (Convert.IsDBNull(DR["experienciainicio"]))
                            tab.Contrato.Experienciainicio = null;
                        else
                            tab.Contrato.Experienciainicio = (DateTime)DR["experienciainicio"];
                        if (Convert.IsDBNull(DR["experienciafim"]))
                            tab.Contrato.Experienciafim = null;
                        else
                            tab.Contrato.Experienciafim = (DateTime)DR["experienciafim"];
                        if (Convert.IsDBNull(DR["experienciaprorrogacao"]))
                            tab.Contrato.Experienciaprorrogacao = null;
                        else
                            tab.Contrato.Experienciaprorrogacao = (DateTime)DR["experienciaprorrogacao"];

                        FuncSalarioDTO salarioatual = new FuncSalarioDTO();
                        salarioatual.Funcao.CBO.Codigo = DR["cbo"].ToString();
                        salarioatual.Data = (DateTime)DR["data"];
                        salarioatual.Motivo = DR["motivo"].ToString();
                        salarioatual.Funcao.Nome = DR["funcao"].ToString();
                        salarioatual.Salario = decimal.Parse(DR["salario"].ToString());
                        salarioatual.Funcao.CalculoHoras = bool.Parse(DR["calculohoras"].ToString());
                        tab.Salario.Add(salarioatual);
                        tab.Documento.Banco.Codigo = DR["bancopis"].ToString();
                        tab.Documento.Banco.Nome = DR["nomebancopis"].ToString();

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
        /// Retorna um objeto FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FuncionarioDTO GetDadosImpressao(int id, DateTime mesano)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFuncionario");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    FuncionarioDTO tab = new FuncionarioDTO();
                    tab.Id = int.Parse(DR["id"].ToString());

                    /*TRANSFERÊNCIA*/
                    if (tab.Contrato.Datatransferencia.HasValue)
                    {
                        DateTime mesanotransferencia = new DateTime(tab.Contrato.Datatransferencia.Value.Year, tab.Contrato.Datatransferencia.Value.Month, 1);
                        if (tab.Contrato.Datademissao != tab.Contrato.Datatransferencia) //DESTINO
                        {
                            if (mesano < mesanotransferencia)
                                return new FuncionarioDTO();
                        }
                    }
                    /**/

                    tab.Nomecompleto = DR["nomecompleto"].ToString();
                    if (Convert.IsDBNull(DR["datanascimento"]))
                        tab.Datanascimento = null;
                    else
                        tab.Datanascimento = (DateTime)DR["datanascimento"];

                    //LOCALIZAR BANCO PARA DEPÓSITO DE SALÁRIO
                    BancoDTO bancosalario = new BancoDTO();
                    if (!Convert.IsDBNull(DR["id_bancosalario"]))
                    {
                        BancoDAO bancosalariodata = new BancoDAO();
                        bancosalario.Id = Convert.ToInt32(DR["id_bancosalario"]);
                        bancosalario = bancosalariodata.GetBanco(bancosalario.Id);
                    }
                    tab.Bancosalario = bancosalario;
                    //

                    tab.Salconta = DR["salconta"].ToString();
                    tab.Salcontadv1 = DR["salcontadv1"].ToString();
                    tab.Salagencia = DR["salagencia"].ToString();
                    tab.Salagenciadv = DR["salagenciadv"].ToString();

                    tab.Documento = new FuncDocumentoDAO().GetFuncdocumentoFuncionario(tab.Id);
                    tab.Salario = new FuncSalarioDAO().GetFuncsalarioFuncionario(tab.Id);

                    tab.SalarioAtual = new FuncSalarioDAO().GetFuncsalarioFuncionarioCurrent(tab.Id); //41262
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável pela persistência das listas agregadas a classe FuncionarioDTO.
        /// </summary>
        /// <param name="funcionario">Objeto do tipo FuncionarioDTO gerado na camada de apresentação</param>
        /// <param name="id_funcionario">Chave primária do funcionário gerada no Banco de dados</param>
        /// <param name="type">Tipo de operação ("I"-Insert / "U"-Update)</param>
        private void PersisteListas(FuncionarioDTO funcionario, int id_funcionario, string type)
        {
            //FUNCDOCUMENTO
            FuncDocumentoDAO funcdocumentodata = new FuncDocumentoDAO(Transaction);
            funcionario.Documento.Id_funcionario = id_funcionario;
            if (type.Equals("I"))
                funcdocumentodata.Insert(funcionario.Documento);
            else
                funcdocumentodata.Update(funcionario.Documento);

            funcionario.Contrato.Id_funcionario = id_funcionario;

            //FUNCCONTRATO
            FuncContratoDAO funccontratodata = new FuncContratoDAO(Transaction);
            funcionario.Contrato.Id_funcionario = id_funcionario;
            if (type.Equals("I"))
                funccontratodata.Insert(funcionario.Contrato);
            else
                funccontratodata.Update(funcionario.Contrato);

            //FUNCSALARIO
            FuncSalarioDAO funcsalariodata = new FuncSalarioDAO(Transaction);
            if (funcsalariodata.DeleteFuncionario(id_funcionario))
            {
                foreach (FuncSalarioDTO itemsalario in funcionario.Salario)
                {
                    itemsalario.Id_funcionario = id_funcionario;
                    funcsalariodata.Insert(itemsalario);
                }
            }
        }

        #region IDisposable Members
        public void Dispose()
        {
            Transaction = null;
        }
        #endregion
    }
}