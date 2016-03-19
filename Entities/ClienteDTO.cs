using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MechTech.Entities;

namespace MechTech.Entities
{
    [Serializable]
    public class ClienteDTO : IEquatable<ClienteDTO>
    {
        public ClienteDTO()
        {

        }

        public ClienteDTO(ClienteDTO obj)
        {
            this.Id = obj.Id;
            this.Nome = obj.Nome;
            this.DataCadastro = obj.DataCadastro;
            this.DataNasc = obj.DataNasc;
            this.Tipo_pessoa = obj.Tipo_pessoa;
            this.Telefone = obj.Telefone;
            this.Email = obj.Email;
            this.Endereco = obj.Endereco;
            this.Celular = obj.Celular;
            this.Cidade = new MunicipioDTO(obj.Cidade);
            this.Numero = obj.Numero;
            this.Bairro = obj.Bairro;
            this.Cep = obj.Cep;
            this.UF = obj.UF;
            this.Compl = obj.Compl;
            this.Cpf_Cnpj = obj.Cpf_Cnpj;
            this.Rg = obj.Rg;
            this.Emissor = obj.Emissor;
            this.Obs1 = obj.Obs1;
            this.Obs2 = obj.Obs2;
            this.Obs3 = obj.Obs3;
            this.Contato = obj.Contato;
            this.Profissao = obj.Profissao;
            this.Time = obj.Time;
            this.Passatempo = obj.Passatempo;
        }

        private int id = 0;
        public int Id {
            get { return id; } 
            set { id = value; } 
        }
        private string nome = string.Empty;
        public string Nome { 
            get { return nome; } 
            set { nome = value; }
        }

        private DateTime? datacadastro = null;
        public DateTime? DataCadastro 
        {
            get { return datacadastro; }
            set { datacadastro = value; }
        }

        public DateTime? datanasc = null;
        public DateTime? DataNasc 
        {
            get { return datanasc; }
            set { datanasc = value; } 
        }     
  
        public string tipo_pessoa = string.Empty;
        public string Tipo_pessoa 
        {
            get { return tipo_pessoa; }
            set { tipo_pessoa = value; } 
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
            set {numero = value;}
        }

        private string bairro = string.Empty;
        public string Bairro 
        {
            get { return bairro; }
            set { bairro = value; }
        }
        private MunicipioDTO cidade = new MunicipioDTO();
        public MunicipioDTO Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        private string compl = string.Empty;
        public string Compl 
        {
            get { return compl; }
            set { compl = value; }
        }

        private string telefone = string.Empty;
        public string Telefone 
        {
            get { return telefone; }
            set { telefone = value; } 
        }

        private string celular = string.Empty;
        public string Celular
        {
            get { return celular; }
            set { celular = value; } 
        }

        private string cep = string.Empty;
        public string Cep 
        {
            get { return cep; }
            set { cep = value; }
        }

        private string estado = string.Empty;
            public string Estado
            {
                get{return estado;}
                set{estado = value;}
            }

        private string uf = string.Empty;
        public string UF
        {
            get { return uf; }
            set { uf = value; }
        }

        private string email = string.Empty;
        public string Email 
        {
            get { return email; }
            set { email = value; }
        }

        private string cpf_cnpj = string.Empty;
        public string Cpf_Cnpj 
        {
            get { return cpf_cnpj; } 
            set {cpf_cnpj = value;}
        }

        private string rg = string.Empty;
        public string Rg
        {
            get { return rg; }
            set { rg = value; }
        }

        private string emissor = string.Empty;
        public string Emissor 
        {
            get { return emissor; }
            set { emissor = value; }
        }

        private string obs1 = string.Empty;
        public string Obs1 
        {
            get { return obs1; }
            set { obs1 = value; } 
        }

        private string obs2 = string.Empty;
        public string Obs2 
        {
            get { return obs2; }
            set { obs2 = value; } 
        }

        private string obs3 = string.Empty;
        public string Obs3 
        {
            get { return obs3; }
            set { obs3 = value; }
        }

        private string contato = string.Empty;
        public string Contato
        {
            get { return contato; }
            set { contato = value; }
        }

        private string profissao = string.Empty;
        public string Profissao
        {
            get { return profissao; }
            set { profissao = value; }
        }

        private string time = string.Empty;

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        private string passatempo = string.Empty;

        public string Passatempo
        {
            get { return passatempo; }
            set { passatempo = value; }
        }

        #region IEquatable<ClienteDTO> Members
        public bool Equals(ClienteDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Nome != obj.Nome) return false;
            else if (this.DataCadastro != obj.DataCadastro) return false;
            else if (this.DataNasc != obj.DataNasc) return false;
            else if (!this.Cidade.Equals(obj.Cidade)) return false;
            else if (this.Bairro != obj.Bairro) return false;
            else if (this.Celular != obj.Celular) return false;
            else if (this.Cep != obj.Cep) return false;
            else if (this.Compl != obj.Compl) return false;
            else if (this.Cpf_Cnpj != obj.Cpf_Cnpj) return false;
            else if (this.Email != obj.Email) return false;
            else if (this.Emissor != obj.Emissor) return false;
            else if (this.Endereco != obj.Endereco) return false;
            else if (this.Numero != obj.Numero) return false;
            else if (this.Rg != obj.Rg) return false;
            else if (this.Telefone != obj.Telefone) return false;
            else if (this.Celular != obj.Celular) return false;
            else if (this.UF != obj.UF) return false;
            else if (this.Obs1 != obj.Obs1) return false;
            else if (this.Obs2 != obj.Obs2) return false;
            else if (this.Obs3 != obj.Obs3) return false;
            else if (this.Cpf_Cnpj != obj.Cpf_Cnpj) return false;
            else if (this.Contato != obj.Contato) return false;
            else if (this.Time != obj.Time) return false;
            else if (this.Profissao != obj.Profissao) return false;
            else if (this.Passatempo != obj.Passatempo) return false;

            return true;
        }
        #endregion 
            
    }
}
