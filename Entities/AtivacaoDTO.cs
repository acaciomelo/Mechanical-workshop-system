using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechTech.Entities
{
    public class AtivacaoDTO
    {
        public AtivacaoDTO()
        {

        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime dataativ = DateTime.Today;
        public DateTime Dataativ
        {
            get { return dataativ; }
            set { dataativ = value; }
        }

        public string razao_social = string.Empty;
        public string Razao_social
        {
            get { return razao_social; }
            set { razao_social = value; }
        }

        private string nome_fantasia = string.Empty;

        public string Nome_fantasia
        {
            get { return nome_fantasia; }
            set { nome_fantasia = value; }
        }

        private string ie = string.Empty;

        public string Ie
        {
            get { return ie; }
            set { ie = value; }
        }

        private string cnpj = string.Empty;

        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        private string cep = string.Empty;

        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        private string telefone = string.Empty;

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        private string email = string.Empty;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string contato = string.Empty;

        public string Contato
        {
            get { return contato; }
            set { contato = value; }
        }

        private string tel_contato = string.Empty;

        public string Tel_contato
        {
            get { return tel_contato; }
            set { tel_contato = value; }
        }

        private string email_contato = string.Empty;

        public string Email_contato
        {
            get { return email_contato; }
            set { email_contato = value; }
        }
    }
}
