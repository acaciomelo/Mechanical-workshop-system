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
    public class EmpresaBO : IDados<EmpresaDTO>
    {
        EmpresaDAO regrasdados = new EmpresaDAO();

        /// <summary>
        /// Instância básica para EmpresaBO.
        /// </summary>
        public EmpresaBO()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(EmpresaDTO Empresa)
        {
            try
            {
                return regrasdados.Insert(Empresa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(EmpresaDTO Empresa)
        {
            try
            {
                return regrasdados.Update(Empresa);
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
        /// Retorna um objeto EmpresaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public EmpresaDTO GetEmpresa(int id)
        {
            try
            {
                EmpresaDTO empresa = regrasdados.GetEmpresa(id);
                return empresa;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos EmpresaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<EmpresaDTO> GetGridEmpresa(string Campo, string ValorPesquisa)
        {
            try
            {
                List<EmpresaDTO> lstEmpresa = regrasdados.GetGridEmpresa(Campo, ValorPesquisa);
                return lstEmpresa;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
            return null;
        }



        /// <summary>
        /// Trava de segurança.
        /// </summary>
        public void Update(int id_empresa, DateTime? data)
        {
            try
            {
                regrasdados.Update(id_empresa, data);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public string GetRazaoSocial(int id)
        {
            try
            {
                return regrasdados.GetRazaoSocial(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public int GetSimples(int id)
        {
            try
            {
                return regrasdados.GetSimples(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um objeto EmpresaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public EmpresaDTO GetDadosImpressao(int id)
        {
            try
            {
                return regrasdados.GetDadosImpressao(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}