using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.CSharp;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;

namespace MechTech.Util
{
    public sealed class Global
    {
        public delegate void Synchronizer();
        public delegate void SystemDelegate(object obj);


        private static Enumeradores.Sistema sistema;
        /// <summary>
        /// Representa qual Sistema está em uso.
        /// </summary>
        public static Enumeradores.Sistema Sistema
        {
            get { return Global.sistema; }
            set { Global.sistema = value; }
        }

        private static Enumeradores.TipoConexao tpConexao = Enumeradores.TipoConexao.LAN;
        /// <summary>
        /// Representa um enumerador indicando se a conexão é LAN ou Remota.
        /// </summary>
        public static Enumeradores.TipoConexao TpConexao
        {
            get { return Global.tpConexao; }
            set { Global.tpConexao = value; }
        }

        private static string mainform = "frmPrincipal";
        /// <summary>
        /// Representa o mainform físico ativo.
        /// </summary>
        public static string MainForm
        {
            get { return Global.mainform; }
            set { Global.mainform = value; }
        }

        private static string skin = "Black";
        /// <summary>
        /// Representa a "pele" do Sistema.
        /// </summary>
        public static string Skin
        {
            get { return Global.skin; }
            set { Global.skin = value; }
        }

        private static string driverede = string.Empty;
        /// <summary>
        /// Representa a unidade de rede onde o Mirror.exe está sendo executado. (Ex.: X:, Y:, Z:)
        /// </summary>
        public static string DriveRede
        {
            get { return Global.driverede; }
            set { Global.driverede = value; }
        }

        private static string localpath = string.Empty;
        /// <summary>
        /// Representa a unidade de local podendo ser C: ou a indicada pelo Terminal Service (Shim)
        /// </summary>
        public static string LocalPath
        {
            get { return Global.localpath; }
            set { Global.localpath = value; }
        }

        private static Icon iconesistema;
        /// <summary>
        /// Representa o ícone padrão utilizado no Sistema.
        /// </summary>
        /// 
        //public static Icon IconeSistema
        //{
        //    get
        //    {
        //        Assembly fileEmbedded = Assembly.GetExecutingAssembly();

        //        if (Global.Sistema == Enumeradores.Sistema.MECHTECH)
        //            //Global.iconesistema = new Icon(fileEmbedded.GetManifestResourceStream("MechTech.Util.Images.Icons")); //TODO ATUALIZAR ÍCONE

        //        return Global.iconesistema;
        //    }
        //}

        private static string versaosistema = "1.00.0000";
        public static string VersaoSistema
        {
            get
            {
                try
                {
                    //MÓDULO DA VERSÃO
                    //string modulo = "0";
                    //if (DriveRede != string.Empty)
                    //{
                    //    string line;
                    //    using (StreamReader file = new StreamReader(DriveRede + "\\Sistemas\\" + Global.Sistema.ToString() + "\\modulo.ini"))
                    //    {
                    //        while ((line = file.ReadLine()) != null)
                    //        {
                    //            if (line.ToUpper().StartsWith("MODULO"))
                    //            {
                    //                string[] value = line.Split('=');
                    //                modulo = value[1];
                    //                break;
                    //            }
                    //        }
                    //    }
                    //}
                    ////

                    //Global.versaosistema = Assembly.GetEntryAssembly().GetName().Version.Major.ToString() + "." +
                    //                       CompletarZerosEsquerda(Assembly.GetEntryAssembly().GetName().Version.Minor, 2) + "." +
                    //                       modulo;

                    Assembly assembly = Assembly.Load("MechTech.Business");
                    Type classe = assembly.GetType("MechTech.Business.VersaoBO");
                    Object instancia = classe.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);

                    //Global.versaosistema = new VersaoBO().VersaoAtual(Global.ConnectionStringPg);
                    Global.versaosistema = classe.InvokeMember("VersaoAtual", BindingFlags.InvokeMethod, null, instancia, new object[] { Global.ConnectionStringPg }).ToString();
                }
                catch { }

                return Global.versaosistema;
            }
        }

        private static string empresaAtiva = "emp0001";
        /// <summary>
        /// Representa a empresa ativa no momento.
        /// </summary>
        public static string EmpresaAtiva
        {
            get { return Global.empresaAtiva; }
            set { Global.empresaAtiva = value; }
        }

        private static DateTime mesanoAtivo = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        /// <summary>
        /// Representa o mês/ano ativo no momento.
        /// </summary>
        public static DateTime MesanoAtivo
        {
            get { return Global.mesanoAtivo; }
            set { Global.mesanoAtivo = value; }
        }

        private static int filial = 0;
        /// <summary>
        /// Identificação da Filial.
        /// </summary>
        public static int Filial
        {
            get { return Global.filial; }
            set { Global.filial = value; }
        }

        private static int filialassist = 0;
        /// <summary>
        /// Representa o código da filial ativa para acesso ao assist
        /// </summary>
        public static int FilialAssist
        {
            get { return Global.filialassist; }
            set { Global.filialassist = value; }
        }

