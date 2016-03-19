using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

#region DEVEXPRESS
using DevExpress.XtraEditors;
#endregion

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Templates;
using MechTech.Util;
using MechTech.Entities;
using MechTech.Gateway;
//using MechTech.UI.Movimentos;
//using MechTech.UI.Cadastro;

#endregion
namespace MechTech.UI.Cadastros
{
    public partial class frmUpdateFuncionario : frmBase
    {
        DateTime dataprocessamento;
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        FuncionarioDTO funcionarioDTO { get; set; }
        FuncionarioDTO funcionarioDTOVersaoOriginal { get; set; }
        BindingSource bndFuncionarioGrid = new BindingSource();
        FuncionarioGL funcionarioGL = new FuncionarioGL();
        MunicipioGL municipioGL = new MunicipioGL();
        Acesso acesso = new Acesso();

        bool ProcuraCEP = true;
        public frmUpdateFuncionario()
        {
            InitializeComponent();
            MechTech.Util.Global.RotinaLOG = Enumeradores.RotinaLOG.Funcionarios;
            dataprocessamento = MechTech.Util.Global.MesanoAtivo;
        }

        public frmUpdateFuncionario(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();
            MechTech.Util.Global.RotinaLOG = Enumeradores.RotinaLOG.Funcionarios;
            dataprocessamento = MechTech.Util.Global.MesanoAtivo;

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndFuncionarioGrid = bnd;
                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                    FuncionarioDTOBindingSource.AddNew();
                else
                {
                    funcionarioDTO = funcionarioGL.GetFuncionario(((FuncionarioSEDTO)bndFuncionarioGrid.Current).Id);
                    FuncionarioDTOBindingSource.DataSource = funcionarioDTO;
                    funcionarioDTOVersaoOriginal = new FuncionarioDTO((FuncionarioDTO)FuncionarioDTOBindingSource.Current);
                }

                funcionarioDTO = (FuncionarioDTO)FuncionarioDTOBindingSource.Current;

                //SITUAÇÃO
                if (funcionarioDTO.Contrato.Datademissao.HasValue)
                {
                    lblSituacao.Visible = true;
                    lblSituacao.Text = "* Funcionário Demitido *";
                }

                UFDTOBindingSource.DataSource = new UFGL().GetGridUF("codigo", "%");
                BancoDTOBindingSource.DataSource = new BancoGL().GetGridBanco("codigo", "%");
                SemanaBindingSource.DataSource = MechTech.Util.Global.ObterSemana();

                GetFoto();
            }
            catch
            {
                throw;
            }
        }

        private void GetFoto()
        {
            fotopictureEdit.Image = MechTech.Util.Global.LerImagemBinaria(funcionarioDTO.Foto);
        }
        private void btnExcluirSalario_Click(object sender, EventArgs e)
        {
            ExcluirSalario();
        }

        private void ExcluirSalario()
        {
            if (funcionarioDTO.Salario.Count <= 0)
                return;

            if (MessageBox.Show("Deseja realmente excluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    SalarioBindingSource.RemoveCurrent();
                }
                catch
                {
                    throw;
                }
            }
        }
        private void btnVisualizarSalario_Click(object sender, EventArgs e)
        {
            VisualizarSalario();
        }

        private void btnInserirSalario_Click(object sender, EventArgs e)
        {
            InserirSalario();
        }
        private void VisualizarSalario()
        {
            if (funcionarioDTO.Salario.Count <= 0 ||
                tpOperacao == Enumeradores.TipoOperacao.Viewer ||
                !btnVisualizarSalario.Enabled)
                return;

            Cursor = Cursors.WaitCursor;
            frmUpdateSalario frmUpdate = new frmUpdateSalario(Enumeradores.TipoOperacao.Viewer, SalarioBindingSource, colSalario.Visible);
            frmUpdate.ShowDialog();
            Cursor = Cursors.Default;
        }
        private void InserirSalario()
        {
            Cursor = Cursors.WaitCursor;
            frmUpdateSalario frmUpdate = new frmUpdateSalario(Enumeradores.TipoOperacao.Insert, SalarioBindingSource, colSalario.Visible);
            frmUpdate.ShowDialog();
            Cursor = Cursors.Default;
        }
        private void fotopictureEdit_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.RestoreDirectory = true;
            file.Filter = "Arquivos de Imagem(*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";
            if (file.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileinfo = new FileInfo(file.FileName);
                decimal filelength = fileinfo.Length / 1024;
                if (filelength > 15) //15KB
                {
                    MessageBox.Show("Foto inválida. O tamanho da imagem não deve ser superior a 15KB.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fotopictureEdit.Image = null;
                    funcionarioDTO.Foto = null;
                }
                else
                {
                    fotopictureEdit.Image = Image.FromFile(file.FileName);
                    funcionarioDTO.Foto = MechTech.Util.Global.LerImagem(file.FileName);
                }
            }
            else
            {
                fotopictureEdit.Image = null;
                funcionarioDTO.Foto = null;
            }
        }

