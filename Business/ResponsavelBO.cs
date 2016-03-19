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
    public class ResponsavelBO : IDados<ResponsavelDTO>
    {
        ResponsavelDAO regrasdados = new ResponsavelDAO();

        /// <summary>
        /// Instância básica para ResponsavelBO.
        /// </summary>
        public ResponsavelBO()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(ResponsavelDTO responsavel)
        {
            try
            {
                return regrasdados.Insert(responsavel);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(ResponsavelDTO responsavel)
        {
            try
            {
                return regrasdados.Update(responsavel);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do conteúdo especificado, caso contrário FALSO.
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
        /// Retorna um objeto ResponsavelDTO para a instrução do conteúdo especificado.
        /// </summary>
        public ResponsavelDTO GetResponsavel(int id)
        {
            try
            {
                return regrasdados.GetResponsavel(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos ResponsavelDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<ResponsavelDTO> GetGridResponsavel(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridResponsavel(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos ResponsavelDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<ResponsavelDTO> GetResponsaveis(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetResponsaveis(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        /// <summary>
        /// Checa se o responsável já se encontra cadastrado no sistema, através de algum documento.
        /// </summary>
        /// <param name="campo">nome do campo no banco de dados que será pesquisado</param>
        /// <param name="valorPesquisa">número do documento que será pesquisado</param>
        /// <param name="valorID">ID atual do responsável</param>
        /// <returns>true se já existir, false se não existir</returns>
        public bool ChecaResponsavel(string campo, string valorPesquisa, int valorID)
        {
            try
            {
                return false;
                //return regrasdados.ChecaResponsavel(campo, valorPesquisa, valorID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

    }
}