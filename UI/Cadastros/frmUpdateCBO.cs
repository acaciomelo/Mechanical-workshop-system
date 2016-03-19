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
    public partial class frmUpdateCBO : frmBase
    {
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        CBODTO cboDTO { get; set; }
        BindingSource bndCBOGrid = new BindingSource();
        CBOGL cboGL = new CBOGL();
        Acesso acesso = new Acesso();
        public frmUpdateCBO()
        {
            InitializeComponent();
        }

        public frmUpdateCBO(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndCBOGrid = bnd;

                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                    CBODTOBindingSource.AddNew();
                else
                {
                    cboDTO = (CBODTO)bndCBOGrid.Current;
                    CBODTOBindingSource.DataSource = cboGL.GetCBO(cboDTO.Id);
                }

                cboDTO = (CBODTO)CBODTOBindingSource.Current;
            }
            catch
            {
                throw;
            }
        }

        private void frmUpdateCBO_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;

            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir CBO";
                    cboDTO.Grupo = "Ocupação";
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar CBO";
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar CBO";
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

        private void frmUpdateCBO_FormClosed(object sender, FormClosedEventArgs e)
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
                if (ValidaCampos())
                    return;

                Cursor = Cursors.WaitCursor;
                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        cboDTO.Id = cboGL.Insert((CBODTO)CBODTOBindingSource.Current);
                        bndCBOGrid.Add(CBODTOBindingSource.Current);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        cboGL.Update((CBODTO)CBODTOBindingSource.Current);
                        bndCBOGrid.List[bndCBOGrid.Position] = CBODTOBindingSource.Current;
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

        /// <summary>
        /// Provedor de validações de objeto input.
        /// </summary>
        /// <returns>Retorna um tipo VERDADEIRO caso erros sejam detectados, caso contrário FALSO.</returns>
        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors();

            if (cboDTO.Codigo.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(txtCodigo, "Código do CBO inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (cboDTO.Descricao.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(txtDescricao, "Descrição inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            return dxErrorProvider.HasErrors;
        }
    }
}