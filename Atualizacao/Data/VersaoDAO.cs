using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

#region DEVART
using Devart.Data.PostgreSql;
#endregion

namespace MechTech.Atualizacao.Data
{
    public class VersaoDAO
    {
        Database db = null;
        DbCommand dbCommand = null;


        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        /// <summary>
        /// Instância básica para CpArqDbDAO.
        /// </summary>
        public VersaoDAO()
        { }

        /// <summary>
        /// Instância para CpArqDbDAO com controle de transação.
        /// </summary>
        public VersaoDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        public int VerificaVersaoModulo(string conexao, int versao, int modulo)
        {
            db = new GenericDatabase(conexao, PgSqlProviderFactory.Instance);
            DbConnection connection = null;

            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    dbCommand = db.GetSqlStringCommand(" SELECT id, versao, modulo FROM PACOTE" +
                                                       " where versao = @versao and modulo = @modulo" +
                                                       " ORDER BY versao desc, modulo desc");
                    db.AddInParameter(dbCommand, "@versao", DbType.Int32, versao);
                    db.AddInParameter(dbCommand, "@modulo", DbType.Int32, modulo);

                    int idPacote = 0;

                    using (IDataReader DR = db.ExecuteReader(dbCommand))
                    {
                        while (DR.Read())
                        {
                            idPacote = int.Parse(DR["id"].ToString());
                        }
                    }

                    return idPacote;
                }
            }
            catch
            {
                throw;
            }
        }

        public void Insert(int versao, int modulo, string data, string hora, string conexao)
        {
            db = new GenericDatabase(conexao, PgSqlProviderFactory.Instance);
            DbConnection connection = null;

            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                    dbCommand = db.GetSqlStringCommand("Insert Into public.pacote(" +
                        " versao," +
                        " modulo," +
                        " dataatualiza," +
                        " horaatualiza" +
                        ") VALUES (" +
                        " @versao," +
                        " @modulo," +
                        " @dataatualiza," +
                        " @horaatualiza);" +
                        " SELECT currval('pacote_id_seq');");
                    db.AddInParameter(dbCommand, "@versao", DbType.Int16, versao);
                    db.AddInParameter(dbCommand, "@modulo", DbType.Int16, modulo);
                    db.AddInParameter(dbCommand, "@dataatualiza", DbType.String, data);
                    db.AddInParameter(dbCommand, "@horaatualiza", DbType.String, hora);
                    db.ExecuteNonQuery(dbCommand, transaction);
                    connection.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        public string VersaoAtual(string conexao)
        {
            db = new GenericDatabase(conexao, PgSqlProviderFactory.Instance);
            DbConnection connection = null;

            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    dbCommand = db.GetSqlStringCommand(" SELECT versao,modulo FROM PACOTE" +
                                                       " ORDER BY versao desc, modulo desc" +
                                                       " LIMIT 1");

                    string versao = "1.00.000";

                    using (IDataReader DR = db.ExecuteReader(dbCommand))
                    {
                        while (DR.Read())
                        {
                            versao = decimal.Parse(DR["versao"].ToString()).ToString("N02") + "." + CompletarZerosEsquerda(DR["modulo"].ToString(), 4);
                            versao = versao.Replace(",", ".");
                        }
                    }

                    return versao;
                }
            }
            catch
            {
                throw;
            }
        }

        public string DataVersaoAtual(string conexao)
        {
            db = new GenericDatabase(conexao, PgSqlProviderFactory.Instance);
            DbConnection connection = null;

            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    dbCommand = db.GetSqlStringCommand(" SELECT versao,modulo,dataatualiza FROM PACOTE" +
                                                       " ORDER BY versao desc, modulo desc" +
                                                       " LIMIT 1");

                    string dataAtualiza = string.Empty;

                    using (IDataReader DR = db.ExecuteReader(dbCommand))
                    {
                        while (DR.Read())
                        {
                            dataAtualiza = DR["dataAtualiza"].ToString();
                        }
                    }

                    return dataAtualiza;
                }
            }
            catch
            {
                throw;
            }
        }

        public static string CompletarZerosEsquerda(int numero, int qtdzeros)
        {
            return numero.ToString().PadLeft(qtdzeros, '0');
        }

        public static string CompletarZerosEsquerda(string valor, int qtdzeros)
        {
            return valor.PadLeft(qtdzeros, '0');
        }
    }
}
