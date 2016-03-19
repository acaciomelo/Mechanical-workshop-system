using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

#region DevExpress
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
#endregion

#region MechTech
using MechTech.Util.Templates;
using MechTech.Util;
using MechTech.Gateway;
using MechTech.Entities;
using MechTech.UI.Cadastros;
using MechTech.Util.Forms;
using MechTech.UI.Vendas.Reports;
#endregion


namespace MechTech.UI.Vendas
{
    public partial class frmUpdateOrcamento : frmBase
    {
        FuncionarioGL funcionarioGL = new FuncionarioGL();
        OrcamentoGL orcamentoGL = new OrcamentoGL();
        ProdutoServicoGL produtoGL = new ProdutoServicoGL();
        VincularVeiculoGL vincularGL = new VincularVeiculoGL();
        ClienteGL clienteGL = new ClienteGL();
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        Enumeradores.TipoOperacao tpOperacao2 { get; set; }
        ClienteDTO clienteDTO { get; set; }
        OrcamentoDTO orcamentoDTO { get; set; }
        OrcamentoDTO orcamentoDTOVersaoOriginal { get; set; }
        BindingSource bndOrcamentoGrid = new BindingSource();
        Acesso acesso = new Acesso();
        public frmUpdateOrcamento()
        {
            InitializeComponent();
        }

        public frmUpdateOrcamento(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndOrcamentoGrid = bnd;
                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                    OrcamentoDTOBindingSource.AddNew();
                else
                {
                    orcamentoDTO = orcamentoGL.GetOrcamento(((OrcamentoDTO)bndOrcamentoGrid.Current).Id);
                    OrcamentoDTOBindingSource.DataSource = orcamentoDTO;
                    orcamentoDTO.Cliente = clienteGL.GetCliente(orcamentoDTO.Cliente.Id);
                    Recalcula();
                }

                orcamentoDTO = (OrcamentoDTO)OrcamentoDTOBindingSource.Current;
                orcamentoDTOVersaoOriginal = new OrcamentoDTO(orcamentoDTO);
            }
            catch
            {
                throw;
            }
        }

        private void GetPlacaCliente()
        {
            try
            {
                List<VincularVeiculoDTO> vinculos = new List<VincularVeiculoDTO>();
                vinculos = vincularGL.GetPlacasCliente(orcamentoDTO.Cliente.Id);
                List<PlacaVeiculoDTO> placasDTO = new List<PlacaVeiculoDTO>();
                if (vinculos.Count > 0)
                {
                    foreach (var item in vinculos)
                    {
                        PlacaVeiculoDTO placa = new PlacaVeiculoDTO();
                        placa.Placa = item.Placa;
                        placa.Veiculo = item.Veiculo;
                        placa.Id_Vinculo = item.Id;
                        placasDTO.Add(placa);
                    }
                }
                PlacasBindingSource.DataSource = placasDTO;
            }
            catch { throw; }
        }

