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
#endregion

namespace MechTech.UI.Cadastros
{
    public partial class frmUpdateFornecedor : frmBase
    {
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        FornecedorDTO fornecedorDTO { get; set; }
        FornecedorDTO fornecedorDTOVersaoOriginal { get; set; }
        TreeNode node { get; set; }
        BindingSource bndFornecedorGrid = new BindingSource();
        CNAEGL cnaeGL = new CNAEGL();
        FornecedorGL fornecedorGL = new FornecedorGL();
        MunicipioGL municipioGL = new MunicipioGL();
        Acesso acesso = new Acesso();

        bool ProcuraCEP = true;
        public frmUpdateFornecedor()
        {
            InitializeComponent();
        }

        public frmUpdateFornecedor(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndFornecedorGrid = bnd;
                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                {
                    FonecedorDTOBindingSource.AddNew();
                }
                else
                {
                    fornecedorDTO = (FornecedorDTO)bndFornecedorGrid.Current;
                    FonecedorDTOBindingSource.DataSource = fornecedorGL.GetFornecedor(fornecedorDTO.Id);
                    fornecedorDTOVersaoOriginal = new FornecedorDTO((FornecedorDTO)FonecedorDTOBindingSource.Current);
                }
                fornecedorDTO = (FornecedorDTO)FonecedorDTOBindingSource.Current;

            }
            catch
            {
                throw;
            }
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Salvar())
                Close();
        }

        private void Municipio()
        {
            try
            {
                ((FornecedorDTO)FonecedorDTOBindingSource.Current).Municipio = municipioGL.GetMunicipioIBGE(Convert.ToInt32(codigoibgeButtonEdit.Text));
            }
            catch { }
        }
        private bool Salvar()
        {
            try
            {
                //EXCEPTION
                Municipio();
                //

                if (ValidaCampos())
                    return false;

                Cursor = Cursors.WaitCursor;
                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        fornecedorDTO.Id = fornecedorGL.Insert((FornecedorDTO)FonecedorDTOBindingSource.Current);
                        bndFornecedorGrid.Add(FonecedorDTOBindingSource.Current);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        fornecedorGL.Update((FornecedorDTO)FonecedorDTOBindingSource.Current);
                        bndFornecedorGrid.List[bndFornecedorGrid.Position] = FonecedorDTOBindingSource.Current;
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

            #region BÁSICO
            if (fornecedorDTO.Razaosocial.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(razaosocialTextEdit, "Razão Social inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (fornecedorDTO.Nomefantasia.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(nomefantasiaTextEdit, "Nome fantasia inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (fornecedorDTO.Endereco.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(enderecoTextEdit, "Endereço inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (fornecedorDTO.Numero.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(numeroTextEdit, "Número inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (fornecedorDTO.Bairro.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(bairroTextEdit, "Bairro inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (fornecedorDTO.Cep.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(cepTextEdit, "Cep inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (fornecedorDTO.Municipio.Codigoibge == 0)
                dxErrorProvider.SetError(codigoibgeButtonEdit, "Cód. Município inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            else
            {
                if (fornecedorDTO.Municipio.Nome.Trim().Equals(string.Empty))
                    dxErrorProvider.SetError(codigoibgeButtonEdit, "Cód. Município não localizado.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }

            if (fornecedorDTO.Dddtelefone.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(dddtelefoneTextEdit, "DDD do telefone inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (fornecedorDTO.Telefone.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(telefoneTextEdit, "Telefone inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);


            if (fornecedorDTO.Cnpj.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(cnpjTextEdit, "CNPJ inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            else
            {
                if (!Documentos.ValidarCNPJ(fornecedorDTO.Cnpj.Trim()))
                    dxErrorProvider.SetError(cnpjTextEdit, "CNPJ inválido.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }

            if (fornecedorDTO.Iestadual.Trim().Equals(string.Empty))
            {
                dxErrorProvider.SetError(iestadualTextEdit, "Inscrição Estadual inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }
            else
            {
                if (Documentos.ConsisteInscricaoEstadual(fornecedorDTO.Iestadual.Trim(), fornecedorDTO.Municipio.UF.Codigo.Trim()) != 0)
                {
                    if (fornecedorDTO.Municipio.UF.Codigo.Trim().Equals(string.Empty))
                        dxErrorProvider.SetError(iestadualTextEdit, "Inscrição Estadual inválida.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    else
                        dxErrorProvider.SetError(iestadualTextEdit, "Inscrição Estadual inválida para " + fornecedorDTO.Municipio.UF.Descricao.Trim(), DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                }
            }

            if (fornecedorDTO.Email.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(emailTextEdit, "Email inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            #endregion


            if (dxErrorProvider.HasErrors)
                MessageBox.Show("O Sistema identificou campos obrigatórios não preenchidos ou preenchidos incorretamente. Impossível prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return dxErrorProvider.HasErrors;
        }

        private void frmUpdateFornecedor_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;

            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Fornecedor";
                    HabilitaDesabilitaBotoesNavegacao(false);
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Fornecedor";
                    HabilitaDesabilitaBotoesNavegacao(true);                  
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Fornecedor";
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

        private bool VerificarDados()
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Update)
            {
                if (!((FornecedorDTO)FonecedorDTOBindingSource.Current).Equals(fornecedorDTOVersaoOriginal))
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
            FonecedorDTOBindingSource.DataSource = fornecedorGL.GetFornecedor(((FornecedorDTO)bndFornecedorGrid.Current).Id);
            fornecedorDTO = (FornecedorDTO)FonecedorDTOBindingSource.Current;
            fornecedorDTOVersaoOriginal = new FornecedorDTO(fornecedorDTO);
            Cursor = Cursors.Default;
        }

        private void btnPrimeiro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndFornecedorGrid.MoveFirst();
            Navegar();
        }

        private void btnAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndFornecedorGrid.MovePrevious();
            Navegar();
        }

        private void btnProximo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndFornecedorGrid.MoveNext();
            Navegar();
        }

        private void btnUltimo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndFornecedorGrid.MoveLast();
            Navegar();
        }

        private void codigoibgeButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridMunicipio frmGrid = new frmGridMunicipio(this, new Global.SystemDelegate(SetMunicipio));
            frmGrid.Show();
            Cursor = Cursors.Default;
        }
        private void SetMunicipio(object municipio)
        {
            codigoibgeButtonEdit.Text = ((MunicipioDTO)municipio).Codigoibge.ToString();
            municipioTextEdit.Text = ((MunicipioDTO)municipio).Nome;
            UFTextEdit.Text = ((MunicipioDTO)municipio).UF.Codigo;
            fornecedorDTO.Municipio = (MunicipioDTO)municipio;
        }

        private void codigoibgeButtonEdit_Validated(object sender, EventArgs e)
        {
            if (!codigoibgeButtonEdit.IsModified)
                return;

            MunicipioDTO municipio = new MunicipioDTO();
            if (codigoibgeButtonEdit.Text.Trim() != "0" && this.Enabled == true)
            {
                try
                {
                    municipio = municipioGL.GetMunicipioIBGE(Convert.ToInt32(codigoibgeButtonEdit.Text));
                    municipioTextEdit.Text = municipio.Nome;
                    UFTextEdit.Text = municipio.UF.Codigo;
                }
                catch
                {
                    municipio.Codigoibge = Convert.ToInt32(codigoibgeButtonEdit.Text);
                    municipioTextEdit.Text = string.Empty;
                    UFTextEdit.Text = string.Empty;

                    Cursor = Cursors.WaitCursor;
                    frmGridMunicipio frmgridmunicipio = new frmGridMunicipio(this, new Global.SystemDelegate(SetMunicipio));
                    frmgridmunicipio.Show();
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                municipioTextEdit.Text = string.Empty;
                UFTextEdit.Text = string.Empty;
            }
            fornecedorDTO.Municipio = municipio;
        }

        private void BuscaCep()
        {
            Global.Validacep = true;
            if (Global.Validacep == false)
            {
                MessageBox.Show("Sua concessionária não contratou o serviço de consulta on-line de CEP. " +
                                "Para utilizar este serviço, acesse a Área do Cliente no website www.MECHTECH.inf.br \n" +
                                "na seção 'Administrador' e solicite a ativação deste recurso.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ProcuraCEP)
                return;

            try
            {
                ProcuraCEP = true;

                Cursor = Cursors.WaitCursor;
                BuscaCEPGL cep = new BuscaCEPGL();
                List<BuscaCEPDTO> dados = new List<BuscaCEPDTO>();


                if (fornecedorDTO.Cep != "")
                    dados = cep.GetEndereco("",
                                            "",
                                            "",
                                            fornecedorDTO.Cep);

                if ((dados == null) || (dados.Count == 0) || (dados.Count > 1))
                {
                    frmBuscaCEP frmCep = new frmBuscaCEP(this, new MechTech.Util.Global.SystemDelegate(SetCep));
                    frmCep.Show();
                }
                else
                {
                    cepTextEdit.EditValue = dados[0].Cep;
                    UFTextEdit.EditValue = dados[0].Uf;
                    codigoibgeButtonEdit.EditValue = dados[0].CodMun;
                    municipioTextEdit.EditValue = dados[0].Municipio;
                    enderecoTextEdit.EditValue = dados[0].Endereco;
                    bairroTextEdit.EditValue = dados[0].Bairro;
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                ProcuraCEP = false;
            }
        }

        private void cepTextEdit_Validated(object sender, EventArgs e)
        {
            if (fornecedorDTO.Cep != "")
                BuscaCep();
        }

        private void cepTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            BuscaCep();
        }

        private void frmUpdateFornecedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        private void SetCep(object cep)
        {
            codigoibgeButtonEdit.Text = ((BuscaCEPDTO)cep).CodMun.ToString();
            municipioTextEdit.Text = ((BuscaCEPDTO)cep).Municipio;
            UFTextEdit.Text = ((BuscaCEPDTO)cep).Uf;
            cepTextEdit.Text = ((BuscaCEPDTO)cep).Cep;
            enderecoTextEdit.Text = ((BuscaCEPDTO)cep).Endereco;
            bairroTextEdit.Text = ((BuscaCEPDTO)cep).Bairro;
        }

        private void codigoibgeButtonEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void codigoibgeButtonEdit_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}