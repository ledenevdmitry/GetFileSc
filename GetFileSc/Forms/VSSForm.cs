using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniLib;
using CVSLib.CVSTypes;
using GetFileSc;
using IniParser;
using IniParser.Model;
using Microsoft.VisualStudio.SourceSafe.Interop;
using CVSLib;

namespace GetFileSc.Forms
{
    public partial class VSSForm : Form
    {
        CVS cvs;
        private string basePath;

        int threadsAmount = -1;
        int threadsSucceded = 0;

        public VSSForm()
        {
            InitializeComponent();
            Application.Idle += OnIdle;

            Connect();

            TbSourceFolder.Text = IniUtils.GetConfig("Folders", "Source");
            TbDestFolder.Text = IniUtils.GetConfig("Folders", "Dest");
        }

        private void Connect()
        {
            try
            {
                basePath = IniUtils.GetConfig("Credentials", "Base");
                string cvsType = IniUtils.GetConfig("CVS", "CVSType");
                if (String.IsNullOrWhiteSpace(cvsType))
                {
                    throw new ArgumentException("В настройках задайте тип системы контроля версий");
                }

                if (String.IsNullOrWhiteSpace(basePath))
                {
                    throw new ArgumentException("В настройках задайте правильный путь до " + cvsType);
                }
                cvs = Activator.CreateInstance("CVSLib", "CVSLib.CVSTypes." + IniUtils.GetConfig("CVS", "CVSType")).Unwrap() as CVS;
                cvs.location = basePath;
                cvs.login = Environment.UserName;
                cvs.Connect();
                //cvs = new VSS(basePath, Environment.UserName);
            }

            catch(COMException exc)
            {
                string message = VSSErrors.GetMessageByCode(exc.ErrorCode);
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnIdle(object sender, EventArgs e)
        {
            BtMove.Enabled = TbSourceFolder.Text != "" && TbDestFolder.Text != "" &&
                             TbFolders.Text != "" && !IsRecursiveMove() && !string.IsNullOrWhiteSpace(basePath);
            NudFpNum.Enabled = RbFixpack.Checked;
            GbNumeration.Enabled = CbAddNumeration.Checked;
            if (threadsAmount > 0)
            {
                PbPatches.Maximum = threadsAmount;
                PbPatches.Value = threadsSucceded;
                if (threadsAmount == threadsSucceded)
                {
                    MessageBox.Show("Готово!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    PbPatches.Maximum = 100;
                    PbPatches.Value = 0;
                    threadsAmount = -1;
                    threadsSucceded = 0;
                }
            }

        }

        private bool IsRecursiveMove()
        {
            return TbDestFolder.Text.IndexOf(TbSourceFolder.Text) != -1 && 
                  (TbSourceFolder.Text.Length > TbDestFolder.Text.Length ||
                   TbDestFolder.Text[TbSourceFolder.Text.Length - 1] == '/');
        }

        VSSItem destFolder;

        private void BtMove_Click(object sender, EventArgs e)
        {
            IniUtils.SetConfig("Folders", "Source", TbSourceFolder.Text);
            IniUtils.SetConfig("Folders", "Dest", TbDestFolder.Text);
            string[] folders = TbFolders.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            threadsAmount = folders.Length;
            threadsSucceded = 0;

            try
            {
                cvs.Move(TbSourceFolder.Text, TbDestFolder.Text, folders);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void DownloadVSSDestFolder()
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    IniUtils.SetConfig("Directories", "WorkingFolder", fbd.SelectedPath);
                    string localFolder = fbd.SelectedPath + "\\" + new DirectoryInfo(TbDestFolder.Text).Name;
                    Directory.CreateDirectory(localFolder);
                    DownloadVSSDestFolder(localFolder);
                }
            }
        }

        private void DownloadVSSDestFolder(string localFolder)
        {
                try
                    {

                    cvs.Download(TbDestFolder.Text, localFolder);
                }
                    catch (Exception exc)
                    {
                            switch (MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation))
                            {
                                case DialogResult.Abort: return;
                                case DialogResult.Ignore: break;
                                case DialogResult.Retry:
                                    {
                                        DownloadVSSDestFolder(localFolder);
                                       
                                    }
                                    break;
                            }
                        }
                    }

        private void BtDownload_Click(object sender, EventArgs e)
        {
            string workingFolder = IniUtils.GetConfig("Directories", "WorkingFolder");
            DownloadVSSDestFolder();
        }

        private void TsAddSubfolder_Click(object sender, EventArgs e)
        {
            /*
                SetAttrDialog sad = new SetAttrDialog("Поставка");
                sad.ShowDialog();
                if (sad.Set)
                {
                    try
                    {
                        destFolder = vssDatabase.get_VSSItem(TbDestFolder.Text);
                        destFolder.NewSubproject(sad.Attr);
                        TbDestFolder.Text += "/" + sad.Attr;
                    }
                    catch (System.Runtime.InteropServices.COMException exc)
                    {
                        if (exc.ErrorCode == -2147166572)
                        {
                            switch (MessageBox.Show("Папка уже существует! Добавить в нее патчи все равно?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                            {
                                case DialogResult.Yes:
                                case DialogResult.No: return;
                            }
                        }
                        else
                            MessageBox.Show(VSSErrors.GetMessageByCode(exc.ErrorCode), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            */
        }

        private void TsChangeVSSDatabase_Click(object sender, EventArgs e)
        {
            SetAttrDialog sad = new SetAttrDialog("База VSS");
            sad.ShowDialog();
            if (sad.Set)
            {
                IniUtils.SetConfig("Credentials", "Base", sad.Attr);
            }
            Connect();
        }

        private void VSSForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(cvs != null) cvs.Close();
        }

