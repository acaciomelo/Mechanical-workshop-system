using System;

namespace MechTech.Entities
{
    [Serializable]
    public class MunicipioDTO : IEquatable<MunicipioDTO>
    {
        public MunicipioDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public MunicipioDTO(MunicipioDTO obj)
        {
            this.Id = obj.Id;
            this.Nome = obj.Nome;
            this.Codigoibge = obj.Codigoibge;
            this.Codigosrfb = obj.Codigosrfb;
            this.UF = new UFDTO(obj.UF);
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

        private int codigoibge = 0;
        public int Codigoibge
        {
            get { return codigoibge; }
            set { codigoibge = value; }
        }

        private int codigosrfb = 0;
        public int Codigosrfb
        {
            get { return codigosrfb; }
            set { codigosrfb = value; }
        }

        private UFDTO _UF = new UFDTO();
        public UFDTO UF
        {
            get { return _UF; }
            set { _UF = value; }
        }

        #region IEquatable<MunicipioDTO> Members
        public bool Equals(MunicipioDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Nome != obj.Nome) return false;
            else if (this.Codigoibge != obj.Codigoibge) return false;
            else if (this.Codigosrfb != obj.Codigosrfb) return false;
            else if (!this.UF.Equals(obj.UF)) return false;

            return true;
        }
        #endregion
    }
}