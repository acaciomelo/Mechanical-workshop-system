using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

#region DEVART
using Devart.Data.PostgreSql;
#endregion

#region MECHTECH
using MechTech.Entities;
using MechTech.Util;
#endregion

namespace MechTech.Data
{
    public class VincularVeiculoDAO
    {
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance);
        DbCommand dbcommand = null;
        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        public VincularVeiculoDAO()
        {
        }

        public List<VincularVeiculoDTO> GetPlacasCliente(int id)
        {
            List<VincularVeiculoDTO> vinculos = new List<VincularVeiculoDTO>();

            try
            {
                dbcommand = db.GetSqlStringCommand("Select id,placa,id_veiculo FROM public.veiculo_vinc" +
                                    " WHERE" +
                                    " id_cliente = @id;");
                db.AddInParameter(dbcommand, "@id", DbType.Int32, id);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbcommand) : db.ExecuteReader(dbcommand, Transaction)))
                {
                    while (DR.Read())
                    {
                        VincularVeiculoDTO vinculo = new VincularVeiculoDTO();
                        vinculo.Id = int.Parse(DR["id"].ToString());
                        vinculo.Placa = (DR["placa"].ToString());
                        vinculo.Id_Veiculo = int.Parse(DR["id_veiculo"].ToString());
                        vinculo.Veiculo = GetVeiculo(vinculo.Id_Veiculo);
                        vinculos.Add(vinculo);
                    }
                }
                return vinculos;
            }
            catch
            {
                throw;
            }
        }

        public VincularVeiculoDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        public int Insert(VincularVeiculoDTO vinc)
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

                        dbcommand = db.GetSqlStringCommand("Insert Into public.veiculo_vinc(" +
                              " id_cliente," +
                              " id_veiculo," +
                              " placa," +
                              " km,"+
                              " cor,"+
                              " ano,"+
                              " num_chassi,"+
                              " obs,"+
                              " modelo,"+
                              " foto"+
                               ") VALUES (" +
                              " @id_cliente," +
                              " @id_veiculo," +
                              " @placa," +
                              " @km,"+
                              " @cor,"+
                              " @ano,"+
                              " @num_chassi,"+
                              " @obs,"+
                              " @modelo,"+
                              " @foto);"+                     
                               " SELECT currval('veiculo_vinc_id_seq');");

                        db.AddInParameter(dbcommand, "@id_cliente", DbType.Int16, vinc.Id_Cliente);
                        db.AddInParameter(dbcommand, "@id_veiculo", DbType.Int16, vinc.Id_Veiculo);
                        db.AddInParameter(dbcommand, "@placa", DbType.String, vinc.Placa);
                        db.AddInParameter(dbcommand, "@km", DbType.Int32, vinc.Km);
                        db.AddInParameter(dbcommand, "@cor", DbType.String, vinc.Cor);
                        db.AddInParameter(dbcommand, "@ano", DbType.String, vinc.Ano);
                        db.AddInParameter(dbcommand, "@num_chassi", DbType.String, vinc.Num_chassi);
                        db.AddInParameter(dbcommand, "@obs", DbType.String, vinc.Obs);
                        db.AddInParameter(dbcommand, "@modelo", DbType.String, vinc.Modelo);
                        db.AddInParameter(dbcommand, "@foto", DbType.Binary, vinc.Foto);
                       

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

        public bool Update(VincularVeiculoDTO vinc)
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

                        dbcommand = db.GetSqlStringCommand(" UPDATE public.veiculo_vinc SET" +
                                                           "    id_veiculo = @id_veiculo," +
                                                           "    id_cliente = @id_cliente,"+
                                                           "    placa = @placa,"+
                                                           "    km = @km,"+
                                                           "    cor = @cor,"+
                                                           "    ano = @ano,"+
                                                           "    num_chassi = @num_chassi,"+
                                                           "    obs = @obs,"+
                                                           "    modelo = @modelo,"+
                                                           "    foto = @foto" + 
                                                           "    WHERE" +
                                                           "    id = @id");
                        db.AddInParameter(dbcommand, "@id_cliente", DbType.Int16, vinc.Id_Cliente);
                        db.AddInParameter(dbcommand, "@id_veiculo", DbType.Int16, vinc.Id_Veiculo);
                        db.AddInParameter(dbcommand, "@placa", DbType.String, vinc.Placa);
                        db.AddInParameter(dbcommand, "@km", DbType.Int32, vinc.Km);
                        db.AddInParameter(dbcommand, "@cor", DbType.String, vinc.Cor);
                        db.AddInParameter(dbcommand, "@ano", DbType.String, vinc.Ano);
                        db.AddInParameter(dbcommand, "@num_chassi", DbType.String, vinc.Num_chassi);
                        db.AddInParameter(dbcommand, "@obs", DbType.String, vinc.Obs);
                        db.AddInParameter(dbcommand, "@foto", DbType.Binary, vinc.Foto);
                        db.AddInParameter(dbcommand, "@modelo", DbType.String, vinc.Modelo);
                        db.AddInParameter(dbcommand, "@id", DbType.Int16, vinc.Id);


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

                    dbcommand = db.GetSqlStringCommand(" DELETE FROM public.veiculo_vinc" +
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

        public string GetVeiculo(int id)
        {

            try
            {
                dbcommand = db.GetSqlStringCommand(" Select veiculo FROM public.veiculo" +
                                    " WHERE" +
                                    " id = @id;");

                db.AddInParameter(dbcommand, "@id", DbType.Int32, id);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbcommand) : db.ExecuteReader(dbcommand, Transaction)))
                {
                    DR.Read();
                    VeiculoDTO veiculo = new VeiculoDTO();
                    veiculo.Veiculo = DR["veiculo"].ToString();
                    return veiculo.Veiculo;
                }
            }
            catch
            {
                throw;
            }
        }

        public string GetCliente(int id)
        {
            try
            {
                dbcommand = db.GetSqlStringCommand(" Select Nome FROM public.clientes" +
                                    " WHERE" +
                                    " id = @id;");
                db.AddInParameter(dbcommand, "@id", DbType.Int32, id);
                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbcommand) : db.ExecuteReader(dbcommand, Transaction)))
                {
                    DR.Read();
                    VincularVeiculoDTO cliente = new VincularVeiculoDTO();
               
                    cliente.Cliente = DR["nome"].ToString();
                    return cliente.Cliente;
                }
            }
            catch
            {
                throw;
            }
        }

        public int GetIdVeiculo(string veiculo)
        {
            try
            {
                dbcommand = db.GetStoredProcCommand("GetIdVeiculo");
                db.AddInParameter(dbcommand, "@veiculo", DbType.String, veiculo);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbcommand) : db.ExecuteReader(dbcommand, Transaction)))
                {
                    DR.Read();
                    return int.Parse(DR["id"].ToString()); ;
                }
            }

            catch
            {
                throw;
            }
        }

        public VincularVeiculoDTO GetVincularVeiculo(int id)
        {
            try
            {
                dbcommand = db.GetStoredProcCommand("getveiculovincbyidveiculo");
                db.AddInParameter(dbcommand, "@veiculo", DbType.Int32, id);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbcommand) : db.ExecuteReader(dbcommand, Transaction)))
                {
                    DR.Read();
                    VincularVeiculoDTO vinc = new VincularVeiculoDTO();
                    vinc.Id = int.Parse(DR["id"].ToString());
                    vinc.Id_Veiculo = int.Parse(DR["id_veiculo"].ToString());
                    vinc.Veiculo = GetVeiculo(vinc.Id_Veiculo);
                    vinc.Id_Cliente = int.Parse(DR["id_cliente"].ToString());
                    vinc.Cliente = GetCliente(vinc.Id_Cliente);
                    vinc.Placa = DR["placa"].ToString();
                    vinc.Obs = DR["obs"].ToString();
                    vinc.Modelo = DR["modelo"].ToString();
                    vinc.Num_chassi = DR["num_chassi"].ToString();
                    vinc.Km = int.Parse(DR["Km"].ToString());
                    vinc.Ano = DR["ano"].ToString();
                    vinc.Cor = DR["cor"].ToString();
                    vinc.Foto = (Convert.IsDBNull(DR["foto"]) ? null : (byte[])DR["foto"]);
                    return vinc;
                }
            }
            catch
            {
                throw;
            }
        }
        public VincularVeiculoDTO GetVeiculoVinc(int id)
        {
            try
            {
                dbcommand = db.GetStoredProcCommand("GetVeiculoVinc");
                db.AddInParameter(dbcommand, "@veiculo", DbType.Int32,id);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbcommand) : db.ExecuteReader(dbcommand, Transaction)))
                {
                    DR.Read();
                    VincularVeiculoDTO vinc = new VincularVeiculoDTO();
                    vinc.Id = int.Parse(DR["id"].ToString());                                                  
                    vinc.Id_Veiculo = int.Parse(DR["id_veiculo"].ToString());
                    vinc.Veiculo = GetVeiculo(vinc.Id_Veiculo);
                    vinc.Id_Cliente = int.Parse(DR["id_cliente"].ToString());
                    vinc.Cliente = GetCliente(vinc.Id_Cliente);
                    vinc.Placa = DR["placa"].ToString();
                    vinc.Obs = DR["obs"].ToString();
                    vinc.Modelo = DR["modelo"].ToString();
                    vinc.Num_chassi = DR["num_chassi"].ToString();
                    vinc.Km = int.Parse(DR["Km"].ToString());   
                    vinc.Ano = DR["ano"].ToString();
                    vinc.Cor = DR["cor"].ToString();
                    vinc.Foto = (Convert.IsDBNull(DR["foto"]) ? null : (byte[])DR["foto"]);
                    return vinc;
                }
            }
            catch
            {
                throw;
            }
        }

        public List<VincularVeiculoDTO> GetGridVeiculoVinc(string campo, string valorPesquisa)
        {
            try
            {
                dbcommand = db.GetStoredProcCommand("GetGridVeiculoVinc");
                db.AddInParameter(dbcommand, "campo", DbType.String, campo);
                db.AddInParameter(dbcommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbcommand) : db.ExecuteReader(dbcommand, Transaction)))
                {
                    List<VincularVeiculoDTO> list = new List<VincularVeiculoDTO>();
                    while (DR.Read())
                    {
                        VincularVeiculoDTO vinc = new VincularVeiculoDTO();
                        vinc.Id = int.Parse(DR["id"].ToString());
                        vinc.Veiculo = DR["veiculo"].ToString();
                        vinc.Cliente = DR["cliente"].ToString();
                        vinc.Placa   = DR["placa"].ToString();
                     

                        list.Add(vinc);
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
