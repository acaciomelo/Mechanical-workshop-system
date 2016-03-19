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

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Templates;
using MechTech.Entities;
using MechTech.Gateway;
#endregion

namespace MechTech.UI.Cadastros
{
    public partial class frmUpdateVeiculo : frmBase
    {
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        VeiculoDTO veiculoDTO { get; set; }
        VeiculoDTO veiculoDTOVersaoOriginal { get; set; }
        BindingSource bndVeiculoGrid = new BindingSource();
        VeiculoGL veiculoGL = new VeiculoGL();
        Acesso acesso = new Acesso();

        public frmUpdateVeiculo()
        {
            InitializeComponent();
        }

        public frmUpdateVeiculo(int id_veiculo)
        {
            InitializeComponent();
            veiculoDTO = (VeiculoDTO)VeiculoDTOBindingSource.Current;

        }

        private void CarregarMarcas(int ptipo, bool insert)
        {

            if (insert)
            {

                switch (ptipo)
                {
                    case 0:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasCarros().OrderBy(x => x.Descricao);
                        break;
                    case 1:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasBarcos().OrderBy(x => x.Descricao);
                        break;
                    case 2:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasBuggys().OrderBy(x => x.Descricao);
                        break;
                    case 3:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasCaminhoes().OrderBy(x => x.Descricao);
                        break;
                    case 4:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasCarretas().OrderBy(x => x.Descricao);
                        break;
                    case 5:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasEmpilhadeiras().OrderBy(x => x.Descricao);
                        break;
                    case 6:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasLanchas().OrderBy(x => x.Descricao);
                        break;
                    case 7:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasMotos().OrderBy(x => x.Descricao);
                        break;
                    case 8:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasMotosAquaticas().OrderBy(x => x.Descricao);
                        break;
                    case 9:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasMotorPopa().OrderBy(x => x.Descricao);
                        break;
                    case 10:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasOnibus().OrderBy(x => x.Descricao);
                        break;
                    case 11:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasQuadricliclos().OrderBy(x => x.Descricao);
                        break;
                    case 12:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasTratores().OrderBy(x => x.Descricao);
                        break;
                }

                lookUpTipo.ItemIndex = ptipo;
            }
            else
            {
                switch (ptipo)
                {
                    case 1:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasCarros().OrderBy(x => x.Descricao);
                        break;
                    case 24:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasBarcos().OrderBy(x => x.Descricao);
                        break;
                    case 5:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasBuggys().OrderBy(x => x.Descricao);
                        break;
                    case 6:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasCaminhoes().OrderBy(x => x.Descricao);
                        break;
                    case 7:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasCarretas().OrderBy(x => x.Descricao);
                        break;
                    case 9:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasEmpilhadeiras().OrderBy(x => x.Descricao);
                        break;
                    case 12:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasLanchas().OrderBy(x => x.Descricao);
                        break;
                    case 17:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasMotos().OrderBy(x => x.Descricao);
                        break;
                    case 11:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasMotosAquaticas().OrderBy(x => x.Descricao);
                        break;
                    case 16:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasMotorPopa().OrderBy(x => x.Descricao);
                        break;
                    case 19:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasOnibus().OrderBy(x => x.Descricao);
                        break;
                    case 20:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasQuadricliclos().OrderBy(x => x.Descricao);
                        break;
                    case 22:
                        MarcaBindingSource.DataSource = Veiculo.ObterMarcasTratores().OrderBy(x => x.Descricao);
                        break;
                }

            }

        }

        private void frmUpdateVeiculo_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;
            TipoBindingSource.DataSource = Veiculo.ObterTipo().OrderBy(x => x.Descricao);
            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    HabilitaDesabilitaBotoesNavegacao(false);
                    break;
                case Enumeradores.TipoOperacao.Update:
                    HabilitaDesabilitaBotoesNavegacao(true);
                    break;
                case Enumeradores.TipoOperacao.Viewer:
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

        public frmUpdateVeiculo(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndVeiculoGrid = bnd;
                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                {
                    VeiculoDTOBindingSource.AddNew();
                    CarregarMarcas(0, true);
                }
                else
                {
                    veiculoDTO = (VeiculoDTO)bndVeiculoGrid.Current;
                    VeiculoDTOBindingSource.DataSource = veiculoGL.GetVeiculo(veiculoDTO.Id);
                    veiculoDTOVersaoOriginal = new VeiculoDTO((VeiculoDTO)VeiculoDTOBindingSource.Current);

                    CarregarMarcas(veiculoDTO.Tipo, false);

                }
                veiculoDTO = (VeiculoDTO)VeiculoDTOBindingSource.Current;
            }
            catch
            {
                throw;
            }
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
                        veiculoDTO.Id = veiculoGL.Insert((VeiculoDTO)VeiculoDTOBindingSource.Current);
                        bndVeiculoGrid.Add(VeiculoDTOBindingSource.Current);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        veiculoGL.Update((VeiculoDTO)VeiculoDTOBindingSource.Current);
                        bndVeiculoGrid.List[bndVeiculoGrid.Position] = VeiculoDTOBindingSource.Current;
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

            if (veiculoDTO.Id_Marca == 0)
            {
                dxErrorProvider.SetError(lookUpMarca, "Marca do veículo inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }
            if (veiculoDTO.Tipo == 0)
            {
                dxErrorProvider.SetError(lookUpTipo, "Tipo do veículo inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            if (veiculoDTO.Veiculo.Trim().Equals(string.Empty))
            {
                dxErrorProvider.SetError(txtVeiculo, "Nome do veículo inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }


            if (dxErrorProvider.HasErrors)
                MessageBox.Show("O Sistema identificou campos obrigatórios não preenchidos ou preenchidos incorretamente. Impossível prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return dxErrorProvider.HasErrors;
        }

        private void HabilitaDesabilitaBotoesNavegacao(bool enabled)
        {
            BtnPrimeiro.Enabled = enabled;
            BtnAnterior.Enabled = enabled;
            BtnProximo.Enabled = enabled;
            BtnUltimo.Enabled = enabled;
        }

        private bool VerificarDados()
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Update)
            {
                if (!((VeiculoDTO)VeiculoDTOBindingSource.Current).Equals(veiculoDTOVersaoOriginal))
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
            VeiculoDTOBindingSource.DataSource = veiculoGL.GetVeiculo(((VeiculoDTO)bndVeiculoGrid.Current).Id);
            veiculoDTO = (VeiculoDTO)VeiculoDTOBindingSource.Current;
            veiculoDTOVersaoOriginal = new VeiculoDTO(veiculoDTO);
            Cursor = Cursors.Default;
        }

        private void BtnUltimo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndVeiculoGrid.MoveLast();
            Navegar();
        }

        private void BtnProximo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndVeiculoGrid.MoveNext();
            Navegar();
        }

        private void BtnAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndVeiculoGrid.MovePrevious();
            Navegar();
        }

        private void BtnPrimeiro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndVeiculoGrid.MoveFirst();
            Navegar();
        }

        private void frmUpdateVeiculo_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
        }

        private void BtnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BtnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Salvar())
                Close();
        }

        private void lookUpTipo_EditValueChanged(object sender, EventArgs e)
        {
            if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
            {
                CarregarMarcas(lookUpTipo.ItemIndex, true);

            }
            else
            {
                CarregarMarcas(Convert.ToInt32(lookUpTipo.EditValue), false);
            }
        }
    }
}