namespace MechTech.Util
{
    public sealed class Semana
    {
        public Semana()
        { }

        public Semana(int dia)
        {
            this.Dia = dia;
        }

        public Semana(int dia, string descricao)
        {
            this.Dia = dia;
            this.Descricao = descricao;
        }

        private int dia = 0;
        public int Dia
        {
            get { return dia; }
            set { dia = value; }
        }

        private string descricao = string.Empty;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
