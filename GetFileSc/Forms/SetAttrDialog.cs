using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetFileSc.Forms
{
    public partial class SetAttrDialog : Form
    {
        public string Attr { get; set; }
        public bool Set { get; private set; }

        public SetAttrDialog(string attrName)
        {
            InitializeComponent();
            Set = false;
            LbAttr.Text = attrName + ":";
            Text = attrName;
        }

        public void OnIdle(object sender, EventArgs e)
        {
            BtSubmit.Enabled = TbAttr.Text != "";
        }

        private void BtSubmit_Click(object sender, EventArgs e)
        {
            Attr = TbAttr.Text;
            Set = true;
            Close();
        }
    }
}
