using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

#region DEVEXPRESS
using DevExpress.XtraTreeList.Nodes;
#endregion

#region MECHTECH
using MechTech.Util;
using MechTech.Entities;
using MechTech.Gateway;
using MechTech.Util.Templates;
using MechTech.Business;
using System;
using DevExpress.XtraEditors;
using System.Drawing;
#endregion


namespace MechTech.UI.Utilitarios
{
    public partial class frmUpdateUsuario : frmBase
    {
        PerfilGL perfilGL = new PerfilGL();
        UsuarioPerfilGL usuarioperfilGL = new UsuarioPerfilGL();
        UsuarioRotinaGL usuariorotinaGL = new UsuarioRotinaGL();
        List<UsuarioPerfilDTO> perfisdatasource = new List<UsuarioPerfilDTO>();
        List<UsuarioRotinaDTO> rotinasdatasource = new List<UsuarioRotinaDTO>();
        string currentuser = string.Empty;
        string newpassword = string.Empty;
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        UsuarioDTO usuarioDTO { get; set; }
        BindingSource bndUsuarioGrid = new BindingSource();
        DatabaseStructureCoreBO databasestructureBO = new DatabaseStructureCoreBO();
        UsuarioBO usuarioBO = new UsuarioBO();
        Acesso acesso = new Acesso();
        public frmUpdateUsuario()
        {
            InitializeComponent();
        }

        public frmUpdateUsuario(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            if (Global.Sistema != Enumeradores.Sistema.MECHTECH)
                groupControl2.Visible = false;

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndUsuarioGrid = bnd;

                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                    UsuarioDTOBindingSource.AddNew();
                else
                {
                    usuarioDTO = (UsuarioDTO)bndUsuarioGrid.Current;
                    UsuarioDTOBindingSource.DataSource = usuarioBO.GetUsuario(usuarioDTO.Id);
                    currentuser = usuarioDTO.Login;
                }
                usuarioDTO = (UsuarioDTO)UsuarioDTOBindingSource.Current;

                CarregaPerfis();
                CarregaModulos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                "Motivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void CarregaPerfis()
        {
            PerfilDTOBindingSource.DataSource = perfilGL.GetGridPerfil("id", string.Empty);
            if (PerfilDTOBindingSource.List.Count <= 0)
            {
                MarcaButton.Enabled = false;
                DesmarcaButton.Enabled = false;
            }

            perfisdatasource = usuarioperfilGL.GetUsuarioPerfilUsuario(((MechTech.Entities.UsuarioDTO)UsuarioDTOBindingSource.Current).Id);
        }

        public  void CarregaModulos()
        {
            List<RotinaDTO> result = new List<RotinaDTO>();
            foreach (RotinaDTO umregistro in new RotinaGL().GetRotinaModulo(string.Empty))
            {
                if (!umregistro.Acesso)
                    continue;

                if (umregistro.Id == 1007 ||
                    umregistro.Id == 1008) //SAIR/SAIR DO SISTEMA
                    continue;

                if (umregistro.Descricao == "" && umregistro.Acao != "")
                    umregistro.Descricao = umregistro.Acao;

                if (umregistro.Nivel.Length > 2)
                    umregistro.ParentNivel = umregistro.Nivel.Substring(0, umregistro.Nivel.Length - 2);
                else
                    umregistro.ParentNivel = umregistro.Nivel;


                result.Add(umregistro);
            }
            RotinaDTOBindingSource.DataSource = result;

            rotinasdatasource = usuariorotinaGL.GetUsuarioRotinaUsuario(((MechTech.Entities.UsuarioDTO)UsuarioDTOBindingSource.Current).Id);
        }

        public  void CarregaAcessos()
        {
            foreach (PerfilDTO umperfil in (List<PerfilDTO>)PerfilDTOBindingSource.List)
            {
                var datasource = from p in perfisdatasource
                                 where p.Id_Perfil == umperfil.Id
                                 select p;
                if (datasource.Count() > 0)
                    umperfil.Selecao = true;
            }
            gridControl1.RefreshDataSource();
            Selecao2();

            foreach (UsuarioRotinaDTO umarotina in rotinasdatasource)
            {
                SetRotinas(treeList1.Nodes, umarotina.Id_Rotina);
            }
        }

        private void SetRotinas(TreeListNodes nodes, int id_rotina)
        {
            foreach (TreeListNode node in nodes)
            {
                if ((int)node.GetValue(treeListColumn2) == id_rotina)
                {
                    node.Checked = true;
                    break;
                }

                if (node.HasChildren)
                    SetRotinas(node.Nodes, id_rotina);
            }
        }

        List<UsuarioRotinaDTO> rotinas = new List<UsuarioRotinaDTO>();
        public void SalvaAcesso()
        {
            SalvaAcessoAux();

            List<UsuarioPerfilDTO> perfis = new List<UsuarioPerfilDTO>();
            foreach (PerfilDTO umperfil in (List<PerfilDTO>)PerfilDTOBindingSource.List)
            {
                if (umperfil.Selecao)
                    perfis.Add(new UsuarioPerfilDTO() { Id_Perfil = umperfil.Id });
            }
            usuarioperfilGL.Insert(perfis, ((MechTech.Entities.UsuarioDTO)UsuarioDTOBindingSource.Current).Id);

            rotinas.Clear();
            GetRotinas(treeList1.Nodes);
            usuariorotinaGL.Insert(rotinas, ((MechTech.Entities.UsuarioDTO)UsuarioDTOBindingSource.Current).Id);
        }

        private void GetRotinas(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                if (node.Checked && node.Tag == null)
                    rotinas.Add(new UsuarioRotinaDTO() { Id_Rotina = (int)node.GetValue(treeListColumn2) });

                if (node.HasChildren)
                    GetRotinas(node.Nodes);
            }
        }

