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
    public class SecaoBO : IDados<SecaoDTO>
    {
        SecaoDAO regrasdados = new SecaoDAO();

        /// <summary>
        /// Instância básica para SecaoBO.
        /// </summary>
        public SecaoBO()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(SecaoDTO Secao)
        {
            try
            {
                return regrasdados.Insert(Secao);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(SecaoDTO Secao)
        {
            try
            {
                return regrasdados.Update(Secao);
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
        /// Retorna um objeto SecaoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SecaoDTO GetSecao(int id)
        {
            try
            {
                return regrasdados.GetSecao(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos SecaoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<SecaoDTO> GetGridSecao(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridSecao(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



        /// <summary>
        /// Retorna um objeto SecaoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SecaoDTO GetSecaoCodigo(int codigo)
        {
            try
            {
                return regrasdados.GetSecaoCodigo(codigo);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}