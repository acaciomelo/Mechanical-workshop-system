namespace MechTech.UI.Utilitarios
{
    partial class frmMessageBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.lstMessage = new DevExpress.XtraEditors.ListBoxControl();
            this.chkCloseAll = new DevExpress.XtraEditors.CheckEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.lstMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCloseAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMessage.Location = new System.Drawing.Point(12, 12);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(448, 27);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "O Sistema identificou tela(s) aberta(s) durante o processo solicitado. Para a efe" +
    "tivação desse procedimento é necessário o fechamento do(s) seguinte(s) ítem(ns) " +
    "listado(s) abaixo:";
            // 
            // lstMessage
            // 
            this.lstMessage.Location = new System.Drawing.Point(12, 43);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(448, 187);
            this.lstMessage.TabIndex = 4;
            // 
            // chkCloseAll
            // 
            this.chkCloseAll.Location = new System.Drawing.Point(12, 238);
            this.chkCloseAll.Name = "chkCloseAll";
            this.chkCloseAll.Properties.Caption = "Fechar todas as telas abertas agora";
            this.chkCloseAll.Size = new System.Drawing.Size(369, 19);
            this.chkCloseAll.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(385, 236);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // frmMessageBox
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 266);
            this.Controls.Add(this.chkCloseAll);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lstMessage);
            this.Controls.Add(this.lblMessage);
            this.Name = "frmMessageBox";
            this.Text = "MECHTECH";
            ((System.ComponentModel.ISupportInitialize)(this.lstMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCloseAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblMessage;
        public DevExpress.XtraEditors.ListBoxControl lstMessage;
        private DevExpress.XtraEditors.CheckEdit chkCloseAll;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}