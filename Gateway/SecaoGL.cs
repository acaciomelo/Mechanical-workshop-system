using System.Collections.Generic;

#region MechTech
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Gateway
{
    public class SecaoGL : IDados<SecaoDTO>
    {
        SecaoBO regrasnegocio = new SecaoBO();

        /// <summary>
        /// Instância básica para SecaoGL.
        /// </summary>
        public SecaoGL()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(SecaoDTO Secao)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(Secao);
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
        public bool Update(SecaoDTO Secao)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(Secao);
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
        /// Retorna um objeto SecaoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SecaoDTO GetSecao(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetSecao(id);
                else
                    return new SecaoDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos SecaoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<SecaoDTO> GetGridSecao(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridSecao(campo, valorPesquisa);
                else
                    return new List<SecaoDTO>();
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// Retorna um objeto SecaoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SecaoDTO GetSecaoCodigo(int codigo)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetSecaoCodigo(codigo);
                else
                    return new SecaoDTO();
            }
            catch
            {
                throw;
            }
        }
    }
}