using System;

namespace MechTech.Entities
{
    [Serializable]
    public class SecaoDTO : IEquatable<SecaoDTO>
    {
        public SecaoDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public SecaoDTO(SecaoDTO obj)
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

        private int codigo = 0;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        #region IEquatable<SecaoDTO> Members
        public bool Equals(SecaoDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Nome != obj.Nome) return false;
            else if (this.Codigo != obj.Codigo) return false;

            return true;
        }
        #endregion
    }
}