using System;
using System.Text;
using System.Windows.Forms;

#region MECHTECH
using MechTech.Util.Templates;
#endregion


namespace MechTech.Util.Forms
{
    public partial class frmExceptionDetail : frmBase
    {
        public frmExceptionDetail(Exception ex)
        {
            InitializeComponent();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Motivo: \"" + ex.Message + "\"");
            sb.AppendLine("Fonte: \"" + ex.Source + "\"");
            sb.AppendLine("Rastreamento de pilha:");
            sb.Append(ex.StackTrace);

            DetailMemoEdit.Text = sb.ToString();
        }

        private void frmExceptionDetail_Shown(object sender, EventArgs e)
        {
            btnOK.Focus();
        }

        private void DetailMemoEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}