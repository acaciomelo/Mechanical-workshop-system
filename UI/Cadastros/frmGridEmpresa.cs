using System;
using System.Windows.Forms;

#region MechTech
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
    public partial class frmGridEmpresa : frmBase
    {
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        EmpresaDTO empresaDTO = new EmpresaDTO();
        EmpresaGL empresaGL = new EmpresaGL();
        Global.SystemDelegate GetEmpresa;
        Form frmUpdate { get; set; }
        bool isEnabled;
        public frmGridEmpresa()
        {
            InitializeComponent();
            isEnabled = true;
        }

        public frmGridEmpresa(Form frm, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = false;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetEmpresa = target;
        }
        public frmGridEmpresa(Form frm, bool enabled, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = enabled;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetEmpresa = target;
        }
        private void btnInserir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Novo();
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
        }

        private void Filtro_EditValueChanged(object sender, EventArgs e)
        {
            txtConsulta.EditValue = string.Empty;
            if (Filtro.EditValue.ToString().ToUpper() == "CÓDIGO")
            {
                btnPesquisa.Mask.EditMask = "([0-9]+;)*([0-9]+)";
                btnPesquisa.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                btnPesquisa.Mask.ShowPlaceHolders = false;
                btnPesquisa.Mask.UseMaskAsDisplayFormat = true;
            }
            else
            {
                btnPesquisa.Mask.EditMask = string.Empty;
                btnPesquisa.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                btnPesquisa.Mask.ShowPlaceHolders = true;
                btnPesquisa.Mask.UseMaskAsDisplayFormat = false;
            }
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
                        EmpresaDTOBindingSource.DataSource = empresaGL.GetGridEmpresa("id", texto.Text.Replace(";", ","));
                        break;
                    case "NOME FANTASIA":
                        EmpresaDTOBindingSource.DataSource = empresaGL.GetGridEmpresa("nomefantasia", "%" + texto.Text + "%");
                        break;
                    case "RAZÃO SOCIAL":
                        EmpresaDTOBindingSource.DataSource = empresaGL.GetGridEmpresa("razaosocial", "%" + texto.Text + "%");
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

        private void Novo()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateEmpresa frmUpdate = new frmUpdateEmpresa(this, Enumeradores.TipoOperacao.Insert, EmpresaDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }
        private void Alterar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateEmpresa frmUpdate = new frmUpdateEmpresa(this, Enumeradores.TipoOperacao.Update, EmpresaDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Excluir()
        {
            if (MessageBox.Show("Deseja realmente excluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                empresaDTO = (EmpresaDTO)EmpresaDTOBindingSource.Current;

                try
                {
                    empresaGL.Delete(empresaDTO.Id);
                    EmpresaDTOBindingSource.RemoveCurrent();
                }
                catch
                {
                    throw;
                }
            }
        }

        private void Imprimir()
        {
            base.ShowRibbonPreview(dgdTabela, "Listagem do Cadastro de Empresas");
            //new LOGGL().GravaLOG(1095, string.Empty);
        }

        private void Visualizar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateEmpresa frmUpdate = new frmUpdateEmpresa(this, Enumeradores.TipoOperacao.Viewer, EmpresaDTOBindingSource);
            frmUpdate.Show();
            //new LOGGL().GravaLOG(1094, string.Empty);
            Cursor = Cursors.Default;
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

        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            EmpresaDTO empresa = (EmpresaDTO)EmpresaDTOBindingSource[e.ListSourceRowIndex];

            if (e.Column.Name.Equals("colCnpj") && e.ListSourceRowIndex >= 0)
            {
                try
                {
                    if (empresa.Tipo == "J") //PESSOA JURÍDICA (CNPJ)
                        e.DisplayText = Convert.ToInt64(e.DisplayText).ToString(@"00\.000\.000\/0000\-00");
                    else //PESSOA FÍSICA (CPF)
                        e.DisplayText = Convert.ToInt64(e.DisplayText).ToString(@"000\.000\.000\-00");
                }
                catch
                { }
            }
        }

        private void dgdTabela_DoubleClick(object sender, EventArgs e)
        {
            if (btnEditar.Enabled)
            {
                Cursor = Cursors.WaitCursor;
                frmUpdateEmpresa frmUpdate = new frmUpdateEmpresa(this, Enumeradores.TipoOperacao.Update, EmpresaDTOBindingSource);
                frmUpdate.Show();
                Cursor = Cursors.Default;
            }
        }

        private void gridView_RowCountChanged(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoes();
        }

        private void btnSelecionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Selecionar();
        }

        private void Selecionar()
        {
            try
            {
                GetEmpresa((EmpresaDTO)EmpresaDTOBindingSource.Current);
            }
            catch
            { }

            Close();
        }
    }
}