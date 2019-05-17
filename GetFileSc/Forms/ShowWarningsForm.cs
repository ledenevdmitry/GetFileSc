using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetFileSc
{
    public partial class ShowWarningsForm : Form
    {
        private const int SMALL_BORDER = 9;
        public DialogResult dialogResult { get; private set; }
        public ShowWarningsForm(string FilesNotExist, string LinesNotExist)
        {
            InitializeComponent();
            SetSize();
            tbFilesNotExist.Text = FilesNotExist;
            tbLinesNotExist.Text = LinesNotExist;
        }

        private void SetSize()
        {
            gbFilesNotExist.Top = SMALL_BORDER;
            gbFilesNotExist.Left = SMALL_BORDER;
            gbLinesNotExist.Top = Height / 2 - SMALL_BORDER - gbContinue.Height / 2;
            gbLinesNotExist.Left = SMALL_BORDER;

            gbFilesNotExist.Width = Width - 2 * SMALL_BORDER;
            gbLinesNotExist.Width = Width - 2 * SMALL_BORDER;
            gbFilesNotExist.Height = Height / 2 - 2 * SMALL_BORDER - gbContinue.Height;
            gbLinesNotExist.Height = Height / 2 - 2 * SMALL_BORDER - gbContinue.Height;

            tbFilesNotExist.Width = gbFilesNotExist.Width - SMALL_BORDER;
            tbLinesNotExist.Width = gbLinesNotExist.Width - SMALL_BORDER;
            tbFilesNotExist.Height = gbFilesNotExist.Height - SMALL_BORDER;
            tbLinesNotExist.Height = gbLinesNotExist.Height - SMALL_BORDER;

            gbContinue.Left = Width / 2 - gbContinue.Width / 2;
            gbContinue.Top = gbLinesNotExist.Bottom + SMALL_BORDER;
        }

        private void ShowWarningsForm_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void btYes_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Yes;
            Close();
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.No;
            Close();
        }
    }
}
