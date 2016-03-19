using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

#region Devart
using Devart.Data.PostgreSql;
#endregion

#region MECHTECH
using MechTech.Entities;
using MechTech.Interfaces;
using MechTech.Util;
#endregion

namespace MechTech.Data
{
    public class CategoriaProdutoDAO : IDados<CategoriaProdutoDTO>
    {
        
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance); 
        DbCommand dbCommand = null;

        /// <summary>
        /// Instância básica para CategoriaProdutoDAO.
        /// </summary>
        public CategoriaProdutoDAO()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(CategoriaProdutoDTO categoriaproduto)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" INSERT INTO public.categoriaproduto(" +
                                                   "    nome," +
                                                   "    descricao," +
                                                   "    codigo" +
                                                   ") VALUES (" +
                                                   "    @nome," +
                                                   "    @descricao," +
                                                   "    @codigo);" +
                                                   " SELECT currval('categoriaproduto_id_seq');");
                db.AddInParameter(dbCommand, "@nome", DbType.String, categoriaproduto.Nome);
                db.AddInParameter(dbCommand, "@descricao", DbType.String, categoriaproduto.Descricao);
                db.AddInParameter(dbCommand, "@codigo", DbType.Int32, categoriaproduto.Codigo);

                int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
                return id;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(CategoriaProdutoDTO categoriaproduto)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" UPDATE public.categoriaproduto SET" +
                                                   "    nome = @nome," +
                                                   "    descricao = @descricao," +
                                                   "    codigo = @codigo" +
                                                   " WHERE" +
                                                   "    id = @id");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, categoriaproduto.Id);
                db.AddInParameter(dbCommand, "@nome", DbType.String, categoriaproduto.Nome);
                db.AddInParameter(dbCommand, "@codigo", DbType.Int32, categoriaproduto.Codigo);
                db.AddInParameter(dbCommand, "@descricao", DbType.String, categoriaproduto.Descricao);
                db.ExecuteNonQuery(dbCommand);
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do conteúdo especificado, caso contrário FALSO.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" DELETE FROM public.categoriaproduto" +
                                                   " WHERE" +
                                                   "    id = @id;");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
                db.ExecuteNonQuery(dbCommand);
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto CategoriaProdutoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public CategoriaProdutoDTO GetCategoriaProduto(int id)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetCategoriaProduto");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    CategoriaProdutoDTO tab = new CategoriaProdutoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Codigo = int.Parse(DR["codigo"].ToString());
                    tab.Nome = DR["nome"].ToString();
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
        /// Retorna uma lista de objetos CategoriaProdutoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<CategoriaProdutoDTO> GetGridCategoriaProduto(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetGridCategoriaProduto");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<CategoriaProdutoDTO> List = new List<CategoriaProdutoDTO>();
                    while (DR.Read())
                    {
                        CategoriaProdutoDTO tab = new CategoriaProdutoDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Codigo = int.Parse(DR["codigo"].ToString());
                        tab.Nome = DR["nome"].ToString();
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

        public CategoriaProdutoDTO GetCategoriaProdutoCodigo(int codigo)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(Global.EmpresaAtiva + ".GetCategoriaProdutoCodigo");
                db.AddInParameter(dbCommand, "@codigo", DbType.Int32, codigo);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    CategoriaProdutoDTO tab = new CategoriaProdutoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Nome = DR["nome"].ToString();
                    tab.Descricao = DR["descricao"].ToString();                   
                    tab.Codigo = int.Parse(DR["codigo"].ToString());
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