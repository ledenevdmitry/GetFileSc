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
    public partial class AddUsrTsForm : Form
    {
        public DialogResultExt dialogResult { get; private set; }
        public AddUsrTsForm(string path)
        {
            InitializeComponent();
            lbStr.Text = path;
            SetSize();
        }

        private void btYes_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResultExt.Yes;
            Close();
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResultExt.No;
            Close();
        }

        private void btYesAll_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResultExt.YesAll;
            Close();
        }

        private void btNoAll_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResultExt.NoAll;
            Close();
        }

        private void AddUsrTsForm_Resize(object sender, EventArgs e)
        {
            SetSize();
        }
        private void SetSize()
        {
            lbStr.MaximumSize = new Size(Width - 20, 0);
        }
    }
}
