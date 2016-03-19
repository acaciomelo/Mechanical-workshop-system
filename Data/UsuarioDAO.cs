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
    public class UsuarioDAO : IDados<UsuarioDTO>
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
        /// Instância básica para UsuarioDAO.
        /// </summary>
        public UsuarioDAO()
        { }

        /// <summary>
        /// Instância para UsuarioDAO com controle de transação.
        /// </summary>
        public UsuarioDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        /// 
        public void Insert2(UsuarioDTO usuario)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(5, '');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" INSERT INTO public.usuario(" +
                                                           "    id," +
                                                           "    nome," +
                                                           "    ativo," +
                                                           "    login," +
                                                           "    senha," +
                                                           "    supervisor," +
                                                           "    modulo" +
                                                           ") VALUES (" +
                                                           "    @id," +
                                                           "    @nome," +
                                                           "    @ativo," +
                                                           "    @login," +
                                                           "    @senha," +
                                                           "    @supervisor," +
                                                           "    @modulo);");
                        db.AddInParameter(dbCommand, "@id", DbType.String, usuario.Id);
                        db.AddInParameter(dbCommand, "@nome", DbType.String, usuario.Nome);
                        db.AddInParameter(dbCommand, "@ativo", DbType.Boolean, usuario.Ativo);
                        db.AddInParameter(dbCommand, "@login", DbType.String, usuario.Login);
                        db.AddInParameter(dbCommand, "@senha", DbType.String, usuario.Senha);
                        db.AddInParameter(dbCommand, "@supervisor", DbType.Boolean, usuario.Supervisor);
                        db.AddInParameter(dbCommand, "@modulo", DbType.Boolean, usuario.Modulo);
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
            }
            catch
            {
                throw;
            }
        }

        public int Insert(UsuarioDTO usuario)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1, '', '" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" INSERT INTO public.usuario(" +
                                                           "    nome," +
                                                           "    ativo," +
                                                           "    login," +
                                                           "    senha," +
                                                           "    supervisor," +
                                                           "    modulo," +
                                                           "    mechtechativo" +
                                                           ") VALUES (" +
                                                           "    @nome," +
                                                           "    @ativo," +
                                                           "    @login," +
                                                           "    @senha," +
                                                           "    @supervisor," +
                                                           "    @modulo," +
                                                           "    @mechtechativo);" +
                                                           " SELECT currval('usuario_id_seq1');");
                        db.AddInParameter(dbCommand, "@nome", DbType.String, usuario.Nome);
                        db.AddInParameter(dbCommand, "@ativo", DbType.Boolean, usuario.Ativo);
                        db.AddInParameter(dbCommand, "@login", DbType.String, usuario.Login);
                        db.AddInParameter(dbCommand, "@senha", DbType.String, usuario.Senha);
                        db.AddInParameter(dbCommand, "@supervisor", DbType.Boolean, usuario.Supervisor);
                        db.AddInParameter(dbCommand, "@modulo", DbType.Boolean, usuario.Modulo);
                        db.AddInParameter(dbCommand, "@mechtechativo", DbType.Boolean, usuario.Mechtechativo);
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
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(UsuarioDTO usuario)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1, '','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" UPDATE public.usuario SET" +
                                                           "    nome = @nome," +
                                                           "    ativo = @ativo," +
                                                           "    login = @login," +
                                                           "    senha = @senha," +
                                                           "    supervisor = @supervisor," +
                                                           "    modulo = @modulo" +
                                                           " WHERE" +
                                                           "    id = @id");
                        db.AddInParameter(dbCommand, "@id", DbType.Int32, usuario.Id);
                        db.AddInParameter(dbCommand, "@nome", DbType.String, usuario.Nome);
                        db.AddInParameter(dbCommand, "@ativo", DbType.Boolean, usuario.Ativo);
                        db.AddInParameter(dbCommand, "@login", DbType.String, usuario.Login);
                        db.AddInParameter(dbCommand, "@senha", DbType.String, usuario.Senha);
                        db.AddInParameter(dbCommand, "@supervisor", DbType.Boolean, usuario.Supervisor);
                        db.AddInParameter(dbCommand, "@modulo", DbType.Boolean, usuario.Modulo);
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1, '','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" DELETE FROM public.usuario" +
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
        /// Retorna um objeto UsuarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public UsuarioDTO GetUsuario(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetUsuario");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    UsuarioDTO tab = new UsuarioDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nome = DR["nome"].ToString();
                    tab.Ativo = bool.Parse(DR["ativo"].ToString());
                    tab.Login = DR["login"].ToString();
                    tab.Senha = DR["senha"].ToString();
                    tab.Supervisor = bool.Parse(DR["supervisor"].ToString());
                    tab.Modulo = bool.Parse(DR["modulo"].ToString());
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos UsuarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<UsuarioDTO> GetGridUsuario(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridUsuario");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<UsuarioDTO> List = new List<UsuarioDTO>();
                    while (DR.Read())
                    {
                        UsuarioDTO tab = new UsuarioDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nome = DR["nome"].ToString();
                        tab.Ativo = bool.Parse(DR["ativo"].ToString());
                        tab.Login = DR["login"].ToString();
                        tab.Senha = DR["senha"].ToString();
                        tab.Supervisor = bool.Parse(DR["supervisor"].ToString());
                        tab.Modulo = bool.Parse(DR["modulo"].ToString());
                        try
                        {
                            tab.Mechtechativo = bool.Parse(DR["mechtechativo"].ToString());
                        }
                        catch { }
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

        //TODO: Implemente códigos adicionais aqui.

        /// <summary>
        /// Retorna um objeto UsuarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public UsuarioDTO GetUsuarioByLogin(string login)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetUsuarioByLogin");
                db.AddInParameter(dbCommand, "login", DbType.String, login);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    UsuarioDTO tab = new UsuarioDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nome = DR["nome"].ToString();
                    tab.Ativo = bool.Parse(DR["ativo"].ToString());
                    tab.Login = DR["login"].ToString();
                    tab.Senha = DR["senha"].ToString();
                    tab.Supervisor = bool.Parse(DR["supervisor"].ToString());
                    tab.Modulo = bool.Parse(DR["modulo"].ToString());
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