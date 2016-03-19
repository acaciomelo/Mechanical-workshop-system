﻿using System;
using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Gateway
{
    public class EmpresaGL : IDados<EmpresaDTO>
    {
        EmpresaBO regrasnegocio = new EmpresaBO();

        /// <summary>
        /// Instância básica para EmpresaGL.
        /// </summary>
        public EmpresaGL()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(EmpresaDTO Empresa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(Empresa);
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(EmpresaDTO Empresa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(Empresa);
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do conteúdo especificado, caso contrário FALSO.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Delete(id);
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto EmpresaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public EmpresaDTO GetEmpresa(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetEmpresa(id);
                else
                    return new EmpresaDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos EmpresaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<EmpresaDTO> GetGridEmpresa(string Campo, string ValorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridEmpresa(Campo, ValorPesquisa);
                else
                    return new List<EmpresaDTO>();
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// Trava de segurança.
        /// </summary>
        public void Update(int id_empresa, DateTime? data)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    regrasnegocio.Update(id_empresa, data);
            }
            catch
            {
                throw;
            }
        }

        public string GetRazaoSocial(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetRazaoSocial(id);
                else
                    return string.Empty;
            }
            catch
            {
                throw;
            }
        }

        public int GetSimples(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetSimples(id);
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto EmpresaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public EmpresaDTO GetDadosImpressao(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetDadosImpressao(id);
                else
                    return new EmpresaDTO();
            }
            catch
            {
                throw;
            }
        }
    }
}