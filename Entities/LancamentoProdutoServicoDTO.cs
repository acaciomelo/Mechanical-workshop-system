using System;

namespace MechTech.Entities
{
    [Serializable]
    public class LancamentoProdutoServicoDTO : IEquatable<LancamentoProdutoServicoDTO>
    {
        public LancamentoProdutoServicoDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public LancamentoProdutoServicoDTO(LancamentoProdutoServicoDTO obj)
        {
            this.Id = obj.Id;
            this.Id_orcamento = obj.Id_orcamento;
            this.Produto = new ProdutoServicoDTO(obj.Produto);
            this.Quantidade = obj.Quantidade;
            this.ValorUnitario = obj.ValorUnitario;
            this.ValorDesconto = obj.ValorDesconto;
            this.Tipo = obj.Tipo;
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_orcamento = 0;
        public int Id_orcamento
        {
            get { return id_orcamento; }
            set { id_orcamento = value; }
        }

        private ProdutoServicoDTO produto = new ProdutoServicoDTO();
        public ProdutoServicoDTO Produto
        {
            get { return produto; }
            set { produto = value; }
        }

        private int quantidade = 0;
        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        private decimal valorUnitario = 0;
        public decimal ValorUnitario
        {
            get { return valorUnitario; }
            set { valorUnitario = value; }
        }

        private decimal valorDesconto = 0;
        public decimal ValorDesconto
        {
            get { return valorDesconto; }
            set { valorDesconto = value; }
        }

        private decimal valorTotal = 0;
        public decimal ValorTotal
        {
            get { return valorTotal; }
            set { valorTotal = value; }
        }

        private decimal valorLiquido = 0;
        public decimal ValorLiquido
        {
            get { return valorLiquido; }
            set { valorLiquido = value; }
        }

        private string tipo = string.Empty;
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }


        #region IEquatable<LancamentoProdutoServicoDTO> Members
        public bool Equals(LancamentoProdutoServicoDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Id_orcamento != obj.Id_orcamento) return false;
            else if (!this.Produto.Equals(obj.Produto)) return false;
            else if (this.ValorUnitario != obj.ValorUnitario) return false;
            else if (this.valorDesconto != obj.valorDesconto) return false;
            else if (this.Tipo != obj.Tipo) return false;
            return true;
        }
        #endregion
    }
}
