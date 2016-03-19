using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Gateway
{
    public class CategoriaProdutoGL : IDados<CategoriaProdutoDTO>
    {
        CategoriaProdutoBO regrasnegocio = new CategoriaProdutoBO();

        /// <summary>
        /// Instância básica para CategoriaProdutoGL.
        /// </summary>
        public CategoriaProdutoGL()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(CategoriaProdutoDTO Categoria)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(Categoria);
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
        public bool Update(CategoriaProdutoDTO Categoria)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(Categoria);
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
        /// Retorna um objeto CategoriaProdutoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public CategoriaProdutoDTO GetCategoria(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetCategoriaProduto(id);
                else
                    return new CategoriaProdutoDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos CategoriaProdutoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<CategoriaProdutoDTO> GetGridCategoria(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridCategoriaProduto(campo, valorPesquisa);
                else
                    return new List<CategoriaProdutoDTO>();
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// Retorna um objeto CategoriaProdutoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public CategoriaProdutoDTO GetCategoriaProdutoCodigo(int codigo)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetCategoriaProdutoCodigo(codigo);
                else
                    return new CategoriaProdutoDTO();
            }
            catch
            {
                throw;
            }
        }
    }
}