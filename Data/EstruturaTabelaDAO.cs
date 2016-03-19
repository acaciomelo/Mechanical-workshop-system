using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;

using Devart.Data.PostgreSql;

#region MECHTECH
using MechTech.Util;
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Data
{
    public class EstruturaTabelaDAO
    {
        //Database db = DatabaseFactory.CreateDatabase(); //37959
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); //37959
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para EstruturaTabelaDAO.
        /// </summary>
        public EstruturaTabelaDAO()
        { }

        /// <summary>
        /// Retorna uma lista de objetos EstruturaTabelaDTO.
        /// </summary>
        public List<EstruturaTabelaDTO> GetListAll()
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetListAllEstruturaTabela");

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    EstruturaObjetoDAO objetos = new EstruturaObjetoDAO();
                    List<EstruturaTabelaDTO> List = new List<EstruturaTabelaDTO>();
                    while (DR.Read())
                    {
                        EstruturaTabelaDTO tab = new EstruturaTabelaDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Nometabela = DR["nometabela"].ToString();
                        tab.Descricao = DR["descricao"].ToString();
                        tab.DDL = DR["DDL"].ToString();
                        tab.Objetos = objetos.GetListEstruturaObjetoByFK(tab.Id);
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
        /// Cria todas as tabelas/objetos para o Banco de dados.
        /// </summary>
        public void Create()
        {
            try
            {
                List<EstruturaTabelaDTO> tables = this.GetListAll();
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                    try
                    {
                        foreach (EstruturaTabelaDTO estrutura in tables)
                        {
                            string DDL = estrutura.DDL.Replace("[empresa]", Global.EmpresaAtiva);
                            dbCommand = db.GetSqlStringCommand(DDL);

                            db.ExecuteNonQuery(dbCommand, transaction);

                            //OBJETOS (FK´S, PK´S, ÍNDICES, CHECKS, ETC)
                            foreach (EstruturaObjetoDTO objeto in estrutura.Objetos)
                            {
                                DDL = objeto.DDL.Replace("[empresa]", Global.EmpresaAtiva);
                                dbCommand = db.GetSqlStringCommand(DDL);

                                db.ExecuteNonQuery(dbCommand, transaction);
                            }
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
        /// Cria tabelas/objetos de acordo com a instrução especificada.
        /// </summary>
        /// <param name="tables">Tabela(s) a ser(em) criada(s)</param>
        public void Create(List<EstruturaTabelaDTO> tables)
        {
            try
            {
                List<DatabaseStructureDTO> databaseobjects = new DatabaseStructureDAO().GetObjects(Global.EmpresaAtiva);

                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                    string objetoatual = string.Empty;

                    try
                    {
                        foreach (EstruturaTabelaDTO estrutura in tables)
                        {
                            objetoatual = estrutura.Descricao;
                            string DDL = estrutura.DDL.Replace("[empresa]", Global.EmpresaAtiva);
                            dbCommand = db.GetSqlStringCommand(DDL);

                            db.ExecuteNonQuery(dbCommand, transaction);

                            //OBJETOS (FK´S, PK´S, ÍNDICES, CHECKS, ETC)
                            foreach (EstruturaObjetoDTO objeto in estrutura.Objetos)
                            {
                                objetoatual = objeto.Descricao;
                                DDL = objeto.DDL.Replace("[empresa]", Global.EmpresaAtiva);
                                dbCommand = db.GetSqlStringCommand(DDL);

                                DatabaseStructureDTO objectstructure = databaseobjects.Find(delegate(DatabaseStructureDTO item) { return item.Name.Equals(objeto.Nomeobjeto); });
                                if (objectstructure == null)
                                    db.ExecuteNonQuery(dbCommand, transaction);
                            }
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