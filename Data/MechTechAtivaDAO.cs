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
    public class MechTechAtivaDAO
    {
        GenericDatabase db = null;
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para MechTechAtivaDAO.
        /// </summary>
        public MechTechAtivaDAO()
        { }

        /// <summary>
        /// Retorna um objeto MechTechAtivaDTO contendo a licença de ativação liberada.
        /// </summary>
        /// <param name="filial">Filial liberada</param>
        public MechTechAtivaDTO GetMechTechAtivaByFilial(int filial)
        {
            MechTechAtivaDTO tab = new MechTechAtivaDTO();
            return tab;
            //try
            //{
            //    db = new GenericDatabase("host=www.webpav.com.br;Port=5432;Database=ativacao;User=ativacao;Password=mw1q2w3eE#W@Q!;Unicode=False", PgSqlProviderFactory.Instance);
            //    dbCommand = db.GetSqlStringCommand("SELECT * FROM MechTechativa" +
            //                                       " WHERE filial = @filial;");
            //    db.AddInParameter(dbCommand, "@filial", DbType.Int32, filial);

            //    using (IDataReader DR = db.ExecuteReader(dbCommand))
            //    {
            //        DR.Read();
            //        MechTechAtivaDTO tab = new MechTechAtivaDTO();
            //        tab.Id = int.Parse(DR["id"].ToString());
            //        tab.Filial = int.Parse(DR["filial"].ToString());
            //        tab.Licenca = DR["licenca"].ToString();

            //        //KILL INSTANCE
            //        db = null;

            //        return tab;
            //    }
            //}
            //catch
            //{
            //    throw;
            //}
        }
    }
}