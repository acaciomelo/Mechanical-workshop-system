using System;

namespace MechTech.Entities
{
    [Serializable]
    public class DepartamentoDTO : IEquatable<DepartamentoDTO>
    {
        public DepartamentoDTO()
        { }

        public DepartamentoDTO(int codigo, string nome)
        {
            this.Codigo = codigo;
            this.Nome = nome;
        }

        public DepartamentoDTO(int id, int codigo, string nome)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Nome = nome;
        }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public DepartamentoDTO(DepartamentoDTO obj)
        {
            this.Id = obj.Id;
            this.Nome = obj.Nome;
            this.Endereco = obj.Endereco;
            this.Numero = obj.Numero;
            this.Complemento = obj.Complemento;
            this.Bairro = obj.Bairro;
            this.Cep = obj.Cep;
            this.Municipio = new MunicipioDTO(obj.Municipio);
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

        private string endereco = string.Empty;
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        private string numero = string.Empty;
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private string complemento = string.Empty;
        public string Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }

        private string bairro = string.Empty;
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        private string cep = string.Empty;
        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        private MunicipioDTO municipio = new MunicipioDTO();
        public MunicipioDTO Municipio
        {
            get { return municipio; }
            set { municipio = value; }
        }

        private int codigo = 0;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private int? codigoorigem = null;
        /// <summary>
        /// Cópia entre empresas da Configuração Contábil.
        /// </summary>
        public int? CodigoOrigem
        {
            get { return codigoorigem; }
            set { codigoorigem = value; }
        }

        #region IEquatable<DepartamentoDTO> Members
        public bool Equals(DepartamentoDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Nome != obj.Nome) return false;
            else if (this.Endereco != obj.Endereco) return false;
            else if (this.Numero != obj.Numero) return false;
            else if (this.Complemento != obj.Complemento) return false;
            else if (this.Bairro != obj.Bairro) return false;
            else if (this.Cep != obj.Cep) return false;
            else if (!this.Municipio.Equals(obj.Municipio)) return false;
            else if (this.Codigo != obj.Codigo) return false;

            return true;
        }

        public bool EqualsLogESocial(DepartamentoDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Nome != obj.Nome) return false;
            else if (this.Endereco != obj.Endereco) return false;
            else if (this.Numero != obj.Numero) return false;
            else if (this.Complemento != obj.Complemento) return false;
            else if (this.Bairro != obj.Bairro) return false;
            else if (this.Cep != obj.Cep) return false;
            else if (!this.Municipio.Equals(obj.Municipio)) return false;
            else if (this.Codigo != obj.Codigo) return false;

            return true;
        }

        #endregion
    }
}