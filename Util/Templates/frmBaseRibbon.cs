using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Xml.Serialization;
using System.IO;

namespace MechTech.Util.Templates
{
    public partial class frmBaseRibbon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmBaseRibbon()
        {
            InitializeComponent();

            Deserializar();

            defaultLookAndFeelBase.LookAndFeel.SkinName = Global.Skin;
        }
        public override void Refresh()
        {
            defaultLookAndFeelBase.LookAndFeel.SkinName = Global.Skin;
            base.Refresh();
        }

        private void barCheckItemPadrao_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            barCheckItemPadrao.Checked = true;
            barCheckItemCinza.Checked = false;
            barCheckItemPreto.Checked = false;
            barCheckItemAzul.Checked = false;
            barCheckItemVerde.Checked = false;
            barCheckItemSeven.Checked = false;
            Global.Skin = "Black";
            Serializar();
            Cursor = Cursors.Default;
        }

        private void barCheckItemCinza_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            barCheckItemPadrao.Checked = false;
            barCheckItemCinza.Checked = true;
            barCheckItemPreto.Checked = false;
            barCheckItemAzul.Checked = false;
            barCheckItemVerde.Checked = false;
            barCheckItemSeven.Checked = false;
            Global.Skin = "Foggy";
            Serializar();
            Cursor = Cursors.Default;
        }

        private void barCheckItemPreto_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            barCheckItemPadrao.Checked = false;
            barCheckItemCinza.Checked = false;
            barCheckItemPreto.Checked = true;
            barCheckItemAzul.Checked = false;
            barCheckItemVerde.Checked = false;
            barCheckItemSeven.Checked = false;
            Global.Skin = "Darkroom";
            Serializar();
            Cursor = Cursors.Default;
        }

        private void barCheckItemAzul_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            barCheckItemPadrao.Checked = false;
            barCheckItemCinza.Checked = false;
            barCheckItemPreto.Checked = false;
            barCheckItemAzul.Checked = true;
            barCheckItemVerde.Checked = false;
            barCheckItemSeven.Checked = false;
            Global.Skin = "Blue";
            Serializar();
            Cursor = Cursors.Default;
        }

        private void barCheckItemVerde_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            barCheckItemPadrao.Checked = false;
            barCheckItemCinza.Checked = false;
            barCheckItemPreto.Checked = false;
            barCheckItemAzul.Checked = false;
            barCheckItemVerde.Checked = true;
            barCheckItemSeven.Checked = false;
            Global.Skin = "Office 2007 Green";
            Serializar();
            Cursor = Cursors.Default;
        }

        private void barCheckItemSeven_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            barCheckItemPadrao.Checked = false;
            barCheckItemCinza.Checked = false;
            barCheckItemPreto.Checked = false;
            barCheckItemAzul.Checked = false;
            barCheckItemVerde.Checked = false;
            barCheckItemSeven.Checked = true;
            Global.Skin = "Seven";
            Serializar();
            Cursor = Cursors.Default;
        }
        private void Serializar()
        {
            defaultLookAndFeelBase.LookAndFeel.SkinName = Global.Skin;

            sysConfig config = new sysConfig();
            config.Serializar();
        }

        private void Deserializar()
        {
            sysConfig config = new sysConfig();
            config.Deserializar();

            switch (Global.Skin)
            {
                case "Foggy":
                    barCheckItemPadrao.Checked = false;
                    barCheckItemCinza.Checked = true;
                    barCheckItemPreto.Checked = false;
                    barCheckItemAzul.Checked = false;
                    barCheckItemVerde.Checked = false;
                    barCheckItemSeven.Checked = false;
                    break;
                case "Darkroom":
                    barCheckItemPadrao.Checked = false;
                    barCheckItemCinza.Checked = false;
                    barCheckItemPreto.Checked = true;
                    barCheckItemAzul.Checked = false;
                    barCheckItemVerde.Checked = false;
                    barCheckItemSeven.Checked = false;
                    break;
                case "Blue":
                    barCheckItemPadrao.Checked = false;
                    barCheckItemCinza.Checked = false;
                    barCheckItemPreto.Checked = false;
                    barCheckItemAzul.Checked = true;
                    barCheckItemVerde.Checked = false;
                    barCheckItemSeven.Checked = false;
                    break;
                case "Office 2007 Green":
                    barCheckItemPadrao.Checked = false;
                    barCheckItemCinza.Checked = false;
                    barCheckItemPreto.Checked = false;
                    barCheckItemAzul.Checked = false;
                    barCheckItemVerde.Checked = true;
                    barCheckItemSeven.Checked = false;
                    break;
                case "Seven":
                    barCheckItemPadrao.Checked = false;
                    barCheckItemCinza.Checked = false;
                    barCheckItemPreto.Checked = false;
                    barCheckItemAzul.Checked = false;
                    barCheckItemVerde.Checked = false;
                    barCheckItemSeven.Checked = true;
                    break;
                default:
                    barCheckItemPadrao.Checked = true;
                    barCheckItemCinza.Checked = false;
                    barCheckItemPreto.Checked = false;
                    barCheckItemAzul.Checked = false;
                    barCheckItemVerde.Checked = false;
                    barCheckItemSeven.Checked = false;
                    break;
            }
        }
        private void barButtonItemCloseScreen_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<string> forms = new List<string>();
            foreach (Form umform in Application.OpenForms)
            {
                if (!umform.Name.Equals(Global.MainForm) &&
                    !umform.Name.Trim().Equals(string.Empty) &&
                    !umform.Text.Trim().Equals(string.Empty))
                    forms.Add(umform.Name);
            }
            foreach (string umnome in forms)
            {
                if (Application.OpenForms[umnome].ControlBox)
                    Application.OpenForms[umnome].Close();
            }
        }

        public class sysConfig
        {
            public sysConfig()
            {
                this.Skin = Global.Skin;
            }

            private string skin = "Black";
            public string Skin
            {
                get { return skin; }
                set { skin = value; }
            }

            #region XMLSERIALIZER
            public void Serializar()
            {
                try
                {
                    XmlSerializer serializar = new XmlSerializer(typeof(sysConfig));
                    FileStream fs = File.Create(@"C:\Sistemas\sysConfig.xml");
                    serializar.Serialize(fs, this);
                    fs.Close();
                }
                catch { }
            }

            public void Deserializar()
            {
                try
                {
                    XmlSerializer deserializar = new XmlSerializer(typeof(sysConfig));
                    FileStream fs = File.OpenRead(@"C:\Sistemas\sysConfig.xml");
                    Global.Skin = ((sysConfig)deserializar.Deserialize(fs)).Skin;
                    fs.Close();
                }
                catch { }
            }
            #endregion
        }

        private void barCheckItemVerde_CheckedChanged(object sender, ItemClickEventArgs e)
        {

        }
    }
}