namespace GetFileSc
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtSetFolder = new System.Windows.Forms.Button();
            this.LbSetFolder = new System.Windows.Forms.Label();
            this.BtCreateFileScFromSc = new System.Windows.Forms.Button();
            this.BtCreateFileScFromFiles = new System.Windows.Forms.Button();
            this.BtVssFormOpen = new System.Windows.Forms.Button();
            this.CbPatchFrom = new System.Windows.Forms.CheckBox();
            this.NudPatchFrom = new System.Windows.Forms.NumericUpDown();
            this.NudPatchTo = new System.Windows.Forms.NumericUpDown();
            this.CbPatchTo = new System.Windows.Forms.CheckBox();
            this.LbNote = new System.Windows.Forms.Label();
            this.BtRNCheck = new System.Windows.Forms.Button();
            this.BtCheckFp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NudPatchFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudPatchTo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtSetFolder
            // 
            this.BtSetFolder.Location = new System.Drawing.Point(12, 12);
            this.BtSetFolder.Name = "BtSetFolder";
            this.BtSetFolder.Size = new System.Drawing.Size(136, 23);
            this.BtSetFolder.TabIndex = 0;
            this.BtSetFolder.Text = "Выбрать папку";
            this.BtSetFolder.UseVisualStyleBackColor = true;
            this.BtSetFolder.Click += new System.EventHandler(this.BtSetFolder_Click);
            // 
            // LbSetFolder
            // 
            this.LbSetFolder.AutoSize = true;
            this.LbSetFolder.Location = new System.Drawing.Point(12, 227);
            this.LbSetFolder.Name = "LbSetFolder";
            this.LbSetFolder.Size = new System.Drawing.Size(45, 13);
            this.LbSetFolder.TabIndex = 9;
            this.LbSetFolder.Text = "Папка: ";
            // 
            // BtCreateFileScFromSc
            // 
            this.BtCreateFileScFromSc.Enabled = false;
            this.BtCreateFileScFromSc.Location = new System.Drawing.Point(12, 122);
            this.BtCreateFileScFromSc.Name = "BtCreateFileScFromSc";
            this.BtCreateFileScFromSc.Size = new System.Drawing.Size(267, 23);
            this.BtCreateFileScFromSc.TabIndex = 8;
            this.BtCreateFileScFromSc.Text = "Создать файл сценария по сценариям патчей";
            this.BtCreateFileScFromSc.UseVisualStyleBackColor = true;
            this.BtCreateFileScFromSc.Click += new System.EventHandler(this.BtCreateFileSc_Click);
            // 
            // BtCreateFileScFromFiles
            // 
            this.BtCreateFileScFromFiles.Enabled = false;
            this.BtCreateFileScFromFiles.Location = new System.Drawing.Point(12, 93);
            this.BtCreateFileScFromFiles.Name = "BtCreateFileScFromFiles";
            this.BtCreateFileScFromFiles.Size = new System.Drawing.Size(267, 23);
            this.BtCreateFileScFromFiles.TabIndex = 7;
            this.BtCreateFileScFromFiles.Text = "Создать файл сценария по файлам патчей";
            this.BtCreateFileScFromFiles.UseVisualStyleBackColor = true;
            this.BtCreateFileScFromFiles.Click += new System.EventHandler(this.BtCreateFileScFromFiles_Click);
            // 
            // BtVssFormOpen
            // 
            this.BtVssFormOpen.Location = new System.Drawing.Point(154, 12);
            this.BtVssFormOpen.Name = "BtVssFormOpen";
            this.BtVssFormOpen.Size = new System.Drawing.Size(125, 23);
            this.BtVssFormOpen.TabIndex = 1;
            this.BtVssFormOpen.Text = "Собрать в VSS";
            this.BtVssFormOpen.UseVisualStyleBackColor = true;
            this.BtVssFormOpen.Click += new System.EventHandler(this.BtVSSFormOpen_Click);
            // 
            // CbPatchFrom
            // 
            this.CbPatchFrom.AutoSize = true;
            this.CbPatchFrom.Location = new System.Drawing.Point(12, 41);
            this.CbPatchFrom.Name = "CbPatchFrom";
            this.CbPatchFrom.Size = new System.Drawing.Size(78, 17);
            this.CbPatchFrom.TabIndex = 2;
            this.CbPatchFrom.Text = "С патча №";
            this.CbPatchFrom.UseVisualStyleBackColor = true;
            // 
            // NudPatchFrom
            // 
            this.NudPatchFrom.Location = new System.Drawing.Point(96, 40);
            this.NudPatchFrom.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NudPatchFrom.Name = "NudPatchFrom";
            this.NudPatchFrom.Size = new System.Drawing.Size(49, 20);
            this.NudPatchFrom.TabIndex = 3;
            // 
            // NudPatchTo
            // 
            this.NudPatchTo.Location = new System.Drawing.Point(96, 66);
            this.NudPatchTo.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NudPatchTo.Name = "NudPatchTo";
            this.NudPatchTo.Size = new System.Drawing.Size(49, 20);
            this.NudPatchTo.TabIndex = 5;
            // 
            // CbPatchTo
            // 
            this.CbPatchTo.AutoSize = true;
            this.CbPatchTo.Location = new System.Drawing.Point(12, 67);
            this.CbPatchTo.Name = "CbPatchTo";
            this.CbPatchTo.Size = new System.Drawing.Size(79, 17);
            this.CbPatchTo.TabIndex = 4;
            this.CbPatchTo.Text = "По патч №";
            this.CbPatchTo.UseVisualStyleBackColor = true;
            // 
            // LbNote
            // 
            this.LbNote.AutoSize = true;
            this.LbNote.Location = new System.Drawing.Point(151, 42);
            this.LbNote.MaximumSize = new System.Drawing.Size(130, 0);
            this.LbNote.Name = "LbNote";
            this.LbNote.Size = new System.Drawing.Size(130, 26);
            this.LbNote.TabIndex = 6;
            this.LbNote.Text = "Примечание: имеется в виду порядковый номер";
            // 
            // BtRNCheck
            // 
            this.BtRNCheck.Enabled = false;
            this.BtRNCheck.Location = new System.Drawing.Point(12, 151);
            this.BtRNCheck.Name = "BtRNCheck";
            this.BtRNCheck.Size = new System.Drawing.Size(267, 23);
            this.BtRNCheck.TabIndex = 10;
            this.BtRNCheck.Text = "Проверить RN\'ы";
            this.BtRNCheck.UseVisualStyleBackColor = true;
            this.BtRNCheck.Click += new System.EventHandler(this.BtRNCheck_Click);
            // 
            // BtCheckFp
            // 
            this.BtCheckFp.Enabled = false;
            this.BtCheckFp.Location = new System.Drawing.Point(12, 180);
            this.BtCheckFp.Name = "BtCheckFp";
            this.BtCheckFp.Size = new System.Drawing.Size(267, 44);
            this.BtCheckFp.TabIndex = 11;
            this.BtCheckFp.Text = "Проверить соответствие сценария и файлов всей поставки";
            this.BtCheckFp.UseVisualStyleBackColor = true;
            this.BtCheckFp.Click += new System.EventHandler(this.BtCheckFp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 268);
            this.Controls.Add(this.BtCheckFp);
            this.Controls.Add(this.BtRNCheck);
            this.Controls.Add(this.LbNote);
            this.Controls.Add(this.NudPatchTo);
            this.Controls.Add(this.CbPatchTo);
            this.Controls.Add(this.NudPatchFrom);
            this.Controls.Add(this.CbPatchFrom);
            this.Controls.Add(this.BtVssFormOpen);
            this.Controls.Add(this.BtCreateFileScFromFiles);
            this.Controls.Add(this.BtCreateFileScFromSc);
            this.Controls.Add(this.LbSetFolder);
            this.Controls.Add(this.BtSetFolder);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Создать file_sc";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.NudPatchFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudPatchTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtSetFolder;
        private System.Windows.Forms.Label LbSetFolder;
        private System.Windows.Forms.Button BtCreateFileScFromSc;
        private System.Windows.Forms.Button BtCreateFileScFromFiles;
        private System.Windows.Forms.Button BtVssFormOpen;
        private System.Windows.Forms.CheckBox CbPatchFrom;
        private System.Windows.Forms.NumericUpDown NudPatchFrom;
        private System.Windows.Forms.NumericUpDown NudPatchTo;
        private System.Windows.Forms.CheckBox CbPatchTo;
        private System.Windows.Forms.Label LbNote;
        private System.Windows.Forms.Button BtRNCheck;
        private System.Windows.Forms.Button BtCheckFp;
    }
}

