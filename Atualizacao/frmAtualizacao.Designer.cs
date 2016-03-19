namespace MechTech
{
    partial class frmAtualizacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAtualizacao));
            this.btnAtualizar = new DevExpress.XtraEditors.SimpleButton();
            this.CompSistemaProgressBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.CompExternoProgressBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.DownloadScriptSQLProgressBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.ExecucaoScriptSQLProgressBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblComponenteSistema = new DevExpress.XtraEditors.LabelControl();
            this.lblComponentesExternos = new DevExpress.XtraEditors.LabelControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblDataUltimaAtualizacao = new DevExpress.XtraEditors.LabelControl();
            this.lblVersaoSistema = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.CompSistemaProgressBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompExternoProgressBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadScriptSQLProgressBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExecucaoScriptSQLProgressBarControl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.Location = new System.Drawing.Point(37, 220);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 0;
            this.btnAtualizar.Text = "&Atualizar";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // CompSistemaProgressBarControl
            // 
            this.CompSistemaProgressBarControl.Location = new System.Drawing.Point(37, 31);
            this.CompSistemaProgressBarControl.Name = "CompSistemaProgressBarControl";
            this.CompSistemaProgressBarControl.Size = new System.Drawing.Size(501, 18);
            this.CompSistemaProgressBarControl.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(37, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(191, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Atualização de componentes do sistema";
            this.labelControl1.UseWaitCursor = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(37, 72);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(183, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Atualização de componentes externos";
            this.labelControl2.UseWaitCursor = true;
            // 
            // CompExternoProgressBarControl
            // 
            this.CompExternoProgressBarControl.Location = new System.Drawing.Point(37, 91);
            this.CompExternoProgressBarControl.Name = "CompExternoProgressBarControl";
            this.CompExternoProgressBarControl.Properties.Step = 1;
            this.CompExternoProgressBarControl.Size = new System.Drawing.Size(501, 18);
            this.CompExternoProgressBarControl.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(37, 134);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(200, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Atualização de Scripts do Banco de Dados";
            this.labelControl3.UseWaitCursor = true;
            // 
            // DownloadScriptSQLProgressBarControl
            // 
            this.DownloadScriptSQLProgressBarControl.Location = new System.Drawing.Point(37, 153);
            this.DownloadScriptSQLProgressBarControl.Name = "DownloadScriptSQLProgressBarControl";
            this.DownloadScriptSQLProgressBarControl.Size = new System.Drawing.Size(501, 18);
            this.DownloadScriptSQLProgressBarControl.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(37, 177);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(196, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Execução dos Scripts do Banco de Dados";
            this.labelControl4.UseWaitCursor = true;
            // 
            // ExecucaoScriptSQLProgressBarControl
            // 
            this.ExecucaoScriptSQLProgressBarControl.Location = new System.Drawing.Point(37, 196);
            this.ExecucaoScriptSQLProgressBarControl.Name = "ExecucaoScriptSQLProgressBarControl";
            this.ExecucaoScriptSQLProgressBarControl.Size = new System.Drawing.Size(501, 18);
            this.ExecucaoScriptSQLProgressBarControl.TabIndex = 8;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(118, 220);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseWaitCursor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(229, 220);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(178, 13);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "Última atualização feita com sucesso:";
            this.labelControl5.UseWaitCursor = true;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(229, 239);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(92, 13);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Versão do Sistema:";
            this.labelControl6.UseWaitCursor = true;
            // 
            // lblComponenteSistema
            // 
            this.lblComponenteSistema.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblComponenteSistema.Location = new System.Drawing.Point(37, 53);
            this.lblComponenteSistema.Name = "lblComponenteSistema";
            this.lblComponenteSistema.Size = new System.Drawing.Size(0, 13);
            this.lblComponenteSistema.TabIndex = 12;
            this.lblComponenteSistema.UseWaitCursor = true;
            // 
            // lblComponentesExternos
            // 
            this.lblComponentesExternos.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblComponentesExternos.Location = new System.Drawing.Point(37, 115);
            this.lblComponentesExternos.Name = "lblComponentesExternos";
            this.lblComponentesExternos.Size = new System.Drawing.Size(0, 13);
            this.lblComponentesExternos.TabIndex = 13;
            this.lblComponentesExternos.UseWaitCursor = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged_1);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblDataUltimaAtualizacao
            // 
            this.lblDataUltimaAtualizacao.Location = new System.Drawing.Point(413, 220);
            this.lblDataUltimaAtualizacao.Name = "lblDataUltimaAtualizacao";
            this.lblDataUltimaAtualizacao.Size = new System.Drawing.Size(0, 13);
            this.lblDataUltimaAtualizacao.TabIndex = 14;
            this.lblDataUltimaAtualizacao.UseWaitCursor = true;
            // 
            // lblVersaoSistema
            // 
            this.lblVersaoSistema.Location = new System.Drawing.Point(327, 239);
            this.lblVersaoSistema.Name = "lblVersaoSistema";
            this.lblVersaoSistema.Size = new System.Drawing.Size(0, 13);
            this.lblVersaoSistema.TabIndex = 15;
            this.lblVersaoSistema.UseWaitCursor = true;
            // 
            // frmAtualizacao
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 259);
            this.Controls.Add(this.lblVersaoSistema);
            this.Controls.Add(this.lblDataUltimaAtualizacao);
            this.Controls.Add(this.lblComponentesExternos);
            this.Controls.Add(this.lblComponenteSistema);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.ExecucaoScriptSQLProgressBarControl);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.DownloadScriptSQLProgressBarControl);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.CompExternoProgressBarControl);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.CompSistemaProgressBarControl);
            this.Controls.Add(this.btnAtualizar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAtualizacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualização do Sistema";
            this.Load += new System.EventHandler(this.frmAtualizacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CompSistemaProgressBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompExternoProgressBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadScriptSQLProgressBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExecucaoScriptSQLProgressBarControl.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAtualizar;
        private DevExpress.XtraEditors.ProgressBarControl CompSistemaProgressBarControl;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ProgressBarControl CompExternoProgressBarControl;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ProgressBarControl DownloadScriptSQLProgressBarControl;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ProgressBarControl ExecucaoScriptSQLProgressBarControl;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblComponenteSistema;
        private DevExpress.XtraEditors.LabelControl lblComponentesExternos;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.LabelControl lblDataUltimaAtualizacao;
        private DevExpress.XtraEditors.LabelControl lblVersaoSistema;
    }
}