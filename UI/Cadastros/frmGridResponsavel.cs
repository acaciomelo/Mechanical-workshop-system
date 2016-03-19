using System;
using System.Windows.Forms;

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Templates;
using MechTech.Entities;
using MechTech.Gateway;
using MechTech.UI.Cadastros;
#endregion

#region DEVEXPRESS
using DevExpress.XtraEditors;
#endregion

namespace MechTech.UI.Cadastros
{
    public partial class frmGridResponsavel : frmBase
    {
        private bool isEnabled;
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        Form frmUpdate { get; set; }
        ResponsavelDTO responsavelDTO = new ResponsavelDTO();
        ResponsavelGL responsavelGL = new ResponsavelGL();
        Acesso acesso = new Acesso();
        Global.SystemDelegate GetResponsavel;

        public frmGridResponsavel()
        {
            InitializeComponent();
            isEnabled = true;
        }

        /// <summary>
        /// Instância para frmGridResponsavel com opção de "Seleção".
        /// </summary>
        public frmGridResponsavel(Form frm, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = false;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetResponsavel = target;
        }

        /// <summary>
        /// Instância para frmGridResponsavel com opção de "Seleção" e controle de estado do formulário.
        /// </summary>
        public frmGridResponsavel(Form frm, bool enabled, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = enabled;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetResponsavel = target;
        }

        private void frmGridResponsavel_Load(object sender, EventArgs e)
        {
            try
            {
                frmUpdate.Enabled = isEnabled;
            }
            catch
            { }
        }

        private void frmGridResponsavel_FormClosed(object sender, FormClosedEventArgs e)
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
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnVisualizar.Enabled = false;
                btnImprimir.Enabled = false;
                btnSelecionar.Enabled = false;
            }
            else
            {
                btnAlterar.Enabled = true;
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
            if (!ValidaCampos(texto.Text)) return;
            Cursor = Cursors.WaitCursor;
            try
            {
                switch (Filtro.EditValue.ToString().ToUpper())
                {
                    case "CÓDIGO":
                        ResponsavelDTOBindingSource.DataSource = responsavelGL.GetGridResponsavel("id", texto.Text.Replace(";", ","));
                        break;
                    case "NOME":
                        ResponsavelDTOBindingSource.DataSource = responsavelGL.GetGridResponsavel("nome", "%" + texto.Text + "%");
                        break;
                    case "CPF":
                        ResponsavelDTOBindingSource.DataSource = responsavelGL.GetGridResponsavel("cpf", texto.Text + "%");
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
                Pesquisar(sender);
        }

        private void btnInserir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Novo();
        }

        private void Novo()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateResponsavel frmUpdate = new frmUpdateResponsavel(this, Enumeradores.TipoOperacao.Insert, ResponsavelDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void btnAlterar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Alterar();
        }

        private void Alterar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateResponsavel frmUpdate = new frmUpdateResponsavel(this, Enumeradores.TipoOperacao.Update, ResponsavelDTOBindingSource);
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
                responsavelDTO = (ResponsavelDTO)ResponsavelDTOBindingSource.Current;
                Cursor = Cursors.WaitCursor;
                try
                {
                    responsavelGL.Delete(responsavelDTO.Id);
                    ResponsavelDTOBindingSource.RemoveCurrent();
                }
                catch
                {
                    Cursor = Cursors.Default;
                    throw;
                }
                Cursor = Cursors.Default;
            }
        }

        private void btnSelecionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Selecionar();
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
        }

        private void Imprimir()
        {
            base.ShowRibbonPreview(dgdTabela, "Listagem do Cadastro de Responsáveis");
        }

        private void dgdTabela_DoubleClick(object sender, EventArgs e)
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Select)
                Selecionar();
            else
            {
                if (btnAlterar.Enabled)
                {
                    Cursor = Cursors.WaitCursor;
                    frmUpdateResponsavel frmUpdate = new frmUpdateResponsavel(this, Enumeradores.TipoOperacao.Update, ResponsavelDTOBindingSource);
                    frmUpdate.Show();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void bandedGridView1_RowCountChanged(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoes();
        }

        private void bandedGridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ResponsavelDTO responsavel = (ResponsavelDTO)ResponsavelDTOBindingSource[e.ListSourceRowIndex];

            try
            {
                if (e.Column.Name.Equals("colCpf") && e.ListSourceRowIndex >= 0 && e.DisplayText != "")
                    e.DisplayText = Convert.ToInt64(e.DisplayText).ToString(@"000\.000\.000\-00");
            }
            catch { }

            if (e.Column.Name.Equals("colTelefone") && e.ListSourceRowIndex >= 0)
            {
                try
                {
                    if (responsavel.Telefone != string.Empty)
                        e.DisplayText = "(" + responsavel.Dddtelefone + ")" + responsavel.Telefone;
                    else
                        e.DisplayText = string.Empty;
                }
                catch
                { }
            }
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

        private void selecionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selecionar();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void Selecionar()
        {
            try
            {
                GetResponsavel((ResponsavelDTO)ResponsavelDTOBindingSource.Current);
            }
            catch
            { }

            Close();
        }

        private void Filtro_EditValueChanged(object sender, EventArgs e)
        {
            txtConsulta.EditValue = string.Empty;
            if (Filtro.EditValue.ToString().ToUpper() == "CÓDIGO")
            {
                btnPesquisar.Mask.EditMask = "([0-9]+;)*([0-9]+)";
                btnPesquisar.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                btnPesquisar.Mask.ShowPlaceHolders = false;
                btnPesquisar.Mask.UseMaskAsDisplayFormat = true;
            }
            else
            {
                btnPesquisar.Mask.EditMask = string.Empty;
                btnPesquisar.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                btnPesquisar.Mask.ShowPlaceHolders = true;
                btnPesquisar.Mask.UseMaskAsDisplayFormat = false;
            }
        }

        private bool ValidaCampos(string conteudo)
        {
            dxErrorProvider.ClearErrors();

            if (Filtro.EditValue.ToString().ToUpper() == "CÓDIGO")
            {
                if (conteudo.Trim() != string.Empty)
                {
                    if (conteudo.Trim().Substring(conteudo.Trim().Length - 1, 1).Equals(";"))
                    {
                        MessageBox.Show("Conteúdo inválido. Ponto e vírgula (;) identificado no final da expressão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Visualizar();
        }

        private void Visualizar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateResponsavel frmUpdate = new frmUpdateResponsavel(this, Enumeradores.TipoOperacao.Viewer, ResponsavelDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }
    }
}