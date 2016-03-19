using System;

namespace MechTech.Entities
{
    [Serializable]
    public class PerfilRotinaDTO
    {
        public PerfilRotinaDTO()
        { }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_perfil = 0;
        public int Id_Perfil
        {
            get { return id_perfil; }
            set { id_perfil = value; }
        }

        private int id_rotina = 0;
        public int Id_Rotina
        {
            get { return id_rotina; }
            set { id_rotina = value; }
        }
    }
}