using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

#region MECHTECH
using MechTech.Util.Templates;
using MechTech.Util;
using MechTech.Entities;
using MechTech.Gateway;
#endregion

#region DEVEXPRESS
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
#endregion

namespace MechTech.UI.Cadastros
{
    public partial class frmGridVeiculosVinc : DevExpress.XtraEditors.XtraForm
    {

        bool isEnabled;
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        VincularVeiculoDTO vincularveiculoDTO = new VincularVeiculoDTO();
        VincularVeiculoGL vincularveiculoGL = new VincularVeiculoGL();
        Global.SystemDelegate GetVeiculoVinc;
        Form frmUpdate { get; set; }

        public frmGridVeiculosVinc()
        {
            InitializeComponent();
            isEnabled = true;
        }

        public frmGridVeiculosVinc(Form frm, Global.SystemDelegate target)
        {
            InitializeComponent();
            tpOperacao = Enumeradores.TipoOperacao.Select;
            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;
            GetVeiculoVinc = target;
            isEnabled = false;
        }

        private void frmGridVeiculosVinc_Load(object sender, EventArgs e)
        {
            try
            {
                frmUpdate.Enabled = isEnabled;
            }
            catch
            { }
        }

        private void HabilitaDesabilitaBotoes()
        {
            if (dgdVeiculosVinc.FocusedView.DataRowCount == 0)
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
                    case "PLACA":
                        VeiculoVincBindingSource.DataSource = vincularveiculoGL.GetGridVincularVeiculo("placa", "%" + texto.Text + "%");
                        break;
                    case "VEÍCULO":
                        VeiculoVincBindingSource.DataSource = vincularveiculoGL.GetGridVincularVeiculo("veiculo", "%" + texto.Text + "%");
                        break;
                    case "CLIENTE":
                        VeiculoVincBindingSource.DataSource = vincularveiculoGL.GetGridVincularVeiculo("nome", "%" + texto.Text + "%");
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
            frmVincularVeiculo frmUpdate = new frmVincularVeiculo(this, Enumeradores.TipoOperacao.Viewer, VeiculoVincBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Novo()
        {
            Cursor = Cursors.WaitCursor;
            frmVincularVeiculo frmUpdate = new frmVincularVeiculo(this, Enumeradores.TipoOperacao.Insert, VeiculoVincBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Alterar()
        {
            Cursor = Cursors.WaitCursor;
            frmVincularVeiculo frmUpdate = new frmVincularVeiculo(this, Enumeradores.TipoOperacao.Update, VeiculoVincBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Excluir()
        {
            if (MessageBox.Show("Deseja realmente excluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                vincularveiculoDTO = (VincularVeiculoDTO)VeiculoVincBindingSource.Current;

                try
                {
                    vincularveiculoGL.Delete(vincularveiculoDTO.Id);
                    VeiculoVincBindingSource.RemoveCurrent();
                }
                catch
                {
                    throw;
                }
            }
        }

        private void Imprimir()
        {
            ShowRibbonPreview(dgdVeiculosVinc, "Listagem de Veículos Vinculados");
        }

        private void Selecionar()
        {
            try
            {
                GetVeiculoVinc((VincularVeiculoDTO)VeiculoVincBindingSource.Current);
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

        private void frmGridVeiculosVinc_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmUpdate.Enabled = true;
            }
            catch
            { }
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

        private void btnVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Visualizar();
        }

        private void btnSelecionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Selecionar();
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

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

        private void grdView_RowCountChanged(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoes();
        }

        private void dgdVeiculosVinc_DoubleClick(object sender, EventArgs e)
        {
            if (btnAlterar.Enabled)
            {
                Cursor = Cursors.WaitCursor;
                frmVincularVeiculo frmUpdate = new frmVincularVeiculo(this, Enumeradores.TipoOperacao.Update, VeiculoVincBindingSource);
                frmUpdate.Show();
                Cursor = Cursors.Default;

            }
        }

    }
}