using System;

namespace MechTech.Entities
{
    [Serializable]
    public class BancoDTO : IEquatable<BancoDTO>
    {
        public BancoDTO()
        { }

        public BancoDTO(string codigo)
        {
            this.Codigo = codigo;
        }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public BancoDTO(BancoDTO obj)
        {
            this.Id = obj.Id;
            this.Nome = obj.Nome;
            this.Codigo = obj.Codigo;
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nome = string.Empty;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string codigo = string.Empty;
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        #region IEquatable<BancoDTO> Members
        public bool Equals(BancoDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Nome != obj.Nome) return false;
            else if (this.Codigo != obj.Codigo) return false;

            return true;
        }
        #endregion
    }
}