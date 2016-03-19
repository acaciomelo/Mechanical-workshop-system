using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechTech.Atualizacao.Entities
{
    public class ScriptDTO
    {

        private string versao = string.Empty;
        public string Versao
        {
            get { return versao; }
            set { versao = value; }
        }

        private string modulo = string.Empty;
        public string Modulo
        {
            get { return modulo; }
            set { modulo = value; }
        }

        private int id_script = 0;
        public int Id_script
        {
            get { return id_script; }
            set { id_script = value; }
        }
        
        private int id_pacote = 0;
        public int Id_pacote
        {
            get { return id_pacote; }
            set { id_pacote = value; }
        }

        private string script = string.Empty;
        public string Script
        {
            get { return script; }
            set { script = value; }
        }

        private bool executado = false;
        public bool Executado
        {
            get { return executado; }
            set { executado = value; }
        }

        private string erro = string.Empty;

        public string Erro
        {
            get { return erro; }
            set { erro = value; }
        }
    }
}
