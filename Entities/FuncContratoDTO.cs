using System;

namespace MechTech.Entities
{
    [Serializable]
    public class FuncContratoDTO : IEquatable<FuncContratoDTO>
    {
        public FuncContratoDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public FuncContratoDTO(FuncContratoDTO obj)
        {
            this.Id = obj.Id;
            this.Id_funcionario = obj.Id_funcionario;
            this.Dataadmissao = obj.Dataadmissao;
            this.Datademissao = obj.Datademissao;
            this.Datatransferencia = obj.Datatransferencia;
            this.Aprendiz = obj.Aprendiz;
            this.Alvara = obj.Alvara;
            this.Experienciainicio = obj.Experienciainicio;
            this.Experienciafim = obj.Experienciafim;
            this.Experienciaprorrogacao = obj.Experienciaprorrogacao;
            this.Vencexamemedico = obj.Vencexamemedico;
            this.Diadescanso = obj.Diadescanso;
            this.Tipo_adto = obj.Tipo_adto;
            this.Percentual_adto = obj.Percentual_adto;
            this.Valor_adto = obj.Valor_adto;
            this.DataPagtoRescisao = obj.DataPagtoRescisao;
            this.DiasExperienciaProrrogacao = obj.DiasExperienciaProrrogacao;
            this.DiasExperienciaFim = obj.DiasExperienciaFim;
            this.Empresa = obj.Empresa;
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_funcionario = 0;
        public int Id_funcionario
        {
            get { return id_funcionario; }
            set { id_funcionario = value; }
        }

        private DateTime? dataadmissao = null;
        public DateTime? Dataadmissao
        {
            get { return dataadmissao; }
            set { dataadmissao = value; }
        }

        private DateTime? datademissao = null;
        public DateTime? Datademissao
        {
            get { return datademissao; }
            set { datademissao = value; }
        }

        private DateTime? datatransferencia = null;
        public DateTime? Datatransferencia
        {
            get { return datatransferencia; }
            set { datatransferencia = value; }
        }
        private string empresa = string.Empty;
        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }


        private bool aprendiz = false;
        public bool Aprendiz
        {
            get { return aprendiz; }
            set { aprendiz = value; }
        }

        private bool alvara = false;
        public bool Alvara
        {
            get { return alvara; }
            set { alvara = value; }
        }

        private DateTime? experienciainicio = null;
        public DateTime? Experienciainicio
        {
            get { return experienciainicio; }
            set { experienciainicio = value; }
        }

        private DateTime? experienciafim = null;
        public DateTime? Experienciafim
        {
            get { return experienciafim; }
            set { experienciafim = value; }
        }

        private DateTime? experienciaprorrogacao = null;
        public DateTime? Experienciaprorrogacao
        {
            get { return experienciaprorrogacao; }
            set { experienciaprorrogacao = value; }
        }

        private DateTime? vencexamemedico = null;
        public DateTime? Vencexamemedico
        {
            get { return vencexamemedico; }
            set { vencexamemedico = value; }
        }

        private int diadescanso;
        public int Diadescanso
        {
            get { return diadescanso; }
            set { diadescanso = value; }
        }

        private string tipo_adto = string.Empty;
        public string Tipo_adto
        {
            get { return tipo_adto; }
            set { tipo_adto = value; }
        }

        private decimal percentual_adto = 0;
        public decimal Percentual_adto
        {
            get { return percentual_adto; }
            set { percentual_adto = value; }
        }

        private decimal valor_adto = 0;
        public decimal Valor_adto
        {
            get { return valor_adto; }
            set { valor_adto = value; }
        }

        private DateTime? datapagtorescisao = null;
        public DateTime? DataPagtoRescisao
        {
            get { return datapagtorescisao; }
            set { datapagtorescisao = value; }
        }

        private int diasexperienciaprorrogacao = 0;
        public int DiasExperienciaProrrogacao
        {
            get { return diasexperienciaprorrogacao; }
            set { diasexperienciaprorrogacao = value; }
        }

        private int diasexperienciafim = 0;
        public int DiasExperienciaFim
        {
            get { return diasexperienciafim; }
            set { diasexperienciafim = value; }
        }

        private DateTime? datademissaoajuste = null;
        public DateTime? DataDemissaoAjuste
        {
            get { return datademissaoajuste; }
            set { datademissaoajuste = value; }
        }
        #region IEquatable<FuncContratoDTO> Members
        public bool Equals(FuncContratoDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Id_funcionario != obj.Id_funcionario) return false;
            else if (this.Dataadmissao != obj.Dataadmissao) return false;
            else if (this.Datademissao != obj.Datademissao) return false;
            else if (this.Datatransferencia != obj.Datatransferencia) return false;
            else if (this.Aprendiz != obj.Aprendiz) return false;
            else if (this.Alvara != obj.Alvara) return false;
            else if (this.Experienciainicio != obj.Experienciainicio) return false;
            else if (this.Experienciafim != obj.Experienciafim) return false;
            else if (this.Experienciaprorrogacao != obj.Experienciaprorrogacao) return false;
            else if (this.Vencexamemedico != obj.Vencexamemedico) return false;
            else if (this.Diadescanso != obj.Diadescanso) return false;
            else if (this.Tipo_adto != obj.Tipo_adto) return false;
            else if (this.Percentual_adto != obj.Percentual_adto) return false;
            else if (this.Valor_adto != obj.Valor_adto) return false;
            else if (this.DataPagtoRescisao != obj.DataPagtoRescisao) return false;
            else if (this.DiasExperienciaProrrogacao != obj.DiasExperienciaProrrogacao) return false;
            else if (this.DiasExperienciaFim != obj.DiasExperienciaFim) return false;
            else if (this.Empresa != obj.Empresa) return false;

            return true;
        }

        #endregion
    }
}