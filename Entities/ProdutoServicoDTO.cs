using System;

namespace MechTech.Entities
{
    [Serializable]
    public class ProdutoServicoDTO : IEquatable<ProdutoServicoDTO>
    {
        public ProdutoServicoDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public ProdutoServicoDTO(ProdutoServicoDTO obj)
        {
            this.Id = obj.Id;
            this.CodBarras = obj.CodBarras;
            this.Descricao = obj.Descricao;
            this.Referencia = obj.Referencia;
            this.Referencia2 = obj.Referencia2;
            this.Unidade = obj.Unidade;
            this.Custo = obj.Custo;
            this.Venda = obj.Venda;
            this.TipoLucro = obj.TipoLucro;
            this.Categoria = obj.Categoria;
            this.Fornecedor = obj.Fornecedor;
            this.Localizacao = obj.Localizacao;
            this.EstoqueMinimo = obj.EstoqueMinimo;
            this.EstoqueAtual = obj.EstoqueAtual;
            this.UsadoEmVeic = obj.UsadoEmVeic;
            this.AnosParaUso = obj.AnosParaUso;
            this.Observacoes = obj.Observacoes;
            this.Aplicacao = obj.Aplicacao;
            this.Foto = obj.Foto;
            this.Produtoservico = obj.Produtoservico;
        }
        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string codBarras = string.Empty;
        public string CodBarras
        {
            get { return codBarras; }
            set { codBarras = value; }
        }

        private string descricao = string.Empty;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        private string referencia2 = string.Empty;
        public string Referencia2
        {
            get { return referencia2; }
            set { referencia2 = value; }
        }

        private string referencia = string.Empty;
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        private string unidade = string.Empty;
        public string Unidade
        {
            get { return unidade; }
            set { unidade = value; }
        }

        private double custo = 0;
        public double Custo
        {
            get { return custo; }
            set { custo = value; }
        }

        private double venda = 0;
        public double Venda
        {
            get { return venda; }
            set { venda = value; }
        }

        private string tipoLucro = string.Empty;
        public string TipoLucro
        {
            get { return tipoLucro; }
            set { tipoLucro = value; }
        }

        private FornecedorDTO fornecedor = null;
        public FornecedorDTO Fornecedor
        {
            get { return fornecedor; }
            set { fornecedor = value; }
        }

        private CategoriaProdutoDTO categoria = null;
        public CategoriaProdutoDTO Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private string localizacao = string.Empty;
        public string Localizacao
        {
            get { return localizacao; }
            set { localizacao = value; }
        }

        private int estoqueMinimo = 0;
        public int EstoqueMinimo
        {
            get { return estoqueMinimo; }
            set { estoqueMinimo = value; }
        }

        private int estoqueAtual = 0;
        public int EstoqueAtual
        {
            get { return estoqueAtual; }
            set { estoqueAtual = value; }
        }

        private string usadoEmVeic = string.Empty;
        public string UsadoEmVeic
        {
            get { return usadoEmVeic; }
            set { usadoEmVeic = value; }
        }

        private string anosParaUso = string.Empty;
        public string AnosParaUso
        {
            get { return anosParaUso; }
            set { anosParaUso = value; }
        }

        private string observacoes = string.Empty;
        public string Observacoes
        {
            get { return observacoes; }
            set { observacoes = value; }
        }

        private string aplicacao = string.Empty;
        public string Aplicacao
        {
            get { return aplicacao; }
            set { aplicacao = value; }
        }

        //Tarefa 22
        private byte[] foto = null;
        public byte[] Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        private int produtoservico = 0;
        public int Produtoservico
        {
            get { return produtoservico; }
            set { produtoservico = value; }
        }
     


        #region IEquatable<ProdutoServicoDTO> Members
        public bool Equals(ProdutoServicoDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.CodBarras != obj.CodBarras) return false;
            else if (this.Descricao != obj.Descricao) return false;
            else if (this.Referencia != obj.Referencia) return false;
            else if (this.Referencia2 != obj.Referencia2) return false;
            else if (this.Unidade != obj.Unidade) return false;
            else if (this.Custo != obj.Custo) return false;
            else if (this.Venda != obj.Venda) return false;
            else if (this.TipoLucro != obj.TipoLucro) return false;
            else if (this.Fornecedor != obj.Fornecedor) return false;
            else if (this.Categoria != obj.Categoria) return false;
            else if (this.Localizacao != obj.Localizacao) return false;
            else if (this.EstoqueMinimo != obj.EstoqueMinimo) return false;
            else if (this.EstoqueAtual != obj.EstoqueAtual) return false;
            else if (this.UsadoEmVeic != obj.UsadoEmVeic) return false;
            else if (this.AnosParaUso != obj.AnosParaUso) return false;
            else if (this.Observacoes != obj.Observacoes) return false;
            else if (this.Aplicacao != obj.Aplicacao) return false;
            else if (this.Foto != obj.Foto) return false;
            else if (this.Produtoservico != obj.Produtoservico) return false;
            return true;
        }
        #endregion
    }
}