        private static DateTime? datatrava = null;
        /// <summary>
        /// Trava de segurança.
        /// </summary>
        public static DateTime? DataTrava
        {
            get { return Global.datatrava; }
            set { Global.datatrava = value; }
        }

        private static string licencauso = "DEMONSTRAÇÃO";
        /// <summary>
        /// Informações de licença de uso do Sistema.
        /// </summary>
        public static string LicencaUso
        {
            get { return Global.licencauso; }
            set { Global.licencauso = value; }
        }

        private static bool validacep = false;
        /// <summary>
        /// Informações de licença de uso da consulta de CEP.
        /// </summary>
        public static bool Validacep
        {
            get { return Global.validacep; }
            set { Global.validacep = value; }
        }

        private static string connectionstringpg = string.Empty;
        /// <summary>
        /// String de  conexão com o Banco de dados utilizando o usuário 'postgres'.
        /// </summary>
        public static string ConnectionStringPg
        {
            get { return Global.connectionstringpg; }
            set { Global.connectionstringpg = value; }
        }

        private static string connectionstringuser = string.Empty;
        /// <summary>
        /// String de conexão com o Banco de dados utilizando os usuários cadastrados no Sistema.
        /// </summary>
        public static string ConnectionStringUser
        {
            get { return Global.connectionstringuser; }
            set { Global.connectionstringuser = value; }
        }

        private static string connectionstringgersys = string.Empty;
        /// <summary>
        /// String de conexão com o Banco de dados GERSYS (MECHTECH Account)
        /// </summary>
        public static string ConnectionStringGerSys
        {
            get { return Global.connectionstringgersys; }
            set { Global.connectionstringgersys = value; }
        }

        private static string validadelicenca = "Indefinido";
        /// <summary>
        /// Tempo de validade da licença de uso do Sistema.
        /// </summary>
        public static string ValidadeLicenca
        {
            get { return Global.validadelicenca; }
            set { Global.validadelicenca = value; }
        }

        private static int id_usuarioativo = 0;
        /// <summary>
        /// Identificador do usuário ativo no momento.
        /// </summary>
        public static int Id_UsuarioAtivo
        {
            get { return Global.id_usuarioativo; }
            set { Global.id_usuarioativo = value; }
        }

        private static string usuarioativo = string.Empty;
        /// <summary>
        /// Representa o usuário ativo no momento.
        /// </summary>
        public static string UsuarioAtivo
        {
            get { return Global.usuarioativo; }
            set { Global.usuarioativo = value; }
        }

        private static List<int> acessos = new List<int>();
        /// <summary>
        /// Lista de rotinas disponíveis para acesso.
        /// </summary>
        public static List<int> Acessos
        {
            get { return Global.acessos; }
            set { Global.acessos = value; }
        }

        private static bool supervisor = false;
        /// <summary>
        /// Indica se o usuário ativo no momento tem permissões de supervisor.
        /// </summary>
        public static bool Supervisor
        {
            get { return Global.supervisor; }
            set { Global.supervisor = value; }
        }

        private static bool atualizarmodulos = false;
        /// <summary>
        /// Indica se o usuário ativo no momento tem permissão para atualizar módulos.
        /// </summary>
        public static bool AtualizarModulos
        {
            get { return Global.atualizarmodulos; }
            set { Global.atualizarmodulos = value; }
        }

        private static bool dbmonitor = false;
        /// <summary>
        /// Ativa/Desativa o monitoramento de ocorrências a nível de banco de dados.
        /// </summary>
        public static bool DbMonitor
        {
            get { return Global.dbmonitor; }
            set { Global.dbmonitor = value; }
        }

