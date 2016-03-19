using System;

namespace MechTech.Entities
{
    [Serializable]
    public class EstruturaFuncaoDTO
    {
        public EstruturaFuncaoDTO()
        { }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nomefuncao = string.Empty;
        public string Nomefuncao
        {
            get { return nomefuncao; }
            set { nomefuncao = value; }
        }

        private string descricao = string.Empty;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        private string ddl = string.Empty;
        public string DDL
        {
            get { return ddl; }
            set { ddl = value; }
        }
    }
}