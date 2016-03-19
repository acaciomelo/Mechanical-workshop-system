using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class EstruturaObjetoBO
    {
        EstruturaObjetoDAO regrasdados = new EstruturaObjetoDAO();

        /// <summary>
        /// Instância básica para EstruturaObjetoBO.
        /// </summary>
        public EstruturaObjetoBO()
        { }

        /// <summary>
        /// Retorna uma lista de objetos EstruturaObjetoDTO.
        /// </summary>
        public List<EstruturaObjetoDTO> GetListAll()
        {
            try
            {
                return regrasdados.GetListAll();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos EstruturaObjetoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<EstruturaObjetoDTO> GetListEstruturaObjetoByFK(int id_estruturatabela)
        {
            try
            {
                return regrasdados.GetListEstruturaObjetoByFK(id_estruturatabela);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Cria objetos de acordo com a instrução especificada.
        /// </summary>
        /// <param name="objects">Objeto(s) a ser(em) criado(s)</param>
        public void Create(List<EstruturaObjetoDTO> objects)
        {
            try
            {
                regrasdados.Create(objects);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}