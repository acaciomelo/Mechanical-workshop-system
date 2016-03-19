using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class FilialBO
    {
        FilialDAO regrasdados = new FilialDAO();

        /// <summary>
        /// Instância básica para FilialBO.
        /// </summary>
        public FilialBO()
        { }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Insert(FilialDTO filial)
        {
            try
            {
                return regrasdados.Insert(filial);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(FilialDTO filial)
        {
            try
            {
                return regrasdados.Update(filial);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Delete(int filial)
        {
            try
            {
                return regrasdados.Delete(filial);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um objeto FilialDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FilialDTO GetFilial(int filial)
        {
            try
            {
                return regrasdados.GetFilial(filial);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FilialDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FilialDTO> GetGridFilial(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridFilial(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



    }
}