namespace MechTech
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ConexoesLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.ddbConectar = new DevExpress.XtraEditors.DropDownButton();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.CarregandoPictureBox = new System.Windows.Forms.PictureBox();
            this.CopiandoPictureBox = new System.Windows.Forms.PictureBox();
            this.AtualizacaoPictureBox = new System.Windows.Forms.PictureBox();
            this.ConexaoPictureBox = new System.Windows.Forms.PictureBox();
            this.ConexaoDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ConexoesLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarregandoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CopiandoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AtualizacaoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConexaoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConexaoDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Testando conexão com o Banco de Dados...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Procurando por atualizações...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Copiando novos arquivos...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Carregando o Sistema...";
            // 
            // ConexoesLookUpEdit
            // 
            this.ConexoesLookUpEdit.EditValue = "";
            this.ConexoesLookUpEdit.EnterMoveNextControl = true;
            this.ConexoesLookUpEdit.Location = new System.Drawing.Point(75, 77);
            this.ConexoesLookUpEdit.Name = "ConexoesLookUpEdit";
            this.ConexoesLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.ConexoesLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ConexoesLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ConexoesLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Empresa", 250, "Empresa"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Servidor", 250, "Servidor"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Banco", 250, "Banco")});
            this.ConexoesLookUpEdit.Properties.DataSource = this.ConexaoDTOBindingSource;
            this.ConexoesLookUpEdit.Properties.DisplayMember = "Empresa";
            this.ConexoesLookUpEdit.Properties.HeaderClickMode = DevExpress.XtraEditors.Controls.HeaderClickMode.AutoSearch;
            this.ConexoesLookUpEdit.Properties.NullText = "";
            this.ConexoesLookUpEdit.Properties.PopupSizeable = false;
            this.ConexoesLookUpEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.ConexoesLookUpEdit.Properties.ValueMember = "Empresa";
            this.ConexoesLookUpEdit.Size = new System.Drawing.Size(237, 20);
            this.ConexoesLookUpEdit.TabIndex = 1;
            this.ConexoesLookUpEdit.EditValueChanged += new System.EventHandler(this.ConexoesLookUpEdit_EditValueChanged);
            // 
            // ddbConectar
            // 
            this.ddbConectar.Location = new System.Drawing.Point(75, 104);
            this.ddbConectar.Name = "ddbConectar";
            this.ddbConectar.Size = new System.Drawing.Size(237, 23);
            this.ddbConectar.TabIndex = 2;
            this.ddbConectar.Text = "Conectar";
            this.ddbConectar.Click += new System.EventHandler(this.ddbConectar_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // CarregandoPictureBox
            // 
            this.CarregandoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("CarregandoPictureBox.Image")));
            this.CarregandoPictureBox.Location = new System.Drawing.Point(75, 58);
            this.CarregandoPictureBox.Name = "CarregandoPictureBox";
            this.CarregandoPictureBox.Size = new System.Drawing.Size(16, 16);
            this.CarregandoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.CarregandoPictureBox.TabIndex = 8;
            this.CarregandoPictureBox.TabStop = false;
            this.CarregandoPictureBox.Visible = false;
            // 
            // CopiandoPictureBox
            // 
            this.CopiandoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("CopiandoPictureBox.Image")));
            this.CopiandoPictureBox.Location = new System.Drawing.Point(75, 42);
            this.CopiandoPictureBox.Name = "CopiandoPictureBox";
            this.CopiandoPictureBox.Size = new System.Drawing.Size(16, 16);
            this.CopiandoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.CopiandoPictureBox.TabIndex = 7;
            this.CopiandoPictureBox.TabStop = false;
            this.CopiandoPictureBox.Visible = false;
            // 
            // AtualizacaoPictureBox
            // 
            this.AtualizacaoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AtualizacaoPictureBox.Image")));
            this.AtualizacaoPictureBox.Location = new System.Drawing.Point(75, 25);
            this.AtualizacaoPictureBox.Name = "AtualizacaoPictureBox";
            this.AtualizacaoPictureBox.Size = new System.Drawing.Size(16, 16);
            this.AtualizacaoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.AtualizacaoPictureBox.TabIndex = 6;
            this.AtualizacaoPictureBox.TabStop = false;
            this.AtualizacaoPictureBox.Visible = false;
            // 
            // ConexaoPictureBox
            // 
            this.ConexaoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ConexaoPictureBox.Image")));
            this.ConexaoPictureBox.Location = new System.Drawing.Point(75, 7);
            this.ConexaoPictureBox.Name = "ConexaoPictureBox";
            this.ConexaoPictureBox.Size = new System.Drawing.Size(16, 16);
            this.ConexaoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ConexaoPictureBox.TabIndex = 5;
            this.ConexaoPictureBox.TabStop = false;
            this.ConexaoPictureBox.Visible = false;
            // 
            // ConexaoDTOBindingSource
            // 
            this.ConexaoDTOBindingSource.DataSource = typeof(MechTech.Entities.ConexoesDTO);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 165);
            this.ControlBox = false;
            this.Controls.Add(this.ddbConectar);
            this.Controls.Add(this.ConexoesLookUpEdit);
            this.Controls.Add(this.CarregandoPictureBox);
            this.Controls.Add(this.CopiandoPictureBox);
            this.Controls.Add(this.AtualizacaoPictureBox);
            this.Controls.Add(this.ConexaoPictureBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConexoesLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarregandoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CopiandoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AtualizacaoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConexaoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConexaoDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox ConexaoPictureBox;
        private System.Windows.Forms.PictureBox AtualizacaoPictureBox;
        private System.Windows.Forms.PictureBox CopiandoPictureBox;
        private System.Windows.Forms.PictureBox CarregandoPictureBox;
        private DevExpress.XtraEditors.LookUpEdit ConexoesLookUpEdit;
        private DevExpress.XtraEditors.DropDownButton ddbConectar;
        private System.Windows.Forms.BindingSource ConexaoDTOBindingSource;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}