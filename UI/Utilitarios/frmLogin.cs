using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Configuration;
using System.Drawing;

#region DEVEXPRESS
using DevExpress.XtraEditors;
#endregion

#region MECHTECH
using MechTech.Entities;
using MechTech.Business;
using MechTech.Util;
using MechTech.Util.Templates;
#endregion

namespace MechTech.UI.Utilitarios
{
    public partial class frmLogin : frmBase
    {
        IntPtr keypress;
        public Enumeradores.Sistema Sistema { get; set; }

        private XtraForm parent = null;
        UsuarioBO usuarioBO = new UsuarioBO();
        public frmLogin()
        {
            InitializeComponent();

            defaultLookAndFeel.LookAndFeel.SkinName = Global.Skin;
            lblLicenca.Text = Global.LicencaUso;
        }
        public frmLogin(XtraForm principal)
        {
            InitializeComponent();

            defaultLookAndFeel.LookAndFeel.SkinName = Global.Skin;
            parent = principal;
            lblLicenca.Text = Global.LicencaUso;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            if (parent == null)
                this.Activate();

            this.TopMost = true; 
            this.BringToFront(); 
            this.UsuarioTextEdit.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (parent != null)
            {
                List<Form> openforms = new List<Form>();
                foreach (Form umform in Application.OpenForms)
                {
                    if (!umform.Name.Equals(Global.MainForm) &&
                        !umform.Name.Equals("frmLogin") &&
                        !umform.Name.Equals("frmVisoesDisponiveis") &&
                        !umform.Name.Equals("frmRelatoriosDisponiveis") &&
                        !umform.Name.Trim().Equals(string.Empty) &&
                        !umform.Text.Trim().Equals(string.Empty))
                        openforms.Add(umform);
                }
                if (openforms.Count > 0)
                {
                    if (MessageBox.Show("Para alternar usuários é necessário que TODAS as telas do Sistema estejam fechadas. Deseja fechar TODAS as telas agora ? \n\n" +
                                        "OBS: Telas com dados não salvos serão perdidos. Certifique-se que todas as operações estejam salvas antes de prosseguir.", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (Form umform in openforms)
                        {
                            if (Application.OpenForms[umform.Name].ControlBox)
                                Application.OpenForms[umform.Name].Close();
                        }
                    }
                    else
                        Close();
                }
            }
            Init();
        }
        private void Init()
        {
            Assembly fileEmbedded = Assembly.GetExecutingAssembly();
            switch (Sistema)
            {
                case Enumeradores.Sistema.MECHTECH: //TODO Adicionar ícone do sistema
                    //BackgroundImage = new Bitmap(fileEmbedded.GetManifestResourceStream("MECHTECH.Core.Util2.Images.Pngs.login_mbi.png"));
                    //BackgroundImageLayout = ImageLayout.Tile;
                    //Icon = new Icon(fileEmbedded.GetManifestResourceStream("MECHTECH.Core.Util2.Images.Icons"));
                    Text = "Login no Sistema de Oficina Mecânica";
                    break;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (((Keys)msg.WParam) == Keys.F4 & keypress == ((IntPtr)18))
                return true;

            keypress = msg.WParam;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UsuarioTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                OK();
        }

        private void SenhaTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                OK();
        }

        private void btnTrocaSenha_Click(object sender, EventArgs e)
        {
            if (UsuarioTextEdit.Text != string.Empty)
            {
                Cursor = Cursors.WaitCursor;
                frmTrocaSenha changepassword = new frmTrocaSenha(UsuarioTextEdit.Text);
                changepassword.Sistema = Enumeradores.Sistema.MECHTECH;
                changepassword.ShowDialog();
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Usuário inválido. Preenchimento obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UsuarioTextEdit.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            OK();
        }

        private void OK()
        {
            try
            {
                if (ValidaCampos()) return;

                Cursor = Cursors.WaitCursor;
                UsuarioDTO usuario = null;
                try
                {
                    usuario = usuarioBO.GetUsuarioByLogin(UsuarioTextEdit.Text);
                }
                catch { }

                //VALIDAR USUÁRIO
                if (usuario == null)
                {
                    MessageBox.Show("O Sistema não pode localizar o usuário especificado. Digite-o novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UsuarioTextEdit.Text = string.Empty;
                    SenhaTextEdit.Text = string.Empty;
                    UsuarioTextEdit.Focus();
                    Cursor = Cursors.Default;
                    return;
                }

                //VALIDAR SENHA
                if (!Global.CompareHash(SenhaTextEdit.Text, usuario.Senha))
                {
                    MessageBox.Show("A senha informada para o usuário '" + UsuarioTextEdit.Text + "' é inválida. Redigite-a novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SenhaTextEdit.Text = string.Empty;
                    SenhaTextEdit.Focus();
                    Cursor = Cursors.Default;
                    return;
                }

                //"LOAD" PERFIL
                if (Sistema == Enumeradores.Sistema.MECHTECH)
                {
                    if (!usuario.Mechtechativo)
                    {
                        MessageBox.Show("O usuário informado não tem permissão para operar o Sistema de Oficina Mecânica.", "Acesso negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(Environment.ExitCode);
                    }
                }

                Global.Id_UsuarioAtivo = usuario.Id;
                Global.UsuarioAtivo = usuario.Login;
                Global.Supervisor = usuario.Supervisor;
                Global.AtualizarModulos = usuario.Modulo;
                if (parent != null)
                {
                    MethodInfo metodo = Application.OpenForms[Global.MainForm].GetType().GetMethod("Perfil");
                    metodo.Invoke(parent, null);
                }

                //ATIVAR USUÁRIO DO SISTEMA NO BANCO DE DADOS
                string[] tags = Global.ConnectionStringPg.Split(';');
                tags[3] = "User=" + UsuarioTextEdit.Text.ToLower();
                tags[4] = "Password=" + SenhaTextEdit.Text.ToLower() + "mechtech" + usuario.Id.ToString();
                Global.ConnectionStringUser = tags[0] + ";" + tags[1] + ";" + tags[2] + ";" + tags[3] + ";" + tags[4] + ";" + tags[5] + ";" + tags[6];

                Cursor = Cursors.Default;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                "Motivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(Environment.ExitCode);
            }
            Cursor = Cursors.Default;
        }

        private bool ValidaCampos()
        {
            if (UsuarioTextEdit.Text == string.Empty)
            {
                MessageBox.Show("Usuário inválido. Preenchimento obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SenhaTextEdit.Text = string.Empty;
                UsuarioTextEdit.Focus();
                return true;
            }
            else
            {
                if (SenhaTextEdit.Text == string.Empty)
                {
                    MessageBox.Show("Senha inválida. Preenchimento obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SenhaTextEdit.Focus();
                    return true;
                }
            }

            return false;
        }
    }
}