        private void btnAlterarSalario_Click(object sender, EventArgs e)
        {
            EditarSalario();
        }
        private void EditarSalario()
        {
            if (funcionarioDTO.Salario.Count <= 0 ||
                tpOperacao == Enumeradores.TipoOperacao.Viewer ||
                !btnAlterarSalario.Enabled)
                return;

            Cursor = Cursors.WaitCursor;
            frmUpdateSalario frmUpdate = new frmUpdateSalario(Enumeradores.TipoOperacao.Update, SalarioBindingSource, colSalario.Visible);
            frmUpdate.ShowDialog();
            salarioGridControl.RefreshDataSource();
            Cursor = Cursors.Default;
        }

        //PERSISTÊNCIA DE MUNICÍPIO
        private void Municipio()
        {
            //MUNICÍPIO
            try
            {
                ((FuncionarioDTO)FuncionarioDTOBindingSource.Current).Municipio = municipioGL.GetMunicipioIBGE(Convert.ToInt32(codigoibgeButtonEdit.Text));
            }
            catch { }
        }

        private void salarioGridControl_DoubleClick(object sender, EventArgs e)
        {
            EditarSalario();
        }
        private void HabilitaDesabilitaBotoesNavegacao(bool enabled)
        {
            btnPrimeiro.Enabled = enabled;
            btnAnterior.Enabled = enabled;
            btnProximo.Enabled = enabled;
            btnUltimo.Enabled = enabled;
        }

