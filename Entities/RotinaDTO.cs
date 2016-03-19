using System;

namespace MechTech.Entities
{
    [Serializable]
    public class RotinaDTO
    {
        public RotinaDTO()
        { }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int indiceimagem = 0;
        public int Indiceimagem
        {
            get { return indiceimagem; }
            set { indiceimagem = value; }
        }

        private string descricao = string.Empty;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        private string nivel = string.Empty;
        public string Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        private string parentNivel = string.Empty;
        public string ParentNivel
        {
            get { return parentNivel; }
            set { parentNivel = value; }
        }

        private string assembler = string.Empty;
        public string Assembler
        {
            get { return assembler; }
            set { assembler = value; }
        }

        private string classe = string.Empty;
        public string Classe
        {
            get { return classe; }
            set { classe = value; }
        }

        private string metodo = string.Empty;
        public string Metodo
        {
            get { return metodo; }
            set { metodo = value; }
        }

        private bool ativaempresa = false;
        public bool Ativaempresa
        {
            get { return ativaempresa; }
            set { ativaempresa = value; }
        }

        private string acao = string.Empty;
        public string Acao
        {
            get { return acao; }
            set { acao = value; }
        }

        private bool menu = false;
        public bool Menu
        {
            get { return menu; }
            set { menu = value; }
        }

        private bool acesso = false;
        public bool Acesso
        {
            get { return acesso; }
            set { acesso = value; }
        }

        private bool log = false;
        public bool Log
        {
            get { return log; }
            set { log = value; }
        }
    }
}
