using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

#region DEVART
using Devart.Data.PostgreSql;
#endregion

#region MECHTECH
using MechTech.Entities;
using MechTech.Util;
using System.Data;
#endregion

namespace MechTech.Data
{
    public class AtivacaoDAO
    {
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance);
        DbCommand dbcommand = null;
        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        public AtivacaoDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        public AtivacaoDAO()
        {
        }

        public bool VerificaSeClienteAtivou()
        {
            bool ativou = false;
            try
            {
                dbcommand = db.GetSqlStringCommand("Select razao FROM public.oficina");

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbcommand) : db.ExecuteReader(dbcommand, Transaction)))
                {
                    if (DR.Read())
                    {
                        ativou = true;
                    }
                }
                return ativou;
            }
            catch
            {
                return ativou;
            }
        }

        public void InserirClienteLocal(string razao)
        {
            bool transactionstart = false;
            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    try
                    {
                        connection.Open();
                        transactionstart = true;
                        if (Transaction == null)
                        {
                            Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                        }

                        dbcommand = db.GetSqlStringCommand("Insert Into public.oficina(" +
                            "razao)" +
                            "values(" +
                            "@razao);");

                        db.AddInParameter(dbcommand, "@razao", DbType.String, razao);
                        db.ExecuteScalar(dbcommand, Transaction);

                        if (transactionstart)
                        {
                            Transaction.Commit();
                            Transaction = null;
                        }
                        connection.Close();
                    }
                    catch (DbException dbex)
                    {
                        if (Transaction != null)
                            Transaction.Rollback();
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

        public string getRazaoCliente()
        {
            string razao = "";
            try
            {
                dbcommand = db.GetSqlStringCommand("Select razao FROM public.oficina");

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbcommand) : db.ExecuteReader(dbcommand, Transaction)))
                {
                    while (DR.Read())
                    {
                        razao = (DR["razao"].ToString());
                    }
                }
                return razao;
            }
            catch
            {
                throw;
            }
        }

        public string GetPasswordDatabaseOnline()
        {
            string pass = string.Empty;

            try
            {
                dbcommand = db.GetSqlStringCommand("Select dbpass FROM public.ftp");

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbcommand) : db.ExecuteReader(dbcommand, Transaction)))
                {
                    while (DR.Read())
                    {
                        pass = (DR["dbpass"].ToString());
                    }
                }

                return StringCipher.Decrypt(pass, "mechtechforever"); ;
            }
            catch
            {
                throw;
            }
        }
    }
}

