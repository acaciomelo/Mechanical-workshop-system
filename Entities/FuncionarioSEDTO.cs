using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechTech.Entities
{
    /// <summary>
    /// Motor de busca de funcionários com auto-desempenho (Cadastro de Funcionários, Movimentações).
    /// </summary>
    [Serializable]
    public class FuncionarioSEDTO
    {
        /// <summary>
        /// Inicializador padrão.
        /// </summary>
        public FuncionarioSEDTO()
        { }

        private int id = 0;
        /// <summary>
        /// Identificação padrão.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nomecompleto = string.Empty;
        public string NomeCompleto
        {
            get { return nomecompleto; }
            set { nomecompleto = value; }
        }

        private string funcao = string.Empty;
        public string Funcao
        {
            get { return funcao; }
            set { funcao = value; }
        }

        private string situacao = string.Empty;
        /// <summary>
        /// Admitido, Demitido, Afastado, etc.
        /// </summary>
        public string Situacao
        {
            get { return situacao; }
            set { situacao = value; }
        }

        public DateTime DataAdmissao { get; set; }

        private DateTime? datademissao = null;
        public DateTime? DataDemissao
        {
            get { return datademissao; }
            set { datademissao = value; }
        }
        private DateTime? datademissaoajuste = null;
        public DateTime? DataDemissaoAjuste
        {
            get { return datademissaoajuste; }
            set { datademissaoajuste = value; }
        }
    }
}