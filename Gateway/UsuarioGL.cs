using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Gateway
{
    public class UsuarioGL : IDados<UsuarioDTO>
    {
        UsuarioBO regrasnegocio = new UsuarioBO();

        /// <summary>
        /// Instância básica para UsuarioGL.
        /// </summary>
        public UsuarioGL()
        { }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(UsuarioDTO usuario)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(usuario);
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(UsuarioDTO usuario)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(usuario);
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Delete(id);
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto UsuarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public UsuarioDTO GetUsuario(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetUsuario(id);
                else
                    return new UsuarioDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos UsuarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<UsuarioDTO> GetGridUsuario(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridUsuario(campo, valorPesquisa);
                else
                    return new List<UsuarioDTO>();
            }
            catch
            {
                throw;
            }
        }

        //TODO: Implemente códigos adicionais aqui.

        /// <summary>
        /// Retorna um objeto UsuarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public UsuarioDTO GetUsuarioByLogin(string login)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetUsuarioByLogin(login);
                else
                    return new UsuarioDTO();
            }
            catch
            {
                throw;
            }
        }
    }
}