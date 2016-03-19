using System;
using System.Collections.Generic;
using System.ServiceModel;

using MechTech.Data;
using MechTech.Entities;


namespace MechTech.Business
{
    public class VersaoBO
    {
        VersaoDAO regrasdados = new VersaoDAO();

        public VersaoBO()
        { }

        /// <summary>
        /// Retorna uma lista de objetos CpArqDbDTO da tabela CpArq para copiar para o C:
        /// </summary>
        public List<CpArqDbDTO> GetCpArqDb(string conexao)
        {
            try
            {
                return regrasdados.GetCpArqDb(conexao);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Carrega a versão do sistema pela tabela Pacote.
        /// </summary>
        /// <param name="conexao">string de conexão atualmente em uso</param>
        /// <returns>Retorna a versão atual do sistema informado pela tabela Pacote</returns>
        public string VersaoAtual(string conexao)
        {
            try
            {
                return regrasdados.VersaoAtual(conexao);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Verifica a ultima disponibilização de módulo
        /// </summary>
        /// <param name="filial">Filial ativa</param>
        /// <param name="versao">Versão atual</param>
        /// <param name="modulo">Módulo atual</param>
        /// <returns>Data Clarion da última disponibilização de módulo</returns>
        public int ModuloDesatualizado(int filial, decimal versao, int modulo, string sistema)
        {
            try
            {
                return regrasdados.ModuloDesatualizado(filial, versao, modulo, sistema);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
