using System;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

#region DEVEXPRESS
using DevExpress.XtraEditors;
#endregion

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Templates;
using MechTech.Entities;
using MechTech.Business;
#endregion

namespace MechTech.UI.Utilitarios
{
    public partial class frmBackupExecucao : frmBase
    {
        BackupBO backupbo = new BackupBO();
        DatabaseStructureBO databasestructureBO = new DatabaseStructureBO();
        StringBuilder ErroBackup = new StringBuilder();
        string ArqDestino = string.Empty;
        public frmBackupExecucao()
        {
            InitializeComponent();
            //switch (Global.Sistema)
            //{
            //    case Enumeradores.Sistema.MECHTECH:
            //        Icon = global::Backup.Properties.Resources.MECHTECH;
            //        NotifyIconBackup.Icon = global::Backup.Properties.Resources.MECHTECH;
            //        break;
            //}
        }

        private void btnFechar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmBackupExecucao_Shown(object sender, EventArgs e)
        {
            StateForm(false);
            backgroundWorker.RunWorkerAsync();
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ExecutarBackup((BackgroundWorker)sender, e);
            if (e.Result == null)
                VerificaLog();
        }

        private void NotifyIconBackup_DoubleClick(object sender, EventArgs e)
        {
            StateForm(true);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GravaLog();

            if (ErroBackup.Length > 0)
            {
                memoBackup.Text = ErroBackup.ToString();
                NotifyIconBackup.ShowBalloonTip(0, "Cópia de Segurança", "Falha na cópia de segurança.", ToolTipIcon.Error);
                MessageBox.Show("Falha na cópia de segurança. Favor verificar a tela a seguir", "Cópia de Segurança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StateForm(true);
            }
            else
            {
                NotifyIconBackup.ShowBalloonTip(0, "Cópia de Segurança", "Cópia de segurança realizada com sucesso.", ToolTipIcon.Info);
                MessageBox.Show("Cópia de segurança realizada com sucesso.", "Cópia de Segurança", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void StateForm(bool isVisible)
        {
            if (isVisible)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
            }
        }

        private void ExecutarBackup(BackgroundWorker status, DoWorkEventArgs e)
        {
            try
            {
                NotifyIconBackup.Visible = true;
                NotifyIconBackup.ShowBalloonTip(0, "Cópia de Segurança", "Processo de cópia de segurança em andamento.", ToolTipIcon.Info);

                int bkp = 0;
                string VersaoPostGres = string.Empty;
                string VersaoBanco = string.Empty;
                BackupDTO LstBackup = backupbo.GetLastBackup();
                BackupDTO BackupResultado = new BackupDTO();

                // VERIFICANDO O NÚMERO DO ÚLTIMO BACKUP REALIZADO
                if (LstBackup.Nomedados != "")
                {
                    if (LstBackup.Nomedados.Substring(6, 1) == "" || LstBackup.Nomedados.Substring(6, 1) == "5")
                        bkp = 1;
                    else
                        bkp = int.Parse(LstBackup.Nomedados.Substring(6, 1)) + 1;
                }
                else
                    bkp = 1;

                // DADOS DE CONEXÃO PARA O PG_DUMP
                string[] tags = Global.ConnectionStringPg.Split(';');
                //SERVIDOR
                string[] server = tags[0].Split('=');
                string Servidor = server[1];

                //PORTA
                string[] port = tags[1].Split('=');
                string porta = port[1];

                //BANCO DE DADOS
                string[] database = tags[2].Split('=');
                string BancoDados = database[1];

                //USUARIO
                string[] user = tags[3].Split('=');
                string usuario = user[1];

                //PWD
                string[] pwd = tags[4].Split('=');
                string Pwd = pwd[1];

                // PEGANDO A VERSÃO DO BANCO DE DADOS
                try
                {
                    VersaoBanco = databasestructureBO.GetVersion();
                    string[] version = VersaoBanco.Split(' ');
                    VersaoPostGres = version[1].Substring(0, 1) + version[1].Substring(2, 1);
                }
                catch { }

                // VERIFICANDO E CRIANDO A PASTA DE ARMAZENAMENTO DO BACKUP
                if (!Directory.Exists(Global.LocalPath + @"\sistemas\MechTech"))
                    Directory.CreateDirectory(Global.LocalPath + @"\sistemas\MechTech");

                if (!Directory.Exists(Global.LocalPath + @"\sistemas\MechTech\" + Global.Sistema.ToString()))
                    Directory.CreateDirectory(Global.LocalPath + @"\sistemas\MechTech\" + Global.Sistema.ToString());

                // NOME DO ARQUIVO DE BACKUP CONFORME A VERSÃO DO POSTGRES
                if (VersaoPostGres.Substring(0, 1) != "7")
                    ArqDestino = string.Format(Global.LocalPath + @"\sistemas\MechTech\" + Global.Sistema.ToString() + "\\bkp000" + bkp + ".fc");
                else
                    ArqDestino = string.Format(Global.LocalPath + @"\sistemas\MechTech\" + Global.Sistema.ToString() + "\\bkp000" + bkp + ".sql");

                // CRIANDO ARQUIVO DE BAT
                FileInfo arquivo = new FileInfo(Global.LocalPath + @"\sistemas\MechTech\" + Global.Sistema.ToString() + "\\backup.bat");
                if (arquivo.Exists)
                    arquivo.Delete();
                StreamWriter arquivoentrada = new StreamWriter(Global.LocalPath + @"\sistemas\MechTech\" + Global.Sistema.ToString() + "\\backup.bat");
                //arquivoentrada.WriteLine("ECHO OFF");
                arquivoentrada.WriteLine("@set PGPASSWORD=" + Pwd);
                //arquivoentrada.WriteLine("cls");
                arquivoentrada.WriteLine("@Echo Processo de backup em execução. Aguarde...");

                // ACIONANDO O PG_DUMP CONFORME A VERSÃO DO POSTGRES
                switch (VersaoPostGres)
                {
                    case "93":
                        //arquivoentrada.WriteLine("@" + Global.LocalPath + "\\sistemas\\" + Global.Sistema.ToString() + "\\postgres\\93\\pg_dump93.exe -U" + usuario + " -h" + Servidor + " -p" + porta + " -i -v -Fc -f" + ArqDestino + " " + BancoDados + " 2> " + ArqDestino + ".log");
                        arquivoentrada.WriteLine("@" + Global.LocalPath + "\\sistemas\\" + "MechTech" + "\\postgres\\93\\pg_dump93.exe -U" + usuario + " -h" + Servidor + " -p" + porta + " -i -v -Fc -f" + ArqDestino + " " + BancoDados + " 2> " + ArqDestino + ".log");
                        break;
                    case "91":
                        arquivoentrada.WriteLine("@" + Global.LocalPath + "\\sistemas\\" + Global.Sistema.ToString() + "\\postgres\\91\\pg_dump91.exe -U" + usuario + " -h" + Servidor + " -p" + porta + " -i -v -Fc -f" + ArqDestino + " " + BancoDados + " 2> " + ArqDestino + ".log");
                        break;
                    case "90":
                        arquivoentrada.WriteLine("@" + Global.LocalPath + "\\sistemas\\" + Global.Sistema.ToString() + "\\postgres\\90\\pg_dump90.exe -U" + usuario + " -h" + Servidor + " -p" + porta + " -i -v -Fc -f" + ArqDestino + " " + BancoDados + " 2> " + ArqDestino + ".log");
                        break;
                    case "82":
                        arquivoentrada.WriteLine("@" + Global.LocalPath + "\\sistemas\\" + Global.Sistema.ToString() + "\\postgres\\82\\pg_dump82.exe -U" + usuario + " -h" + Servidor + " -p" + porta + " -i -v -Fc -f" + ArqDestino + " " + BancoDados + " 2> " + ArqDestino + ".log");
                        break;
                    case "81":
                        arquivoentrada.WriteLine("@" + Global.LocalPath + "\\sistemas\\" + Global.Sistema.ToString() + "\\postgres\\82\\pg_dump81.exe -U" + usuario + " -h" + Servidor + " -p" + porta + " -i -v -Fc -f" + ArqDestino + " " + BancoDados + " 2> " + ArqDestino + ".log");
                        break;
                    default:
                        if (VersaoPostGres.Substring(0, 1) == "7")
                            arquivoentrada.WriteLine(Global.LocalPath + @"\\sistemas\\" + Global.Sistema.ToString() + "\\postgres\\82\\pg_dump7.exe -U" + usuario + " -h" + Servidor + " -p" + porta + " -i -v -f" + ArqDestino + " " + BancoDados + " 2> " + ArqDestino + ".log");
                        break;
                }

                arquivoentrada.Close();

                Process backup = new Process();
                backup.StartInfo.FileName = Global.LocalPath + @"\sistemas\MechTech\" + Global.Sistema.ToString() + "\\backup.bat";
                backup.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                backup.StartInfo.Verb = "Open";
                backup.StartInfo.CreateNoWindow = true;

                backup.Start();

                backup.WaitForExit();

                if (backup.ExitCode != 0)
                {
                    arquivo.Delete();
                    ErroBackup.AppendLine("Falha na execução do Backup.");
                    ErroBackup.AppendLine("Códido de retorno " + backup.ExitCode.ToString() + " recebido.");
                    e.Result = "Código de saída " + backup.ExitCode;
                    return;
                }

                arquivo = new FileInfo(Global.LocalPath + @"\sistemas\MechTech\" + Global.Sistema.ToString() + "\\backup.bat");
                if (arquivo.Exists)
                    arquivo.Delete();

                // REGISTRANDO O BACKUP
                BackupResultado.Data = DateTime.Today;
                BackupResultado.Hora = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
                BackupResultado.Usuario = Global.UsuarioAtivo;
                BackupResultado.Maquina = Environment.MachineName;
                BackupResultado.Nomedados = "bkp000" + bkp;

                if (VersaoPostGres.Substring(0, 1) != "7")
                    BackupResultado.Nomeempresa = "bkp000" + bkp + ".fc";
                else
                    BackupResultado.Nomeempresa = "bkp000" + bkp + ".sql";
                FileInfo fi = new FileInfo(ArqDestino);
                BackupResultado.Tamanho = (int)fi.Length;
                BackupResultado.Versao = Global.VersaoSistema;
                BackupResultado.Banco = VersaoBanco.Substring(0, 50);
                backupbo.Insert(BackupResultado);

                if (backupbo.MonitoraBackup())
                {
                    while (BackupResultado.Versao.IndexOf(".") != -1)
                        BackupResultado.Versao = BackupResultado.Versao.Remove(BackupResultado.Versao.IndexOf("."), 1);

                    int filial = backupbo.GetFilialBackup();
                    //bool RegistroMW = backupbo.InsertMW(BackupResultado, Global.Sistema.ToString(), filial);
                    //if (!RegistroMW)
                    //{
                    //    ErroBackup.AppendLine("Não foi possível registrar a execução do backup na MECHTECH");
                    //    ErroBackup.AppendLine("Verifique se há uma conexão de internet disponível.");
                    //}
                }
            }
            catch (Exception ex)
            {
                ErroBackup.AppendLine("Falha na execução do Backup.");
                ErroBackup.AppendLine(ex.Message);
                e.Result = ex.Message;
            }
        }

        private void VerificaLog()
        {
            StreamReader ArquivoLog = new StreamReader(ArqDestino + ".log");
            string Linha = string.Empty;

            while ((Linha = ArquivoLog.ReadLine().ToLower()) != null)
            {
                if (Linha.Contains("fatal"))
                    ErroBackup.AppendLine(Linha);

                if (Linha.Contains("erro"))
                    ErroBackup.AppendLine(Linha);

                if (Linha.Contains("warning"))
                    ErroBackup.AppendLine(Linha);

                if (Linha.Contains("panic"))
                    ErroBackup.AppendLine(Linha);

                if (Linha.Contains("error"))
                    ErroBackup.AppendLine(Linha);

                if (Linha.Contains("commerror"))
                    ErroBackup.AppendLine(Linha);

                if (Linha.Contains("pgerror"))
                    ErroBackup.AppendLine(Linha);

                if (Linha.Contains("invalid"))
                    ErroBackup.AppendLine(Linha);

                if (Linha.Contains("corrupted"))
                    ErroBackup.AppendLine(Linha);
            }
        }
        private void GravaLog()
        {
            StringBuilder entry = new StringBuilder();
            if (ErroBackup.Length > 0)
            {
                entry.AppendLine("Falha na execução do backup");
                entry.AppendLine("Usuário: " + Global.UsuarioAtivo);
                entry.AppendLine("Data: " + DateTime.Now.ToShortDateString());
                entry.AppendLine("Hora: " + DateTime.Now.ToShortTimeString());
                entry.AppendLine("Informações de retorno:");
                entry.AppendLine(ErroBackup.ToString());
            }
            else
            {
                entry.AppendLine("Backup realizado com sucesso");
                entry.AppendLine("Usuário: " + Global.UsuarioAtivo);
                entry.AppendLine("Data: " + DateTime.Now.ToShortDateString());
                entry.AppendLine("Hora: " + DateTime.Now.ToShortTimeString());
            }
            backupbo.GravaLOGBackup(16, entry.ToString());
        }
    }
}