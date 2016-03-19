using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Security.Cryptography;
using FtpLib;

#region MechTech
using MechTech.Atualizacao.Entities;
using MechTech.Atualizacao;
using MechTech.Atualizacao.Data;
#endregion

using DevExpress.XtraEditors;
using MechTech.Util;

namespace MechTech
{
    public partial class frmAtualizacao : XtraForm
    {
        string DriveRede = string.Empty;
        FtpConnection ftp;
        int tamanho = 0;
        string subPastaSelecionada = string.Empty;
        string stringConexao = string.Empty;
        string versaoSistema = string.Empty;
        string versaoServidor = string.Empty;
        List<string> consultas = new List<string>();
        ExecutaSQLDAO executaSQLDAO = new ExecutaSQLDAO();
        public frmAtualizacao(string[] args)
        {
            this.stringConexao = args[0];
            this.versaoSistema = args[1];
            DriveRede = args[2];
            InitializeComponent();
            this.Cursor = Cursors.Default;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.WorkerReportsProgress = true;
        }

        public void btnAtualizar_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Cursor = Cursors.WaitCursor;
            backgroundWorker1.RunWorkerAsync();
        }

        private void Notify(BackgroundWorker worker, int progress)
        {
            if (worker != null)
                worker.ReportProgress(progress);
        }

        private void Atualizar(BackgroundWorker status, DoWorkEventArgs e)
        {
            Notify(status, 1);
            if (!HasConnection(status))
            {
                e.Cancel = true;
                return;
            }
            Notify(status, 2);
            if (!VerificarConexaoServidor(status))
            {
                e.Cancel = true;
                return;
            }

            Notify(status, 3);
            if (!DownloadArquivos(status, DriveRede + "/sistemas/MechTech/", "Sistema"))
            {
                e.Cancel = true;
                return;
            }

            Notify(status, 4);
            if (!DownloadArquivos(status, DriveRede + "/sistemas/MechTech/", "DevExpress"))
            {
                e.Cancel = true;
                return;
            }
            Notify(status, 5);
            if (!DownloadArquivos(status, DriveRede + "/sistemas/MechTech/postgres/93/", "postgres/93"))
            {
                e.Cancel = true;
                return;
            }

            Notify(status, 6);
            if (!DownloadArquivos(status, DriveRede + "/sistemas/MechTech/pt-br/", "pt-br"))
            {
                e.Cancel = true;
                return;
            }
            Notify(status, 7);
            if (!VerificarVersaoSistema(status))
            {
                e.Cancel = true;
                return;
            }
            Notify(status, 8);
            if (!ExecutarScriptsBanco(status))
            {
                e.Cancel = true;
                return;
            }

            Notify(status, 0);
        }

