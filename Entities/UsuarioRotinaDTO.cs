using System;

namespace MechTech.Entities
{
    [Serializable]
    public class UsuarioRotinaDTO
    {
        public UsuarioRotinaDTO()
        { }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_usuario = 0;
        public int Id_Usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        private int id_rotina = 0;
        public int Id_Rotina
        {
            get { return id_rotina; }
            set { id_rotina = value; }
        }
    }
}