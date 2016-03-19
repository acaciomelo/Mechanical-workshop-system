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
    public class FuncaoBO : IDados<FuncaoDTO>
    {
        FuncaoDAO regrasdados = new FuncaoDAO();

        /// <summary>
        /// Instância básica para FuncaoBO.
        /// </summary>
        public FuncaoBO()
        { }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(FuncaoDTO funcao)
        {
            try
            {
                return regrasdados.Insert(funcao);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(FuncaoDTO funcao)
        {
            try
            {
                return regrasdados.Update(funcao);
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
        /// Retorna um objeto FuncaoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FuncaoDTO GetFuncao(int id)
        {
            try
            {
                return regrasdados.GetFuncao(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FuncaoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncaoDTO> GetGridFuncao(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridFuncao(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



    }
}