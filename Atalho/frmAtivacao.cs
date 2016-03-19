using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MechTech.WebServices;

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Forms;
using MechTech.Entities;
using MechTech.Business;
using MechTech.Atualizacao;
using MechTech.Data;
using MechTech;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
#endregion

namespace MechTech.Atalho
{
    public partial class frmAtivacao : DevExpress.XtraEditors.XtraForm
    {
        WebServices.Ativacao wsativacao = new WebServices.Ativacao();
        AtivacaoDAO ativacaoDao = new AtivacaoDAO();

        public frmAtivacao()
        {
            InitializeComponent();
        }

        public bool Ativar()
        {
            if (ValidarCamposObrigatorios())
                return false;

            var razaosocial = txt_Razao.Text.Trim();
            var ip = wsativacao.GetIp();
            var nomeMaquina = System.Environment.MachineName;

            if (!wsativacao.RazaoSocialJaExisteServidorOnline(razaosocial))
            {
                wsativacao.InserirClienteServidor(txt_Razao.Text.Trim(), txt_cnpj.Text.Trim(), txt_Endereco.Text.Trim(), txt_Cidade.Text.Trim(), txt_Bairro.Text.Trim(), txt_num.Text.Trim(), txt_Cep.Text.Trim(), cmbUF.SelectedText, txt_Email.Text.Trim(), txt_Contato.Text.Trim(), txt_Telefone.Text.Trim(), ip);
                ativacaoDao.InserirClienteLocal(txt_Razao.Text.Trim());
            }

            if (!wsativacao.IPJaExisteServidorOnline(ip, nomeMaquina))
                wsativacao.InserirMaquinaServidor(razaosocial, ip);
            else
            {
                dxErrorProvider.ClearErrors();
                dxErrorProvider.SetError(txt_Razao, "Máquina já cadastrada para essa razão social.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                return false;
            }

            return true;
        }

        public bool ValidarCamposObrigatorios()
        {
            dxErrorProvider.ClearErrors();

            if (txt_cnpj.Text.Equals(string.Empty))
                dxErrorProvider.SetError(txt_Razao, "CNPJ é um campo obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            else if (!Documentos.ValidarCNPJ(txt_cnpj.Text.Trim()))
                dxErrorProvider.SetError(txt_cnpj, "CNPJ inválido.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);

            if (txt_Razao.Text.Equals(string.Empty))
                dxErrorProvider.SetError(txt_Razao, "Razão Social é um campo obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (txt_Endereco.Text.Equals(string.Empty))
                dxErrorProvider.SetError(txt_Endereco, "Endereço é um campo obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (txt_num.Text.Equals(string.Empty))
                dxErrorProvider.SetError(txt_num, "Número é um campo obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (cmbUF.SelectedText.Equals(string.Empty))
                dxErrorProvider.SetError(cmbUF, "Unidade federativa é um campo obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (txt_Cidade.Text.Equals(string.Empty))
                dxErrorProvider.SetError(txt_Cidade, "Cidade é um campo obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (txt_Bairro.Text.Equals(string.Empty))
                dxErrorProvider.SetError(txt_Bairro, "Bairro é um campo obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (txt_Telefone.Text.Equals(string.Empty))
                dxErrorProvider.SetError(txt_Telefone, "Telefone é um campo obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (dxErrorProvider.HasErrors)
                MessageBox.Show("O Sistema identificou campos obrigatórios não preenchidos ou preenchidos incorretamente. Impossível prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return dxErrorProvider.HasErrors;
        }

        private void txt_ativar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Ativar())
                {
                    MessageBox.Show("Parabéns! O sistema foi ativado, por favor reinicie o sistema.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o erro: " + ex);
                this.Close();
            }
        }

        private void txt_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_cnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Cep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Telefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbUF_Validating(object sender, CancelEventArgs e)
        {
            if (cmbUF.Items.Contains(cmbUF.SelectedText))
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}



