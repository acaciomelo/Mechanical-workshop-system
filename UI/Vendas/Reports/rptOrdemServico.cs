using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;

using DevExpress.XtraReports.UI;

using MechTech.Util.Templates.Reports;
using MechTech.Util;

namespace MechTech.UI.Vendas.Reports
{
    public partial class rptOrdemServico : rptBase
    {
        public rptOrdemServico()
        {
            InitializeComponent();
        }

        private void rptOrdemServico_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            List<Orcamento> orcamento = (List<Orcamento>)this.Report.DataSource;
            Image img = Global.LerImagemBinaria(orcamento[0].Logo);
            if (img != null)
            {
                xrPanelCentro.Visible = false;
                xrPanelDireito.Visible = true;
                xrPictureBoxLogo.Visible = true;
                xrPictureBoxLogo.Image = Global.LerImagemBinaria(orcamento[0].Logo);
            }
            else
            {
                xrPictureBoxLogo.Visible = false;
                xrPanelCentro.Visible = true;
                xrPanelDireito.Visible = false;
            }
        }

        private void xrSubreport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            List<Orcamento> produtos_servicos = (List<Orcamento>)xrSubreport.RootReport.DataSource;
            xrSubreport.ReportSource.DataSource = produtos_servicos[CurrentRowIndex].Produtos;
        }

    }
}
