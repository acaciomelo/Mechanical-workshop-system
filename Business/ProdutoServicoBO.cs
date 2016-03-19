using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

#region MECHTECH
using MechTech.Interfaces;
using MechTech.Entities;
using MechTech.Business.Contracts;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class ProdutoServicoBO : IDados<ProdutoServicoDTO>
    {
        ProdutoServicoDAO regrasdados = new ProdutoServicoDAO();

        /// <summary>
        /// Instância básica para ProdutoServicoBO.
        /// </summary>
        public ProdutoServicoBO()
        { }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(ProdutoServicoDTO produto)
        {
            try
            {
                return regrasdados.Insert(produto);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(ProdutoServicoDTO produto)
        {
            try
            {
                return regrasdados.Update(produto);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
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
        /// Retorna um objeto ProdutoServicoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public ProdutoServicoDTO GetProdutoServico(int id)
        {
            try
            {
                return regrasdados.GetProdutoServico(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos ProdutoServicoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<ProdutoServicoDTO> GetGridProdutoServico(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridProdutoServico(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
