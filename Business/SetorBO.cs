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
    public class SetorBO : IDados<SetorDTO>
    {
        SetorDAO regrasdados = new SetorDAO();

        /// <summary>
        /// Instância básica para SetorBO.
        /// </summary>
        public SetorBO()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(SetorDTO Setor)
        {
            try
            {
                return regrasdados.Insert(Setor);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(SetorDTO Setor)
        {
            try
            {
                return regrasdados.Update(Setor);
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
        /// Retorna um objeto SetorDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SetorDTO GetSetor(int id)
        {
            try
            {
                return regrasdados.GetSetor(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos SetorDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<SetorDTO> GetGridSetor(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridSetor(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



        /// <summary>
        /// Retorna um objeto SetorDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SetorDTO GetSetorCodigo(int codigo)
        {
            try
            {
                return regrasdados.GetSetorCodigo(codigo);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}