        public  void MarcaTodos()
        {
            foreach (PerfilDTO umperfil in (List<PerfilDTO>)PerfilDTOBindingSource.List)
            {
                umperfil.Selecao = true;
            }
            gridControl1.RefreshDataSource();
            Selecao();
        }

        public  void DesmarcaTodos()
        {
            foreach (PerfilDTO umperfil in (List<PerfilDTO>)PerfilDTOBindingSource.List)
            {
                umperfil.Selecao = false;
            }
            gridControl1.RefreshDataSource();
            Selecao();
        }

        private void Selecao()
        {
            foreach (PerfilDTO umperfil in (List<PerfilDTO>)PerfilDTOBindingSource.List)
            {
                PerfilDTO acessos = perfilGL.GetPerfil(umperfil.Id);
                foreach (PerfilRotinaDTO umacesso in acessos.Rotinas)
                {
                    SetPerfil(treeList1.Nodes, umacesso.Id_Rotina, umperfil.Selecao);
                }
            }
        }
        private void Selecao2()
        {
            foreach (PerfilDTO umperfil in (List<PerfilDTO>)PerfilDTOBindingSource.List)
            {
                if (umperfil.Selecao)
                {
                    PerfilDTO acessos = perfilGL.GetPerfil(umperfil.Id);
                    foreach (PerfilRotinaDTO umacesso in acessos.Rotinas)
                    {
                        SetPerfil(treeList1.Nodes, umacesso.Id_Rotina, umperfil.Selecao);
                    }
                }
            }
        }

        public  void Selecao(bool checkstate)
        {
            ((PerfilDTO)PerfilDTOBindingSource.Current).Selecao = checkstate;
            PerfilDTO acessos = perfilGL.GetPerfil(((PerfilDTO)PerfilDTOBindingSource.Current).Id);
            foreach (PerfilRotinaDTO umacesso in acessos.Rotinas)
            {
                SetPerfil(treeList1.Nodes, umacesso.Id_Rotina, checkstate);
            }

            var outrosperfis = from p in (List<PerfilDTO>)PerfilDTOBindingSource.List
                               where p.Id != ((PerfilDTO)PerfilDTOBindingSource.Current).Id &&
                               p.Selecao == true
                               select p;
            if (outrosperfis.Count() > 0)
            {
                foreach (PerfilDTO umperfil in outrosperfis)
                {
                    acessos = perfilGL.GetPerfil(umperfil.Id);
                    foreach (PerfilRotinaDTO umacesso in acessos.Rotinas)
                    {
                        SetPerfil(treeList1.Nodes, umacesso.Id_Rotina, umperfil.Selecao);
                    }
                }
            }
        }

