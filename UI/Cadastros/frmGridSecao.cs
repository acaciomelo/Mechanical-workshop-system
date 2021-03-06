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
    public partial class frmGridSecao : frmBase
    {
        private bool isEnabled;
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        Form frmUpdate { get; set; }
        SecaoDTO secaoDTO = new SecaoDTO();
        SecaoGL secaoGL = new SecaoGL();
        Global.SystemDelegate GetSecao;
        /// <summary>
        /// Instância básica para frmGridSecao.
        /// </summary>
        public frmGridSecao()
        {
            InitializeComponent();
            isEnabled = true;
        }

        /// <summary>
        /// Instância para frmGridSecao com opção de "Seleção".
        /// </summary>
        public frmGridSecao(Form frm, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = false;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetSecao = target;
        }

        /// <summary>
        /// Instância para frmGridSecao com opção de "Seleção" e controle de estado do formulário.
        /// </summary>
        public frmGridSecao(Form frm, bool enabled, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = enabled;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetSecao = target;
        }

        private void HabilitaDesabilitaBotoes()
        {
            if (dgdTabela.FocusedView.DataRowCount == 0)
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnVisualizar.Enabled = false;
                btnImprimir.Enabled = false;
                btnSelecionar.Enabled = false;
            }
            else
            {
                btnAlterar.Enabled = true;
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
                        SecaoDTOBindingSource.DataSource = secaoGL.GetGridSecao("codigo", texto.Text.Replace(";", ","));
                        break;
                    case "NOME":
                        SecaoDTOBindingSource.DataSource = secaoGL.GetGridSecao("nome", "%" + texto.Text + "%");
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

        private void btnPesquisar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Pesquisar(sender);
        }

        private void btnPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                Pesquisar(sender);
        }

        private void btnInserir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Novo();
        }

        private void Excluir()
        {
            if (MessageBox.Show("Deseja realmente excluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                secaoDTO = (SecaoDTO)SecaoDTOBindingSource.Current;

                try
                {
                    secaoGL.Delete(secaoDTO.Id);
                    SecaoDTOBindingSource.RemoveCurrent();
                }
                catch
                {
                    throw;
                }
            }
        }

        private void Selecionar()
        {
            try
            {
                GetSecao((SecaoDTO)SecaoDTOBindingSource.Current);
            }
            catch
            { }

            Close();
        }
        private void Imprimir()
        {
            base.ShowRibbonPreview(dgdTabela, "Listagem do Cadastro de Seções");
        }
        private void Alterar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateSecao frmUpdate = new frmUpdateSecao(this, Enumeradores.TipoOperacao.Update, SecaoDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }
        private void Novo()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateSecao frmUpdate = new frmUpdateSecao(this, Enumeradores.TipoOperacao.Insert, SecaoDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
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

        private void btnAlterar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Alterar();
        }

        private void btnExcluir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Excluir();
        }

        private void btnVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void btnSelecionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Selecionar();
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
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
                if (btnAlterar.Enabled)
                {
                    Cursor = Cursors.WaitCursor;
                    frmUpdateSecao frmUpdate = new frmUpdateSecao(this, Enumeradores.TipoOperacao.Update, SecaoDTOBindingSource);
                    frmUpdate.Show();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void frmGridSecao_Load(object sender, EventArgs e)
        {
            try
            {
                frmUpdate.Enabled = isEnabled;
            }
            catch
            { }
        }

        private void frmGridSecao_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmUpdate.Enabled = true;
            }
            catch
            { }
        }

        private void Filtro_EditValueChanged(object sender, EventArgs e)
        {
            txtConsulta.EditValue = string.Empty;
            if (Filtro.EditValue.ToString().ToUpper() == "CÓDIGO")
            {
                btnPesquisar.Mask.EditMask = "([0-9]+;)*([0-9]+)";
                btnPesquisar.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                btnPesquisar.Mask.ShowPlaceHolders = false;
                btnPesquisar.Mask.UseMaskAsDisplayFormat = true;
            }
            else
            {
                btnPesquisar.Mask.EditMask = string.Empty;
                btnPesquisar.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                btnPesquisar.Mask.ShowPlaceHolders = true;
                btnPesquisar.Mask.UseMaskAsDisplayFormat = false;
            }
        }
    }
}