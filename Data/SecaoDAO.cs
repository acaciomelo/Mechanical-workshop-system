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
    public class SecaoDAO : IDados<SecaoDTO>
    {
        
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para SecaoDAO.
        /// </summary>
        public SecaoDAO()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(SecaoDTO secao)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" INSERT INTO " + Global.EmpresaAtiva + ".secao(" +
                                                   "    nome," +
                                                   "    codigo" +
                                                   ") VALUES (" +
                                                   "    @nome," +
                                                   "    @codigo);" +
                                                   " SELECT currval('" + Global.EmpresaAtiva + ".secao_id_seq');");
                db.AddInParameter(dbCommand, "@nome", DbType.String, secao.Nome);
                db.AddInParameter(dbCommand, "@codigo", DbType.Int32, secao.Codigo);

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
        public bool Update(SecaoDTO secao)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" UPDATE " + Global.EmpresaAtiva + ".secao SET" +
                                                   "    nome = @nome," +
                                                   "    codigo = @codigo" +
                                                   " WHERE" +
                                                   "    id = @id");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, secao.Id);
                db.AddInParameter(dbCommand, "@nome", DbType.String, secao.Nome);
                db.AddInParameter(dbCommand, "@codigo", DbType.Int32, secao.Codigo);
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
                dbCommand = db.GetSqlStringCommand(" DELETE FROM " + Global.EmpresaAtiva + ".secao" +
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
        /// Retorna um objeto SecaoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SecaoDTO GetSecao(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetSecao");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    SecaoDTO tab = new SecaoDTO();
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
        /// Retorna uma lista de objetos SecaoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<SecaoDTO> GetGridSecao(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetGridSecao");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<SecaoDTO> List = new List<SecaoDTO>();
                    while (DR.Read())
                    {
                        SecaoDTO tab = new SecaoDTO();
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
        /// Retorna um objeto SecaoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SecaoDTO GetSecaoCodigo(int codigo)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetSecaoCodigo");
                db.AddInParameter(dbCommand, "@codigo", DbType.Int32, codigo);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    SecaoDTO tab = new SecaoDTO();
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