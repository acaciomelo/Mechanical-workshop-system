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
    public class FuncSalarioDAO : IDados<FuncSalarioDTO>
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
        /// Instância básica para FuncSalarioDAO.
        /// </summary>
        public FuncSalarioDAO()
        { }

        /// <summary>
        /// Instância para FuncSalarioDAO com controle de transação.
        /// </summary>
        public FuncSalarioDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(FuncSalarioDTO Funcsalario)
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
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(0, 'Inserindo RRA meses','" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }

                    dbCommand = db.GetSqlStringCommand(" INSERT INTO " + Global.EmpresaAtiva + ".funcsalario(" +
                                                   "    data," +
                                                   "    datareajuste," +
                                                   "    id_funcionario," +
                                                   "    id_departamento," +
                                                   "    id_setor," +
                                                   "    id_secao," +
                                                   "    id_funcao," +
                                                   "    salario," +
                                                   "    motivo" +
                                                   ") VALUES (" +
                                                   "    @data," +
                                                   "    @datareajuste," +
                                                   "    @id_funcionario," +
                                                   "    @id_departamento," +
                                                   "    @id_setor," +
                                                   "    @id_secao," +
                                                   "    @id_funcao," +
                                                   "    @salario," +
                                                   "    @motivo);" +
                                                   " SELECT currval('" + Global.EmpresaAtiva + ".funcsalario_id_seq');");
                    db.AddInParameter(dbCommand, "@data", DbType.Date, (DateTime?)Funcsalario.Data);
                    db.AddInParameter(dbCommand, "@datareajuste", DbType.Date, (DateTime?)Funcsalario.DataReajuste);
                    db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, Funcsalario.Id_funcionario);
                    if (Funcsalario.Departamento.Id != 0)
                        db.AddInParameter(dbCommand, "@id_departamento", DbType.Int32, Funcsalario.Departamento.Id);
                    else
                        db.AddInParameter(dbCommand, "@id_departamento", DbType.Int32, null);
                    if (Funcsalario.Setor.Id != 0)
                        db.AddInParameter(dbCommand, "@id_setor", DbType.Int32, Funcsalario.Setor.Id);
                    else
                        db.AddInParameter(dbCommand, "@id_setor", DbType.Int32, null);
                    if (Funcsalario.Secao.Id != 0)
                        db.AddInParameter(dbCommand, "@id_secao", DbType.Int32, Funcsalario.Secao.Id);
                    else
                        db.AddInParameter(dbCommand, "@id_secao", DbType.Int32, null);
                    db.AddInParameter(dbCommand, "@id_funcao", DbType.Int32, Funcsalario.Funcao.Id);
                    db.AddInParameter(dbCommand, "@salario", DbType.Decimal, Funcsalario.Salario);
                    db.AddInParameter(dbCommand, "@motivo", DbType.String, Funcsalario.Motivo);
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
        public bool Update(FuncSalarioDTO Funcsalario)
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
                        db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(0, 'Atualizando RRA meses','" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }

                    dbCommand = db.GetSqlStringCommand(" UPDATE " + Global.EmpresaAtiva + ".funcsalario SET" +
                                                   "    data = @data," +
                                                   "    datareajuste = @datareajuste," +
                                                   "    id_funcionario = @id_funcionario," +
                                                   "    id_departamento = @id_departamento," +
                                                   "    id_setor = @id_setor," +
                                                   "    id_secao = @id_secao," +
                                                   "    id_funcao = @id_funcao," +
                                                   "    salario = @salario," +
                                                   "    motivo = @motivo" +
                                                   " WHERE" +
                                                   "    id = @id");
                    db.AddInParameter(dbCommand, "@id", DbType.Int32, Funcsalario.Id);
                    db.AddInParameter(dbCommand, "@data", DbType.Date, (DateTime?)Funcsalario.Data);
                    db.AddInParameter(dbCommand, "@datareajuste", DbType.Date, (DateTime?)Funcsalario.DataReajuste);
                    db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, Funcsalario.Id_funcionario);
                    db.AddInParameter(dbCommand, "@id_departamento", DbType.Int32, Funcsalario.Departamento.Id);
                    db.AddInParameter(dbCommand, "@id_setor", DbType.Int32, Funcsalario.Setor.Id);
                    db.AddInParameter(dbCommand, "@id_secao", DbType.Int32, Funcsalario.Secao.Id);
                    db.AddInParameter(dbCommand, "@id_funcao", DbType.Int32, Funcsalario.Funcao.Id);
                    db.AddInParameter(dbCommand, "@salario", DbType.Decimal, Funcsalario.Salario);
                    db.AddInParameter(dbCommand, "@motivo", DbType.Int32, Funcsalario.Motivo);
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
                        db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(0, 'Excluindo RRA meses','" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }

                    dbCommand = db.GetSqlStringCommand(" DELETE FROM " + Global.EmpresaAtiva + ".funcsalario" +
                                                   " WHERE id = @id;");
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
        /// Retorna uma lista de objetos FuncsalarioDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<FuncSalarioDTO> GetFuncsalarioFuncionario(int id_funcionario)
        {
            try
            {
                //CAPTURAR O SALÁRIO DE ACORDO COM O MÊS/ANO ATIVO.
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFuncsalarioFuncionario");
                db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, id_funcionario);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<FuncSalarioDTO> List = new List<FuncSalarioDTO>();
                    while (DR.Read())
                    {
                        FuncSalarioDTO tab = new FuncSalarioDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        if (Convert.IsDBNull(DR["data"]))
                            tab.Data = null;
                        else
                            tab.Data = (DateTime)DR["data"];
                        if (Convert.IsDBNull(DR["datareajuste"]))
                            tab.DataReajuste = null;
                        else
                            tab.DataReajuste = (DateTime)DR["datareajuste"];
                        tab.Id_funcionario = int.Parse(DR["id_funcionario"].ToString());

                        //LOCALIZAR DEPARTAMENTO
                        DepartamentoDTO departamento = new DepartamentoDTO();
                        if (!Convert.IsDBNull(DR["id_departamento"]))
                        {
                            DepartamentoDAO departamentodata = new DepartamentoDAO();
                            departamento.Id = Convert.ToInt32(DR["id_departamento"]);
                            departamento = departamentodata.GetDepartamento(departamento.Id);
                        }
                        tab.Departamento = departamento;
                        //

                        //LOCALIZAR SETOR
                        SetorDTO setor = new SetorDTO();
                        if (!Convert.IsDBNull(DR["id_setor"]))
                        {
                            SetorDAO setordata = new SetorDAO();
                            setor.Id = Convert.ToInt32(DR["id_setor"]);
                            setor = setordata.GetSetor(setor.Id);
                        }
                        tab.Setor = setor;
                        //

                        //LOCALIZAR SECAO
                        SecaoDTO secao = new SecaoDTO();
                        if (!Convert.IsDBNull(DR["id_secao"]))
                        {
                            SecaoDAO secaodata = new SecaoDAO();
                            secao.Id = Convert.ToInt32(DR["id_secao"]);
                            secao = secaodata.GetSecao(secao.Id);
                        }
                        tab.Secao = secao;
                        //

                        //LOCALIZAR FUNCAO
                        FuncaoDTO funcao = new FuncaoDTO();
                        if (Convert.ToInt32(DR["id_funcao"]) != 0)
                        {
                            FuncaoDAO funcaodata = new FuncaoDAO();
                            funcao.Id = Convert.ToInt32(DR["id_funcao"]);
                            funcao = funcaodata.GetFuncao(funcao.Id);
                        }
                        tab.Funcao = funcao;
                        tab.Salario = decimal.Parse(DR["salario"].ToString());
                        tab.Motivo = DR["motivo"].ToString();

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

        public FuncSalarioDTO GetFuncsalarioFuncionarioCurrent(int id_funcionario) //31236
        {
            try
            {
                //CAPTURAR O SALÁRIO DE ACORDO COM O MÊS/ANO ATIVO.
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetFuncsalarioFuncionario");
                db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, id_funcionario);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    FuncSalarioDTO List = new FuncSalarioDTO();
                    while (DR.Read())
                    {
                        FuncSalarioDTO tab = new FuncSalarioDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        if (Convert.IsDBNull(DR["data"]))
                            tab.Data = null;
                        else
                            tab.Data = (DateTime)DR["data"];
                        if (Convert.IsDBNull(DR["datareajuste"]))
                            tab.DataReajuste = null;
                        else
                            tab.DataReajuste = (DateTime)DR["datareajuste"];
                        tab.Id_funcionario = int.Parse(DR["id_funcionario"].ToString());

                        //LOCALIZAR DEPARTAMENTO
                        DepartamentoDTO departamento = new DepartamentoDTO();
                        if (!Convert.IsDBNull(DR["id_departamento"]))
                        {
                            DepartamentoDAO departamentodata = new DepartamentoDAO();
                            departamento.Id = Convert.ToInt32(DR["id_departamento"]);
                            departamento = departamentodata.GetDepartamento(departamento.Id);
                        }
                        tab.Departamento = departamento;
                        //

                        //LOCALIZAR SETOR
                        SetorDTO setor = new SetorDTO();
                        if (!Convert.IsDBNull(DR["id_setor"]))
                        {
                            SetorDAO setordata = new SetorDAO();
                            setor.Id = Convert.ToInt32(DR["id_setor"]);
                            setor = setordata.GetSetor(setor.Id);
                        }
                        tab.Setor = setor;
                        //

                        //LOCALIZAR SECAO
                        SecaoDTO secao = new SecaoDTO();
                        if (!Convert.IsDBNull(DR["id_secao"]))
                        {
                            SecaoDAO secaodata = new SecaoDAO();
                            secao.Id = Convert.ToInt32(DR["id_secao"]);
                            secao = secaodata.GetSecao(secao.Id);
                        }
                        tab.Secao = secao;
                        //

                        //LOCALIZAR FUNCAO
                        FuncaoDTO funcao = new FuncaoDTO();
                        if (Convert.ToInt32(DR["id_funcao"]) != 0)
                        {
                            FuncaoDAO funcaodata = new FuncaoDAO();
                            funcao.Id = Convert.ToInt32(DR["id_funcao"]);
                            funcao = funcaodata.GetFuncao(funcao.Id);
                        }
                        tab.Funcao = funcao;

                        return tab;
                    }

                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do conteúdo especificado, caso contrário FALSO.
        /// </summary>
        public bool DeleteFuncionario(int id_funcionario)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" DELETE FROM " + Global.EmpresaAtiva + ".funcsalario" +
                                                   " WHERE id_funcionario = @id_funcionario;");
                db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, id_funcionario);
                db.ExecuteNonQuery(dbCommand, Transaction);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}