        private void SetPerfil(TreeListNodes nodes, int id_rotina, bool check)
        {
            treeList1.BeginUnboundLoad();
            foreach (TreeListNode node in nodes)
            {
                if ((int)node.GetValue(treeListColumn2) == id_rotina)
                {
                    if (!check)
                    {
                        node.Tag = null;
                        node.Checked = false;
                    }
                    else
                    {
                        node.Tag = "PERFIL";
                        node.Checked = true;
                    }
                    break;
                }

                if (node.HasChildren)
                    SetPerfil(node.Nodes, id_rotina, check);
            }

            if (!check)
            {
                foreach (TreeListNode node in nodes)
                {
                    SetCheckedParentNodes(node, node.CheckState);
                }
            }
            treeList1.EndUnboundLoad();
        }

        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Checked : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        public void SalvaAcessoAux()
        {
            if (SupervisorCheckEdit.Checked)
            {
                DesmarcaTodos();
                CheckBoxState(treeList1.Nodes, false);
            }
        }

        private void CheckBoxState(TreeListNodes nodes, bool check)
        {
            foreach (TreeListNode node in nodes)
            {
                if (node.Tag == null)
                    node.Checked = check;
                if (node.HasChildren)
                    CheckBoxState(node.Nodes, check);
            }
        }

        private void frmUpdateUsuario_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;

            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Usuário";
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Usuário";
                    btnTrocaSenha.Enabled = true;
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Usuário";
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

        private void frmUpdateUsuario_Shown(object sender, EventArgs e)
        {
            CarregaAcessos();
        }

        private void frmUpdateUsuario_FormClosed(object sender, FormClosedEventArgs e)
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
                if (this.ValidaCampos()) return;
                if (tpOperacao == Enumeradores.TipoOperacao.Insert)
                    EncryptPassword();

                Cursor = Cursors.WaitCursor;
                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        UsuarioDTO usuario = null;
                        try
                        {
                            usuario = usuarioBO.GetUsuarioByLogin(LoginTextEdit.Text);
                        }
                        catch { }
                        if (usuario != null)
                        {
                            dxErrorProvider.SetError(LoginTextEdit, "Login inválido. Já existe um usuário '" + LoginTextEdit.Text + "' cadastrado.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                            Cursor = Cursors.Default;
                            return;
                        }

                        usuarioDTO.Id = usuarioBO.Insert((UsuarioDTO)UsuarioDTOBindingSource.Current);
                        SalvaAcesso();
                        bndUsuarioGrid.Add(UsuarioDTOBindingSource.Current);

                        //
                        try
                        {
                            databasestructureBO.CreateRole(usuarioDTO.Id, usuarioDTO.Login, usuarioDTO.Login);
                        }
                        catch { }
                        if (Global.Sistema == Enumeradores.Sistema.MECHTECH)
                        {
                            if (usuarioDTO.Mechtechativo)
                                databasestructureBO.AlterRole(usuarioDTO.Login, true);
                            else
                                databasestructureBO.AlterRole(usuarioDTO.Login, false);
                        }

                        break;
                    case Enumeradores.TipoOperacao.Update:
                        if (!string.IsNullOrEmpty(newpassword))
                            usuarioDTO.Senha = newpassword;
                        if (usuarioDTO.Login != currentuser)
                            EncryptPassword();
                        usuarioBO.Update((UsuarioDTO)UsuarioDTOBindingSource.Current);
                        SalvaAcesso();
                        bndUsuarioGrid.List[bndUsuarioGrid.Position] = UsuarioDTOBindingSource.Current;

                        if (usuarioDTO.Login != currentuser)
                        {
                            databasestructureBO.DropRole(currentuser);
                            databasestructureBO.CreateRole(usuarioDTO.Id, usuarioDTO.Login, usuarioDTO.Login);
                        }
                        if (Global.Sistema == Enumeradores.Sistema.MECHTECH)
                        {
                            if (usuarioDTO.Mechtechativo)
                                databasestructureBO.AlterRole(usuarioDTO.Login, true);
                            else
                                databasestructureBO.AlterRole(usuarioDTO.Login, false);
                        }

                        break;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                "Motivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Cursor = Cursors.Default;
        }

