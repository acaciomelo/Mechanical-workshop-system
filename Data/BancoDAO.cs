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
    public class BancoDAO : IDados<BancoDTO>
    {
        
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para BancoDAO.
        /// </summary>
        public BancoDAO()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(BancoDTO banco)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" INSERT INTO public.banco(" +
                                                   "    nome," +
                                                   "    codigo" +
                                                   ") VALUES (" +
                                                   "    @nome," +
                                                   "    @codigo);" +
                                                   " SELECT currval('banco_id_seq');");
                db.AddInParameter(dbCommand, "@nome", DbType.String, banco.Nome);
                db.AddInParameter(dbCommand, "@codigo", DbType.String, banco.Codigo);

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
        public bool Update(BancoDTO banco)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" UPDATE public.banco SET" +
                                                   "    nome = @nome," +
                                                   "    codigo = @codigo" +
                                                   " WHERE" +
                                                   "    id = @id");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, banco.Id);
                db.AddInParameter(dbCommand, "@nome", DbType.String, banco.Nome);
                db.AddInParameter(dbCommand, "@codigo", DbType.String, banco.Codigo);
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
                dbCommand = db.GetSqlStringCommand(" DELETE FROM public.banco" +
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
        /// Retorna um objeto BancoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public BancoDTO GetBanco(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetBanco");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    BancoDTO tab = new BancoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nome = DR["nome"].ToString();
                    tab.Codigo = DR["codigo"].ToString();
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos BancoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<BancoDTO> GetGridBanco(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridBanco");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<BancoDTO> List = new List<BancoDTO>();
                    while (DR.Read())
                    {
                        BancoDTO tab = new BancoDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nome = DR["nome"].ToString();
                        tab.Codigo = DR["codigo"].ToString();
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