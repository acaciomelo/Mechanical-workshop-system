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
using MechTech.Util;
#endregion

namespace MechTech.Data
{
    public class VeiculoDAO
    {
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance);
        DbCommand dbcommand = null;
        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        public VeiculoDAO()
        {
        }

        public VeiculoDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }


        public int Insert(VeiculoDTO veiculo)
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

                        dbcommand = db.GetSqlStringCommand("Insert Into public.veiculo(" +
                              " veiculo," +
                              " tipo," +
                              " id_marca" +
                               ") VALUES (" +
                               " @veiculo," +
                               " @tipo," +
                               " @id_marca);" +
                               " SELECT currval('veiculo_id_seq');");

                        db.AddInParameter(dbcommand, "@veiculo", DbType.String, veiculo.Veiculo);
                        db.AddInParameter(dbcommand, "@id_marca", DbType.Int16, veiculo.Id_Marca);
                        db.AddInParameter(dbcommand, "@tipo", DbType.Int16, veiculo.Tipo);

                        int id = Convert.ToInt32(db.ExecuteScalar(dbcommand, Transaction));

                        if (transactionstart)
                        {
                            Transaction.Commit();
                            Transaction = null;
                        }
                        connection.Close();
                        return id;
                    }

                    catch (DbException dbex)
                    {
                        if (Transaction != null)
                            Transaction.Rollback();
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        Dispose();
                        throw dbex;
                    }
                }
            }

            catch
            {
                throw;
            }
        }


        public bool Update(VeiculoDTO veiculo)
        {
            Transaction = null;
            DbConnection connection = null;
            bool transactionstart = false;

            try
            {
                using (connection = db.CreateConnection())
                {
                    try
                    {
                        connection.Open();
                        if (Transaction == null)
                        {
                            Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                            transactionstart = true;
                        }

                        dbcommand = db.GetSqlStringCommand(" UPDATE public.veiculo SET" +
                                                           "    veiculo = @veiculo," +
                                                           "    tipo = @tipo," +
                                                           "    id_marca = @id_marca" +
                                                           "    WHERE" +
                                                           "     id = @id");
                        db.AddInParameter(dbcommand, "@veiculo", DbType.String, veiculo.Veiculo);
                        db.AddInParameter(dbcommand, "@id_marca", DbType.Int16, veiculo.Id_Marca);
                        db.AddInParameter(dbcommand, "@tipo", DbType.Int16, veiculo.Tipo);
                        db.AddInParameter(dbcommand, "@id", DbType.Int16, veiculo.Id);

                        db.ExecuteNonQuery(dbcommand, Transaction);

                        if (transactionstart)
                        {
                            Transaction.Commit();
                            Transaction = null;
                        }
                        connection.Close();
                        return true;
                    }

                    catch
                    {
                        throw;
                    }
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
                    }

                    dbcommand = db.GetSqlStringCommand(" DELETE FROM public.veiculo" +
                                                       " WHERE" +
                                                       " id = @id;");

                    db.AddInParameter(dbcommand, "@id", DbType.Int32, id);
                    db.ExecuteNonQuery(dbcommand, Transaction);

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

        public VeiculoDTO GetVeiculo(int id)
        {
            try
            {
                dbcommand = db.GetStoredProcCommand("GetVeiculo");
                db.AddInParameter(dbcommand, "@id", DbType.Int32, id);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbcommand) : db.ExecuteReader(dbcommand, Transaction)))
                {
                    DR.Read();
                    VeiculoDTO veiculo = new VeiculoDTO();
                    veiculo.Id = int.Parse(DR["id"].ToString());
                    veiculo.Veiculo = DR["veiculo"].ToString();
                    veiculo.Id_Marca = int.Parse(DR["id_marca"].ToString());
                    veiculo.Tipo = int.Parse(DR["tipo"].ToString());
                    return veiculo;
                }
            }
            catch
            {
                throw;
            }
        }

        public List<VeiculoDTO> GetGridVeiculo(string campo, string valorPesquisa)
        {
            try
            {

                dbcommand = db.GetStoredProcCommand("GetGridVeiculo");
                db.AddInParameter(dbcommand, "campo", DbType.String, campo);
                db.AddInParameter(dbcommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbcommand) : db.ExecuteReader(dbcommand, Transaction)))
                {
                    List<VeiculoDTO> list = new List<VeiculoDTO>();
                    while (DR.Read())
                    {
                        VeiculoDTO veiculo = new VeiculoDTO();
                        veiculo.Id = int.Parse(DR["id"].ToString());
                        veiculo.Veiculo = DR["veiculo"].ToString();
                        veiculo.Id_Marca = int.Parse(DR["id_marca"].ToString());
                        veiculo.Tipo = int.Parse(DR["tipo"].ToString());
                        veiculo.Desc_marca = Veiculo.ObterMarcasVeiculos(veiculo.Id_Marca, veiculo.Tipo).Descricao;
                        veiculo.Descr_tipo = Veiculo.ObterTipo(veiculo.Tipo).Descricao;

                        list.Add(veiculo);
                    }

                    return list;
                }
            }
            catch
            {
                throw;
            }

        }

        public void Dispose()
        {
            Transaction = null;
        }
    }
}
