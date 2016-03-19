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
    public class DepartamentoBO : IDados<DepartamentoDTO>
    {
        DepartamentoDAO regrasdados = new DepartamentoDAO();

        /// <summary>
        /// Instância básica para DepartamentoBO.
        /// </summary>
        public DepartamentoBO()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(DepartamentoDTO Departamento)
        {
            try
            {
                return regrasdados.Insert(Departamento);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(DepartamentoDTO Departamento)
        {
            try
            {
                return regrasdados.Update(Departamento);
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
        /// Retorna um objeto DepartamentoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public DepartamentoDTO GetDepartamento(int id)
        {
            try
            {
                return regrasdados.GetDepartamento(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos DepartamentoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<DepartamentoDTO> GetGridDepartamento(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridDepartamento(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



        /// <summary>
        /// Retorna um objeto DepartamentoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public DepartamentoDTO GetDepartamentoCodigo(int codigo)
        {
            try
            {
                return regrasdados.GetDepartamentoCodigo(codigo);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
