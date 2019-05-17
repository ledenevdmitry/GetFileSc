namespace GetFileSc.Forms
{
    partial class VSSForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LbSourceFolder = new System.Windows.Forms.Label();
            this.TbSourceFolder = new System.Windows.Forms.TextBox();
            this.TbDestFolder = new System.Windows.Forms.TextBox();
            this.LbDestFolder = new System.Windows.Forms.Label();
            this.TbFolders = new System.Windows.Forms.TextBox();
            this.LbFolders = new System.Windows.Forms.Label();
            this.BtMove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NudFpNum = new System.Windows.Forms.NumericUpDown();
            this.RbFixpack = new System.Windows.Forms.RadioButton();
            this.RbMainSupply = new System.Windows.Forms.RadioButton();
            this.LbCustomNumberation = new System.Windows.Forms.Label();
            this.NudCustomNumeration = new System.Windows.Forms.NumericUpDown();
            this.NudSymbolCount = new System.Windows.Forms.NumericUpDown();
            this.LbSymbolCount = new System.Windows.Forms.Label();
            this.GbNumeration = new System.Windows.Forms.GroupBox();
            this.CbAddNumeration = new System.Windows.Forms.CheckBox();
            this.BtDownload = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.TsAddSubfolder = new System.Windows.Forms.ToolStripMenuItem();
            this.TsLoadOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.TsSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.TsChangeVSSDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.TsChangeLoggingBase = new System.Windows.Forms.ToolStripMenuItem();
            this.PbPatches = new System.Windows.Forms.ProgressBar();
            this.TsSetCVSType = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudFpNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCustomNumeration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSymbolCount)).BeginInit();
            this.GbNumeration.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbSourceFolder
            // 
            this.LbSourceFolder.AutoSize = true;
            this.LbSourceFolder.Location = new System.Drawing.Point(32, 30);
            this.LbSourceFolder.Name = "LbSourceFolder";
            this.LbSourceFolder.Size = new System.Drawing.Size(95, 13);
            this.LbSourceFolder.TabIndex = 0;
            this.LbSourceFolder.Text = "Исходная папка: ";
            // 
            // TbSourceFolder
            // 
            this.TbSourceFolder.Location = new System.Drawing.Point(133, 27);
            this.TbSourceFolder.Name = "TbSourceFolder";
            this.TbSourceFolder.Size = new System.Drawing.Size(185, 20);
            this.TbSourceFolder.TabIndex = 1;
            // 
            // TbDestFolder
            // 
            this.TbDestFolder.Location = new System.Drawing.Point(133, 53);
            this.TbDestFolder.Name = "TbDestFolder";
            this.TbDestFolder.Size = new System.Drawing.Size(185, 20);
            this.TbDestFolder.TabIndex = 3;
            // 
            // LbDestFolder
            // 
            this.LbDestFolder.AutoSize = true;
            this.LbDestFolder.Location = new System.Drawing.Point(20, 56);
            this.LbDestFolder.Name = "LbDestFolder";
            this.LbDestFolder.Size = new System.Drawing.Size(107, 13);
            this.LbDestFolder.TabIndex = 2;
            this.LbDestFolder.Text = "Папка назначения: ";
            // 
            // TbFolders
            // 
            this.TbFolders.Location = new System.Drawing.Point(12, 219);
            this.TbFolders.Multiline = true;
            this.TbFolders.Name = "TbFolders";
            this.TbFolders.Size = new System.Drawing.Size(306, 318);
            this.TbFolders.TabIndex = 10;
            // 
            // LbFolders
            // 
            this.LbFolders.AutoSize = true;
            this.LbFolders.Location = new System.Drawing.Point(12, 203);
            this.LbFolders.Name = "LbFolders";
            this.LbFolders.Size = new System.Drawing.Size(115, 13);
            this.LbFolders.TabIndex = 9;
            this.LbFolders.Text = "Переносимые папки:";
            // 
            // BtMove
            // 
            this.BtMove.Location = new System.Drawing.Point(12, 559);
            this.BtMove.Name = "BtMove";
            this.BtMove.Size = new System.Drawing.Size(306, 36);
            this.BtMove.TabIndex = 11;
            this.BtMove.Text = "Перенести";
            this.BtMove.UseVisualStyleBackColor = true;
            this.BtMove.Click += new System.EventHandler(this.BtMove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NudFpNum);
            this.groupBox1.Controls.Add(this.RbFixpack);
            this.groupBox1.Controls.Add(this.RbMainSupply);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид поставки";
            // 
            // NudFpNum
            // 
            this.NudFpNum.Location = new System.Drawing.Point(229, 19);
            this.NudFpNum.Name = "NudFpNum";
            this.NudFpNum.Size = new System.Drawing.Size(55, 20);
            this.NudFpNum.TabIndex = 2;
            this.NudFpNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RbFixpack
            // 
            this.RbFixpack.AutoSize = true;
            this.RbFixpack.Location = new System.Drawing.Point(137, 19);
            this.RbFixpack.Name = "RbFixpack";
            this.RbFixpack.Size = new System.Drawing.Size(86, 17);
            this.RbFixpack.TabIndex = 1;
            this.RbFixpack.Text = "Фикспак №";
            this.RbFixpack.UseVisualStyleBackColor = true;
            // 
            // RbMainSupply
            // 
            this.RbMainSupply.AutoSize = true;
            this.RbMainSupply.Checked = true;
            this.RbMainSupply.Location = new System.Drawing.Point(6, 19);
            this.RbMainSupply.Name = "RbMainSupply";
            this.RbMainSupply.Size = new System.Drawing.Size(125, 17);
            this.RbMainSupply.TabIndex = 0;
            this.RbMainSupply.TabStop = true;
            this.RbMainSupply.Text = "Основная поставка";
            this.RbMainSupply.UseVisualStyleBackColor = true;
            // 
            // LbCustomNumberation
            // 
            this.LbCustomNumberation.AutoSize = true;
            this.LbCustomNumberation.Location = new System.Drawing.Point(3, 71);
            this.LbCustomNumberation.Name = "LbCustomNumberation";
            this.LbCustomNumberation.Size = new System.Drawing.Size(81, 13);
            this.LbCustomNumberation.TabIndex = 1;
            this.LbCustomNumberation.Text = "Нумеровать с:";
            // 
            // NudCustomNumeration
            // 
            this.NudCustomNumeration.Location = new System.Drawing.Point(90, 69);
            this.NudCustomNumeration.Name = "NudCustomNumeration";
            this.NudCustomNumeration.Size = new System.Drawing.Size(43, 20);
            this.NudCustomNumeration.TabIndex = 2;
            this.NudCustomNumeration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudSymbolCount
            // 
            this.NudSymbolCount.Location = new System.Drawing.Point(256, 69);
            this.NudSymbolCount.Name = "NudSymbolCount";
            this.NudSymbolCount.Size = new System.Drawing.Size(40, 20);
            this.NudSymbolCount.TabIndex = 4;
            this.NudSymbolCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // LbSymbolCount
            // 
            this.LbSymbolCount.AutoSize = true;
            this.LbSymbolCount.Location = new System.Drawing.Point(140, 71);
            this.LbSymbolCount.Name = "LbSymbolCount";
            this.LbSymbolCount.Size = new System.Drawing.Size(111, 13);
            this.LbSymbolCount.TabIndex = 3;
            this.LbSymbolCount.Text = "Символов на номер:";
            // 
            // GbNumeration
            // 
            this.GbNumeration.Controls.Add(this.NudSymbolCount);
            this.GbNumeration.Controls.Add(this.LbSymbolCount);
            this.GbNumeration.Controls.Add(this.NudCustomNumeration);
            this.GbNumeration.Controls.Add(this.LbCustomNumberation);
            this.GbNumeration.Controls.Add(this.groupBox1);
            this.GbNumeration.Location = new System.Drawing.Point(15, 102);
            this.GbNumeration.Name = "GbNumeration";
            this.GbNumeration.Size = new System.Drawing.Size(302, 97);
            this.GbNumeration.TabIndex = 8;
            this.GbNumeration.TabStop = false;
            this.GbNumeration.Text = "Нумерация";
            // 
            // CbAddNumeration
            // 
            this.CbAddNumeration.AutoSize = true;
            this.CbAddNumeration.Checked = true;
            this.CbAddNumeration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbAddNumeration.Location = new System.Drawing.Point(12, 79);
            this.CbAddNumeration.Name = "CbAddNumeration";
            this.CbAddNumeration.Size = new System.Drawing.Size(136, 17);
            this.CbAddNumeration.TabIndex = 7;
            this.CbAddNumeration.Text = "Добавить нумерацию";
            this.CbAddNumeration.UseVisualStyleBackColor = true;
            // 
            // BtDownload
            // 
            this.BtDownload.Location = new System.Drawing.Point(12, 601);
            this.BtDownload.Name = "BtDownload";
            this.BtDownload.Size = new System.Drawing.Size(306, 36);
            this.BtDownload.TabIndex = 12;
            this.BtDownload.Text = "Скачать поставку из VSS";
            this.BtDownload.UseVisualStyleBackColor = true;
            this.BtDownload.Click += new System.EventHandler(this.BtDownload_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsFile,
            this.TsSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(329, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TsFile
            // 
            this.TsFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsAddSubfolder,
            this.TsLoadOrder,
            this.TsSetCVSType});
            this.TsFile.Name = "TsFile";
            this.TsFile.Size = new System.Drawing.Size(48, 20);
            this.TsFile.Text = "Файл";
            // 
            // TsAddSubfolder
            // 
            this.TsAddSubfolder.Name = "TsAddSubfolder";
            this.TsAddSubfolder.Size = new System.Drawing.Size(316, 22);
            this.TsAddSubfolder.Text = "Добавить подпапку в папку назначения";
            this.TsAddSubfolder.Click += new System.EventHandler(this.TsAddSubfolder_Click);
            // 
            // TsLoadOrder
            // 
            this.TsLoadOrder.Name = "TsLoadOrder";
            this.TsLoadOrder.Size = new System.Drawing.Size(316, 22);
            this.TsLoadOrder.Text = "Загрузить последовательность из .xls файла";
            this.TsLoadOrder.Click += new System.EventHandler(this.TsLoadOrder_Click);
            // 
            // TsSettings
            // 
            this.TsSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsChangeVSSDatabase,
            this.TsChangeLoggingBase});
            this.TsSettings.Name = "TsSettings";
            this.TsSettings.Size = new System.Drawing.Size(78, 20);
            this.TsSettings.Text = "Настройка";
            // 
            // TsChangeVSSDatabase
            // 
            this.TsChangeVSSDatabase.Name = "TsChangeVSSDatabase";
            this.TsChangeVSSDatabase.Size = new System.Drawing.Size(249, 22);
            this.TsChangeVSSDatabase.Text = "Задать адрес базы VSS";
            this.TsChangeVSSDatabase.Click += new System.EventHandler(this.TsChangeVSSDatabase_Click);
            // 
            // TsChangeLoggingBase
            // 
            this.TsChangeLoggingBase.Name = "TsChangeLoggingBase";
            this.TsChangeLoggingBase.Size = new System.Drawing.Size(249, 22);
            this.TsChangeLoggingBase.Text = "Задать адрес базы логирования";
            this.TsChangeLoggingBase.Click += new System.EventHandler(this.TsChangeLoggingBase_Click);
            // 
            // PbPatches
            // 
            this.PbPatches.Location = new System.Drawing.Point(12, 543);
            this.PbPatches.Name = "PbPatches";
            this.PbPatches.Size = new System.Drawing.Size(306, 10);
            this.PbPatches.TabIndex = 14;
            // 
            // TsSetCVSType
            // 
            this.TsSetCVSType.Name = "TsSetCVSType";
            this.TsSetCVSType.Size = new System.Drawing.Size(316, 22);
            this.TsSetCVSType.Text = "Задать тип системы контроля версий";
            this.TsSetCVSType.Click += new System.EventHandler(this.TsSetCVSType_Click);
            // 
            // VSSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 642);
            this.Controls.Add(this.PbPatches);
            this.Controls.Add(this.BtDownload);
            this.Controls.Add(this.CbAddNumeration);
            this.Controls.Add(this.GbNumeration);
            this.Controls.Add(this.BtMove);
            this.Controls.Add(this.LbFolders);
            this.Controls.Add(this.TbFolders);
            this.Controls.Add(this.TbDestFolder);
            this.Controls.Add(this.LbDestFolder);
            this.Controls.Add(this.TbSourceFolder);
            this.Controls.Add(this.LbSourceFolder);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "VSSForm";
            this.Text = "Перенос патчей";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VSSForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudFpNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCustomNumeration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSymbolCount)).EndInit();
            this.GbNumeration.ResumeLayout(false);
            this.GbNumeration.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbSourceFolder;
        private System.Windows.Forms.TextBox TbSourceFolder;
        private System.Windows.Forms.TextBox TbDestFolder;
        private System.Windows.Forms.Label LbDestFolder;
        private System.Windows.Forms.TextBox TbFolders;
        private System.Windows.Forms.Label LbFolders;
        private System.Windows.Forms.Button BtMove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown NudFpNum;
        private System.Windows.Forms.RadioButton RbFixpack;
        private System.Windows.Forms.RadioButton RbMainSupply;
        private System.Windows.Forms.Label LbCustomNumberation;
        private System.Windows.Forms.NumericUpDown NudCustomNumeration;
        private System.Windows.Forms.NumericUpDown NudSymbolCount;
        private System.Windows.Forms.Label LbSymbolCount;
        private System.Windows.Forms.GroupBox GbNumeration;
        private System.Windows.Forms.CheckBox CbAddNumeration;
        private System.Windows.Forms.Button BtDownload;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TsFile;
        private System.Windows.Forms.ToolStripMenuItem TsAddSubfolder;
        private System.Windows.Forms.ToolStripMenuItem TsSettings;
        private System.Windows.Forms.ToolStripMenuItem TsChangeVSSDatabase;
        private System.Windows.Forms.ProgressBar PbPatches;
        private System.Windows.Forms.ToolStripMenuItem TsLoadOrder;
        private System.Windows.Forms.ToolStripMenuItem TsChangeLoggingBase;
        private System.Windows.Forms.ToolStripMenuItem TsSetCVSType;
    }
}