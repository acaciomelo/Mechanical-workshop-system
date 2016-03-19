using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

#region DEVEXPRESS
using DevExpress.XtraEditors;
#endregion

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Templates;
using MechTech.Entities;
using MechTech.Business;
#endregion

namespace MechTech.UI.Utilitarios
{
    public partial class frmTrocaSenha : frmBase
    {
        public Enumeradores.Sistema Sistema { get; set; }
        public string NewPassword { get; set; }
        public bool IsSupervisor { get; set; }

        UsuarioDTO usuario = null;
        DatabaseStructureCoreBO databasestructureBO = new DatabaseStructureCoreBO();
        UsuarioBO usuarioBO = new UsuarioBO();
        public frmTrocaSenha()
        {
            Sistema = Enumeradores.Sistema.MECHTECH;
            InitializeComponent();
            defaultLookAndFeel.LookAndFeel.SkinName = Global.Skin;
            lblUsuario.Text = Global.UsuarioAtivo;
            RequestCurrentPass();
        }

        public frmTrocaSenha(string usuario)
        {
            InitializeComponent();
            Sistema = Enumeradores.Sistema.MECHTECH;
            defaultLookAndFeel.LookAndFeel.SkinName = Global.Skin;
            lblUsuario.Text = usuario;
            RequestCurrentPass();
        }
        private void RequestCurrentPass()
        {
            if (Global.Supervisor)
            {
                IsSupervisor = true;
                lblSenhaAtual.Visible = false;
                SenhaAtualTextEdit.Visible = false;
            }
        }

        private void frmTrocaSenha_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Salvar()
        {
            try
            {
                if (ValidaCampos()) return;

                Cursor = Cursors.WaitCursor;
                usuario.Senha = Global.CreateHash(NovaSenhaTextEdit.Text);
                usuarioBO.Update(usuario);

                //
                databasestructureBO.AlterRole(usuario.Id, usuario.Login, NovaSenhaTextEdit.Text);
                //

                this.NewPassword = usuario.Senha;
                MessageBox.Show("Senha alterada com sucesso.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                "Motivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Cursor = Cursors.Default;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Faz todas as validações necessárias dos campos da janela
        /// </summary>
        /// <returns>Retorna true se existir inconsistências na janela</returns>
        private bool ValidaCampos()
        {
            if (SenhaAtualTextEdit.Text == string.Empty &&
                !IsSupervisor)
            {
                MessageBox.Show("Senha atual inválida. Preenchimento obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NovaSenhaTextEdit.Text = string.Empty;
                RedigiteTextEdit.Text = string.Empty;
                SenhaAtualTextEdit.Focus();
                return true;
            }
            else
            {
                try
                {
                    usuario = usuarioBO.GetUsuarioByLogin(lblUsuario.Text);
                }
                catch { }

                //VALIDAR SENHA
                if (!IsSupervisor)
                {
                    if (usuario != null)
                    {
                        if (!Global.CompareHash(SenhaAtualTextEdit.Text, usuario.Senha))
                        {
                            MessageBox.Show("Senha atual inválida. Redigite-a novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            SenhaAtualTextEdit.Text = string.Empty;
                            NovaSenhaTextEdit.Text = string.Empty;
                            RedigiteTextEdit.Text = string.Empty;
                            SenhaAtualTextEdit.Focus();
                            return true;
                        }
                    }
                    else
                        throw new Exception("O Sistema não pode localizar o usuário especificado.");
                }

                if (NovaSenhaTextEdit.Text == string.Empty)
                {
                    MessageBox.Show("Nova senha inválida. Preenchimento obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RedigiteTextEdit.Text = string.Empty;
                    NovaSenhaTextEdit.Focus();
                    return true;
                }
                else
                {
                    if (RedigiteTextEdit.Text == string.Empty)
                    {
                        MessageBox.Show("Confirmação da senha inválida. Preenchimento obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RedigiteTextEdit.Focus();
                        return true;
                    }
                    else
                    {
                        if (RedigiteTextEdit.Text != NovaSenhaTextEdit.Text)
                        {
                            MessageBox.Show("A nova senha é diferente da senha de confirmação. Redigite-as novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            NovaSenhaTextEdit.Text = string.Empty;
                            RedigiteTextEdit.Text = string.Empty;
                            NovaSenhaTextEdit.Focus();
                            return true;
                        }
                    }
                }
            }

            return false; ;
        }
    }
}