using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
#endregion

namespace MechTech.Gateway
{
    public class SalarioTipoGL
    {
        SalarioTipoBO regrasnegocio = new SalarioTipoBO();

        /// <summary>
        /// Instância básica para SalariotipoGL.
        /// </summary>
        public SalarioTipoGL()
        { }

        /// <summary>
        /// Retorna um objeto SalariotipoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SalarioTipoDTO GetSalariotipo(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetSalariotipo(id);
                else
                    return new SalarioTipoDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos SalariotipoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<SalarioTipoDTO> GetGridSalariotipo(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridSalariotipo(campo, valorPesquisa);
                else
                    return new List<SalarioTipoDTO>();
            }
            catch
            {
                throw;
            }
        }



    }
}