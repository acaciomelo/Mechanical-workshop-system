using System;

namespace MechTech.Entities
{
    [Serializable]
    public class CBODTO : IEquatable<CBODTO>
    {
        public CBODTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public CBODTO(CBODTO obj)
        {
            this.Id = obj.Id;
            this.Descricao = obj.Descricao;
            this.Codigo = obj.Codigo;
            this.Grupo = obj.Grupo;
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

        private string grupo = string.Empty;
        public string Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }

        #region IEquatable<CBODTO> Members
        public bool Equals(CBODTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Descricao != obj.Descricao) return false;
            else if (this.Codigo != obj.Codigo) return false;
            else if (this.Grupo != obj.Grupo) return false;

            return true;
        }
        #endregion
    }
}