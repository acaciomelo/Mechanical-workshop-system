using System;

namespace MechTech.Entities
{
    /// <summary>
    /// Motor de busca de orçamentos com auto-desempenho
    /// </summary>
    /// 
    [Serializable]
    public class OrcamentoProdutoServicoDTO : IEquatable<OrcamentoProdutoServicoDTO>
    {
        public OrcamentoProdutoServicoDTO()
        { }

        public int Id { get; set; }
        public int Id_orcamento { get; set; }
        public string Cliente { get; set; }
        public string Posicao { get; set; }
        public int Id_cliente { get; set; }
        public DateTime ?DataOrcamento { get; set; }

        #region IEquatable<OrcamentoProdutoServicoDTO> Members
        public bool Equals(OrcamentoProdutoServicoDTO obj)
        {
            if (this.Id != obj.Id) return false;
            if (this.Id_orcamento != obj.Id_orcamento) return false;
            if (this.Posicao != obj.Posicao) return false;
            if (this.Cliente != obj.Cliente) return false;
            if (this.DataOrcamento != obj.DataOrcamento) return false;
            if (this.Id_cliente != obj.Id_cliente) return false;

            return true;
        }
        #endregion
    }
}