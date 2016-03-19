using System;

namespace MechTech.Entities
{
    [Serializable]
    public class FeriadoDTO
    {
        public FeriadoDTO()
        { }


        public FeriadoDTO(FeriadoDTO obj)
        {

            this.Id = obj.Id;
            this.UF = obj.UF;
            this.Municipio = obj.Municipio;
            this.Descricao = obj.Descricao;
            this.Tipo = obj.Tipo;
            this.Especie = obj.Especie;
            this.Data = obj.Data;
            this.Observacao = obj.Observacao;
            this.Repete = obj.Repete;
            this.Termina = obj.Termina;
            this.TerminaAno = obj.TerminaAno;

        }


        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private UFDTO uf = new UFDTO();
        public UFDTO UF
        {
            get { return uf; }
            set { uf = value; }
        }

        private MunicipioDTO municipio = new MunicipioDTO();
        public MunicipioDTO Municipio
        {
            get { return municipio; }
            set { municipio = value; }
        }

        private string descricao = string.Empty;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        private string tipo = string.Empty;
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private string especie = string.Empty;
        public string Especie
        {
            get { return especie; }
            set { especie = value; }
        }

        private DateTime? data = null;
        public DateTime? Data
        {
            get { return data; }
            set { data = value; }
        }

        private string observacao = string.Empty;
        public string Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }

        
        private bool repete = false;
        public bool Repete
        {
            get { return repete; }
            set { repete = value; }
        }

        private bool termina = false;
        public bool Termina
        {
            get { return termina; }
            set { termina = value; }
        }

        private int terminaAno = int.Parse(DateTime.Now.ToString("yyyy"));
        public int TerminaAno
        {
            get { return terminaAno; }
            set { terminaAno = value; }
        }
    }
}
