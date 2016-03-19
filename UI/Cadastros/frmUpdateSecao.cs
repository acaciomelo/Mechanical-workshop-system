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
    public partial class frmUpdateSecao : frmBase
    {
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        SecaoDTO secaoDTO { get; set; }
        BindingSource bndSecaoGrid = new BindingSource();
        SecaoGL secaoGL = new SecaoGL();
        public frmUpdateSecao()
        {
            InitializeComponent();
        }

        public frmUpdateSecao(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndSecaoGrid = bnd;

                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                {
                    SecaoDTOBindingSource.AddNew();
                }
                else
                {
                    secaoDTO = (SecaoDTO)bndSecaoGrid.Current;
                    SecaoDTOBindingSource.DataSource = secaoGL.GetSecao(secaoDTO.Id);
                }

                secaoDTO = (SecaoDTO)SecaoDTOBindingSource.Current;
            }
            catch
            {
                throw;
            }
        }

        private void frmUpdateSecao_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;

            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Seção";
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Seção";
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Seção";
                    break;
                default:
                    break;
            }
        }

        private void frmUpdateSecao_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Salvar();
        }

        private void Salvar()
        {
            try
            {
                if (ValidaCampos())
                    return;

                Cursor = Cursors.WaitCursor;
                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        secaoDTO.Id = secaoGL.Insert((SecaoDTO)SecaoDTOBindingSource.Current);
                        bndSecaoGrid.Add(SecaoDTOBindingSource.Current);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        secaoGL.Update((SecaoDTO)SecaoDTOBindingSource.Current);
                        bndSecaoGrid.List[bndSecaoGrid.Position] = SecaoDTOBindingSource.Current;
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

            if (secaoDTO.Codigo == 0)
                dxErrorProvider.SetError(codigoTextEdit, "Código da seção inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (secaoDTO.Nome.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(nomeTextEdit, "Nome inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            return dxErrorProvider.HasErrors;
        }
    }
}