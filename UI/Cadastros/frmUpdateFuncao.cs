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
    public partial class frmUpdateFuncao : frmBase
    {
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        FuncaoDTO funcaoDTO { get; set; }
        FuncaoDTO funcaoDTOAux { get; set; }
        FuncaoDTO funcaoDTOOriginal { get; set; }
        BindingSource bndFuncaoGrid = new BindingSource();
        FuncaoGL funcaoGL = new FuncaoGL();
        SalarioTipoGL salariotipoGL = new SalarioTipoGL();
        CBOGL cboGL = new CBOGL();
        Acesso acesso = new Acesso();
        public frmUpdateFuncao()
        {
            InitializeComponent();
        }
        public frmUpdateFuncao(int id_funcao)
        {
            InitializeComponent();
            funcaoDTO = new FuncaoDTO();
            funcaoDTO.Id = id_funcao;

        }
        public frmUpdateFuncao(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndFuncaoGrid = bnd;

                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                {
                    FuncaoDTOBindingSource.AddNew();
                }
                else
                {
                    int funcaoId = 0;
                    funcaoDTO = (FuncaoDTO)bndFuncaoGrid.Current;
                    switch (funcaoDTO.Salariotipo.Descricao)
                    {
                        case "Pro-Labore":
                            funcaoId = 5;
                            break;
                            case "Horista":
                            funcaoId = 2;
                            break;
                            case "Comissionista":
                            funcaoId = 3;
                            break;
                            case "Estagiário":
                            funcaoId = 4;
                            break;
                             case "Autônomo":
                            funcaoId = 6;
                            break;
                        default:
                            funcaoId = 1;
                            break;
                    }
                    funcaoDTOAux = funcaoGL.GetFuncao(funcaoDTO.Id);
                    funcaoDTOAux.Salariotipo.Id = funcaoId;
                    funcaoDTOAux.CBO = new CBOGL().GetCBOCodigo(funcaoDTO.CBO.Codigo);
                    FuncaoDTOBindingSource.DataSource = funcaoDTOAux;
                    funcaoDTOOriginal = new FuncaoDTO((FuncaoDTO)FuncaoDTOBindingSource.Current);
                }

                funcaoDTO = (FuncaoDTO)FuncaoDTOBindingSource.Current;

                SalarioTipoDTOBindingSource.DataSource = salariotipoGL.GetGridSalariotipo("id", string.Empty);
            }
            catch
            {
                throw;
            }
        }

        private void frmUpdateFuncao_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;

            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Cargo";
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar cargo";
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Cargo";
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

        private void frmUpdateFuncao_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                CBO();

                if (ValidaCampos()) return;

                ((FuncaoDTO)FuncaoDTOBindingSource.Current).Salariotipo.Descricao = salariotipoLookUpEdit.Text;

                Cursor = Cursors.WaitCursor;
                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        funcaoDTO.Id = funcaoGL.Insert((FuncaoDTO)FuncaoDTOBindingSource.Current);
                        bndFuncaoGrid.Add(FuncaoDTOBindingSource.Current);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        funcaoGL.Update((FuncaoDTO)FuncaoDTOBindingSource.Current);
                        bndFuncaoGrid.List[bndFuncaoGrid.Position] = FuncaoDTOBindingSource.Current;
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

        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors();

            if (funcaoDTO.Nome.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(nomeTextEdit, "Nome inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (funcaoDTO.Salariotipo.Id != (int)MechTech.Util.Enumeradores.TipoSalario.Estagiario)
            {
                if (funcaoDTO.CBO.Codigo.Trim().Equals(string.Empty))
                    dxErrorProvider.SetError(codigocboButtonEdit, "CBO inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                else
                {
                    if (funcaoDTO.CBO.Descricao.Trim().Equals(string.Empty))
                        dxErrorProvider.SetError(codigocboButtonEdit, "CBO não localizado.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                }
            }

            if (funcaoDTO.Salariofuncao < 0)
                dxErrorProvider.SetError(salariofuncaoTextEdit, "Salário inválido. O valor deve ser superior ou igual a 0.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);

            if (funcaoDTO.Horas == 0)
                dxErrorProvider.SetError(horasTextEdit, "Nº de horas inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            else
            {
                if (funcaoDTO.Horas < 0)
                    dxErrorProvider.SetError(horasTextEdit, "Nº de horas inválido. O valor deve ser superior a 0", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }

            return dxErrorProvider.HasErrors;
        }

        private void codigocboButtonEdit_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridCBO frmGrid = new frmGridCBO(this, new Global.SystemDelegate(SetCBO));
            frmGrid.Show();
            Cursor = Cursors.Default;
        }

        private void codigocboButtonEdit_Validated(object sender, EventArgs e)
        {
            if (!codigocboButtonEdit.IsModified)
                return;

            CBODTO cbo = new CBODTO();
            if (codigocboButtonEdit.Text.Trim() != string.Empty && codigocboButtonEdit.Text.Trim() != "0" && this.Enabled == true)
            {
                try
                {
                    cbo = cboGL.GetCBOCodigo(codigocboButtonEdit.Text.Trim());
                    descricaocboTextEdit.Text = cbo.Descricao;
                }
                catch
                {
                    cbo.Codigo = codigocboButtonEdit.Text;
                    descricaocboTextEdit.Text = string.Empty;

                    Cursor = Cursors.WaitCursor;
                    frmGridCBO frmgridcbo = new frmGridCBO(this, new Global.SystemDelegate(SetCBO));
                    frmgridcbo.Show();
                    Cursor = Cursors.Default;
                }
            }
            else
                descricaocboTextEdit.Text = string.Empty;
            funcaoDTO.CBO = cbo;
        }

        private void SetCBO(object CBO)
        {
            codigocboButtonEdit.Text = ((CBODTO)CBO).Codigo.ToString();
            descricaocboTextEdit.Text = ((CBODTO)CBO).Descricao;
        }

        private void CBO()
        {
            try
            {
                ((FuncaoDTO)FuncaoDTOBindingSource.Current).CBO = cboGL.GetCBOCodigo(codigocboButtonEdit.Text.Trim());
            }
            catch { }
        }

        private void salariotipoLookUpEdit_TextChanged(object sender, EventArgs e)
        {
            if ((int)salariotipoLookUpEdit.EditValue == (int)MechTech.Util.Enumeradores.TipoSalario.Estagiario)
                CalculoHorasCheckEdit.Visible = true;
            else
            {
                CalculoHorasCheckEdit.Visible = false;
                CalculoHorasCheckEdit.EditValue = false;
            }
        }

    }
}