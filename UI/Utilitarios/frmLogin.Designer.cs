namespace MechTech.UI.Utilitarios
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnTrocaSenha = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.SenhaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.UsuarioTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.lblLicenca = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.SenhaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTrocaSenha
            // 
            this.btnTrocaSenha.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnTrocaSenha.Appearance.Options.UseBackColor = true;
            this.btnTrocaSenha.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTrocaSenha.Image = ((System.Drawing.Image)(resources.GetObject("btnTrocaSenha.Image")));
            this.btnTrocaSenha.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnTrocaSenha.Location = new System.Drawing.Point(358, 186);
            this.btnTrocaSenha.Name = "btnTrocaSenha";
            this.btnTrocaSenha.Size = new System.Drawing.Size(24, 23);
            this.btnTrocaSenha.TabIndex = 13;
            this.btnTrocaSenha.TabStop = false;
            this.btnTrocaSenha.ToolTip = "Trocar senha de acesso";
            this.btnTrocaSenha.Click += new System.EventHandler(this.btnTrocaSenha_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(4, 165);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Usuário:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(308, 214);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(227, 214);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SenhaTextEdit
            // 
            this.SenhaTextEdit.EditValue = "";
            this.SenhaTextEdit.Location = new System.Drawing.Point(101, 188);
            this.SenhaTextEdit.Name = "SenhaTextEdit";
            this.SenhaTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SenhaTextEdit.Properties.MaxLength = 48;
            this.SenhaTextEdit.Properties.PasswordChar = '*';
            this.SenhaTextEdit.Size = new System.Drawing.Size(251, 20);
            this.SenhaTextEdit.TabIndex = 10;
            this.SenhaTextEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SenhaTextEdit_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(4, 191);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 13);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Senha:";
            // 
            // UsuarioTextEdit
            // 
            this.UsuarioTextEdit.EditValue = "";
            this.UsuarioTextEdit.Location = new System.Drawing.Point(101, 162);
            this.UsuarioTextEdit.Name = "UsuarioTextEdit";
            this.UsuarioTextEdit.Properties.MaxLength = 15;
            this.UsuarioTextEdit.Size = new System.Drawing.Size(281, 20);
            this.UsuarioTextEdit.TabIndex = 9;
            this.UsuarioTextEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UsuarioTextEdit_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(4, 136);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Licenciado para:";
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Black";
            // 
            // lblLicenca
            // 
            this.lblLicenca.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLicenca.Location = new System.Drawing.Point(101, 136);
            this.lblLicenca.Name = "lblLicenca";
            this.lblLicenca.Size = new System.Drawing.Size(282, 13);
            this.lblLicenca.TabIndex = 17;
            // 
            // frmLogin
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 243);
            this.ControlBox = false;
            this.Controls.Add(this.lblLicenca);
            this.Controls.Add(this.btnTrocaSenha);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.SenhaTextEdit);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.UsuarioTextEdit);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Shown += new System.EventHandler(this.frmLogin_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.SenhaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnTrocaSenha;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.TextEdit SenhaTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit UsuarioTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.XtraEditors.LabelControl lblLicenca;
    }
}