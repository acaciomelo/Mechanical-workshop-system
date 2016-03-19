using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Interfaces;
using MechTech.Entities;
using MechTech.Data;

#endregion

namespace MechTech.Business
{
    public class CategoriaProdutoBO : IDados<CategoriaProdutoDTO>
    {
        CategoriaProdutoDAO regrasdados = new CategoriaProdutoDAO();

        /// <summary>
        /// Instância básica para CategoriaProdutoBO.
        /// </summary>
        public CategoriaProdutoBO()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(CategoriaProdutoDTO Produto)
        {
            try
            {
                return regrasdados.Insert(Produto);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(CategoriaProdutoDTO Produto)
        {
            try
            {
                return regrasdados.Update(Produto);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do conteúdo especificado, caso contrário FALSO.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                return regrasdados.Delete(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um objeto CategoriaProdutoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public CategoriaProdutoDTO GetCategoriaProduto(int id)
        {
            try
            {
                return regrasdados.GetCategoriaProduto(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos CategoriaProdutoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<CategoriaProdutoDTO> GetGridCategoriaProduto(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridCategoriaProduto(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public CategoriaProdutoDTO GetCategoriaProdutoCodigo(int codigo)
        {
            try
            {
                return regrasdados.GetCategoriaProdutoCodigo(codigo);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}

