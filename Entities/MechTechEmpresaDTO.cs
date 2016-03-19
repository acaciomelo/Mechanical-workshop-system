using System;

namespace MechTech.Entities
{
    [Serializable]
    public class MechTechEmpresaDTO
    {
        public MechTechEmpresaDTO()
        { }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private MechTechAtivaDTO MechTechativa = new MechTechAtivaDTO();
        public MechTechAtivaDTO MechTechAtiva
        {
            get { return MechTechativa; }
            set { MechTechativa = value; }
        }

        private string cnpj = string.Empty;
        public string CNPJ
        {
            get { return cnpj; }
            set { cnpj = value; }
        }
    }
}
