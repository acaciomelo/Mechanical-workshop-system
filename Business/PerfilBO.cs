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
    public class PerfilBO : IDados<PerfilDTO>
    {
        PerfilDAO regrasdados = new PerfilDAO();

        /// <summary>
        /// Instância básica para PerfilBO.
        /// </summary>
        public PerfilBO()
        { }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(PerfilDTO perfil)
        {
            try
            {
                return regrasdados.Insert(perfil);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(PerfilDTO perfil)
        {
            try
            {
                return regrasdados.Update(perfil);
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
        /// Retorna um objeto PerfilDTO caso a instrução seja bem sucedida.
        /// </summary>
        public PerfilDTO GetPerfil(int id)
        {
            try
            {
                return regrasdados.GetPerfil(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos PerfilDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<PerfilDTO> GetGridPerfil(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridPerfil(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        //TODO: Implemente códigos adicionais aqui.

    }
}