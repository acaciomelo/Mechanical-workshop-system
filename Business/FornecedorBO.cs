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
    public class FornecedorBO : IDados<FornecedorDTO>
    {
        FornecedorDAO regrasdados = new FornecedorDAO();

        /// <summary>
        /// Instância básica para FornecedorBO.
        /// </summary>
        public FornecedorBO()
        { }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(FornecedorDTO fornecedor)
        {
            try
            {
                return regrasdados.Insert(fornecedor);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(FornecedorDTO fornecedor)
        {
            try
            {
                return regrasdados.Update(fornecedor);
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
        /// Retorna um objeto FornecedorDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FornecedorDTO GetFornecedor(int id)
        {
            try
            {
                return regrasdados.GetFornecedor(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FornecedorDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FornecedorDTO> GetGridFornecedor(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridFornecedor(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
