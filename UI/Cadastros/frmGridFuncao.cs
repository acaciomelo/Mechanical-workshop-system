using System;
using System.Windows.Forms;

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Templates;
using MechTech.Entities;
using MechTech.Gateway;
using MechTech.UI.Utilitarios;
#endregion

#region DEVEXPRESS
using DevExpress.XtraEditors;
using System.Data.Common;
#endregion


namespace MechTech.UI.Cadastros
{
    public partial class frmGridFuncao : frmBase
    {
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        FuncaoDTO funcaoDTO = new FuncaoDTO();
        FuncaoGL funcaoGL = new FuncaoGL();
        Acesso acesso = new Acesso();
        public frmGridFuncao()
        {
            InitializeComponent();
        }

        private void frmGridFuncao_Load(object sender, EventArgs e)
        {
            acesso.Add(1122, btnInserir, Enumeradores.TipoAcao.Desabilitar);
            acesso.Add(1124, btnEditar, Enumeradores.TipoAcao.Desabilitar);
            acesso.Add(1125, btnExcluir, Enumeradores.TipoAcao.Desabilitar);
            acesso.Add(1126, btnVisualizar, Enumeradores.TipoAcao.Desabilitar);
            acesso.Add(1127, btnImprimir, Enumeradores.TipoAcao.Desabilitar);

            acesso.Validate();
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

            acesso.Validate();
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
                        FuncaoDTOBindingSource.DataSource = funcaoGL.GetGridFuncao("f.id", texto.Text.Replace(";", ","));
                        break;
                    case "NOME":
                        FuncaoDTOBindingSource.DataSource = funcaoGL.GetGridFuncao("nome", "%" + texto.Text + "%");
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

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Pesquisar(sender);
        }

        private void btnPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                Pesquisar(sender);
        }

        private void btnInserir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Novo();
        }
        private void Novo()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateFuncao frmUpdate = new frmUpdateFuncao(this, Enumeradores.TipoOperacao.Insert, FuncaoDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Alterar();
        }
        private void Alterar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateFuncao frmUpdate = new frmUpdateFuncao(this, Enumeradores.TipoOperacao.Update, FuncaoDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void btnExcluir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Excluir();
        }
        private void Excluir()
        {
            if (MessageBox.Show("Deseja realmente excluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                funcaoDTO = (FuncaoDTO)FuncaoDTOBindingSource.Current;

                try
                {
                    funcaoGL.Delete(funcaoDTO.Id);
                    FuncaoDTOBindingSource.RemoveCurrent();
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("violates foreign key")) //32787
                        throw new Exception(" Não é possível a exclusão, o cargo está sendo utilizado em outro cadastro.", new Exception(Enumeradores.TipoExcessao.Usuario.ToString()));
                    else
                        throw;
                }
            }
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
        }
        private void Imprimir()
        {
            base.ShowRibbonPreview(dgdTabela, "Listagem do Cadastro de Funções");
        }

        private void gridView_RowCountChanged(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoes();
        }

        private void dgdTabela_DoubleClick(object sender, EventArgs e)
        {
            if (btnEditar.Enabled)
            {
                Cursor = Cursors.WaitCursor;
                frmUpdateFuncao frmUpdate = new frmUpdateFuncao(this, Enumeradores.TipoOperacao.Update, FuncaoDTOBindingSource);
                frmUpdate.Show();
                Cursor = Cursors.Default;
            }
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            FuncaoDTO funcao = (FuncaoDTO)FuncaoDTOBindingSource[e.ListSourceRowIndex];

            if (e.Column.FieldName.Equals("CBO.Codigo") && e.ListSourceRowIndex >= 0 && e.IsGetData)
                e.Value = funcao.CBO.Codigo;
        }

        private void btnVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Visualizar();
        }
        private void Visualizar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateFuncao frmUpdate = new frmUpdateFuncao(this, Enumeradores.TipoOperacao.Viewer, FuncaoDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
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