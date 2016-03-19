using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

#region DEVEXPRESS
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Preview;
#endregion

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Templates;
using MechTech.Entities;
using MechTech.Gateway;
//using MechTech.UI.Cadastros.Reports;
//using MechTech.UI.Utilitarios;
#endregion

namespace MechTech.UI.Cadastros
{
    public partial class frmUpdateEmpresa : frmBase
    {
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        EmpresaDTO empresaDTO { get; set; }
        EmpresaDTO empresaDTOVersaoOriginal { get; set; }
        TreeNode node { get; set; }
        BindingSource bndEmpresaGrid = new BindingSource();
        CNAEGL cnaeGL = new CNAEGL();
        EmpresaGL empresaGL = new EmpresaGL();
        MunicipioGL municipioGL = new MunicipioGL();
        Acesso acesso = new Acesso();

        bool ProcuraCEP = false;
        public frmUpdateEmpresa()
        {
            InitializeComponent();
        }

        public frmUpdateEmpresa(int id_empresa)
        {
            InitializeComponent();
            empresaDTO = new EmpresaDTO();
            empresaDTO.Id = id_empresa;
        }

        public frmUpdateEmpresa(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndEmpresaGrid = bnd;
                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                {
                    EmpresaDTOBindingSource.AddNew();
                }
                else
                {
                    empresaDTO = (EmpresaDTO)bndEmpresaGrid.Current;
                    EmpresaDTOBindingSource.DataSource = empresaGL.GetEmpresa(empresaDTO.Id);
                    empresaDTOVersaoOriginal = new EmpresaDTO((EmpresaDTO)EmpresaDTOBindingSource.Current);
                }
                empresaDTO = (EmpresaDTO)EmpresaDTOBindingSource.Current;
                GetImages();
                NaturezaJuridicaDTOBindingSource.DataSource = new NaturezaJuridicaGL().GetGridNaturezajuridica("codigo", "%");
                PorteDTOBindingSource.DataSource = new PorteGL().GetGridPorte("codigo", "%");
                PopulateTreeviewCNAE();
                GetTipo();
            }
            catch
            {
                throw;
            }
        }
        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Salvar())
                Close();
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnPrimeiro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndEmpresaGrid.MoveFirst();
            Navegar();
        }

        private void btnAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndEmpresaGrid.MovePrevious();
            Navegar();
        }

        private void btnProximo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndEmpresaGrid.MoveNext();
            Navegar();
        }

        private void btnUltimo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndEmpresaGrid.MoveLast();
            Navegar();
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            node = e.Node;
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nodeSelected(node);
        }

        private void treeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                nodeSelected(node);
        }

        private void Navegar()
        {
            Cursor = Cursors.WaitCursor;
            EmpresaDTOBindingSource.DataSource = empresaGL.GetEmpresa(((EmpresaDTO)bndEmpresaGrid.Current).Id);
            empresaDTO = (EmpresaDTO)EmpresaDTOBindingSource.Current;
            GetTipo();
            GetImages();
            empresaDTOVersaoOriginal = new EmpresaDTO(empresaDTO);
            Cursor = Cursors.Default;
        }

        private void PopulateTreeviewCNAE()
        {
            TreeNode tncnae = new TreeNode("C.N.A.E");

            List<CNAEDTO> lstcnae = cnaeGL.GetGridCNAE("codigo", "%");
            int n1 = -1;
            string n2 = string.Empty;
            string n3 = string.Empty;
            string n4 = string.Empty;
            foreach (CNAEDTO item in lstcnae)
            {
                if (item.Codigo.Length == 1)
                {
                    tncnae.Nodes.Add(item.Codigo, item.Codigo + " - " + item.Descricao);
                    n1++;
                }
                else if (item.Codigo.Length == 3)
                {
                    tncnae.Nodes[n1].Nodes.Add(item.Codigo, item.Codigo + " - " + item.Descricao);
                    n2 = item.Codigo;
                }
                else if (item.Codigo.Length == 4)
                {
                    tncnae.Nodes[n1].Nodes[n2].Nodes.Add(item.Codigo, item.Codigo + " - " + item.Descricao);
                    n3 = item.Codigo;
                }
                else if (item.Codigo.Length == 7)
                {
                    tncnae.Nodes[n1].Nodes[n2].Nodes[n3].Nodes.Add(item.Codigo, item.Codigo + " - " + item.Descricao);
                    n4 = item.Codigo;
                }
                else if (item.Codigo.Length == 10)
                {
                    tncnae.Nodes[n1].Nodes[n2].Nodes[n3].Nodes[n4].Nodes.Add(item.Codigo, item.Codigo + " - " + item.Descricao);
                }
            }

            tncnae.Expand();
            treeView.Nodes.Add(tncnae);
        }

        private void frmUpdateEmpresa_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;

            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Empresa";
                    HabilitaDesabilitaBotoesNavegacao(false);
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Empresa";
                    HabilitaDesabilitaBotoesNavegacao(true);
                    cnpjTextEdit.Enabled = false;
                    rdgTipo.Enabled = false;
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Empresa";
                    HabilitaDesabilitaBotoesNavegacao(true);
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
        private void HabilitaDesabilitaBotoesNavegacao(bool enabled)
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Viewer)
                return;

            btnPrimeiro.Enabled = enabled;
            btnAnterior.Enabled = enabled;
            btnProximo.Enabled = enabled;
            btnUltimo.Enabled = enabled;
        }

        private void frmUpdateEmpresa_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
        }
        private void GetTipo()
        {
            if (empresaDTO.Tipo.Equals("J")) //PESSOA JURÍDICA (CNPJ)
            {
                rdgTipo.SelectedIndex = 0;
                cnpjTextEdit.Properties.Mask.EditMask = "99.999.999/9999-99";
                empresaDTO.Tipo = "J";
            }
            else //PESSOA FÍSICA (CPF)
            {
                rdgTipo.SelectedIndex = 1;
                cnpjTextEdit.Properties.Mask.EditMask = "999.999.999-99";
                empresaDTO.Tipo = "F";
            }
        }

        private bool Salvar()
        {
            try
            {
                //EXCEPTION
                Municipio();
                //

                if (ValidaCampos())
                    return false;

                Cursor = Cursors.WaitCursor;
                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        empresaDTO.Id = empresaGL.Insert((EmpresaDTO)EmpresaDTOBindingSource.Current);
                        bndEmpresaGrid.Add(EmpresaDTOBindingSource.Current);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        empresaGL.Update((EmpresaDTO)EmpresaDTOBindingSource.Current);
                        bndEmpresaGrid.List[bndEmpresaGrid.Position] = EmpresaDTOBindingSource.Current;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            Cursor = Cursors.Default;

            return true;
        }

        private void GetImages()
        {
            LogotipoPictureEdit.Image = Global.LerImagemBinaria(empresaDTO.Logotipo);
        }

        private void Municipio()
        {
            try
            {
                ((EmpresaDTO)EmpresaDTOBindingSource.Current).Municipio = municipioGL.GetMunicipioIBGE(Convert.ToInt32(codigoibgeButtonEdit.Text));
            }
            catch { }
        }

        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors();

            #region BÁSICO
            if (empresaDTO.Razaosocial.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(razaosocialTextEdit, "Razão Social inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (empresaDTO.Nomefantasia.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(nomefantasiaTextEdit, "Nome fantasia inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (empresaDTO.Endereco.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(enderecoTextEdit, "Endereço inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (empresaDTO.Numero.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(numeroTextEdit, "Número inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (empresaDTO.Bairro.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(bairroTextEdit, "Bairro inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (empresaDTO.Cep.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(cepTextEdit, "Cep inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (empresaDTO.Municipio.Codigoibge == 0)
                dxErrorProvider.SetError(codigoibgeButtonEdit, "Cód. Município inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            else
            {
                if (empresaDTO.Municipio.Nome.Trim().Equals(string.Empty))
                    dxErrorProvider.SetError(codigoibgeButtonEdit, "Cód. Município não localizado.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }

            if (empresaDTO.Dddtelefone.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(dddtelefoneTextEdit, "DDD do telefone inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (empresaDTO.Telefone.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(telefoneTextEdit, "Telefone inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (empresaDTO.Tipo.Equals("J")) //PESSOA JURÍDICA (CNPJ)
            {
                if (empresaDTO.Cnpj.Trim().Equals(string.Empty))
                    dxErrorProvider.SetError(cnpjTextEdit, "CNPJ inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                else
                {
                    if (!Documentos.ValidarCNPJ(empresaDTO.Cnpj.Trim()))
                        dxErrorProvider.SetError(cnpjTextEdit, "CNPJ inválido.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                }
            }
            else //PESSOA FÍSICA (CPF)
            {
                if (empresaDTO.Cnpj.Trim().Equals(string.Empty))
                    dxErrorProvider.SetError(cnpjTextEdit, "CPF inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                else
                {
                    if (!Documentos.ValidarCPF(empresaDTO.Cnpj.Trim()))
                        dxErrorProvider.SetError(cnpjTextEdit, "CPF inválido.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                }
            }

            if (empresaDTO.Iestadual.Trim().Equals(string.Empty))
            {
                dxErrorProvider.SetError(iestadualTextEdit, "Inscrição Estadual inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }
            else
            {
                if (Documentos.ConsisteInscricaoEstadual(empresaDTO.Iestadual.Trim(), empresaDTO.Municipio.UF.Codigo.Trim()) != 0)
                {
                    if (empresaDTO.Municipio.UF.Codigo.Trim().Equals(string.Empty))
                        dxErrorProvider.SetError(iestadualTextEdit, "Inscrição Estadual inválida.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    else
                        dxErrorProvider.SetError(iestadualTextEdit, "Inscrição Estadual inválida para " + empresaDTO.Municipio.UF.Descricao.Trim(), DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                }
            }

            if (empresaDTO.Naturezajuridica.Id == 0)
                dxErrorProvider.SetError(naturezajuridicaLookUpEdit, "Nat. Jurídica inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (empresaDTO.CNAE.Codigo.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(cnaeContainerEdit, "CNAE inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (empresaDTO.Email.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(emailTextEdit, "Email inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            #endregion

            if (empresaDTO.Bairro.ToString().Count() > 20) //41739
                dxErrorProvider.SetError(bairroTextEdit, "O campo bairro possui mais caracteres do que o permitido nos layouts, por gentileza informe dados de modo abreviado. Tamanho máximo: 20 Caracteres.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (dxErrorProvider.HasErrors)
                MessageBox.Show("O Sistema identificou campos obrigatórios não preenchidos ou preenchidos incorretamente. Impossível prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return dxErrorProvider.HasErrors;
        }

        private bool VerificarDados()
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Update)
            {
                if (!((EmpresaDTO)EmpresaDTOBindingSource.Current).Equals(empresaDTOVersaoOriginal))
                {
                    if (MessageBox.Show("O Sistema identificou dados alterados não salvos. Deseja salvá-los antes de prosseguir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        return Salvar();
                    else
                        dxErrorProvider.ClearErrors();
                }
            }

            return true;
        }
        private void nodeSelected(TreeNode no)
        {
            if (no.Name.Trim().Length == 10) //ÚLTIMO NÍVEL DE CNAE
            {
                if (no.Name.Trim() != string.Empty)
                    cnaeContainerEdit.EditValue = no.Name;
                else
                    cnaeContainerEdit.EditValue = string.Empty;
                CNAEDTO cnae = cnaeGL.GetCNAE(cnaeContainerEdit.EditValue.ToString().ToUpper());
                empresaDTO.CNAE = cnae;

                cnaeContainerControl.OwnerEdit.ClosePopup();
            }
        }

        private void cnaeContainerEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (cnaeContainerEdit.Text.Trim().Equals(string.Empty))
                cnaeContainerEdit.Text = string.Empty;
        }

        private void codigoibgeButtonEdit_Validated(object sender, EventArgs e)
        {
            if (!codigoibgeButtonEdit.IsModified)
                return;

            MunicipioDTO municipio = new MunicipioDTO();
            if (codigoibgeButtonEdit.Text.Trim() != "0" && this.Enabled == true)
            {
                try
                {
                    municipio = municipioGL.GetMunicipioIBGE(Convert.ToInt32(codigoibgeButtonEdit.Text));
                    municipioTextEdit.Text = municipio.Nome;
                    UFTextEdit.Text = municipio.UF.Codigo;
                }
                catch
                {
                    municipio.Codigoibge = Convert.ToInt32(codigoibgeButtonEdit.Text);
                    municipioTextEdit.Text = string.Empty;
                    UFTextEdit.Text = string.Empty;

                    Cursor = Cursors.WaitCursor;
                    frmGridMunicipio frmgridmunicipio = new frmGridMunicipio(this, new Global.SystemDelegate(SetMunicipio));
                    frmgridmunicipio.Show();
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                municipioTextEdit.Text = string.Empty;
                UFTextEdit.Text = string.Empty;
            }
            empresaDTO.Municipio = municipio;
        }

        private void SetMunicipio(object municipio)
        {
            codigoibgeButtonEdit.Text = ((MunicipioDTO)municipio).Codigoibge.ToString();
            municipioTextEdit.Text = ((MunicipioDTO)municipio).Nome;
            UFTextEdit.Text = ((MunicipioDTO)municipio).UF.Codigo;
            empresaDTO.Municipio = (MunicipioDTO)municipio;
        }

        private void cepTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            BuscaCep();
        }

        private void BuscaCep()
        {

            //if (Global.Validacep == false)
            //{
            //    MessageBox.Show("Sua oficina não contratou o serviço de consulta on-line de CEP. " +
            //                    "Para utilizar este serviço, acesse a Área do Cliente no website www.MECHTECH.inf.br \n" +
            //                    "na seção 'Administrador' e solicite a ativação deste recurso.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            if (ProcuraCEP)
                return;

            try
            {
                ProcuraCEP = true;

                Cursor = Cursors.WaitCursor;
                BuscaCEPGL cep = new BuscaCEPGL();
                List<BuscaCEPDTO> dados = new List<BuscaCEPDTO>();


                if (empresaDTO.Cep != "")
                    dados = cep.GetEndereco("",
                                            "",
                                            "",
                                            empresaDTO.Cep);

                if ((dados == null) || (dados.Count == 0) || (dados.Count > 1))
                {
                    frmBuscaCEP frmCep = new frmBuscaCEP(this, new MechTech.Util.Global.SystemDelegate(SetCep));
                    frmCep.Show();
                }
                else
                {

                    cepTextEdit.EditValue = dados[0].Cep;
                    UFTextEdit.EditValue = dados[0].Uf;
                    codigoibgeButtonEdit.EditValue = dados[0].CodMun;
                    municipioTextEdit.EditValue = dados[0].Municipio;
                    enderecoTextEdit.EditValue = dados[0].Endereco;
                    bairroTextEdit.EditValue = dados[0].Bairro;
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                ProcuraCEP = false;
            }
        }
        private void SetCep(object cep)
        {
            codigoibgeButtonEdit.Text = ((BuscaCEPDTO)cep).CodMun.ToString();
            municipioTextEdit.Text = ((BuscaCEPDTO)cep).Municipio;
            UFTextEdit.Text = ((BuscaCEPDTO)cep).Uf;
            cepTextEdit.Text = ((BuscaCEPDTO)cep).Cep;
            enderecoTextEdit.Text = ((BuscaCEPDTO)cep).Endereco;
            bairroTextEdit.Text = ((BuscaCEPDTO)cep).Bairro;
        }

        private void rdgTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdgTipo.SelectedIndex == 0) //PESSOA JURÍDICA (CNPJ)
            {
                cnpjTextEdit.Properties.Mask.EditMask = "99.999.999/9999-99";
                empresaDTO.Tipo = "J";
            }
            else //PESSOA FÍSICA (CPF)
            {
                cnpjTextEdit.Properties.Mask.EditMask = "999.999.999-99";
                empresaDTO.Tipo = "F";
            }
        }

        private void cnaeContainerEdit_Popup(object sender, EventArgs e)
        {
            if (cnaeContainerEdit.EditValue.ToString() != string.Empty)
            {
                try
                {
                    treeView.Nodes[0].TreeView.CollapseAll();

                    string cnae = cnaeContainerEdit.EditValue.ToString();
                    string cnae_n1 = cnae.Substring(0, 1);
                    string cnae_n2 = cnae.Substring(1, 2);
                    string cnae_n3 = cnae.Substring(3, 1);
                    string cnae_n4 = cnae.Substring(4, 3);

                    TreeNode[] no_n1 = treeView.Nodes[0].Nodes.Find(cnae_n1, true);
                    no_n1[0].Expand();
                    TreeNode[] no_n2 = treeView.Nodes[0].Nodes[no_n1[0].Index].Nodes.Find(cnae_n1 + cnae_n2, true);
                    no_n2[0].Expand();
                    TreeNode[] no_n3 = treeView.Nodes[0].Nodes[no_n1[0].Index].Nodes[no_n2[0].Index].Nodes.Find(cnae_n1 + cnae_n2 + cnae_n3, true);
                    no_n3[0].Expand();
                    TreeNode[] no_n4 = treeView.Nodes[0].Nodes[no_n1[0].Index].Nodes[no_n2[0].Index].Nodes[no_n3[0].Index].Nodes.Find(cnae_n1 + cnae_n2 + cnae_n3 + cnae_n4, true);
                    no_n4[0].Expand();
                    TreeNode[] no_n5 = treeView.Nodes[0].Nodes[no_n1[0].Index].Nodes[no_n2[0].Index].Nodes[no_n3[0].Index].Nodes[no_n4[0].Index].Nodes.Find(cnae, true);
                    treeView.SelectedNode = no_n5[0];
                }
                catch { }
            }
        }

        private void codigoibgeButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridMunicipio frmGrid = new frmGridMunicipio(this, new Global.SystemDelegate(SetMunicipio));
            frmGrid.Show();
            Cursor = Cursors.Default;
        }

        private void LogotipoPictureEdit_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.RestoreDirectory = true;
            file.Filter = "Arquivos de Imagem(*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png;*.ico)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png;*.ico";
            if (file.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileinfo = new FileInfo(file.FileName);
                decimal filelength = fileinfo.Length / 1024;
                if (filelength > 5000) //5000KB
                {
                    MessageBox.Show("Logotipo inválido. O tamanho da imagem não deve ser superior a 5MB.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LogotipoPictureEdit.Image = null;
                    empresaDTO.Logotipo = null;
                }
                else
                {
                    LogotipoPictureEdit.Image = Image.FromFile(file.FileName);
                    empresaDTO.Logotipo = Global.LerImagem(file.FileName);
                }
            }
            else
            {
                LogotipoPictureEdit.Image = null;
                empresaDTO.Logotipo = null;
            }
        }
    }
}
