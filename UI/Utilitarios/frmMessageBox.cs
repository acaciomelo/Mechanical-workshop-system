using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using MechTech.Util.Templates;
using MechTech.Util;

namespace MechTech.UI.Utilitarios
{
    public partial class frmMessageBox : frmBase
    {
        public frmMessageBox()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            OK();
        }
        private void OK()
        {
            if (chkCloseAll.Checked)
            {
                List<string> forms = new List<string>();
                foreach (Form umform in Application.OpenForms)
                {
                    if (!umform.Name.Equals(Global.MainForm) &&
                        !umform.Name.Trim().Equals(string.Empty) &&
                        !umform.Text.Trim().Equals(string.Empty) &&
                        !umform.Name.Equals(this.Name))
                        forms.Add(umform.Name);
                }
                foreach (string umnome in forms)
                {
                    Application.OpenForms[umnome].Close();
                }
            }
            Close();
        }

    }
}