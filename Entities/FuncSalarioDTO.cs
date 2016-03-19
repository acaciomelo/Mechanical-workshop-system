using System;

namespace MechTech.Entities
{
    [Serializable]
    public class FuncSalarioDTO : IEquatable<FuncSalarioDTO>
    {
        public FuncSalarioDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public FuncSalarioDTO(FuncSalarioDTO obj)
        {
            this.Id = obj.Id;
            this.Data = obj.Data;
            this.DataReajuste = obj.DataReajuste;
            this.Motivo = obj.Motivo;
            this.Id_funcionario = obj.Id_funcionario;
            this.Departamento = new DepartamentoDTO(obj.Departamento);
            this.Setor = new SetorDTO(obj.Setor);
            this.Secao = new SecaoDTO(obj.Secao);
            this.Funcao = new FuncaoDTO(obj.Funcao);
            this.Salario = obj.Salario;
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? data = null;
        public DateTime? Data
        {
            get { return data; }
            set { data = value; }
        }

        private DateTime? datareajuste = null;
        public DateTime? DataReajuste
        {
            get { return datareajuste; }
            set { datareajuste = value; }
        }

        private string motivo = string.Empty;
        public string Motivo
        {
            get { return motivo; }
            set { motivo = value; }
        }

        private int id_funcionario = 0;
        public int Id_funcionario
        {
            get { return id_funcionario; }
            set { id_funcionario = value; }
        }

        private DepartamentoDTO departamento = new DepartamentoDTO();
        public DepartamentoDTO Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        private SetorDTO setor = new SetorDTO();
        public SetorDTO Setor
        {
            get { return setor; }
            set { setor = value; }
        }

        private SecaoDTO secao = new SecaoDTO();
        public SecaoDTO Secao
        {
            get { return secao; }
            set { secao = value; }
        }

        private FuncaoDTO funcao = new FuncaoDTO();
        public FuncaoDTO Funcao
        {
            get { return funcao; }
            set { funcao = value; }
        }

        private decimal salario = 0;
        public decimal Salario
        {
            get { return salario; }
            set { salario = value; }
        }

        private decimal percentualReajuste = 0;
        public decimal PercentualReajuste
        {
            get { return percentualReajuste; }
            set { percentualReajuste = value; }
        }

        #region IEquatable<FuncSalarioDTO> Members
        public bool Equals(FuncSalarioDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Data != obj.Data) return false;
            else if (this.DataReajuste != obj.DataReajuste) return false;
            else if (this.Id_funcionario != obj.Id_funcionario) return false;
            else if (!this.Departamento.Equals(obj.Departamento)) return false;
            else if (!this.Setor.Equals(obj.Setor)) return false;
            else if (!this.Secao.Equals(obj.Secao)) return false;
            else if (!this.Funcao.Equals(obj.Funcao)) return false;
            else if (this.Salario != obj.Salario) return false;

            return true;
        }
        #endregion
    }
}
