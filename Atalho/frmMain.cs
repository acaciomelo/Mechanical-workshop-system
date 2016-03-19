using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using System.Collections;
using Microsoft.Win32;

#region DEVEXPRESS
using DevExpress.XtraEditors;
using DevExpress.Utils.Menu;
#endregion

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Forms;
using MechTech.Entities;
using MechTech.Business;
using MechTech.Atualizacao;
using MechTech;
#endregion

namespace MechTech
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public Enumeradores.Sistema SistemaMirror { get; set; }
        public string unidaderede = string.Empty;

        delegate void ConectarEventHandler(object sender, EventArgs e);
        delegate void AtualizarModulosEventHandler(object sender, EventArgs e);
        delegate void ManutencaoConexoesEventHandler(object sender, EventArgs e);

        event ConectarEventHandler OnConectar;
        event AtualizarModulosEventHandler OnAtualizarModulos;
        event ManutencaoConexoesEventHandler OnManutencaoConexoes;

        List<CpArq> atualizacoes = new List<CpArq>();
        bool exit = false;
        string AppPath = Application.StartupPath;
        public frmMain()
        {
            InitializeComponent();
            SistemaMirror = Enumeradores.Sistema.MECHTECH;
            Global.DriveRede = AppDomain.CurrentDomain.BaseDirectory.Substring(0,2);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            if (keyData == Keys.Enter)
            {
                ddbConectar.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool ProcurarAtualizacoesNovo(BackgroundWorker status)
        {
            if (Global.DriveRede == string.Empty)
            {
                if (!File.Exists(AppPath + "\\CpArqM.xml"))
                {
                    Notify(status, 21);
                    MessageBox.Show("O arquivo 'CpArqM.xml' não pode ser localizado. Impossível prosseguir.", "Arquivo não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            try
            {
                if (Global.DriveRede == string.Empty) //1ª FASE DO MIRROR
                {
                    DataSet DS = new DataSet();
                    DS.ReadXml("CpArqM.xml");

                    string origem = string.Empty;
                    string destino = string.Empty;
                    string arquivo = string.Empty;
                    string hashfileserver = string.Empty;
                    string hashfilelocal = string.Empty;

                    atualizacoes.Clear();
                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        try
                        {
                            origem = Path.GetPathRoot(AppPath).Substring(0, 2) + row["origem"].ToString();
                            destino = row["destino"].ToString().Replace("C:", Global.LocalPath);
                            arquivo = row["arquivo"].ToString();

                            //ARQUIVOS DO SERVIDOR
                            string[] filesserver = Directory.GetFiles(origem, arquivo);
                            foreach (string fileserver in filesserver)
                            {
                                arquivo = Path.GetFileName(fileserver);
                                //COMPARAR ARQUIVOS DO SERVIDOR/ARQUIVOS LOCAIS
                                if (!File.Exists(destino + Path.GetFileName(fileserver)))
                                {
                                    atualizacoes.Add(new CpArq(origem, destino, Path.GetFileName(fileserver)));
                                }
                                else
                                {
                                    hashfileserver = Global.CalculaFileHash(Path.GetFullPath(fileserver));
                                    hashfilelocal = Global.CalculaFileHash(destino + Path.GetFileName(fileserver));

                                    if (hashfileserver != hashfilelocal)
                                    {
                                        atualizacoes.Add(new CpArq(origem, destino, Path.GetFileName(fileserver)));
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            atualizacoes.Add(new CpArq(origem, destino, arquivo));
                        }
                    }
                }
                else //2º FASE DO MIRROR
                {
                    Global.ConnectionStringPg = "host=" + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Servidor +
                        ";Port=" + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Porta + ";Database="
                        + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Banco + ";User="
                        + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Usuario + ";Password="
                        + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Senha + ";Unicode=False;Protocol=2";

                    string origem = string.Empty;
                    string destino = string.Empty;
                    string arquivo = string.Empty;
                    string hashfileserver = string.Empty;
                    string hashfilelocal = string.Empty;

                    atualizacoes.Clear();
                    List<CpArqDbDTO> lista = new VersaoBO().GetCpArqDb(Global.ConnectionStringPg);

                    foreach (CpArqDbDTO item in lista)
                    {
                        try
                        {
                            origem = Global.DriveRede + item.Path;
                            destino = Global.LocalPath + item.Path;
                            arquivo = item.Arquivo;

                            if (!File.Exists(destino + item.Arquivo))
                            {
                                atualizacoes.Add(new CpArq(origem, destino, item.Arquivo));
                            }
                            else if (item.Hash.Trim() == string.Empty)
                            {
                                hashfileserver = Global.CalculaFileHash(origem + item.Arquivo);
                                hashfilelocal = Global.CalculaFileHash(destino + item.Arquivo);

                                if (hashfileserver != hashfilelocal)
                                {
                                    atualizacoes.Add(new CpArq(origem, destino, item.Arquivo));
                                }
                            }
                            else
                            {
                                hashfileserver = item.Hash;
                                hashfilelocal = string.Empty;

                                if (destino.Substring(0, 2) != @"\\" || destino.ToUpper().IndexOf(@"$RGG\C$") == 0)
                                    hashfilelocal = Global.CalculaFileHash(destino + item.Arquivo);

                                if (hashfileserver.Trim() == string.Empty || hashfilelocal.Trim() == string.Empty || hashfileserver != hashfilelocal)
                                {
                                    atualizacoes.Add(new CpArq(origem, destino, item.Arquivo));
                                }
                            }
                        }
                        catch
                        {
                            atualizacoes.Add(new CpArq(origem, destino, arquivo));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Notify(status, 21);
                MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                "Motivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void Notify(BackgroundWorker worker, int progress)
        {
            if (worker != null)
                worker.ReportProgress(progress);
        }
        private bool CopiarNovosArquivos(BackgroundWorker status)
        {
            try
            {
                string arquivoorigem = string.Empty;
                string arquivodestino = string.Empty;
                foreach (CpArq umaatualizao in atualizacoes)
                {

                    if (!Directory.Exists(umaatualizao.Destino))
                        Directory.CreateDirectory(umaatualizao.Destino);

                    arquivoorigem = umaatualizao.Origem + umaatualizao.Arquivo;
                    arquivodestino = umaatualizao.Destino + umaatualizao.Arquivo;
                    File.Copy(arquivoorigem, arquivodestino, true);
                }
            }
            catch (Exception ex)
            {
                Notify(status, 31);
                MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                "Motivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
        private void AcionaMirrorLocal()
        {
            frmWait wait = new frmWait("Procurando por atualizações...");
            wait.Show();
            Application.DoEvents();

            if (!ProcurarAtualizacoesNovo(null))
            {
                Environment.Exit(Environment.ExitCode);
            }

            wait.NewMessage = "Copiando novos arquivos...";
            Application.DoEvents();

            if (!CopiarNovosArquivos(null))
            {
                Environment.Exit(Environment.ExitCode);
            }
        }

        void Atualizacao(object sender, EventArgs e)
        {
            if (ConexaoDTOBindingSource.List.Count <= 0)
            {
                MessageBox.Show("Nenhuma conexão foi estabelecida. Acesse o módulo de \"Manutenção de Conexões\" para configurar uma nova conexão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionstring = "host=" + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Servidor + ";Port=" + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Porta + ";Database=" + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Banco + ";User=" + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Usuario + ";Password=" + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Senha + ";Unicode=False;Protocol=2";
            string versaoAtual;
            versaoAtual = new VersaoBO().VersaoAtual(connectionstring);
            if (!File.Exists(Global.DriveRede + @"\Sistemas\MechTech\Atualizacao.exe"))
            {
                MessageBox.Show("O módulo de atualização não foi localizado.\nEntre em contato com o suporte técnico.", "Arquivo não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            Process.Start(string.Format(Global.DriveRede + @"\Sistemas\MechTech\Atualizacao.exe"), connectionstring + " " + versaoAtual + " " + Global.DriveRede);
            Application.Exit();
        }

        void frmMirror_OnManutencaoConexoes(object sender, EventArgs e)
        {
            frmAcessoTI acessoti = new frmAcessoTI();
            acessoti.ShowDialog();
            if (acessoti.Result)
                new frmGridConexoes().ShowDialog();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Global.LocalPath = @"C:";

            FileInfo arquivo = new FileInfo(@"C:\Windows\AppPatch\Custom\{306eee73-a574-495b-b47a-eb68e5a5c101}.sdb");
            if (arquivo.Exists)
                Global.LocalPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo arquivo2003 = new FileInfo(@"C:\Windows\AppPatch\Custom\{3bc43a9b-22d7-40aa-88c8-1f78e055031f}.sdb");

            if (arquivo2003.Exists)
                Global.LocalPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (Global.DriveRede == string.Empty)
            {
                UpdateComponentsDevExpress();
                UpdateComponentsSystem();
                AcionaMirrorLocal();
            }

            GetVersionFromRegistry();
            OnConectar += new ConectarEventHandler(frmMirror_OnConectar);
            OnManutencaoConexoes += new ManutencaoConexoesEventHandler(frmMirror_OnManutencaoConexoes);

            DXPopupMenu popupmenu = new DXPopupMenu();
            popupmenu.Items.Add(new DXMenuItem("&Conectar", new EventHandler(frmMirror_OnConectar)));
            popupmenu.Items.Add(new DXMenuItem("&Manutenção de Conexões", new EventHandler(frmMirror_OnManutencaoConexoes)));
            popupmenu.Items.Add(new DXMenuItem("&Atualização", new EventHandler(Atualizacao)));
            ddbConectar.DropDownControl = popupmenu;
        }

        private static void GetVersionFromRegistry()
        {
            using (RegistryKey ndpKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                string versoes = string.Empty;
                foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                {
                    if (versionKeyName.StartsWith("v"))
                    {

                        RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                        string name = (string)versionKey.GetValue("Version", "");
                        string sp = versionKey.GetValue("SP", "").ToString();
                        string install = versionKey.GetValue("Install", "").ToString();
                        if (install == "") //no install info, ust be later
                            versoes = versoes + versionKeyName + "  " + name + "\r\n";
                        else
                        {
                            if (sp != "" && install == "1")
                            {
                                versoes = versoes + versionKeyName + "  " + name + "  SP" + sp + "\r\n";
                            }

                        }
                        if (name != "")
                        {
                            continue;
                        }
                        foreach (string subKeyName in versionKey.GetSubKeyNames())
                        {
                            RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                            name = (string)subKey.GetValue("Version", "");
                            if (name != "")
                                sp = subKey.GetValue("SP", "").ToString();
                            install = subKey.GetValue("Install", "").ToString();
                            if (install == "") //no install info, ust be later
                                versoes = versoes + versionKeyName + "  " + name + "\r\n";
                            else
                            {
                                if (sp != "" && install == "1")
                                {
                                    versoes = versoes + "  " + subKeyName + "  " + name + "  SP" + sp + "\r\n";
                                }
                                else if (install == "1")
                                {
                                    versoes = versoes + "  " + subKeyName + "  " + name + "\r\n";
                                }

                            }

                        }

                    }
                }
            }
        }
        public string[] DirectoryGetFiles(string path, string searchPattern)
        {
            ArrayList files = new ArrayList();
            string[] patterns = searchPattern.Split('|');

            foreach (string onepattern in patterns)
            {
                files.AddRange(Directory.GetFiles(path, onepattern));
            }

            return (string[])files.ToArray(typeof(string));
        }
        private void UpdateComponentsDevExpress()
        {
            string serverpathptbr = Path.GetPathRoot(AppPath).Substring(0, 2) + @"\Sistemas\" + SistemaMirror.ToString() + @"\pt-BR";
            string serverpathsystem = Path.GetPathRoot(AppPath).Substring(0, 2) + @"\Sistemas\" + SistemaMirror.ToString();
            string localpathptbr = Global.LocalPath + @"\Sistemas\" + SistemaMirror.ToString() + @"\pt-BR";
            string localpathsystem = Global.LocalPath + @"\Sistemas\" + SistemaMirror.ToString();

            //PT-BR (SERVER)
            if (Directory.Exists(serverpathptbr))
            {
                string[] devexpressfiles = DirectoryGetFiles(serverpathptbr, "*.v9.2.*|*.v9.3.*|*.v10.1.*|*.v10.2.*|*.v11.1.*");
                foreach (string file in devexpressfiles)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }
            }
            //SYSTEM (SERVER)
            if (Directory.Exists(serverpathsystem))
            {
                string[] devexpressfiles = DirectoryGetFiles(serverpathsystem, "*.v9.2.*|*.v9.3.*|*.v10.1.*|*.v10.2.*|*.v11.1.*");
                foreach (string file in devexpressfiles)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }
            }

            //PT-BR (LOCAL)
            if (Directory.Exists(localpathptbr))
            {
                string[] devexpressfiles = DirectoryGetFiles(localpathptbr, "*.v9.2.*|*.v9.3.*|*.v10.1.*|*.v10.2.*|*.v11.1.*");
                foreach (string file in devexpressfiles)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }
            }

            //SYSTEM (LOCAL)
            if (Directory.Exists(localpathsystem))
            {
                string[] devexpressfiles = DirectoryGetFiles(localpathsystem, "*.v9.2.*|*.v9.3.*|*.v10.1.*|*.v10.2.*|*.v11.1.*");
                foreach (string file in devexpressfiles)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// Verify MECHTECH files.
        /// </summary>
        private void UpdateComponentsSystem()
        {
            string serverpathsystem = Path.GetPathRoot(AppPath).Substring(0, 2) + @"\Sistemas\" + SistemaMirror.ToString() + @"\";
            string localpathsystem = Global.LocalPath + @"\Sistemas\" + SistemaMirror.ToString() + @"\";
        }

        void frmMirror_OnConectar(object sender, EventArgs e)
        {
            OnConect();
        }
        private void ddbConectar_Click(object sender, EventArgs e)
        {
            OnConect();
        }

        private void HabilitaDesabilitaControles(bool enabled)
        {
            ConexoesLookUpEdit.Enabled = enabled;
            ddbConectar.Enabled = enabled;
        }

        private void OnConect()
        {
            if (ConexaoDTOBindingSource.List.Count <= 0)
            {
                MessageBox.Show("Nenhuma conexão foi estabelecida. Acesse o módulo de \"Manutenção de Conexões\" para configurar uma nova conexão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Global.ConnectionStringPg = "host=" + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Servidor + ";Port=" + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Porta + ";Database=" + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Banco + ";User=" + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Usuario + ";Password=" + ((ConexoesDTO)ConexaoDTOBindingSource.Current).Senha + ";Unicode=False;Protocol=2";

            HabilitaDesabilitaControles(false);
            Cursor = Cursors.WaitCursor;

            ResetImages();
            backgroundWorker.RunWorkerAsync();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            if (File.Exists("appConex.bin"))
            {
                ConexaoDTOBindingSource.DataSource = new ConexoesDTO().Deserializar();

                try
                {
                    ConexoesLookUpEdit.EditValue = ((ConexoesDTO)ConexaoDTOBindingSource.Current).Empresa;
                }
                catch
                {
                    if (!exit)
                    {
                        exit = true;
                        MessageBox.Show("Não foi possível ler o arquivo de configuração de conexões. Por favor entre em contato com nosso suporte técnico para solucionar o problema.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Environment.Exit(Environment.ExitCode);
                }
            }
        }

        private void ConexoesLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!ConexoesLookUpEdit.IsModified)
                return;

            ConexaoDTOBindingSource.Position = ConexoesLookUpEdit.ItemIndex;
        }

        private void ResetImages()
        {
            ConexaoPictureBox.Image = MechTech.Atalho.Properties.Resources.loading;
            ConexaoPictureBox.Visible = false;

            AtualizacaoPictureBox.Image = MechTech.Atalho.Properties.Resources.loading;
            AtualizacaoPictureBox.Visible = false;

            CopiandoPictureBox.Image = MechTech.Atalho.Properties.Resources.loading;
            CopiandoPictureBox.Visible = false;

            CarregandoPictureBox.Image = MechTech.Atalho.Properties.Resources.loading;
            CarregandoPictureBox.Visible = false;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
                ConexaoPictureBox.Visible = true;
            if (e.ProgressPercentage == 11)
                ConexaoPictureBox.Image = MechTech.Atalho.Properties.Resources.cancel_16x16;

            if (e.ProgressPercentage == 2)
            {
                ConexaoPictureBox.Image = MechTech.Atalho.Properties.Resources.ok_16;
                AtualizacaoPictureBox.Visible = true;
            }
            if (e.ProgressPercentage == 21)
                AtualizacaoPictureBox.Image = MechTech.Atalho.Properties.Resources.cancel_16x16;

            if (e.ProgressPercentage == 3)
            {
                AtualizacaoPictureBox.Image = MechTech.Atalho.Properties.Resources.ok_16;
                CopiandoPictureBox.Visible = true;
            }
            if (e.ProgressPercentage == 31)
                CopiandoPictureBox.Image = MechTech.Atalho.Properties.Resources.cancel_16x16;

            if (e.ProgressPercentage == 4)
            {
                CopiandoPictureBox.Image = MechTech.Atalho.Properties.Resources.ok_16;
                CarregandoPictureBox.Visible = true;
            }
            if (e.ProgressPercentage == 41)
                CarregandoPictureBox.Image = MechTech.Atalho.Properties.Resources.cancel_16x16;

            if (e.ProgressPercentage == 0) //END
                CarregandoPictureBox.Image = MechTech.Atalho.Properties.Resources.ok_16;

            ConexaoPictureBox.Refresh();
            AtualizacaoPictureBox.Refresh();
            CopiandoPictureBox.Refresh();
            CarregandoPictureBox.Refresh();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Conectar(sender as BackgroundWorker, e);
        }

        private void Conectar(BackgroundWorker status, DoWorkEventArgs e)
        {
            Notify(status, 1);
            if (!TestarConexaoDB(status))
            {
                e.Cancel = true;
                return;
            }
            Notify(status, 2);
            if (!ProcurarAtualizacoesNovo(status))
            {
                e.Cancel = true;
                Environment.Exit(Environment.ExitCode);
            }
            Notify(status, 3);
            if (!CopiarNovosArquivos(status))
            {
                e.Cancel = true;
                Environment.Exit(Environment.ExitCode);
            }
            Notify(status, 4);
            if (!Carregar(status))
            {
                e.Cancel = true;
                Environment.Exit(Environment.ExitCode);
            }
            Notify(status, 0);
        }

        private bool Carregar(BackgroundWorker status)
        {
            try
            {
                Process.Start(string.Format(Global.LocalPath + @"\Sistemas\{0}\{0}.exe", SistemaMirror.ToString()), "mirror " + Global.DriveRede + " " + ConexoesLookUpEdit.ItemIndex);
            }
            catch (Exception ex)
            {
                Notify(status, 41);
                MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                "Motivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool TestarConexaoDB(BackgroundWorker status)
        {
            if (!ping.Send((ConexoesDTO)ConexaoDTOBindingSource.Current))
            {
                Notify(status, 11);
                MessageBox.Show("Não foi possível estabelecer uma conexão válida. Acesse o módulo de \"Manutenção de conexões\" para reconfigurar a conexão caso seja necessário.", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Application.Exit();
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