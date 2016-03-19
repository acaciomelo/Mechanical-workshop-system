using System;

namespace MechTech.Util
{
    public sealed class Meses : IComparable<Meses>
    {
        public Meses()
        { }

        public Meses(int mes)
        {
            this.Mes = mes;
        }

        public Meses(int mes, string descricao)
        {
            this.Mes = mes;
            this.Descricao = descricao;
        }

        private int mes = 0;
        public int Mes
        {
            get { return mes; }
            set { mes = value; }
        }

        private string descricao = string.Empty;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        #region IComparable<Meses> Members
        public int CompareTo(Meses other)
        {
            /*
            -1 -> Atual menor que o comparado
            0  -> Atual igual ao comparado
            1  -> Atual maior que o comparado
            */

            if (this.Mes < other.Mes)
                return -1;
            else
                return 1;
        }
        #endregion
    }
}
