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

#region MechTech
using MechTech.Util;
using MechTech.Util.Templates;
using MechTech.Entities;
using MechTech.Gateway;
using MechTech.Data;
#endregion

namespace MechTech.UI.Vendas
{
    public partial class frmLancamentoProdServ : frmBase
    {
        LancamentoProdutoServicoDTO lancamentoProdutoServicoDTO;
        LancamentoProdutoServicoDTO lancamentoProdutoServicoDTOVersaoOriginal;
        OrcamentoDTO orcamentoDTO;
        ProdutoServicoDTO produtoservicoDTO;
        BindingSource bndOrcamentoProdutoGrid = new BindingSource();
        BindingSource bndOrcamento = new BindingSource();
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        MechTech.Util.Global.SystemDelegate GetOrcamentoProduto = null;
        DateTime dataprocessamento;
        public frmLancamentoProdServ()
        {
            InitializeComponent();
            dataprocessamento = MechTech.Util.Global.MesanoAtivo;
        }

        public frmLancamentoProdServ(Enumeradores.TipoOperacao tpo, BindingSource bnd, BindingSource bndOrc, MechTech.Util.Global.SystemDelegate target)
        {
            InitializeComponent();

            try
            {
                tpOperacao = tpo;
                bndOrcamentoProdutoGrid = bnd;
                bndOrcamento = bndOrc;
                GetOrcamentoProduto = target;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                {
                    OrcamentoProdutoServicoBindingSource.AddNew();
                    List<ProdutoServicoDTO> listaProdutos = new List<ProdutoServicoDTO>();
                    listaProdutos = new ProdutoServicoDAO().GetGridProdutoServico("descricao", "%" + "" + "%");
                    ProdutoServicoBindingSource.DataSource = listaProdutos;
                    lookUpEditProdutoServico.Enabled = true;
                }
                else
                {
                    lookUpEditProdutoServico.Enabled = false;
                    lancamentoProdutoServicoDTO = (LancamentoProdutoServicoDTO)bndOrcamentoProdutoGrid.Current;
                    OrcamentoProdutoServicoBindingSource.DataSource = lancamentoProdutoServicoDTO;
                    ProdutoServicoBindingSource.DataSource = lancamentoProdutoServicoDTO.Produto;
                    lancamentoProdutoServicoDTOVersaoOriginal = new LancamentoProdutoServicoDTO(lancamentoProdutoServicoDTO);
                }

                orcamentoDTO = (OrcamentoDTO)bndOrc.Current;
                lancamentoProdutoServicoDTO = (LancamentoProdutoServicoDTO)OrcamentoProdutoServicoBindingSource.Current;
                lblProdutoServico.Text = "[" + lancamentoProdutoServicoDTO.Produto.Descricao.Trim() + "]";

                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        this.Text = "Inserir Produto ou Serviço";
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        this.Text = "Atualizar Produto ou Serviço";
                        break;
                    case Enumeradores.TipoOperacao.Viewer:
                        this.Text = "Vizualizar Produto ou Serviço";
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                throw;
            }
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Salvar();
        }

