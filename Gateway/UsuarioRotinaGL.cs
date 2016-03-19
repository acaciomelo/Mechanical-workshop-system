using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
#endregion

namespace MechTech.Gateway
{
    public class UsuarioRotinaGL
    {
        UsuarioRotinaBO regrasnegocio = new UsuarioRotinaBO();

        /// <summary>
        /// Instância básica para UsuarioRotinaGL.
        /// </summary>
        public UsuarioRotinaGL()
        { }

        public void Insert(List<UsuarioRotinaDTO> collection, int id_usuario)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    regrasnegocio.Insert(collection, id_usuario);
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(int id_usuario)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Delete(id_usuario);
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        public List<UsuarioRotinaDTO> GetUsuarioRotinaUsuario(int id_usuario)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetUsuarioRotinaUsuario(id_usuario);
                else
                    return new List<UsuarioRotinaDTO>();
            }
            catch
            {
                throw;
            }
        }
    }
}