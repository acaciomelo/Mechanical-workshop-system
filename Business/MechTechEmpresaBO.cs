using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MechTech
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class MechTechEmpresaBO
    {
        MechTechEmpresaDAO regrasdados = new MechTechEmpresaDAO();

        /// <summary>
        /// Instância básica para MechTechEmpresaBO.
        /// </summary>
        public MechTechEmpresaBO()
        { }

        /// <summary>
        /// Retorna uma lista de objetos MechTechEmpresaDTO contendo as empresas liberadas para uso.
        /// </summary>
        public List<MechTechEmpresaDTO> GetMechTechEmpresaByID_MechTechAtiva(int id_MechTechativa)
        {
            try
            {
                return regrasdados.GetMechTechEmpresaByID_MechTechAtiva(id_MechTechativa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}