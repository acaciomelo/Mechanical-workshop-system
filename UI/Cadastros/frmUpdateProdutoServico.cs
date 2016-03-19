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
using MechTech.Util.Templates;
using MechTech.Util;
using MechTech.Entities;
using MechTech.Gateway;
using System.IO;
#endregion

namespace MechTech.UI.Cadastros
{
    public partial class frmUpdateProdutoServico : frmBase
    {
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        ProdutoServicoDTO produtoDTO { get; set; }
        ProdutoServicoDTO produtoDTOVersaoOriginal { get; set; }
        BindingSource bndProdutoGrid = new BindingSource();
        ProdutoServicoGL produtoGL = new ProdutoServicoGL();
        Acesso acesso = new Acesso();
        public frmUpdateProdutoServico()
        {
            ValidaTipoLucro();
            InitializeComponent();
        }

        public frmUpdateProdutoServico(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();
            ValidaTipoLucro();
            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndProdutoGrid = bnd;
                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                {
                    ProdutoServicoBindingSource.AddNew();
                }
                else
                {
                    produtoDTO = (ProdutoServicoDTO)bndProdutoGrid.Current;
                    ProdutoServicoBindingSource.DataSource = produtoGL.GetProdutoServico(produtoDTO.Id);
                    produtoDTOVersaoOriginal = new ProdutoServicoDTO((ProdutoServicoDTO)ProdutoServicoBindingSource.Current);
                }
                produtoDTO = (ProdutoServicoDTO)ProdutoServicoBindingSource.Current;
                carregaValores();
            }
            catch
            {
                throw;
            }

