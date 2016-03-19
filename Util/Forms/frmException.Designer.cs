namespace MechTech.Util.Forms
{
    partial class frmException
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmException));
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.ExceptionMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.SendMailPictureBox = new System.Windows.Forms.PictureBox();
            this.lblSendMail = new DevExpress.XtraEditors.LabelControl();
            this.btnEncerrar = new DevExpress.XtraEditors.SimpleButton();
            this.btnContinuar = new DevExpress.XtraEditors.SimpleButton();
            this.LinkLabel3 = new System.Windows.Forms.LinkLabel();
            this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
            this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExceptionMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendMailPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(50, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(388, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Uma excessão ocorreu durante a tentativa de execução de uma ação específica.";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(12, 179);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(37, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Ações:";
            // 
            // ExceptionMemoEdit
            // 
            this.ExceptionMemoEdit.EditValue = "";
            this.ExceptionMemoEdit.Location = new System.Drawing.Point(12, 68);
            this.ExceptionMemoEdit.Name = "ExceptionMemoEdit";
            this.ExceptionMemoEdit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ExceptionMemoEdit.Properties.Appearance.Options.UseBackColor = true;
            this.ExceptionMemoEdit.Properties.ReadOnly = true;
            this.ExceptionMemoEdit.Size = new System.Drawing.Size(426, 96);
            this.ExceptionMemoEdit.TabIndex = 5;
            this.ExceptionMemoEdit.UseOptimizedRendering = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(12, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Motivo:";
            // 
            // SendMailPictureBox
            // 
            this.SendMailPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.SendMailPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("SendMailPictureBox.Image")));
            this.SendMailPictureBox.Location = new System.Drawing.Point(15, 270);
            this.SendMailPictureBox.Name = "SendMailPictureBox";
            this.SendMailPictureBox.Size = new System.Drawing.Size(16, 16);
            this.SendMailPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.SendMailPictureBox.TabIndex = 19;
            this.SendMailPictureBox.TabStop = false;
            this.SendMailPictureBox.Visible = false;
            // 
            // lblSendMail
            // 
            this.lblSendMail.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSendMail.Location = new System.Drawing.Point(35, 270);
            this.lblSendMail.Name = "lblSendMail";
            this.lblSendMail.Size = new System.Drawing.Size(244, 16);
            this.lblSendMail.TabIndex = 18;
            this.lblSendMail.Text = "Enviando...";
            this.lblSendMail.Visible = false;
            // 
            // btnEncerrar
            // 
            this.btnEncerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnEncerrar.Image")));
            this.btnEncerrar.Location = new System.Drawing.Point(366, 263);
            this.btnEncerrar.Name = "btnEncerrar";
            this.btnEncerrar.Size = new System.Drawing.Size(75, 23);
            this.btnEncerrar.TabIndex = 17;
            this.btnEncerrar.Text = "&Encerrar";
            this.btnEncerrar.Click += new System.EventHandler(this.btnEncerrar_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Image = ((System.Drawing.Image)(resources.GetObject("btnContinuar.Image")));
            this.btnContinuar.Location = new System.Drawing.Point(285, 263);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(75, 23);
            this.btnContinuar.TabIndex = 16;
            this.btnContinuar.Text = "&Continuar";
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // LinkLabel3
            // 
            this.LinkLabel3.AutoSize = true;
            this.LinkLabel3.Location = new System.Drawing.Point(12, 238);
            this.LinkLabel3.Name = "LinkLabel3";
            this.LinkLabel3.Size = new System.Drawing.Size(229, 13);
            this.LinkLabel3.TabIndex = 15;
            this.LinkLabel3.TabStop = true;
            this.LinkLabel3.Text = "Enviar detalhes da excessão para a MechTech";
            this.LinkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel3_LinkClicked);
            // 
            // LinkLabel2
            // 
            this.LinkLabel2.AutoSize = true;
            this.LinkLabel2.Location = new System.Drawing.Point(12, 216);
            this.LinkLabel2.Name = "LinkLabel2";
            this.LinkLabel2.Size = new System.Drawing.Size(286, 13);
            this.LinkLabel2.TabIndex = 14;
            this.LinkLabel2.TabStop = true;
            this.LinkLabel2.Text = "Copiar detalhes da excessão para a área de transferência";
            this.LinkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel2_LinkClicked);
            // 
            // LinkLabel1
            // 
            this.LinkLabel1.AutoSize = true;
            this.LinkLabel1.Location = new System.Drawing.Point(12, 194);
            this.LinkLabel1.Name = "LinkLabel1";
            this.LinkLabel1.Size = new System.Drawing.Size(79, 13);
            this.LinkLabel1.TabIndex = 13;
            this.LinkLabel1.TabStop = true;
            this.LinkLabel1.Text = "Ver detalhes...";
            this.LinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // frmException
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 309);
            this.ControlBox = false;
            this.Controls.Add(this.SendMailPictureBox);
            this.Controls.Add(this.lblSendMail);
            this.Controls.Add(this.btnEncerrar);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.LinkLabel3);
            this.Controls.Add(this.LinkLabel2);
            this.Controls.Add(this.LinkLabel1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.ExceptionMemoEdit);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmException";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Controle de Excessões";
            this.Shown += new System.EventHandler(this.frmException_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExceptionMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendMailPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit ExceptionMemoEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox SendMailPictureBox;
        private DevExpress.XtraEditors.LabelControl lblSendMail;
        private DevExpress.XtraEditors.SimpleButton btnEncerrar;
        private DevExpress.XtraEditors.SimpleButton btnContinuar;
        private System.Windows.Forms.LinkLabel LinkLabel3;
        private System.Windows.Forms.LinkLabel LinkLabel2;
        private System.Windows.Forms.LinkLabel LinkLabel1;
    }
}