using System;

namespace MechTech.Entities
{
    [Serializable]
    public class SalarioTipoDTO : IEquatable<SalarioTipoDTO>
    {
        public SalarioTipoDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public SalarioTipoDTO(SalarioTipoDTO obj)
        {
            this.Id = obj.Id;
            this.Descricao = obj.Descricao;
        }

        private int id = 1;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string descricao = "Mensalista";
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        #region IEquatable<SalarioTipoDTO> Members
        public bool Equals(SalarioTipoDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Descricao != obj.Descricao) return false;

            return true;
        }
        #endregion
    }
}
