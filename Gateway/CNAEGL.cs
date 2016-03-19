using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
#endregion

namespace MechTech.Gateway
{
    public class CNAEGL
    {
        CNAEBO regrasnegocio = new CNAEBO();

        /// <summary>
        /// Instância básica para CNAEGL.
        /// </summary>
        public CNAEGL()
        { }

        /// <summary>
        /// Retorna um objeto CNAEDTO para a instrução do conteúdo especificado.
        /// </summary>
        public CNAEDTO GetCNAE(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetCNAE(id);
                else
                    return new CNAEDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos CNAEDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<CNAEDTO> GetGridCNAE(string Campo, string ValorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridCNAE(Campo, ValorPesquisa);
                else
                    return new List<CNAEDTO>();
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// Retorna um objeto CNAEDTO para a instrução do conteúdo especificado.
        /// </summary>
        public CNAEDTO GetCNAE(string codigo)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetCNAE(codigo);
                else
                    return new CNAEDTO();
            }
            catch
            {
                throw;
            }
        }
    }
}