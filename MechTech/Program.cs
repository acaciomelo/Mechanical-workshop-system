using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Threading;
using DevExpress.LookAndFeel;
using MechTech.Data;
using MechTech.UI.Cadastros;
using MechTech.Util;
using MechTech.Util.Forms;
using MechTech.WebServices;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using MechTech.Atalho;

namespace MechTech
{
    static class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetForegroundWindow(IntPtr hWnd);
        [STAThread]
        static void Main(string[] args)
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            if (args.Length <= 0 ||
                args[0].ToUpper() != "MIRROR")
            {
                MessageBox.Show("O Sistema de oficina mecânica não pode ser executado diretamente. Favor executar o arquivo Atalho.exe", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(Environment.ExitCode);
            }
            Global.DriveRede = args[1];
            Global.LocalPath = @"C:";
            int conexaomirror = int.Parse(args[2]);

            FileInfo arquivo = new FileInfo(@"C:\Windows\AppPatch\Custom\{306eee73-a574-495b-b47a-eb68e5a5c101}.sdb");

            if (arquivo.Exists)
                Global.LocalPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo arquivo2003 = new FileInfo(@"C:\Windows\AppPatch\Custom\{3bc43a9b-22d7-40aa-88c8-1f78e055031f}.sdb");

            if (arquivo2003.Exists)
                Global.LocalPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            #region SEGURANÇA DO ARQUIVO DE CONFIGURAÇÃO DO SISTEMA
            List<MechTech.Entities.ConexoesDTO> conexoes = new MechTech.Entities.ConexoesDTO().Deserializar();
            Global.ConnectionStringPg = "host=" + conexoes[conexaomirror].Servidor + ";Port=" + conexoes[conexaomirror].Porta + ";Database=" + conexoes[conexaomirror].Banco + ";User=" + conexoes[conexaomirror].Usuario + ";Password=" + conexoes[conexaomirror].Senha + ";Unicode=False;Protocol=2";

            string[] tags = Global.ConnectionStringPg.Split(';');
            tags[2] = "Database=gersys";
            Global.ConnectionStringGerSys = tags[0] + ";" + tags[1] + ";" + tags[2] + ";" + tags[3] + ";" + tags[4] + ";" + tags[5] + ";" + tags[6];
            #endregion
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.DoEvents();
            Global.Sistema = Enumeradores.Sistema.MECHTECH;
            Global.LicencaUso = "DEMONSTRAÇÃO";
            DevExpress.UserSkins.BonusSkins.Register();
            Ativacao wsativ = new Ativacao();
            #region Ativação
            try
            {   
                AtivacaoDAO ativacaoDao = new AtivacaoDAO();
                bool Ativou = false;
                int dias = 0;
                string ip = wsativ.GetIp();

                Ativou = ativacaoDao.VerificaSeClienteAtivou();

                if (Ativou)
                {
                    string razao = ativacaoDao.getRazaoCliente();
                    if (wsativ.VerificaAtivacao(razao))
                    {
                        wsativ.FecharConexao();
                        Global.LicencaUso = razao.ToUpper();
                        Application.Run(new frmPrincipal());
                    }
                    else
                    {
                        MessageBox.Show("Desculpe-nos, mas sua licença expirou. Por favor, entre em contato com nosso suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();
                    }
                }
                else
                {
                    if (wsativ.VerificaIpNoServidor(ip))
                    {
                        dias = wsativ.VerificarDiasDemonstracao(ip);
                        if (dias == 9999)
                        {
                            MessageBox.Show("Desculpe-nos, mas não foi possível verificar a data da máquina.\n" +
                            "Verifique sua conexão de internet.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Application.Exit();
                        }
                    }
                    else
                        wsativ.GravarIp(ip);
                }

                if (dias > 0)
                {
                    wsativ.FecharConexao();
                    Application.Run(new frmPrincipal());
                }
                else if (dias < 0)
                {
                    if (MessageBox.Show("O período de demonstração expirou. É necessário ativar o sistema para continuar, deseja fazê-lo agora?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        Application.Run(new MechTech.Atalho.frmAtivacao());
                }
            }
            catch (Exception ex)
            {
                wsativ.FecharConexao();
                MessageBox.Show(ex.StackTrace);
            }
            #endregion
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception.InnerException == null)
                new frmException(e.Exception).ShowDialog();
            else
            {
                if (e.Exception.InnerException.Message == Enumeradores.TipoExcessao.Usuario.ToString())
                    MessageBox.Show(e.Exception.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    new frmException(e.Exception).ShowDialog();
            }
        }
    }
}