using System.Collections.Generic;

#region MECHTECH
using MechTech.Business;
using MechTech.Entities;
#endregion

namespace MechTech.Gateway
{
    public class EstruturaObjetoGL
    {
        EstruturaObjetoBO regrasnegocio = new EstruturaObjetoBO();

        /// <summary>
        /// Instância básica para EstruturaObjetoGL.
        /// </summary>
        public EstruturaObjetoGL()
        { }

        /// <summary>
        /// Retorna uma lista de objetos EstruturaObjetoDTO.
        /// </summary>
        public List<EstruturaObjetoDTO> GetListAll()
        {
            try
            {
                return regrasnegocio.GetListAll();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos EstruturaObjetoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<EstruturaObjetoDTO> GetListEstruturaObjetoByFK(int id_estruturatabela)
        {
            try
            {
                return regrasnegocio.GetListEstruturaObjetoByFK(id_estruturatabela);
            }
            catch
            {
                throw;
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
                regrasnegocio.Create(objects);
            }
            catch
            {
                throw;
            }
        }
    }
}