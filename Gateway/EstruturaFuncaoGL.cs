using System.Collections.Generic;

#region MECHTECH
using MechTech.Business;
using MechTech.Entities;
#endregion

namespace MechTech.Gateway
{
    public class EstruturaFuncaoGL
    {
        EstruturaFuncaoBO regrasnegocio = new EstruturaFuncaoBO();

        /// <summary>
        /// Instância básica para EstruturaFuncaoGL.
        /// </summary>
        public EstruturaFuncaoGL()
        { }

        /// <summary>
        /// Retorna uma lista de objetos EstruturaFuncaoDTO.
        /// </summary>
        public List<EstruturaFuncaoDTO> GetListAll()
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
        /// Cria todas as funções para o Banco de dados.
        /// </summary>
        public void Create()
        {
            try
            {
                regrasnegocio.Create();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Cria funções de acordo com a instrução especificada.
        /// </summary>
        /// <param name="functions">Função(ões) a ser(em) criada(s)</param>
        public void Create(List<EstruturaFuncaoDTO> functions)
        {
            try
            {
                regrasnegocio.Create(functions);
            }
            catch
            {
                throw;
            }
        }
    }
}
