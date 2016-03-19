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
#endregion

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Templates;
using MechTech.Entities;
using MechTech.Gateway;
#endregion

namespace MechTech.UI.Cadastros
{
    public partial class frmUpdateCliente : XtraForm
    {
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        ClienteDTO clienteDTO { get; set; }
        ClienteDTO clienteDTOVersaoOriginal { get; set; }
        BindingSource bndClienteGrid = new BindingSource();
        ClienteGL clienteGL = new ClienteGL();
        MunicipioGL municipioGL = new MunicipioGL();
        Acesso acesso = new Acesso();
        bool ProcuraCEP = false;
        UFGL ufGL = new UFGL();

        public frmUpdateCliente()
        {
            InitializeComponent();
        }

        public frmUpdateCliente(int id_cliente)
        {
            InitializeComponent();
            InitializeComponent();
            clienteDTO = (ClienteDTO)ClienteDTOBindingSource.Current;
            Verifica_mascara_Cpf_Cnpj();
        }

        public frmUpdateCliente(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndClienteGrid = bnd;
                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                {
                    ClienteDTOBindingSource.AddNew();
                }
                else
                {
                    clienteDTO = (ClienteDTO)bndClienteGrid.Current;
                    ClienteDTOBindingSource.DataSource = clienteGL.GetCliente(clienteDTO.Id);
                    clienteDTOVersaoOriginal = new ClienteDTO((ClienteDTO)ClienteDTOBindingSource.Current);
                    Verifica_mascara_Cpf_Cnpj();
                }
                clienteDTO = (ClienteDTO)ClienteDTOBindingSource.Current;
                UFDTOBindingSource.DataSource = ufGL.GetGridUF("codigo", "%");
            }
            catch
            {
                throw;
            }

        }

        private void SetMunicipio(object cliente)
        {
            BtnCodMunicipio.Text = ((MunicipioDTO)cliente).Codigoibge.ToString();
            txtCidade.Text = ((MunicipioDTO)cliente).Nome;
            LookUpUF.Text = ((MunicipioDTO)cliente).UF.Codigo;
            clienteDTO.Cidade = (MunicipioDTO)cliente;
        }

