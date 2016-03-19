namespace MechTech.Util.Forms
{
    partial class frmExceptionDetail
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
            this.DetailMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.DetailMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // DetailMemoEdit
            // 
            this.DetailMemoEdit.Location = new System.Drawing.Point(12, 12);
            this.DetailMemoEdit.Name = "DetailMemoEdit";
            this.DetailMemoEdit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.DetailMemoEdit.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailMemoEdit.Properties.Appearance.Options.UseBackColor = true;
            this.DetailMemoEdit.Properties.Appearance.Options.UseFont = true;
            this.DetailMemoEdit.Properties.ReadOnly = true;
            this.DetailMemoEdit.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DetailMemoEdit.Properties.WordWrap = false;
            this.DetailMemoEdit.Size = new System.Drawing.Size(770, 513);
            this.DetailMemoEdit.TabIndex = 1;
            this.DetailMemoEdit.UseOptimizedRendering = true;
            this.DetailMemoEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DetailMemoEdit_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(707, 531);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // frmExceptionDetail
            // 
            this.AcceptButton = this.btnOK;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(794, 561);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.DetailMemoEdit);
            this.Name = "frmExceptionDetail";
            this.ShowInTaskbar = false;
            this.Text = "Detalhes da excessão";
            this.Shown += new System.EventHandler(this.frmExceptionDetail_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DetailMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit DetailMemoEdit;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}