        private bool VerificarDados()
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Update)
            {
                if (!((FuncionarioDTO)FuncionarioDTOBindingSource.Current).Equals(funcionarioDTOVersaoOriginal))
                {
                    if (MessageBox.Show("O Sistema identificou dados alterados não salvos. Deseja salvá-los antes de prosseguir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        return Salvar(false);
                    else
                        dxErrorProvider.ClearErrors();
                }
            }

            return true;
        }

        private void Navegar()
        {
            Cursor = Cursors.WaitCursor;
            FuncionarioDTOBindingSource.DataSource = funcionarioGL.GetFuncionario(((FuncionarioSEDTO)bndFuncionarioGrid.Current).Id);
            funcionarioDTO = (FuncionarioDTO)FuncionarioDTOBindingSource.Current;
            if (funcionarioDTO.Contrato.Datademissao.HasValue)
            {
                lblSituacao.Visible = true;
                lblSituacao.Text = "* Funcionário Demitido *";
            }
            else
            {
                lblSituacao.Visible = false;
                lblSituacao.Text = "";
            }
            GetFoto();
            funcionarioDTOVersaoOriginal = new FuncionarioDTO(funcionarioDTO);
            Cursor = Cursors.Default;
        }

        private void btnPrimeiro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndFuncionarioGrid.MoveFirst();
            Navegar();
        }

        private void btnAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndFuncionarioGrid.MovePrevious();
            Navegar();
        }

        private void btnProximo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndFuncionarioGrid.MoveNext();
            Navegar();
        }

        private void btnUltimo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndFuncionarioGrid.MoveLast();
            Navegar();
        }

        private void gridViewSalario_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //if (e.RowHandle >= 0)
            //{
            //    if (funcionarioDTO.Salario[e.RowHandle].Data == funcionarioDTO.Contrato.Datatransferencia)
            //        e.Appearance.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            //    else
            //        e.Appearance.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //}
        }

        private void BuscaCep()
        {

            //if (MechTech.Util.Global.Validacep == false)
            //{
            //    MessageBox.Show("Sua concessionária não contratou o serviço de consulta on-line de CEP. " +
            //                    "Para utilizar este serviço, acesse a Área do Cliente no website www.MECHTECH.inf.br \n" +
            //                    "na seção 'Administrador' e solicite a ativação deste recurso.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

           // ProcuraCEP = false;

            //if (ProcuraCEP)
            //    return;

            try
            {
               // ProcuraCEP = true;
                Cursor = Cursors.WaitCursor;
               // BuscaCEPGL cep = new BuscaCEPGL();
                //List<BuscaCEPDTO> dados = new List<BuscaCEPDTO>();


                //if (funcionarioDTO.Cep != "")
                //    dados = cep.GetEndereco("",
                //                            "",
                //                            "",
                //                            funcionarioDTO.Cep);

                //if ((dados == null) || (dados.Count == 0) || (dados.Count > 1))
                //{
                    frmBuscaCEP frmCep = new frmBuscaCEP(this, new MechTech.Util.Global.SystemDelegate(SetCep));
                    frmCep.Show();
                //}
                //else
                //{
                //    cepTextEdit.EditValue = dados[0].Cep;
                //    UFTextEdit.EditValue = dados[0].Uf;
                //    codigoibgeButtonEdit.EditValue = dados[0].CodMun;
                //    municipioTextEdit.EditValue = dados[0].Municipio;
                //    enderecoTextEdit.EditValue = dados[0].Endereco;
                //    bairroTextEdit.EditValue = dados[0].Bairro;
                //}
            }
            finally
            {
                Cursor = Cursors.Default;
               // ProcuraCEP = false;
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

        private void cepTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
             BuscaCep();
        }

        private void cepTextEdit_Validated(object sender, EventArgs e)
        {
            //if (funcionarioDTO.Cep != "")
            //    BuscaCep();
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Salvar(false))
                Close();
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private bool Salvar(bool reload)
        {
            try
            {
                Municipio();

                if (ValidaCampos())
                    return false;

                Cursor = Cursors.WaitCursor;
                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        funcionarioDTO.Id = funcionarioGL.Insert((FuncionarioDTO)FuncionarioDTOBindingSource.Current);
                        bndFuncionarioGrid.Add(funcionarioGL.GetGridFuncionarioSE("id", funcionarioDTO.Id.ToString(), Enumeradores.Modulo.Funcionario, false)[0]);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        funcionarioGL.Update((FuncionarioDTO)FuncionarioDTOBindingSource.Current);
                        bndFuncionarioGrid.List[bndFuncionarioGrid.Position] = funcionarioGL.GetGridFuncionarioSE("id", funcionarioDTO.Id.ToString(), Enumeradores.Modulo.Funcionario, false)[0];

                        if (reload) //SALVAR E PERMANECER NO FUNCIONÁRIO SELECIONADO
                        {
                            funcionarioDTO = funcionarioGL.GetFuncionario(((FuncionarioSEDTO)bndFuncionarioGrid.Current).Id);
                            FuncionarioDTOBindingSource.DataSource = funcionarioDTO;
                            funcionarioDTOVersaoOriginal = new FuncionarioDTO((FuncionarioDTO)FuncionarioDTOBindingSource.Current);
                            funcionarioDTO = (FuncionarioDTO)FuncionarioDTOBindingSource.Current;
                            GetFoto();
                        }
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

        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors();

            if (funcionarioDTO.Contrato.Dataadmissao == null)
                dxErrorProvider.SetError(dataadmissaoDateEdit, "Data de admissão inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (funcionarioDTO.Salario.Count <= 0)
            {
                MessageBox.Show("Não foi identificado nenhum lançamento de salário. Impossível prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            FuncSalarioDTO salarioatual = funcionarioDTO.Salario.Find(delegate(FuncSalarioDTO item)
            {
                return new DateTime(item.Data.Value.Year, item.Data.Value.Month, 1) <=
                    new DateTime(dataprocessamento.Year, dataprocessamento.Month, 1) && (item.DataReajuste <=
                    new DateTime(dataprocessamento.Year, dataprocessamento.Month, 1) || !item.DataReajuste.HasValue);
            });

            #region BÁSICO
            if (!funcionarioDTO.Datanascimento.HasValue)
                dxErrorProvider.SetError(datanascimentoDateEdit, "Data de nascimento inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (funcionarioDTO.Nomecompleto.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(nomecompletoTextEdit, "Nome completo inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (funcionarioDTO.Endereco.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(enderecoTextEdit, "Endereço inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (funcionarioDTO.Numero.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(numeroTextEdit, "Número inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (funcionarioDTO.Bairro.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(bairroTextEdit, "Bairro inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (funcionarioDTO.Cep.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(cepTextEdit, "Cep inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (funcionarioDTO.Municipio.Codigoibge == 0)
                dxErrorProvider.SetError(codigoibgeButtonEdit, "Cód. Município inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            else
            {
                if (funcionarioDTO.Municipio.Nome.Trim().Equals(string.Empty))
                    dxErrorProvider.SetError(codigoibgeButtonEdit, "Cód. Município não localizado.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }

            if (funcionarioDTO.Sexo.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(sexocomboBoxEdit, "Sexo inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            #endregion

            #region DOCUMENTOS
            if (!funcionarioDTO.Documento.Cpf.Trim().Equals(string.Empty))
            {
                if (!Documentos.ValidarCPF(funcionarioDTO.Documento.Cpf.Trim()))
                    dxErrorProvider.SetError(cpfTextEdit, "CPF inválido.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                else
                {
                    if (funcionarioGL.ExistsCPF(funcionarioDTO.Id, funcionarioDTO.Documento.Cpf.Trim()))
                        dxErrorProvider.SetError(cpfTextEdit, "CPF inválido. O CPF informado já encontra-se cadastrado nessa empresa para outro funcionário.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                }
            }
            else
                dxErrorProvider.SetError(cpfTextEdit, "CPF inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (funcionarioDTO.Bairro.ToString().Count() > 20) //41739
                dxErrorProvider.SetError(bairroTextEdit, "O campo bairro possui mais caracteres do que o permitido nos layouts, por gentileza informe dados de modo abreviado. Tamanho máximo: 20 Caracteres.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (funcionarioDTO.Endereco.ToString().Count() > 40) //45019
                dxErrorProvider.SetError(enderecoTextEdit, "O campo endereço possui mais caracteres do que o permitido nos layouts, por gentileza informe dados de modo abreviado. Tamanho máximo: 40 Caracteres.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);


            if (dxErrorProvider.HasErrors)
                MessageBox.Show("O Sistema identificou campos obrigatórios não preenchidos ou preenchidos incorretamente. Impossível prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            #endregion

            return dxErrorProvider.HasErrors;
        }

        private void gridViewSalario_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                //DEPARTAMENTO
                if (e.Column.FieldName.Equals("Departamento.Codigo") && e.ListSourceRowIndex >= 0 && e.IsGetData)
                    e.Value = (funcionarioDTO.Salario[e.ListSourceRowIndex].Departamento.Codigo.ToString().Equals("0") ? string.Empty : funcionarioDTO.Salario[e.ListSourceRowIndex].Departamento.Codigo.ToString());

                //SETOR
                if (e.Column.FieldName.Equals("Setor.Codigo") && e.ListSourceRowIndex >= 0 && e.IsGetData)
                    e.Value = (funcionarioDTO.Salario[e.ListSourceRowIndex].Setor.Codigo.ToString().Equals("0") ? string.Empty : funcionarioDTO.Salario[e.ListSourceRowIndex].Setor.Codigo.ToString());

                //SEÇÃO
                if (e.Column.FieldName.Equals("Secao.Codigo") && e.ListSourceRowIndex >= 0 && e.IsGetData)
                    e.Value = (funcionarioDTO.Salario[e.ListSourceRowIndex].Secao.Codigo.ToString().Equals("0") ? string.Empty : funcionarioDTO.Salario[e.ListSourceRowIndex].Secao.Codigo.ToString());

                //FUNÇÃO
                if (e.Column.FieldName.Equals("Funcao.Nome") && e.ListSourceRowIndex >= 0 && e.IsGetData)
                    e.Value = funcionarioDTO.Salario[e.ListSourceRowIndex].Funcao.Nome;

                //HORAS/MÊS
                if (e.Column.FieldName.Equals("Funcao.Horas") && e.ListSourceRowIndex >= 0 && e.IsGetData)
                    e.Value = funcionarioDTO.Salario[e.ListSourceRowIndex].Funcao.Horas.ToString();

                //SALÁRIO
                if (e.Column.FieldName.Equals("Salario.Salario") && e.ListSourceRowIndex >= 0 && e.IsGetData)
                    e.Value = string.Format("{0:c2}", funcionarioDTO.Salario[e.ListSourceRowIndex].Salario);
            }
            catch { }
        }

        private void gridViewSalario_RowCountChanged(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoesSalario();
        }

        private void HabilitaDesabilitaBotoesSalario()
        {
            if (tpOperacao == Enumeradores.TipoOperacao.Viewer)
                return;

            if (salarioGridControl.FocusedView.DataRowCount == 0)
            {
                btnAlterarSalario.Enabled = false;
                btnExcluirSalario.Enabled = false;
                btnVisualizarSalario.Enabled = false;
            }
            else
            {
                btnAlterarSalario.Enabled = true;
                btnExcluirSalario.Enabled = true;
                btnVisualizarSalario.Enabled = true;
            }
        }

        private void frmUpdateFuncionario_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;

            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Funcionário";
                    HabilitaDesabilitaBotoesNavegacao(false);
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Funcionário";
                    HabilitaDesabilitaBotoesNavegacao(true);
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Funcionário";
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

        private void frmUpdateFuncionario_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
        }

        private void codigoibgeButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridMunicipio frmGrid = new frmGridMunicipio(this, new MechTech.Util.Global.SystemDelegate(SetMunicipio));
            frmGrid.Show();
            Cursor = Cursors.Default;
        }

        private void SetMunicipio(object municipio)
        {
            codigoibgeButtonEdit.Text = ((MunicipioDTO)municipio).Codigoibge.ToString();
            municipioTextEdit.Text = ((MunicipioDTO)municipio).Nome;
            UFTextEdit.Text = ((MunicipioDTO)municipio).UF.Codigo;
            funcionarioDTO.Municipio = (MunicipioDTO)municipio;

            codigoibgeButtonEdit.IsModified = true;
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
                    frmGridMunicipio frmgridmunicipio = new frmGridMunicipio(this, new MechTech.Util.Global.SystemDelegate(SetMunicipio));
                    frmgridmunicipio.Show();
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                municipioTextEdit.Text = string.Empty;
                UFTextEdit.Text = string.Empty;
            }
            funcionarioDTO.Municipio = municipio;
        }

        private void UFCTPSLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!UFCTPSLookUpEdit.IsModified)
                return;

            funcionarioDTO.Documento.UFCTPS = (UFDTO)UFCTPSLookUpEdit.Properties.GetDataSourceRowByKeyValue(UFCTPSLookUpEdit.EditValue);
            if (funcionarioDTO.Documento.UFCTPS == null)
                funcionarioDTO.Documento.UFCTPS = new UFDTO();
        }

        private void UFReservistaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!UFReservistaLookUpEdit.IsModified)
                return;

            funcionarioDTO.Documento.UFreservista = (UFDTO)UFReservistaLookUpEdit.Properties.GetDataSourceRowByKeyValue(UFReservistaLookUpEdit.EditValue);
            if (funcionarioDTO.Documento.UFreservista == null)
                funcionarioDTO.Documento.UFreservista = new UFDTO();
        }

        private void bancosalarioLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!bancosalarioLookUpEdit.IsModified)
                return;

            funcionarioDTO.Bancosalario = (BancoDTO)bancosalarioLookUpEdit.Properties.GetDataSourceRowByKeyValue(bancosalarioLookUpEdit.EditValue);
            if (funcionarioDTO.Bancosalario == null)
                funcionarioDTO.Bancosalario = new BancoDTO();
        }

        private void tipocontacomboBoxEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!tipocontacomboBoxEdit.IsModified)
                return;

            if (tipocontacomboBoxEdit.EditValue == null)
                tipocontacomboBoxEdit.EditValue = string.Empty;
        }

        private void UFRGLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!UFRGLookUpEdit.IsModified)
                return;

            funcionarioDTO.Documento.UFRG = (UFDTO)UFRGLookUpEdit.Properties.GetDataSourceRowByKeyValue(UFRGLookUpEdit.EditValue);
            if (funcionarioDTO.Documento.UFRG == null)
                funcionarioDTO.Documento.UFRG = new UFDTO();
        }

        private void codigoibgeButtonEdit_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}