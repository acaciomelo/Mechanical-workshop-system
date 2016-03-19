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

#region 
using MechTech.Entities;
using MechTech.Util;
using MechTech.UI.Cadastros;
#endregion

namespace MechTech
{
    public partial class frmGridConexoes : DevExpress.XtraEditors.XtraForm
    {
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        ConexoesDTO conexoes = new ConexoesDTO();
        public frmGridConexoes()
        {
            InitializeComponent();

            ConexoesDTOBindingSource.DataSource = conexoes.Deserializar();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void HabilitaDesabilitaBotoes()
        {
            if (grdConexoes.FocusedView.DataRowCount == 0)
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnVisualizar.Enabled = false;
            }
            else
            {
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnVisualizar.Enabled = true;
            }
        }

        private void btnNovo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Novo();
        }

        private void btnAlterar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Alterar();
        }

        private void btnExcluir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Excluir();
        }


        private void btnVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Visualizar();
        }

        private void Novo()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateConexoes frmUpdate = new frmUpdateConexoes(this, Enumeradores.TipoOperacao.Insert, ConexoesDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Alterar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateConexoes frmUpdate = new frmUpdateConexoes(this, Enumeradores.TipoOperacao.Update, ConexoesDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Excluir()
        {
            if (MessageBox.Show("Deseja realmente excluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                conexoes = (ConexoesDTO)ConexoesDTOBindingSource.Current;

                Cursor = Cursors.WaitCursor;
                try
                {
                    ConexoesDTOBindingSource.RemoveCurrent();
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                    "Motivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Cursor = Cursors.Default;
            }
        }

        private void Visualizar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateConexoes frmUpdate = new frmUpdateConexoes(this, Enumeradores.TipoOperacao.Viewer, ConexoesDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void frmGridConexoes_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ConexoesDTOBindingSource.List.Count > 0)
            {
                conexoes.Conexoes = (List<ConexoesDTO>)ConexoesDTOBindingSource.List;
                conexoes.Serializar();
            }
        }

        private void grdView_RowCountChanged(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoes();
        }

        private void grdConexoes_DoubleClick(object sender, EventArgs e)
        {
            if (btnAlterar.Enabled)
            {
                Cursor = Cursors.WaitCursor;
                frmUpdateConexoes frmUpdate = new frmUpdateConexoes(this, Enumeradores.TipoOperacao.Update, ConexoesDTOBindingSource);
                frmUpdate.ShowDialog();
                Cursor = Cursors.Default;
            }
        }
    }
}