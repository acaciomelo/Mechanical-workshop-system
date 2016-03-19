using System;
using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Business.Calculos;
using MechTech.Entities;
#endregion

namespace MechTech.Gateway
{
    public class OrcamentoGL : IDisposable
    {
        OrcamentoBO regrasnegocio = new OrcamentoBO();
        Orcamento calculos = new Orcamento();
        CalculaOrcamento<OrcamentoDTO> FPCVM = new CalculaOrcamento<OrcamentoDTO>();

        /// <summary>
        /// Instância básica para OrcamentoGL.
        /// </summary>
        public OrcamentoGL()
        { }

        public bool AtualizarEstoque(int produtoId, int qtdEstoqueAtualizada)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.AtualizarEstoque(produtoId, qtdEstoqueAtualizada);
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos OrcamentoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<OrcamentoDTO> GetGridOrcamento(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridOrcamento(campo, valorPesquisa);
                else
                    return new List<OrcamentoDTO>();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(OrcamentoDTO Orcamento)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(Orcamento);
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
        public bool Update(OrcamentoDTO Orcamento)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(Orcamento);
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
        /// Retorna um objeto OrcamentoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public OrcamentoDTO GetOrcamento(int id_orcamento)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetOrcamento(id_orcamento);
                else
                    return new OrcamentoDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto OrcamentoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public OrcamentoDTO GetOrcamento(int id_funcionario, DateTime mesano)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetOrcamento(id_funcionario, mesano);
                else
                    return new OrcamentoDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto OrcamentoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public OrcamentoDTO GetOrcamento(int id_funcionario, int processamento, DateTime mesano, bool todoseventos)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetOrcamento(id_funcionario, processamento, mesano, todoseventos);
                else
                    return new OrcamentoDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto OrcamentoDTO caso a instrução seja bem sucedida.
        /// <param name="mesano">null = Mês anterior em relação ao mês/ano ativo, caso contrário, mês anterior em relação a data informada</param>
        /// </summary>
        public OrcamentoDTO GetOrcamentoMesanterior(int id_funcionario, int processamento, DateTime? mesano)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetOrcamentoMesanterior(id_funcionario, processamento, mesano);
                else
                    return new OrcamentoDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto OrcamentoDTO com o orçamento calculado.
        /// </summary>
        /// <param name="obj">Objeto à ser calculado</param>
        /// <returns>Objeto calculado</returns>
        public OrcamentoDTO CalculaOrcamento(OrcamentoDTO obj)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return FPCVM.Calcula(calculos, obj);
                else
                    return new OrcamentoDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto OrcamentoDTO com os totais calculado.
        /// </summary>
        /// <param name="obj">Objeto à ser calculado</param>
        /// <returns>Objeto calculado</returns>
        public OrcamentoDTO TotalizaOrcamento(OrcamentoDTO obj)
        {
            try
            {
                //if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                //    return FPCVM.Totaliza(calculos, obj);
                //else
                    return new OrcamentoDTO();
            }
            catch
            {
                throw;
            }
        }

        #region IDisposable Members
        /// <summary>
        /// Responsável por liberar os recursos alocados dinamicamente para execução dos cálculos na classe Orcamento.
        /// </summary>
        public void Dispose()
        {
            //if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
            //    calculos.Dispose();
        }

        public void Dispose(bool disposing)
        {
            //if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
            //    calculos.Dispose(disposing);
        }
        #endregion
    }
}