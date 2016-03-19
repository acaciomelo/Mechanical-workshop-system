namespace MechTech.UI.Utilitarios
{
    partial class frmTrocaSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrocaSenha));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnSalvar = new DevExpress.XtraEditors.SimpleButton();
            this.RedigiteTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NovaSenhaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SenhaAtualTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblSenhaAtual = new DevExpress.XtraEditors.LabelControl();
            this.lblUsuario = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.RedigiteTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NovaSenhaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SenhaAtualTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(310, 102);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(229, 102);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 18;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // RedigiteTextEdit
            // 
            this.RedigiteTextEdit.EnterMoveNextControl = true;
            this.RedigiteTextEdit.Location = new System.Drawing.Point(140, 76);
            this.RedigiteTextEdit.Name = "RedigiteTextEdit";
            this.RedigiteTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RedigiteTextEdit.Properties.MaxLength = 48;
            this.RedigiteTextEdit.Properties.PasswordChar = '*';
            this.RedigiteTextEdit.Size = new System.Drawing.Size(245, 20);
            this.RedigiteTextEdit.TabIndex = 17;
            // 
            // NovaSenhaTextEdit
            // 
            this.NovaSenhaTextEdit.EnterMoveNextControl = true;
            this.NovaSenhaTextEdit.Location = new System.Drawing.Point(140, 54);
            this.NovaSenhaTextEdit.Name = "NovaSenhaTextEdit";
            this.NovaSenhaTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NovaSenhaTextEdit.Properties.MaxLength = 48;
            this.NovaSenhaTextEdit.Properties.PasswordChar = '*';
            this.NovaSenhaTextEdit.Size = new System.Drawing.Size(245, 20);
            this.NovaSenhaTextEdit.TabIndex = 16;
            // 
            // SenhaAtualTextEdit
            // 
            this.SenhaAtualTextEdit.EnterMoveNextControl = true;
            this.SenhaAtualTextEdit.Location = new System.Drawing.Point(140, 32);
            this.SenhaAtualTextEdit.Name = "SenhaAtualTextEdit";
            this.SenhaAtualTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SenhaAtualTextEdit.Properties.MaxLength = 48;
            this.SenhaAtualTextEdit.Properties.PasswordChar = '*';
            this.SenhaAtualTextEdit.Size = new System.Drawing.Size(245, 20);
            this.SenhaAtualTextEdit.TabIndex = 15;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(6, 79);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(128, 13);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "Redigite a nova senha:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(6, 57);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 13);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Nova senha:";
            // 
            // lblSenhaAtual
            // 
            this.lblSenhaAtual.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenhaAtual.Location = new System.Drawing.Point(6, 35);
            this.lblSenhaAtual.Name = "lblSenhaAtual";
            this.lblSenhaAtual.Size = new System.Drawing.Size(70, 13);
            this.lblSenhaAtual.TabIndex = 12;
            this.lblSenhaAtual.Text = "Senha atual:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblUsuario.Location = new System.Drawing.Point(140, 5);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(134, 13);
            this.lblUsuario.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(6, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Usuário:";
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Black";
            // 
            // frmTrocaSenha
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 132);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.RedigiteTextEdit);
            this.Controls.Add(this.NovaSenhaTextEdit);
            this.Controls.Add(this.SenhaAtualTextEdit);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lblSenhaAtual);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmTrocaSenha";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmTrocaSenha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RedigiteTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NovaSenhaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SenhaAtualTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnSalvar;
        private DevExpress.XtraEditors.TextEdit RedigiteTextEdit;
        private DevExpress.XtraEditors.TextEdit NovaSenhaTextEdit;
        private DevExpress.XtraEditors.TextEdit SenhaAtualTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblSenhaAtual;
        private DevExpress.XtraEditors.LabelControl lblUsuario;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
    }
}