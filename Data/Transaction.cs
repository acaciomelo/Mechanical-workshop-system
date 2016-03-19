using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Devart.Data.PostgreSql;
using MechTech.Util;

namespace MechTech.Data
{
    public class Transaction
    {
        private static Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); //37959
        private static DbConnection connection = null;

        private static DbTransaction dbtransaction = null;
        public static DbTransaction DBTransaction
        {
            get { return Transaction.dbtransaction; }
            set { Transaction.dbtransaction = value; }
        }

        public static void Start()
        {
            try
            {
                connection = db.CreateConnection();
                connection.Open();
                DBTransaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
            }
            catch { }
        }

        public static void Stop(bool commited)
        {
            try
            {
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        if (commited)
                            DBTransaction.Commit();
                        else
                            DBTransaction.Rollback();
                        DBTransaction = null;
                        connection.Close();
                    }
                }
            }
            catch
            {
                if (DBTransaction != null)
                {
                    DBTransaction.Rollback();
                    DBTransaction = null;
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
        }
    }
}