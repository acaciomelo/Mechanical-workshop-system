using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

using Devart.Data.PostgreSql;

#region MECHTECH
using MechTech.Util;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Data
{
    public class ClassifTributariaDAO
    {
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        /// <summary>
        /// Instância básica para ClassifTributariaDAO.
        /// </summary>
        public ClassifTributariaDAO()
        { }


        /// <summary>
        /// Retorna uma lista de objetos ClassifTributariaDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<ClassifTributariaDTO> GetGridClassifTributaria(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridClassifTributaria");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    List<ClassifTributariaDTO> List = new List<ClassifTributariaDTO>();
                    while (DR.Read())
                    {
                        ClassifTributariaDTO tab = new ClassifTributariaDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Codigo = DR["codigo"].ToString();
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
