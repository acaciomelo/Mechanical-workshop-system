using System;
using System.Windows.Forms;

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
    public partial class frmUpdateSalario : frmBase
    {
        bool acessocamposalario = true;

        Enumeradores.TipoOperacao tpOperacao { get; set; }
        FuncSalarioDTO funcsalarioDTO { get; set; }
        FuncSalarioDTO funcsalarioDTOVersaoOriginal { get; set; }
        BindingSource bndFuncsalarioGrid = new BindingSource();
        FuncaoGL funcaoGL = new FuncaoGL();
        DepartamentoGL deptoGL = new DepartamentoGL();
        SetorGL setorGL = new SetorGL();
        SecaoGL secaoGL = new SecaoGL();
        public frmUpdateSalario()
        {
            InitializeComponent();
        }

        public frmUpdateSalario(Enumeradores.TipoOperacao tpo, BindingSource bnd, bool acessocamposalario)
        {
            InitializeComponent();
            this.acessocamposalario = acessocamposalario;

            try
            {
                tpOperacao = tpo;
                bndFuncsalarioGrid = bnd;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                    FuncSalarioDTOBindingSource.AddNew();
                else
                {
                    funcsalarioDTO = (FuncSalarioDTO)bndFuncsalarioGrid.Current;
                    FuncSalarioDTOBindingSource.DataSource = funcsalarioDTO;
                    funcsalarioDTOVersaoOriginal = new FuncSalarioDTO(funcsalarioDTO);
                }
                funcsalarioDTO = (FuncSalarioDTO)FuncSalarioDTOBindingSource.Current;

                FuncaoDTOBindingSource.DataSource = funcaoGL.GetGridFuncao("f.id", string.Empty);
            }
            catch
            {
                throw;
            }
        }

        private void frmUpdateSalario_Load(object sender, EventArgs e)
        {
            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Salário";
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Salário";
                    try
                    {
                        LocalizarDepto();
                    }
                    catch { }
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Salário";
                    try
                    {
                        LocalizarDepto();
                    }
                    catch { }
                    DisableControls();
                    break;
                default:
                    break;
            }
        }

        private void frmUpdateSalario_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (tpOperacao.Equals(Enumeradores.TipoOperacao.Update) && DialogResult == DialogResult.Cancel)
                bndFuncsalarioGrid.List[bndFuncsalarioGrid.Position] = funcsalarioDTOVersaoOriginal;
        }
        private void Acesso()
        {
            lblSalario.Visible = acessocamposalario;
            salarioTextEdit.Visible = acessocamposalario;
            lblSiglaSalario.Visible = acessocamposalario;
        }

        private void DisableControls()
        {
            btnSalvar.Enabled = false;
            dataDateEdit.Properties.ReadOnly = true;
            DissidioDateEdit.Properties.ReadOnly = true;
            motivoTextEdit.Properties.ReadOnly = true;
            codigodeptoButtonEdit.Properties.ReadOnly = true;
            codigodeptoButtonEdit.Properties.Buttons[0].Enabled = false;
            funcaoLookUpEdit.Properties.ReadOnly = true;
            salarioTextEdit.Properties.ReadOnly = true;
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (ValidaCampos())
                    return;

                Cursor = Cursors.WaitCursor;
                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        bndFuncsalarioGrid.Sort = "data DESC";
                        bndFuncsalarioGrid.Add(funcsalarioDTO);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        bndFuncsalarioGrid.List[bndFuncsalarioGrid.Position] = funcsalarioDTO;
                        break;
                    default:
                        break;
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Provedor de validações de objeto input.
        /// </summary>
        /// <returns>Retorna um tipo VERDADEIRO caso erros sejam detectados, caso contrário FALSO.</returns>
        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors();

            if (funcsalarioDTO.Data == null)
                dxErrorProvider.SetError(dataDateEdit, "Data de alteração inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            try
            {
                if (funcsalarioDTO.Departamento.Codigo != 0)
                    LocalizarDepto();
            }
            catch
            {
                dxErrorProvider.SetError(codigodeptoButtonEdit, "Departamento não localizado.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }

            try
            {
                if (funcsalarioDTO.Setor.Codigo != 0)
                    LocalizarSetor();
            }
            catch
            {
                dxErrorProvider.SetError(codigosetorButtonEdit, "Setor não localizado.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }

            try
            {
                if (funcsalarioDTO.Secao.Codigo != 0)
                    LocalizarSecao();
            }
            catch
            {
                dxErrorProvider.SetError(codigosecaoButtonEdit, "Seção não localizada.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }

            if (funcsalarioDTO.Funcao.Id == 0)
                dxErrorProvider.SetError(funcaoLookUpEdit, "Cargo inválida. Preenchimento obrigatório", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (funcsalarioDTO.Salario < 0)
                dxErrorProvider.SetError(salarioTextEdit, "Salário inválido. O valor deve ser superior a 0.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);

            return dxErrorProvider.HasErrors;
        }

        private DepartamentoDTO LocalizarDepto()
        {
            DepartamentoDTO depto;
            try
            {
                depto = deptoGL.GetDepartamentoCodigo(Convert.ToInt32(codigodeptoButtonEdit.Text));
                lblDepto.Text = "[" + depto.Nome + "]";
            }
            catch
            {
                lblDepto.Text = "[]";
                throw;
            }
            return depto;
        }

        private SetorDTO LocalizarSetor()
        {
            SetorDTO setor;
            try
            {
                setor = setorGL.GetSetorCodigo(Convert.ToInt32(codigosetorButtonEdit.Text));
                lblSetor.Text = "[" + setor.Nome + "]";
            }
            catch
            {
                lblSetor.Text = "[]";
                throw;
            }
            return setor;
        }

        private SecaoDTO LocalizarSecao()
        {
            SecaoDTO secao;
            try
            {
                secao = secaoGL.GetSecaoCodigo(Convert.ToInt32(codigosecaoButtonEdit.Text));
                lblSecao.Text = "[" + secao.Nome + "]";
            }
            catch
            {
                lblSecao.Text = "[]";
                throw;
            }
            return secao;
        }

        private void codigodeptoButtonEdit_Validated(object sender, EventArgs e)
        {
            DepartamentoDTO depto = new DepartamentoDTO();
            if (codigodeptoButtonEdit.Text.Trim() != "0" && this.Enabled == true)
            {
                try
                {
                    depto = LocalizarDepto();
                }
                catch
                {
                    depto.Codigo = Convert.ToInt32(codigodeptoButtonEdit.Text);

                    Cursor = Cursors.WaitCursor;
                    frmGridDepartamento frmgriddepartamento = new frmGridDepartamento(this, new MechTech.Util.Global.SystemDelegate(SetDepartamento));
                    frmgriddepartamento.ShowDialog();
                    Cursor = Cursors.Default;
                }
            }
            else
                lblDepto.Text = "[]";
            funcsalarioDTO.Departamento = depto;
        }

        private void codigosetorButtonEdit_Validated(object sender, EventArgs e)
        {
            if (!codigosetorButtonEdit.IsModified)
                return;

            SetorDTO setor = new SetorDTO();
            if (codigosetorButtonEdit.Text.Trim() != "0" && this.Enabled == true)
            {
                try
                {
                    setor = LocalizarSetor();
                }
                catch
                {
                    setor.Codigo = Convert.ToInt32(codigosetorButtonEdit.Text);

                    Cursor = Cursors.WaitCursor;
                    frmGridSetor frmgridsetor = new frmGridSetor(this, new MechTech.Util.Global.SystemDelegate(SetSetor));
                    frmgridsetor.ShowDialog();
                    Cursor = Cursors.Default;
                }
            }
            else
                lblSetor.Text = "[]";
            funcsalarioDTO.Setor = setor;
        }

        private void codigosecaoButtonEdit_Validated(object sender, EventArgs e)
        {
            if (!codigosecaoButtonEdit.IsModified)
                return;

            SecaoDTO secao = new SecaoDTO();
            if (codigosecaoButtonEdit.Text.Trim() != "0" && this.Enabled == true)
            {
                try
                {
                    secao = LocalizarSecao();
                }
                catch
                {
                    secao.Codigo = Convert.ToInt32(codigosecaoButtonEdit.Text);

                    Cursor = Cursors.WaitCursor;
                    frmGridSecao frmgridsecao = new frmGridSecao(this, new MechTech.Util.Global.SystemDelegate(SetSecao));
                    frmgridsecao.ShowDialog();
                    Cursor = Cursors.Default;
                }
            }
            else
                lblSecao.Text = "[]";
            funcsalarioDTO.Secao = secao;
        }

        private void funcaoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Viewer ||
                tpOperacao == Enumeradores.TipoOperacao.Update)
            {
                if (!funcaoLookUpEdit.IsModified)
                {
                    return;
                }
            }

            DevExpress.XtraEditors.LookUpEdit luefuncao = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (funcaoLookUpEdit.EditValue != null && luefuncao.Text.Trim().ToUpper() != string.Empty)
            {
                funcsalarioDTO.Funcao = funcaoGL.GetFuncao(((FuncaoDTO)funcaoLookUpEdit.Properties.GetDataSourceRowByKeyValue(funcaoLookUpEdit.EditValue)).Id);
                PopulateControls(funcsalarioDTO.Funcao);
            }
        }
        private void PopulateControls(FuncaoDTO funcao)
        {
            salarioTextEdit.EditValue = funcao.Salariofuncao;
        }

        private void codigodeptoButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridDepartamento frmGrid = new frmGridDepartamento(this, new MechTech.Util.Global.SystemDelegate(SetDepartamento));
            frmGrid.ShowDialog();
            Cursor = Cursors.Default;
        }
        //DEPTO

        private void SetDepartamento(object departamento)
        {
            codigodeptoButtonEdit.EditValue = ((DepartamentoDTO)departamento).Codigo.ToString();
            lblDepto.Text = "[" + ((DepartamentoDTO)departamento).Nome + "]";
        }

        private void codigosetorButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridSetor frmGrid = new frmGridSetor(this, new MechTech.Util.Global.SystemDelegate(SetSetor));
            frmGrid.ShowDialog();
            Cursor = Cursors.Default;
        }
        private void SetSetor(object setor)
        {
            codigosetorButtonEdit.EditValue = ((SetorDTO)setor).Codigo.ToString();
            lblSetor.Text = "[" + ((SetorDTO)setor).Nome + "]";
        }

        private void codigosecaoButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridSecao frmGrid = new frmGridSecao(this, new MechTech.Util.Global.SystemDelegate(SetSecao));
            frmGrid.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void SetSecao(object secao)
        {
            codigosecaoButtonEdit.EditValue = ((SecaoDTO)secao).Codigo.ToString();
            lblSecao.Text = "[" + ((SecaoDTO)secao).Nome + "]";
        }
    }
}