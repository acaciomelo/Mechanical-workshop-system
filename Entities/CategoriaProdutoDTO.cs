using System;

namespace MechTech.Entities
{
    [Serializable]
    public class CategoriaProdutoDTO : IEquatable<CategoriaProdutoDTO>
    {
        public CategoriaProdutoDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public CategoriaProdutoDTO(CategoriaProdutoDTO obj)
        {
            this.Id = obj.Id;
            this.Codigo = obj.Codigo;
            this.Nome = obj.Nome;
            this.Descricao = obj.Descricao;
        }
        private int codigo = 0;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
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

        private string descricao = string.Empty;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }


        #region IEquatable<CategoriaProdutoDTO> Members
        public bool Equals(CategoriaProdutoDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Codigo != obj.Codigo) return false;
            else if (this.Nome != obj.Nome) return false;
            else if (this.Descricao != obj.Descricao) return false;
            return true;
        }
        #endregion
    }
}