namespace GetFileSc
{
    partial class ShowWarningsForm
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
            this.tbFilesNotExist = new System.Windows.Forms.TextBox();
            this.tbLinesNotExist = new System.Windows.Forms.TextBox();
            this.gbFilesNotExist = new System.Windows.Forms.GroupBox();
            this.gbLinesNotExist = new System.Windows.Forms.GroupBox();
            this.gbContinue = new System.Windows.Forms.GroupBox();
            this.btNo = new System.Windows.Forms.Button();
            this.btYes = new System.Windows.Forms.Button();
            this.gbFilesNotExist.SuspendLayout();
            this.gbLinesNotExist.SuspendLayout();
            this.gbContinue.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbFilesNotExist
            // 
            this.tbFilesNotExist.Location = new System.Drawing.Point(0, 19);
            this.tbFilesNotExist.Multiline = true;
            this.tbFilesNotExist.Name = "tbFilesNotExist";
            this.tbFilesNotExist.ReadOnly = true;
            this.tbFilesNotExist.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbFilesNotExist.Size = new System.Drawing.Size(292, 193);
            this.tbFilesNotExist.TabIndex = 0;
            // 
            // tbLinesNotExist
            // 
            this.tbLinesNotExist.Location = new System.Drawing.Point(0, 19);
            this.tbLinesNotExist.Multiline = true;
            this.tbLinesNotExist.Name = "tbLinesNotExist";
            this.tbLinesNotExist.ReadOnly = true;
            this.tbLinesNotExist.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLinesNotExist.Size = new System.Drawing.Size(286, 229);
            this.tbLinesNotExist.TabIndex = 0;
            // 
            // gbFilesNotExist
            // 
            this.gbFilesNotExist.Controls.Add(this.tbFilesNotExist);
            this.gbFilesNotExist.Location = new System.Drawing.Point(6, 8);
            this.gbFilesNotExist.Name = "gbFilesNotExist";
            this.gbFilesNotExist.Size = new System.Drawing.Size(292, 212);
            this.gbFilesNotExist.TabIndex = 0;
            this.gbFilesNotExist.TabStop = false;
            this.gbFilesNotExist.Text = "Отсутствуют файлы, указанные в сценарии:";
            // 
            // gbLinesNotExist
            // 
            this.gbLinesNotExist.Controls.Add(this.tbLinesNotExist);
            this.gbLinesNotExist.Location = new System.Drawing.Point(12, 238);
            this.gbLinesNotExist.Name = "gbLinesNotExist";
            this.gbLinesNotExist.Size = new System.Drawing.Size(286, 248);
            this.gbLinesNotExist.TabIndex = 1;
            this.gbLinesNotExist.TabStop = false;
            this.gbLinesNotExist.Text = "Файлы не присутствуют в файле сценария: ";
            // 
            // gbContinue
            // 
            this.gbContinue.Controls.Add(this.btNo);
            this.gbContinue.Controls.Add(this.btYes);
            this.gbContinue.Location = new System.Drawing.Point(12, 507);
            this.gbContinue.Name = "gbContinue";
            this.gbContinue.Size = new System.Drawing.Size(210, 60);
            this.gbContinue.TabIndex = 2;
            this.gbContinue.TabStop = false;
            this.gbContinue.Text = "Продолжить?";
            // 
            // btNo
            // 
            this.btNo.Location = new System.Drawing.Point(108, 19);
            this.btNo.Name = "btNo";
            this.btNo.Size = new System.Drawing.Size(96, 38);
            this.btNo.TabIndex = 1;
            this.btNo.Text = "Нет";
            this.btNo.UseVisualStyleBackColor = true;
            this.btNo.Click += new System.EventHandler(this.btNo_Click);
            // 
            // btYes
            // 
            this.btYes.Location = new System.Drawing.Point(6, 19);
            this.btYes.Name = "btYes";
            this.btYes.Size = new System.Drawing.Size(96, 38);
            this.btYes.TabIndex = 0;
            this.btYes.Text = "Да";
            this.btYes.UseVisualStyleBackColor = true;
            this.btYes.Click += new System.EventHandler(this.btYes_Click);
            // 
            // ShowWarningsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 567);
            this.Controls.Add(this.gbContinue);
            this.Controls.Add(this.gbLinesNotExist);
            this.Controls.Add(this.gbFilesNotExist);
            this.Name = "ShowWarningsForm";
            this.Text = "Предупреждение";
            this.Resize += new System.EventHandler(this.ShowWarningsForm_Resize);
            this.gbFilesNotExist.ResumeLayout(false);
            this.gbFilesNotExist.PerformLayout();
            this.gbLinesNotExist.ResumeLayout(false);
            this.gbLinesNotExist.PerformLayout();
            this.gbContinue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbFilesNotExist;
        private System.Windows.Forms.TextBox tbLinesNotExist;
        private System.Windows.Forms.GroupBox gbFilesNotExist;
        private System.Windows.Forms.GroupBox gbLinesNotExist;
        private System.Windows.Forms.GroupBox gbContinue;
        private System.Windows.Forms.Button btNo;
        private System.Windows.Forms.Button btYes;
    }
}