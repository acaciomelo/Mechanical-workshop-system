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
    public class GPSPagamentoDAO
    {
        
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para GPSpagamentoDAO.
        /// </summary>
        public GPSPagamentoDAO()
        { }

        /// <summary>
        /// Retorna um objeto GPSpagamentoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public GPSPagamentoDTO GetGPSpagamento(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGPSpagamento");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    GPSPagamentoDTO tab = new GPSPagamentoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Descricao = DR["descricao"].ToString();
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
        /// Retorna uma lista de objetos GPSpagamentoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<GPSPagamentoDTO> GetGridGPSpagamento(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridGPSpagamento");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<GPSPagamentoDTO> List = new List<GPSPagamentoDTO>();
                    while (DR.Read())
                    {
                        GPSPagamentoDTO tab = new GPSPagamentoDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Descricao = DR["descricao"].ToString();
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