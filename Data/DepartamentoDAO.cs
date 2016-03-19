using System;
using System.Collections.Generic;
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
    public class DepartamentoDAO : IDados<DepartamentoDTO>
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
        /// Instância básica para DepartamentoDAO.
        /// </summary>
        public DepartamentoDAO()
        { }

        /// <summary>
        /// Instância para DepartamentoDAO com controle de transação.
        /// </summary>
        public DepartamentoDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(DepartamentoDTO departamento)
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
                            //string ocorrencia = (MechTech.Util.Global.RotinaLOG == MechTech.Util.Enumeradores.RotinaLOG.ImportacaoDados ? "Importação de Dados" : string.Empty);
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1111, '" + ocorrencia + "', '" + MechTech.Util.Global.UsuarioAtivo + "');"); 
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" INSERT INTO " + Global.EmpresaAtiva + ".departamento(" +
                                                           "    nome," +
                                                           "    endereco," +
                                                           "    numero," +
                                                           "    complemento," +
                                                           "    bairro," +
                                                           "    cep," +
                                                           "    id_municipio," +
                                                           "    codigo" +
                                                           ") VALUES (" +
                                                           "    @nome," +
                                                           "    @endereco," +
                                                           "    @numero," +
                                                           "    @complemento," +
                                                           "    @bairro," +
                                                           "    @cep," +
                                                           "    @id_municipio," +
                                                           "    @codigo);" +
                                                           "SELECT currval('" + Global.EmpresaAtiva + ".departamento_id_seq');");
                        db.AddInParameter(dbCommand, "@nome", DbType.String, departamento.Nome);
                        db.AddInParameter(dbCommand, "@endereco", DbType.String, departamento.Endereco);
                        db.AddInParameter(dbCommand, "@numero", DbType.String, departamento.Numero);
                        db.AddInParameter(dbCommand, "@complemento", DbType.String, departamento.Complemento);
                        db.AddInParameter(dbCommand, "@bairro", DbType.String, departamento.Bairro);
                        db.AddInParameter(dbCommand, "@cep", DbType.String, departamento.Cep);
                        if (departamento.Municipio.Id == 0)
                            db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, null);
                        else
                            db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, departamento.Municipio.Id);
                        db.AddInParameter(dbCommand, "@codigo", DbType.Int32, departamento.Codigo);
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
        public bool Update(DepartamentoDTO departamento)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1112, 'Depto: " + departamento.Nome + "', '" + MechTech.Util.Global.UsuarioAtivo + "');"); 
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" UPDATE " + Global.EmpresaAtiva + ".departamento SET" +
                                                           "    nome = @nome," +
                                                           "    endereco = @endereco," +
                                                           "    numero = @numero," +
                                                           "    complemento = @complemento," +
                                                           "    bairro = @bairro," +
                                                           "    cep = @cep," +
                                                           "    id_municipio = @id_municipio," +
                                                           "    codigo = @codigo" +
                                                           " WHERE" +
                                                           "    id = @id");
                        db.AddInParameter(dbCommand, "@id", DbType.Int32, departamento.Id);
                        db.AddInParameter(dbCommand, "@nome", DbType.String, departamento.Nome);
                        db.AddInParameter(dbCommand, "@endereco", DbType.String, departamento.Endereco);
                        db.AddInParameter(dbCommand, "@numero", DbType.String, departamento.Numero);
                        db.AddInParameter(dbCommand, "@complemento", DbType.String, departamento.Complemento);
                        db.AddInParameter(dbCommand, "@bairro", DbType.String, departamento.Bairro);
                        db.AddInParameter(dbCommand, "@cep", DbType.String, departamento.Cep);
                        if (departamento.Municipio.Id == 0)
                            db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, null);
                        else
                            db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, departamento.Municipio.Id);
                        db.AddInParameter(dbCommand, "@codigo", DbType.Int32, departamento.Codigo);

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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1113, 'Codigo: " + id.ToString() + "','" + MechTech.Util.Global.UsuarioAtivo + "');"); 
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" DELETE FROM " + Global.EmpresaAtiva + ".departamento" +
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
        /// Retorna um objeto DepartamentoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public DepartamentoDTO GetDepartamento(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetDepartamento");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    DepartamentoDTO tab = new DepartamentoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nome = DR["nome"].ToString();
                    tab.Endereco = DR["endereco"].ToString();
                    tab.Numero = DR["numero"].ToString();
                    tab.Complemento = DR["complemento"].ToString();
                    tab.Bairro = DR["bairro"].ToString();
                    tab.Cep = DR["cep"].ToString();

                    //LOCALIZAR MUNICÍPIO
                    MunicipioDTO municipio = new MunicipioDTO();
                    if (!Convert.IsDBNull(DR["id_municipio"]))
                    {
                        MunicipioDAO municipiodata = new MunicipioDAO();
                        municipio.Id = Convert.ToInt32(DR["id_municipio"]);
                        municipio = municipiodata.GetMunicipio(municipio.Id);
                    }
                    tab.Municipio = municipio;
                    //

                    tab.Codigo = int.Parse(DR["codigo"].ToString());

                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos DepartamentoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<DepartamentoDTO> GetGridDepartamento(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetGridDepartamento");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<DepartamentoDTO> List = new List<DepartamentoDTO>();
                    while (DR.Read())
                    {
                        DepartamentoDTO tab = new DepartamentoDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nome = DR["nome"].ToString();
                        tab.Codigo = int.Parse(DR["codigo"].ToString());

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
        /// Responsável apenas por verificar a existência do Departamento no Banco de dados (Importação de dados).
        /// </summary>
        /// <param name="codigo">Código do Departamento</param>
        /// <returns>true = existe, não = não existe</returns>
        public bool ExistsDepartamento(int codigo)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetDepartamentoCodigo");
                db.AddInParameter(dbCommand, "@codigo", DbType.Int32, codigo);

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
        /// Retorna um objeto DepartamentoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public DepartamentoDTO GetDepartamentoCodigo(int codigo)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetDepartamentoCodigo");
                db.AddInParameter(dbCommand, "@codigo", DbType.Int32, codigo);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    DepartamentoDTO tab = new DepartamentoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nome = DR["nome"].ToString();
                    tab.Endereco = DR["endereco"].ToString();
                    tab.Numero = DR["numero"].ToString();
                    tab.Complemento = DR["complemento"].ToString();
                    tab.Bairro = DR["bairro"].ToString();
                    tab.Cep = DR["cep"].ToString();

                    //LOCALIZAR MUNICÍPIO
                    MunicipioDTO municipio = new MunicipioDTO();
                    if (!Convert.IsDBNull(DR["id_municipio"]))
                    {
                        MunicipioDAO municipiodata = new MunicipioDAO();
                        municipio.Id = Convert.ToInt32(DR["id_municipio"]);
                        municipio = municipiodata.GetMunicipio(municipio.Id);
                    }
                    tab.Municipio = municipio;
                    //

                    tab.Codigo = int.Parse(DR["codigo"].ToString());

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