        private bool ExecutarScriptsBanco(BackgroundWorker status)
        {
            try
            {
                int versaoInicial = int.Parse(versaoSistema.Substring(5, 4));
                int versaoFinal = int.Parse(versaoServidor.Substring(5, 4));

                versaoInicial++;
                do
                {
                    versaoServidor = "1.00." + CompletarZerosEsquerda(versaoInicial, 4);
                    if (Directory.Exists(DriveRede + "/sistemas/MechTech/Scripts/" + versaoServidor))
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(DriveRede + "/sistemas/MechTech/Scripts/" + versaoServidor);
                        tamanho = dirInfo.GetFiles().Count();
                        foreach (var item in dirInfo.GetFiles())
                        {
                            System.IO.StreamReader myFile = null;
                            myFile = new System.IO.StreamReader(item.FullName);
                            string texto = myFile.ReadToEnd();
                            consultas.Add(texto + "**" + item.Name.Replace(".sql", "") + "**" + versaoServidor);
                        }
                    }
                    versaoInicial++;
                } while (versaoInicial.Equals(versaoFinal));
                string nomeScript = string.Empty;
                try
                {
                    foreach (var consulta in consultas)
                    {
                        string[] scriptString = consulta.Split(new string[] { "**" }, StringSplitOptions.None);

                        //MONTANDO OS DADOS DO SCRIPT
                        ScriptDTO script = new ScriptDTO();
                        script.Script = scriptString[0];
                        script.Id_script = int.Parse(scriptString[1]);
                        string[] dadosVersaoModulo = scriptString[2].Split(new string[] { "." }, StringSplitOptions.None);
                        script.Modulo = dadosVersaoModulo[2];
                        script.Versao = dadosVersaoModulo[0];
                        script.Executado = true;
                        nomeScript = scriptString[1];

                        //VERIFICANDO SE O PACOTE JÁ EXISTE
                        int Id_pacote = new VersaoDAO().VerificaVersaoModulo(stringConexao, int.Parse(script.Versao), int.Parse(script.Modulo));
                        if (Id_pacote.Equals(0))
                        {
                            new VersaoDAO().Insert(int.Parse(script.Versao), int.Parse(script.Modulo), DateTime.Now.ToShortDateString(), DateTime.Now.ToString("hh:mm:ss tt"), stringConexao);
                            Id_pacote = new VersaoDAO().VerificaVersaoModulo(stringConexao, int.Parse(script.Versao), int.Parse(script.Modulo));
                        }
                        else
                            Id_pacote = new VersaoDAO().VerificaVersaoModulo(stringConexao, int.Parse(script.Versao), int.Parse(script.Modulo));

                        script.Id_pacote = Id_pacote;
                        //VERIFICAR SE O SCRIPT FOI EXECUTADO
                        bool scriptVerificar = new ExecutaSQLDAO(stringConexao).GetScript(script);
                        if (!scriptVerificar)
                            //EXECUTANDO O SCRIPT
                            new ExecutaSQLDAO(stringConexao).Create(script);
                        UpdateBarraExecucaoScriptSQLProgressBarControl(consultas.Count());
                    }

                }
                catch { throw new Exception("A seguinte consulta não pode ser executada: " + "\nVersão: " + versaoServidor + "\nConsulta: " + nomeScript); }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool VerificarConexaoServidor(BackgroundWorker status)
        {
            try
            {
                string ftppass = new FTPDAO(stringConexao).GetFTPPass();
                ftppass = StringCipher.Decrypt(ftppass, "mechtechforever");
                ftp = new FtpConnection("ftp.acaciomelo.com", "mechtech@acaciomelo.com", ftppass);
                ftp.Open();
                ftp.Login();
                return true;
            }
            catch
            {
                MessageBox.Show("O Sistema identificou que a conexão com o servidor não foi possível. Por favor, tente mais tarde.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private bool VerificarVersaoSistema(BackgroundWorker status)
        {
            try
            {
                System.IO.StreamReader myFile = null;
                if (!DownloadArquivos(status, DriveRede + "/sistemas/MechTech/", "ScriptsSQL"))
                    return false;

                if (File.Exists(DriveRede + "/sistemas/MechTech/Versao.txt"))
                {
                    myFile = new System.IO.StreamReader(DriveRede + "/sistemas/MechTech/Versao.txt");
                    versaoServidor = myFile.ReadToEnd();
                    myFile.Close();
                    if (versaoServidor.Equals(versaoSistema))
                        return true;
                    else
                    {
                        int versaoInicial = int.Parse(versaoSistema.Substring(5, 4));
                        int versaoFinal = int.Parse(versaoServidor.Substring(5, 4));

                        versaoInicial++;
                        do
                        {
                            versaoServidor = "1.00." + CompletarZerosEsquerda(versaoInicial, 4);
                            if (!Directory.Exists(DriveRede + "/sistemas/MechTech/Scripts/" + versaoServidor))
                                Directory.CreateDirectory(DriveRede + "/sistemas/MechTech/Scripts/" + versaoServidor);
                            DownloadArquivos(status, DriveRede + "/sistemas/MechTech/Scripts/" + versaoServidor + "/", "ScriptsSQL/" + versaoServidor + "/");
                            versaoInicial++;
                        } while (versaoInicial.Equals(versaoFinal));
                    }
                }
                else
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private long TamanhoArquivoServidor(string local, string arquivo)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://mechtech%40acaciomelo.com:214904@acaciomelo.com/" + local + "/" + arquivo));
                request.Proxy = null;
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                long size = response.ContentLength;
                response.Close();
                return size;
            }
            catch
            {
                return 0;
            }
        }
        private bool DownloadArquivos(BackgroundWorker status, string pasta, string subpasta)
        {
            tamanho = 0;
            subPastaSelecionada = subpasta;
            try
            {
                if (subpasta.Length > 11 && subpasta.Substring(0, 12).Equals("ScriptsSQL/"))
                {
                    if (this.DownloadScriptSQLProgressBarControl.InvokeRequired)
                    {
                        DownloadScriptSQLProgressBarControl.Invoke(new MethodInvoker(delegate
                        {
                            this.DownloadScriptSQLProgressBarControl.EditValue = 0;
                            this.DownloadScriptSQLProgressBarControl.Update();
                        }));
                    }
                }
                else if (subpasta.Equals("Sistema"))
                {
                    if (this.CompSistemaProgressBarControl.InvokeRequired)
                    {
                        CompSistemaProgressBarControl.Invoke(new MethodInvoker(delegate
                        {
                            this.CompSistemaProgressBarControl.EditValue = 0;
                            this.CompSistemaProgressBarControl.Update();
                        }));
                    }
                }
                else if (subpasta.Equals("DevExpress") ||
                            subpasta.Equals("postgres/93") ||
                            subpasta.Equals("pt-br"))
                {
                    if (this.CompExternoProgressBarControl.InvokeRequired)
                    {
                        CompExternoProgressBarControl.Invoke(new MethodInvoker(delegate
                        {
                            this.CompExternoProgressBarControl.EditValue = 0;
                            this.CompExternoProgressBarControl.Update();
                        }));
                    }
                }

                if (ftp.DirectoryExists("/" + subpasta))
                    ftp.SetCurrentDirectory("/" + subpasta);

                var dir = ftp.GetCurrentDirectoryInfo();
                tamanho = dir.GetFiles().Length;

                foreach (var file in dir.GetFiles())
                {
                    if (!File.Exists(pasta + file.Name) || subpasta.Equals("ScriptsSQL"))
                    {
                        SetText("[" + file.Name + "]");
                        ftp.GetFile("/" + subpasta + "/" + file.Name, pasta + file.Name, false);
                    }
                    else
                    {
                        long size = TamanhoArquivoServidor(subpasta, file.Name);
                        FileInfo f = new FileInfo(pasta + file.Name);
                        long size2 = f.Length;

                        //COMPARAR ARQUIVOS DO SERVIDOR/ARQUIVOS LOCAIS
                        if (size != size2)
                        {
                            SetText("[" + file.Name + "]");
                            ftp.GetFile("/" + subpasta + "/" + file.Name, pasta + file.Name, false);
                        }
                        else
                        {
                            if (subpasta.Length > 11 && subpasta.Substring(0, 12).Equals("ScriptsSQL/"))
                            {
                                DownloadScriptSQLProgressBarControl.Invoke(new MethodInvoker(delegate
                                {
                                    this.DownloadScriptSQLProgressBarControl.Properties.Maximum = tamanho;

                                }));
                            }
                            else if (subpasta.Equals("Sistema"))
                            {
                                CompSistemaProgressBarControl.Invoke(new MethodInvoker(delegate
                                {
                                    this.CompSistemaProgressBarControl.Properties.Maximum = tamanho;

                                }));
                            }
                            else if (subpasta.Equals("DevExpress") ||
                                    subpasta.Equals("postgres/93") ||
                                    subpasta.Equals("pt-br"))
                            {
                                if (this.CompExternoProgressBarControl.InvokeRequired)
                                {
                                    CompExternoProgressBarControl.Invoke(new MethodInvoker(delegate
                                    {
                                        this.CompExternoProgressBarControl.Properties.Maximum = tamanho;

                                    }));
                                }
                            }
                        }

                        if (subpasta.Equals("Sistema"))
                            UpdateBarraArquivosSistema(tamanho);
                        else if (subpasta.Length > 11 && subpasta.Substring(0, 12).Equals("ScriptsSQL/1"))
                            UpdateBarraArquivosDownloadScripts(tamanho);
                        else if (subpasta.Equals("DevExpress") ||
                                   subpasta.Equals("postgres/93") ||
                                   subpasta.Equals("pt-br"))
                            UpdateBarraArquivosExternos(tamanho);

                        SetText("");
                    }
                }
            }
            catch
            {
                MessageBox.Show("O Sistema identificou que a conexão com o servidor não foi possível. Por favor, tente mais tarde.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void UpdateBarraExecucaoScriptSQLProgressBarControl(int tamanho)
        {
            if (this.ExecucaoScriptSQLProgressBarControl.InvokeRequired)
            {
                ExecucaoScriptSQLProgressBarControl.Invoke(new MethodInvoker(delegate
                {
                    this.ExecucaoScriptSQLProgressBarControl.Properties.Maximum = tamanho;
                    this.ExecucaoScriptSQLProgressBarControl.Properties.Step = 1;
                    this.ExecucaoScriptSQLProgressBarControl.PerformStep();
                    this.ExecucaoScriptSQLProgressBarControl.Update();
                }));
            }
        }
        private void UpdateBarraArquivosDownloadScripts(int tamanho)
        {
            if (this.DownloadScriptSQLProgressBarControl.InvokeRequired)
            {
                DownloadScriptSQLProgressBarControl.Invoke(new MethodInvoker(delegate
                {
                    this.DownloadScriptSQLProgressBarControl.Properties.Maximum = tamanho;
                    this.DownloadScriptSQLProgressBarControl.Properties.Step = 1;
                    this.DownloadScriptSQLProgressBarControl.PerformStep();
                    this.DownloadScriptSQLProgressBarControl.Update();
                }));
            }
        }

        private void UpdateBarraArquivosExternos(int tamanho)
        {
            if (this.CompExternoProgressBarControl.InvokeRequired)
            {
                CompExternoProgressBarControl.Invoke(new MethodInvoker(delegate
                {
                    this.CompExternoProgressBarControl.Properties.Maximum = tamanho;
                    this.CompExternoProgressBarControl.Properties.Step = 1;
                    this.CompExternoProgressBarControl.PerformStep();
                    this.CompExternoProgressBarControl.Update();
                }));
            }
        }

        private void UpdateBarraArquivosSistema(int tamanho)
        {
            if (this.CompSistemaProgressBarControl.InvokeRequired)
            {
                CompSistemaProgressBarControl.Invoke(new MethodInvoker(delegate
                {
                    this.CompSistemaProgressBarControl.Properties.Maximum = tamanho;
                    this.CompSistemaProgressBarControl.Properties.Step = 1;
                    this.CompSistemaProgressBarControl.PerformStep();
                    this.CompSistemaProgressBarControl.Update();
                }));
            }
        }

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (subPastaSelecionada.Equals("DevExpress") ||
                                   subPastaSelecionada.Equals("postgres/93") ||
                                   subPastaSelecionada.Equals("pt-br"))
            {
                if (this.lblComponentesExternos.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                    this.lblComponentesExternos.Text = text;
            }
            else if (subPastaSelecionada.Equals("Sistema"))
            {
                if (this.lblComponenteSistema.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                    this.lblComponenteSistema.Text = text;
            }
        }
        public static bool HasConnection(BackgroundWorker status)
        {
            try
            {
                System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch
            {
                MessageBox.Show("O Sistema identificou que não há conexão com a internet. Impossível prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                UseWaitCursor = false;
                Cursor = Cursors.Default;
            }
            else
                Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Atualizar(sender as BackgroundWorker, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void backgroundWorker1_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void frmAtualizacao_Load(object sender, EventArgs e)
        {
            lblVersaoSistema.Text = new VersaoDAO().VersaoAtual(stringConexao);
            lblDataUltimaAtualizacao.Text = new VersaoDAO().DataVersaoAtual(stringConexao);
        }

        public static string CompletarZerosEsquerda(int numero, int qtdzeros)
        {
            return numero.ToString().PadLeft(qtdzeros, '0');
        }

        public static string CompletarZerosEsquerda(string valor, int qtdzeros)
        {
            return valor.PadLeft(qtdzeros, '0');
        }
    }

    internal class CpArq
    {
        public CpArq()
        { }

        public CpArq(string origem)
        {
            this.Origem = origem;
        }

        public CpArq(string origem, string destino)
        {
            this.Origem = origem;
            this.Destino = destino;
        }

        public CpArq(string origem, string destino, string arquivo)
        {
            this.Origem = origem;
            this.Destino = destino;
            this.Arquivo = arquivo;
        }

        private string origem = string.Empty;
        public string Origem
        {
            get { return origem; }
            set { origem = value; }
        }

        private string destino = string.Empty;
        public string Destino
        {
            get { return destino; }
            set { destino = value; }
        }

        private string arquivo = string.Empty;
        public string Arquivo
        {
            get { return arquivo; }
            set { arquivo = value; }
        }
    }
}