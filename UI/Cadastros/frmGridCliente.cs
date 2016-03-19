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
    public partial class frmGridCliente : DevExpress.XtraEditors.XtraForm
    {

        Enumeradores.TipoOperacao tpOperacao { get; set; }
        ClienteDTO clienteDTO = new ClienteDTO();
        ClienteGL clienteGL = new ClienteGL();
        Global.SystemDelegate GetCliente;
        Form frmUpdate { get; set; }
        
        private bool isEnabled;
        
        public frmGridCliente()
        {
            InitializeComponent();
        }

       public frmGridCliente(Form frm, Global.SystemDelegate target)
        {
            InitializeComponent();
            isEnabled = false;
            tpOperacao = Enumeradores.TipoOperacao.Select;
            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;
            GetCliente = target;
        }

        private void HabilitaDesabilitaBotoes()
        {
            if (dgdClientes.FocusedView.DataRowCount == 0)
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
               
                    case "NOME":
                        ClienteDTOBindingSource.DataSource = clienteGL.GetGridCliente("nome", "%" + texto.Text + "%");
                        break;
                    case "CÓDIGO":
                        ClienteDTOBindingSource.DataSource = clienteGL.GetGridCliente("id", texto.Text.Replace(";", ","));
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

        private void Visualizar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateCliente frmUpdate = new frmUpdateCliente(this, Enumeradores.TipoOperacao.Viewer, ClienteDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Novo()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateCliente frmUpdate = new frmUpdateCliente(this, Enumeradores.TipoOperacao.Insert, ClienteDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Alterar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateCliente frmUpdate = new frmUpdateCliente(this, Enumeradores.TipoOperacao.Update, ClienteDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Excluir()
        {
            if (MessageBox.Show("Deseja realmente excluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                clienteDTO = (ClienteDTO)ClienteDTOBindingSource.Current;

                try
                {
                    clienteGL.Delete(clienteDTO.Id);
                    ClienteDTOBindingSource.RemoveCurrent();
                }
                catch
                {
                    throw;
                }
            }
        }

        private void Imprimir()
        {
            ShowRibbonPreview(dgdClientes, "Listagem do Cadastro de Clientes");
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

        private void frmGridCliente_Load(object sender, EventArgs e)
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

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
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

        private void Filtro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void txtConsulta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void txtConsulta_ItemDoubleClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Pesquisar(sender);
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

        private void dgdClientes_DoubleClick(object sender, EventArgs e)
        {
            if (btnAlterar.Enabled)
            {
                Cursor = Cursors.WaitCursor;
                frmUpdateCliente frmUpdate = new frmUpdateCliente(this, Enumeradores.TipoOperacao.Update, ClienteDTOBindingSource);
                frmUpdate.Show();
                Cursor = Cursors.Default;
            }
        }

        private void grdView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ClienteDTO cliente = (ClienteDTO)ClienteDTOBindingSource[e.ListSourceRowIndex];

            if (e.Column.Name.Equals("colCpf_Cnpj") && e.ListSourceRowIndex >= 0)
            {
                try
                {
                    if (cliente.Tipo_pessoa == "J") //PESSOA JURÍDICA (CNPJ)
                        e.DisplayText = Convert.ToInt64(e.DisplayText).ToString(@"00\.000\.000\/0000\-00");
                    else //PESSOA FÍSICA (CPF)
                        e.DisplayText = Convert.ToInt64(e.DisplayText).ToString(@"000\.000\.000\-00");
                }
                catch
                { }
            }
        }

        private void grdView_LeftCoordChanged(object sender, EventArgs e)
        {

        }

        private void grdView_RowCountChanged(object sender, EventArgs e)
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
                GetCliente((ClienteDTO)ClienteDTOBindingSource.Current);
            }
            catch
            { }

            Close();
        }

        private void frmGridCliente_FormClosed(object sender, FormClosedEventArgs e)
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