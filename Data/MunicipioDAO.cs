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
    public class MunicipioDAO : IDados<MunicipioDTO>
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
        /// Instância básica para MunicipioDAO.
        /// </summary>
        public MunicipioDAO()
        { }

        /// <summary>
        /// Instância para MunicipioDAO com controle de transação.
        /// </summary>
        public MunicipioDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(MunicipioDTO municipio)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1133, '','" + Main.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" INSERT INTO public.municipio(" +
                                                           "    nome," +
                                                           "    codigoibge," +
                                                           "    codigosrfb," +
                                                           "    id_uf" +
                                                           ") VALUES (" +
                                                           "    @nome," +
                                                           "    @codigoibge," +
                                                           "    @codigosrfb," +
                                                           "    @id_uf);" +
                                                           " SELECT currval('municipio_id_seq');");
                        db.AddInParameter(dbCommand, "@nome", DbType.String, municipio.Nome);
                        db.AddInParameter(dbCommand, "@codigoibge", DbType.Int32, municipio.Codigoibge);
                        db.AddInParameter(dbCommand, "@codigosrfb", DbType.Int32, municipio.Codigosrfb);
                        db.AddInParameter(dbCommand, "@id_uf", DbType.Int32, municipio.UF.Id);
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
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(MunicipioDTO municipio)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1134, '', '" + Main.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" UPDATE public.municipio SET" +
                                                           "    nome = @nome," +
                                                           "    codigoibge = @codigoibge," +
                                                           "    codigosrfb = @codigosrfb," +
                                                           "    id_uf = @id_uf" +
                                                           " WHERE" +
                                                           "    id = @id");
                        db.AddInParameter(dbCommand, "@id", DbType.Int32, municipio.Id);
                        db.AddInParameter(dbCommand, "@nome", DbType.String, municipio.Nome);
                        db.AddInParameter(dbCommand, "@codigoibge", DbType.Int32, municipio.Codigoibge);
                        db.AddInParameter(dbCommand, "@codigosrfb", DbType.Int32, municipio.Codigosrfb);
                        db.AddInParameter(dbCommand, "@id_uf", DbType.Int32, municipio.UF.Id);
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
        /// Retorna um tipo VERDADEIRO para a instrução do conteúdo especificado, caso contrário FALSO.
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1135, '','" + Main.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" DELETE FROM public.municipio" +
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
        /// Retorna um objeto MunicipioDTO para a instrução do conteúdo especificado.
        /// </summary>
        public MunicipioDTO GetMunicipio(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetMunicipio");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    MunicipioDTO tab = new MunicipioDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nome = DR["nome"].ToString();
                    tab.Codigoibge = int.Parse(DR["codigoibge"].ToString());
                    tab.Codigosrfb = int.Parse(DR["codigosrfb"].ToString());

                    //UF
                    UFDTO uf = new UFDTO();
                    UFDAO ufdata = new UFDAO();
                    uf.Id = Convert.ToInt32(DR["id_uf"]);
                    uf = ufdata.GetUF(uf.Id);
                    tab.UF = uf;
                    //

                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos MunicipioDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<MunicipioDTO> GetGridMunicipio(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridMunicipio");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<MunicipioDTO> List = new List<MunicipioDTO>();
                    while (DR.Read())
                    {
                        MunicipioDTO tab = new MunicipioDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nome = DR["nome"].ToString();
                        tab.Codigoibge = int.Parse(DR["codigoibge"].ToString());

                        //UF
                        UFDTO uf = new UFDTO();
                        uf.Id = Convert.ToInt32(DR["uf_id"]);
                        uf.Codigo = DR["uf_codigo"].ToString();
                        tab.UF = uf;
                        //

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



        /// <summary>
        /// Retorna um objeto MunicipioDTO para a instrução do conteúdo especificado.
        /// </summary>
        public MunicipioDTO GetMunicipioIBGE(int codigoIBGE)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetMunicipioIBGE");
                db.AddInParameter(dbCommand, "@codigoIBGE", DbType.Int32, codigoIBGE);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    MunicipioDTO tab = new MunicipioDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nome = DR["nome"].ToString();
                    tab.Codigoibge = int.Parse(DR["codigoibge"].ToString());
                    tab.Codigosrfb = int.Parse(DR["codigosrfb"].ToString());

                    //UF
                    UFDTO uf = new UFDTO();
                    UFDAO ufdata = new UFDAO();
                    uf.Id = Convert.ToInt32(DR["id_uf"]);
                    uf = ufdata.GetUF(uf.Id);
                    tab.UF = uf;
                    //

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