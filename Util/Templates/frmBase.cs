using System.Drawing;
using System.Drawing.Printing;

using DevExpress.XtraPrinting;
using DevExpress.XtraEditors;

using MechTech.Util;

namespace MechTech.Util.Templates
{
    public partial class frmBase : DevExpress.XtraEditors.XtraForm
    {
        
        public frmBase()
        {
            InitializeComponent();

            defaultLookAndFeelBase.LookAndFeel.SkinName = Global.Skin;
            //this.Icon = Global.IconeSistema;
        }

        public override void Refresh()
        {
            defaultLookAndFeelBase.LookAndFeel.SkinName = Global.Skin;
            base.Refresh();
        }
        public void ShowRibbonPreview(IPrintable component, string title)
        {
            //HEADER
            PageHeaderArea header = new PageHeaderArea();
            header.Content.Add(string.Empty);
            header.Content.Add(title);
            header.LineAlignment = BrickAlignment.Center;
            header.Font = new Font("Tahoma", 16, FontStyle.Bold);

            //FOOTER
            PageFooterArea footer = new PageFooterArea();
            footer.Content.AddRange(new string[] { "", "", "Página: [Page #]" });

            //UNION HEADER/FOOTER
            PageHeaderFooter headerfooter = new PageHeaderFooter(header, footer);

            PrintableComponentLink print = new PrintableComponentLink(new PrintingSystem());
            print.Component = component;
            print.PageHeaderFooter = headerfooter;
            print.PaperKind = PaperKind.A4;
            print.Margins = new Margins(60, 30, 60, 60);
            print.CreateDocument();
            print.ShowRibbonPreview(this.LookAndFeel);
        }
    }
}