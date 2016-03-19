using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
#endregion

namespace MechTech.Gateway
{
    public class UFGL
    {
        UFBO regrasnegocio = new UFBO();

        /// <summary>
        /// Instância básica para UFGL.
        /// </summary>
        public UFGL()
        { }

        /// <summary>
        /// Retorna um objeto UFDTO para a instrução do conteúdo especificado.
        /// </summary>
        public UFDTO GetUF(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetUF(id);
                else
                    return new UFDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos UFDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<UFDTO> GetGridUF(string Campo, string ValorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridUF(Campo, ValorPesquisa);
                else
                    return new List<UFDTO>();
            }
            catch
            {
                throw;
            }
        }


    }
}