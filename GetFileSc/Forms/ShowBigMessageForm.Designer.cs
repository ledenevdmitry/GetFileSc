namespace GetFileSc.Forms
{
    partial class ShowBigMessageForm
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
            this.TbMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TbMessage
            // 
            this.TbMessage.Location = new System.Drawing.Point(12, 12);
            this.TbMessage.Multiline = true;
            this.TbMessage.Name = "TbMessage";
            this.TbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbMessage.Size = new System.Drawing.Size(542, 300);
            this.TbMessage.TabIndex = 0;
            // 
            // ShowBigMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 324);
            this.Controls.Add(this.TbMessage);
            this.Name = "ShowBigMessageForm";
            this.Text = "ShowBigMessageForm";
            this.Resize += new System.EventHandler(this.ShowBigMessageForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbMessage;
    }
}