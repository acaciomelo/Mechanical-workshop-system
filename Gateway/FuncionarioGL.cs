using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Gateway
{
    public class FuncionarioGL : IDados<FuncionarioDTO>
    {
        FuncionarioBO regrasnegocio = new FuncionarioBO();

        /// <summary>
        /// Instância básica para FuncionarioGL.
        /// </summary>
        public FuncionarioGL()
        { }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(FuncionarioDTO Funcionario)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(Funcionario);
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
        public bool Update(FuncionarioDTO Funcionario)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(Funcionario);
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
        /// Retorna um objeto FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FuncionarioDTO GetFuncionario(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetFuncionario(id);
                else
                    return new FuncionarioDTO();
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// Responsável por verificar a existência de CPF´s duplicados.
        /// </summary>
        /// <param name="id_funcionario">ID do funcionário ignorado na pesquisa</param>
        /// <param name="cpf">Número de um CPF válido</param>
        /// <returns>true=CPF encontrado, false=CPF não encontrado</returns>
        public bool ExistsCPF(int id_funcionario, string cpf)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.ExistsCPF(id_funcionario, cpf);
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public int GetTotalFuncionarios()
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetTotalFuncionarios();
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Retorna uma lista de funcionários selecionados.
        /// </summary>
        /// <param name="ids">Informar um ou mais códigos de funcionário separados por ponto-e-vírgula. Ex.: 3 ou 1;3;5;12;4</param>
        public List<FuncionarioDTO> GetFuncionarios(string ids)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetFuncionarios(ids);
                else
                    return new List<FuncionarioDTO>();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de funcionários selecionados.
        /// Protótipo com seleção
        /// </summary>
        /// <param name="ids">Informar um ou mais códigos de funcionário separados por ponto-e-vírgula. Ex.: 3 ou 1;3;5;12;4</param>
        public List<FuncionarioDTO> GetFuncionarios(string ids, FuncPesquisaDTO opcoes)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetFuncionarios(ids, opcoes);
                else
                    return new List<FuncionarioDTO>();
            }
            catch
            {
                throw;
            }
        }

        public string GetNomeCompleto(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetNomeCompleto(id);
                else
                    return string.Empty;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FuncionarioDTO GetFuncionarioDigitacao(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetFuncionarioDigitacao(id);
                else
                    return new FuncionarioDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioDTO> GetGridFuncionario(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridFuncionario(campo, valorPesquisa);
                else
                    return new List<FuncionarioDTO>();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioDTO> GetListFuncionario(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetListFuncionario(campo, valorPesquisa);
                else
                    return new List<FuncionarioDTO>();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioDTO> GetGridFuncionario(string campo, string valorPesquisa, MechTech.Util.Enumeradores.Modulo modulo)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridFuncionario(campo, valorPesquisa, modulo);
                else
                    return new List<FuncionarioDTO>();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FichaFinanceiraGridDTO caso a instrução seja bem sucedida.
        /// </summary>
        //public List<FichaFinanceiraGridDTO> GetGridFuncionarioFichaFinan(FichaFinanceiraGridDTO obj, bool apresentardemitidos)
        //{
        //    try
        //    {
        //        if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
        //            return regrasnegocio.GetGridFuncionarioFichaFinan(obj, apresentardemitidos);
        //        else
        //            return new List<FichaFinanceiraGridDTO>();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        /// <summary>
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioSEDTO> GetGridFuncionarioSE(string campo, string valorPesquisa, MechTech.Util.Enumeradores.Modulo modulo, bool apresentardemitidos)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridFuncionarioSE(campo, valorPesquisa, modulo, apresentardemitidos);
                else
                    return new List<FuncionarioSEDTO>();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Extension
        /// </summary>
        //public List<FuncionarioSEexDTO> GetGridFuncionarioSEex(string campo, string valorPesquisa, MechTech.Util.Enumeradores.Modulo modulo)
        //{
        //    try
        //    {
        //        if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
        //            return regrasnegocio.GetGridFuncionarioSEex(campo, valorPesquisa, modulo);
        //        else
        //            return new List<FuncionarioSEexDTO>();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        /// <summary>
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        /// <param name="campo">O valor especificado será a chave de indexação da pesquisa</param>
        public List<FuncionarioDTO> GetListDadosLayout(string campo, string valorpesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetListDadosLayout(campo, valorpesquisa);
                else
                    return new List<FuncionarioDTO>();
            }
            catch
            {
                throw;
            }
        }
    }
}