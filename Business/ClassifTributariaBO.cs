using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

#region MECHTECH
using MechTech.Interfaces;
using MechTech.Entities;
using MechTech.Data;
using MechTech.Business.Contracts;
#endregion

namespace MechTech.Business
{
    public class ClassifTributariaBO
    {
        ClassifTributariaDAO regrasdados = new ClassifTributariaDAO();

        /// <summary>
        /// Instância básica para ClassifTributariaBO.
        /// </summary>
        public ClassifTributariaBO()
        { }

        /// <summary>
        /// Retorna uma lista de objetos ClassifTributariaDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<ClassifTributariaDTO> GetGridClassifTributaria(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridClassifTributaria(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



    }
}
