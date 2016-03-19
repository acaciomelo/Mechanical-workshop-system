using System;

namespace MechTech.Entities
{
    [Serializable]
    public class FilialDTO
    {
        public FilialDTO()
        { }

        private int filial = 0;
        public int Filial
        {
            get { return filial; }
            set { filial = value; }
        }

        private string licenca = string.Empty;
        public string Licenca
        {
            get { return licenca; }
            set { licenca = value; }
        }

        private DateTime? vencimento = null;
        public DateTime? Vencimento
        {
            get { return vencimento; }
            set { vencimento = value; }
        }

        private string situacao = "N";
        public string Situacao
        {
            get { return situacao; }
            set { situacao = value; }
        }

        private string chave = string.Empty;
        public string Chave
        {
            get { return chave; }
            set { chave = value; }
        }

        private bool validacep = false;
        public bool Validacep
        {
            get { return validacep; }
            set { validacep = value; }
        }


    }
}