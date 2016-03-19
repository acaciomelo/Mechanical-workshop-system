using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Interfaces;
using MechTech.Entities;
using MechTech.Data;
using MechTech.Business.Contracts;
#endregion

namespace MechTech.Business
{


    public class BuscaCEPBO
    {

        BuscaCEPDAO regrasdados = new BuscaCEPDAO();

        /// <summary>
        /// Instância básica para CBOBO.
        /// </summary>
        public BuscaCEPBO()
        { }


        public List<BuscaCEPDTO> GetEndereco(string uf, string municipio, string logradouro, string cep)
        {
            try
            {
                List<BuscaCEPDTO> dados = regrasdados.GetEndereco(uf, municipio, logradouro, cep);
                return dados;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



    }
}
