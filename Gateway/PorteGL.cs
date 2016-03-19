using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
#endregion

namespace MechTech.Gateway
{
    public class PorteGL
    {
        PorteBO regrasnegocio = new PorteBO();

        /// <summary>
        /// Instância básica para PorteGL.
        /// </summary>
        public PorteGL()
        { }

        /// <summary>
        /// Retorna um objeto PorteDTO caso a instrução seja bem sucedida.
        /// </summary>
        public PorteDTO GetPorte(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetPorte(id);
                else
                    return new PorteDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos PorteDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<PorteDTO> GetGridPorte(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridPorte(campo, valorPesquisa);
                else
                    return new List<PorteDTO>();
            }
            catch
            {
                throw;
            }
        }



    }
}