using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

#region MECHTECH
using MechTech.Util.Templates;
using MechTech.Business;
using MechTech.Util;
#endregion

namespace MechTech.UI.Utilitarios
{
    public partial class frmBackup : frmBase
    {
        BackupBO backupBO = new BackupBO();
        DatabaseStructureBO databasestructureBO = new DatabaseStructureBO();
        public frmBackup()
        {
            InitializeComponent();
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            BackupBindingSource.DataSource = backupBO.GetGridBackup();
        }

        private void btnExecutar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBackupExecucao frmBackup = new frmBackupExecucao();
            frmBackup.ShowDialog();
        }
    }
}