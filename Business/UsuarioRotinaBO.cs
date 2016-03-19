using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class UsuarioRotinaBO
    {
        UsuarioRotinaDAO regrasdados = new UsuarioRotinaDAO();

        /// <summary>
        /// Instância básica para UsuarioRotinaBO.
        /// </summary>
        public UsuarioRotinaBO()
        { }

        public void Insert(List<UsuarioRotinaDTO> collection, int id_usuario)
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

        public List<UsuarioRotinaDTO> GetUsuarioRotinaUsuario(int id_usuario)
        {
            try
            {
                return regrasdados.GetUsuarioRotinaUsuario(id_usuario);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}