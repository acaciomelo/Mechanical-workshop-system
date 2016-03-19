using System;

namespace MechTech.Entities
{
    [Serializable]
    public class UsuarioDTO
    {
        public UsuarioDTO()
        { }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nome = string.Empty;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private bool ativo = false;
        public bool Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }

        private bool mechtechativo = true;
        public bool Mechtechativo
        {
            get { return mechtechativo; }
            set { mechtechativo = value; }
        }
        
        private string login = string.Empty;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string senha = string.Empty;
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        private bool supervisor = false;
        public bool Supervisor
        {
            get { return supervisor; }
            set { supervisor = value; }
        }

        private bool modulo = false;
        public bool Modulo
        {
            get { return modulo; }
            set { modulo = value; }
        }
    }
}