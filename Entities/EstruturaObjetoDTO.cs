using System;

namespace MechTech.Entities
{
    [Serializable]
    public class EstruturaObjetoDTO
    {
        public EstruturaObjetoDTO()
        { }

        private int id_estruturatabela = 0;
        public int Id_estruturatabela
        {
            get { return id_estruturatabela; }
            set { id_estruturatabela = value; }
        }

        private string nomeobjeto = string.Empty;
        public string Nomeobjeto
        {
            get { return nomeobjeto; }
            set { nomeobjeto = value; }
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