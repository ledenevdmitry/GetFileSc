using GetFileSc.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using IniLib;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GetFileSc
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetSize();
            Application.Idle += OnIdle;
        }

        string folder;
        string[] subfolders;

        private void OnIdle(object sender, EventArgs e)
        {
            NudPatchFrom.Enabled = CbPatchFrom.Checked;
            NudPatchTo.Enabled = CbPatchTo.Checked;
        }

        private void BtSetFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = IniUtils.GetConfig("Directories", "FixpackDir");
                DialogResult result;
                try
                {
                    result = fbd.ShowDialog();
                }
                catch(Exception exc)
                {
                    fbd.SelectedPath = "";
                    result = fbd.ShowDialog();
                }

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    IniUtils.SetConfig("Directories", "FixpackDir", fbd.SelectedPath);
                    folder = fbd.SelectedPath;
                    LbSetFolder.Text = "Папка: " + fbd.SelectedPath;
                    (new ToolTip()).SetToolTip(LbSetFolder, LbSetFolder.Text);
                    subfolders = Directory.GetDirectories(folder);


                    MessageBox.Show("Найдено: " + subfolders.Length.ToString() + " патчей", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtCreateFileScFromSc.Enabled = true;
                    BtCreateFileScFromFiles.Enabled = true;
                    BtRNCheck.Enabled = true;
                    BtCheckFp.Enabled = true;
                }
            }
        }

        private void ApplyFilter()
        {
            //фильтр патчей по условию с чекбоксами
            if (CbPatchFrom.Checked)
            {
                subfolders = Array.FindAll(subfolders, (x => FileScUtils.GetPatchOrderNumber(new DirectoryInfo(x).Name) >= (int)NudPatchFrom.Value));
            }

            if (CbPatchTo.Checked)
            {
                subfolders = Array.FindAll(subfolders, (x => FileScUtils.GetPatchOrderNumber(new DirectoryInfo(x).Name) <= (int)NudPatchTo.Value));
            }

        }

        private void BtCreateFileSc_Click(object sender, EventArgs e)
        {
            ApplyFilter();
            bool quit = false;

            string scfilesNotExistsMessage;
            string[] texts = FileScUtils.GetTextsFromPatches(subfolders, out scfilesNotExistsMessage);

            if (scfilesNotExistsMessage != "")
            {
                quit = MessageBox.Show("Отсутствуют файлы сценария в папках:" + Environment.NewLine + scfilesNotExistsMessage + Environment.NewLine + "Продолжить?",
                    "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes ? false : true;
            }

            string dbxmlFilesNotExistsMessage;
            string linesNotExistsMessage;

            if (!quit)
            {
                FileScUtils.GetFileScFromScs(folder, subfolders, texts, out dbxmlFilesNotExistsMessage, out linesNotExistsMessage, ref quit);
            }

            if (!quit)
            {
                FileScUtils.SaveFileSc(folder, texts);
            }
        }

        private void BtCreateFileScFromFiles_Click(object sender, EventArgs e)
        {
            ApplyFilter();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "txt";
            sfd.Filter = "Текстовый файл|*.txt";
            sfd.FileName = "file_sc";
            sfd.InitialDirectory = folder;
            string[] prefixes = { "ORA", "IPC", "STWF" };

            string[] texts;
            FileScUtils.GetFileScFromFiles(folder, subfolders, out texts);
            FileScUtils.SaveFileSc(folder, texts);

        }

        private void BtVSSFormOpen_Click(object sender, EventArgs e)
        {
            VSSForm vssForm = new VSSForm();
            vssForm.ShowDialog();
        }

        private void SetSize()
        {
            LbSetFolder.MaximumSize = new Size(Width - 20, 0);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void BtRNCheck_Click(object sender, EventArgs e)
        {
            string report = FileScUtils.RNReport(subfolders);
            if(report != "")
            {
                ShowBigMessageForm sbmf = new ShowBigMessageForm(report);
                sbmf.ShowDialog();
            }
        }

        private void BtCheckFp_Click(object sender, EventArgs e)
        {
            FileScUtils.CheckFP(folder);
        }
    }
}
