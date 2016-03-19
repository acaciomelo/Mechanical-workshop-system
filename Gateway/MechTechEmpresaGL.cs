using System.Collections.Generic;

#region MechTech
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
#endregion

namespace MechTech.Gateway
{
    public class MechTechEmpresaGL
    {
        MechTechEmpresaBO regrasnegocio = new MechTechEmpresaBO();

        /// <summary>
        /// Instância básica para MechTechEmpresaGL.
        /// </summary>
        public MechTechEmpresaGL()
        { }

        /// <summary>
        /// Retorna uma lista de objetos MechTechEmpresaDTO contendo as empresas liberadas para uso.
        /// </summary>
        public List<MechTechEmpresaDTO> GetMechTechEmpresaByID_MechTechAtiva(int id_MechTechativa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetMechTechEmpresaByID_MechTechAtiva(id_MechTechativa);
                else
                    return new List<MechTechEmpresaDTO>();
            }
            catch
            {
                throw;
            }
        }
    }
}