using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechTech.Entities
{
    public class FuncPesquisaDTO
    {
        public FuncPesquisaDTO()
        { }

        public FuncPesquisaDTO(bool documento, bool contrato, bool sindicato, bool parentesco, bool salario, bool alteracao, bool automatico, bool afastamento, bool cat, bool ferias, bool rra, bool exames)
        {
            this.Documento = documento;
            this.Contrato = contrato;
            this.Sindicato = sindicato;
            this.Parentesco = parentesco;
            this.Salario = salario;
            this.Alteracao = alteracao;
            this.Automatico = automatico;
            this.Afastamento = afastamento;
            this.Cat = cat;
            this.Ferias = ferias;
            this.Rra = rra;
            this.ExameMedico = exames;
        }

        private bool documento = false;
        public bool Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        private bool contrato = false;
        public bool Contrato
        {
            get { return contrato; }
            set { contrato = value; }
        }

        private bool sindicato = false;
        public bool Sindicato
        {
            get { return sindicato; }
            set { sindicato = value; }
        }

        private bool parentesco = false;
        public bool Parentesco
        {
            get { return parentesco; }
            set { parentesco = value; }
        }

        private bool salario = false;
        public bool Salario
        {
            get { return salario; }
            set { salario = value; }
        }

        private bool alteracao = false;
        public bool Alteracao
        {
            get { return alteracao; }
            set { alteracao = value; }
        }

        private bool automatico = false;
        public bool Automatico
        {
            get { return automatico; }
            set { automatico = value; }
        }

        private bool afastamento = false;
        public bool Afastamento
        {
            get { return afastamento; }
            set { afastamento = value; }
        }

        private bool cat = false;
        public bool Cat
        {
            get { return cat; }
            set { cat = value; }
        }

        private bool ferias = false;
        public bool Ferias
        {
            get { return ferias; }
            set { ferias = value; }
        }

        private bool rra = false;
        public bool Rra
        {
            get { return rra; }
            set { rra = value; }
        }

        private bool exameMedico = false;
        public bool ExameMedico
        {
            get { return exameMedico; }
            set { exameMedico = value; }
        }
    }
}
