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
    public class FAPDAO
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
        /// Instância básica para FAPDAO.
        /// </summary>
        public FAPDAO()
        { }

        /// <summary>
        /// Instância para FAPDAO com controle de transação.
        /// </summary>
        public FAPDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(FAPDTO fap)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" INSERT INTO public.fap(" +
                                                   " id_empresa," +
                                                   " mesano," +
                                                   " percentualrat," +
                                                   " percentualfap," +
                                                   " aliquota" +
                                                   ") VALUES (" +
                                                   " @id_empresa," +
                                                   " @mesano," +
                                                   " @percentualrat," +
                                                   " @percentualfap," +
                                                   " @aliquota);" +
                                                   " SELECT currval('fap_id_seq');");
                db.AddInParameter(dbCommand, "@id_empresa", DbType.Int32, fap.ID_Empresa);
                db.AddInParameter(dbCommand, "@mesano", DbType.Date, new DateTime(fap.MesAno.Year, fap.MesAno.Month, 1));
                db.AddInParameter(dbCommand, "@percentualrat", DbType.Decimal, fap.PercentualRAT);
                db.AddInParameter(dbCommand, "@percentualfap", DbType.Decimal, fap.PercentualFAP);
                db.AddInParameter(dbCommand, "@aliquota", DbType.Decimal, fap.Aliquota);
                int id = Convert.ToInt32(db.ExecuteScalar(dbCommand, Transaction));
                return id;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Atualização de Módulos.
        /// </summary>
        public void Insert2(FAPDTO fap)
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
                        db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(2, '', '" + MechTech.Util.Global.UsuarioAtivo + "');");
                    }

                    dbCommand = db.GetSqlStringCommand(" INSERT INTO public.fap(" +
                                                       " id_empresa," +
                                                       " mesano," +
                                                       " percentualrat," +
                                                       " percentualfap," +
                                                       " aliquota" +
                                                       ") VALUES (" +
                                                       " @id_empresa," +
                                                       " @mesano," +
                                                       " @percentualrat," +
                                                       " @percentualfap," +
                                                       " @aliquota);" +
                                                       " SELECT currval('fap_id_seq');");
                    db.AddInParameter(dbCommand, "@id_empresa", DbType.Int32, fap.ID_Empresa);
                    db.AddInParameter(dbCommand, "@mesano", DbType.Date, (DateTime?)fap.MesAno);
                    db.AddInParameter(dbCommand, "@percentualrat", DbType.Decimal, fap.PercentualRAT);
                    db.AddInParameter(dbCommand, "@percentualfap", DbType.Decimal, fap.PercentualFAP);
                    db.AddInParameter(dbCommand, "@aliquota", DbType.Decimal, fap.Aliquota);
                    db.ExecuteNonQuery(dbCommand, Transaction);

                    if (transactionstart)
                    {
                        Transaction.Commit();
                        Transaction = null;
                    }
                    connection.Close();
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
        public bool Delete(int id_empresa)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" DELETE FROM public.fap" +
                                                   " WHERE" +
                                                   " id_empresa = @id_empresa;");
                db.AddInParameter(dbCommand, "@id_empresa", DbType.Int32, id_empresa);
                db.ExecuteNonQuery(dbCommand, Transaction);
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Current FAP.
        /// </summary>
        public decimal GetFAP(int id_empresa, DateTime mesano)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetFAP");
                db.AddInParameter(dbCommand, "@id_empresa", DbType.Int32, id_empresa);
                db.AddInParameter(dbCommand, "@mesano", DbType.Date, mesano);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    DR.Read();
                    return decimal.Parse(DR["aliquota"].ToString());
                }
            }
            catch
            {
                return 0;
            }
        }

        public decimal GetFAPPeriodo(int id_empresa, DateTime mesanoinicial, DateTime mesanofinal) //34568
        {
            try
            {
                using (dbCommand = db.GetStoredProcCommand("GetFAPperiodo"))
                {
                    db.AddInParameter(dbCommand, "@id_empresa", DbType.Int32, id_empresa);
                    db.AddInParameter(dbCommand, "@mesanoinicial", DbType.Date, mesanoinicial);
                    db.AddInParameter(dbCommand, "@mesanofinal", DbType.Date, mesanofinal);
                    db.AddOutParameter(dbCommand, "return_value", DbType.Decimal, 1);
                    db.ExecuteScalar(dbCommand);
                    DbParameter retorno = dbCommand.Parameters["return_value"];
                    return (decimal)retorno.Value;
                }

            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FAPDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FAPDTO> GetListFAP(int id_empresa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetListFAP");
                db.AddInParameter(dbCommand, "@id_empresa", DbType.Int32, id_empresa);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    List<FAPDTO> List = new List<FAPDTO>();
                    while (DR.Read())
                    {
                        FAPDTO tab = new FAPDTO();
                        tab.ID = int.Parse(DR["id"].ToString());
                        tab.ID_Empresa = int.Parse(DR["id_empresa"].ToString());
                        tab.MesAno = (DateTime)DR["mesano"];
                        tab.PercentualRAT = decimal.Parse(DR["percentualrat"].ToString());
                        tab.PercentualFAP = decimal.Parse(DR["percentualfap"].ToString());
                        tab.Aliquota = decimal.Parse(DR["aliquota"].ToString());
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