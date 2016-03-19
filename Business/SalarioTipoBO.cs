using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class SalarioTipoBO
    {
        SalarioTipoDAO regrasdados = new SalarioTipoDAO();

        /// <summary>
        /// Instância básica para SalariotipoBO.
        /// </summary>
        public SalarioTipoBO()
        { }

        /// <summary>
        /// Retorna um objeto SalariotipoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SalarioTipoDTO GetSalariotipo(int id)
        {
            try
            {
                return regrasdados.GetSalariotipo(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos SalariotipoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<SalarioTipoDTO> GetGridSalariotipo(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridSalariotipo(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



    }
}