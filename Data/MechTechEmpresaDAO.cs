using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

#region DEVART
using Devart.Data.PostgreSql;
#endregion

#region MechTech
using MechTech.Entities;
#endregion

namespace MechTech.Data
{
    public class MechTechEmpresaDAO
    {
        GenericDatabase db = null;
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para MechTechEmpresaDAO.
        /// </summary>
        public MechTechEmpresaDAO()
        { }

        /// <summary>
        /// Retorna uma lista de objetos MechTechEmpresaDTO contendo as empresas liberadas para uso.
        /// </summary>
        public List<MechTechEmpresaDTO> GetMechTechEmpresaByID_MechTechAtiva(int id_MechTechativa)
        {
            //    try
            //    {
            //        db = new GenericDatabase("host=www.webpav.com.br;Port=5432;Database=ativacao;User=ativacao;Password=mw1q2w3eE#W@Q!;Unicode=False", PgSqlProviderFactory.Instance);
            //        dbCommand = db.GetSqlStringCommand("SELECT * FROM MechTechempresa" +
            //                                           " WHERE id_MechTechativa = @id_MechTechativa;");
            //        db.AddInParameter(dbCommand, "@id_MechTechativa", DbType.Int32, id_MechTechativa);

            //        using (IDataReader DR = db.ExecuteReader(dbCommand))
            //        {
            //            List<MechTechEmpresaDTO> List = new List<MechTechEmpresaDTO>();
            //            while (DR.Read())
            //            {
            //                MechTechEmpresaDTO tab = new MechTechEmpresaDTO();
            //                tab.Id = int.Parse(DR["id"].ToString());
            //                tab.MechTechAtiva.Id = int.Parse(DR["id_MechTechativa"].ToString());
            //                tab.CNPJ = DR["cnpj"].ToString();
            //                List.Add(tab);
            //            }

            //            //KILL INSTANCE
            //            db = null;

            //            return List;
            //        }
            //    }
            //    catch
            //    {
            //        throw;
            //    }
            List<MechTechEmpresaDTO> List = new List<MechTechEmpresaDTO>();
            return List;
        }
    }
}