        private bool ValidaCampos()
        {

            dxErrorProvider.ClearErrors();

            #region BÁSICO

            if (clienteDTO.Nome.Trim().Equals(string.Empty))
            {
                dxErrorProvider.SetError(txtNome, "Nome inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            if (clienteDTO.Endereco.Trim().Equals(string.Empty))
            {
                dxErrorProvider.SetError(txtEndereco, " Endereço inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            if (clienteDTO.Numero.Trim().Equals(string.Empty))
            {
                dxErrorProvider.SetError(txtNumero, "Número inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            if (clienteDTO.Bairro.Trim().Equals(string.Empty))
            {
                dxErrorProvider.SetError(txtBairro, "Bairro inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            if (clienteDTO.Cidade.Codigoibge == 0)
            {
                dxErrorProvider.SetError(BtnCodMunicipio, "Cód. Município inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            }
            else
            {
                if (clienteDTO.Cidade.Nome.Trim().Equals(string.Empty))
                {
                    dxErrorProvider.SetError(BtnCodMunicipio, "Cód. Município não localizado. Preenchimento obrigatório,", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                }
            }

            if (!clienteDTO.DataCadastro.HasValue)
            {
                dxErrorProvider.SetError(dtCadastro, "Data inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            //if (clienteDTO.Telefone.Trim().Equals(string.Empty))
            //{
            //    dxErrorProvider.SetError(txtTelefone, "Telefone inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            //}

            if (clienteDTO.Celular.Trim().Equals(string.Empty))
            {
                dxErrorProvider.SetError(txtCelular, "Celular inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            //if (clienteDTO.Emissor.Trim().Equals(string.Empty))
            //{
            //    dxErrorProvider.SetError(txtEmissor, "Emissor inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            //}

            if (clienteDTO.Tipo_pessoa.Trim().Equals("J"))
            {
                if (!Documentos.ValidarCNPJ(clienteDTO.Cpf_Cnpj.Trim()))
                    dxErrorProvider.SetError(txt_cpf_cnpj, "CPF/CNPJ inválido.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }
            else
            {
                {
                    if (!Documentos.ValidarCPF(clienteDTO.Cpf_Cnpj.Trim()))
                        dxErrorProvider.SetError(txt_cpf_cnpj, "CPF/CNPJ inválido.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                }
            }

            #endregion

            if (dxErrorProvider.HasErrors)
                MessageBox.Show("O Sistema identificou campos obrigatórios não preenchidos ou preenchidos incorretamente. Impossível prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return dxErrorProvider.HasErrors;
        }

        private bool VerificarDados()
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Update)
            {
                if (!((ClienteDTO)ClienteDTOBindingSource.Current).Equals(clienteDTOVersaoOriginal))
                {
                    if (MessageBox.Show("O Sistema identificou dados alterados não salvos. Deseja salvá-los antes de prosseguir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        return Salvar();
                    else
                        dxErrorProvider.ClearErrors();
                }
            }

            return true;
        }

        private void Municipio()
        {
            try
            {
                ((ClienteDTO)ClienteDTOBindingSource.Current).Cidade = municipioGL.GetMunicipioIBGE(Convert.ToInt32(BtnCodMunicipio.Text));
            }
            catch { }
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
                        clienteDTO.Id = clienteGL.Insert((ClienteDTO)ClienteDTOBindingSource.Current);
                        bndClienteGrid.Add(ClienteDTOBindingSource.Current);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        clienteGL.Update((ClienteDTO)ClienteDTOBindingSource.Current);
                        bndClienteGrid.List[bndClienteGrid.Position] = ClienteDTOBindingSource.Current;
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

        private void Navegar()
        {
            Cursor = Cursors.WaitCursor;
            ClienteDTOBindingSource.DataSource = clienteGL.GetCliente(((ClienteDTO)bndClienteGrid.Current).Id);
            clienteDTO = (ClienteDTO)ClienteDTOBindingSource.Current;
            clienteDTOVersaoOriginal = new ClienteDTO(clienteDTO);
            Cursor = Cursors.Default;
            Verifica_mascara_Cpf_Cnpj();
        }

        private void rdgTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarCPFCNPJ();
        }

        private void ValidarCPFCNPJ()
        {
            if (rdgTipo.SelectedIndex == 0)
            {
                txt_cpf_cnpj.Properties.Mask.EditMask = "99.999.999/9999-99";
                clienteDTO.Tipo_pessoa = "J";
            }
            else
            {
                txt_cpf_cnpj.Properties.Mask.EditMask = "999.999.999-99";
                clienteDTO.Tipo_pessoa = "F";
            }
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Salvar())
                Close();
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnPrimeiro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndClienteGrid.MoveFirst();
            Navegar();
        }

        private void btnProximo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndClienteGrid.MoveNext();
            Navegar();
        }

        private void btnUltimo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndClienteGrid.MoveLast();
            Navegar();
        }

        private void frmUpdateCliente_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;
            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Cliente";
                    HabilitaDesabilitaBotoesNavegacao(false);
                    dtCadastro.EditValue = DateTime.Now;
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Cliente";
                    HabilitaDesabilitaBotoesNavegacao(true);
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Cliente";
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

        private void BtnCodMunicipio_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridMunicipio frmGrid = new frmGridMunicipio(this, new Global.SystemDelegate(SetMunicipio));
            frmGrid.Show();
            Cursor = Cursors.Default;
        }

        private void frmUpdateCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
        }

        private void BtnCodMunicipio_EditValueChanged(object sender, EventArgs e)
        {
            if (!BtnCodMunicipio.IsModified)
                return;

            MunicipioDTO municipio = new MunicipioDTO();

            if (BtnCodMunicipio.Text.Trim() != "0" && this.Enabled == true)
            {
                try
                {
                    municipio = municipioGL.GetMunicipioIBGE(Convert.ToInt32(BtnCodMunicipio.Text));
                    txtCidade.Text = municipio.Nome;
                    LookUpUF.Text = municipio.UF.Codigo;
                }
                catch
                {
                    municipio.Codigoibge = Convert.ToInt32(BtnCodMunicipio.Text);
                    txtCidade.Text = string.Empty;
                    LookUpUF.Text = string.Empty;
                    Cursor = Cursors.WaitCursor;
                    frmGridMunicipio frmgridmunicipio = new frmGridMunicipio(this, new Global.SystemDelegate(SetMunicipio));
                    frmgridmunicipio.Show();
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                txtCidade.Text = string.Empty;
                LookUpUF.Text = string.Empty;

            }

            clienteDTO.Cidade = municipio;
        }

        private void BtnCodMunicipio_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!BtnCodMunicipio.IsModified)
                return;

            MunicipioDTO municipio = new MunicipioDTO();

            if (BtnCodMunicipio.Text.Trim() != "0" && this.Enabled == true)
            {
                try
                {
                    municipio = municipioGL.GetMunicipioIBGE(Convert.ToInt32(BtnCodMunicipio.Text));
                    txtCidade.Text = municipio.Nome;

                    LookUpUF.Text = municipio.UF.Codigo;
                }
                catch
                {
                    municipio.Codigoibge = Convert.ToInt32(BtnCodMunicipio.Text);
                    txtCidade.Text = string.Empty;

                    LookUpUF.Text = string.Empty;
                    Cursor = Cursors.WaitCursor;
                    frmGridMunicipio frmgridmunicipio = new frmGridMunicipio(this, new Global.SystemDelegate(SetMunicipio));
                    frmgridmunicipio.Show();
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                txtCidade.Text = string.Empty;
                LookUpUF.Text = string.Empty;
            }

            clienteDTO.Cidade = municipio;
        }

        public void Verifica_mascara_Cpf_Cnpj()
        {
            if (clienteDTO.Tipo_pessoa.Equals("J"))
            {
                rdgTipo.SelectedIndex = 0;
                txt_cpf_cnpj.Properties.Mask.EditMask = "99.999.999/9999-99";
            }
            else
            {
                rdgTipo.SelectedIndex = 1;
                txt_cpf_cnpj.Properties.Mask.EditMask = "999.999.999-99";
            }
        }

        private void btnAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndClienteGrid.MovePrevious();
            Navegar();
        }
    }
}