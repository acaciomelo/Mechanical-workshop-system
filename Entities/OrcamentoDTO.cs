using MechTech.Entities.AbstractClasses;
using System;
using System.Collections.Generic;

namespace MechTech.Entities
{
    [Serializable]
    public class OrcamentoDTO : IEquatable<OrcamentoDTO>
    {
        public OrcamentoDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public OrcamentoDTO(OrcamentoDTO obj)
        {
            this.Id = obj.Id;
            this.Codigo = obj.Codigo;
            this.DataOrcamento = obj.DataOrcamento;
            this.AtendidoPor = obj.AtendidoPor;
            this.PosicaoOrcamento = obj.PosicaoOrcamento;
            this.Cliente = obj.Cliente;
            this.PlacaVeiculo = obj.PlacaVeiculo;
            this.ValorLiquido = obj.ValorLiquido;
            this.Vinculo = obj.Vinculo;
            this.NotaFiscalServicos = obj.NotaFiscalServicos;
            this.NotaFiscalProdutos = obj.NotaFiscalProdutos;
            this.IdEspecieRecebimento = obj.IdEspecieRecebimento;
            this.ValorEspecieRecebimento = obj.ValorEspecieRecebimento;
            this.QuantidadeParcelas = obj.QuantidadeParcelas;

            //LISTAS GENÉRICAS
            foreach (LancamentoProdutoServicoDTO umprodutoservico in obj.Produtoservico)
            {
                this.Produtoservico.Add(new LancamentoProdutoServicoDTO(umprodutoservico));
            }

            foreach (DetalheFormaRecebimento umdetalheformarecebimento in obj.DetalhesFormaRecebimento)
            {
                this.DetalhesFormaRecebimento.Add(new DetalheFormaRecebimento(umdetalheformarecebimento));
            }
        }

        private int codigo = 0;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? dataOrcamento = null;
        public DateTime? DataOrcamento
        {
            get { return dataOrcamento; }
            set { dataOrcamento = value; }
        }
        private string atendidoPor = string.Empty;
        public string AtendidoPor
        {
            get { return atendidoPor; }
            set { atendidoPor = value; }
        }

        private int posicaoOrcamento = 0;
        public int PosicaoOrcamento
        {
            get { return posicaoOrcamento; }
            set { posicaoOrcamento = value; }
        }

        private string posicaoOrcamentoDescricao = string.Empty;
        public string PosicaoOrcamentoDescricao
        {
            get { return posicaoOrcamentoDescricao; }
            set { posicaoOrcamentoDescricao = value; }
        }

        private string placaVeiculo = string.Empty;
        public string PlacaVeiculo
        {
            get { return placaVeiculo; }
            set { placaVeiculo = value; }
        }

        private ClienteDTO cliente = new ClienteDTO();
        public ClienteDTO Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        private VincularVeiculoDTO vinculo = new VincularVeiculoDTO();
        public VincularVeiculoDTO Vinculo
        {
            get { return vinculo; }
            set { vinculo = value; }
        }

        private List<DetalheFormaRecebimento> detalhesFormaRecebimento = new List<DetalheFormaRecebimento>();
        public List<DetalheFormaRecebimento> DetalhesFormaRecebimento
        {
            get { return detalhesFormaRecebimento; }
            set { detalhesFormaRecebimento = value; }
        }

        private List<LancamentoProdutoServicoDTO> produtoservico = new List<LancamentoProdutoServicoDTO>();
        public List<LancamentoProdutoServicoDTO> Produtoservico
        {
            get { return produtoservico; }
            set { produtoservico = value; }
        }

        private decimal valorLiquido = 0;
        public decimal ValorLiquido
        {
            get { return valorLiquido; }
            set { valorLiquido = value; }
        }

        private string notaFiscalServicos = string.Empty;
        public string NotaFiscalServicos
        {
            get { return notaFiscalServicos; }
            set { notaFiscalServicos = value; }
        }

        private string notaFiscalProdutos = string.Empty;
        public string NotaFiscalProdutos
        {
            get { return notaFiscalProdutos; }
            set { notaFiscalProdutos = value; }
        }
        public int IdEspecieRecebimento { get; set; }
        public decimal ValorEspecieRecebimento { get; set; }
        public int QuantidadeParcelas { get; set; }

        public class DetalheFormaRecebimento : Identificador, IEquatable<DetalheFormaRecebimento>
        {
            public DetalheFormaRecebimento() { }
            public DetalheFormaRecebimento(DetalheFormaRecebimento obj)
            {
                this.Id = obj.Id;
                this.ParcelaEspecie = obj.ParcelaEspecie;
                this.ValorParcela = obj.ValorParcela;
            }
            public override int Id { get; set; }
            public string ParcelaEspecie { get; set; }
            public decimal ValorParcela { get; set; }

            public bool Equals(DetalheFormaRecebimento obj)
            {
                if (this.Id != obj.Id) return false;
                else if (this.ParcelaEspecie != obj.ParcelaEspecie) return false;
                else if (this.ValorParcela != obj.ValorParcela) return false;

                return true;
            }
        }
        #region IEquatable<OrcamentoDTO> Members
        public bool Equals(OrcamentoDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Codigo != obj.Codigo) return false;
            else if (this.DataOrcamento != obj.DataOrcamento) return false;
            else if (this.AtendidoPor != obj.AtendidoPor) return false;
            else if (this.PosicaoOrcamento != obj.PosicaoOrcamento) return false;
            else if (!this.Cliente.Equals(obj.Cliente)) return false;
            else if (this.PlacaVeiculo != obj.PlacaVeiculo) return false;
            else if (this.ValorLiquido != obj.ValorLiquido) return false;
            else if (this.NotaFiscalProdutos != obj.NotaFiscalProdutos) return false;
            else if (this.NotaFiscalServicos != obj.NotaFiscalServicos) return false;
            else if (this.IdEspecieRecebimento != obj.IdEspecieRecebimento) return false;
            else if (this.ValorEspecieRecebimento != obj.ValorEspecieRecebimento) return false;
            else if (this.QuantidadeParcelas != obj.QuantidadeParcelas) return false;

            //LISTAS GENÉRICAS
            if (this.Produtoservico.Count != obj.Produtoservico.Count)
                return false;
            else
            {
                foreach (LancamentoProdutoServicoDTO umprodutoservico in this.Produtoservico)
                {
                    try
                    {
                        if (!umprodutoservico.Equals(obj.Produtoservico.Find(delegate(LancamentoProdutoServicoDTO item) { return item.Produto.Id == umprodutoservico.Produto.Id; })))
                            return false;
                    }
                    catch { return false; }
                }
            }

            if (this.DetalhesFormaRecebimento.Count != obj.DetalhesFormaRecebimento.Count)
                return false;
            else
            {
                foreach (DetalheFormaRecebimento umdetalheformarecebimento in this.DetalhesFormaRecebimento)
                {
                    try
                    {
                        if (!umdetalheformarecebimento.Equals(obj.DetalhesFormaRecebimento.Find(delegate(DetalheFormaRecebimento item) { return item.Id == umdetalheformarecebimento.Id; })))
                            return false;
                    }
                    catch { return false; }
                }
            }

            return true;
        }
        #endregion
    }
}
