using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using MechTech.Entities;
using MechTech.Util.Forms;
using MechTech.Util;

namespace MechTech
{
    public partial class frmUpdateConexoes : DevExpress.XtraEditors.XtraForm
    {
        bool isSerializable = false;
        bool cancelarPressionado = true;
        public Form frmGrid { get; set; }
        public Enumeradores.TipoOperacao tpOperacao { get; set; }

        public ConexoesDTO conexaoDTO { get; set; }
        public ConexoesDTO conexaoDTOVersaoOriginal { get; set; }
        BindingSource bndConexaoGrid = new BindingSource();
        public frmUpdateConexoes()
        {
            InitializeComponent();
            isSerializable = true;

            try
            {
                tpOperacao = Enumeradores.TipoOperacao.Insert;
                ConexaoDTOBindingSource.AddNew();
                conexaoDTO = (ConexoesDTO)ConexaoDTOBindingSource.Current;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                "Motivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public frmUpdateConexoes(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndConexaoGrid = bnd;

                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                    ConexaoDTOBindingSource.AddNew();
                else
                {
                    conexaoDTO = (ConexoesDTO)bndConexaoGrid.Current;
                    ConexaoDTOBindingSource.DataSource = conexaoDTO;
                    conexaoDTOVersaoOriginal = new ConexoesDTO(conexaoDTO);
                }

                conexaoDTO = (ConexoesDTO)ConexaoDTOBindingSource.Current;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                "Motivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmUpdateConexoes_Load(object sender, EventArgs e)
        {
            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Conexão";
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Conexão";
                    break;
                default:
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
            cancelarPressionado = true;
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Salvar();
        }

        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors(); // Elimina todo os erros da janela

            if (conexaoDTO.Empresa == string.Empty)
                dxErrorProvider.SetError(txtEmpresa, "Empresa inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (conexaoDTO.Usuario == string.Empty)
                dxErrorProvider.SetError(txtUsuario, "Usuário inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (conexaoDTO.Senha == string.Empty)
                dxErrorProvider.SetError(txtSenha, "Senha inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (conexaoDTO.Servidor == string.Empty)
                dxErrorProvider.SetError(txtServidor, "Servidor inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (conexaoDTO.Banco == string.Empty)
                dxErrorProvider.SetError(txtBanco, "Banco de dados inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (conexaoDTO.Porta == string.Empty)
                dxErrorProvider.SetError(txtPorta, "Porta inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            return dxErrorProvider.HasErrors;
        }
        private void Salvar()
        {
            try
            {
                if (this.ValidaCampos()) return;

                Cursor = Cursors.WaitCursor;
                //VALIDAR CONFIGURAÇÃO
                using (frmWait wait = new frmWait("Testando conexão com o Banco de Dados..."))
                {
                    wait.Show();
                    Application.DoEvents();
                    if (!ping.Send(conexaoDTO))
                    {
                        MessageBox.Show("Não foi possível estabelecer uma conexão válida. Verifique os dados informados e tente novamente.", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cursor = Cursors.Default;
                        wait.Close();
                        return;
                    }
                    wait.Close();
                }
                if (isSerializable)
                {
                    //APLICAR DIRETIVAS DE SEGURANÇA

                    conexaoDTO.Conexoes.Add(conexaoDTO);
                    conexaoDTO.Serializar();
                }
                else
                {
                    switch (tpOperacao)
                    {
                        case Enumeradores.TipoOperacao.Insert:
                            bndConexaoGrid.Add(ConexaoDTOBindingSource.Current);
                            break;
                        case Enumeradores.TipoOperacao.Update:
                            bndConexaoGrid.List[bndConexaoGrid.Position] = ConexaoDTOBindingSource.Current;
                            break;
                    }
                }
                DialogResult = DialogResult.OK;
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
        private void frmUpdateConexoes_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (tpOperacao.Equals(Enumeradores.TipoOperacao.Update) && cancelarPressionado)
                bndConexaoGrid.List[bndConexaoGrid.Position] = conexaoDTOVersaoOriginal;
        }
    }
}