using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MechTech.Util;

#region DEVART
using Devart.Data.PostgreSql;
#endregion

namespace MechTech.Atualizacao.Data
{
    public class FTPDAO
    {
        Database db;
        DbCommand dbCommand = null;

        public FTPDAO()
        { }

        public FTPDAO(string conexaoString)
        {
            db = new GenericDatabase(conexaoString, PgSqlProviderFactory.Instance);
        }

        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }
        public string GetFTPPass()
        {
            string pass = string.Empty;
            try
            {
                dbCommand = db.GetSqlStringCommand(" SELECT * FROM ftp;");
                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    pass = DR["pass"].ToString();
                    return pass;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
