using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MechTech.Util.Forms
{
    public partial class frmWait : DevExpress.XtraEditors.XtraForm
    {
        IntPtr keypress;
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams mdiCp = base.CreateParams;
                mdiCp.ClassStyle = mdiCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return mdiCp;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (((Keys)msg.WParam) == Keys.F4 & keypress == ((IntPtr)18))
                return true;

            keypress = msg.WParam;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public frmWait()
        {
            InitializeComponent();
        }

        public frmWait(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;
        }

        public string NewMessage
        {
            set { lblMessage.Text = value; }
        }
    }
}