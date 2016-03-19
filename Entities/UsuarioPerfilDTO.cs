using System;

namespace MechTech.Entities
{
    [Serializable]
    public class UsuarioPerfilDTO
    {
        public UsuarioPerfilDTO()
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

        private int id_perfil = 0;
        public int Id_Perfil
        {
            get { return id_perfil; }
            set { id_perfil = value; }
        }
    }
}