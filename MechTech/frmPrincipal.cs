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
using System.IO;

#region DEVEXPRESS
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
#endregion

#region MECHTECH
using MechTech.Util;
using MechTech.UI.Cadastros;
using MechTech.UI.Vendas;
using MechTech.Entities;
using MechTech.Util.Templates;
using MechTech.UI.Utilitarios;
using MechTech.Gateway;
using MechTech.Util.Forms;

#endregion

namespace MechTech
{
    public partial class frmPrincipal : frmBaseRibbon
    {
        enum OpenForm
        {
            Splash,
            Main
        }

        bool selecionaempresa = false;
        bool empresainexistente = false;
        bool empresanaoliberada = false;

        private bool ativaempresa = false;
        public bool Ativaempresa
        {
            get { return ativaempresa; }
            set { ativaempresa = value; }
        }

        EmpresaDTO empresa = null;
        MechTechAtivaGL mechtechativaGL = new MechTechAtivaGL();
        MechTechEmpresaGL mechtechempresaGL = new MechTechEmpresaGL();
        public frmPrincipal()
        {
            Application.DoEvents();
            InitializeComponent();
            Application.DoEvents();
            ConfiguracaoPessoal();
            Application.DoEvents();
            MontaMenuModulo("01", treeListCadastros);
            MontaMenuModulo("02", treeListVendas);
            MontaMenuModulo("03", treeListRelatorios);
            Acesso();
        }

        private void Acesso()
        {

            MechTech.UI.Utilitarios.frmLogin frmlogin = new MechTech.UI.Utilitarios.frmLogin();
            frmlogin.ShowDialog();
            Perfil();
        }

