using System;

namespace MechTech.Entities
{
    [Serializable]
    public class FuncaoDTO : IEquatable<FuncaoDTO>
    {
        public FuncaoDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public FuncaoDTO(FuncaoDTO obj)
        {
            this.Id = obj.Id;
            this.CBO = new CBODTO(obj.CBO);
            this.Nome = obj.Nome;
            this.Salariofuncao = obj.Salariofuncao;
            this.Salariotipo = new SalarioTipoDTO(obj.Salariotipo);
            this.Horas = obj.Horas;
            this.Atividade = obj.Atividade;
            this.Cargo = obj.Cargo;
            this.CalculoHoras = obj.CalculoHoras;
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private CBODTO cbo = new CBODTO();
        public CBODTO CBO
        {
            get { return cbo; }
            set { cbo = value; }
        }

        private string nome = string.Empty;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private decimal salariofuncao = 0;
        public decimal Salariofuncao
        {
            get { return salariofuncao; }
            set { salariofuncao = value; }
        }

        private SalarioTipoDTO salariotipo = new SalarioTipoDTO();
        public SalarioTipoDTO Salariotipo
        {
            get { return salariotipo; }
            set { salariotipo = value; }
        }

        private int horas = 220;
        public int Horas
        {
            get { return horas; }
            set { horas = value; }
        }

        private bool calculohoras = false;
        public bool CalculoHoras
        {
            get { return calculohoras; }
            set { calculohoras = value; }
        }

        private string atividade = string.Empty;
        public string Atividade
        {
            get { return atividade; }
            set { atividade = value; }
        }

        private string cargo = string.Empty;
        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }


        #region IEquatable<FuncaoDTO> Members
        public bool Equals(FuncaoDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (!this.CBO.Equals(obj.CBO)) return false;
            else if (this.Nome != obj.Nome) return false;
            else if (this.Salariofuncao != obj.Salariofuncao) return false;
            else if (!this.Salariotipo.Equals(obj.Salariotipo)) return false;
            else if (this.Horas != obj.Horas) return false;
            else if (this.Atividade != obj.Atividade) return false;
            else if (this.Cargo != obj.Cargo) return false;
            else if (this.CalculoHoras != obj.CalculoHoras) return false;
            return true;
        }

        public bool EqualsLogESocial(FuncaoDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.cbo.Codigo != obj.cbo.Codigo) return false;
            else if (this.Nome != obj.Nome) return false;

            return true;
        }
        #endregion
    }
}