        private void ExcelCleanup(Microsoft.Office.Interop.Excel.Range xlRange,
                                  Microsoft.Office.Interop.Excel._Worksheet xlWorksheet,
                                  Microsoft.Office.Interop.Excel.Workbook xlWorkbook,
                                  Microsoft.Office.Interop.Excel.Application xlApp)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }

        private void TsLoadOrder_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            string folder;
            using (var ofd = new OpenFileDialog())
            {
                ofd.DefaultExt = "xls";
                ofd.Filter = "Файл Excel(*.XLS;*.XLSX)|*.XLS;*.XLSX|Все файлы (*.*)|*.*";
                ofd.InitialDirectory = IniUtils.GetConfig("Directories", "ExcelDir");
                DialogResult result;
                try
                {
                    result = ofd.ShowDialog();
                }
                catch (Exception exc)
                {
                    ofd.InitialDirectory = "";
                    result = ofd.ShowDialog();
                }

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    TbFolders.Text = "";
                    IniUtils.SetConfig("Directories", "ExcelDir", Path.GetDirectoryName(ofd.FileName));
                    folder = ofd.FileName;

                    Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(folder);
                    Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                    Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;
                    int patchColumn = 2;
                    int firstPatchRow = 2;

                    for (int i = firstPatchRow; i <= rowCount; i++)
                    {
                        //write the value to the console
                        if (xlRange.Cells[i, patchColumn] != null && xlRange.Cells[i, patchColumn].Value2 != null)
                            TbFolders.Text += xlRange.Cells[i, patchColumn].Value2.ToString() + Environment.NewLine;
                    }

                    ExcelCleanup(xlRange, xlWorksheet, xlWorkbook, xlApp);
                }
            }
        }

        private void TsChangeLoggingBase_Click(object sender, EventArgs e)
        {
            SetAttrDialog sad = new SetAttrDialog("TNS для базы, где ведется логирование");
            sad.Attr = Properties.Settings.Default.OraTNS;
            sad.ShowDialog();
            if (sad.Set)
            {
                IniUtils.SetConfig("Credentials", "CustomTNS", sad.Attr);
                Connect();
            }
        }

        private void TsSetCVSType_Click(object sender, EventArgs e)
        {
            SetAttrDialog sad = new SetAttrDialog("Тип системы контроля версий");
            sad.Attr = "VSS";
            sad.ShowDialog();
            if (sad.Set)
            {
                IniUtils.SetConfig("CVS", "CVSType", sad.Attr);
                Connect();
            }
        }
    }
}
