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
    public class FornecedorGL : IDados<FornecedorDTO>
    {
        FornecedorBO regrasnegocio = new FornecedorBO();

        /// <summary>
        /// Instância básica para FornecedorGL.
        /// </summary>
        public FornecedorGL()
        { }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(FornecedorDTO fornecedor)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(fornecedor);
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
        public bool Update(FornecedorDTO fornecedor)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(fornecedor);
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
        /// Retorna um objeto FornecedorDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FornecedorDTO GetFornecedor(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetFornecedor(id);
                else
                    return new FornecedorDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FornecedorDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FornecedorDTO> GetGridFornecedor(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridFornecedor(campo, valorPesquisa);
                else
                    return new List<FornecedorDTO>();
            }
            catch
            {
                throw;
            }
        }
    }
}
