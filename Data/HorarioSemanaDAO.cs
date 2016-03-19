using System;
using System.Collections.Generic;
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
    public class HorarioSemanaDAO : IDados<HorarioSemanaDTO>
    {
        
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        private DbTransaction transaction;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        /// <summary>
        /// Instância básica para HorarioSemanaDAO.
        /// </summary>
        public HorarioSemanaDAO()
        { }

        /// <summary>
        /// Instância para HorarioSemanaDAO com controle de transação.
        /// </summary>
        public HorarioSemanaDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(HorarioSemanaDTO horariosemana)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" INSERT INTO " + Global.EmpresaAtiva + ".horariosemana(" +
                                                   "    id_horario," +
                                                   "    diadasemana," +
                                                   "    entradapp," +
                                                   "    saidapp," +
                                                   "    entradasp," +
                                                   "    saidasp" +
                                                   ") VALUES (" +
                                                   "    @id_horario," +
                                                   "    @diadasemana," +
                                                   "    @entradapp," +
                                                   "    @saidapp," +
                                                   "    @entradasp," +
                                                   "    @saidasp);" +
                                                   " SELECT currval('" + Global.EmpresaAtiva + ".horariosemana_id_seq');");
                db.AddInParameter(dbCommand, "@id_horario", DbType.Int32, horariosemana.Id_horario);
                db.AddInParameter(dbCommand, "@diadasemana", DbType.Int32, horariosemana.Diadasemana);
                db.AddInParameter(dbCommand, "@entradapp", DbType.Time, TimeSpan.Parse(horariosemana.Entradapp.ToString("HH:mm")));
                db.AddInParameter(dbCommand, "@saidapp", DbType.Time, TimeSpan.Parse(horariosemana.Saidapp.ToString("HH:mm")));
                db.AddInParameter(dbCommand, "@entradasp", DbType.Time, TimeSpan.Parse(horariosemana.Entradasp.ToString("HH:mm")));
                db.AddInParameter(dbCommand, "@saidasp", DbType.Time, TimeSpan.Parse(horariosemana.Saidasp.ToString("HH:mm")));
                int id = Convert.ToInt32(db.ExecuteScalar(dbCommand, Transaction));
                return id;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(HorarioSemanaDTO horariosemana)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" UPDATE " + Global.EmpresaAtiva + ".horariosemana SET" +
                                                   "    id_horario = @id_horario," +
                                                   "    diadasemana = @diadasemana," +
                                                   "    entradapp = @entradapp," +
                                                   "    saidapp = @saidapp," +
                                                   "    entradasp = @entradasp," +
                                                   "    saidasp = @saidasp" +
                                                   " WHERE" +
                                                   "    id = @id");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, horariosemana.Id);
                db.AddInParameter(dbCommand, "@id_horario", DbType.Int32, horariosemana.Id_horario);
                db.AddInParameter(dbCommand, "@diadasemana", DbType.Int32, horariosemana.Diadasemana);
                db.AddInParameter(dbCommand, "@entradapp", DbType.Time, TimeSpan.Parse(horariosemana.Entradapp.ToString("HH:mm")));
                db.AddInParameter(dbCommand, "@saidapp", DbType.Time, TimeSpan.Parse(horariosemana.Saidapp.ToString("HH:mm")));
                db.AddInParameter(dbCommand, "@entradasp", DbType.Time, TimeSpan.Parse(horariosemana.Entradasp.ToString("HH:mm")));
                db.AddInParameter(dbCommand, "@saidasp", DbType.Time, TimeSpan.Parse(horariosemana.Saidasp.ToString("HH:mm")));
                db.ExecuteNonQuery(dbCommand, Transaction);
                return true;
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
                dbCommand = db.GetSqlStringCommand(" DELETE FROM " + Global.EmpresaAtiva + ".horariosemana" +
                                                   " WHERE" +
                                                   "    id = @id;");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
                db.ExecuteNonQuery(dbCommand, Transaction);
                return true;
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// Retorna uma lista de objetos HorariosemanaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<HorarioSemanaDTO> GetHorariosemanaHorario(int id_horario)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetHorariosemanaHorario");
                db.AddInParameter(dbCommand, "@id_horario", DbType.Int32, id_horario);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<HorarioSemanaDTO> List = new List<HorarioSemanaDTO>();
                    while (DR.Read())
                    {
                        HorarioSemanaDTO tab = new HorarioSemanaDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Id_horario = int.Parse(DR["id_horario"].ToString());
                        tab.Diadasemana = int.Parse(DR["diadasemana"].ToString());
                        tab.Entradapp = Convert.ToDateTime("01/01/1900 " + DR["entradapp"].ToString());
                        tab.Saidapp = Convert.ToDateTime("01/01/1900 " + DR["saidapp"].ToString());
                        tab.Entradasp = Convert.ToDateTime("01/01/1900 " + DR["entradasp"].ToString());
                        tab.Saidasp = Convert.ToDateTime("01/01/1900 " + DR["saidasp"].ToString());
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
        /// Retorna um tipo VERDADEIRO para a instrução do conteúdo especificado, caso contrário FALSO.
        /// </summary>
        public bool DeleteHorario(int id_horario)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" DELETE FROM " + Global.EmpresaAtiva + ".horariosemana" +
                                                   " WHERE" +
                                                   "    id_horario = @id_horario;");
                db.AddInParameter(dbCommand, "@id_horario", DbType.Int32, id_horario);
                db.ExecuteNonQuery(dbCommand, Transaction);
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos HorariosemanaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<HorarioSemanaDTO> GetHorarioSemanaFuncionario(int id_funcionario)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetHorariosemanaFuncionario");
                db.AddInParameter(dbCommand, "@id_func", DbType.Int32, id_funcionario);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<HorarioSemanaDTO> List = new List<HorarioSemanaDTO>();
                    while (DR.Read())
                    {
                        HorarioSemanaDTO tab = new HorarioSemanaDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Id_horario = int.Parse(DR["id_horario"].ToString());
                        tab.Diadasemana = int.Parse(DR["diadasemana"].ToString());
                        tab.Entradapp = Convert.ToDateTime("01/01/1900 " + DR["entradapp"].ToString());
                        tab.Saidapp = Convert.ToDateTime("01/01/1900 " + DR["saidapp"].ToString());
                        tab.Entradasp = Convert.ToDateTime("01/01/1900 " + DR["entradasp"].ToString());
                        tab.Saidasp = Convert.ToDateTime("01/01/1900 " + DR["saidasp"].ToString());
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