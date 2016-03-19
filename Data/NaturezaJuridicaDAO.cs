using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Devart.Data.PostgreSql;

using Microsoft.Practices.EnterpriseLibrary.Data;

#region MECHTECH
using MechTech.Entities;
using MechTech.Util;
#endregion

namespace MechTech.Data
{
    public class NaturezaJuridicaDAO
    {
        
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para NaturezajuridicaDAO.
        /// </summary>
        public NaturezaJuridicaDAO()
        { }

        /// <summary>
        /// Retorna um objeto NaturezajuridicaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public NaturezaJuridicaDTO GetNaturezajuridica(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetNaturezajuridica");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    NaturezaJuridicaDTO tab = new NaturezaJuridicaDTO();
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
        /// Retorna uma lista de objetos NaturezajuridicaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<NaturezaJuridicaDTO> GetGridNaturezajuridica(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridNaturezajuridica");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<NaturezaJuridicaDTO> List = new List<NaturezaJuridicaDTO>();
                    while (DR.Read())
                    {
                        NaturezaJuridicaDTO tab = new NaturezaJuridicaDTO();
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
