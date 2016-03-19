using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class UFBO
    {
        UFDAO regrasdados = new UFDAO();

        /// <summary>
        /// Instância básica para UFBO.
        /// </summary>
        public UFBO()
        { }

        /// <summary>
        /// Retorna um objeto UFDTO para a instrução do conteúdo especificado.
        /// </summary>
        public UFDTO GetUF(int id)
        {
            try
            {
                return regrasdados.GetUF(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos UFDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<UFDTO> GetGridUF(string Campo, string ValorPesquisa)
        {
            try
            {
                return regrasdados.GetGridUF(Campo, ValorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


    }
}