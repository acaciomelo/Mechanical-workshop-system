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
    public class SetorDAO : IDados<SetorDTO>
    {
        
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para SetorDAO.
        /// </summary>
        public SetorDAO()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(SetorDTO setor)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" INSERT INTO " + Global.EmpresaAtiva + ".setor(" +
                                                   "    nome," +
                                                   "    codigo" +
                                                   ") VALUES (" +
                                                   "    @nome," +
                                                   "    @codigo);" +
                                                   " SELECT currval('" + Global.EmpresaAtiva + ".setor_id_seq');");
                db.AddInParameter(dbCommand, "@nome", DbType.String, setor.Nome);
                db.AddInParameter(dbCommand, "@codigo", DbType.Int32, setor.Codigo);

                int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
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
        public bool Update(SetorDTO setor)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" UPDATE " + Global.EmpresaAtiva + ".setor SET" +
                                                   "    nome = @nome," +
                                                   "    codigo = @codigo" +
                                                   " WHERE" +
                                                   "    id = @id");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, setor.Id);
                db.AddInParameter(dbCommand, "@nome", DbType.String, setor.Nome);
                db.AddInParameter(dbCommand, "@codigo", DbType.Int32, setor.Codigo);
                db.ExecuteNonQuery(dbCommand);
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
                dbCommand = db.GetSqlStringCommand(" DELETE FROM " + Global.EmpresaAtiva + ".setor" +
                                                   " WHERE" +
                                                   "    id = @id;");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
                db.ExecuteNonQuery(dbCommand);
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto SetorDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SetorDTO GetSetor(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetSetor");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    SetorDTO tab = new SetorDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nome = DR["nome"].ToString();
                    tab.Codigo = int.Parse(DR["codigo"].ToString());
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos SetorDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<SetorDTO> GetGridSetor(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetGridSetor");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<SetorDTO> List = new List<SetorDTO>();
                    while (DR.Read())
                    {
                        SetorDTO tab = new SetorDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nome = DR["nome"].ToString();
                        tab.Codigo = int.Parse(DR["codigo"].ToString());
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
        /// Retorna um objeto SetorDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SetorDTO GetSetorCodigo(int codigo)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetSetorCodigo");
                db.AddInParameter(dbCommand, "@codigo", DbType.Int32, codigo);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    SetorDTO tab = new SetorDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nome = DR["nome"].ToString();
                    tab.Codigo = int.Parse(DR["codigo"].ToString());
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
