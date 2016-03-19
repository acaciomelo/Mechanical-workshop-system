namespace MechTech.Util
{
    public sealed class Rotina
    {
        public Rotina()
        { }

        public Rotina(int id)
        {
            this.Id = id;
        }


        public Rotina(int id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string descricao = string.Empty;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}