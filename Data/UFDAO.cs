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
    public class UFDAO
    {
        
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para UFDAO.
        /// </summary>
        public UFDAO()
        { }

        /// <summary>
        /// Retorna um objeto UFDTO para a instrução do conteúdo especificado.
        /// </summary>
        public UFDTO GetUF(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetUF");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    UFDTO tab = new UFDTO();
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
        /// Retorna uma lista de objetos UFDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<UFDTO> GetGridUF(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridUF");
                db.AddInParameter(dbCommand, "Campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "ValorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<UFDTO> List = new List<UFDTO>();
                    while (DR.Read())
                    {
                        UFDTO tab = new UFDTO();
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