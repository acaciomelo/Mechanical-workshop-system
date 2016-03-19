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
using MechTech.Entities;
using MechTech.Gateway;
using DevExpress.XtraPrinting;
using System.Drawing.Printing;


namespace MechTech.UI.Cadastros
{
    public partial class frmGridFornecedores : XtraForm
    {
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        FornecedorDTO fornecedorDTO = new FornecedorDTO();
        FornecedorGL fornecedorGL = new FornecedorGL();
        bool isEnabled;
        Global.SystemDelegate GetFornecedor;
        Form frmUpdate { get; set; }


        public frmGridFornecedores()
        {
            InitializeComponent();
        }
        public frmGridFornecedores(Form frm, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = false;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetFornecedor = target;
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
                        FornecedorDTOBindingSource.DataSource = fornecedorGL.GetGridFornecedor("id", texto.Text.Replace(";", ","));
                        break;
                    case "NOME FANTASIA":
                        FornecedorDTOBindingSource.DataSource = fornecedorGL.GetGridFornecedor("nomefantasia", "%" + texto.Text + "%");
                        break;
                    case "RAZÃO SOCIAL":
                        FornecedorDTOBindingSource.DataSource = fornecedorGL.GetGridFornecedor("razaosocial", "%" + texto.Text + "%");
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
            frmUpdateFornecedor frmUpdate = new frmUpdateFornecedor(this, Enumeradores.TipoOperacao.Viewer, FornecedorDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void btnNovo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Novo();
        }
        private void Novo()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateFornecedor frmUpdate = new frmUpdateFornecedor(this, Enumeradores.TipoOperacao.Insert, FornecedorDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Alterar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateFornecedor frmUpdate = new frmUpdateFornecedor(this, Enumeradores.TipoOperacao.Update, FornecedorDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Excluir()
        {
            if (MessageBox.Show("Deseja realmente excluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                fornecedorDTO = (FornecedorDTO)FornecedorDTOBindingSource.Current;

                try
                {
                    fornecedorGL.Delete(fornecedorDTO.Id);
                    FornecedorDTOBindingSource.RemoveCurrent();
                }
                catch
                {
                    throw;
                }
            }
        }

        private void Imprimir()
        {
            ShowRibbonPreview(dgdTabela, "Listagem do Cadastro de Fornecedores");
        }

        private void dgdTabela_DoubleClick(object sender, EventArgs e)
        {
            if (btnAlterar.Enabled)
            {
                Cursor = Cursors.WaitCursor;
                frmUpdateFornecedor frmUpdate = new frmUpdateFornecedor(this, Enumeradores.TipoOperacao.Update, FornecedorDTOBindingSource);
                frmUpdate.Show();
                Cursor = Cursors.Default;
            }
        }

        private void btnAlterar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Alterar();
        }

        private void btnExcluir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Excluir();
        }

        private void grdView_RowCountChanged(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoes();
        }

        private void grdView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            FornecedorDTO fornecedor = (FornecedorDTO)FornecedorDTOBindingSource[e.ListSourceRowIndex];

            if (e.Column.Name.Equals("colCnpj") && e.ListSourceRowIndex >= 0)
            {
                try
                {
                    e.DisplayText = Convert.ToInt64(e.DisplayText).ToString(@"00\.000\.000\/0000\-00");
                }
                catch
                { }
            }
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

        public void ShowRibbonPreview(IPrintable component, string title)
        {
            //HEADER
            PageHeaderArea header = new PageHeaderArea();
            header.Content.Add(string.Empty);
            header.Content.Add(title);
            header.LineAlignment = BrickAlignment.Center;
            header.Font = new Font("Tahoma", 16, FontStyle.Bold);

            //FOOTER
            PageFooterArea footer = new PageFooterArea();
            footer.Content.AddRange(new string[] { "", "", "Página: [Page #]" });

            //UNION HEADER/FOOTER
            PageHeaderFooter headerfooter = new PageHeaderFooter(header, footer);

            PrintableComponentLink print = new PrintableComponentLink(new PrintingSystem());
            print.Component = component;
            print.PageHeaderFooter = headerfooter;
            print.PaperKind = PaperKind.A4;
            print.Margins = new Margins(60, 30, 60, 60);
            print.CreateDocument();
            print.ShowRibbonPreview(this.LookAndFeel);
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
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

        private void btnSelecionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Selecionar();
        }
        private void Selecionar()
        {
            try
            {
                GetFornecedor((FornecedorDTO)FornecedorDTOBindingSource.Current);
            }
            catch
            { }

            Close();
        }
    }
}