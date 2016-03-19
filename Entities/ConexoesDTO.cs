using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace MechTech.Entities
{
    [Serializable]
    public class ConexoesDTO
    {
        public ConexoesDTO() { }

        public ConexoesDTO(ConexoesDTO obj)
        {
            this.Usuario = obj.Usuario;
            this.Senha = obj.Senha;
            this.servidor = obj.Servidor;
            this.Porta = obj.Porta;
            this.Banco = obj.Banco;
            this.Empresa = obj.Empresa;
        }

        private string empresa = string.Empty;
        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        private string usuario = "";
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private string senha = "";

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        private string servidor = "";

        public string Servidor
        {
            get { return servidor; }
            set { servidor = value; }
        }
        private string porta = "";

        public string Porta
        {
            get { return porta; }
            set { porta = value; }
        }
        private string banco = "";

        public string Banco
        {
            get { return banco; }
            set { banco = value; }
        }
        private List<ConexoesDTO> conexoes = new List<ConexoesDTO>();
        public List<ConexoesDTO> Conexoes
        {
            get { return conexoes; }
            set { conexoes = value; }
        }

        #region BINARYSERIALIZER
        public void Serializar()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.Create("appConex.bin");

                Assembly assembly = Assembly.Load("MechTech.Util");
                Type classe = assembly.GetType("MechTech.Util.Global");
                MethodInfo metodo = classe.GetMethod("Crypt");
                foreach (ConexoesDTO umaconexao in this.Conexoes)
                {
                    umaconexao.Servidor = metodo.Invoke(null, new object[] { "C", umaconexao.Servidor, umaconexao.Empresa }).ToString();
                    umaconexao.Porta = metodo.Invoke(null, new object[] { "C", umaconexao.Porta, umaconexao.Empresa }).ToString();
                    umaconexao.Banco = metodo.Invoke(null, new object[] { "C", umaconexao.Banco, umaconexao.Empresa }).ToString();
                    umaconexao.Usuario = metodo.Invoke(null, new object[] { "C", umaconexao.Usuario, umaconexao.Empresa }).ToString();
                    umaconexao.Senha = metodo.Invoke(null, new object[] { "C", umaconexao.Senha, umaconexao.Empresa }).ToString();
                }

                bf.Serialize(fs, this.Conexoes);
                fs.Close();
            }
            catch { }
        }

        public List<ConexoesDTO> Deserializar()
        {
            FileStream fs = null;
            List<ConexoesDTO> conexoes = new List<ConexoesDTO>();
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                fs = File.OpenRead("appConex.bin");
                conexoes = (List<ConexoesDTO>)bf.Deserialize(fs);

                Assembly assembly = Assembly.Load("MechTech.Util");
                Type classe = assembly.GetType("MechTech.Util.Global");
                MethodInfo metodo = classe.GetMethod("Crypt");
                foreach (ConexoesDTO umaconexao in conexoes)
                {
                    umaconexao.Servidor = metodo.Invoke(null, new object[] { "D", umaconexao.Servidor, umaconexao.Empresa }).ToString();
                    umaconexao.Porta = metodo.Invoke(null, new object[] { "D", umaconexao.Porta, umaconexao.Empresa }).ToString();
                    umaconexao.Banco = metodo.Invoke(null, new object[] { "D", umaconexao.Banco, umaconexao.Empresa }).ToString();
                    umaconexao.Usuario = metodo.Invoke(null, new object[] { "D", umaconexao.Usuario, umaconexao.Empresa }).ToString();
                    umaconexao.Senha = metodo.Invoke(null, new object[] { "D", umaconexao.Senha, umaconexao.Empresa }).ToString();
                }

                fs.Close();
            }
            catch
            {
                if (fs != null)
                    fs.Close();
            }
            return conexoes;
        }
        #endregion
    }
}
