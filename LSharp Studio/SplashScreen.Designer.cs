namespace LSharp.Studio
{
    partial class SplashScreen
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
        	this.lblCopyrights = new System.Windows.Forms.Label();
        	this.lblLoadingMessage = new System.Windows.Forms.Label();
        	this.label1 = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// lblCopyrights
        	// 
        	this.lblCopyrights.AutoSize = true;
        	this.lblCopyrights.BackColor = System.Drawing.Color.Transparent;
        	this.lblCopyrights.ForeColor = System.Drawing.Color.Black;
        	this.lblCopyrights.Location = new System.Drawing.Point(2, 85);
        	this.lblCopyrights.Name = "lblCopyrights";
        	this.lblCopyrights.Size = new System.Drawing.Size(302, 26);
        	this.lblCopyrights.TabIndex = 0;
        	this.lblCopyrights.Text = "Copyright © 2005-2008 Rob Blackwell && Active Web Solutions\r\nCopyright © 2011 mln" +
        	"lover11 Productions";
        	this.lblCopyrights.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// lblLoadingMessage
        	// 
        	this.lblLoadingMessage.AutoSize = true;
        	this.lblLoadingMessage.BackColor = System.Drawing.Color.Transparent;
        	this.lblLoadingMessage.Location = new System.Drawing.Point(247, 127);
        	this.lblLoadingMessage.Name = "lblLoadingMessage";
        	this.lblLoadingMessage.Size = new System.Drawing.Size(57, 13);
        	this.lblLoadingMessage.TabIndex = 1;
        	this.lblLoadingMessage.Text = "Loading ...";
        	this.lblLoadingMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// label1
        	// 
        	this.label1.BackColor = System.Drawing.Color.Transparent;
        	this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label1.Location = new System.Drawing.Point(83, 9);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(122, 34);
        	this.label1.TabIndex = 3;
        	this.label1.Text = "Studio";
        	// 
        	// SplashScreen
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.Color.White;
        	this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
        	this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        	this.ClientSize = new System.Drawing.Size(303, 149);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.lblLoadingMessage);
        	this.Controls.Add(this.lblCopyrights);
        	this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "SplashScreen";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.TopMost = true;
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Label label1;

        #endregion

        private System.Windows.Forms.Label lblCopyrights;
        private System.Windows.Forms.Label lblLoadingMessage;
    }
}