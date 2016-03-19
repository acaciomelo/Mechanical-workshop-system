using System;
using System.Collections.Generic;

namespace MechTech.Entities
{
    [Serializable]
    public class PerfilDTO
    {
        public PerfilDTO()
        { }

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

        private List<PerfilRotinaDTO> rotinas = new List<PerfilRotinaDTO>();
        public List<PerfilRotinaDTO> Rotinas
        {
            get { return rotinas; }
            set { rotinas = value; }
        }

        private bool selecao = false;
        public bool Selecao
        {
            get { return selecao; }
            set { selecao = value; }
        }
    }
}