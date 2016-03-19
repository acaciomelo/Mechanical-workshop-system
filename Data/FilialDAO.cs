using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;

using Devart.Data.PostgreSql;

#region MECHTECH
using MechTech.Entities;
using MechTech.Util;
#endregion

namespace MechTech.Data
{
    public class FilialDAO
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
        /// Instância básica para FilialDAO.
        /// </summary>
        public FilialDAO()
        { }

        /// <summary>
        /// Instância para FilialDAO com controle de transação.
        /// </summary>
        public FilialDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Insert(FilialDTO filial)
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
                            db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1085, '" + filial.Filial.ToString() + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" INSERT INTO public.filial(" +
                                                           "    filial," +
                                                           "    licenca," +
                                                           "    vencimento," +
                                                           "    situacao," +
                                                           "    chave," +
                                                           "    validacep " +
                                                           ") VALUES (" +
                                                           "    @filial," +
                                                           "    @licenca," +
                                                           "    @vencimento," +
                                                           "    @situacao," +
                                                           "    @chave, " +
                                                           "    @validacep)");
                        db.AddInParameter(dbCommand, "@filial", DbType.Int32, filial.Filial);
                        db.AddInParameter(dbCommand, "@licenca", DbType.String, filial.Licenca);
                        db.AddInParameter(dbCommand, "@vencimento", DbType.Date, (DateTime?)filial.Vencimento);
                        db.AddInParameter(dbCommand, "@situacao", DbType.String, filial.Situacao);
                        db.AddInParameter(dbCommand, "@chave", DbType.String, filial.Chave);
                        db.AddInParameter(dbCommand, "@validacep", DbType.Boolean, filial.Validacep);
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
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(FilialDTO filial)
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
                            db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1085, '" + filial.Filial.ToString() + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" UPDATE public.filial SET" +
                                                           "    licenca = @licenca," +
                                                           "    vencimento = @vencimento," +
                                                           "    situacao = @situacao," +
                                                           "    chave = @chave, " +
                                                           "    validacep = @validacep " +
                                                           " WHERE" +
                                                           "    filial = @filial");
                        db.AddInParameter(dbCommand, "@filial", DbType.Int32, filial.Filial);
                        db.AddInParameter(dbCommand, "@licenca", DbType.String, filial.Licenca);
                        db.AddInParameter(dbCommand, "@vencimento", DbType.Date, (DateTime?)filial.Vencimento);
                        db.AddInParameter(dbCommand, "@situacao", DbType.String, filial.Situacao);
                        db.AddInParameter(dbCommand, "@chave", DbType.String, filial.Chave);
                        db.AddInParameter(dbCommand, "@validacep", DbType.Boolean, filial.Validacep);
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
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Delete(int filial)
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
                            db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1085, '','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" DELETE FROM public.filial" +
                                                           " WHERE" +
                                                           "    filial = @filial;");
                        db.AddInParameter(dbCommand, "@filial", DbType.Int32, filial);
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
        /// Retorna um objeto FilialDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FilialDTO GetFilial(int filial)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetFilial");
                db.AddInParameter(dbCommand, "@filial", DbType.Int32, filial);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    FilialDTO tab = new FilialDTO();
                    tab.Filial = int.Parse(DR["filial"].ToString());
                    tab.Licenca = DR["licenca"].ToString();
                    if (Convert.IsDBNull(DR["vencimento"]))
                        tab.Vencimento = null;
                    else
                        tab.Vencimento = (DateTime)DR["vencimento"];
                    tab.Situacao = DR["situacao"].ToString();
                    tab.Chave = DR["chave"].ToString();

                    if (Convert.IsDBNull(DR["validacep"]))
                        tab.Validacep = false;
                    else
                        tab.Validacep = bool.Parse(DR["validacep"].ToString());

                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FilialDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FilialDTO> GetGridFilial(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridFilial");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<FilialDTO> List = new List<FilialDTO>();
                    while (DR.Read())
                    {
                        FilialDTO tab = new FilialDTO();
                        tab.Filial = int.Parse(DR["filial"].ToString());
                        tab.Licenca = DR["licenca"].ToString();
                        if (Convert.IsDBNull(DR["vencimento"]))
                            tab.Vencimento = null;
                        else
                            tab.Vencimento = (DateTime)DR["vencimento"];
                        tab.Chave = DR["chave"].ToString();
                        tab.Situacao = DR["situacao"].ToString();

                        if (Convert.IsDBNull(DR["validacep"]))
                            tab.Validacep = false;
                        else
                            tab.Validacep = bool.Parse(DR["validacep"].ToString());


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