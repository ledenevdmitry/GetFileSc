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
    public partial class ShowBigMessageForm : Form
    {
        public ShowBigMessageForm(string message)
        {
            InitializeComponent();
            TbMessage.Text = message;
        }

        private void ShowBigMessageForm_Resize(object sender, EventArgs e)
        {
            TbMessage.Width = Width - 3 * TbMessage.Left;
            TbMessage.Height = Height - 5 * TbMessage.Top;
        }
    }
}
