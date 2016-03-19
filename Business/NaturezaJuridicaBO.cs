using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class NaturezaJuridicaBO
    {
        NaturezaJuridicaDAO regrasdados = new NaturezaJuridicaDAO();

        /// <summary>
        /// Instância básica para NaturezajuridicaBO.
        /// </summary>
        public NaturezaJuridicaBO()
        { }

        /// <summary>
        /// Retorna um objeto NaturezajuridicaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public NaturezaJuridicaDTO GetNaturezajuridica(int id)
        {
            try
            {
                return regrasdados.GetNaturezajuridica(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos NaturezajuridicaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<NaturezaJuridicaDTO> GetGridNaturezajuridica(string Campo, string ValorPesquisa)
        {
            try
            {
                return regrasdados.GetGridNaturezajuridica(Campo, ValorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


    }
}