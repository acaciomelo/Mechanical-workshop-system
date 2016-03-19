using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Interfaces;
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class UsuarioBO : IDados<UsuarioDTO>
    {
        UsuarioDAO regrasdados = new UsuarioDAO();

        /// <summary>
        /// Instância básica para UsuarioBO.
        /// </summary>
        public UsuarioBO()
        { }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(UsuarioDTO usuario)
        {
            try
            {
                return regrasdados.Insert(usuario);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(UsuarioDTO usuario)
        {
            try
            {
                return regrasdados.Update(usuario);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                return regrasdados.Delete(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um objeto UsuarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public UsuarioDTO GetUsuario(int id)
        {
            try
            {
                return regrasdados.GetUsuario(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos UsuarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<UsuarioDTO> GetGridUsuario(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridUsuario(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
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
                return regrasdados.GetUsuarioByLogin(login);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}