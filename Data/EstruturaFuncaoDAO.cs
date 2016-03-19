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
    public class EstruturaFuncaoDAO
    {
        //Database db = DatabaseFactory.CreateDatabase(); //37959
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); //37959
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para EstruturaFuncaoDAO.
        /// </summary>
        public EstruturaFuncaoDAO()
        { }

        /// <summary>
        /// Retorna uma lista de objetos EstruturaFuncaoDTO.
        /// </summary>
        public List<EstruturaFuncaoDTO> GetListAll()
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetListAllEstruturaFuncao");

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<EstruturaFuncaoDTO> List = new List<EstruturaFuncaoDTO>();
                    while (DR.Read())
                    {
                        EstruturaFuncaoDTO tab = new EstruturaFuncaoDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nomefuncao = DR["nomefuncao"].ToString();
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
        /// Cria todas as funções para o Banco de dados.
        /// </summary>
        public void Create()
        {
            try
            {
                List<EstruturaFuncaoDTO> tables = this.GetListAll();
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                    try
                    {
                        foreach (EstruturaFuncaoDTO estrutura in tables)
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

        /// <summary>
        /// Cria funções de acordo com a instrução especificada.
        /// </summary>
        /// <param name="functions">Função(ões) a ser(em) criada(s)</param>
        public void Create(List<EstruturaFuncaoDTO> functions)
        {
            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                    try
                    {
                        foreach (EstruturaFuncaoDTO estrutura in functions)
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