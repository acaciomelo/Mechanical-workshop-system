using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
#endregion

namespace MechTech.Gateway
{
    public class UsuarioPerfilGL
    {
        UsuarioPerfilBO regrasnegocio = new UsuarioPerfilBO();

        /// <summary>
        /// Instância básica para UsuarioPerfilGL.
        /// </summary>
        public UsuarioPerfilGL()
        { }

        public void Insert(List<UsuarioPerfilDTO> collection, int id_usuario)
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

        public List<UsuarioPerfilDTO> GetUsuarioPerfilUsuario(int id_usuario)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetUsuarioPerfilUsuario(id_usuario);
                else
                    return new List<UsuarioPerfilDTO>();
            }
            catch
            {
                throw;
            }
        }
    }
}