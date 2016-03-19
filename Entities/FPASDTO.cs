using System;

namespace MechTech.Entities
{
    [Serializable]
    public class FPASDTO : IEquatable<FPASDTO>
    {
        public FPASDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public FPASDTO(FPASDTO obj)
        {
            this.Id = obj.Id;
            this.Descricao = obj.Descricao;
            this.Codigo = obj.Codigo;
            this.Adicional = obj.Adicional;
        }

        private int id = 0;
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

        private string codigo = string.Empty;
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string adicional = string.Empty;
        public string Adicional
        {
            get { return adicional; }
            set { adicional = value; }
        }

        #region IEquatable<FPASDTO> Members
        public bool Equals(FPASDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Descricao != obj.Descricao) return false;
            else if (this.Codigo != obj.Codigo) return false;
            else if (this.Adicional != obj.Adicional) return false;

            return true;
        }
        #endregion
    }
}
