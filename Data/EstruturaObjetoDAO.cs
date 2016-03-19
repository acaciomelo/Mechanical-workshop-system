using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;

using Devart.Data.PostgreSql;

#region MECHTECH
using MechTech.Util;
using MechTech.Entities;
#endregion

namespace MechTech.Data
{
    public class EstruturaObjetoDAO
    {
        //Database db = DatabaseFactory.CreateDatabase(); //37959
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); //37959
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para EstruturaObjetoDAO.
        /// </summary>
        public EstruturaObjetoDAO()
        { }

        /// <summary>
        /// Retorna uma lista de objetos EstruturaObjetoDTO.
        /// </summary>
        public List<EstruturaObjetoDTO> GetListAll()
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetListAllEstruturaObjeto");

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<EstruturaObjetoDTO> List = new List<EstruturaObjetoDTO>();
                    while (DR.Read())
                    {
                        EstruturaObjetoDTO tab = new EstruturaObjetoDTO();
                        tab.Id_estruturatabela = int.Parse(DR["id_estruturatabela"].ToString());
                        tab.Nomeobjeto = DR["nomeobjeto"].ToString();
                        tab.Descricao = DR["descricao"].ToString();
                        tab.DDL = DR["DDL"].ToString();
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
        /// Retorna uma lista de objetos EstruturaObjetoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<EstruturaObjetoDTO> GetListEstruturaObjetoByFK(int id_estruturatabela)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetListEstruturaObjetoByFK");
                db.AddInParameter(dbCommand, "@id_estruturatabela", DbType.Int32, id_estruturatabela);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<EstruturaObjetoDTO> List = new List<EstruturaObjetoDTO>();
                    while (DR.Read())
                    {
                        EstruturaObjetoDTO tab = new EstruturaObjetoDTO();
                        tab.Id_estruturatabela = int.Parse(DR["id_estruturatabela"].ToString());
                        tab.Nomeobjeto = DR["nomeobjeto"].ToString();
                        tab.Descricao = DR["descricao"].ToString();
                        tab.DDL = DR["DDL"].ToString();
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
        /// Cria objetos de acordo com a instrução especificada.
        /// </summary>
        /// <param name="objects">Objeto(s) a ser(em) criado(s)</param>
        public void Create(List<EstruturaObjetoDTO> objects)
        {
            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                    try
                    {
                        foreach (EstruturaObjetoDTO estrutura in objects)
                        {
                            string DDL = estrutura.DDL.Replace("[empresa]", Global.EmpresaAtiva);
                            dbCommand = db.GetSqlStringCommand(DDL);

                            db.ExecuteNonQuery(dbCommand, transaction);
                        }
                        transaction.Commit();
                        connection.Close();
                    }
                    catch (DbException dbex)
                    {
                        transaction.Rollback();
                        connection.Close();
                        throw dbex;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}