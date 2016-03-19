using System;
using System.ServiceModel;

#region MechTech
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class MechTechAtivaBO
    {
        MechTechAtivaDAO regrasdados = new MechTechAtivaDAO();

        /// <summary>
        /// Instância básica para MechTechAtivaBO.
        /// </summary>
        public MechTechAtivaBO()
        { }

        /// <summary>
        /// Retorna um objeto MechTechAtivaDTO contendo a licença de ativação liberada.
        /// </summary>
        /// <param name="filial">Filial liberada</param>
        public MechTechAtivaDTO GetMechTechAtivaByFilial(int filial)
        {
            try
            {
                return regrasdados.GetMechTechAtivaByFilial(filial);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}