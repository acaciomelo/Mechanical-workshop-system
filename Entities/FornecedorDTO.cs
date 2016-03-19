using System;
using System.Collections.Generic;
using System.Text;

namespace MechTech.Entities
{
    [Serializable]
    public class FornecedorDTO : IEquatable<FornecedorDTO>
    {
        public FornecedorDTO()
        { }

        public FornecedorDTO(FornecedorDTO obj)
        {
            this.Id = obj.Id;
            this.Nomefantasia = obj.Nomefantasia;
            this.Razaosocial = obj.Razaosocial;
            this.Endereco = obj.Endereco;
            this.Numero = obj.Numero;
            this.Complemento = obj.Complemento;
            this.Bairro = obj.Bairro;
            this.Cep = obj.Cep;
            this.Municipio = new MunicipioDTO(obj.Municipio);
            this.Dddtelefone = obj.Dddtelefone;
            this.Telefone = obj.Telefone;
            this.Dddfax = obj.Dddfax;
            this.Fax = obj.Fax;
            this.Cnpj = obj.Cnpj;
            this.Cei = obj.Cei;
            this.Iestadual = obj.Iestadual;
            this.Imunicipal = obj.Imunicipal;
            this.Url = obj.Url;
            this.Email = obj.Email;
            this.Dirf = obj.Dirf;
            this.Registro = obj.Registro;
            //Tarefa 22
            this.RamoAtividade = obj.RamoAtividade;
            this.NomeContato = obj.NomeContato;
            this.EmailContato = obj.EmailContato;
            this.DDDTelContato = obj.DDDTelContato;
            this.TelContato = obj.TelContato;
            this.DDDCelContato = obj.DDDCelContato;
            this.CelContato = obj.CelContato;
            this.RamalContato = obj.RamalContato;
            //
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nomefantasia = string.Empty;
        public string Nomefantasia
        {
            get { return nomefantasia; }
            set { nomefantasia = value; }
        }

        private string razaosocial = string.Empty;
        public string Razaosocial
        {
            get { return razaosocial; }
            set { razaosocial = value; }
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

        private string cnpj = string.Empty;
        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        private string cei = string.Empty;
        public string Cei
        {
            get { return cei; }
            set { cei = value; }
        }

        private string iestadual = string.Empty;
        public string Iestadual
        {
            get { return iestadual; }
            set { iestadual = value; }
        }

        private string imunicipal = string.Empty;
        public string Imunicipal
        {
            get { return imunicipal; }
            set { imunicipal = value; }
        }

        private string url = string.Empty;
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private bool dirf = false;
        public bool Dirf
        {
            get { return dirf; }
            set { dirf = value; }
        }

        private string registro = string.Empty;
        public string Registro
        {
            get { return registro; }
            set { registro = value; }
        }
        private string ramoAtividade = string.Empty;
        public string RamoAtividade
        {
            get { return ramoAtividade; }
            set { ramoAtividade = value; }
        }

        //Tarefa 22
        private string nomeContato = string.Empty;

        public string NomeContato
        {
            get { return nomeContato; }
            set { nomeContato = value; }
        }
        private string emailContato = string.Empty;

        public string EmailContato
        {
            get { return emailContato; }
            set { emailContato = value; }
        }

        private string DDDtelContato = string.Empty;
        public string DDDTelContato
        {
            get { return DDDtelContato; }
            set { DDDtelContato = value; }
        }

        private string telContato = string.Empty;

        public string TelContato
        {
            get { return telContato; }
            set { telContato = value; }
        }
        private string DDDcelContato = string.Empty;

        public string DDDCelContato
        {
            get { return DDDcelContato; }
            set { DDDcelContato = value; }
        }
        private string celContato = string.Empty;

        public string CelContato
        {
            get { return celContato; }
            set { celContato = value; }
        }
        private string ramalContato = string.Empty;

        public string RamalContato
        {
            get { return ramalContato; }
            set { ramalContato = value; }
        }
        //

        public bool Equals(FornecedorDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Nomefantasia != obj.Nomefantasia) return false;
            else if (this.Razaosocial != obj.Razaosocial) return false;
            else if (this.Endereco != obj.Endereco) return false;
            else if (this.Numero != obj.Numero) return false;
            else if (this.Complemento != obj.Complemento) return false;
            else if (this.Bairro != obj.Bairro) return false;
            else if (this.Cep != obj.Cep) return false;
            else if (!this.Municipio.Equals(obj.Municipio)) return false;
            else if (this.Dddtelefone != obj.Dddtelefone) return false;
            else if (this.Telefone != obj.Telefone) return false;
            else if (this.Dddfax != obj.Dddfax) return false;
            else if (this.Fax != obj.Fax) return false;
            else if (this.Cnpj != obj.Cnpj) return false;
            else if (this.Cei != obj.Cei) return false;
            else if (this.Iestadual != obj.Iestadual) return false;
            else if (this.Imunicipal != obj.Imunicipal) return false;
            else if (this.Url != obj.Url) return false;
            else if (this.Email != obj.Email) return false;
            else if (this.Dirf != obj.Dirf) return false;
            else if (this.Registro != obj.Registro) return false;
            else if (this.RamoAtividade != obj.RamoAtividade) return false;
            else if (this.NomeContato != obj.NomeContato) return false;
            else if (this.EmailContato != obj.EmailContato) return false;
            else if (this.DDDTelContato != obj.DDDTelContato) return false;
            else if (this.TelContato != obj.TelContato) return false;
            else if (this.DDDCelContato != obj.DDDCelContato) return false;
            else if (this.CelContato != obj.CelContato) return false;
            else if (this.RamalContato != obj.RamalContato) return false;
            return true;
        }
    }
}
