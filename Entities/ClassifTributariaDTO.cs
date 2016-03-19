using System;
using System.Collections.Generic;
using System.Text;

namespace MechTech.Entities
{
    [Serializable]
    public class ClassifTributariaDTO
    {
        public ClassifTributariaDTO()
        { }

        public ClassifTributariaDTO(ClassifTributariaDTO obj)
        {
            this.Id = obj.Id;
            this.Codigo = obj.Codigo;
            this.Descricao = obj.Descricao;
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string codigo = string.Empty;
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string descricao = string.Empty;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
