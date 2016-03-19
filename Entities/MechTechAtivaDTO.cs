using System;

namespace MechTech.Entities
{
    [Serializable]
    public class MechTechAtivaDTO
    {
        public MechTechAtivaDTO()
        { }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int filial = 0;
        public int Filial
        {
            get { return filial; }
            set { filial = value; }
        }

        private string licenca = string.Empty;
        public string Licenca
        {
            get { return licenca; }
            set { licenca = value; }
        }
    }
}
