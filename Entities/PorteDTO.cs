using System;

namespace MechTech.Entities
{
    [Serializable]
    public class PorteDTO : IEquatable<PorteDTO>
    {
        public PorteDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public PorteDTO(PorteDTO obj)
        {
            this.Id = obj.Id;
            this.Descricao = obj.Descricao;
            this.Codigo = obj.Codigo;
        }

        private int id = 3;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string descricao = string.Empty;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        private string codigo = "3";
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        #region IEquatable<PorteDTO> Members
        public bool Equals(PorteDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Descricao != obj.Descricao) return false;
            else if (this.Codigo != obj.Codigo) return false;

            return true;
        }
        #endregion
    }
}