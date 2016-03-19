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
    public partial class frmUpdateCategoriaProduto : frmBase
    {
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        CategoriaProdutoDTO categoriaprodutoDTO { get; set; }
        CategoriaProdutoDTO categoriaprodutoDTOOriginal { get; set; }
        BindingSource bndCategoriaGrid = new BindingSource();
        CategoriaProdutoGL categoriaprodutoGL = new CategoriaProdutoGL();
        Acesso acesso = new Acesso();
        public frmUpdateCategoriaProduto()
        {
            InitializeComponent();
        }

        public frmUpdateCategoriaProduto(int id_categoria)
        {
            InitializeComponent();
            categoriaprodutoDTO = new CategoriaProdutoDTO();
            categoriaprodutoDTO.Id = id_categoria;
        }

        public frmUpdateCategoriaProduto(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndCategoriaGrid = bnd;

                MdiParent = frmGrid.MdiParent;


                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                {
                    CategoriaProdutoDTOBindingSource.AddNew();
                }
                else
                {
                    categoriaprodutoDTO = (CategoriaProdutoDTO)bndCategoriaGrid.Current;
                    CategoriaProdutoDTOBindingSource.DataSource = categoriaprodutoGL.GetCategoria(categoriaprodutoDTO.Id);
                    categoriaprodutoDTOOriginal = new CategoriaProdutoDTO((CategoriaProdutoDTO)CategoriaProdutoDTOBindingSource.Current);
                }
                categoriaprodutoDTO = (CategoriaProdutoDTO)CategoriaProdutoDTOBindingSource.Current;
            }
            catch
            {
                throw;
            }
        }

        private void frmUpdateCategoriaProduto_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;

            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Categoria";
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Categoria";
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Categoria";
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

        private void frmUpdateCategoriaProduto_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
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
                        categoriaprodutoDTO.Id = categoriaprodutoGL.Insert((CategoriaProdutoDTO)CategoriaProdutoDTOBindingSource.Current);
                        bndCategoriaGrid.Add(CategoriaProdutoDTOBindingSource.Current);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        categoriaprodutoGL.Update((CategoriaProdutoDTO)CategoriaProdutoDTOBindingSource.Current);
                        bndCategoriaGrid.List[bndCategoriaGrid.Position] = CategoriaProdutoDTOBindingSource.Current;
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

        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors();

            if (categoriaprodutoDTO.Codigo == 0)
                dxErrorProvider.SetError(codigoTextEdit, "Código da categoria inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (categoriaprodutoDTO.Nome.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(nomeTextEdit, "Nome inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (tpOperacao == Enumeradores.TipoOperacao.Insert)
            {
                List<CategoriaProdutoDTO> verificacodigo = categoriaprodutoGL.GetGridCategoria("codigo", categoriaprodutoDTO.Codigo.ToString());
                if (verificacodigo.Count > 0)
                    dxErrorProvider.SetError(codigoTextEdit, "Código da categoria em uso. Favor indicar outro código", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            return dxErrorProvider.HasErrors;
        }
    }
}