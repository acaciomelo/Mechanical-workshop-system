namespace MechTech.UI.Vendas.Reports
{
    partial class rptProdutosServicos
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabelProdutoTipo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelValorUnitario = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelValorDesconto = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelValorTotalProduto = new DevExpress.XtraReports.UI.XRLabel();
            this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabelProdutoTipo,
            this.xrLabel52,
            this.xrLabel53,
            this.xrLabel54,
            this.xrLabelValorUnitario,
            this.xrLabelValorDesconto,
            this.xrLabelValorTotalProduto});
            this.Detail.HeightF = 37.25336F;
            this.Detail.OddStyleName = "xrControlStyle1";
            // 
            // PageHeader
            // 
            this.PageHeader.HeightF = 0F;
            // 
            // PageFooter
            // 
            this.PageFooter.HeightF = 33.66671F;
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 0F;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 100F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // xrLabelProdutoTipo
            // 
            this.xrLabelProdutoTipo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabelProdutoTipo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Tipo")});
            this.xrLabelProdutoTipo.Dpi = 254F;
            this.xrLabelProdutoTipo.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.xrLabelProdutoTipo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabelProdutoTipo.Name = "xrLabelProdutoTipo";
            this.xrLabelProdutoTipo.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelProdutoTipo.SizeF = new System.Drawing.SizeF(158.75F, 37.25336F);
            this.xrLabelProdutoTipo.StylePriority.UseBorders = false;
            this.xrLabelProdutoTipo.StylePriority.UseFont = false;
            this.xrLabelProdutoTipo.StylePriority.UseTextAlignment = false;
            this.xrLabelProdutoTipo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel52
            // 
            this.xrLabel52.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel52.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Id")});
            this.xrLabel52.Dpi = 254F;
            this.xrLabel52.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(158.7497F, 0F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(150.8125F, 37.25336F);
            this.xrLabel52.StylePriority.UseBorders = false;
            this.xrLabel52.StylePriority.UseFont = false;
            this.xrLabel52.StylePriority.UseTextAlignment = false;
            this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel53
            // 
            this.xrLabel53.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel53.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Descricao")});
            this.xrLabel53.Dpi = 254F;
            this.xrLabel53.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.xrLabel53.LocationFloat = new DevExpress.Utils.PointFloat(309.5622F, 0F);
            this.xrLabel53.Name = "xrLabel53";
            this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel53.SizeF = new System.Drawing.SizeF(677.3331F, 37.25336F);
            this.xrLabel53.StylePriority.UseBorders = false;
            this.xrLabel53.StylePriority.UseFont = false;
            this.xrLabel53.StylePriority.UseTextAlignment = false;
            this.xrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel54
            // 
            this.xrLabel54.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel54.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Quantidade")});
            this.xrLabel54.Dpi = 254F;
            this.xrLabel54.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(986.8954F, 0F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel54.SizeF = new System.Drawing.SizeF(174.6249F, 37.25336F);
            this.xrLabel54.StylePriority.UseBorders = false;
            this.xrLabel54.StylePriority.UseFont = false;
            this.xrLabel54.StylePriority.UseTextAlignment = false;
            this.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabelValorUnitario
            // 
            this.xrLabelValorUnitario.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabelValorUnitario.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ValorUnitario")});
            this.xrLabelValorUnitario.Dpi = 254F;
            this.xrLabelValorUnitario.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.xrLabelValorUnitario.LocationFloat = new DevExpress.Utils.PointFloat(1161.52F, 0F);
            this.xrLabelValorUnitario.Name = "xrLabelValorUnitario";
            this.xrLabelValorUnitario.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelValorUnitario.SizeF = new System.Drawing.SizeF(243.4166F, 37.25336F);
            this.xrLabelValorUnitario.StylePriority.UseBorders = false;
            this.xrLabelValorUnitario.StylePriority.UseFont = false;
            this.xrLabelValorUnitario.StylePriority.UseTextAlignment = false;
            this.xrLabelValorUnitario.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabelValorDesconto
            // 
            this.xrLabelValorDesconto.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabelValorDesconto.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ValorDesconto")});
            this.xrLabelValorDesconto.Dpi = 254F;
            this.xrLabelValorDesconto.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.xrLabelValorDesconto.LocationFloat = new DevExpress.Utils.PointFloat(1404.937F, 0F);
            this.xrLabelValorDesconto.Name = "xrLabelValorDesconto";
            this.xrLabelValorDesconto.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelValorDesconto.SizeF = new System.Drawing.SizeF(241.6465F, 37.25336F);
            this.xrLabelValorDesconto.StylePriority.UseBorders = false;
            this.xrLabelValorDesconto.StylePriority.UseFont = false;
            this.xrLabelValorDesconto.StylePriority.UseTextAlignment = false;
            this.xrLabelValorDesconto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabelValorTotalProduto
            // 
            this.xrLabelValorTotalProduto.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabelValorTotalProduto.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ValorLiquido")});
            this.xrLabelValorTotalProduto.Dpi = 254F;
            this.xrLabelValorTotalProduto.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.xrLabelValorTotalProduto.LocationFloat = new DevExpress.Utils.PointFloat(1646.583F, 0F);
            this.xrLabelValorTotalProduto.Name = "xrLabelValorTotalProduto";
            this.xrLabelValorTotalProduto.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelValorTotalProduto.SizeF = new System.Drawing.SizeF(243.4166F, 37.25336F);
            this.xrLabelValorTotalProduto.StylePriority.UseBorders = false;
            this.xrLabelValorTotalProduto.StylePriority.UseFont = false;
            this.xrLabelValorTotalProduto.StylePriority.UseTextAlignment = false;
            this.xrLabelValorTotalProduto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrControlStyle1
            // 
            this.xrControlStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.xrControlStyle1.Name = "xrControlStyle1";
            this.xrControlStyle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MechTech.UI.Vendas.DetailProdutosServicos);
            // 
            // rptProdutosServicos
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.bottomMarginBand1});
            this.DataSource = this.bindingSource1;
            this.Margins = new System.Drawing.Printing.Margins(150, 60, 60, 0);
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1});
            this.Version = "14.1";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        //private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel xrLabelProdutoTipo;
        private DevExpress.XtraReports.UI.XRLabel xrLabel52;
        private DevExpress.XtraReports.UI.XRLabel xrLabel53;
        private DevExpress.XtraReports.UI.XRLabel xrLabel54;
        private DevExpress.XtraReports.UI.XRLabel xrLabelValorUnitario;
        private DevExpress.XtraReports.UI.XRLabel xrLabelValorDesconto;
        private DevExpress.XtraReports.UI.XRLabel xrLabelValorTotalProduto;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1;
    }
}
