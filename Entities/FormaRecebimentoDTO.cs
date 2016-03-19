using MechTech.Entities.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechTech.Entities
{
    [Serializable]
    public class FormaRecebimentoDTO : Identificador
    {
        public FormaRecebimentoDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public FormaRecebimentoDTO(FormaRecebimentoDTO obj)
        {
            this.Id = obj.Id;
            this.IdOrcamento = obj.IdOrcamento;
            this.EspecieRecebimento = obj.EspecieRecebimento;
            this.Valor = obj.Valor;
            this.QuantidadeParcelas = obj.QuantidadeParcelas;
        }
        public override int Id { get; set; }
        public int IdOrcamento { get; set; }
        public string EspecieRecebimento { get; set; }
        public decimal Valor { get; set; }
        public int QuantidadeParcelas { get; set; }

    }
}
