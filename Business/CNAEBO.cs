using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class CNAEBO
    {
        CNAEDAO regrasdados = new CNAEDAO();

        /// <summary>
        /// Instância básica para CNAEBO.
        /// </summary>
        public CNAEBO()
        { }

        /// <summary>
        /// Retorna um objeto CNAEDTO para a instrução do conteúdo especificado.
        /// </summary>
        public CNAEDTO GetCNAE(int id)
        {
            try
            {
                return regrasdados.GetCNAE(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos CNAEDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<CNAEDTO> GetGridCNAE(string Campo, string ValorPesquisa)
        {
            try
            {
                return regrasdados.GetGridCNAE(Campo, ValorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



        /// <summary>
        /// Retorna um objeto CNAEDTO para a instrução do conteúdo especificado.
        /// </summary>
        public CNAEDTO GetCNAE(string codigo)
        {
            try
            {
                return regrasdados.GetCNAE(codigo);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}