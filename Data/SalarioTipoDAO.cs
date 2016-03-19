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
    public class SalarioTipoDAO
    {
        
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para SalariotipoDAO.
        /// </summary>
        public SalarioTipoDAO()
        { }

        /// <summary>
        /// Retorna um objeto SalariotipoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SalarioTipoDTO GetSalariotipo(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetSalariotipo");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    SalarioTipoDTO tab = new SalarioTipoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Descricao = DR["descricao"].ToString();
                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos SalariotipoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<SalarioTipoDTO> GetGridSalariotipo(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridSalariotipo");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<SalarioTipoDTO> List = new List<SalarioTipoDTO>();
                    while (DR.Read())
                    {
                        SalarioTipoDTO tab = new SalarioTipoDTO();
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



    }
}