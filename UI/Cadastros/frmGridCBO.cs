using System;
using System.Windows.Forms;

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Templates;
using MechTech.Entities;
using MechTech.Gateway;
#endregion

#region DEVEXPRESS
using DevExpress.XtraEditors;
#endregion

namespace MechTech.UI.Cadastros
{
    public partial class frmGridCBO : frmBase
    {
        bool isEnabled;
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        Form frmUpdate { get; set; }
        CBODTO cboDTO = new CBODTO();
        CBOGL cboGL = new CBOGL();
        Acesso acesso = new Acesso();
        Global.SystemDelegate GetCBO;
        public frmGridCBO()
        {
            InitializeComponent();
            isEnabled = true;
        }

        public frmGridCBO(Form frm, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = false;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetCBO = target;
        }

        /// <summary>
        /// Instância para frmGridCBO com opção de "Seleção" e controle de estado do formulário.
        /// </summary>
        public frmGridCBO(Form frm, bool enabled, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = enabled;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetCBO = target;
        }

        private void frmGridCBO_Load(object sender, EventArgs e)
        {
            try
            {
                frmUpdate.Enabled = isEnabled;
            }
            catch
            { }

            acesso.Add(1128, btnInserir, Enumeradores.TipoAcao.Desabilitar);
            acesso.Add(1129, btnEditar, Enumeradores.TipoAcao.Desabilitar);
            acesso.Add(1130, btnExcluir, Enumeradores.TipoAcao.Desabilitar);
            acesso.Add(1131, btnVisualizar, Enumeradores.TipoAcao.Desabilitar);
            acesso.Add(1132, btnImprimir, Enumeradores.TipoAcao.Desabilitar);

            acesso.Validate();
        }

        private void frmGridCBO_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmUpdate.Enabled = true;
            }
            catch
            { }
        }

        private void HabilitaDesabilitaBotoes()
        {
            if (dgdTabela.FocusedView.DataRowCount == 0)
            {
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnVisualizar.Enabled = false;
                btnImprimir.Enabled = false;
                btnSelecionar.Enabled = false;
            }
            else
            {
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnVisualizar.Enabled = true;
                btnImprimir.Enabled = true;

                if (tpOperacao == Enumeradores.TipoOperacao.Select)
                {
                    btnSelecionar.Enabled = true;
                }
            }

            acesso.Validate();
        }

        private void Pesquisar(object sender)
        {
            BaseEdit texto = (BaseEdit)sender;

            Cursor = Cursors.WaitCursor;
            try
            {
                switch (cboFiltro.EditValue.ToString().ToUpper())
                {
                    case "CÓDIGO":
                        CBODTOBindingSource.DataSource = cboGL.GetGridCBO("codigo", texto.Text + "%");
                        break;
                    case "DESCRIÇÃO":
                        CBODTOBindingSource.DataSource = cboGL.GetGridCBO("descricao", "%" + texto.Text + "%");
                        break;
                }
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            Cursor = Cursors.Default;
        }

        private void btnPesquisa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Pesquisar(sender);
        }

        private void btnPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                Pesquisar(sender);
            }
        }

        private void btnInserir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Novo();
        }

        private void Novo()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateCBO frmUpdate = new frmUpdateCBO(this, Enumeradores.TipoOperacao.Insert, CBODTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Alterar();
        }

        private void Alterar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateCBO frmUpdate = new frmUpdateCBO(this, Enumeradores.TipoOperacao.Update, CBODTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void btnExcluir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Excluir();
        }

        private void Excluir()
        {
            if (MessageBox.Show("Deseja realmente excluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                cboDTO = (CBODTO)CBODTOBindingSource.Current;

                try
                {
                    cboGL.Delete(cboDTO.Id);
                    CBODTOBindingSource.RemoveCurrent();
                }
                catch
                {
                    throw;
                }
            }
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
        }

        private void Imprimir()
        {
            base.ShowRibbonPreview(dgdTabela, "Listagem do Cadastro de CBO");
        }

        private void gridView_RowCountChanged(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoes();
        }

        private void dgdTabela_DoubleClick(object sender, EventArgs e)
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Select)
                Selecionar();
            else
            {
                if (btnEditar.Enabled)
                {
                    Cursor = Cursors.WaitCursor;
                    frmUpdateCBO frmUpdate = new frmUpdateCBO(this, Enumeradores.TipoOperacao.Update, CBODTOBindingSource);
                    frmUpdate.Show();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            CBODTO item = (CBODTO)CBODTOBindingSource[e.ListSourceRowIndex];

            if (e.Column.FieldName == "Grupo.Descricao" && e.ListSourceRowIndex >= 0 && e.IsGetData)
            {
                switch (item.Grupo)
                {
                    case "O":
                        e.Value = "Ocupação";
                        break;
                    case "S":
                        e.Value = "Sinônimo";
                        break;
                    default:
                        e.Value = item.Grupo;
                        break;
                }
            }
        }

        private void btnSelecionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Selecionar();
        }

        private void Selecionar()
        {
            try
            {
                GetCBO((CBODTO)CBODTOBindingSource.Current);
            }
            catch
            { }

            Close();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alterar();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visualizar();
        }

        private void Visualizar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateCBO frmUpdate = new frmUpdateCBO(this, Enumeradores.TipoOperacao.Viewer, CBODTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void selecionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selecionar();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void btnVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Visualizar();
        }
 

    }
}