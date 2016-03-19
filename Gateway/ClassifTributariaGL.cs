using System;
using System.Collections.Generic;
using System.Text;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Gateway
{
    public class ClassifTributariaGL
    {
        ClassifTributariaBO regrasnegocio = new ClassifTributariaBO();

        /// <summary>
        /// Instância básica para ClassifTributariaGL.
        /// </summary>
        public ClassifTributariaGL()
        { }

        /// <summary>
        /// Retorna uma lista de objetos ClassifTributariaDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<ClassifTributariaDTO> GetGridClassifTributaria(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridClassifTributaria(campo, valorPesquisa);
                else
                    return new List<ClassifTributariaDTO>();
            }
            catch
            {
                throw;
            }
        }



    }
}
