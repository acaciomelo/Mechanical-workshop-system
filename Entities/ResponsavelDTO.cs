using System;
using System.Collections.Generic;
using System.Text;

namespace MechTech.Entities
{
    [Serializable]
    public class ResponsavelDTO
    {
        public ResponsavelDTO()
        { }

        public ResponsavelDTO(ResponsavelDTO obj)
        {
            this.Id = obj.Id;
            this.Nome = obj.Nome;
            this.Endereco = obj.Endereco;
            this.Numero = obj.Numero;
            this.Complemento = obj.Complemento;
            this.Bairro = obj.Bairro;
            this.Cep = obj.Cep;
            this.Municipio = new MunicipioDTO(Municipio);
            this.Dddtelefone = obj.Dddtelefone;
            this.Telefone = obj.Telefone;
            this.Dddfax = obj.Dddfax;
            this.Fax = obj.Fax;
            this.Dddcelular = obj.Dddcelular;
            this.Celular = obj.Celular;
            this.Email = obj.Email;
            this.Cnpj = obj.Cnpj;
            this.Cpf = obj.Cpf;
            this.Cei = obj.Cei;
            this.Nit = obj.Nit;
            this.Rg = obj.Rg;
            this.Rgemissor = obj.Rgemissor;
            this.UFRG = new UFDTO(UFRG);
            this.Numeroregistro = obj.Numeroregistro;
            this.UFNumeroRegistro = new UFDTO(UFRG);
            this.Contador = obj.Contador;
            this.Responsa = obj.Responsa;
            this.Cargo = obj.Cargo;
            this.Contato = obj.Contato;
            this.URL = obj.URL;
            this.InicioAtividade = obj.InicioAtividade;
            this.FimAtividade = obj.FimAtividade;
            this.DataNascimento = obj.DataNascimento;

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

        private string dddtelefone = string.Empty;
        public string Dddtelefone
        {
            get { return dddtelefone; }
            set { dddtelefone = value; }
        }

        private string telefone = string.Empty;
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        private string dddfax = string.Empty;
        public string Dddfax
        {
            get { return dddfax; }
            set { dddfax = value; }
        }

        private string fax = string.Empty;
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        private string dddcelular = string.Empty;
        public string Dddcelular
        {
            get { return dddcelular; }
            set { dddcelular = value; }
        }

        private string celular = string.Empty;
        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        private string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string cnpj = string.Empty;
        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        private string cpf = string.Empty;
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        private string cei = string.Empty;
        public string Cei
        {
            get { return cei; }
            set { cei = value; }
        }

        private string nit = string.Empty;
        public string Nit
        {
            get { return nit; }
            set { nit = value; }
        }

        private string rg = string.Empty;
        public string Rg
        {
            get { return rg; }
            set { rg = value; }
        }

        private string rgemissor = string.Empty;
        public string Rgemissor
        {
            get { return rgemissor; }
            set { rgemissor = value; }
        }

        private UFDTO ufrg = new UFDTO();
        public UFDTO UFRG
        {
            get { return ufrg; }
            set { ufrg = value; }
        }

        private string numeroregistro = string.Empty;
        public string Numeroregistro
        {
            get { return numeroregistro; }
            set { numeroregistro = value; }
        }

        private UFDTO ufnumeroregistro = new UFDTO();
        public UFDTO UFNumeroRegistro
        {
            get { return ufnumeroregistro; }
            set { ufnumeroregistro = value; }
        }

        private bool contador = false;
        public bool Contador
        {
            get { return contador; }
            set { contador = value; }
        }

        private bool responsa = false;
        public bool Responsa
        {
            get { return responsa; }
            set { responsa = value; }
        }

        private string cargo = string.Empty;
        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        private string contato = string.Empty;
        public string Contato
        {
            get { return contato; }
            set { contato = value; }
        }

        private string url = string.Empty;
        public string URL
        {
            get { return url; }
            set { url = value; }
        }

        private DateTime? inicioatividade = null;
        public DateTime? InicioAtividade
        {
            get { return inicioatividade; }
            set { inicioatividade = value; }
        }

        private DateTime? fimatividade = null;
        public DateTime? FimAtividade
        {
            get { return fimatividade; }
            set { fimatividade = value; }
        }

        private DateTime? datanascimento = null;
        public DateTime? DataNascimento
        {
            get { return datanascimento; }
            set { datanascimento = value; }
        }
    }
}