        private void EncryptPassword()
        {
            usuarioDTO.Senha = Global.CreateHash(usuarioDTO.Login.ToUpper());
        }

        private void btnTrocaSenha_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmTrocaSenha changepassword = new frmTrocaSenha(((UsuarioDTO)bndUsuarioGrid.Current).Login);
            changepassword.Sistema = Global.Sistema;
            changepassword.ShowDialog();
            newpassword = changepassword.NewPassword;
            Cursor = Cursors.Default;
        }

        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors(); // Elimina todo os erros da janela

            if (usuarioDTO.Nome == string.Empty)
                dxErrorProvider.SetError(NomeTextEdit, "Nome inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (usuarioDTO.Login == string.Empty)
                dxErrorProvider.SetError(LoginTextEdit, "Login inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            else
            {
                string expect = "0123456789";
                if (expect.Contains(usuarioDTO.Login.Trim().Substring(0, 1)))
                    dxErrorProvider.SetError(LoginTextEdit, "Login inválido. Apenas números ou número nas iniciais não é permitido.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }

            return dxErrorProvider.HasErrors;
        }

        private void MarcaButton_Click(object sender, EventArgs e)
        {
            MarcaTodos();
        }

        private void DesmarcaButton_Click(object sender, EventArgs e)
        {
            DesmarcaTodos();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            CheckBoxState(treeList1.Nodes, true);
        }

        private void UncheckButton_Click(object sender, EventArgs e)
        {
            CheckBoxState(treeList1.Nodes, false);
        }

        private void repositoryItemCheckEditSelecao_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit currentrow = (CheckEdit)sender;
            Selecao(currentrow.Checked);
        }

        bool unaccess = false;

        private void treeList1_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Viewer)
            {
                if (e.PrevState == CheckState.Checked)
                    e.State = CheckState.Checked;
                else
                    e.State = CheckState.Unchecked;
                return;
            }

            if (e.Node.Tag != null)
            {
                unaccess = true;
                e.State = CheckState.Checked;
            }
            else
                e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        private void treeList1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Viewer)
                return;

            if (!unaccess)
            {
                SetCheckedChildNodes(e.Node, e.Node.CheckState);
                SetCheckedParentNodes(e.Node, e.Node.CheckState);
            }
            unaccess = false;
        }

        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        private void treeList1_CustomDrawNodeCheckBox(object sender, DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                if (e.Node.Checked)
                    e.ObjectArgs.State = DevExpress.Utils.Drawing.ObjectState.Disabled;
                else
                    e.ObjectArgs.State = DevExpress.Utils.Drawing.ObjectState.Normal;
            }
            else
                e.ObjectArgs.State = DevExpress.Utils.Drawing.ObjectState.Normal;
        }

        private void treeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                if (e.Node.Checked)
                    e.Appearance.ForeColor = Color.FromArgb(77, 8, 141);
                else
                    e.Appearance.ForeColor = Color.Empty;
            }
            else
                e.Appearance.ForeColor = Color.Empty;
        }

        private void SupervisorCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (SupervisorCheckEdit.Checked)
                groupControl2.Enabled = false;
            else
                groupControl2.Enabled = true;
        }
    }

}