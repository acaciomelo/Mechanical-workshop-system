using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
#endregion

namespace MechTech.Gateway
{
    public class NaturezaJuridicaGL
    {
        NaturezaJuridicaBO regrasnegocio = new NaturezaJuridicaBO();

        /// <summary>
        /// Instância básica para NaturezajuridicaGL.
        /// </summary>
        public NaturezaJuridicaGL()
        { }

        /// <summary>
        /// Retorna um objeto NaturezajuridicaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public NaturezaJuridicaDTO GetNaturezajuridica(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetNaturezajuridica(id);
                else
                    return new NaturezaJuridicaDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos NaturezajuridicaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<NaturezaJuridicaDTO> GetGridNaturezajuridica(string Campo, string ValorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridNaturezajuridica(Campo, ValorPesquisa);
                else
                    return new List<NaturezaJuridicaDTO>();
            }
            catch
            {
                throw;
            }
        }


    }
}