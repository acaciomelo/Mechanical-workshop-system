using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MechTech.Util;

#region DEVART
using Devart.Data.PostgreSql;
using MechTech.Atualizacao.Entities;
#endregion

namespace MechTech.Atualizacao.Data
{
    public class ExecutaSQLDAO
    {
        Database db = null;
        DbCommand dbCommand = null;

        public ExecutaSQLDAO()
        { }

        public ExecutaSQLDAO(string conexaoString)
        {
            db = new GenericDatabase(conexaoString, PgSqlProviderFactory.Instance);
        }

        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }
        public void Create(ScriptDTO script)
        {
            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                    try
                    {
                        string DDL = script.Script.Replace("[empresa]", Global.EmpresaAtiva);
                        dbCommand = db.GetSqlStringCommand(DDL);
                        db.ExecuteNonQuery(dbCommand, transaction);
                        Insert(script);
                        transaction.Commit();
                        connection.Close();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        connection.Close();
                        throw new Exception("A seguinte consulta não pode ser executada: " + "\nVersão: " + script.Versao + "\nMódulo: " + script.Modulo + "\nConsulta: " + script.Id_script, e);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void Insert(ScriptDTO script)
        {
            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                    try
                    {
                        dbCommand = db.GetSqlStringCommand("Insert Into public.scriptpacote(" +
                            " id_pacote," +
                            " script," +
                            " executado," +
                            " id_script," +
                            " erro" +
                            ") VALUES (" +
                            " @id_pacote," +
                            " @script," +
                            " @executado," +
                            " @id_script," +
                            " @erro);" +
                            " SELECT currval('scriptpacote_id_seq');");
                        db.AddInParameter(dbCommand, "@id_pacote", DbType.String, script.Id_pacote);
                        db.AddInParameter(dbCommand, "@script", DbType.String, script.Script);
                        db.AddInParameter(dbCommand, "@executado", DbType.Boolean, script.Executado);
                        db.AddInParameter(dbCommand, "@id_script", DbType.String, script.Id_script);
                        db.AddInParameter(dbCommand, "@erro", DbType.String, script.Erro);
                        db.ExecuteNonQuery(dbCommand, transaction);

                        transaction.Commit();
                        connection.Close();
                    }
                    catch (DbException dbex)
                    {
                        transaction.Rollback();
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

        public void Update(ScriptDTO script)
        {
            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                    try
                    {
                        dbCommand = db.GetSqlStringCommand(" UPDATE public.scriptpacote SET" +
                                                          "    id_pacote = @id_pacote," +
                                                          "    script = @script," +
                                                          "    executado = @executado," +
                                                          "    erro = @erro" +
                                                          "     WHERE" +
                                                          "     id = @id");
                        db.AddInParameter(dbCommand, "@id_pacote", DbType.String, script.Id_pacote);
                        db.AddInParameter(dbCommand, "@script", DbType.String, script.Script);
                        db.AddInParameter(dbCommand, "@executado", DbType.Boolean, script.Executado);
                        db.AddInParameter(dbCommand, "@erro", DbType.String, script.Erro);
                        db.ExecuteNonQuery(dbCommand, transaction);

                        transaction.Commit();
                        connection.Close();
                    }
                    catch (DbException dbex)
                    {
                        transaction.Rollback();
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

        public bool GetScript(ScriptDTO script)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" SELECT id_pacote, id_script FROM scriptpacote" +
                                                      " where id_pacote = @id_pacote and id_script = @id_script" +
                                                      " ORDER BY id_pacote desc");
                db.AddInParameter(dbCommand, "@id_script", DbType.Int32, script.Id_script);
                db.AddInParameter(dbCommand, "@id_pacote", DbType.Int32, script.Id_pacote);


                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    while (DR.Read())
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
