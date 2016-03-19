using System;
using System.Collections.Generic;

namespace MechTech.Entities
{
    [Serializable]
    public class EstruturaTabelaDTO
    {
        public EstruturaTabelaDTO()
        { }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nometabela = string.Empty;
        public string Nometabela
        {
            get { return nometabela; }
            set { nometabela = value; }
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

        private List<EstruturaObjetoDTO> objetos = new List<EstruturaObjetoDTO>();
        public List<EstruturaObjetoDTO> Objetos
        {
            get { return objetos; }
            set { objetos = value; }
        }
    }
}