using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

#region DEVART
using Devart.Data.PostgreSql;
#endregion

#region MECHTECH
using MechTech.Entities;
#endregion

namespace MechTech.Data
{
    public class BackupDAO
    {
        //Database db = DatabaseFactory.CreateDatabase();         
        Database db = new GenericDatabase((MechTech.Util.Global.ConnectionStringUser == string.Empty ? MechTech.Util.Global.ConnectionStringPg : MechTech.Util.Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        Database db2 = null;
        DbCommand dbCommand = null;

        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        /// <summary>
        /// Instância básica para BackupDAO.
        /// </summary>
        public BackupDAO()
        { }

        /// <summary>
        /// Instância para BackupDAO com controle de transação.
        /// </summary>
        public BackupDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(BackupDTO backup)
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
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(3, 'Inserindo registro','" + MechTech.Util.Global.UsuarioAtivo + "');"); 
                    }

                    dbCommand = db.GetSqlStringCommand(" INSERT INTO public.backup(" +
                                                       " data," +
                                                       " hora," +
                                                       " usuario," +
                                                       " maquina," +
                                                       " nomedados," +
                                                       " nomeempresa," +
                                                       " tamanho," +
                                                       " versao," +
                                                       " banco" +
                                                       ") VALUES (" +
                                                       " @data," +
                                                       " @hora," +
                                                       " @usuario," +
                                                       " @maquina," +
                                                       " @nomedados," +
                                                       " @nomeempresa," +
                                                       " @tamanho," +
                                                       " @versao," +
                                                       " @banco);" +
                                                       " SELECT currval('backup_id_seq');");
                    db.AddInParameter(dbCommand, "@data", DbType.Date, (DateTime?)backup.Data);
                    db.AddInParameter(dbCommand, "@hora", DbType.Time, (TimeSpan)backup.Hora);
                    db.AddInParameter(dbCommand, "@usuario", DbType.String, backup.Usuario);
                    db.AddInParameter(dbCommand, "@maquina", DbType.String, backup.Maquina);
                    db.AddInParameter(dbCommand, "@nomedados", DbType.String, backup.Nomedados);
                    db.AddInParameter(dbCommand, "@nomeempresa", DbType.String, backup.Nomeempresa);
                    db.AddInParameter(dbCommand, "@tamanho", DbType.Int32, backup.Tamanho);
                    db.AddInParameter(dbCommand, "@versao", DbType.String, backup.Versao);
                    db.AddInParameter(dbCommand, "@banco", DbType.String, backup.Banco);
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
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(BackupDTO backup)
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
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(3, 'Atualizando registro','" + MechTech.Util.Global.UsuarioAtivo + "');"); 
                    }

                    dbCommand = db.GetSqlStringCommand(" UPDATE public.backup SET" +
                                                       " data = @data," +
                                                       " hora = @hora," +
                                                       " usuario = @usuario," +
                                                       " maquina = @maquina," +
                                                       " nomedados = @nomedados," +
                                                       " nomeempresa = @nomeempresa," +
                                                       " tamanho = @tamanho," +
                                                       " versao = @versao," +
                                                       " banco = @banco" +
                                                       " WHERE" +
                                                       " id = @id");
                    db.AddInParameter(dbCommand, "@id", DbType.Int32, backup.Id);
                    db.AddInParameter(dbCommand, "@data", DbType.Date, (DateTime?)backup.Data);
                    db.AddInParameter(dbCommand, "@hora", DbType.Time, (TimeSpan)backup.Hora);
                    db.AddInParameter(dbCommand, "@usuario", DbType.String, backup.Usuario);
                    db.AddInParameter(dbCommand, "@maquina", DbType.String, backup.Maquina);
                    db.AddInParameter(dbCommand, "@nomedados", DbType.String, backup.Nomedados);
                    db.AddInParameter(dbCommand, "@nomeempresa", DbType.String, backup.Nomeempresa);
                    db.AddInParameter(dbCommand, "@tamanho", DbType.Int32, backup.Tamanho);
                    db.AddInParameter(dbCommand, "@versao", DbType.String, backup.Versao);
                    db.AddInParameter(dbCommand, "@banco", DbType.String, backup.Banco);
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
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
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
                        //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(3, 'Excluindo registro','" + MechTech.Util.Global.UsuarioAtivo + "');"); 
                    }

