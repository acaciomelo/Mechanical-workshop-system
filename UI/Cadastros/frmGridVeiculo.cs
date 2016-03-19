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
    public partial class frmGridVeiculo : DevExpress.XtraEditors.XtraForm
    {
        bool isEnabled;
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        VeiculoDTO veiculoDTO = new VeiculoDTO();
        VeiculoGL veiculoGL = new VeiculoGL();
        Global.SystemDelegate GetVeiculo;
        Form frmUpdate { get; set; }

        public frmGridVeiculo()
        {
            InitializeComponent();
            isEnabled = true;
        }

        private void HabilitaDesabilitaBotoes()
        {
            if (dgdVeiculos.FocusedView.DataRowCount == 0)
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
                    case "VEÍCULO":
                        VeiculoDTOBindingSource.DataSource = veiculoGL.GetGridVeiculo("veiculo", "%" + texto.Text + "%");
                        break;
                    case "MARCA":
                        VeiculoDTOBindingSource.DataSource = veiculoGL.GetGridVeiculo("id_Marca", "%" + texto.Text + "%");
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

            if (Filtro.EditValue.ToString().ToUpper() == "PLACA")
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

        private void Visualizar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateVeiculo frmUpdate = new frmUpdateVeiculo(this, Enumeradores.TipoOperacao.Viewer, VeiculoDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Novo()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateVeiculo frmUpdate = new frmUpdateVeiculo(this, Enumeradores.TipoOperacao.Insert, VeiculoDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Alterar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateVeiculo frmUpdate = new frmUpdateVeiculo(this, Enumeradores.TipoOperacao.Update, VeiculoDTOBindingSource);
            frmUpdate.Show();

            Cursor = Cursors.Default;
        }

        private void Excluir()
        {
            if (MessageBox.Show("Deseja realmente excluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                veiculoDTO = (VeiculoDTO)VeiculoDTOBindingSource.Current;

                try
                {
                    veiculoGL.Delete(veiculoDTO.Id);
                    VeiculoDTOBindingSource.RemoveCurrent();
                }
                catch
                {
                    throw;
                }
            }
        }

        private void Imprimir()
        {
            ShowRibbonPreview(dgdVeiculos, "Listagem do Cadastro de Veículos");
        }

        private void Selecionar()
        {
            try
            {
                GetVeiculo((VeiculoDTO)VeiculoDTOBindingSource.Current);
            }
            catch
            { }

            Close();
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

        private void btnInserir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnSelecionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Selecionar();
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
        }

        private void grdView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {

        }

        private void grdView_RowCountChanged(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoes();
        }

        private void dgdVeiculos_DoubleClick(object sender, EventArgs e)
        {
            if (btnAlterar.Enabled)
            {
                Cursor = Cursors.WaitCursor;
                frmUpdateVeiculo frmUpdate = new frmUpdateVeiculo(this, Enumeradores.TipoOperacao.Update, VeiculoDTOBindingSource);
                frmUpdate.Show();
                Cursor = Cursors.Default;

            }
        }

        private void btnPesquisar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Pesquisar(sender);
        }

        private void btnPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                Pesquisar(sender);
        }

        private void txtConsulta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void frmGridVeiculo_Load(object sender, EventArgs e)
        {

            try
            {
                frmUpdate.Enabled = isEnabled;
            }
            catch
            { }
        }

        public frmGridVeiculo(Form frm, Global.SystemDelegate target)
        {
            InitializeComponent();
            tpOperacao = Enumeradores.TipoOperacao.Select;
            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;
            GetVeiculo = target;
            isEnabled = false;
        }

        private void btnVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Visualizar();
        }

        private void dgdVeiculos_Click(object sender, EventArgs e)
        {

        }

        private void frmGridVeiculo_Activated(object sender, EventArgs e)
        {

        }

        private void frmGridVeiculo_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled == true)
            {
                if (veiculoDTO.Veiculo != null)
                    VeiculoDTOBindingSource.DataSource = veiculoGL.GetGridVeiculo("veiculo", "%" + veiculoDTO.Veiculo + "%");
            }
        }

        private void frmGridVeiculo_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmUpdate.Enabled = true;
            }
            catch
            { }
        }
    }
}