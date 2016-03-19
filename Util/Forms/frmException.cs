using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

using DevExpress.XtraEditors;
using MechTech.Util.Templates;

namespace MechTech.Util.Forms
{
    public partial class frmException : frmBase
    {
        Exception ex = null;
        public frmException(Exception ex)
        {
            InitializeComponent();

            ExceptionMemoEdit.Text = ex.Message;
            this.ex = ex;
        }

        public frmException(Exception ex, bool continar)
        {
            InitializeComponent();

            if (!continar)
                btnContinuar.Visible = false;

            ExceptionMemoEdit.Text = ex.Message;
            this.ex = ex;
        }

        private void frmException_Shown(object sender, EventArgs e)
        {
            btnContinuar.Focus();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmExceptionDetail(this.ex).ShowDialog();
            btnContinuar.Focus();
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(GetStackTrace());
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
        }
        private string GetStackTrace()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Motivo: \"" + ex.Message + "\"");
            sb.AppendLine("Fonte: \"" + ex.Source + "\"");
            sb.AppendLine("Rastreamento de pilha:");
            sb.Append(ex.StackTrace);

            return sb.ToString();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
                this.Close();
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
                Application.Exit();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker.ReportProgress(0);
            try
            {

                string filial = Global.Filial.ToString() + "-" + Global.LicencaUso.ToUpper();
                string filialinfo = "=======" + new String('=', filial.Length + 1) + Environment.NewLine +
                                    "Filial: " + filial + Environment.NewLine +
                                    "Versão: " + Global.VersaoSistema + Environment.NewLine +
                                    "=======" + new String('=', filial.Length + 1) + Environment.NewLine + Environment.NewLine;

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("mechtechsoftwares@gmail.com", "476445036");

                MailMessage mm = new MailMessage(Global.Sistema.ToString().ToLower() + "@mechtech.inf.br", "acacio.melo@outlook.com", "Central de Excessões (" + Global.Sistema.ToString().ToUpper() + ")", filialinfo + GetStackTrace());
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
            }
            catch { }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SendMailPictureBox.Visible = true;
            lblSendMail.Visible = true;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SendMailPictureBox.Visible = false;
            lblSendMail.Visible = false;
            MessageBox.Show("Excessão enviada com sucesso para a MechTech.\n\n" +
                            "Agradecemos sua colaboração para tornarmos o " + Global.Sistema + " um produto ainda melhor. " +
                            "Em breve, nossos técnicos estarão analisando essa ocorrência e providenciando a solução da mesma o mais rápido possível.\n\n" +
                            "Desculpe-nos pelo transtorno e obrigado pela compreensão.", "Central de Excessões", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnContinuar.Focus();
        }
    }
}