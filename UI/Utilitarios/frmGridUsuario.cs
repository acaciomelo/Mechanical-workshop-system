using System;
using System.Windows.Forms;

#region MECHTECH
using MechTech.Util.Templates;
using MechTech.Entities;
using MechTech.Business;
using MechTech.Util;
using MechTech.Gateway;
#endregion

#region DEVEXPRESS
using DevExpress.XtraEditors;
#endregion

namespace MechTech.UI.Utilitarios
{
    public partial class frmGridUsuario : frmBase
    {
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        UsuarioDTO usuarioDTO = new UsuarioDTO();
        DatabaseStructureCoreBO databasestructureBO = new DatabaseStructureCoreBO();
        UsuarioBO usuarioBO = new UsuarioBO();

        public frmGridUsuario()
        {
            InitializeComponent();
        }

        private void dgdTabela_DoubleClick(object sender, EventArgs e)
        {
            if (btnEditar.Enabled)
            {
                usuarioDTO = (UsuarioDTO)UsuarioDTOBindingSource.Current;
                if (usuarioDTO.Id == 1 && Global.UsuarioAtivo.ToUpper() != "MECHTECH")
                {
                    MessageBox.Show("O usuário '" + usuarioDTO.Login + "' não pode ser alterado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Alterar();
            }
        }

        private void gridView_RowCountChanged(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoes();
        }

        private void frmGridUsuario_Shown(object sender, EventArgs e)
        {
            if (!Global.Supervisor)
            {
                MessageBox.Show("Acesso restrito somente a usuários com permissão de Supervisor.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
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
                        UsuarioDTOBindingSource.DataSource = usuarioBO.GetGridUsuario("id", texto.Text.Replace(";", ","));
                        break;
                    case "LOGIN":
                        UsuarioDTOBindingSource.DataSource = usuarioBO.GetGridUsuario("login", "%" + texto.Text + "%");
                        break;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                "Motivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        public void Novo()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateUsuario frmUpdate = new frmUpdateUsuario(this, Enumeradores.TipoOperacao.Insert, UsuarioDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Alterar();
        }
        public bool Alterar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateUsuario frmUpdate = new frmUpdateUsuario(this, Enumeradores.TipoOperacao.Update, UsuarioDTOBindingSource);
            frmUpdate.Show();
            Cursor = Cursors.Default;

            return true;
        }

        private void btnExcluir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Excluir();
        }

        private void Excluir()
        {
            usuarioDTO = (UsuarioDTO)UsuarioDTOBindingSource.Current;
            if (usuarioDTO.Id == 1)
            {
                MessageBox.Show("O usuário '" + usuarioDTO.Login + "' não pode ser excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usuarioDTO.Login.ToUpper() == Global.UsuarioAtivo.ToUpper())
            {
                MessageBox.Show("O usuário '" + usuarioDTO.Login + "' está em uso no momento e não pode ser excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    usuarioBO.Delete(usuarioDTO.Id);
                    DeleteCascade();

                    //
                    databasestructureBO.DropRole(usuarioDTO.Login);
                    //

                    UsuarioDTOBindingSource.RemoveCurrent();
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                    "Motivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Cursor = Cursors.Default;
            }
        }
        public void DeleteCascade()
        {
            //PERFIL POR USUÁRIO
            try
            {
                new UsuarioPerfilGL().Delete(((UsuarioDTO)UsuarioDTOBindingSource.Current).Id);
            }
            catch { }

            //ROTINA POR USUÁRIO
            try
            {
                new UsuarioRotinaGL().Delete(((UsuarioDTO)UsuarioDTOBindingSource.Current).Id);
            }
            catch { }
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
        }
        private void Imprimir()
        {
            base.ShowRibbonPreview(dgdTabela, "Listagem do Cadastro de Usuários");
        }

        private void txtConsulta_EditValueChanged(object sender, EventArgs e)
        {

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
        public  void Visualizar()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateUsuario frmUpdate = new frmUpdateUsuario(this, Enumeradores.TipoOperacao.Viewer, UsuarioDTOBindingSource);
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

        private void btnPesquisa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Pesquisar(sender);
        }

        private void btnImprimir_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
        }

        private void btnPesquisa_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                Pesquisar(sender);
        }
    }
}