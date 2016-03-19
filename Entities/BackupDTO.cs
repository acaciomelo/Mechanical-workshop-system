using System;

namespace MechTech.Entities
{

    [Serializable]
    public class BackupDTO
    {
        public BackupDTO()
        { }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime data = DateTime.Parse("01/01/1990");
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        public TimeSpan Hora { get; set; }

        private string usuario = string.Empty;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string maquina = string.Empty;
        public string Maquina
        {
            get { return maquina; }
            set { maquina = value; }
        }

        private string nomedados = string.Empty;
        public string Nomedados
        {
            get { return nomedados; }
            set { nomedados = value; }
        }

        private string nomeempresa = string.Empty;
        public string Nomeempresa
        {
            get { return nomeempresa; }
            set { nomeempresa = value; }
        }

        private int tamanho = 0;
        public int Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; }
        }

        private string versao = string.Empty;
        public string Versao
        {
            get { return versao; }
            set { versao = value; }
        }

        private string banco = string.Empty;
        public string Banco
        {
            get { return banco; }
            set { banco = value; }
        }
    }
}
