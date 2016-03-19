using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

#region DEVEXPRESS
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
    public partial class frmUpdateResponsavel : frmBase
    {
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        ResponsavelDTO responsavelDTO { get; set; }
        BindingSource bndResponsavelGrid = new BindingSource();
        ResponsavelGL responsavelGL = new ResponsavelGL();
        UFGL ufGL = new UFGL();
        MunicipioGL municipioGL = new MunicipioGL();
        bool ProcuraCEP = true;
        Acesso acesso = new Acesso();

        public frmUpdateResponsavel()
        {
            InitializeComponent();
        }

        public frmUpdateResponsavel(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndResponsavelGrid = bnd;

                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                    ResponsavelDTOBindingSource.AddNew();
                else
                {
                    responsavelDTO = (ResponsavelDTO)bndResponsavelGrid.Current;
                    ResponsavelDTOBindingSource.DataSource = responsavelGL.GetResponsavel(responsavelDTO.Id);
                }

                responsavelDTO = (ResponsavelDTO)ResponsavelDTOBindingSource.Current;
                UFDTOBindingSource.DataSource = ufGL.GetGridUF("codigo", "%");
            }
            catch
            {
                throw;
            }
        }

        private void frmUpdateResponsavel_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;

            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Responsável";
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Responsável";
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Responsável";
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

        private void frmUpdateResponsavel_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Municipio();

            if (ValidaCampos()) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        responsavelDTO.Id = responsavelGL.Insert((ResponsavelDTO)ResponsavelDTOBindingSource.Current);
                        bndResponsavelGrid.Add(ResponsavelDTOBindingSource.Current);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        responsavelGL.Update((ResponsavelDTO)ResponsavelDTOBindingSource.Current);
                        bndResponsavelGrid.List[bndResponsavelGrid.Position] = ResponsavelDTOBindingSource.Current;
                        break;
                }
                this.Close();
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            Cursor = Cursors.Default;
        }

        private void SetMunicipio(object municipio)
        {
            codigoIBGEButtonEdit.Text = ((MunicipioDTO)municipio).Codigoibge.ToString();
            municipioTextEdit.Text = ((MunicipioDTO)municipio).Nome;
            UFTextEdit.Text = ((MunicipioDTO)municipio).UF.Codigo;
            responsavelDTO.Municipio = (MunicipioDTO)municipio;
        }

        private void codigoIBGEButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridMunicipio frmGrid = new frmGridMunicipio(this, new Global.SystemDelegate(SetMunicipio));
            frmGrid.Show();
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Faz todas as validações necessárias dos campos da janela
        /// </summary>
        /// <returns>Retorna true se existir inconsistencias na janela</returns>
        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors(); // Elimina todo os erros da janela

            if (responsavelDTO.Municipio.Id == 0)
                dxErrorProvider.SetError(municipioTextEdit, "Município inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (responsavelDTO.Responsa == false &&
                    responsavelDTO.Contador == false)
            {
                dxErrorProvider.SetError(responsaCheckEdit, "Responsabilidade inválida. Preenchimento obrigatório ao menos para uma das oções.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                dxErrorProvider.SetError(contadorCheckEdit, "Responsabilidade inválida. Preenchimento obrigatório ao menos para uma das oções.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }
            
            if (responsavelDTO.Contador || responsavelDTO.Responsa)
            {
                if (responsavelDTO.Nome == string.Empty)
                    dxErrorProvider.SetError(nomeTextEdit, "Nome inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

                if (responsavelDTO.Endereco == string.Empty)
                    dxErrorProvider.SetError(enderecoTextEdit, "Endereço inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

                if (responsavelDTO.Numero == string.Empty)
                    dxErrorProvider.SetError(numeroTextEdit, "Número inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

                if (responsavelDTO.Bairro == string.Empty)
                    dxErrorProvider.SetError(bairroTextEdit, "Bairro inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

                if (responsavelDTO.Cep == string.Empty)
                    dxErrorProvider.SetError(cepTextEdit, "Cep inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

                if (responsavelDTO.Municipio.Codigoibge == 0)
                    dxErrorProvider.SetError(codigoIBGEButtonEdit, "Cód. Município inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                else
                {
                    if (responsavelDTO.Municipio.Nome.Trim().Equals(string.Empty))
                        dxErrorProvider.SetError(codigoIBGEButtonEdit, "Cód. Município não localizado.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                }

                if (responsavelDTO.Dddtelefone == string.Empty)
                    dxErrorProvider.SetError(dddtelefoneTextEdit, "DDD do Telefone inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

                if (responsavelDTO.Telefone == string.Empty)
                    dxErrorProvider.SetError(telefoneTextEdit, "Telefone inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

                if (!responsavelDTO.DataNascimento.HasValue)
                    dxErrorProvider.SetError(DataNascimentoDateEdit, "Data de Nascimento inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

                if (responsavelDTO.Contato == string.Empty)
                    dxErrorProvider.SetError(contatoTextEdit, "Contato inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

                if (responsavelDTO.Cpf == string.Empty)
                    dxErrorProvider.SetError(cpfTextEdit, "CPF inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);


                if (responsavelDTO.Cnpj == string.Empty && responsavelDTO.Cei == string.Empty)
                {
                    dxErrorProvider.SetError(cnpjTextEdit, "Documentação inválida. Preenchimento obrigatório ao menos para uma das opções.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                    dxErrorProvider.SetError(ceiTextEdit, "Documentação inválida. Preenchimento obrigatório ao menos para uma das opções.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                }


                if (responsavelDTO.Cargo == string.Empty)
                    dxErrorProvider.SetError(cargoTextEdit, "Cargo inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

                EventHandler checa; // necessário para chamar o evento dos campos

                if (responsavelDTO.Cnpj != string.Empty)
                {
                    if (Documentos.ValidarCNPJ(responsavelDTO.Cnpj) == false)
                        dxErrorProvider.SetError(cnpjTextEdit, "CNPJ inválido.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    else
                    {
                        checa = cnpjTextEdit_Validated;
                        if (checa != null) checa(cnpjTextEdit, EventArgs.Empty);
                    }
                }

                if (responsavelDTO.Cpf != "")
                {
                    if (Documentos.ValidarCPF(responsavelDTO.Cpf) == false)
                        dxErrorProvider.SetError(cpfTextEdit, "CPF inválido.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    else
                    {
                        checa = cpfTextEdit_Validated;
                        if (checa != null) checa(cpfTextEdit, EventArgs.Empty);
                    }
                }

                if (responsavelDTO.Cei != "")
                {
                    if (Documentos.ValidarCEI(responsavelDTO.Cei) == false)
                        dxErrorProvider.SetError(ceiTextEdit, "CEI inválido.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    else
                    {
                        checa = ceiTextEdit_Validated;
                        if (checa != null) checa(ceiTextEdit, EventArgs.Empty);
                    }
                }

                if (responsavelDTO.Nit != "")
                {
                    checa = nitTextEdit_Validated;
                    if (checa != null) checa(nitTextEdit, EventArgs.Empty);
                }

                if (responsavelDTO.Bairro.ToString().Count() > 20) //41739
                    dxErrorProvider.SetError(bairroTextEdit, "O campo bairro possui mais caracteres do que o permitido nos layouts, por gentileza informe dados de modo abreviado. Tamanho máximo: 20 Caracteres.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }
            return dxErrorProvider.HasErrors;
        }

        private void codigoIBGEButtonEdit_Validated(object sender, EventArgs e)
        {
            if (!codigoIBGEButtonEdit.IsModified)
                return;

            MunicipioDTO municipio = new MunicipioDTO();
            if (codigoIBGEButtonEdit.Text.Trim() != "0" && this.Enabled == true)
            {
                try
                {
                    municipio = municipioGL.GetMunicipioIBGE(Convert.ToInt32(codigoIBGEButtonEdit.Text));
                    municipioTextEdit.Text = municipio.Nome;
                    UFTextEdit.Text = municipio.UF.Codigo;
                }
                catch
                {
                    municipio.Codigoibge = Convert.ToInt32(codigoIBGEButtonEdit.Text);
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
            responsavelDTO.Municipio = municipio;
        }

        private void cpfTextEdit_Validated(object sender, EventArgs e)
        {
            if (cpfTextEdit.IsModified)
            {
                try
                {
                    if ((string)cpfTextEdit.EditValue != "")
                    {
                        Cursor = Cursors.WaitCursor;
                        responsavelGL.ChecaResponsavel("cpf", (string)cpfTextEdit.EditValue, (int)idTextEdit.EditValue);
                    }
                    dxErrorProvider.SetError(cpfTextEdit, string.Empty);
                }
                catch (Exception ex)
                {
                    dxErrorProvider.SetError(cpfTextEdit, ex.Message, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                }
                Cursor = Cursors.Default;
            }
        }

        private void cnpjTextEdit_Validated(object sender, EventArgs e)
        {
            if (cnpjTextEdit.IsModified)
            {
                try
                {
                    if ((string)cnpjTextEdit.EditValue != "")
                    {
                        Cursor = Cursors.WaitCursor;
                        responsavelGL.ChecaResponsavel("cnpj", (string)cnpjTextEdit.EditValue, (int)idTextEdit.EditValue);
                    }
                    dxErrorProvider.SetError(cnpjTextEdit, string.Empty);
                }
                catch (Exception ex)
                {
                    dxErrorProvider.SetError(cnpjTextEdit, ex.Message, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                }
                Cursor = Cursors.Default;
            }
        }

        private void ceiTextEdit_Validated(object sender, EventArgs e)
        {
            if (ceiTextEdit.IsModified)
            {
                try
                {
                    if ((string)ceiTextEdit.EditValue != "")
                    {
                        Cursor = Cursors.WaitCursor;
                        responsavelGL.ChecaResponsavel("cei", (string)ceiTextEdit.EditValue, (int)idTextEdit.EditValue);
                    }
                    dxErrorProvider.SetError(ceiTextEdit, string.Empty);
                }
                catch (Exception ex)
                {
                    dxErrorProvider.SetError(ceiTextEdit, ex.Message, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                }
                Cursor = Cursors.Default;
            }
        }

        private void nitTextEdit_Validated(object sender, EventArgs e)
        {
            if (nitTextEdit.IsModified)
            {
                try
                {
                    if ((string)nitTextEdit.EditValue != "")
                    {
                        Cursor = Cursors.WaitCursor;
                        responsavelGL.ChecaResponsavel("nit", (string)nitTextEdit.EditValue, (int)idTextEdit.EditValue);
                    }
                    dxErrorProvider.SetError(nitTextEdit, string.Empty);
                }
                catch (Exception ex)
                {
                    dxErrorProvider.SetError(nitTextEdit, ex.Message, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                }
                Cursor = Cursors.Default;
            }
        }

        //PERSISTÊNCIA DE MUNICÍPIO
        private void Municipio()
        {
            //MUNICÍPIO
            try
            {
                ((ResponsavelDTO)ResponsavelDTOBindingSource.Current).Municipio = municipioGL.GetMunicipioIBGE(Convert.ToInt32(codigoIBGEButtonEdit.Text));
            }
            catch { }
        }
        //

        private void UFRGLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!UFRGLookUpEdit.IsModified)
                return;

            responsavelDTO.UFRG = (UFDTO)UFRGLookUpEdit.Properties.GetDataSourceRowByKeyValue(UFRGLookUpEdit.EditValue);
            if (responsavelDTO.UFRG == null)
                responsavelDTO.UFRG = new UFDTO();
        }

        private void UFNumeroRegistroLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!UFNumeroRegistroLookUpEdit.IsModified)
                return;

            responsavelDTO.UFNumeroRegistro = (UFDTO)UFNumeroRegistroLookUpEdit.Properties.GetDataSourceRowByKeyValue(UFNumeroRegistroLookUpEdit.EditValue);
            if (responsavelDTO.UFNumeroRegistro == null)
                responsavelDTO.UFNumeroRegistro = new UFDTO();
        }


        private void BuscaCep()
        {
            if (ProcuraCEP)
                return;

            try
            {
                ProcuraCEP = true;

                Cursor = Cursors.WaitCursor;
                BuscaCEPGL cep = new BuscaCEPGL();
                List<BuscaCEPDTO> dados = new List<BuscaCEPDTO>();


                if (responsavelDTO.Cep != "")
                    dados = cep.GetEndereco("",
                                            "",
                                            "",
                                            responsavelDTO.Cep);

                if ((dados == null) || (dados.Count == 0) || (dados.Count > 1))
                {
                    frmBuscaCEP frmCep = new frmBuscaCEP(this, new MechTech.Util.Global.SystemDelegate(SetCep));
                    frmCep.Show();
                }
                else
                {
                    cepTextEdit.EditValue = dados[0].Cep;
                    UFTextEdit.EditValue = dados[0].Uf;
                    codigoIBGEButtonEdit.EditValue = dados[0].CodMun;
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

        private void SetCep(object cep)
        {
            codigoIBGEButtonEdit.Text = ((BuscaCEPDTO)cep).CodMun.ToString();
            municipioTextEdit.Text = ((BuscaCEPDTO)cep).Municipio;
            UFTextEdit.Text = ((BuscaCEPDTO)cep).Uf;
            cepTextEdit.Text = ((BuscaCEPDTO)cep).Cep;
            enderecoTextEdit.Text = ((BuscaCEPDTO)cep).Endereco;
            bairroTextEdit.Text = ((BuscaCEPDTO)cep).Bairro;
        }

        private void cepTextEdit_Validated(object sender, EventArgs e)
        {
            if (responsavelDTO.Cep != "")
                BuscaCep();
        }

        private void cepTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            BuscaCep();
        }
    }
}