using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;

using Devart.Data.PostgreSql;

#region MechTech
using MechTech.Entities;
using MechTech.Util;
#endregion

namespace MechTech.Data
{
    public class CNAEDAO
    {
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance);
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para CNAEDAO.
        /// </summary>
        public CNAEDAO()
        { }

        /// <summary>
        /// Retorna um objeto CNAEDTO para a instrução do conteúdo especificado.
        /// </summary>
        public CNAEDTO GetCNAE(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetCNAE");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    CNAEDTO tab = new CNAEDTO();
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
        /// Retorna uma lista de objetos CNAEDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<CNAEDTO> GetGridCNAE(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridCNAE");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<CNAEDTO> List = new List<CNAEDTO>();
                    while (DR.Read())
                    {
                        CNAEDTO tab = new CNAEDTO();
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



        /// <summary>
        /// Retorna um objeto CNAEDTO para a instrução do conteúdo especificado.
        /// </summary>
        public CNAEDTO GetCNAE(string codigo)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetCNAE");
                db.AddInParameter(dbCommand, "@codigo", DbType.String, codigo);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    CNAEDTO tab = new CNAEDTO();
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
    }
}