        private void Salvar()
        {
            try
            {
                if (this.ValidaCampos()) return;

                Cursor = Cursors.WaitCursor;
                int posicao = 0;

                foreach (LancamentoProdutoServicoDTO contem in bndOrcamentoProdutoGrid.List)
                {
                    if (contem.Produto.Id.Equals(((ProdutoServicoDTO)lookUpEditProdutoServico.Properties.GetDataSourceRowByKeyValue(lookUpEditProdutoServico.EditValue)).Id))
                    {
                        tpOperacao = Enumeradores.TipoOperacao.Update;
                        bndOrcamentoProdutoGrid.Position = posicao;
                        break;
                    }
                    posicao++;
                }

                produtoservicoDTO = (ProdutoServicoDTO)lookUpEditProdutoServico.GetSelectedDataRow();
                produtoservicoDTO = new ProdutoServicoDAO().GetProdutoServico(produtoservicoDTO.Id);
                int qtd = int.Parse(txtQuantidade.Text);

                if (!VerificarEstoqueProduto(qtd))
                    return;

                lancamentoProdutoServicoDTO.Produto = produtoservicoDTO;
                if (lancamentoProdutoServicoDTO.Produto.Produtoservico.Equals(0))
                    lancamentoProdutoServicoDTO.Tipo = "P";
                else
                    lancamentoProdutoServicoDTO.Tipo = "S";
                lancamentoProdutoServicoDTO.ValorTotal = lancamentoProdutoServicoDTO.ValorUnitario * lancamentoProdutoServicoDTO.Quantidade;
                lancamentoProdutoServicoDTO.ValorLiquido = lancamentoProdutoServicoDTO.ValorTotal - lancamentoProdutoServicoDTO.ValorDesconto;

                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        bndOrcamentoProdutoGrid.Add(lancamentoProdutoServicoDTO);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        bndOrcamentoProdutoGrid.List[bndOrcamentoProdutoGrid.Position] = lancamentoProdutoServicoDTO;
                        break;
                }

                Recalcula();
                GetOrcamentoProduto(lancamentoProdutoServicoDTO);
                tpOperacao = Enumeradores.TipoOperacao.Insert;
                OrcamentoProdutoServicoBindingSource.AddNew();
                lancamentoProdutoServicoDTO = (LancamentoProdutoServicoDTO)OrcamentoProdutoServicoBindingSource.Current;

                this.Text = "Inserir Produto";
                calcEditValorDesconto.Focus();
                lblProdutoServico.Text = "[]";
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            Cursor = Cursors.Default;
        }

        private bool VerificarEstoqueProduto(int qtd)
        {
            if (produtoservicoDTO != null)
                if (qtd > produtoservicoDTO.EstoqueAtual)
                {
                    MessageBox.Show("Quantidade acima do estoque atual. Estoque Atual: " + produtoservicoDTO.EstoqueAtual.ToString(), "Impossível Prosseguir!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantidade.Focus();
                    return false;
                }

            return true;
        }

        private void Recalcula()
        {
            orcamentoDTO.ValorLiquido = 0;
            foreach (LancamentoProdutoServicoDTO contem in bndOrcamentoProdutoGrid.List)
            {
                orcamentoDTO.ValorLiquido += contem.ValorLiquido;
            }
        }
        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors();

            if (lancamentoProdutoServicoDTO.Produto.Descricao.Equals(string.Empty))
                dxErrorProvider.SetError(lookUpEditProdutoServico, "Produto ou Serviço inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (lancamentoProdutoServicoDTO.Quantidade < 1)
                dxErrorProvider.SetError(txtQuantidade, "Quantidade inválida. O valor deve ser superior ou igual a 1.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);

            if (lancamentoProdutoServicoDTO.ValorUnitario < 0)
                dxErrorProvider.SetError(calcEditValorUnitario, "Valor unitário inválido. O valor deve ser superior ou igual a 0.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);

            if (lancamentoProdutoServicoDTO.ValorDesconto < 0)
                dxErrorProvider.SetError(calcEditValorDesconto, "Valor de desconto inválido. O valor deve ser superior ou igual a 0.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);

            return dxErrorProvider.HasErrors;
        }

        private void lookUpEditProdutoServico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void calcEditValorDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Salvar();
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int qtd = int.Parse(txtQuantidade.Text);

            if (!VerificarEstoqueProduto(qtd))
                return;
            Close();
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == ','
                && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void lookUpEditProdutoServico_EditValueChanged(object sender, EventArgs e)
        {
            if (!lookUpEditProdutoServico.IsModified)
                return;
            else
            {
                try
                {
                    produtoservicoDTO = (ProdutoServicoDTO)(lookUpEditProdutoServico.Properties.GetDataSourceRowByKeyValue(lookUpEditProdutoServico.EditValue));
                    if (produtoservicoDTO == null) return;
                    produtoservicoDTO = new ProdutoServicoDAO().GetProdutoServico(produtoservicoDTO.Id);
                    calcEditValorUnitario.EditValue = produtoservicoDTO.Venda;
                    lookUpEditProdutoServico.EditValue = produtoservicoDTO.Descricao;
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}