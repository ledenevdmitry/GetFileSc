namespace GetFileSc.Forms
{
    partial class SetAttrDialog
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
            this.LbAttr = new System.Windows.Forms.Label();
            this.TbAttr = new System.Windows.Forms.TextBox();
            this.BtSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbAttr
            // 
            this.LbAttr.AutoSize = true;
            this.LbAttr.Location = new System.Drawing.Point(12, 9);
            this.LbAttr.Name = "LbAttr";
            this.LbAttr.Size = new System.Drawing.Size(29, 13);
            this.LbAttr.TabIndex = 8;
            this.LbAttr.Text = "Attr: ";
            // 
            // TbAttr
            // 
            this.TbAttr.Location = new System.Drawing.Point(15, 25);
            this.TbAttr.Name = "TbAttr";
            this.TbAttr.Size = new System.Drawing.Size(185, 20);
            this.TbAttr.TabIndex = 9;
            // 
            // BtSubmit
            // 
            this.BtSubmit.Location = new System.Drawing.Point(15, 51);
            this.BtSubmit.Name = "BtSubmit";
            this.BtSubmit.Size = new System.Drawing.Size(185, 23);
            this.BtSubmit.TabIndex = 10;
            this.BtSubmit.Text = "Задать";
            this.BtSubmit.UseVisualStyleBackColor = true;
            this.BtSubmit.Click += new System.EventHandler(this.BtSubmit_Click);
            // 
            // SetAttrDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 84);
            this.Controls.Add(this.BtSubmit);
            this.Controls.Add(this.LbAttr);
            this.Controls.Add(this.TbAttr);
            this.Name = "SetAttrDialog";
            this.Text = "Attr";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbAttr;
        private System.Windows.Forms.TextBox TbAttr;
        private System.Windows.Forms.Button BtSubmit;
    }
}