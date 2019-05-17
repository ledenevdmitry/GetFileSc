namespace GetFileSc.Forms
{
    partial class AddUsrTsForm
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
            this.lbStr = new System.Windows.Forms.Label();
            this.btYes = new System.Windows.Forms.Button();
            this.lbQuestion = new System.Windows.Forms.Label();
            this.btNo = new System.Windows.Forms.Button();
            this.btYesAll = new System.Windows.Forms.Button();
            this.btNoAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbStr
            // 
            this.lbStr.AutoSize = true;
            this.lbStr.Location = new System.Drawing.Point(12, 9);
            this.lbStr.Name = "lbStr";
            this.lbStr.Size = new System.Drawing.Size(35, 13);
            this.lbStr.TabIndex = 0;
            this.lbStr.Text = "label1";
            // 
            // btYes
            // 
            this.btYes.Location = new System.Drawing.Point(15, 75);
            this.btYes.Name = "btYes";
            this.btYes.Size = new System.Drawing.Size(75, 23);
            this.btYes.TabIndex = 2;
            this.btYes.Text = "Да";
            this.btYes.UseVisualStyleBackColor = true;
            this.btYes.Click += new System.EventHandler(this.btYes_Click);
            // 
            // lbQuestion
            // 
            this.lbQuestion.AutoSize = true;
            this.lbQuestion.Location = new System.Drawing.Point(12, 50);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(63, 13);
            this.lbQuestion.TabIndex = 1;
            this.lbQuestion.Text = "Добавить?";
            // 
            // btNo
            // 
            this.btNo.Location = new System.Drawing.Point(96, 75);
            this.btNo.Name = "btNo";
            this.btNo.Size = new System.Drawing.Size(75, 23);
            this.btNo.TabIndex = 3;
            this.btNo.Text = "Нет";
            this.btNo.UseVisualStyleBackColor = true;
            this.btNo.Click += new System.EventHandler(this.btNo_Click);
            // 
            // btYesAll
            // 
            this.btYesAll.Location = new System.Drawing.Point(177, 75);
            this.btYesAll.Name = "btYesAll";
            this.btYesAll.Size = new System.Drawing.Size(98, 23);
            this.btYesAll.TabIndex = 4;
            this.btYesAll.Text = "Да для всех";
            this.btYesAll.UseVisualStyleBackColor = true;
            this.btYesAll.Click += new System.EventHandler(this.btYesAll_Click);
            // 
            // btNoAll
            // 
            this.btNoAll.Location = new System.Drawing.Point(281, 75);
            this.btNoAll.Name = "btNoAll";
            this.btNoAll.Size = new System.Drawing.Size(98, 23);
            this.btNoAll.TabIndex = 5;
            this.btNoAll.Text = "Нет для всех";
            this.btNoAll.UseVisualStyleBackColor = true;
            this.btNoAll.Click += new System.EventHandler(this.btNoAll_Click);
            // 
            // AddUsrTsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 109);
            this.Controls.Add(this.btNoAll);
            this.Controls.Add(this.btYesAll);
            this.Controls.Add(this.btNo);
            this.Controls.Add(this.lbQuestion);
            this.Controls.Add(this.btYes);
            this.Controls.Add(this.lbStr);
            this.MaximizeBox = false;
            this.Name = "AddUsrTsForm";
            this.Text = "Обнаружена строка создания user или ts ";
            this.Resize += new System.EventHandler(this.AddUsrTsForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbStr;
        private System.Windows.Forms.Button btYes;
        private System.Windows.Forms.Label lbQuestion;
        private System.Windows.Forms.Button btNo;
        private System.Windows.Forms.Button btYesAll;
        private System.Windows.Forms.Button btNoAll;
    }
}