        private void frmUpdateOrcamento_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;

            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Orçamento";
                    HabilitaDesabilitaBotoesNavegacao(false);
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Orçamento";
                    Recalcula();
                    orcamentoDTOVersaoOriginal.ValorLiquido = orcamentoDTO.ValorLiquido;
                    HabilitaDesabilitaBotoesNavegacao(true);
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Orçamento";
                    Recalcula();
                    orcamentoDTOVersaoOriginal.ValorLiquido = orcamentoDTO.ValorLiquido;
                    HabilitaDesabilitaBotoesNavegacao(true);
                    break;
                default:
                    break;
            }

            if (tpOperacao == Enumeradores.TipoOperacao.Viewer)
            {
                acesso.Validate(this);
                acesso.Validate(barManager);

                DesabilitarBotoesItensOrcamento(false);
            }
            else
            {
                DesabilitarBotoesItensOrcamento(true);
            }

            FormaRecebimentoBindingSource.DataSource = Veiculo.ObterTipoRecebimento();
            PosicaoBindingSource.DataSource = Veiculo.ObterPosicaoOrcamento();
            ParcelasBindingSource.DataSource = Veiculo.ObterQuantidadeParcelas();

            if (orcamentoDTO != null)
                lookUpEditPosicao.EditValue = orcamentoDTO.PosicaoOrcamentoDescricao;

            List<FuncionarioSEDTO> listFunc = new List<FuncionarioSEDTO>();
            listFunc = funcionarioGL.GetGridFuncionarioSE("nomecompleto", "%" + "" + "%", MechTech.Util.Enumeradores.Modulo.Funcionario, false);
            foreach (var funcionario in listFunc)
            {
                ComboBoxItemCollection coll = cmbFuncionarios.Properties.Items;
                coll.BeginUpdate();
                try
                {
                    coll.Add(funcionario.NomeCompleto);
                }
                finally
                {
                    coll.EndUpdate();
                }
            }

            if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
            {
                dataOrcamentodateEdit.EditValue = DateTime.Today;
                lookUpEditPosicao.ItemIndex = 0;
                cmbFuncionarios.SelectedIndex = -1;
            }

            VerificarDiferencaRecebimento();
            AtualizarDetalhesEspecieRecebimento();
        }

        private void DesabilitarBotoesItensOrcamento(bool enabled)
        {
            btnInserirProdServ.Visible = enabled;
            btnEditarProdServ.Visible = enabled;
            btnGerarOS.Visible = enabled;
            btnExcluirProdServ.Visible = enabled;
            btnRecalculo.Visible = enabled;
            DigitarOrcamentoToolStripMenuItem.Enabled = enabled;
            AlterarOrcamentoToolStripMenuItem.Enabled = enabled;
            ExcluirOrcamentoToolStripMenuItem.Enabled = enabled;
            ExcluirTudoOrcamentoToolStripMenuItem.Enabled = enabled;
        }

        private void VerificaTipoRecebimento()
        {
            lookUpEditFormaRecebimento.Text = Veiculo.ObterTipoRecebimento(orcamentoDTO.IdEspecieRecebimento).Descricao;
        }
        private void VerificaParcelasRecebimento()
        {
            lookUpEditParcelasRecebimento.Text = Veiculo.ObterQuantidadeParcelas(orcamentoDTO.QuantidadeParcelas).Descricao;
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
        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnInserirProdServ_Click(object sender, EventArgs e)
        {
            InserirProdutoServico();
        }
        private void Recalcula()
        {
            try
            {
                orcamentoDTO = (OrcamentoDTO)OrcamentoDTOBindingSource.Current;
                orcamentoGL.CalculaOrcamento(orcamentoDTO);
                ValorLiquidoTextEdit.Text = orcamentoDTO.ValorLiquido.ToString();
                GetPlacaCliente();
                VerificaTipoRecebimento();
                VerificaParcelasRecebimento();
                VerificarDiferencaRecebimento();
                AtualizarDetalhesEspecieRecebimento();
            }
            catch
            { }
        }
        private void InserirProdutoServico()
        {
            Cursor = Cursors.WaitCursor;
            frmLancamentoProdServ frmUpdate = new frmLancamentoProdServ(Enumeradores.TipoOperacao.Insert, OrcamentoProdutoServicoBindingSource, OrcamentoDTOBindingSource, new MechTech.Util.Global.SystemDelegate(SetOrcamento));
            frmUpdate.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void btnEditarProdServ_Click(object sender, EventArgs e)
        {
            EditarProdutoServico();
        }

        private void EditarProdutoServico()
        {
            if (tpOperacao2 == Enumeradores.TipoOperacao.Viewer)
                return;

            if (orcamentoDTO.Produtoservico.Count <= 0)
                return;

            Cursor = Cursors.WaitCursor;
            frmLancamentoProdServ frmupdatedigitacaoevento = new frmLancamentoProdServ(Enumeradores.TipoOperacao.Update, OrcamentoProdutoServicoBindingSource, OrcamentoDTOBindingSource, new MechTech.Util.Global.SystemDelegate(SetOrcamento));
            frmupdatedigitacaoevento.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void SetOrcamento(object produtoservico)
        {
            Cursor = Cursors.WaitCursor;
            SetTotais();
            OrcamentoGridControl.RefreshDataSource();
            OrcamentoDTOBindingSource.DataSource = orcamentoDTO;
            Cursor = Cursors.Default;
        }
        private void SetTotais()
        {
            ValorLiquidoTextEdit.EditValue = orcamentoDTO.ValorLiquido;
        }

        private void btnExcluirProdServ_Click(object sender, EventArgs e)
        {
            ExcluirProdutoServico();
        }

        private void ExcluirProdutoServico()
        {
            if (orcamentoDTO.Produtoservico.Count <= 0)
                return;

            if (MessageBox.Show("Deseja realmente excluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    OrcamentoProdutoServicoBindingSource.RemoveCurrent();
                    SetOrcamento(null);
                }
                catch
                {
                    throw;
                }
            }
        }

        private void frmUpdateOrcamento_ForeColorChanged(object sender, EventArgs e)
        {
            frmGrid.Enabled = true;
        }

        private void frmUpdateOrcamento_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
        }
        private void SetCliente(object cliente)
        {
            orcamentoDTO.Cliente = clienteGL.GetCliente(((ClienteDTO)cliente).Id);
            ClientesButtonEdit.Text = orcamentoDTO.Cliente.Nome.ToString();
            if (orcamentoDTO.Cliente.Cpf_Cnpj.Length > 11) //PESSOA JURÍDICA (CNPJ)
                txtCPFCNPJ.Properties.Mask.EditMask = "99.999.999/9999-99";
            else //PESSOA FÍSICA (CPF)
                txtCPFCNPJ.Properties.Mask.EditMask = "999.999.999-99";
            txtCPFCNPJ.Text = orcamentoDTO.Cliente.Cpf_Cnpj.ToString();
            try
            {
                GetPlacaCliente();
            }
            catch { throw; }
        }

        private void ClientesButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridCliente frmGrid = new frmGridCliente(this, new MechTech.Util.Global.SystemDelegate(SetCliente));
            frmGrid.Show();
            Cursor = Cursors.Default;
        }

        private void gridView_RowCountChanged(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoes();
        }
        private void HabilitaDesabilitaBotoes()
        {
            if (OrcamentoGridControl.FocusedView.DataRowCount == 0)
            {
                btnEditarProdServ.Enabled = false;
                btnExcluirProdServ.Enabled = false;
                btnRecalculo.Enabled = false;
                btnImprimir.Enabled = false;
                btnGerarOS.Enabled = false;

                AlterarOrcamentoToolStripMenuItem.Enabled = false;
                ExcluirOrcamentoToolStripMenuItem.Enabled = false;
                ExcluirTudoOrcamentoToolStripMenuItem.Enabled = false;
            }
            else
            {
                btnGerarOS.Enabled = true;
                btnEditarProdServ.Enabled = true;
                btnExcluirProdServ.Enabled = true;
                btnRecalculo.Enabled = true;
                btnImprimir.Enabled = true;

                AlterarOrcamentoToolStripMenuItem.Enabled = true;
                ExcluirOrcamentoToolStripMenuItem.Enabled = true;
                ExcluirTudoOrcamentoToolStripMenuItem.Enabled = true;
            }
        }

        private void btnRecalculo_Click(object sender, EventArgs e)
        {
            frmWait wait = new frmWait("Recalculando o orçamento...");
            wait.Show();
            Application.DoEvents();
            try
            {
                Recalcula();
            }
            catch
            {
                throw;
            }
            wait.Close();
        }

        private void DigitarAjusteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InserirProdutoServico();
        }

        private void AlterarAjusteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarProdutoServico();
        }

        private void ExcluirAjusteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcluirProdutoServico();
        }

        private void ExcluirTudoOrcamento()
        {
            if (orcamentoDTO.Produtoservico.Count <= 0)
                return;

            if (MessageBox.Show("Deseja realmente excluir TODOS os produtos e serviços ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    orcamentoDTO.Produtoservico.Clear();
                    SetOrcamento(null);
                }
                catch
                {
                    throw;
                }
            }
        }

        private void ExcluirTudoAjusteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcluirTudoOrcamento();
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
        }
        private void Imprimir()
        {
            base.ShowRibbonPreview(OrcamentoGridControl, "Listagem dos Produtos e Serviços do Orçamento");
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lookUpEditPosicao.EditValue.Equals(6) &&
                MessageBox.Show("Deseja atualizar o estoque de todos os produtos deste orçamento?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                AtualizarEstoque();

            Salvar(false);
        }

        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors(); // Elimina todo os erros da janela

            if (lookUpEditPosicao.EditValue.Equals(15)
                && (String.IsNullOrEmpty(orcamentoDTO.NotaFiscalProdutos) &&
                    String.IsNullOrEmpty(orcamentoDTO.NotaFiscalServicos)))
            {
                dxErrorProvider.SetError(txtNotaFiscalProdutos, "Nota Fiscal de produto ou serviço não preenchida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                dxErrorProvider.SetError(txtNotaFiscalServicos, "Nota Fiscal de produto ou serviço não preenchida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            if (String.IsNullOrEmpty(orcamentoDTO.AtendidoPor))
                dxErrorProvider.SetError(cmbFuncionarios, "Funcionário inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (orcamentoDTO.PosicaoOrcamento.Equals(0))
                dxErrorProvider.SetError(lookUpEditPosicao, "Posição do orçamento inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (orcamentoDTO.Cliente.Id.Equals(0))
                dxErrorProvider.SetError(ClientesButtonEdit, "Cliente inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            if (String.IsNullOrEmpty(orcamentoDTO.PlacaVeiculo))
                dxErrorProvider.SetError(lookUpEditVeiculo, "Placa do veículo inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            return dxErrorProvider.HasErrors;
        }
        private void Salvar(bool navegacao)
        {
            try
            {
                if (this.ValidaCampos()) return;

                if (orcamentoDTO.Produtoservico.Count() <= 0)
                {
                    MessageBox.Show("Orçamento não calculado. Impossível prosseguir.", "Cálculo de Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Cursor = Cursors.WaitCursor;
                frmWait wait = new frmWait("Gravando...");
                wait.Show();
                Application.DoEvents();

                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        orcamentoDTO.Id = orcamentoGL.Insert((OrcamentoDTO)OrcamentoDTOBindingSource.Current);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        orcamentoGL.Update((OrcamentoDTO)OrcamentoDTOBindingSource.Current);
                        break;
                }

                wait.Close();
                MessageBox.Show("Orçamento gravado com sucesso.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!navegacao)
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível efetuar a operação em consequência do seguinte erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Cursor = Cursors.Default;
        }

        private void btnPrimeiro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            frmGridOrcamento frmgriddigitacao = (frmGridOrcamento)frmGrid;
            frmgriddigitacao.OrcamentoBindingSource.MoveFirst();
            Navegar(((OrcamentoDTO)frmgriddigitacao.OrcamentoBindingSource.Current).Id);
        }

        private bool VerificarDados()
        {
            if (!orcamentoDTO.Equals(orcamentoDTOVersaoOriginal))
            {
                if (MessageBox.Show("O Sistema identificou dados alterados não salvos. Deseja salvá-los antes de prosseguir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Salvar(true);
            }

            return true;
        }

        private void Navegar(int id_orcamento)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                orcamentoDTO = orcamentoGL.GetOrcamento(id_orcamento);
                OrcamentoDTOBindingSource.DataSource = orcamentoDTO;
                OrcamentoProdutoServicoBindingSource.DataSource = orcamentoDTO.Produtoservico;
                orcamentoDTO.Cliente = clienteGL.GetCliente(orcamentoDTO.Cliente.Id);
                orcamentoDTOVersaoOriginal = new OrcamentoDTO(orcamentoDTO);
                if (orcamentoDTO.PosicaoOrcamento.Equals(15))
                {
                    acesso.Validate(this);
                    acesso.Validate(barManager);
                }

                Recalcula();
                xtraTabControlDetalhesOrcamento.SelectedTabPageIndex = 0;
                txtCodOrcamento.Focus();
                xtraTabPageItensOrcamento.Refresh();
            }
            catch
            { }
            Cursor = Cursors.Default;
        }

        private void btnAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            frmGridOrcamento frmgriddigitacao = (frmGridOrcamento)frmGrid;
            frmgriddigitacao.OrcamentoBindingSource.MovePrevious();
            Navegar(((OrcamentoDTO)frmgriddigitacao.OrcamentoBindingSource.Current).Id);
        }

        private void btnProximo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            frmGridOrcamento frmgriddigitacao = (frmGridOrcamento)frmGrid;
            frmgriddigitacao.OrcamentoBindingSource.MoveNext();
            Navegar(((OrcamentoDTO)frmgriddigitacao.OrcamentoBindingSource.Current).Id);
        }

        private void btnUltimo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            frmGridOrcamento frmgriddigitacao = (frmGridOrcamento)frmGrid;
            frmgriddigitacao.OrcamentoBindingSource.MoveLast();
            Navegar(((OrcamentoDTO)frmgriddigitacao.OrcamentoBindingSource.Current).Id);
        }

        private void txtCPFCNPJ_EditValueChanged(object sender, EventArgs e)
        {
            if (orcamentoDTO != null)
                if (orcamentoDTO.Cliente.Cpf_Cnpj.Length > 11) //PESSOA JURÍDICA (CNPJ)
                    txtCPFCNPJ.Properties.Mask.EditMask = "99.999.999/9999-99";
                else //PESSOA FÍSICA (CPF)
                    txtCPFCNPJ.Properties.Mask.EditMask = "999.999.999-99";

            txtCPFCNPJ.Refresh();
        }

        private void btnGerarOS_Click(object sender, EventArgs e)
        {
            GerarOS();
        }

        private void GerarOS()
        {
            if (orcamentoDTO == null)
                return;

            EmpresaDTO empresa = null;
            try
            {
                empresa = new EmpresaGL().GetEmpresa(Convert.ToInt32(Global.EmpresaAtiva.Replace("emp", string.Empty)));
            }
            catch { }
            GetVinculo();
            rptOrdemServico report = new rptOrdemServico();
            List<Orcamento> Lista = new List<Orcamento>();
            Orcamento orcamento = new Orcamento();
            orcamento.Produtos = new List<DetailProdutosServicos>();
            orcamento.DataHoje = DateTime.Now.ToString("dd/MM/yyyy");
            orcamento.HoraHoje = DateTime.Now.ToString("HH:mm:ss");
            orcamento.c0 = Global.CompletarZerosEsquerda(orcamentoDTO.Id, 6).ToString();
            //CLIENTE
            if (orcamentoDTO.Cliente.Cpf_Cnpj != string.Empty)
                if (orcamentoDTO.Cliente.Cpf_Cnpj.Length > 11)
                    orcamento.c1 = Convert.ToUInt64(orcamentoDTO.Cliente.Cpf_Cnpj).ToString(@"00\.000\.000\/0000\-00");
                else
                    orcamento.c1 = Convert.ToUInt64(orcamentoDTO.Cliente.Cpf_Cnpj).ToString(@"000\.000\.000\-00");
            orcamento.c2 = orcamentoDTO.Cliente.Nome;
            orcamento.c3 = orcamentoDTO.Cliente.Endereco;
            orcamento.c4 = orcamentoDTO.Cliente.Numero;
            orcamento.c5 = orcamentoDTO.Cliente.Bairro;
            orcamento.c6 = orcamentoDTO.Cliente.Cidade.UF.Codigo;
            orcamento.c7 = orcamentoDTO.Cliente.Cidade.Nome;
            if (!String.IsNullOrEmpty(orcamentoDTO.Cliente.Telefone))
            {
                orcamento.c8 = orcamentoDTO.Cliente.Telefone.Substring(0, 2);
                orcamento.c9 = orcamentoDTO.Cliente.Telefone.Substring(2, 8);
            }
            orcamento.c10 = orcamentoDTO.Cliente.Email;

            //VEICULO
            orcamento.c11 = orcamentoDTO.Vinculo.Veiculo;
            orcamento.c12 = orcamentoDTO.Vinculo.Modelo;
            orcamento.c13 = orcamentoDTO.Vinculo.Km.ToString();
            orcamento.c14 = orcamentoDTO.Vinculo.Placa;
            orcamento.c15 = orcamentoDTO.Vinculo.Num_chassi;
            orcamento.c16 = orcamentoDTO.Vinculo.Cor;
            orcamento.c17 = orcamentoDTO.Vinculo.Ano;

            //EMPRESA
            orcamento.c18 = empresa.Razaosocial;
            string cnpjComFormatacao = Convert.ToUInt64(empresa.Cnpj).ToString(@"00\.000\.000\/0000\-00");
            string cpfComFormatacao = Convert.ToUInt64(empresa.Cnpj).ToString(@"000\.000\.000\-00");
            if (empresa.Cnpj.Length > 11)
                orcamento.c19 = cnpjComFormatacao;
            else
                orcamento.c19 = cpfComFormatacao;
            orcamento.c20 = empresa.Endereco;
            orcamento.c21 = empresa.Numero;
            orcamento.c22 = empresa.Bairro;
            orcamento.c23 = empresa.Municipio.UF.Codigo;
            orcamento.c24 = empresa.Municipio.Nome;
            orcamento.c25 = empresa.Dddtelefone;
            orcamento.c26 = empresa.Telefone;
            orcamento.c27 = empresa.Email;
            orcamento.Logo = empresa.Logotipo;

            //PRODUTOS E SERVIÇOS
            foreach (LancamentoProdutoServicoDTO itemprodserv in orcamentoDTO.Produtoservico)
            {
                DetailProdutosServicos umdetail = new DetailProdutosServicos();
                umdetail.Tipo = itemprodserv.Tipo;
                umdetail.Id = itemprodserv.Id;
                umdetail.Descricao = itemprodserv.Produto.Descricao;
                umdetail.Quantidade = itemprodserv.Quantidade;
                umdetail.ValorUnitario = itemprodserv.ValorUnitario.ToString("c2");
                umdetail.ValorDesconto = itemprodserv.ValorDesconto.ToString("c2");
                umdetail.ValorTotal = itemprodserv.ValorTotal.ToString("c2");
                umdetail.ValorLiquido = itemprodserv.ValorLiquido.ToString("c2");
                orcamento.Produtos.Add(umdetail);
            }

            orcamento.ValorTotalOrcamento = orcamentoDTO.ValorLiquido.ToString("c2");
            Lista.Add(orcamento);
            report.DataSource = Lista;
            report.ShowRibbonPreview();
        }

        private void frmUpdateOrcamento_Paint(object sender, PaintEventArgs e)
        {
            OrcamentoGridControl.RefreshDataSource();
            OrcamentoGridControl.Refresh();
        }

        private void AtualizarEstoque()
        {
            try
            {
                bool atualizado = false;
                int qtdAtualizada = 0;
                foreach (LancamentoProdutoServicoDTO itemprodserv in orcamentoDTO.Produtoservico)
                {
                    qtdAtualizada = itemprodserv.Produto.EstoqueAtual - itemprodserv.Quantidade;

                    if (qtdAtualizada < 0)
                        qtdAtualizada = 0;

                    if (orcamentoGL.AtualizarEstoque(itemprodserv.Produto.Id, qtdAtualizada))
                        atualizado = true;
                    else
                        atualizado = false;
                }

                if (atualizado)
                    MessageBox.Show("Estoque atualizado com sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                throw;
            }
        }

        private void GetVinculo()
        {
            int idVinculo = 0;
            if (PlacasBindingSource.Count > 0 && lookUpEditVeiculo.GetSelectedDataRow() != null)
            {
                idVinculo = ((PlacaVeiculoDTO)lookUpEditVeiculo.GetSelectedDataRow()).Id_Vinculo;
                orcamentoDTO.Vinculo = vincularGL.GetVeiculoVinc(idVinculo);
            }
        }

        private void lookUpEditParcelasRecebimento_Leave(object sender, EventArgs e)
        {
            VerificarDiferencaRecebimento();
            AtualizarDetalhesEspecieRecebimento();
        }
        private void AtualizarDetalhesEspecieRecebimento()
        {
            List<MechTech.Entities.OrcamentoDTO.DetalheFormaRecebimento> detalhesFormaRecebimento = new List<OrcamentoDTO.DetalheFormaRecebimento>();

            if (orcamentoDTO.QuantidadeParcelas > 0)
            {
                var valorParcela = orcamentoDTO.ValorEspecieRecebimento / orcamentoDTO.QuantidadeParcelas;

                for (int i = 0; i < orcamentoDTO.QuantidadeParcelas; i++)
                {
                    MechTech.Entities.OrcamentoDTO.DetalheFormaRecebimento detalhe = new MechTech.Entities.OrcamentoDTO.DetalheFormaRecebimento
                    {
                        Id = i + 1,
                        ParcelaEspecie = Global.CompletarZerosEsquerda(i + 1, 2) + "/" + Global.CompletarZerosEsquerda(orcamentoDTO.QuantidadeParcelas, 2) + " - " + Veiculo.ObterTipoRecebimento(orcamentoDTO.IdEspecieRecebimento).Descricao,
                        ValorParcela = valorParcela
                    };

                    detalhesFormaRecebimento.Add(detalhe);
                }

            }

            orcamentoDTO.DetalhesFormaRecebimento = detalhesFormaRecebimento;
            DetalheParcelaBindingSource.DataSource = detalhesFormaRecebimento;
        }

        private void VerificarDiferencaRecebimento()
        {
            var diferenca = orcamentoDTO.ValorEspecieRecebimento - orcamentoDTO.ValorLiquido;

            if (diferenca >= 0)
            {
                lblDiferencaRecebimento.ForeColor = Color.Green;
                lblDiferencaValor.ForeColor = Color.Green;
            }
            else
            {
                lblDiferencaRecebimento.ForeColor = Color.Red;
                lblDiferencaValor.ForeColor = Color.Red;
            }

            lblDiferencaValor.Text = diferenca.ToString("c2");
        }
    }


    public class Orcamento
    {
        public string DataHoje { get; set; }
        public string HoraHoje { get; set; }
        public string c0 { get; set; } //CÓDIGO ORÇAMENTO

        //IDENTIFICAÇÃO DO CLIENTE
        public string c1 { get; set; }
        public string c2 { get; set; }
        public string c3 { get; set; }
        public string c4 { get; set; }
        public string c5 { get; set; }
        public string c6 { get; set; }
        public string c7 { get; set; }
        public string c8 { get; set; }
        public string c9 { get; set; }
        public string c10 { get; set; }

        //IDENTIFICAÇÃO DO VEÍCULO
        public string c11 { get; set; }
        public string c12 { get; set; }
        public string c13 { get; set; }
        public string c14 { get; set; }
        public string c15 { get; set; }
        public string c16 { get; set; }
        public string c17 { get; set; }

        //IDENTIFICAÇÃO DA EMPRESA
        public string c18 { get; set; }
        public string c19 { get; set; }
        public string c20 { get; set; }
        public string c21 { get; set; }
        public string c22 { get; set; }
        public string c23 { get; set; }
        public string c24 { get; set; }
        public string c25 { get; set; }
        public string c26 { get; set; }
        public string c27 { get; set; }
        public string ValorTotalOrcamento { get; set; }
        public byte[] Logo { get; set; }

        //LISTA DE PRODUTOS E SERVIÇOS
        public List<DetailProdutosServicos> Produtos { get; set; }
    }

    public struct DetailProdutosServicos
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public decimal Quantidade { get; set; }
        public string ValorUnitario { get; set; }
        public string ValorDesconto { get; set; }
        public string ValorTotal { get; set; }
        public string ValorLiquido { get; set; }
    }

    public struct PlacaVeiculoDTO
    {
        public int Id_Vinculo { get; set; }
        public string Placa { get; set; }
        public string Veiculo { get; set; }
    }
}