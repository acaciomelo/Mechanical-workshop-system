using System;
using System.Windows.Forms;

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Templates;
using MechTech.Entities;
using MechTech.Gateway;
using MechTech.Data;
#endregion

#region DEVEXPRESS
using DevExpress.XtraEditors;
#endregion

namespace MechTech.UI.Vendas
{
    public partial class frmGridOrcamento : frmBase
    {
        private bool isEnabled;
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        Form frmUpdate { get; set; }
        OrcamentoDTO orcamentoDTO = new OrcamentoDTO();
        OrcamentoGL orcamentoGL = new OrcamentoGL();
        Global.SystemDelegate GetOrcamento;
        public frmGridOrcamento()
        {
            InitializeComponent();
            isEnabled = true;
        }

        public frmGridOrcamento(Form frm, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = false;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetOrcamento = target;
        }

        /// <summary>
        /// Instância para frmGridOrcamento com opção de "Seleção" e controle de estado do formulário.
        /// </summary>
        public frmGridOrcamento(Form frm, bool enabled, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = enabled;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetOrcamento = target;
        }

        private void frmGridOrcamento_Load(object sender, EventArgs e)
        {
            try
            {
                frmUpdate.Enabled = isEnabled;
            }
            catch
            { }
        }

        private void frmGridOrcamento_FormClosed(object sender, FormClosedEventArgs e)
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
                        OrcamentoBindingSource.DataSource = orcamentoGL.GetGridOrcamento("id", texto.Text.Replace(";", ","));
                        break;
                    case "CLIENTE":
                        string id_cliente = "";
                        if (texto.Text.Equals(string.Empty))
                            id_cliente = "-1";
                        else
                            try
                            {
                                id_cliente = new ClienteDAO().GetGridCliente("nome", "%" + texto.Text + "%")[0].Id.ToString();
                            }
                            catch
                            {
                                id_cliente = "0";
                            }

                        if (id_cliente.Equals("0"))
                            OrcamentoBindingSource.DataSource = orcamentoGL.GetGridOrcamento("id_cliente", "0");
                        else if (id_cliente.Equals("-1"))
                            OrcamentoBindingSource.DataSource = orcamentoGL.GetGridOrcamento("placa", "%%");
                        else
                            OrcamentoBindingSource.DataSource = orcamentoGL.GetGridOrcamento("id_cliente", id_cliente);
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
            frmUpdateOrcamento frmUpdate = new frmUpdateOrcamento(this, Enumeradores.TipoOperacao.Insert, OrcamentoBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Alterar();
        }

        private void Alterar()
        {
            OrcamentoDTO orcamentoDTO = (OrcamentoDTO)OrcamentoBindingSource.Current;
            if (orcamentoDTO != null)
            {
                if (orcamentoDTO.PosicaoOrcamentoDescricao.Equals("Pedido Finalizado"))
                {
                    MessageBox.Show("Não é possível alterar um orçamento já finalizado!", "Impossível prosseguir!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor = Cursors.Default;
                    return;
                }
            }

            Cursor = Cursors.WaitCursor;
            frmUpdateOrcamento frmUpdate = new frmUpdateOrcamento(this, Enumeradores.TipoOperacao.Update, OrcamentoBindingSource);
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
                orcamentoDTO = (OrcamentoDTO)OrcamentoBindingSource.Current;

                try
                {
                    orcamentoGL.Delete(orcamentoDTO.Id);
                    OrcamentoBindingSource.RemoveCurrent();
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
            base.ShowRibbonPreview(dgdTabela, "Listagem do Cadastro de Orçamentos");
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
                GetOrcamento((OrcamentoDTO)OrcamentoBindingSource.Current);
            }
            catch
            { }

            Close();
        }

        private void btnVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Visualizar();
        }

        private void Visualizar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateOrcamento frmUpdate = new frmUpdateOrcamento(this, Enumeradores.TipoOperacao.Viewer, OrcamentoBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
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

        private void dgdTabela_DoubleClick(object sender, EventArgs e)
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Select)
                Selecionar();
            else
            {
                if (btnEditar.Enabled)
                {
                    OrcamentoDTO orcamentoDTO = (OrcamentoDTO)OrcamentoBindingSource.Current;
                    if (orcamentoDTO != null)
                    {
                        if (orcamentoDTO.PosicaoOrcamentoDescricao.Equals("Pedido Finalizado"))
                        {
                            MessageBox.Show("Não é possível alterar um orçamento já finalizado!", "Impossível prosseguir!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cursor = Cursors.Default;
                            return;
                        }
                    }
                    Cursor = Cursors.WaitCursor;
                    frmUpdateOrcamento frmUpdate = new frmUpdateOrcamento(this, Enumeradores.TipoOperacao.Update, OrcamentoBindingSource);
                    frmUpdate.Show();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            OrcamentoDTO orcamento = (OrcamentoDTO)OrcamentoBindingSource[e.ListSourceRowIndex];

            if (e.Column.FieldName.Equals("Codigo") && e.ListSourceRowIndex >= 0 && e.IsGetData)
                e.Value = orcamento.Codigo;
        }
    }
}