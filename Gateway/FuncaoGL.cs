using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Gateway
{
    public class FuncaoGL : IDados<FuncaoDTO>
    {
        FuncaoBO regrasnegocio = new FuncaoBO();

        /// <summary>
        /// Instância básica para FuncaoGL.
        /// </summary>
        public FuncaoGL()
        { }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(FuncaoDTO funcao)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(funcao);
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
        public bool Update(FuncaoDTO funcao)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(funcao);
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
        /// Retorna um objeto FuncaoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FuncaoDTO GetFuncao(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetFuncao(id);
                else
                    return new FuncaoDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FuncaoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncaoDTO> GetGridFuncao(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridFuncao(campo, valorPesquisa);
                else
                    return new List<FuncaoDTO>();
            }
            catch
            {
                throw;
            }
        }



    }
}