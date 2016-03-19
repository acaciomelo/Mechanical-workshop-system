using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Gateway
{
    public class ResponsavelGL : IDados<ResponsavelDTO>
    {
        ResponsavelBO regrasnegocio = new ResponsavelBO();

        /// <summary>
        /// Instância básica para ResponsavelGL.
        /// </summary>
        public ResponsavelGL()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(ResponsavelDTO responsavel)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(responsavel);
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
        public bool Update(ResponsavelDTO responsavel)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(responsavel);
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
        /// Retorna um objeto ResponsavelDTO para a instrução do conteúdo especificado.
        /// </summary>
        public ResponsavelDTO GetResponsavel(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetResponsavel(id);
                else
                    return new ResponsavelDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos ResponsavelDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<ResponsavelDTO> GetGridResponsavel(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridResponsavel(campo, valorPesquisa);
                else
                    return new List<ResponsavelDTO>();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos ResponsavelDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<ResponsavelDTO> GetResponsaveis(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetResponsaveis(campo, valorPesquisa);
                else
                    return new List<ResponsavelDTO>();
            }
            catch
            {
                throw;
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
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.ChecaResponsavel(campo, valorPesquisa, valorID);
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
    }
}