        /// <summary>
        /// Provedor de conversão de arquivos de imagem para tipo binário.
        /// </summary>
        public static byte[] LerImagem(string nomeimagem)
        {
            string filename = string.Empty;
            long filelength = 0;
            byte[] binaryfile = null;

            try
            {
                filename = nomeimagem;
                FileInfo image = new FileInfo(filename);
                filelength = image.Length;
                binaryfile = new byte[Convert.ToInt32(filelength)];
                FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                stream.Read(binaryfile, 0, Convert.ToInt32(filelength));
                stream.Close();

                return binaryfile;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Provedor de conversão de tipo binário para arquivos de imagem.
        /// </summary>
        public static Image LerImagemBinaria(byte[] imagembinaria)
        {
            try
            {
                if (imagembinaria == null)
                    return null;

                MemoryStream stream = new MemoryStream();
                stream.Write(imagembinaria, 0, imagembinaria.Length);

                return Image.FromStream(stream);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Representa uma lista de todos os dias da semana.
        /// </summary>
        public static List<Semana> ObterSemana()
        {
            List<Semana> semana = new List<Semana>();
            semana.Add(new Semana(1, "Domingo"));
            semana.Add(new Semana(2, "Segunda-Feira"));
            semana.Add(new Semana(3, "Terça-Feira"));
            semana.Add(new Semana(4, "Quarta-Feira"));
            semana.Add(new Semana(5, "Quinta-Feira"));
            semana.Add(new Semana(6, "Sexta-Feira"));
            semana.Add(new Semana(7, "Sábado"));
            return semana;
        }

        /// <summary>
        /// Representa um objeto com o dia especificado.
        /// </summary>
        public static Semana ObterDiaSemana(int dia)
        {
            Semana umdia = new Semana();
            List<Semana> semana = ObterSemana();
            foreach (Semana itemsemana in semana)
            {
                if (itemsemana.Dia.ToString().Equals(dia.ToString()))
                {
                    umdia = itemsemana;
                    break;
                }
            }
            return umdia;
        }

        /// <summary>
        /// Representa uma lista de todos os meses do ano.
        /// </summary>
        public static List<Meses> ObterMeses()
        {
            List<Meses> meses = new List<Meses>();
            meses.Add(new Meses(1, "Janeiro"));
            meses.Add(new Meses(2, "Fevereiro"));
            meses.Add(new Meses(3, "Março"));
            meses.Add(new Meses(4, "Abril"));
            meses.Add(new Meses(5, "Maio"));
            meses.Add(new Meses(6, "Junho"));
            meses.Add(new Meses(7, "Julho"));
            meses.Add(new Meses(8, "Agosto"));
            meses.Add(new Meses(9, "Setembro"));
            meses.Add(new Meses(10, "Outubro"));
            meses.Add(new Meses(11, "Novembro"));
            meses.Add(new Meses(12, "Dezembro"));
            return meses;
        }

        /// <summary>
        /// Representa um objeto com o mês especificado.
        /// </summary>
        public static Meses ObterMes(int mes)
        {
            Meses ummes = new Meses();
            List<Meses> meses = ObterMeses();
            foreach (Meses itemmes in meses)
            {
                if (itemmes.Mes.ToString().Equals(mes.ToString()))
                {
                    ummes = itemmes;
                    break;
                }
            }
            return ummes;
        }

        /// <summary>
        /// Responsável por classificar os meses retroativos de acordo com o período especificado, tendo como base o mês/ano de processamento. Por exemplo:
        /// processamento  -> 01/04/2008
        /// periodoinicial -> 01/07/2007 (Últimos 09 meses em relação a data de processamento)
        /// periodofinal   -> 01/03/2008
        /// Classificação  -> Jan/08, Fev/08, Mar/08, Abr (Mês/Ano ativo), Mai, Jun, Jul/07, Ago/07, Set/07, Out/07, Nov/07, Dez/07
        /// </summary>
        public static List<Meses> ClassificarPeriodo(DateTime periodoinicial, DateTime periodofinal)
        {
            List<Meses> mesesclassificados = new List<Meses>();
            int mesfinal = 12;

            if (periodoinicial.Year == periodofinal.Year)
                mesfinal = periodofinal.Month;
            for (int i = periodoinicial.Month; i <= mesfinal; i++)
            {
                if (i == 1) //JANEIRO
                    mesesclassificados.Add(new Meses(1, "Jan/" + periodoinicial.Year.ToString().Substring(2, 2)));
                else if (i == 2) //FEVEREIRO
                    mesesclassificados.Add(new Meses(2, "Fev/" + periodoinicial.Year.ToString().Substring(2, 2)));
                else if (i == 3) //MARÇO
                    mesesclassificados.Add(new Meses(3, "Mar/" + periodoinicial.Year.ToString().Substring(2, 2)));
                else if (i == 4) //ABRIL
                    mesesclassificados.Add(new Meses(4, "Abr/" + periodoinicial.Year.ToString().Substring(2, 2)));
                else if (i == 5) //MAIO
                    mesesclassificados.Add(new Meses(5, "Mai/" + periodoinicial.Year.ToString().Substring(2, 2)));
                else if (i == 6) //JUNHO
                    mesesclassificados.Add(new Meses(6, "Jun/" + periodoinicial.Year.ToString().Substring(2, 2)));
                else if (i == 7) //JULHO
                    mesesclassificados.Add(new Meses(7, "Jul/" + periodoinicial.Year.ToString().Substring(2, 2)));
                else if (i == 8) //AGOSTO
                    mesesclassificados.Add(new Meses(8, "Ago/" + periodoinicial.Year.ToString().Substring(2, 2)));
                else if (i == 9) //SETEMBRO
                    mesesclassificados.Add(new Meses(9, "Set/" + periodoinicial.Year.ToString().Substring(2, 2)));
                else if (i == 10) //OUTUBRO
                    mesesclassificados.Add(new Meses(10, "Out/" + periodoinicial.Year.ToString().Substring(2, 2)));
                else if (i == 11) //NOVEMBRO
                    mesesclassificados.Add(new Meses(11, "Nov/" + periodoinicial.Year.ToString().Substring(2, 2)));
                else if (i == 12) //DEZEMBRO
                    mesesclassificados.Add(new Meses(12, "Dez/" + periodoinicial.Year.ToString().Substring(2, 2)));
            }

            if (periodoinicial.Year != periodofinal.Year)
            {
                for (int i = 1; i <= periodofinal.Month; i++)
                {
                    if (i == 1) //JANEIRO
                        mesesclassificados.Add(new Meses(1, "Jan/" + periodofinal.Year.ToString().Substring(2, 2)));
                    else if (i == 2) //FEVEREIRO
                        mesesclassificados.Add(new Meses(2, "Fev/" + periodofinal.Year.ToString().Substring(2, 2)));
                    else if (i == 3) //MARÇO
                        mesesclassificados.Add(new Meses(3, "Mar/" + periodofinal.Year.ToString().Substring(2, 2)));
                    else if (i == 4) //ABRIL
                        mesesclassificados.Add(new Meses(4, "Abr/" + periodofinal.Year.ToString().Substring(2, 2)));
                    else if (i == 5) //MAIO
                        mesesclassificados.Add(new Meses(5, "Mai/" + periodofinal.Year.ToString().Substring(2, 2)));
                    else if (i == 6) //JUNHO
                        mesesclassificados.Add(new Meses(6, "Jun/" + periodofinal.Year.ToString().Substring(2, 2)));
                    else if (i == 7) //JULHO
                        mesesclassificados.Add(new Meses(7, "Jul/" + periodofinal.Year.ToString().Substring(2, 2)));
                    else if (i == 8) //AGOSTO
                        mesesclassificados.Add(new Meses(8, "Ago/" + periodofinal.Year.ToString().Substring(2, 2)));
                    else if (i == 9) //SETEMBRO
                        mesesclassificados.Add(new Meses(9, "Set/" + periodofinal.Year.ToString().Substring(2, 2)));
                    else if (i == 10) //OUTUBRO
                        mesesclassificados.Add(new Meses(10, "Out/" + periodofinal.Year.ToString().Substring(2, 2)));
                    else if (i == 11) //NOVEMBRO
                        mesesclassificados.Add(new Meses(11, "Nov/" + periodofinal.Year.ToString().Substring(2, 2)));
                    else if (i == 12) //DEZEMBRO
                        mesesclassificados.Add(new Meses(12, "Dez/" + periodofinal.Year.ToString().Substring(2, 2)));
                }
            }

            return mesesclassificados;
        }

        /// <summary>
        /// Troca um ou mais caracteres por um outro informado.
        /// </summary>
        /// <param name="caracteres">Caracter(es) que serão trocados</param>
        /// <param name="troca">Valor pelo qual o caracter será trocado</param>
        /// <param name="valor">Valor que será alterado</param>
        /// <returns>Valor com os caracteres alterados</returns>
        public static string TrocaCaracteres(string[] caracteres, string troca, string valor)
        {
            for (int i = 0; i < caracteres.Length; i++)
            {
                if (valor.Contains(caracteres[i].ToString()))
                    valor = valor.Replace(caracteres[i].ToString(), troca);
            }
            return valor;
        }

        /// <summary>
        /// Faz a quebra de um texto em um espaço próximo ao tamanho passado.
        /// </summary>
        /// <param name="Texto">Texto</param>
        /// <param name="tamQuebra">Tamanho máximo em que deve ocorrer a quebra</param>
        /// <returns></returns>
        public static string[] QuebraTexto(string Texto, int tamQuebra)
        {
            // texto = QuebraTexto(Texto, 90)[0];

            string[] retorno = new string[2] { "", "" };
            if (Texto.Length > tamQuebra)
            {
                for (int i = tamQuebra - 1; i >= 0; i--)
                {
                    if (Texto.Substring(i, 1).Equals(" "))
                    {
                        retorno[0] = Texto.Substring(0, i);
                        retorno[1] = Texto.Substring(i, (Texto.Length - i));
                        break;
                    }
                }
            }
            else
                retorno[0] = Texto;
            return retorno;
        }

        public static string Crypt(string action, string src, string addkey)
        {
            int keyLen = 0;
            int keyPos = 0;
            int offSet = 0; ;
            string dest = string.Empty;
            string key = string.Empty;
            int srcPos = 0;
            int srcAsc = 0;
            int tmpSrcAsc = 0;
            int range = 255;

            if (src == string.Empty) return string.Empty;

            key = "OPLIO7845OUPWEJRIRL784MONUIH589YQOLHCMN8320MJOIUALZ895PALKHULCJ7LWHYCLZ85CMCVX702MCOXGR";
            if (addkey != string.Empty)
                key = addkey + key.Substring(0, 87 - (addkey.Length - 1));

            keyLen = key.Length;

            if (action.ToUpper() == "C")
            {
                Random random = new Random();
                offSet = random.Next(0, range);
                dest = Convert.ToString(offSet, 16).PadLeft(2, Convert.ToChar("0")).ToUpper();
                for (int i = 0; i < src.Length; i++)
                {
                    srcAsc = (Convert.ToChar(src[i]) + offSet) % 255;

                    if (keyPos < keyLen)
                        keyPos++;
                    else
                        keyPos = 1;

                    srcAsc = srcAsc ^ Convert.ToChar(key[keyPos - 1]);
                    dest += Convert.ToString(srcAsc, 16).PadLeft(2, Convert.ToChar("0")).ToUpper();
                    offSet = srcAsc;
                }
            }
            else if (action.ToUpper() == "D")
            {
                offSet = Convert.ToInt32(src.Substring(0, 2), 16);
                srcPos = 2;
                do
                {
                    srcAsc = Convert.ToInt32(src.Substring(srcPos, 2), 16);
                    if (keyPos < keyLen)
                        keyPos++;
                    else
                        keyPos = 1;

                    tmpSrcAsc = srcAsc ^ Convert.ToChar(key[keyPos - 1]);
                    if (tmpSrcAsc <= offSet)
                        tmpSrcAsc = 255 + tmpSrcAsc - offSet;
                    else
                        tmpSrcAsc -= offSet;

                    dest += Convert.ToChar(tmpSrcAsc);
                    offSet = srcAsc;
                    srcPos += 2;
                }
                while (srcPos < src.Length);
            }
            return dest;
        }

        /// <summary>
        /// SHA1
        /// </summary>
        /// <returns>Mensagem encriptada</returns>
        public static string CreateHash(string mensagemoriginal)
        {
            return Cryptographer.CreateHash("SHA1Managed", mensagemoriginal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool CompareHash(string mensagemoriginal, string mensagemencriptada)
        {
            if (Cryptographer.CompareHash("SHA1Managed", mensagemoriginal, mensagemencriptada))
                return true;
            else
                return false;
        }

        /// <summary>
        /// MD5
        /// </summary>
        /// <returns>Mensagem encriptada</returns>
        public static string CreateMD5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5Hasher.ComputeHash(inputBytes);
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sBuilder.Append(hash[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static string CalculaFileHash(string arquivo)
        {
            MD5 objMD5 = MD5.Create();
            StringBuilder sBuilder = new StringBuilder();
            //FileStream objFS = new FileStream(arquivo,FileMode.Open,System.Security.AccessControl.FileSystemRights.ReadData,FileShare.Read,8,FileOptions.Asynchronous);
            FileStream objFS = File.OpenRead(arquivo);
            byte[] hashfile = objMD5.ComputeHash(objFS);

            for (int i = 0; i < hashfile.Length; i++)
                sBuilder.Append(hashfile[i].ToString("x2"));

            objFS.Close();
            return sBuilder.ToString().ToUpper();
        }

        /// <summary>
        /// Provedor de verificação da resolução de vídeo do Windows.
        /// </summary>
        /// <returns></returns>
        public static bool VerificarResolucaoVideo()
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            if (w <= 800 && h <= 600)
                return true;

            return false;
        }

        /// <summary>
        /// Representa um inteiro com a quantidade de domingos para o conteúdo especificado.
        /// </summary>
        public static int ObterDomingos(int mes, int ano)
        {
            int domingos = 0;
            int ultimodia = new DateTime(ano, mes, 1).AddMonths(1).AddDays(-1).Day;

            for (int umdia = 1; umdia <= ultimodia; umdia++)
            {
                DateTime dias = new DateTime(ano, mes, umdia);
                if (dias.DayOfWeek == DayOfWeek.Sunday)
                    domingos++;
            }

            return domingos;
        }

        /// <summary>
        /// Provedor de conversão de tipos numéricos para tipos string completados com zeros à esquerda.
        /// </summary>
        /// <param name="numero">Número original</param>
        /// <param name="qtdzeros">Quantidade de zeros aplicados ao número original</param>
        /// <returns>Número original completado com a quantidade de zeros à esquerda</returns>
        public static string CompletarZerosEsquerda(int numero, int qtdzeros)
        {
            return numero.ToString().PadLeft(qtdzeros, '0');
        }

        /// <summary>
        /// Provê zeros à esquerda para uma string qualquer.
        /// </summary>
        /// <param name="valor">String original</param>
        /// <param name="qtdzeros">Quantidade de zeros aplicados a string original</param>
        /// <returns>String original completada com a quantidade de zeros à esquerda</returns>
        public static string CompletarZerosEsquerda(string valor, int qtdzeros)
        {
            return valor.PadLeft(qtdzeros, '0');
        }

        /// <summary>
        /// Provê caracteres em branco à esquerda para uma string qualquer.
        /// </summary>
        /// <param name="valor">String original</param>
        /// <param name="qtdcaracteresbranco">Quantidade de caracteres em branco aplicado a string original</param>
        /// <returns>String original completada com a quantidade de caracteres em branco à esquerda</returns>
        public static string CompletarBrancosEsquerda(string valor, int qtdcaracteresbranco)
        {
            return valor.PadLeft(qtdcaracteresbranco, ' ');
        }

        /// <summary>
        /// Provê caracteres em branco à direita para uma string qualquer.
        /// </summary>
        /// <param name="valor">String original</param>
        /// <param name="qtdcaracteresbranco">Quantidade de caracteres em branco aplicado a string original</param>
        /// <returns>String original completada com a quantidade de caracteres em branco à direita</returns>
        public static string CompletarBrancosDireita(string valor, int qtdcaracteresbranco)
        {
            return valor.PadRight(qtdcaracteresbranco, ' ');
        }

        /// <summary>
        /// Provê espaços em branco de acordo com a quantidade especificada.
        /// </summary>
        /// <param name="count">O número de vezes que aparecerá o caracter em branco.</param>
        /// <returns></returns>
        public static string Space(int count)
        {
            return new String(' ', count);
        }

        /// <summary>
        /// Efetua as seguintes normalizações para obtenção de certificados:
        /// Elimina acentos e cedilhas dos nomes;
        /// Converte aspas duplas em simples;
        /// Converte algumas letras estrangeiras para seus equivalentes ASCII (como ß, convertido para ss);
        /// Põe uma "\" antes de vírgulas, permitindo nomes como "Verisign, Corp." e de "\", permitindo nomes como " a \ b ";
        /// Converte os sinais de = para -
        /// Alguns caracteres são removidos:
        /// -> os superiores a 255, mesmo que possam ser representados por letras latinas normais (como s, = U+015E = Latin Capital Letter S With Cedilla);
        /// -> os caracteres de controle (exceto tab, que é trocado por um espaço)
        /// </summary>
        /// <param name="valor">String à normalizar</param>
        /// <param name="tamanho">Quantidade de caracteres à normalizar ou null para normalizar a string toda</param>
        /// <returns>String normalizada</returns>
        public static string TratarCaracteresEspeciais(string valor, int? tamanho)
        {
            if (tamanho != null)
            {
                try
                {
                    valor = valor.Substring(0, tamanho.Value);
                }
                catch
                { }
            }

            string FIRST_STRING = (" !'#$%&'()*+\\-./0123456789:;<->?@ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                + "[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~ E ,f'.++^%S<O Z  ''''.-"
                + "-~Ts>o ZY !C#$Y|$'(a<--(_o+23'u .,1o>113?AAAAAAACEEEEIIIIDNOO"
                + "OOOXOUUUUyTsaaaaaaaceeeeiiiidnooooo/ouuuuyty");
            char[] FIRST_CHAR = FIRST_STRING.ToCharArray();
            string SECOND_STRING = ("  '         ,                                               "
                + "\\                                   $  r'. + o  E      ''  "
                + "  M  e     #  =  'C.<  R .-..     ..>424     E E            "
                + "   E E     hs    e e         h     e e     h ");
            char[] SECOND_CHAR = SECOND_STRING.ToCharArray();

            char[] chars = valor.ToCharArray();
            StringBuilder ret = new StringBuilder(chars.Length * 2);
            for (int i = 0; i < chars.Length; ++i)
            {
                char aChar = chars[i];
                if (aChar == ' ' || aChar == '\t')
                    ret.Append(' ');
                else if (aChar == '%')
                    ret.Append(string.Empty);
                else if (aChar == '.')
                    ret.Append(string.Empty);
                else if (aChar == ',')
                    ret.Append(string.Empty);
                else if (aChar == '-')
                    ret.Append(string.Empty);
                else if (aChar > ' ' && aChar < 256)
                {
                    if (FIRST_CHAR[aChar - ' '] != ' ')
                        ret.Append(FIRST_CHAR[aChar - ' ']);
                    if (SECOND_CHAR[aChar - ' '] != ' ')
                        ret.Append(SECOND_CHAR[aChar - ' ']);
                }
            }

            return ret.ToString();
        }

        /// <summary>
        /// Calcula as casas decimais ignorando possíveis arredondamentos. Ex.: R$156,879778 -> R$156,87
        /// </summary>
        /// <param name="valor">Valor original</param>
        /// <returns>Valor truncado</returns>
        public static decimal Truncate(decimal valor)
        {
            valor *= 100;
            valor = Math.Truncate(valor);
            valor /= 100;

            return valor;
        }

        /// <summary>
        /// Calcula as casas decimais ignorando possíveis arredondamentos. Ex.: R$156,879778 -> R$156,87
        /// </summary>
        /// <param name="valor">Valor original</param>
        /// <returns>Valor truncado</returns>
        public static double Truncate(double valor)
        {
            valor *= 100;
            valor = Math.Truncate(valor);
            valor /= 100;

            return valor;
        }

        /// <summary>
        /// Processador dinâmico de objetos.
        /// </summary>
        /// <param name="obj">Objeto à ser processado</param>
        /// <returns>Objeto processado</returns>
        public static object Eval(object obj)
        {
            CSharpCodeProvider c = new CSharpCodeProvider();
            ICodeCompiler icc = c.CreateCompiler();
            CompilerParameters cp = new CompilerParameters();

            cp.ReferencedAssemblies.Add("system.dll");

            cp.CompilerOptions = "/t:library";
            cp.GenerateInMemory = true;
            StringBuilder sb = new StringBuilder("");

            sb.Append("using System;\n");

            sb.Append("namespace CSCodeEvaler{ \n");
            sb.Append("public class CSCodeEvaler{ \n");
            sb.Append("public object EvalCode(object oParam){\n");
            sb.Append("return oParam; \n");
            sb.Append("} \n");
            sb.Append("} \n");
            sb.Append("}\n");

            CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
            if (cr.Errors.Count > 0)
            {
                MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                "Motivo: " + cr.Errors[0].ErrorText, "Processador dinâmico de objetos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            Assembly a = cr.CompiledAssembly;
            object o = a.CreateInstance("CSCodeEvaler.CSCodeEvaler");
            Type t = o.GetType();
            MethodInfo mi = t.GetMethod("EvalCode");
            object[] oParams = new object[1];
            oParams[0] = obj;
            object s = mi.Invoke(o, oParams);
            return s;
        }

        /// <summary>
        /// Receives a string and the length of the result string as parameters. Pads blank characters on the both sides of this string and returns a string with the length specified.
        /// </summary>
        public static string PadC(string cExpression, int nResultSize)
        {
            //Determine the number of padding characters
            int nPaddTotal = nResultSize - cExpression.Length;
            int lnHalfLength = (int)(nPaddTotal / 2);

            string lcString = cExpression.PadLeft(cExpression.Length + lnHalfLength);
            return lcString.PadRight(nResultSize);
        }

        /// <summary>
        /// Provê espaços em branco entre uma letra e outra de acordo com o número de pontos especificado.
        /// </summary>
        /// <param name="valor">String original</param>
        /// <param name="pt">O número de pontos em branco que aparecerá entre uma letra e outra.</param>
        /// <returns>String original com as letras separadas</returns>
        public static string EspacamentoEntreCaracteres(string valor, int pt)
        {
            string result = string.Empty;
            for (int i = 0; i < valor.Length; i++)
            {
                result += valor[i] + new String(' ', pt);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hora"></param>
        /// <returns></returns>
        public static long TimeSpanToTimeClarion(TimeSpan hora)
        {
            return (hora.Ticks / 100000) + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hora"></param>
        /// <returns></returns>
        public static TimeSpan TimeClarionToTimeSpan(long hora)
        {
            return TimeSpan.FromTicks((hora - 1) * 100000);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double DateTimeToDateClarion(DateTime data)
        {
            return data.ToOADate() + 36161;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime DateClarionToDateTime(double data)
        {
            return DateTime.FromOADate(data - 36161);
        }

        /// <summary>
        /// Calcula o DV Geral para código de barras pelo modulo 11.
        /// </summary>
        /// <param name="valor">String codbarras</param>
        /// <param name="pt">Sequencia base para calculo do DV.</param>
        /// <returns>String DV do código indicado</returns>
        public static string DVGeral_Modulo11(string codbarras)
        {
            int indice = 1;
            int acumulador = 0;

            for (int i = codbarras.Length - 1; i >= 0; i--)
            {
                indice++;

                if (indice > 9)
                    indice = 2;

                acumulador += int.Parse(codbarras.Substring(i, 1)) * indice;
            }

            if (acumulador > 11)
                acumulador = (acumulador % 11);

            return (11 - acumulador).ToString();
        }

        /// <summary>
        /// Calcula o DV dos blocos da representação numérica pelo modulo 10.
        /// </summary>
        /// <param name="valor">String codbarras</param>
        /// <param name="pt">Sequencia base para calculo do DV.</param>
        /// <returns>String DV do código indicado</returns>
        public static string DVBlocos_Modulo10(string codbarras)
        {
            int indice = 1;
            int tmp = 0;
            int acumulador = 0;

            for (int i = codbarras.Length - 1; i >= 0; i--)
            {
                if (indice == 1)
                    indice = 2;
                else
                    indice = 1;

                tmp = int.Parse(codbarras.Substring(i, 1)) * indice;

                if (tmp > 9)
                    tmp = int.Parse(tmp.ToString().Substring(0, 1)) + int.Parse(tmp.ToString().Substring(1, 1));

                acumulador += tmp;

            }

            acumulador = (acumulador % 10);

            if (acumulador == 0)
                return "0";
            else
                return (10 - acumulador).ToString();
        }

        /// <summary>
        /// Aplica formatação específica sobre um conteúdo informado.
        /// </summary>
        /// <param name="format">Formato específico</param>
        /// <param name="arg">Conteúdo</param>
        /// <returns>Conteúdo formatado</returns>
        public static string FormatString(string format, string arg)
        {
            string newvalue = string.Empty;
            int position = 0;

            for (int i = 0; format.Length > i; i++)
            {
                if (format[i] == '#')
                {
                    if (arg.Length > position)
                    {
                        newvalue = newvalue + arg[position];
                        position++;
                    }
                    else
                        break;
                }
                else
                {
                    if (arg.Length > position)
                        newvalue = newvalue + format[i];
                    else
                        break;
                }
            }
            return newvalue;
        }

        /// <summary>
        /// Retorna a data atual por extenso com a primeira letra maiúscula
        /// </summary>
        public static string GetLongDateString()
        {
            try
            {
                string data = DateTime.Now.ToLongDateString();
                data = data.Remove(0, 1);
                data = data.Insert(0, DateTime.Now.ToLongDateString()[0].ToString().ToUpper());

                return data;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna a string passada como parâmetro com a primeira letra
        /// de cada palavra em maiúsculo
        /// <param name="frase">Frase a ser tratada</param>
        /// </summary>
        public static string ToUpperString(string frase)
        {
            try
            {
                frase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(frase);
                return frase;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Converte uma string em um byte array
        /// <param name="input">String a ser convertida</param>
        /// </summary>
        public static byte[] ConvertStringToBytes(string input)
        {
            MemoryStream stream = new MemoryStream();

            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(input);
                writer.Flush();
            }

            return stream.ToArray();
        }

        /// <summary>
        /// Converte um array de bytes em string
        /// <param name="bytes">Array de bytes a ser convertido</param>
        /// </summary>
        public static string ConvertBytesToString(byte[] bytes)
        {
            string output = String.Empty;

            MemoryStream stream = new MemoryStream(bytes);
            stream.Position = 0;

            using (StreamReader reader = new StreamReader(stream))
            {
                output = reader.ReadToEnd();

            }

            return output;
        }

        /// <summary>
        /// Converte uma string de UTF8 para ISO-8859-1
        /// <param name="input">String a ser convertida</param>
        /// </summary>
        public static string ConvertUTF8ToISO88591(string input)
        {
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            Encoding utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(input);
            byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            input = iso.GetString(isoBytes);

            return input;
        }

        /// <summary>
        /// Converte uma string de ISO-8859-1 para UTF8
        /// <param name="input">String a ser convertida</param>
        /// </summary>
        public static string ConvertISO88591ToUTF8(string input)
        {
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            Encoding utf8 = Encoding.UTF8;
            byte[] isoBytes = iso.GetBytes(input);
            byte[] utfBytes = Encoding.Convert(iso, utf8, isoBytes);
            input = utf8.GetString(isoBytes);

            return input;
        }


        public static string GerarCNPJ(string cnpj) //43146
        {

            if (cnpj.Length < 12)
                return "";

            string[] aux = new string[12];

            for (int i = 0; i < 12; i++)
                aux[i] = cnpj.Substring(i, 1);


            /* if (sequencia < 10)
             {
                 aux[10] = "0";
                 aux[11] = sequencia.ToString(); ;
             }
             else
             {
                 string[] seq = new string[sequencia.ToString().Length];
                 for (int i = 0; i < sequencia.ToString().Length; i++)
                     seq[i] = sequencia.ToString().Substring(i, 1);
                 sequencia = 12 - seq.Length;
                 for (int i = 0; i < seq.Length; i++)
                 {
                     aux[sequencia] = seq[i];
                     sequencia++;
                 }                
             }*/

            int n0 = int.Parse(aux[0]) * 5;
            int n1 = int.Parse(aux[1]) * 4;
            int n2 = int.Parse(aux[2]) * 3;
            int n3 = int.Parse(aux[3]) * 2;
            int n4 = int.Parse(aux[4]) * 9;
            int n5 = int.Parse(aux[5]) * 8;
            int n6 = int.Parse(aux[6]) * 7;
            int n7 = int.Parse(aux[7]) * 6;
            int n8 = int.Parse(aux[8]) * 5;
            int n9 = int.Parse(aux[9]) * 4;
            int n10 = int.Parse(aux[10]) * 3;
            int n11 = int.Parse(aux[11]) * 2;

            int n12 = (n0 + n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9 + n10 + n11) % 11;

            if (n12 < 2)
                n12 = 0;
            else
                n12 = 11 - n12;

            string p12 = n12.ToString();

            n0 = int.Parse(aux[0]) * 6;
            n1 = int.Parse(aux[1]) * 5;
            n2 = int.Parse(aux[2]) * 4;
            n3 = int.Parse(aux[3]) * 3;
            n4 = int.Parse(aux[4]) * 2;
            n5 = int.Parse(aux[5]) * 9;
            n6 = int.Parse(aux[6]) * 8;
            n7 = int.Parse(aux[7]) * 7;
            n8 = int.Parse(aux[8]) * 6;
            n9 = int.Parse(aux[9]) * 5;
            n10 = int.Parse(aux[10]) * 4;
            n11 = int.Parse(aux[11]) * 3;
            n12 = n12 * 2;

            int n13 = (n0 + n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9 + n10 + n11 + n12) % 11;

            if (n13 < 2)
                n13 = 0;
            else
                n13 = 11 - n13;

            return aux[0] +
                   aux[1] +
                   aux[2] +
                   aux[3] +
                   aux[4] +
                   aux[5] +
                   aux[6] +
                   aux[7] +
                   aux[8] +
                   aux[9] +
                   aux[10] +
                   aux[11] +
                   p12 +
                   n13.ToString();
        }

        public static double RetornaIdade(DateTime Data) //40925
        {
            DateTime datanascimento = Data;
            DateTime today = DateTime.Today;
            try
            {
                today = new DateTime(MechTech.Util.Global.MesanoAtivo.Year, MechTech.Util.Global.MesanoAtivo.Month, DateTime.Today.Day);
            }
            catch { }
            TimeSpan idade = today - datanascimento;
            return Math.Round(idade.TotalDays / 365, 0);
        }

        private static Enumeradores.RotinaLOG rotinalog = Enumeradores.RotinaLOG.DigitacaoHolerith;
        public static Enumeradores.RotinaLOG RotinaLOG
        {
            get { return Global.rotinalog; }
            set { Global.rotinalog = value; }
        }

    }
}
