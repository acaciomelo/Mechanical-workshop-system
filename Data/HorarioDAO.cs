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
    public class HorarioDAO : IDados<HorarioDTO>
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
        /// Instância básica para HorarioDAO.
        /// </summary>
        public HorarioDAO()
        { }

        /// <summary>
        /// Instância para HorarioDAO com controle de transação.
        /// </summary>
        public HorarioDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(HorarioDTO horario)
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
                            db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1138, 'Horário: " + horario.Descricao + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" INSERT INTO " + Global.EmpresaAtiva + ".horario(" +
                                                           "    descricao" +
                                                           ") VALUES (" +
                                                           "    @descricao);" +
                                                           " SELECT currval('" + Global.EmpresaAtiva + ".horario_id_seq');");
                        db.AddInParameter(dbCommand, "@descricao", DbType.String, horario.Descricao);
                        int id = Convert.ToInt32(db.ExecuteScalar(dbCommand, Transaction));
                        PersisteListas(horario, id);
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
        public bool Update(HorarioDTO horario)
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
                            db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1139, 'Horário: " + horario.Descricao + "','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" UPDATE " + Global.EmpresaAtiva + ".horario SET" +
                                                           "    descricao = @descricao" +
                                                           " WHERE" +
                                                           "    id = @id");
                        db.AddInParameter(dbCommand, "@id", DbType.Int32, horario.Id);
                        db.AddInParameter(dbCommand, "@descricao", DbType.String, horario.Descricao);
                        db.ExecuteNonQuery(dbCommand, Transaction);
                        PersisteListas(horario, horario.Id);
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
                            db.ExecuteNonQuery(Transaction, CommandType.Text, "SELECT GravaLOG_App(1140, '','" + MechTech.Util.Global.UsuarioAtivo + "');");
                        }

                        //ROTINA
                        dbCommand = db.GetSqlStringCommand(" DELETE FROM " + Global.EmpresaAtiva + ".horario" +
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
        /// Retorna um objeto HorarioDTO para a instrução do conteúdo especificado.
        /// </summary>
        public HorarioDTO GetHorario(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetHorario");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    HorarioDTO tab = new HorarioDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Descricao = DR["descricao"].ToString();

                    //LOCALIZAR HORÁRIOS DA SEMANA
                    tab.Horariosemana = new HorarioSemanaDAO().GetHorariosemanaHorario(tab.Id);

                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos HorarioDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<HorarioDTO> GetGridHorario(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetGridHorario");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<HorarioDTO> List = new List<HorarioDTO>();
                    while (DR.Read())
                    {
                        HorarioDTO tab = new HorarioDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Descricao = DR["descricao"].ToString();
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
        /// Método responsável pela persistência das listas agregadas a classe HorarioDTO.
        /// </summary>
        /// <param name="Horario">Objeto do tipo HorarioDTO gerado na camada de apresentação</param>
        /// <param name="id_horario">Chave primária do horário gerada no Banco de dados</param>
        private void PersisteListas(HorarioDTO Horario, int id_horario)
        {
            //TABELA HORARIOSEMANA
            HorarioSemanaDAO horariosemanadata = new HorarioSemanaDAO(Transaction);
            if (horariosemanadata.DeleteHorario(id_horario))
            {
                foreach (HorarioSemanaDTO itemhorario in Horario.Horariosemana)
                {
                    itemhorario.Id_horario = id_horario;
                    horariosemanadata.Insert(itemhorario);
                }
            }
        }
    }
}
