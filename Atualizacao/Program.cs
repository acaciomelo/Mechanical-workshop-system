using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.Threading;

namespace MechTech.Atualizacao
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                MessageBox.Show("A atualização não pode ser executado diretamente. Favor executar pelo sistema.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(Environment.ExitCode);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Blue");
            Application.Run(new frmAtualizacao(args));
        }
    }
}
