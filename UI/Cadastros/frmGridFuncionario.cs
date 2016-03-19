using System;
using System.Windows.Forms;
using System.Reflection;

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
    public partial class frmGridFuncionario : frmBase
    {
        bool isEnabled;
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        Form frmUpdate { get; set; }
        FuncionarioSEDTO funcionarioSEDTO = new FuncionarioSEDTO();
        FuncionarioGL funcionarioGL = new FuncionarioGL();
        Global.SystemDelegate GetFuncionario;
        public frmGridFuncionario()
        {
            InitializeComponent();
            isEnabled = true;
        }

        /// <summary>
        /// Instância para frmGridFuncionario com opção de "Seleção".
        /// </summary>
        public frmGridFuncionario(Form frm, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = false;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetFuncionario = target;
        }

        /// <summary>
        /// Instância para frmGridFuncionario com opção de "Seleção" e controle de estado do formulário.
        /// </summary>
        public frmGridFuncionario(Form frm, bool enabled, Global.SystemDelegate target)
        {
            InitializeComponent();

            isEnabled = enabled;
            tpOperacao = Enumeradores.TipoOperacao.Select;

            frmUpdate = frm;
            MdiParent = frmUpdate.MdiParent;

            GetFuncionario = target;
        }

        private void frmGridFuncionario_Load(object sender, EventArgs e)
        {
            try
            {
                frmUpdate.Enabled = isEnabled;
            }
            catch
            { }
        }

        private void frmGridFuncionario_FormClosed(object sender, FormClosedEventArgs e)
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
                    btnSelecionar.Enabled = true;
            }
        }

        /// <summary>
        /// Sincronizador.
        /// </summary>
        public void Pesquisar()
        {
            string texto = string.Empty;
            try
            {
                texto = txtConsulta.EditValue.ToString();
            }
            catch
            {
                texto = string.Empty;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                switch (Filtro.EditValue.ToString().ToUpper())
                {
                    case "CÓDIGO":
                        FuncionarioSEDTOBindingSource.DataSource = funcionarioGL.GetGridFuncionarioSE("id", texto.Replace(";", ","), MechTech.Util.Enumeradores.Modulo.Funcionario, false);
                        break;
                    case "Nº FICHA":
                        FuncionarioSEDTOBindingSource.DataSource = funcionarioGL.GetGridFuncionarioSE("numficharegistro", texto.Replace(";", ","), MechTech.Util.Enumeradores.Modulo.Funcionario, false);
                        break;
                    case "NOME COMPLETO":
                        FuncionarioSEDTOBindingSource.DataSource = funcionarioGL.GetGridFuncionarioSE("nomecompleto", "%" + texto + "%", MechTech.Util.Enumeradores.Modulo.Funcionario, false);
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

        /// <summary>
        /// Interface.
        /// </summary>
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
                        FuncionarioSEDTOBindingSource.DataSource = funcionarioGL.GetGridFuncionarioSE("id", texto.Text.Replace(";", ","), MechTech.Util.Enumeradores.Modulo.Funcionario, true);
                        break;
                    case "Nº FICHA":
                        FuncionarioSEDTOBindingSource.DataSource = funcionarioGL.GetGridFuncionarioSE("numficharegistro", texto.Text.Replace(";", ","), MechTech.Util.Enumeradores.Modulo.Funcionario, true);
                        break;
                    case "NOME COMPLETO":
                        FuncionarioSEDTOBindingSource.DataSource = funcionarioGL.GetGridFuncionarioSE("nomecompleto", "%" + texto.Text + "%", MechTech.Util.Enumeradores.Modulo.Funcionario, true);
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

        private void btnPesquisa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
            frmUpdateFuncionario frmUpdate = new frmUpdateFuncionario(this, Enumeradores.TipoOperacao.Insert, FuncionarioSEDTOBindingSource);
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
            frmUpdateFuncionario frmUpdate = new frmUpdateFuncionario(this, Enumeradores.TipoOperacao.Update, FuncionarioSEDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void btnExcluir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Excluir();
        }

        private void Excluir()
        {
            if (MessageBox.Show("A exclusão deste cadastro irá eliminar TODOS os dados referente a este funcionário. Deseja realmente excluir ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                funcionarioSEDTO = (FuncionarioSEDTO)FuncionarioSEDTOBindingSource.Current;

                try
                {
                    funcionarioGL.Delete(funcionarioSEDTO.Id);
                    FuncionarioSEDTOBindingSource.RemoveCurrent();

                    //SINCRONIZAÇÃO
                    try
                    {
                        foreach (Form umform in Application.OpenForms)
                        {
                            if (umform.Text == "Digitação de Holerith" ||
                                umform.Text == "Férias Individualizada" ||
                                umform.Text == "Rescisão Individualizada" ||
                                umform.Text == "Cadastro de Duplo Vínculo")
                            {
                                MethodInfo metodo = Application.OpenForms[umform.Name].GetType().GetMethod("Pesquisar");
                                metodo.Invoke(umform, null);
                            }
                        }
                    }
                    catch { }
                }
                catch
                {
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
            base.ShowRibbonPreview(dgdTabela, "Listagem do Cadastro de Funcionários");
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
                    Alterar();
            }
        }

        private void Selecionar()
        {
            try
            {
                GetFuncionario((FuncionarioSEDTO)FuncionarioSEDTOBindingSource.Current);
            }
            catch
            { }

            Close();
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

        private void btnVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Visualizar();
        }
        private void Visualizar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateFuncionario frmUpdate = new frmUpdateFuncionario(this, Enumeradores.TipoOperacao.Viewer, FuncionarioSEDTOBindingSource);
            frmUpdate.Show();          
            Cursor = Cursors.Default;
        }
    }
}