                    dbCommand = db.GetSqlStringCommand(" DELETE FROM public.backup" +
                                                       " WHERE" +
                                                       " id = @id;");
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
        /// Retorna um objeto BackupDTO caso a instrução seja bem sucedida.
        /// </summary>
        public BackupDTO GetBackup(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetBackup");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    DR.Read();
                    BackupDTO tab = new BackupDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Data = (DateTime)DR["data"];
                    tab.Hora = (TimeSpan)DR["hora"];
                    tab.Usuario = DR["usuario"].ToString();
                    tab.Maquina = DR["maquina"].ToString();
                    tab.Nomedados = DR["nomedados"].ToString();
                    tab.Nomeempresa = DR["nomeempresa"].ToString();
                    tab.Tamanho = int.Parse(DR["tamanho"].ToString());
                    tab.Versao = DR["versao"].ToString();
                    tab.Banco = DR["banco"].ToString();
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos BackupDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<BackupDTO> GetGridBackup()
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridBackup");

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    List<BackupDTO> List = new List<BackupDTO>();
                    while (DR.Read())
                    {
                        BackupDTO tab = new BackupDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Data = (DateTime)DR["data"];
                        tab.Hora = (TimeSpan)DR["hora"];
                        tab.Usuario = DR["usuario"].ToString();
                        tab.Maquina = DR["maquina"].ToString();
                        tab.Nomedados = DR["nomedados"].ToString();
                        tab.Nomeempresa = DR["nomeempresa"].ToString();
                        tab.Tamanho = int.Parse(DR["tamanho"].ToString());
                        tab.Versao = DR["versao"].ToString();
                        tab.Banco = DR["banco"].ToString();
                        List.Add(tab);
                    }
                    return List;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto BackupDTO caso com os dados do ultimo backup realizado
        /// </summary>
        public BackupDTO GetLastBackup()
        {
            try
            {
                dbCommand = db.GetSqlStringCommand("SELECT * from backup order by 1 desc limit 1;");
                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    BackupDTO tab = new BackupDTO();
                    if (DR.Read())
                    {
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Data = (DateTime)DR["data"];
                        tab.Hora = (TimeSpan)DR["hora"];
                        tab.Usuario = DR["usuario"].ToString();
                        tab.Maquina = DR["maquina"].ToString();
                        tab.Nomedados = DR["nomedados"].ToString();
                        tab.Nomeempresa = DR["nomeempresa"].ToString();
                        tab.Tamanho = int.Parse(DR["tamanho"].ToString());
                        tab.Versao = DR["versao"].ToString();
                        tab.Banco = DR["banco"].ToString();
                    }
                    return tab;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna o numero da filial em uso para identificação de backup
        /// </summary>
        public int GetFilialBackup()
        {
            try
            {
                dbCommand = db.GetSqlStringCommand("SELECT filial from filial limit 1;");
                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    int filial = new int();
                    if (DR.Read())
                    {
                        filial = int.Parse(DR["filial"].ToString());
                    }
                    return filial;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica se o backup é monitorado pela MW
        /// </summary>
        public bool MonitoraBackup()
        {
            try
            {
                dbCommand = db.GetSqlStringCommand("SELECT monitorabackup from parametros;");
                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    bool monitora = false;
                    if (DR.Read())
                    {
                        if (Convert.IsDBNull(DR["monitorabackup"]))
                            monitora = false;
                        else
                            monitora = bool.Parse(DR["monitorabackup"].ToString());
                    }
                    return monitora;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Grava informações sobre o backup na base da MECHTECH
        /// </summary>
        //public bool InsertMW(BackupDTO backup, string sistema, int filial)
        //{

        //    db2 = new GenericDatabase("host=www.mwk.com.br;Port=5432;Database=assist;User=assist;Password=assist456;Unicode=False;Protocol=2", PgSqlProviderFactory.Instance);
        //    DbConnection connection = null;
        //    bool transactionstart = false;

        //    try
        //    {
        //        using (connection = db2.CreateConnection())
        //        {
        //            connection.Open();
        //            if (Transaction == null)
        //            {
        //                Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
        //                transactionstart = true;
        //                //db2.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(0, '');");
        //            }

        //            dbCommand = db2.GetSqlStringCommand(" INSERT INTO public.bkpcliente(" +
        //                                                " filial," +
        //                                                " sistema," +
        //                                                " data," +
        //                                                " hora," +
        //                                                " usuario," +
        //                                                " maquina," +
        //                                                " arquivo," +
        //                                                " tamanho," +
        //                                                " versao," +
        //                                                " banco" +
        //                                                ") VALUES (" +
        //                                                " @filial," +
        //                                                " @sistema," +
        //                                                " @data," +
        //                                                " @hora," +
        //                                                " @usuario," +
        //                                                " @maquina," +
        //                                                " @arquivo," +
        //                                                " @tamanho," +
        //                                                " @versao," +
        //                                                " @banco);");
        //            db2.AddInParameter(dbCommand, "@filial", DbType.Int32, filial);
        //            db2.AddInParameter(dbCommand, "@sistema", DbType.String, sistema);
        //            db2.AddInParameter(dbCommand, "@data", DbType.Int32, (backup.Data.ToOADate() + 36161));
        //            db2.AddInParameter(dbCommand, "@hora", DbType.Int32, (backup.Hora.Ticks / 100000) + 1);
        //            db2.AddInParameter(dbCommand, "@usuario", DbType.String, backup.Usuario);
        //            db2.AddInParameter(dbCommand, "@maquina", DbType.String, backup.Maquina);
        //            db2.AddInParameter(dbCommand, "@arquivo", DbType.String, backup.Nomeempresa);
        //            db2.AddInParameter(dbCommand, "@tamanho", DbType.Int32, backup.Tamanho);
        //            db2.AddInParameter(dbCommand, "@versao", DbType.String, backup.Versao);
        //            db2.AddInParameter(dbCommand, "@banco", DbType.String, backup.Banco);
        //            db2.ExecuteNonQuery(dbCommand, Transaction);

        //            if (transactionstart)
        //            {
        //                Transaction.Commit();
        //                Transaction = null;
        //            }
        //            connection.Close();
        //            return true;
        //        }
        //    }
        //    catch
        //    {
        //        if (transactionstart)
        //        {
        //            if (Transaction.Connection.State == ConnectionState.Open)
        //                Transaction.Rollback();
        //            Transaction = null;
        //        }
        //        if (connection.State == ConnectionState.Open)
        //            connection.Close();
        //        return false;
        //    }
        //}

        /// <summary>
        /// Gravando log da Execução do backup
        /// </summary>
        public void GravaLOGBackup(int rotina, string ocorrencia)
        {
            try
            {
                //dbCommand = db.GetStoredProcCommand("GravaLOG_App");
                //db.AddInParameter(dbCommand, "@rotina", DbType.Int32, rotina);
                //db.AddInParameter(dbCommand, "@ocorrencia", DbType.String, ocorrencia);
                //db.AddInParameter(dbCommand, "@usuario", DbType.String, MechTech.Util.Global.UsuarioAtivo); 
                //if (Transaction == null)
                //    db.ExecuteNonQuery(dbCommand);
                //else
                //    db.ExecuteNonQuery(dbCommand, Transaction);
            }
            catch
            {
                throw;
            }
        }

    }
}
