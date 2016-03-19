using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
using MechTech.Util;
#endregion

namespace MechTech.Business
{
    public class OrcamentoBO
    {
        DateTime dataprocessamento;
        OrcamentoDAO regrasdados = new OrcamentoDAO();
        EmpresaBO regrasnegocioempresa = new EmpresaBO();

        /// <summary>
        /// Instância básica para OrcamentoBO.
        /// </summary>
        public OrcamentoBO()
        {
            dataprocessamento = Global.MesanoAtivo;
        }


        /// <summary>
        /// Retorna uma lista de objetos OrcamentoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<OrcamentoDTO> GetGridOrcamento(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridOrcamento(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(OrcamentoDTO Orcamento)
        {
            try
            {
                Transaction.Stop(false);
                Transaction.Start();
                return regrasdados.Insert(Orcamento);
            }
            catch (Exception ex)
            {
                Transaction.Stop(false);
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(OrcamentoDTO Orcamento)
        {
            try
            {
                Transaction.Stop(false);
                Transaction.Start();
                return regrasdados.Update(Orcamento);
            }
            catch (Exception ex)
            {
                Transaction.Stop(false);
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                Transaction.Stop(false);
                Transaction.Start();
                return regrasdados.Delete(id);
            }
            catch (Exception ex)
            {
                Transaction.Stop(false);
                throw new FaultException(ex.Message);
            }
        }

        //TODO: Implemente códigos adicionais aqui.

        /// <summary>
        /// Retorna um objeto OrcamentoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public OrcamentoDTO GetOrcamento(int id_cliente)
        {
            try
            {
                return regrasdados.GetOrcamento(id_cliente);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um objeto OrcamentoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public OrcamentoDTO GetOrcamento(int id_funcionario, DateTime mesano)
        {
            try
            {
                return regrasdados.GetOrcamento(id_funcionario, mesano);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um objeto OrcamentoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public OrcamentoDTO GetOrcamento(int id_funcionario, int processamento, DateTime mesano, bool todoseventos)
        {
            try
            {
                return regrasdados.GetOrcamento(id_funcionario, processamento, mesano, todoseventos);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
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
                return regrasdados.GetOrcamentoMesanterior(id_funcionario, processamento, mesano);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AtualizarEstoque(int produtoId, int qtdEstoqueAtualizada)
        {
            try
            {
                return regrasdados.AtualizarEstoque(produtoId, qtdEstoqueAtualizada);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}