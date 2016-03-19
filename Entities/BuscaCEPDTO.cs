using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechTech.Entities
{

    [Serializable]
    public class BuscaCEPDTO
    {

        public BuscaCEPDTO()
        {
        }

        private string cep = string.Empty;
        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        private string uf = string.Empty;
        public string Uf
        {
            get { return uf; }
            set { uf = value; }
        }


        private int codMun = 0;
        public int CodMun
        {
            get { return codMun; }
            set { codMun = value; }
        }

        private string municipio = string.Empty;
        public string Municipio
        {
            get { return municipio; }
            set { municipio = value; }
        }

        private string endereco = string.Empty;
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        private string bairro = string.Empty;
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }





    }


}
