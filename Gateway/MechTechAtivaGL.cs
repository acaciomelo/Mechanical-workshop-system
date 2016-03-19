#region MechTech
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
#endregion

namespace MechTech.Gateway
{
    public class MechTechAtivaGL
    {
        MechTechAtivaBO regrasnegocio = new MechTechAtivaBO();

        /// <summary>
        /// Instância básica para MechTechAtivaGL.
        /// </summary>
        public MechTechAtivaGL()
        { }

        /// <summary>
        /// Retorna um objeto MechTechAtivaDTO contendo a licença de ativação liberada.
        /// </summary>
        /// <param name="filial">Filial liberada</param>
        public MechTechAtivaDTO GetMechTechAtivaByFilial(int filial)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetMechTechAtivaByFilial(filial);
                else
                    return new MechTechAtivaDTO();
            }
            catch
            {
                throw;
            }
        }
    }
}