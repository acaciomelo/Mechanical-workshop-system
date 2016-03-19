using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

#region DEVEXPRESS
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
#endregion

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Templates;
using MechTech.Entities;
using MechTech.Gateway;
using MechTech.Util.Forms;
#endregion

namespace MechTech.UI.Utilitarios
{
    public partial class frmSelecionaEmpresa : frmBase
    {
        private XtraForm parent = null;

        FilialGL filialGL = new FilialGL();
        MechTechAtivaGL mechtechativaGL = new MechTechAtivaGL();
        MechTechEmpresaGL mechtechempresaGL = new MechTechEmpresaGL();
        Acesso acesso = new Acesso();

        public frmSelecionaEmpresa()
        {
            InitializeComponent();

            Init();
        }

        public frmSelecionaEmpresa(XtraForm principal)
        {
            InitializeComponent();

            parent = principal;
            Init();
        }

        private void Init()
        {
            try
            {
                EmpresaDTOBindingSource.DataSource = new EmpresaGL().GetGridEmpresa("id", string.Empty);
                MesesBindingSource.DataSource = Global.ObterMeses();
            }
            catch
            {
                throw;
            }
        }

        private void frmSelecionaEmpresa_Load(object sender, EventArgs e)
        {
            if (EmpresaDTOBindingSource.List.Count <= 0)
            {
                MessageBox.Show("O Sistema detectou que não existe empresas cadastradas. Impossível prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
            else
            {
                //VALIDAR FORMULÁRIOS EM USO
                frmMessageBox message = new frmMessageBox();
                foreach (Form umform in Application.OpenForms)
                {
                    if (!umform.Name.Equals(Global.MainForm) &&
                        !umform.Name.Equals("frmSelecionaEmpresa") &&
                        !umform.Name.Trim().Equals(string.Empty) &&
                        !umform.Text.Trim().Equals(string.Empty))
                        message.lstMessage.Items.Add(umform.Text);
                }

                if (message.lstMessage.Items.Count > 0)
                {
                    message.ShowDialog();
                    Close();
                }

                Deserializar();
            }

            acesso.Add(1028, btnSelecionar, Enumeradores.TipoAcao.Desabilitar);
            acesso.Validate();
        }

        private void GravaLOG()
        {
            StringBuilder entry = new StringBuilder();
            entry.AppendLine("Seleção de Empresa");
            entry.AppendLine("[Empresa: " + empresaLookUpEdit.Text + "]");
            entry.AppendLine("[Mês: " + meslookUpEdit.Text + "]");
            entry.Append("[Ano: " + anospinEdit.Text + "]");
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSelecionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Selecionar();
        }

        private void Selecionar()
        {
            if (Trava())
                return;
            if (!Acesso())
                return;

            Serializar();

            DialogResult = DialogResult.OK;
            GravaLOG();
            Close();
        }

        /// <summary>
        /// Validar trava de segurança.
        /// </summary>
        private bool Trava()
        {
            EmpresaDTO empresa = (EmpresaDTO)EmpresaDTOBindingSource.Current;
            if (empresa.DataTrava.HasValue)
            {
                MechTech.Util.Global.DataTrava = empresa.DataTrava;
                DateTime mesanoselecionado = new DateTime(Convert.ToInt32(anospinEdit.EditValue), Convert.ToInt32(meslookUpEdit.EditValue), 1);
                if (mesanoselecionado <= empresa.DataTrava.Value)
                {
                    MessageBox.Show("A empresa não pode ser ativada para uso em meses anteriores ou igual a " + empresa.DataTrava.Value.ToString("MM/yyyy") + "." +
                                    " Para demais esclarecimentos, entre em contato com nosso suporte técnico.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Validar licença de funcionamento.
        /// </summary>
        /// <returns>Verdadeiro caso empresa esteja liberada para funcionamento</returns>
        private bool Acesso()
        {
            frmWait wait = new frmWait("Verificando licença de funcionamento...");
            wait.Show();
            Application.DoEvents();

            try
            {
                List<FilialDTO> filiais = filialGL.GetGridFilial("filial", string.Empty);
                MechTechAtivaDTO ativacao = null;
                try
                {
                    ativacao = mechtechativaGL.GetMechTechAtivaByFilial(filiais[0].Filial);
                }
                catch { }
                if (ativacao != null)
                {
                    List<MechTechEmpresaDTO> empresasliberadas = mechtechempresaGL.GetMechTechEmpresaByID_MechTechAtiva(ativacao.Id);
                    if (empresasliberadas.Count <= 0)
                    {
                        MessageBox.Show("A empresa não pode ser ativada para uso devido sua licença de funcionamento não estar liberada." +
                                        " Para demais esclarecimentos, entre em contato com nosso suporte técnico.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        wait.Close();
                        return false;
                    }

                    MechTechEmpresaDTO empresaliberada = empresasliberadas.Find(delegate(MechTechEmpresaDTO item) { return item.CNPJ == ((EmpresaDTO)EmpresaDTOBindingSource.Current).Cnpj; });
                    if (empresaliberada == null)
                    {
                        MessageBox.Show("A empresa não pode ser ativada para uso devido sua licença de funcionamento não estar liberada." +
                                        " Para demais esclarecimentos, entre em contato com nosso suporte técnico.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        wait.Close();
                        return false;
                    }
                }
            }
            catch
            {
                wait.Close();
                throw;
            }

            wait.Close();
            return true;
        }

        private void Padrao()
        {
            empresaLookUpEdit.ItemIndex = 0;
            meslookUpEdit.EditValue = DateTime.Today.Month;
            anospinEdit.EditValue = DateTime.Today.Year;
        }

        private void CarregaConfiguracoes(EmpresaDTO obj)
        {
            //REINDERIZAR CONFIGURAÇÕES
            if (parent != null)
            {
                frmWait wait = new frmWait("Lendo as novas configurações...");
                wait.Show();
                Application.DoEvents();

                PropertyInfo propriedade;
                MethodInfo metodo;

                propriedade = Application.OpenForms[Global.MainForm].GetType().GetProperty("Ativaempresa");
                propriedade.SetValue(parent, false, null);

                propriedade = Application.OpenForms[Global.MainForm].GetType().GetProperty("DialogResult");
                propriedade.SetValue(parent, DialogResult.OK, null);

                //metodo = Application.OpenForms[Global.MainForm].GetType().GetMethod("Atalhos");
                //metodo.Invoke(parent, null);

                metodo = Application.OpenForms[Global.MainForm].GetType().GetMethod("MontaMenuModulo");
                metodo.Invoke(parent, new object[] { "01", new TreeList() });
                //metodo = Application.OpenForms[Global.MainForm].GetType().GetMethod("MontaMenuModulo");
                //metodo.Invoke(parent, new object[] { "02", new TreeList() });
                //metodo = Application.OpenForms[Global.MainForm].GetType().GetMethod("MontaMenuModulo");
                //metodo.Invoke(parent, new object[] { "03", new TreeList() });
                //metodo = Application.OpenForms[Global.MainForm].GetType().GetMethod("MontaMenuModulo");
                //metodo.Invoke(parent, new object[] { "04", new TreeList() });
                //metodo = Application.OpenForms[Global.MainForm].GetType().GetMethod("MontaMenuModulo");
                //metodo.Invoke(parent, new object[] { "05", new TreeList() });
                //metodo = Application.OpenForms[Global.MainForm].GetType().GetMethod("MontaMenuModulo");
                //metodo.Invoke(parent, new object[] { "06", new TreeList() });
                //metodo = Application.OpenForms[Global.MainForm].GetType().GetMethod("MontaMenuModulo");
                //metodo.Invoke(parent, new object[] { "07", new TreeList() });
                //metodo = Application.OpenForms[Global.MainForm].GetType().GetMethod("MontaMenuModulo");
                //metodo.Invoke(parent, new object[] { "08", new TreeList() });

                metodo = Application.OpenForms[Global.MainForm].GetType().GetMethod("CarregaConfiguracoes");
                metodo.Invoke(parent, new object[] { obj });

                wait.Close();
            }
        }

        private void Serializar()
        {
            EmpresaDTO empresa = new EmpresaDTO();
            empresa = (EmpresaDTO)EmpresaDTOBindingSource.Current;
            empresa.Mesano = Convert.ToDateTime("01/" + meslookUpEdit.EditValue.ToString() + "/" + anospinEdit.EditValue.ToString());
            empresa.Serializar();

            CarregaConfiguracoes(empresa);
        }

        private void Deserializar()
        {
            EmpresaDTO empresa = new EmpresaDTO().Deserializar();
            if (empresa == null)
                Padrao();
            else
            {
                try
                {
                    empresaLookUpEdit.EditValue = new EmpresaGL().GetEmpresa(empresa.Id).Id;
                    EmpresaDTOBindingSource.Position = empresaLookUpEdit.ItemIndex;
                    meslookUpEdit.EditValue = empresa.Mesano.Month;
                    anospinEdit.EditValue = empresa.Mesano.Year;
                }
                catch
                {
                    Padrao();
                }
            }
        }

        private void empresaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!empresaLookUpEdit.IsModified)
                return;

            EmpresaDTOBindingSource.Position = empresaLookUpEdit.ItemIndex;
        }

        private void empresaLookUpEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void meslookUpEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void anospinEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Selecionar();
            else if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}