using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class PorteBO
    {
        PorteDAO regrasdados = new PorteDAO();

        /// <summary>
        /// Instância básica para PorteBO.
        /// </summary>
        public PorteBO()
        { }

        /// <summary>
        /// Retorna um objeto PorteDTO caso a instrução seja bem sucedida.
        /// </summary>
        public PorteDTO GetPorte(int id)
        {
            try
            {
                return regrasdados.GetPorte(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos PorteDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<PorteDTO> GetGridPorte(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridPorte(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



    }
}