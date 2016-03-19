namespace MechTech.Atalho
{
    partial class frmAtivacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAtivacao));
            this.gcOficina = new DevExpress.XtraEditors.GroupControl();
            this.txt_Telefone = new DevExpress.XtraEditors.TextEdit();
            this.btn_Cancelar = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollectionSmall = new DevExpress.Utils.ImageCollection();
            this.btn_ativar = new DevExpress.XtraEditors.SimpleButton();
            this.txt_num = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Cep = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Contato = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Email = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txt_cnpj = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Bairro = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Cidade = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Endereco = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Razao = new DevExpress.XtraEditors.TextEdit();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            this.cmbUF = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gcOficina)).BeginInit();
            this.gcOficina.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Telefone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_num.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Cep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Contato.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cnpj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Bairro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Cidade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Endereco.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Razao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gcOficina
            // 
            this.gcOficina.AppearanceCaption.Options.UseTextOptions = true;
            this.gcOficina.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcOficina.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.gcOficina.Controls.Add(this.cmbUF);
            this.gcOficina.Controls.Add(this.txt_Telefone);
            this.gcOficina.Controls.Add(this.btn_Cancelar);
            this.gcOficina.Controls.Add(this.btn_ativar);
            this.gcOficina.Controls.Add(this.txt_num);
            this.gcOficina.Controls.Add(this.labelControl5);
            this.gcOficina.Controls.Add(this.label13);
            this.gcOficina.Controls.Add(this.txt_Cep);
            this.gcOficina.Controls.Add(this.labelControl10);
            this.gcOficina.Controls.Add(this.labelControl9);
            this.gcOficina.Controls.Add(this.txt_Contato);
            this.gcOficina.Controls.Add(this.labelControl8);
            this.gcOficina.Controls.Add(this.txt_Email);
            this.gcOficina.Controls.Add(this.labelControl7);
            this.gcOficina.Controls.Add(this.txt_cnpj);
            this.gcOficina.Controls.Add(this.labelControl6);
            this.gcOficina.Controls.Add(this.labelControl4);
            this.gcOficina.Controls.Add(this.txt_Bairro);
            this.gcOficina.Controls.Add(this.labelControl3);
            this.gcOficina.Controls.Add(this.txt_Cidade);
            this.gcOficina.Controls.Add(this.labelControl1);
            this.gcOficina.Controls.Add(this.txt_Endereco);
            this.gcOficina.Controls.Add(this.labelControl2);
            this.gcOficina.Controls.Add(this.txt_Razao);
            this.gcOficina.Location = new System.Drawing.Point(1, 0);
            this.gcOficina.Name = "gcOficina";
            this.gcOficina.Size = new System.Drawing.Size(552, 215);
            this.gcOficina.TabIndex = 0;
            this.gcOficina.Text = "Ativação";
            // 
            // txt_Telefone
            // 
            this.txt_Telefone.EnterMoveNextControl = true;
            this.txt_Telefone.Location = new System.Drawing.Point(360, 139);
            this.txt_Telefone.Name = "txt_Telefone";
            this.txt_Telefone.Properties.Mask.EditMask = "(99) 99999-9999";
            this.txt_Telefone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txt_Telefone.Properties.Mask.SaveLiteral = false;
            this.txt_Telefone.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txt_Telefone.Properties.MaxLength = 15;
            this.txt_Telefone.Size = new System.Drawing.Size(182, 20);
            this.txt_Telefone.TabIndex = 10;
            this.txt_Telefone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Telefone_KeyPress);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.ImageIndex = 1;
            this.btn_Cancelar.ImageList = this.imageCollectionSmall;
            this.btn_Cancelar.Location = new System.Drawing.Point(461, 172);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(82, 30);
            this.btn_Cancelar.TabIndex = 61;
            this.btn_Cancelar.Text = "&Cancelar";
            this.btn_Cancelar.Click += new System.EventHandler(this.txt_Cancelar_Click);
            // 
            // imageCollectionSmall
            // 
            this.imageCollectionSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionSmall.ImageStream")));
            this.imageCollectionSmall.Images.SetKeyName(0, "members_unlock_16.png");
            this.imageCollectionSmall.Images.SetKeyName(1, "stop_cancel_16.png");
            // 
            // btn_ativar
            // 
            this.btn_ativar.ImageIndex = 0;
            this.btn_ativar.ImageList = this.imageCollectionSmall;
            this.btn_ativar.Location = new System.Drawing.Point(373, 172);
            this.btn_ativar.Name = "btn_ativar";
            this.btn_ativar.Size = new System.Drawing.Size(82, 30);
            this.btn_ativar.TabIndex = 60;
            this.btn_ativar.Text = "&Ativar";
            this.btn_ativar.Click += new System.EventHandler(this.txt_ativar_Click);
            // 
            // txt_num
            // 
            this.txt_num.EnterMoveNextControl = true;
            this.txt_num.Location = new System.Drawing.Point(481, 61);
            this.txt_num.Name = "txt_num";
            this.txt_num.Properties.MaxLength = 4;
            this.txt_num.Size = new System.Drawing.Size(61, 20);
            this.txt_num.TabIndex = 4;
            this.txt_num.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_num_KeyPress);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(455, 64);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(16, 13);
            this.labelControl5.TabIndex = 58;
            this.labelControl5.Text = "Nº:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(24, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 13);
            this.label13.TabIndex = 57;
            this.label13.Text = "UF:";
            // 
            // txt_Cep
            // 
            this.txt_Cep.EnterMoveNextControl = true;
            this.txt_Cep.Location = new System.Drawing.Point(162, 87);
            this.txt_Cep.Name = "txt_Cep";
            this.txt_Cep.Properties.Mask.EditMask = "99999-999";
            this.txt_Cep.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txt_Cep.Properties.MaxLength = 9;
            this.txt_Cep.Size = new System.Drawing.Size(133, 20);
            this.txt_Cep.TabIndex = 6;
            this.txt_Cep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Cep_KeyPress);
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(135, 89);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(23, 13);
            this.labelControl10.TabIndex = 27;
            this.labelControl10.Text = "CEP:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(305, 143);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(46, 13);
            this.labelControl9.TabIndex = 25;
            this.labelControl9.Text = "Telefone:";
            // 
            // txt_Contato
            // 
            this.txt_Contato.EnterMoveNextControl = true;
            this.txt_Contato.Location = new System.Drawing.Point(87, 139);
            this.txt_Contato.Name = "txt_Contato";
            this.txt_Contato.Properties.MaxLength = 50;
            this.txt_Contato.Size = new System.Drawing.Size(208, 20);
            this.txt_Contato.TabIndex = 9;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(27, 145);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(43, 13);
            this.labelControl8.TabIndex = 23;
            this.labelControl8.Text = "Contato:";
            // 
            // txt_Email
            // 
            this.txt_Email.EnterMoveNextControl = true;
            this.txt_Email.Location = new System.Drawing.Point(87, 113);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Properties.MaxLength = 100;
            this.txt_Email.Size = new System.Drawing.Size(455, 20);
            this.txt_Email.TabIndex = 8;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(27, 119);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(32, 13);
            this.labelControl7.TabIndex = 21;
            this.labelControl7.Text = "E-mail:";
            // 
            // txt_cnpj
            // 
            this.txt_cnpj.EnterMoveNextControl = true;
            this.txt_cnpj.Location = new System.Drawing.Point(339, 87);
            this.txt_cnpj.Name = "txt_cnpj";
            this.txt_cnpj.Properties.Mask.EditMask = "99.999.999/9999-99";
            this.txt_cnpj.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txt_cnpj.Properties.MaxLength = 17;
            this.txt_cnpj.Size = new System.Drawing.Size(203, 20);
            this.txt_cnpj.TabIndex = 7;
            this.txt_cnpj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cnpj_KeyPress);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(305, 89);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(29, 13);
            this.labelControl6.TabIndex = 19;
            this.labelControl6.Text = "CNPJ:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(301, 64);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(32, 13);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "Bairro:";
            // 
            // txt_Bairro
            // 
            this.txt_Bairro.EnterMoveNextControl = true;
            this.txt_Bairro.Location = new System.Drawing.Point(339, 61);
            this.txt_Bairro.Name = "txt_Bairro";
            this.txt_Bairro.Properties.MaxLength = 50;
            this.txt_Bairro.Size = new System.Drawing.Size(110, 20);
            this.txt_Bairro.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(25, 64);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(37, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Cidade:";
            // 
            // txt_Cidade
            // 
            this.txt_Cidade.EnterMoveNextControl = true;
            this.txt_Cidade.Location = new System.Drawing.Point(88, 61);
            this.txt_Cidade.Name = "txt_Cidade";
            this.txt_Cidade.Properties.MaxLength = 80;
            this.txt_Cidade.Size = new System.Drawing.Size(207, 20);
            this.txt_Cidade.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Endereço:";
            // 
            // txt_Endereco
            // 
            this.txt_Endereco.EnterMoveNextControl = true;
            this.txt_Endereco.Location = new System.Drawing.Point(88, 35);
            this.txt_Endereco.Name = "txt_Endereco";
            this.txt_Endereco.Properties.MaxLength = 100;
            this.txt_Endereco.Size = new System.Drawing.Size(454, 20);
            this.txt_Endereco.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Razão Social:";
            // 
            // txt_Razao
            // 
            this.txt_Razao.EnterMoveNextControl = true;
            this.txt_Razao.Location = new System.Drawing.Point(88, 9);
            this.txt_Razao.Name = "txt_Razao";
            this.txt_Razao.Properties.MaxLength = 100;
            this.txt_Razao.Size = new System.Drawing.Size(454, 20);
            this.txt_Razao.TabIndex = 0;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // cmbUF
            // 
            this.cmbUF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUF.DropDownHeight = 110;
            this.cmbUF.DropDownWidth = 50;
            this.cmbUF.FormattingEnabled = true;
            this.cmbUF.IntegralHeight = false;
            this.cmbUF.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AM",
            "AP",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MG",
            "MS",
            "MT",
            "PA",
            "PB",
            "PE",
            "PI",
            "PR",
            "RJ",
            "RN",
            "RO",
            "RR",
            "RS",
            "SC",
            "SE",
            "SP",
            "TO"});
            this.cmbUF.Location = new System.Drawing.Point(88, 86);
            this.cmbUF.MaxDropDownItems = 15;
            this.cmbUF.MaxLength = 2;
            this.cmbUF.Name = "cmbUF";
            this.cmbUF.Size = new System.Drawing.Size(42, 21);
            this.cmbUF.TabIndex = 5;
            this.cmbUF.Validating += new System.ComponentModel.CancelEventHandler(this.cmbUF_Validating);
            // 
            // frmAtivacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 214);
            this.ControlBox = false;
            this.Controls.Add(this.gcOficina);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAtivacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ativação MechTech";
            ((System.ComponentModel.ISupportInitialize)(this.gcOficina)).EndInit();
            this.gcOficina.ResumeLayout(false);
            this.gcOficina.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Telefone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_num.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Cep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Contato.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cnpj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Bairro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Cidade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Endereco.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Razao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcOficina;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_Endereco;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_Razao;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_Cidade;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txt_Contato;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txt_Email;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txt_cnpj;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txt_Bairro;
        private DevExpress.XtraEditors.TextEdit txt_Cep;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.TextEdit txt_num;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btn_ativar;
        private DevExpress.XtraEditors.SimpleButton btn_Cancelar;
        private DevExpress.XtraEditors.TextEdit txt_Telefone;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.Utils.ImageCollection imageCollectionSmall;
        private System.Windows.Forms.ComboBox cmbUF;
    }
}