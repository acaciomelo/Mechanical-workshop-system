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
    public partial class frmUpdateSetor : DevExpress.XtraEditors.XtraForm
    {
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        SetorDTO setorDTO { get; set; }
        BindingSource bndSetorGrid = new BindingSource();
        SetorGL setorGL = new SetorGL();
        public frmUpdateSetor()
        {
            InitializeComponent();
        }

        public frmUpdateSetor(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndSetorGrid = bnd;

                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                {
                    SetorDTOBindingSource.AddNew();
                }
                else
                {
                    setorDTO = (SetorDTO)bndSetorGrid.Current;
                    SetorDTOBindingSource.DataSource = setorGL.GetSetor(setorDTO.Id);
                }

                setorDTO = (SetorDTO)SetorDTOBindingSource.Current;
            }
            catch
            {
                throw;
            }
        }

        private void frmUpdateSetor_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;

            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Setor";
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Setor";
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Setor";
                    break;
                default:
                    break;
            }
        }

        private void frmUpdateSetor_FormClosed(object sender, FormClosedEventArgs e)
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
                        setorDTO.Id = setorGL.Insert((SetorDTO)SetorDTOBindingSource.Current);
                        bndSetorGrid.Add(SetorDTOBindingSource.Current);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        setorGL.Update((SetorDTO)SetorDTOBindingSource.Current);
                        bndSetorGrid.List[bndSetorGrid.Position] = SetorDTOBindingSource.Current;
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

            if (setorDTO.Codigo == 0)
                dxErrorProvider.SetError(codigoTextEdit, "Código do setor inválido. Preenchimento obrigatório", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (setorDTO.Nome.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(nomeTextEdit, "Nome inválido. Preenchimento obrigatório", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            return dxErrorProvider.HasErrors;
        }
    }
}