using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion


namespace MechTech.Gateway
{
    public class BuscaCEPGL
    {
        BuscaCEPBO regrasnegocio = new BuscaCEPBO();

        public BuscaCEPGL()
        { }

        public List<BuscaCEPDTO> GetEndereco(string uf, string municipio, string logradouro, string cep)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetEndereco(uf, municipio, logradouro, cep);
                else
                    return new List<BuscaCEPDTO>();
            }
            catch
            {
                throw;
            }
        }
    }
}
