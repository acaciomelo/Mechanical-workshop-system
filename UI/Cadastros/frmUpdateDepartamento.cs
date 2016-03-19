using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    public partial class frmUpdateDepartamento : frmBase
    {
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        DepartamentoDTO departamentoDTO { get; set; }
        DepartamentoDTO departamentoDTOOriginal { get; set; }
        BindingSource bndDepartamentoGrid = new BindingSource();
        DepartamentoGL departamentoGL = new DepartamentoGL();
        MunicipioGL municipioGL = new MunicipioGL();
        Acesso acesso = new Acesso();
        
        bool ProcuraCEP = true;
        public frmUpdateDepartamento()
        {
            InitializeComponent();
        }

        public frmUpdateDepartamento(int id_departamento)
        {
            InitializeComponent();
            departamentoDTO = new DepartamentoDTO();
            departamentoDTO.Id = id_departamento;

        }

        public frmUpdateDepartamento(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndDepartamentoGrid = bnd;

                MdiParent = frmGrid.MdiParent;


                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                {
                    DepartamentoDTOBindingSource.AddNew();
                }
                else
                {
                    departamentoDTO = (DepartamentoDTO)bndDepartamentoGrid.Current;
                    DepartamentoDTOBindingSource.DataSource = departamentoGL.GetDepartamento(departamentoDTO.Id);
                    departamentoDTOOriginal = new DepartamentoDTO((DepartamentoDTO)DepartamentoDTOBindingSource.Current);
                }

                departamentoDTO = (DepartamentoDTO)DepartamentoDTOBindingSource.Current;

            }
            catch
            {
                throw;
            }
        }

        private void frmUpdateDepartamento_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;

            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Departamento";
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Departamento";
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Departamento";
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

        private void frmUpdateDepartamento_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Municipio();
                if (ValidaCampos())
                    return;

                Cursor = Cursors.WaitCursor;
                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        departamentoDTO.Id = departamentoGL.Insert((DepartamentoDTO)DepartamentoDTOBindingSource.Current);
                        bndDepartamentoGrid.Add(DepartamentoDTOBindingSource.Current);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        departamentoGL.Update((DepartamentoDTO)DepartamentoDTOBindingSource.Current);
                        bndDepartamentoGrid.List[bndDepartamentoGrid.Position] = DepartamentoDTOBindingSource.Current;
                        break;
                    default:
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

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Provedor de validações de objeto input.
        /// </summary>
        /// <returns>Retorna um tipo VERDADEIRO caso erros sejam detectados, caso contrário FALSO.</returns>
        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors();

            if (departamentoDTO.Codigo == 0)
                dxErrorProvider.SetError(codigoTextEdit, "Código do departamento inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (departamentoDTO.Nome.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(nomeTextEdit, "Nome inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (tpOperacao == Enumeradores.TipoOperacao.Insert)
            {
                List<DepartamentoDTO> verificacodigo = departamentoGL.GetGridDepartamento("codigo", departamentoDTO.Codigo.ToString());
                if (verificacodigo.Count > 0)
                    dxErrorProvider.SetError(codigoTextEdit, "Código do departamento em uso. Favor indicar outro código", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            if (departamentoDTO.Bairro.ToString().Count() > 20)
                dxErrorProvider.SetError(bairroTextEdit, "O campo bairro possui mais caracteres do que o permitido nos layouts, por gentileza informe dados de modo abreviado. Tamanho máximo: 20 Caracteres.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            return dxErrorProvider.HasErrors;
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
            departamentoDTO.Municipio = (MunicipioDTO)municipio;
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
            departamentoDTO.Municipio = municipio;
        }

        private void Municipio()
        {
            try
            {
                ((DepartamentoDTO)DepartamentoDTOBindingSource.Current).Municipio = municipioGL.GetMunicipioIBGE(Convert.ToInt32(codigoibgeButtonEdit.Text));
            }
            catch { }
        }

        private void BuscaCep()
        {

            //if (MechTech.Util.Global.Validacep == false)
            //{
            //    MessageBox.Show("Sua concessionária não contratou o serviço de consulta on-line de CEP. " +
            //                    "Para utilizar este serviço, acesse a Área do Cliente no website www.MECHTECH.inf.br \n" +
            //                    "na seção 'Administrador' e solicite a ativação deste recurso.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            // ProcuraCEP = false;

            //if (ProcuraCEP)
            //    return;

            try
            {
                // ProcuraCEP = true;
                Cursor = Cursors.WaitCursor;
                // BuscaCEPGL cep = new BuscaCEPGL();
                //List<BuscaCEPDTO> dados = new List<BuscaCEPDTO>();


                //if (funcionarioDTO.Cep != "")
                //    dados = cep.GetEndereco("",
                //                            "",
                //                            "",
                //                            funcionarioDTO.Cep);

                //if ((dados == null) || (dados.Count == 0) || (dados.Count > 1))
                //{
                frmBuscaCEP frmCep = new frmBuscaCEP(this, new MechTech.Util.Global.SystemDelegate(SetCep));
                frmCep.Show();
                //}
                //else
                //{
                //    cepTextEdit.EditValue = dados[0].Cep;
                //    UFTextEdit.EditValue = dados[0].Uf;
                //    codigoibgeButtonEdit.EditValue = dados[0].CodMun;
                //    municipioTextEdit.EditValue = dados[0].Municipio;
                //    enderecoTextEdit.EditValue = dados[0].Endereco;
                //    bairroTextEdit.EditValue = dados[0].Bairro;
                //}
            }
            finally
            {
                Cursor = Cursors.Default;
                // ProcuraCEP = false;
            }
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

        private void cepTextEdit_Validated(object sender, EventArgs e)
        {
            if (departamentoDTO.Cep != "")
                BuscaCep();
        }

        private void cepTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            BuscaCep();
        }
    }
}