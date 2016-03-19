using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;

using Devart.Data.PostgreSql;

#region MECHTECH
using MechTech.Util;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Data
{
    public class FeriadoDAO : IDados<FeriadoDTO>
    {
        //Database db = DatabaseFactory.CreateDatabase(a);
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance);
        DbCommand dbCommand = null;

        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        /// <summary>
        /// Instância básica para FeriadoDAO.
        /// </summary>
        public FeriadoDAO()
        { }

        /// <summary>
        /// Instância para FeriadoDAO com controle de transação.
        /// </summary>
        public FeriadoDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(FeriadoDTO feriado)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1020, 'Inserido dia " + feriado.Data.ToString() + " - " + feriado.Descricao + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" INSERT INTO public.feriado(" +
                                                           "    id_uf," +
                                                           "    id_municipio," +
                                                           "    descricao," +
                                                           "    tipo," +
                                                           "    especie," +
                                                           "    data," +
                                                           "    observacao, " +
                                                           "    repete, " +
                                                           "    termina, " +
                                                           "    terminaano " +
                                                           ") VALUES (" +
                                                           "    @id_uf," +
                                                           "    @id_municipio," +
                                                           "    @descricao," +
                                                           "    @tipo," +
                                                           "    @especie," +
                                                           "    @data," +
                                                           "    @observacao, " +
                                                           "    @repete, " +
                                                           "    @termina, " +
                                                           "    @terminaano); " +
                                                           " SELECT currval('feriado_id_seq');");
                        if (feriado.UF.Id == 0)
                            db.AddInParameter(dbCommand, "@id_uf", DbType.Int32, Convert.DBNull);
                        else
                            db.AddInParameter(dbCommand, "@id_uf", DbType.Int32, feriado.UF.Id);

                        if (feriado.Municipio.Id == 0)
                            db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, Convert.DBNull);
                        else
                            db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, feriado.Municipio.Id);

                        db.AddInParameter(dbCommand, "@descricao", DbType.String, feriado.Descricao);
                        db.AddInParameter(dbCommand, "@tipo", DbType.String, feriado.Tipo);
                        db.AddInParameter(dbCommand, "@especie", DbType.String, feriado.Especie);
                        db.AddInParameter(dbCommand, "@data", DbType.Date, (DateTime?)feriado.Data);
                        db.AddInParameter(dbCommand, "@observacao", DbType.String, feriado.Observacao);

                        db.AddInParameter(dbCommand, "@repete", DbType.Boolean, feriado.Repete);
                        db.AddInParameter(dbCommand, "@termina", DbType.Boolean, feriado.Termina);
                        db.AddInParameter(dbCommand, "@terminaano", DbType.Int32, feriado.TerminaAno);

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
        public bool Update(FeriadoDTO feriado)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1020, 'Editado dia " + feriado.Data.ToString() + " - " + feriado.Descricao + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" UPDATE public.feriado SET" +
                                                           "    id_uf = @id_uf," +
                                                           "    id_municipio = @id_municipio," +
                                                           "    descricao = @descricao," +
                                                           "    tipo = @tipo," +
                                                           "    especie = @especie," +
                                                           "    data = @data," +
                                                           "    observacao = @observacao, " +
                                                           "    repete = @repete, " +
                                                           "    termina = @termina, " +
                                                           "    terminaano = @terminaano " +
                                                           " WHERE" +
                                                           "    id = @id");
                        db.AddInParameter(dbCommand, "@id", DbType.Int32, feriado.Id);

                        if (feriado.UF.Id == 0)
                            db.AddInParameter(dbCommand, "@id_uf", DbType.Int32, Convert.DBNull);
                        else
                            db.AddInParameter(dbCommand, "@id_uf", DbType.Int32, feriado.UF.Id);

                        if (feriado.Municipio.Id == 0)
                            db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, Convert.DBNull);
                        else
                            db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, feriado.Municipio.Id);

                        db.AddInParameter(dbCommand, "@descricao", DbType.String, feriado.Descricao);
                        db.AddInParameter(dbCommand, "@tipo", DbType.String, feriado.Tipo);
                        db.AddInParameter(dbCommand, "@especie", DbType.String, feriado.Especie);
                        db.AddInParameter(dbCommand, "@data", DbType.Date, (DateTime?)feriado.Data);
                        db.AddInParameter(dbCommand, "@observacao", DbType.String, feriado.Observacao);
                        db.AddInParameter(dbCommand, "@repete", DbType.Boolean, feriado.Repete);
                        db.AddInParameter(dbCommand, "@termina", DbType.Boolean, feriado.Termina);
                        db.AddInParameter(dbCommand, "@terminaano", DbType.Int32, feriado.TerminaAno);

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

        public bool Update(FeriadoDTO feriado, bool repetir)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1020, 'Editado dia " + feriado.Data.ToString() + " - " + feriado.Descricao + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        int terminaano = feriado.Data.Value.Year;
                        FeriadoDTO aux = GetFeriado(feriado.Id);

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" UPDATE public.feriado SET" +
                                                           "    id_uf = @id_uf," +
                                                           "    id_municipio = @id_municipio," +
                                                           "    descricao = @descricao," +
                                                           "    tipo = @tipo," +
                                                           "    especie = @especie," +
                                                           "    observacao = @observacao, " +
                                                           "    data = CAST(EXTRACT(YEAR FROM data) " + "||'-" + feriado.Data.Value.Month + "-" + feriado.Data.Value.Day + "' as DATE) " +
                                                           " WHERE" +
                                                           "    descricao = @desc AND EXTRACT(YEAR FROM data) >= @terminaano");
                        db.AddInParameter(dbCommand, "@desc", DbType.String, aux.Descricao);
                        db.AddInParameter(dbCommand, "@terminaano", DbType.Int32, terminaano);

                        if (feriado.UF.Id == 0)
                            db.AddInParameter(dbCommand, "@id_uf", DbType.Int32, Convert.DBNull);
                        else
                            db.AddInParameter(dbCommand, "@id_uf", DbType.Int32, feriado.UF.Id);

                        if (feriado.Municipio.Id == 0)
                            db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, Convert.DBNull);
                        else
                            db.AddInParameter(dbCommand, "@id_municipio", DbType.Int32, feriado.Municipio.Id);

                        db.AddInParameter(dbCommand, "@descricao", DbType.String, feriado.Descricao);
                        db.AddInParameter(dbCommand, "@tipo", DbType.String, feriado.Tipo);
                        db.AddInParameter(dbCommand, "@especie", DbType.String, feriado.Especie);
                        db.AddInParameter(dbCommand, "@observacao", DbType.String, feriado.Observacao);



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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1020, 'Deletado dia " + Feriado.Data.ToString() + " - " + Feriado.Descricao + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" DELETE FROM public.feriado" +
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



        public bool Delete(FeriadoDTO feriado)
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
                            //db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1020, 'Deletado dia " + feriado.Data.ToString() + " - " + feriado.Descricao + "','" + MechTech.Util.Global.UsuarioAtivo + "');"); 
                        }

                        int terminaano = feriado.Data.Value.Year;


                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" DELETE FROM public.feriado" +
                                                           " WHERE" +
                                                           "    descricao = @descricao AND EXTRACT(YEAR FROM data) >= @terminaano;");
                        db.AddInParameter(dbCommand, "@descricao", DbType.String, feriado.Descricao);
                        db.AddInParameter(dbCommand, "@terminaano", DbType.Int32, terminaano);
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
        /// Retorna um objeto FeriadoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public FeriadoDTO GetFeriado(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetFeriado");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    FeriadoDTO tab = new FeriadoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());

                    UFDTO uf = new UFDTO();
                    if (DR["id_uf"] != Convert.DBNull)
                    {
                        UFDAO ufDAO = new UFDAO();
                        uf.Id = Convert.ToInt32(DR["id_uf"]);
                        uf = ufDAO.GetUF(uf.Id);
                    }
                    tab.UF = uf;

                    MunicipioDTO municipio = new MunicipioDTO();
                    if (DR["id_municipio"] != Convert.DBNull)
                    {
                        MunicipioDAO municipioDAO = new MunicipioDAO();
                        municipio.Id = Convert.ToInt32(DR["id_municipio"]);
                        municipio = municipioDAO.GetMunicipio(municipio.Id);
                    }
                    tab.Municipio = municipio;

                    tab.Descricao = DR["descricao"].ToString();
                    tab.Tipo = DR["tipo"].ToString();
                    tab.Especie = DR["especie"].ToString();
                    if (Convert.IsDBNull(DR["data"]))
                        tab.Data = null;
                    else
                        tab.Data = (DateTime)DR["data"];
                    tab.Observacao = DR["observacao"].ToString();

                    tab.Repete = Convert.ToBoolean(DR["repete"]);
                    tab.Termina = Convert.ToBoolean(DR["termina"]);
                    tab.TerminaAno = Convert.ToInt32(DR["terminaano"]);

                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FeriadoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<FeriadoDTO> GetGridFeriado(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridFeriado");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<FeriadoDTO> List = new List<FeriadoDTO>();
                    while (DR.Read())
                    {
                        FeriadoDTO tab = new FeriadoDTO();
                        tab.Id = int.Parse(DR["id"].ToString());

                        UFDTO uf = new UFDTO();
                        if (DR["id_uf"] != Convert.DBNull)
                        {
                            UFDAO ufDAO = new UFDAO();
                            uf.Id = Convert.ToInt32(DR["id_uf"]);
                            uf = ufDAO.GetUF(uf.Id);
                        }
                        tab.UF = uf;

                        MunicipioDTO municipio = new MunicipioDTO();
                        if (DR["id_municipio"] != Convert.DBNull)
                        {
                            MunicipioDAO municipioDAO = new MunicipioDAO();
                            municipio.Id = Convert.ToInt32(DR["id_municipio"]);
                            municipio = municipioDAO.GetMunicipio(municipio.Id);
                        }
                        tab.Municipio = municipio;

                        tab.Descricao = DR["descricao"].ToString();
                        tab.Tipo = DR["tipo"].ToString();
                        tab.Especie = DR["especie"].ToString();
                        if (Convert.IsDBNull(DR["data"]))
                            tab.Data = null;
                        else
                            tab.Data = (DateTime)DR["data"];
                        tab.Observacao = DR["observacao"].ToString();

                        tab.Repete = Convert.ToBoolean(DR["repete"]);
                        tab.Termina = Convert.ToBoolean(DR["termina"]);
                        tab.TerminaAno = Convert.ToInt32(DR["terminaano"]);

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
        /// </summary>
        public int ObterFeriadosDSR(DateTime datainicial, DateTime datafinal)
        {
            if (datafinal < datainicial)
                return 0;

            int dias = 0;

            foreach (FeriadoDTO umferiado in GetFeriadoPeriodo(datainicial, datafinal, 0, 0))
            {
                if (umferiado.Data.Value.DayOfWeek != DayOfWeek.Sunday)
                    dias++;
            }

            return dias;
        }

        /// <summary>
        /// </summary>
        public int ObterFeriadosDSR(List<DateTime> datas)
        {
            int dias = 0;

            if (datas.Count > 0)
            {
                List<FeriadoDTO> feriados = GetFeriadoPeriodo(datas.First(), datas.Last(), 0, 0);
                foreach (FeriadoDTO umferiado in feriados)
                {
                    if (datas.Exists(delegate(DateTime item) { return item == umferiado.Data.Value; }))
                    {
                        if (umferiado.Data.Value.DayOfWeek != DayOfWeek.Sunday)
                            dias++;
                    }
                }
            }

            return dias;
        }

        /// <summary>
        /// Retorna uma lista de objetos FeriodoDTO definida por período inicial e final
        /// </summary>
        /// <param name="periodoInicial">Data inicial</param>
        /// <param name="periodoFinal">Data final</param>
        /// <param name="idMunicipio">id do municipio que deseja os feriados</param>
        /// <param name="idUF">id do estado que deseja os feriados</param>
        /// <returns>lista de objetos FeriadoDTO</returns>
        public List<FeriadoDTO> GetFeriadoPeriodo(DateTime periodoInicial, DateTime periodoFinal, int idMunicipio, int idUF)
        {
            try
            {
                //*GENERIC IMPLEMENTATION
                EmpresaDTO empresa = null;
                try
                {
                    empresa = new EmpresaDAO().GetEmpresa(Convert.ToInt32(Global.EmpresaAtiva.Replace("emp", string.Empty)));
                }
                catch { }
                //

                dbCommand = db.GetStoredProcCommand("GetFeriadoPeriodo");
                db.AddInParameter(dbCommand, "periodoInicial", DbType.Date, periodoInicial);
                db.AddInParameter(dbCommand, "periodoFinal", DbType.Date, periodoFinal);
                db.AddInParameter(dbCommand, "idMunicipio", DbType.Int32, idMunicipio);
                db.AddInParameter(dbCommand, "iduf", DbType.Int32, idUF);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<FeriadoDTO> List = new List<FeriadoDTO>();
                    while (DR.Read())
                    {
                        FeriadoDTO tab = new FeriadoDTO();
                        tab.Id = int.Parse(DR["id"].ToString());

                        UFDTO uf = new UFDTO();
                        if (DR["id_uf"] != Convert.DBNull)
                        {
                            UFDAO ufDAO = new UFDAO();
                            uf.Id = Convert.ToInt32(DR["id_uf"]);
                            uf = ufDAO.GetUF(uf.Id);
                        }
                        tab.UF = uf;

                        MunicipioDTO municipio = new MunicipioDTO();
                        if (DR["id_municipio"] != Convert.DBNull)
                        {
                            MunicipioDAO municipioDAO = new MunicipioDAO();
                            municipio.Id = Convert.ToInt32(DR["id_municipio"]);
                            municipio = municipioDAO.GetMunicipio(municipio.Id);
                        }
                        tab.Municipio = municipio;

                        tab.Descricao = DR["descricao"].ToString();
                        tab.Tipo = DR["tipo"].ToString();
                        tab.Especie = DR["especie"].ToString();
                        if (Convert.IsDBNull(DR["data"]))
                            tab.Data = null;
                        else
                            tab.Data = (DateTime)DR["data"];
                        tab.Observacao = DR["observacao"].ToString();

                        //*
                        if (empresa != null)
                        {
                            if (tab.UF.Id != 0)
                            {
                                if (tab.UF.Id != empresa.Municipio.UF.Id)
                                    continue;
                            }
                            if (tab.Municipio.Id != 0)
                            {
                                if (tab.Municipio.Id != empresa.Municipio.Id)
                                    continue;
                            }
                        }
                        //

                        if (DR["repete"] != Convert.DBNull)
                            tab.Repete = Convert.ToBoolean(DR["repete"]);
                        if (DR["termina"] != Convert.DBNull)
                            tab.Termina = Convert.ToBoolean(DR["termina"]);
                        if (DR["terminaano"] != Convert.DBNull)
                            tab.TerminaAno = Convert.ToInt32(DR["terminaano"]);

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
        /// Retorna uma lista de datas de feriados
        /// </summary>
        /// <returns>lista de feriados (DateTime)</returns>
        public List<DateTime> GetFeriados()
        {
            try
            {
                dbCommand = db.GetSqlStringCommand("SELECT data FROM feriado;");

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<DateTime> tab = new List<DateTime>();
                    while (DR.Read())
                    {
                        tab.Add(DateTime.Parse(DR["data"].ToString()));
                    }

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