        public void MontaMenuModulo(string modulo, TreeList treeList)
        {
            try
            {
                treeList.BeginUnboundLoad();
                treeList.ClearNodes();

                TreeListNode[] nivel = new TreeListNode[8];
                TreeListNode node;

                RotinaGL rotinaGL = new RotinaGL();
                List<RotinaDTO> rotinas = rotinaGL.GetRotinaModulo(modulo);

                foreach (RotinaDTO rotina in rotinas)
                {
                    if (!rotina.Menu)
                        continue;

                    if (rotina.Classe.Equals("frmSobre"))
                        continue;

                    if (rotina.Nivel.Length == 2)
                        continue;

                    node = nivel[0];
                    switch (rotina.Nivel.Length - 2)
                    {
                        case 2:
                            nivel[0] = treeList.AppendNode(new object[] { rotina.Descricao }, null);
                            node = nivel[0];
                            break;
                        case 4:
                            nivel[1] = treeList.AppendNode(new object[] { rotina.Descricao }, nivel[0]);
                            node = nivel[1];
                            break;
                        case 6:
                            nivel[2] = treeList.AppendNode(new object[] { rotina.Descricao }, nivel[1]);
                            node = nivel[2];
                            break;
                        case 8:
                            nivel[3] = treeList.AppendNode(new object[] { rotina.Descricao }, nivel[2]);
                            node = nivel[3];
                            break;
                        case 10:
                            nivel[4] = treeList.AppendNode(new object[] { rotina.Descricao }, nivel[3]);
                            node = nivel[4];
                            break;
                        case 12:
                            nivel[5] = treeList.AppendNode(new object[] { rotina.Descricao }, nivel[4]);
                            node = nivel[5];
                            break;
                        case 14:
                            nivel[6] = treeList.AppendNode(new object[] { rotina.Descricao }, nivel[5]);
                            node = nivel[6];
                            break;
                        case 16:
                            nivel[7] = treeList.AppendNode(new object[] { rotina.Descricao }, nivel[6]);
                            node = nivel[7];
                            break;
                        case 18:
                            nivel[8] = treeList.AppendNode(new object[] { rotina.Descricao }, nivel[7]);
                            node = nivel[8];
                            break;
                        default:
                            MessageBox.Show("Nível não suportado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    if (rotina.Indiceimagem > 0)
                        node.StateImageIndex = rotina.Indiceimagem;
                    node.Tag = rotina;
                }

                treeList.EndUnboundLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                "Motivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void treeListCadastros_Click(object sender, EventArgs e)
        {
            treeListClick(sender, e);
        }

        private void treeListClick(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;
            if (mouse.Button == MouseButtons.Right)
                return;

            TreeList treelist = (TreeList)sender;
            TreeListNode currentnode = treelist.FocusedNode;

            if (currentnode.Tag == null)
                return;

            RotinaDTO no = (RotinaDTO)currentnode.Tag;

            Cursor = Cursors.WaitCursor;
            this.ExecutarRotina(no);
            Cursor = Cursors.Default;
        }

        private void ExecutarRotina(RotinaDTO rotina)
        {
            string metodo = rotina.Metodo;

            try
            {
                if (rotina.Metodo.Equals(""))
                    return;

                // Não é possível chamar métodos da classe frmPrincipal
                if (rotina.Assembler.Equals("MechTech.UI") || rotina.Classe.Equals("frmPrincipal"))
                {
                    if (rotina.Metodo.Equals("Close"))
                        this.Close();
                }

                //VERIFICA PERMISSÕES DE ACESSO
                //if (!ValidaAcesso(rotina.Id))
                //    return;

                //NÃO PERMITE ABRIR AVISOS ENQUANTO NÃO HOUVER EMPRESA ATIVA
                //if (rotina.Classe.Equals("frmAvisos"))
                //{
                //    if (File.Exists(Global.LocalPath + @"\Sistemas\MECHTECH\appConfig.xml")) //EXISTE EMPRESA ATIVA.
                //        VerificaAvisos();
                //    else
                //    {
                //        MessageBox.Show("Para visualizar os avisos é necessário selecionar uma empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //        return;
                //    }
                //}

                ////EXECUÇÃO DE MÓDULOS EXTERNOS
                //if (rotina.Classe.Equals("Modulos.exe"))
                //{
                //    Modulos();
                //    return;
                //}

                ////VERIFICA ACESSO (ÍTENS DA TREEVIEW)
                //if (rotina.Ativaempresa)
                //{
                //    if (Ativaempresa)
                //    {
                //        MessageBox.Show("Opção indisponível no momento. É necessário a seleção de uma empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}

                ////VERIFICA USUÁRIO MECHTECH PARA ACESSAR ROTINA DE MODULOS E PROGRAMAS
                //if (rotina.Metodo.Equals("ShowMP"))
                //{
                //    if (Global.UsuarioAtivo.ToString().ToUpper() != "MECHTECH")
                //    {
                //        MessageBox.Show("Acesso permitido somente para funcionários MECHTECH.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //        return;
                //    }

                //    foreach (Form umform in Application.OpenForms)
                //    {
                //        if (umform.Text.Equals("Módulos e Programas"))
                //            return;
                //    }
                //}

                Assembly assembly = Assembly.Load(rotina.Assembler);
                Type classe = assembly.GetType(rotina.Assembler + "." + rotina.Classe);
                Object instancia;
                if (!rotina.Classe.Equals("frmLogin") &&
                    !rotina.Classe.Equals("frmSelecionaEmpresa") &&
                    !rotina.Classe.Equals("FinalMes")) //VERIFICAÇÃO NECESSÁRIA PARA QUE O FORM DE LOGIN/ SELEÇÃO DE EMPRESA/ FINAL DE MÊS TENHA AUTONOMIA PARA INVOCAR MÉTODOS DO FORM PRINCIPAL.
                {
                    //ACESSO RESTRITO AO SUPERVISOR
                    if (rotina.Classe.Equals("frmParametros") ||
                        rotina.Classe.Equals("frmImportacaoDados") ||
                        rotina.Classe.Equals("Forms.frmLog"))
                    {
                        if (!MechTech.Util.Global.Supervisor)
                        {
                            MessageBox.Show("Acesso restrito somente a usuários com permissão de Supervisor.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    /*REUTILIZAR FORMULÁRIOS ABERTOS*/
                    string classname = rotina.Classe;
                    if (classname.Contains("Forms."))
                        classname = classname.Replace("Forms.", string.Empty);
                    try
                    {
                        bool isopened = false;
                        if (rotina.Metodo.Equals("ShowH"))
                        {
                            foreach (Form umformopened in Application.OpenForms)
                            {
                                if (umformopened.Text.Equals("Digitação de Holerith"))
                                {
                                    if (umformopened.Enabled)
                                        umformopened.BringToFront();
                                    else
                                        MessageBox.Show("Já existe uma tela de " + umformopened.Text + " em uso por outro processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    isopened = true;
                                    break;
                                }
                            }
                        }
                        else if (rotina.Metodo.Equals("ShowF"))
                        {
                            foreach (Form umformopened in Application.OpenForms)
                            {
                                if (umformopened.Text.Equals("Férias Individualizada"))
                                {
                                    if (umformopened.Enabled)
                                        umformopened.BringToFront();
                                    else
                                        MessageBox.Show("Já existe uma tela de " + umformopened.Text + " em uso por outro processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    isopened = true;
                                    break;
                                }
                            }
                        }
                        else if (rotina.Metodo.Equals("ShowR"))
                        {
                            foreach (Form umformopened in Application.OpenForms)
                            {
                                if (umformopened.Text.Equals("Rescisão Individualizada"))
                                {
                                    if (umformopened.Enabled)
                                        umformopened.BringToFront();
                                    else
                                        MessageBox.Show("Já existe uma tela de " + umformopened.Text + " em uso por outro processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    isopened = true;
                                    break;
                                }
                            }
                        }
                        else if (rotina.Metodo.Equals("ShowMP"))
                        {
                            foreach (Form umformopened in Application.OpenForms)
                            {
                                if (umformopened.Text.Equals("Módulos e Programas"))
                                {
                                    if (umformopened.Enabled)
                                        umformopened.BringToFront();
                                    else
                                        MessageBox.Show("Já existe uma tela de " + umformopened.Text + " em uso por outro processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    isopened = true;
                                    break;
                                }
                            }
                        }
                        else if (rotina.Metodo.Equals("ShowCM"))
                        {
                            foreach (Form umformopened in Application.OpenForms)
                            {
                                if (umformopened.Text.Equals("Circulares MECHTECH"))
                                {
                                    if (umformopened.Enabled)
                                        umformopened.BringToFront();
                                    else
                                        MessageBox.Show("Já existe uma tela de " + umformopened.Text + " em uso por outro processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    isopened = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Form formopened = Application.OpenForms[classname];

                            if (formopened.Enabled)
                            {
                                formopened.BringToFront();
                                isopened = true;
                            }
                            else
                            {
                                MessageBox.Show("Já existe uma tela de " + formopened.Text + " em uso por outro processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                isopened = true;
                            }
                        }
                        if (isopened)
                            return;
                    }
                    catch { }
                    /**/

                    instancia = classe.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);
                }
                else
                    instancia = classe.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { this });
                if (rotina.Metodo.Equals("Show"))
                    classe.InvokeMember("MdiParent", BindingFlags.SetProperty, null, instancia, new object[] { this });
                classe.InvokeMember(rotina.Metodo, BindingFlags.InvokeMethod, null, instancia, null);
                rotina.Metodo = metodo;

                //CARREGAR EMPRESA ATIVA
                //if (rotina.Classe.Equals("frmSelecionaEmpresa"))
                //{
                //    if (DialogResult != DialogResult.Cancel)
                //    {
                //        if (File.Exists(Global.LocalPath + @"\Sistemas\MECHTECH\appConfig.xml")) //EXISTE EMPRESA ATIVA.
                //        {
                //            empresa = new EmpresaDTO().Deserializar();
                //            VerificaAvisos();
                //            dialogResult = DialogResult.Cancel;
                //        }
                //    }
                //}
            }
            catch
            {
                //if (rotina.Metodo.Equals("Start"))
                //    SuporteASSIST();

                //if (rotina.Metodo.Equals("Open"))
                //    SuporteConnect();
            }
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                Application.Exit();
            else
                return;
        }
        public bool FormOpened(string formname, MechTech.Util.Enumeradores.Modulo modulo)
        {
            try
            {
                bool isopened = false;
                if (modulo == MechTech.Util.Enumeradores.Modulo.Holerith)
                {
                    foreach (Form umformopened in Application.OpenForms)
                    {
                        if (umformopened.Text.Equals("Digitação de Holerith"))
                        {
                            if (umformopened.Enabled)
                                umformopened.BringToFront();
                            else
                                MessageBox.Show("Já existe uma tela de " + umformopened.Text + " em uso por outro processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            isopened = true;
                            break;
                        }
                    }
                }
                else if (modulo == MechTech.Util.Enumeradores.Modulo.Ferias)
                {
                    foreach (Form umformopened in Application.OpenForms)
                    {
                        if (umformopened.Text.Equals("Férias Individualizada"))
                        {
                            if (umformopened.Enabled)
                                umformopened.BringToFront();
                            else
                                MessageBox.Show("Já existe uma tela de " + umformopened.Text + " em uso por outro processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            isopened = true;
                            break;
                        }
                    }
                }
                else if (modulo == MechTech.Util.Enumeradores.Modulo.Rescisao)
                {
                    foreach (Form umformopened in Application.OpenForms)
                    {
                        if (umformopened.Text.Equals("Rescisão Individualizada"))
                        {
                            if (umformopened.Enabled)
                                umformopened.BringToFront();
                            else
                                MessageBox.Show("Já existe uma tela de " + umformopened.Text + " em uso por outro processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            isopened = true;
                            break;
                        }
                    }
                }
                else
                {
                    Form formopened = Application.OpenForms[formname];
                    if (formopened.Enabled)
                    {
                        formopened.BringToFront();
                        isopened = true;
                    }
                    else
                    {
                        MessageBox.Show("Já existe uma tela de " + formopened.Text + " em uso por outro processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isopened = true;
                    }
                }
                if (isopened)
                    return true;
            }
            catch { return false; }

            return false;
        }

        private void barButtonItemCadEmpresa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FormOpened("frmGridEmpresa", MechTech.Util.Enumeradores.Modulo.Nenhum))
                return;

            Cursor = Cursors.WaitCursor;
            frmGridEmpresa frm = new frmGridEmpresa();
            frm.MdiParent = this;
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void barButtonItemSelecao_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (new frmSelecionaEmpresa(this).ShowDialog() != DialogResult.Cancel)
            {
                if (File.Exists(Global.LocalPath + @"\Sistemas\MechTech\appConfig.xml")) //EXISTE EMPRESA ATIVA.
                {
                    empresa = new EmpresaDTO().Deserializar();
                    dialogResult = DialogResult.Cancel;
                }
            }
            Cursor = Cursors.Default;
        }

        private DialogResult dialogResult = DialogResult.Cancel;
        public DialogResult DialogResult
        {
            get
            {
                return dialogResult;
            }
            set
            {
                dialogResult = value;
            }
        }

        DatabaseStructureGL databasestructureGL = new DatabaseStructureGL();
        EstruturaTabelaGL estruturatabelaGL = new EstruturaTabelaGL();
        EstruturaObjetoGL estruturaobjetoGL = new EstruturaObjetoGL();
        EstruturaFuncaoGL estruturafuncaoGL = new EstruturaFuncaoGL();
        FilialGL filialGL = new FilialGL();

        private void xtraTabbedMdiManager_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            if (xtraTabbedMdiManager.Pages.Count > 0)
                pictureBoxBackground.Visible = false;
        }

        private void xtraTabbedMdiManager_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            if (xtraTabbedMdiManager.Pages.Count <= 0)
                pictureBoxBackground.Visible = true;
        }

        private void pgSqlMonitor_TraceEvent(object sender, Devart.Common.MonitorEventArgs e)
        {
            if (e.TracePoint == Devart.Common.MonitorTracePoint.AfterEvent)
                return;

            if (Global.DbMonitor)
            {
                string logpath = Global.LocalPath + @"\Sistemas\MechTech\Postgres\LOG";
                if (!Directory.Exists(logpath))
                    Directory.CreateDirectory(logpath);

                StreamWriter logfile = new StreamWriter(logpath + "\\" + DateTime.Today.ToString("yyyy_MM_dd") + ".log", true);
                logfile.WriteLine(DateTime.Today.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("HH:mm:ss") + " | " + e.Description);
                logfile.Close();
            }
        }

        #region CONFIGURAÇÕES EMPRESA
        /// <summary>
        /// Responsável por garantir a inicialização e personalização correta do Sistema.
        /// </summary>
        /// 

        private bool VerificarEmpresa()
        {
            empresa = new EmpresaDTO().Deserializar();
            try
            {
                DateTime mesanoativo = empresa.Mesano;
                empresa = new EmpresaGL().GetEmpresa(empresa.Id);
                empresa.Mesano = mesanoativo;

                if (empresa.DataTrava.HasValue)
                {
                    MechTech.Util.Global.DataTrava = empresa.DataTrava;
                    if (empresa.Mesano <= empresa.DataTrava.Value)
                        return false;
                }

                CarregaConfiguracoes(empresa);
            }
            catch
            {
                if (empresa.Id == 0)
                    throw;

                return false;
            }

            return true;
        }
        private void ConfiguracaoPessoal()
        {
            try
            {
                if (new EmpresaGL().GetGridEmpresa("id", string.Empty).Count <= 0)
                {
                    Ativaempresa = true;
                    try
                    {
                        VerificarEmpresa();
                    }
                    catch { }
                    base.Refresh();
                }
                else
                {
                    if (!File.Exists(Global.LocalPath + @"\Sistemas\MechTech\appConfig.xml")) //NÃO EXISTE EMPRESA ATIVA.
                    {
                        Ativaempresa = true;
                        selecionaempresa = true;
                    }
                    else
                    {
                        if (!VerificarEmpresa())
                        {
                            Ativaempresa = true;
                            empresainexistente = true;
                            selecionaempresa = true;
                        }
                    }
                }
            }
            catch
            {
                Ativaempresa = true;
                selecionaempresa = true;
            }
        }
        public void CarregaConfiguracoes(EmpresaDTO obj)
        {
            Global.EmpresaAtiva = "emp" + Global.CompletarZerosEsquerda(obj.Id, 4);
            Global.MesanoAtivo = obj.Mesano;

            barStaticItemEmpresa.Caption = "Empresa: " + obj.Id.ToString() + " - " + obj.Nomefantasia;
            barStaticItemMesano.Caption = "Mês/Ano: " + Global.CompletarZerosEsquerda(obj.Mesano.Month, 2) + "/" + obj.Mesano.Year.ToString();

            DataBaseStructure();
        }
        #endregion

        private void treeKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cursor = Cursors.WaitCursor;
                this.ExecutarRotina((RotinaDTO)((TreeList)sender).FocusedNode.Tag);
                Cursor = Cursors.Default;
            }
        }

        private void treeListCadastros_KeyDown(object sender, KeyEventArgs e)
        {
            treeKeyDown(sender, e);
        }

        #region TREELIST HOT TRACKING
        private TreeList treelistactivated = null;
        private TreeListNode hotTrackNode = null;
        private TreeListNode HotTrackNode
        {
            get
            {
                return hotTrackNode;
            }
            set
            {
                if (hotTrackNode != value)
                {
                    TreeListNode prevHotTrackNode = hotTrackNode;
                    hotTrackNode = value;
                    treelistactivated.InvalidateNode(prevHotTrackNode);
                    treelistactivated.InvalidateNode(HotTrackNode);
                }
            }
        }

        private void treeListCadastros_MouseLeave(object sender, EventArgs e)
        {
            HotTrackNode = null;
        }
     
        private void treeListRelatorios_MouseLeave(object sender, EventArgs e)
        {
            HotTrackNode = null;
        }
       
        private void treeListCadastros_MouseMove(object sender, MouseEventArgs e)
        {
            treeListMouseMove(sender, e);
        }
      
        private void treeListRelatorios_MouseMove(object sender, MouseEventArgs e)
        {
            treeListMouseMove(sender, e);
        }
        

        private void treeListMouseMove(object sender, MouseEventArgs e)
        {
            TreeListHitInfo HitInfo = ((TreeList)sender).CalcHitInfo(e.Location);
            treelistactivated = (TreeList)sender;
            HotTrackNode = HitInfo.Node;
            if (HotTrackNode != null)
            {
                if (HotTrackNode.HasChildren)
                    treelistactivated.FocusedNode = HotTrackNode;
            }
        }

        private void treeListCadastros_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            treeListNodeCellStyle(sender, e);
        }

        private void treeListNodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node == HotTrackNode)
            {
                if (Global.Skin == "Black" ||
                    Global.Skin == "Blue" ||
                    Global.Skin == "Office 2007 Green")
                {
                    e.Appearance.ForeColor = Color.White;
                    e.Appearance.BackColor = Color.FromArgb(122, 150, 223);
                }
                else if (Global.Skin == "Foggy")
                {
                    e.Appearance.ForeColor = Color.FromArgb(42, 44, 54);
                    e.Appearance.BackColor = Color.FromArgb(234, 235, 241);
                }
                else if (Global.Skin == "Seven")
                {
                    e.Appearance.ForeColor = Color.Black;
                    e.Appearance.BackColor = Color.FromArgb(235, 235, 235);
                }
                else if (Global.Skin == "Darkroom")
                {
                    e.Appearance.ForeColor = Color.FromArgb(220, 220, 220);
                    e.Appearance.BackColor = Color.FromArgb(80, 80, 80);
                }
            }
        }
        #endregion

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[versao]", Global.VersaoSistema);

            if (Global.VerificarResolucaoVideo())
                MessageBox.Show("A resolução de vídeo atual é compatível com o Sistema" +
                                " no entanto, para uma melhor visualização, recomenda-se" +
                                " utilizar 1024x768 ou superior.", "Aviso importante", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (selecionaempresa)
            {
                if (empresanaoliberada)
                    MessageBox.Show("A empresa selecionada não está acessível para uso devido sua licença de funcionamento não estar liberada." +
                                    " Para demais esclarecimentos, entre em contato com nosso suporte técnico.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (empresainexistente)
                        MessageBox.Show("A empresa selecionada não está acessível. Para solucionar esse problema, selecione-a novamente ou escolha outra empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Cursor = Cursors.WaitCursor;
                if (new frmSelecionaEmpresa().ShowDialog() == DialogResult.OK) //APLICA CONFIGURAÇÕES
                {
                    frmWait wait = new frmWait("Lendo as novas configurações...");
                    wait.Show();
                    Application.DoEvents();

                    Ativaempresa = false;

                    //Atalhos();

                    MontaMenuModulo("01", treeListCadastros);
                    MontaMenuModulo("02", treeListVendas);
                    MontaMenuModulo("03", treeListRelatorios);
                    //MontaMenuModulo("04", treeListImpressos);
                    //MontaMenuModulo("05", treeListDocumentos);
                    //MontaMenuModulo("06", treeListIntegracoes);
                    //MontaMenuModulo("07", treeListUtilitarios);
                    //MontaMenuModulo("08", treeListAjuda);

                    empresa = new EmpresaDTO().Deserializar();
                    CarregaConfiguracoes(empresa);
                    dialogResult = DialogResult.Cancel;

                    wait.Close();
                }
                Cursor = Cursors.Default;
            }
        }

        private void barButtonItemCadUsuario_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FormOpened("frmGridUsuario", MechTech.Util.Enumeradores.Modulo.Nenhum))
                return;

            Cursor = Cursors.WaitCursor;
            MechTech.UI.Utilitarios.frmGridUsuario frm = new MechTech.UI.Utilitarios.frmGridUsuario();
            frm.MdiParent = this;
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void barButtonItemSenha_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            new MechTech.UI.Utilitarios.frmTrocaSenha().ShowDialog();
            Cursor = Cursors.Default;
        }

        private void barButtonItemAlterarUsu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            new MechTech.UI.Utilitarios.frmLogin(this).ShowDialog();
            Cursor = Cursors.Default;
        }

        public void Perfil()
        {
            try
            {
                Global.Acessos = new RotinaGL().GetAcessos();
            }
            catch { }
            barStaticItemUsuario.Caption = "Usuário: " + Global.UsuarioAtivo;
        }

        private void barButtonItemCopia_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FormOpened("frmBackup", MechTech.Util.Enumeradores.Modulo.Nenhum))
                return;

            Cursor = Cursors.WaitCursor;
            frmBackup frm = new frmBackup();
            frm.MdiParent = this;
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void barButtonItemAtivacao_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItemCopiaSeguranca_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FormOpened("frmBackup", MechTech.Util.Enumeradores.Modulo.Nenhum))
                return;

            Cursor = Cursors.WaitCursor;
            frmBackup frm = new frmBackup();
            frm.MdiParent = this;
            frm.Show();
            Cursor = Cursors.Default;
        }

        #region ESTRUTURA DO BANCO DE DADOS
        /// <summary>
        /// Responsável por efetuar toda validação a nível de estrutura do Banco de dados.
        /// </summary>
        private void DataBaseStructure()
        {
            OpenForm form = OpenForm.Splash;

            frmWait wait = new frmWait();
            // frmSplashScreen waitSplash = new frmSplashScreen();

            //if (Application.OpenForms.Count == 1)
            //    Splash.Status = "Verificando a estrutura do Banco de dados...";
            //else
            //{

            if (Global.Id_UsuarioAtivo > 0) //42350
                form = OpenForm.Main;


            if (form == OpenForm.Splash)
                Splash.Status = "Verificando a estrutura do Banco de dados...";
            else
                wait.NewMessage = "Verificando a estrutura do Banco de dados...";
            wait.Show();
            Application.DoEvents();
            //}

            //ESTRUTURA BASE
            List<EstruturaTabelaDTO> tablesbase = new List<EstruturaTabelaDTO>();
            List<EstruturaObjetoDTO> objectsbase = new List<EstruturaObjetoDTO>();
            List<EstruturaFuncaoDTO> functionsbase = new List<EstruturaFuncaoDTO>();
            try
            {
                tablesbase = estruturatabelaGL.GetListAll();
                objectsbase = estruturaobjetoGL.GetListAll();
                functionsbase = estruturafuncaoGL.GetListAll();
            }
            catch
            {
                if (form == OpenForm.Splash)
                    Splash.Close();
                MessageBox.Show("Ocorreu uma falha geral a nível de estrutura do Banco de dados. Verifique junto ao suporte técnico as possíveis causas para solução do problema.", "Falha catastrófica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(Environment.ExitCode);
            }
            //

            //INÍCIO
            try
            {
                DatabaseStructureDTO databasestructure = null;
                try
                {
                    databasestructure = databasestructureGL.GetSchema(Global.EmpresaAtiva);
                }
                catch { }
                if (databasestructure == null) //SEM SCHEMA
                {
                    //ESTRUTURA
                    if (form == OpenForm.Splash)
                        Splash.Status = "Criando a estrutura " + Global.EmpresaAtiva;
                    else
                    {
                        wait.NewMessage = "Criando a estrutura " + Global.EmpresaAtiva;
                        Application.DoEvents();
                    }
                    databasestructureGL.CreateSchema(Global.EmpresaAtiva);

                    //TABELAS/OBJETOS
                    if (form == OpenForm.Splash)
                        Splash.Status = "Criando as tabelas e objetos para " + Global.EmpresaAtiva;
                    else
                    {
                        wait.NewMessage = "Criando as tabelas e objetos para " + Global.EmpresaAtiva;
                        Application.DoEvents();
                    }
                    estruturatabelaGL.Create();

                    //FUNÇÕES
                    if (form == OpenForm.Splash)
                        Splash.Status = "Criando os procedimentos para " + Global.EmpresaAtiva;
                    else
                    {
                        wait.NewMessage = "Criando os procedimentos para " + Global.EmpresaAtiva;
                        Application.DoEvents();
                    }
                    estruturafuncaoGL.Create();
                }
                else //COM SCHEMA
                {
                    //TABELAS
                    List<DatabaseStructureDTO> tables = databasestructureGL.GetTables(Global.EmpresaAtiva);
                    if (tables.Count != tablesbase.Count)
                    {
                        List<EstruturaTabelaDTO> tablecreate = new List<EstruturaTabelaDTO>();
                        foreach (EstruturaTabelaDTO estruturabase in tablesbase)
                        {
                            DatabaseStructureDTO estrutura = tables.Find(delegate(DatabaseStructureDTO item) { return item.Name.Equals(estruturabase.Nometabela); });
                            if (estrutura == null)
                                tablecreate.Add(estruturabase);
                        }
                        if (tablecreate.Count > 0)
                        {
                            if (form == OpenForm.Splash)
                                Splash.Status = "Criando as tabelas e objetos para " + Global.EmpresaAtiva;
                            else
                            {
                                wait.NewMessage = "Criando as tabelas e objetos para " + Global.EmpresaAtiva;
                                Application.DoEvents();
                            }
                            estruturatabelaGL.Create(tablecreate);
                        }
                    }

                    //OBJETOS
                    List<DatabaseStructureDTO> objects = databasestructureGL.GetObjects(Global.EmpresaAtiva);
                    if (objects.Count != objectsbase.Count)
                    {
                        List<EstruturaObjetoDTO> objectcreate = new List<EstruturaObjetoDTO>();
                        foreach (EstruturaObjetoDTO estruturabase in objectsbase)
                        {
                            DatabaseStructureDTO estrutura = objects.Find(delegate(DatabaseStructureDTO item) { return item.Name.Equals(estruturabase.Nomeobjeto); });
                            if (estrutura == null)
                                objectcreate.Add(estruturabase);
                        }
                        if (objectcreate.Count > 0)
                        {
                            if (form == OpenForm.Splash)
                                Splash.Status = "Criando os objetos para " + Global.EmpresaAtiva;
                            else
                            {
                                wait.NewMessage = "Criando os objetos para " + Global.EmpresaAtiva;
                                Application.DoEvents();
                            }
                            estruturaobjetoGL.Create(objectcreate);
                        }
                    }

                    //FUNÇÕES
                    List<DatabaseStructureDTO> functions = databasestructureGL.GetProcs(Global.EmpresaAtiva);
                    if (functions.Count != functionsbase.Count)
                    {
                        List<EstruturaFuncaoDTO> functioncreate = new List<EstruturaFuncaoDTO>();
                        foreach (EstruturaFuncaoDTO estruturabase in functionsbase)
                        {
                            DatabaseStructureDTO estrutura = functions.Find(delegate(DatabaseStructureDTO item) { return item.Name.Equals(estruturabase.Nomefuncao); });
                            if (estrutura == null)
                                functioncreate.Add(estruturabase);
                        }
                        if (functioncreate.Count > 0)
                        {
                            if (form == OpenForm.Splash)
                                Splash.Status = "Criando os procedimentos para " + Global.EmpresaAtiva;
                            else
                            {
                                wait.NewMessage = "Criando os procedimentos para " + Global.EmpresaAtiva;
                                Application.DoEvents();
                            }
                            estruturafuncaoGL.Create(functioncreate);
                        }
                    }
                }
            }
            catch
            {
                if (form == OpenForm.Splash)
                    Splash.Close();
                MessageBox.Show("Ocorreu uma falha geral a nível de estrutura do Banco de dados. Verifique junto ao suporte técnico as possíveis causas para solução do problema.", "Falha catastrófica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            wait.Close();
        }
        #endregion

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUpdateOrcamento frm = new frmUpdateOrcamento();
            frm.Show();
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmUpdateOrcamento frm = new frmUpdateOrcamento();
            frm.Show();
        }

        private void treeListVendas_Click(object sender, EventArgs e)
        {
            treeListClick(sender, e);
        }

        private void treeListVendas_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            treeListNodeCellStyle(sender, e);
        }

        private void treeListVendas_KeyDown(object sender, KeyEventArgs e)
        {
            treeKeyDown(sender, e);
        }

        private void treeListRelatorios_Click(object sender, EventArgs e)
        {
            treeListClick(sender, e);
        }

        private void treeListRelatorios_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            treeListNodeCellStyle(sender, e);
        }

        private void treeListRelatorios_KeyDown(object sender, KeyEventArgs e)
        {
            treeKeyDown(sender, e);
        }

        private void treeListVendas_MouseMove(object sender, MouseEventArgs e)
        {
            treeListMouseMove(sender, e);
        }

        private void treeListVendas_MouseLeave(object sender, EventArgs e)
        {
            HotTrackNode = null;
        }
    }
}