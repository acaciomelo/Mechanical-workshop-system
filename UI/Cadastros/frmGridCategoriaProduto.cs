﻿using System;
using System.Windows.Forms;

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Templates;
using MechTech.Entities;
using MechTech.Gateway;
#endregion

#region DEVEXPRESS
using DevExpress.XtraEditors;
#endregion

namespace MechTech.UI.Cadastros
{
    public partial class frmGridCategoriaProduto : frmBase
    {
        bool isEnabled;
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        Form frmUpdate { get; set; }
        CategoriaProdutoDTO categoriaDTO = new CategoriaProdutoDTO();
        CategoriaProdutoGL categoriaGL = new CategoriaProdutoGL();
        Global.SystemDelegate GetCategoriaProduto;
        public frmGridCategoriaProduto()
        {
            InitializeComponent();
            isEnabled = true;
        }

        public frmGridCategoriaProduto(Form frm, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = false;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetCategoriaProduto = target;
        }

        public frmGridCategoriaProduto(Form frm, bool enabled, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = enabled;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetCategoriaProduto = target;
        }

        private void btnInserir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Novo();
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Alterar();
        }

        private void btnExcluir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Excluir();
        }

        private void btnVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Visualizar();
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
        }

        private void Filtro_EditValueChanged(object sender, EventArgs e)
        {
            txtConsulta.EditValue = string.Empty;
            if (Filtro.EditValue.ToString().ToUpper() == "CÓDIGO")
            {
                btnPesquisa.Mask.EditMask = "([0-9]+;)*([0-9]+)";
                btnPesquisa.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                btnPesquisa.Mask.ShowPlaceHolders = false;
                btnPesquisa.Mask.UseMaskAsDisplayFormat = true;
            }
            else
            {
                btnPesquisa.Mask.EditMask = string.Empty;
                btnPesquisa.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                btnPesquisa.Mask.ShowPlaceHolders = true;
                btnPesquisa.Mask.UseMaskAsDisplayFormat = false;
            }
        }

        private void btnPesquisa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Pesquisar(sender);
        }

        private void btnPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                Pesquisar(sender);
        }

        private void frmGridDepartamento_Load(object sender, EventArgs e)
        {
            try
            {
                frmUpdate.Enabled = isEnabled;
            }
            catch
            { }
        }

        private void frmGridDepartamento_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmUpdate.Enabled = true;
            }
            catch
            { }
        }

        private void HabilitaDesabilitaBotoes()
        {
            if (dgdTabela.FocusedView.DataRowCount == 0)
            {
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnVisualizar.Enabled = false;
                btnImprimir.Enabled = false;
                btnSelecionar.Enabled = false;
            }
            else
            {
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnVisualizar.Enabled = true;
                btnImprimir.Enabled = true;

                if (tpOperacao == Enumeradores.TipoOperacao.Select)
                {
                    btnSelecionar.Enabled = true;
                }
            }
        }

        private void Pesquisar(object sender)
        {
            BaseEdit texto = (BaseEdit)sender;
            if (!ValidaCampos(texto.Text)) return;
            Cursor = Cursors.WaitCursor;
            try
            {
                switch (Filtro.EditValue.ToString().ToUpper())
                {
                    case "CÓDIGO":
                        CategoriaProdutoDTOBindingSource.DataSource = categoriaGL.GetGridCategoria("codigo", texto.Text.Replace(";", ","));
                        break;
                    case "NOME":
                        CategoriaProdutoDTOBindingSource.DataSource = categoriaGL.GetGridCategoria("nome", "%" + texto.Text + "%");
                        break;
                }
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            Cursor = Cursors.Default;
        }

        private void Novo()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateCategoriaProduto frmUpdate = new frmUpdateCategoriaProduto(this, Enumeradores.TipoOperacao.Insert, CategoriaProdutoDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Alterar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateCategoriaProduto frmUpdate = new frmUpdateCategoriaProduto(this, Enumeradores.TipoOperacao.Update, CategoriaProdutoDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void Visualizar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateCategoriaProduto frmUpdate = new frmUpdateCategoriaProduto(this, Enumeradores.TipoOperacao.Viewer, CategoriaProdutoDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }
        private void Excluir()
        {
            if (MessageBox.Show("Deseja realmente excluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                categoriaDTO = (CategoriaProdutoDTO)CategoriaProdutoDTOBindingSource.Current;

                try
                {
                    categoriaGL.Delete(categoriaDTO.Id);
                    CategoriaProdutoDTOBindingSource.RemoveCurrent();
                }
                catch
                {
                    throw;
                }
            }
        }

        private void Imprimir()
        {
            base.ShowRibbonPreview(dgdTabela, "Listagem do Cadastro de Categorias");
        }

        private void gridView_RowCountChanged(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoes();
        }

        private void dgdTabela_DoubleClick(object sender, EventArgs e)
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Select)
                Selecionar();
            else
            {
                if (btnEditar.Enabled)
                {
                    Cursor = Cursors.WaitCursor;
                    frmUpdateCategoriaProduto frmUpdate = new frmUpdateCategoriaProduto(this, Enumeradores.TipoOperacao.Update, CategoriaProdutoDTOBindingSource);
                    frmUpdate.Show();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void Selecionar()
        {
            try
            {
                GetCategoriaProduto((CategoriaProdutoDTO)CategoriaProdutoDTOBindingSource.Current);
            }
            catch
            { }

            Close();
        }

        private void btnSelecionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Selecionar();
        }
        private bool ValidaCampos(string conteudo)
        {
            dxErrorProvider.ClearErrors();

            if (Filtro.EditValue.ToString().ToUpper() == "CÓDIGO")
            {
                if (conteudo.Trim() != string.Empty)
                {
                    if (conteudo.Trim().Substring(conteudo.Trim().Length - 1, 1).Equals(";"))
                    {
                        MessageBox.Show("Conteúdo inválido. Ponto e vírgula (;) identificado no final da expressão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return true;
        }
    }
}