using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

#region MECHTECH
using MechTech.Util;
#endregion

namespace MechTech.Atalho
{
    static class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetForegroundWindow(IntPtr hWnd);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 0)
                Global.DriveRede = args[0];
            else
                Global.DriveRede = string.Empty;

            #region INSTÂNCIA ÚNICA DA APLICAÇÃO
            string applicationid = Process.GetCurrentProcess().ProcessName;
            Process[] processlist = Process.GetProcessesByName(applicationid);
            if (processlist != null && processlist.Length > 1)
            {
                foreach (Process umprocesso in processlist)
                {
                    SetForegroundWindow(umprocesso.MainWindowHandle);
                }
                return;
            }
            #endregion

            #region MODULOS.EXE EM USO
            Process[] process = Process.GetProcessesByName("atualizacao");
            if (process != null && process.Length >= 1)
            {
                MessageBox.Show("O processo de Atualização de está em execução e impossibilita o uso deste programa no momento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion
            Global.Sistema = Enumeradores.Sistema.Mirror;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
