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

namespace MechTech.Util
{
    public partial class frmAcessoTI : DevExpress.XtraEditors.XtraForm
    {
        public bool Result { get; set; }
        enum Action
        {
            OK,
            Cancel
        }
        Action action = Action.Cancel;
        public frmAcessoTI()
        {
            InitializeComponent();

            dateEdit.EditValue = DateTime.Today;
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cancel();
        }

        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OK();
        }

        private void OK()
        {
            if (ValidaCampos())
                return;
            else
                this.Result = true;

            action = Action.OK;
            Close();
        }

        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors(); // Elimina todo os erros da janela

            if (txtSenhaTI.Text == string.Empty)
            {
                MessageBox.Show("Senha inválida. Preenchimento obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenhaTI.Focus();
                return true;
            }

            //int senhati = Math.Abs(Convert.ToInt32(Convert.ToInt32(Global.DateTimeToDateClarion(DateTime.Today)) * 123562 / 11));
            int senhati = 102030;
            string senha = senhati.ToString();
            if (senha.Length > 10)
                senha = senha.Substring(0, 10);
            if (txtSenhaTI.Text != senha)
            {
                MessageBox.Show("A senha informada é inválida. Redigite-a novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenhaTI.Text = string.Empty;
                txtSenhaTI.Focus();
                return true;
            }
            return false;
        }

        private void txtSenhaTI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                OK();
            else if (e.KeyCode == Keys.Escape)
                Cancel();
        }
        private void Cancel()
        {
            action = Action.Cancel;
            Close();
        }
    }
}