            GetFoto();
        }


        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void CategoriaTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridCategoriaProduto frmGrid = new frmGridCategoriaProduto(this, new MechTech.Util.Global.SystemDelegate(SetCategoria));
            frmGrid.Show();
            Cursor = Cursors.Default;
        }
        private void SetCategoria(object categoria)
        {
            CategoriaTextEdit.Text = ((CategoriaProdutoDTO)categoria).Nome.ToString();
            produtoDTO.Categoria = (CategoriaProdutoDTO)categoria;
        }

        private void SetFornecedor(object fornecedor)
        {
            FornecedorTextEdit.Text = ((FornecedorDTO)fornecedor).Nomefantasia.ToString();
            produtoDTO.Fornecedor = (FornecedorDTO)fornecedor;
        }
        private void SetVeiculo(object veiculo)
        {
            UsadoEmTextEdit.Text += ((VeiculoDTO)veiculo).Veiculo.ToString() + ";";
        }

        private void FornecedorTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridFornecedores frmGrid = new frmGridFornecedores(this, new MechTech.Util.Global.SystemDelegate(SetFornecedor));
            frmGrid.Show();
            Cursor = Cursors.Default;
        }

        private void frmUpdateProdutoServico_Load(object sender, System.EventArgs e)
        {
            frmGrid.Enabled = false;

            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Produto ou Serviço";
                    HabilitaDesabilitaBotoesNavegacao(false);
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Produto ou Serviço";
                    HabilitaDesabilitaBotoesNavegacao(true);
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Produto ou Serviço";
                    HabilitaDesabilitaBotoesNavegacao(true);
                    break;
                default:
                    break;
            }

            if (tpOperacao == Enumeradores.TipoOperacao.Viewer)
            {
                acesso.Validate(this);
                acesso.Validate(barManager);
            }
        }
        private void HabilitaDesabilitaBotoesNavegacao(bool enabled)
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Viewer)
                return;

            btnPrimeiro.Enabled = enabled;
            btnAnterior.Enabled = enabled;
            btnProximo.Enabled = enabled;
            btnUltimo.Enabled = enabled;
        }

        private void frmUpdateProdutoServico_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Salvar())
                Close();
        }
        private bool Salvar()
        {
            try
            {
                if (ValidaCampos())
                    return false;

                Cursor = Cursors.WaitCursor;
                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        produtoDTO.Id = produtoGL.Insert((ProdutoServicoDTO)ProdutoServicoBindingSource.Current);
                        bndProdutoGrid.Add(ProdutoServicoBindingSource.Current);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        produtoGL.Update((ProdutoServicoDTO)ProdutoServicoBindingSource.Current);
                        bndProdutoGrid.List[bndProdutoGrid.Position] = ProdutoServicoBindingSource.Current;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            Cursor = Cursors.Default;

            return true;
        }

        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors();

            if (produtoDTO.Descricao.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(DescProdTextEdit, "Descrição inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (produtoDTO.Fornecedor == null || produtoDTO.Fornecedor.Id == 0)
                dxErrorProvider.SetError(FornecedorTextEdit, "Fornecedor inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (produtoDTO.Categoria == null || produtoDTO.Categoria.Id == 0)
                dxErrorProvider.SetError(CategoriaTextEdit, "Categoria inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (dxErrorProvider.HasErrors)
                MessageBox.Show("O Sistema identificou campos obrigatórios não preenchidos ou preenchidos incorretamente. Impossível prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return dxErrorProvider.HasErrors;
        }

        private bool VerificarDados()
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Update)
            {
                if (!((ProdutoServicoDTO)ProdutoServicoBindingSource.Current).Equals(produtoDTOVersaoOriginal))
                {
                    if (MessageBox.Show("O Sistema identificou dados alterados não salvos. Deseja salvá-los antes de prosseguir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        return Salvar();
                    else
                        dxErrorProvider.ClearErrors();
                }
            }

            return true;
        }
        private void Navegar()
        {
            Cursor = Cursors.WaitCursor;
            ProdutoServicoBindingSource.DataSource = produtoGL.GetProdutoServico(((ProdutoServicoDTO)bndProdutoGrid.Current).Id);
            produtoDTO = (ProdutoServicoDTO)ProdutoServicoBindingSource.Current;
            if (produtoDTO.Produtoservico.Equals(0))
                rdgTipo.SelectedIndex = 0;
            else
                rdgTipo.SelectedIndex = 1;
            GetFoto();
            produtoDTOVersaoOriginal = new ProdutoServicoDTO(produtoDTO);
            Cursor = Cursors.Default;
        }

        private void btnPrimeiro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndProdutoGrid.MoveFirst();
            Navegar();
        }

        private void btnAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndProdutoGrid.MovePrevious();
            Navegar();
        }

        private void btnProximo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndProdutoGrid.MoveNext();
            Navegar();
        }

        private void btnUltimo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndProdutoGrid.MoveLast();
            Navegar();
        }

        private void CodBarrasTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void TipoLucroComboBoxEdit_EditValueChanged(object sender, EventArgs e)
        {
            ValidaTipoLucro();
        }

        private void carregaValores()
        {
            try
            {
                double custo = produtoDTO.Custo;
                double venda = produtoDTO.Venda;
                double resultado, resultadoValor = 0;
                resultado = (venda * 100 / custo) - 100;
                resultadoValor = venda - custo;

                if (produtoDTO.TipoLucro.Substring(0, 1) == "P")
                    PercentLucroTextEdit.EditValue = resultado.ToString();
                else
                    VlrLucroTextEdit.EditValue = resultadoValor.ToString();
            }
            catch { }
        }
        private void ValidaTipoLucro()
        {
            if (TipoLucroComboBoxEdit.Text == "Percentual")
            {
                PercentLucroTextEdit.Enabled = true;
                VlrLucroTextEdit.EditValue = "";
                VlrLucroTextEdit.Enabled = false;
            }
            else
            {
                VlrLucroTextEdit.Enabled = true;
                PercentLucroTextEdit.EditValue = "";
                PercentLucroTextEdit.Enabled = false;
            }
        }

        private void PercentLucroTextEdit_Leave(object sender, EventArgs e)
        {
            try
            {
                double custo = double.Parse(CustoTextEdit.EditValue.ToString());
                double porcentagem = double.Parse(PercentLucroTextEdit.Text);
                double resultado = custo + (custo * porcentagem / 100);
                VendaTextEdit.EditValue = resultado.ToString();
                VlrLucroTextEdit.EditValue = Math.Round((resultado - custo), 2).ToString();//Tarefa 22
            }
            catch { }
        }
        private void GetFoto()
        {
            fotopictureEdit.Image = MechTech.Util.Global.LerImagemBinaria(produtoDTO.Foto);
        }
        private void PercentLucroTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void VlrLucroTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void VlrLucroTextEdit_Leave(object sender, EventArgs e)
        {
            try
            {
                double custo = double.Parse(CustoTextEdit.EditValue.ToString());
                double lucro = double.Parse(VlrLucroTextEdit.EditValue.ToString());
                double resultado = custo + lucro;
                VendaTextEdit.EditValue = resultado.ToString();
                PercentLucroTextEdit.EditValue = Math.Round((resultado / custo - 1) * 100, 2).ToString(); //Tarefa 22
            }
            catch { }
        }

        private void fotopictureEdit_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.RestoreDirectory = true;
            file.Filter = "Arquivos de Imagem(*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";
            if (file.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileinfo = new FileInfo(file.FileName);
                decimal filelength = fileinfo.Length / 1024;
                if (filelength > 2000) //2000KB
                {
                    MessageBox.Show("Foto inválida. O tamanho da imagem não deve ser superior a 2000KB.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fotopictureEdit.Image = null;
                    produtoDTO.Foto = null;
                }
                else
                {
                    fotopictureEdit.Image = Image.FromFile(file.FileName);
                    produtoDTO.Foto = MechTech.Util.Global.LerImagem(file.FileName);
                }
            }
            else
            {
                fotopictureEdit.Image = null;
                produtoDTO.Foto = null;
            }
        }

        private void rdgTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdgTipo.SelectedIndex.Equals(-1))
            {
                if (produtoDTO.Produtoservico.Equals(0))
                    rdgTipo.SelectedIndex = 0;
                else
                    rdgTipo.SelectedIndex = 1;
            }
            else
                if (rdgTipo.SelectedIndex.Equals(0))
                    produtoDTO.Produtoservico = 0;
                else
                    produtoDTO.Produtoservico = 1;
        }

        private void VendaTextEdit_Leave(object sender, EventArgs e)
        {
            try
            {
                double venda = double.Parse(VendaTextEdit.EditValue.ToString());
                double custo = double.Parse(CustoTextEdit.EditValue.ToString());
                PercentLucroTextEdit.EditValue = Math.Round(((venda / custo) - 1) * 100, 2).ToString(); //Tarefa 22
                VlrLucroTextEdit.EditValue = Math.Round(venda - custo, 2);
            }
            catch { }
        }

        private void UsadoEmTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridVeiculo frmGrid = new frmGridVeiculo(this, new MechTech.Util.Global.SystemDelegate(SetVeiculo));
            frmGrid.Show();
            Cursor = Cursors.Default;
        }
    }
}