using System;
using System.Collections.Generic;
using System.Text;

#region MechTech
using MechTech.Util;
using MechTech.Entities;
using MechTech.Interfaces;
using MechTech.Business;
#endregion

namespace MechTech.Gateway
{
    public class ProdutoServicoGL : IDados<ProdutoServicoDTO>
    {
        ProdutoServicoBO regrasnegocio = new ProdutoServicoBO();

        /// <summary>
        /// Instância básica para ProdutoServicoGL.
        /// </summary>
        public ProdutoServicoGL()
        { }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(ProdutoServicoDTO produto)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(produto);
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(ProdutoServicoDTO produto)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(produto);
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
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
        /// Retorna um objeto ProdutoServicoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public ProdutoServicoDTO GetProdutoServico(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetProdutoServico(id);
                else
                    return new ProdutoServicoDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos ProdutoServicoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<ProdutoServicoDTO> GetGridProdutoServico(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridProdutoServico(campo, valorPesquisa);
                else
                    return new List<ProdutoServicoDTO>();
            }
            catch
            {
                throw;
            }
        }
    }
}
