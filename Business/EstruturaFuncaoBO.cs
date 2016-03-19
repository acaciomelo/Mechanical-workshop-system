using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class EstruturaFuncaoBO
    {
        EstruturaFuncaoDAO regrasdados = new EstruturaFuncaoDAO();

        /// <summary>
        /// Instância básica para EstruturaFuncaoBO.
        /// </summary>
        public EstruturaFuncaoBO()
        { }

        /// <summary>
        /// Retorna uma lista de objetos EstruturaFuncaoDTO.
        /// </summary>
        public List<EstruturaFuncaoDTO> GetListAll()
        {
            try
            {
                return regrasdados.GetListAll();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Cria todas as funções para o Banco de dados.
        /// </summary>
        public void Create()
        {
            try
            {
                regrasdados.Create();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
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
                regrasdados.Create(functions);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}