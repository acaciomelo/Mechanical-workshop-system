using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class UsuarioPerfilBO
    {
        UsuarioPerfilDAO regrasdados = new UsuarioPerfilDAO();

        /// <summary>
        /// Instância básica para UsuarioPerfilBO.
        /// </summary>
        public UsuarioPerfilBO()
        { }

        public void Insert(List<UsuarioPerfilDTO> collection, int id_usuario)
        {
            try
            {
                regrasdados.Insert(collection, id_usuario);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool Delete(int id_usuario)
        {
            try
            {
                return regrasdados.Delete(id_usuario);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<UsuarioPerfilDTO> GetUsuarioPerfilUsuario(int id_usuario)
        {
            try
            {
                return regrasdados.GetUsuarioPerfilUsuario(id_usuario);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}