using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechTech.Entities
{
    [Serializable]
    public class CpArqDbDTO
    {
        public CpArqDbDTO()
        { }

        private string path = string.Empty;
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        private string arquivo = string.Empty;
        public string Arquivo
        {
            get { return arquivo; }
            set { arquivo = value; }
        }

        private string hash = string.Empty;
        public string Hash
        {
            get { return hash; }
            set { hash = value; }
        }
    }
}
