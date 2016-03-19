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
    public class PorteDAO
    {
        
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para PorteDAO.
        /// </summary>
        public PorteDAO()
        { }

        /// <summary>
        /// Retorna um objeto PorteDTO caso a instrução seja bem sucedida.
        /// </summary>
        public PorteDTO GetPorte(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetPorte");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    PorteDTO tab = new PorteDTO();
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
        /// Retorna uma lista de objetos PorteDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<PorteDTO> GetGridPorte(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridPorte");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<PorteDTO> List = new List<PorteDTO>();
                    while (DR.Read())
                    {
                        PorteDTO tab = new PorteDTO();
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