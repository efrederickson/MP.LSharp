/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/22/2011
 * Time: 4:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LSharp.Studio.Core.Forms
{
	partial class ViewEnvContentsForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
		    this.listBox1 = new System.Windows.Forms.ListBox();
		    this.textBox1 = new System.Windows.Forms.TextBox();
		    this.button1 = new System.Windows.Forms.Button();
		    this.SuspendLayout();
		    // 
		    // listBox1
		    // 
		    this.listBox1.FormattingEnabled = true;
		    this.listBox1.Location = new System.Drawing.Point(12, 12);
		    this.listBox1.Name = "listBox1";
		    this.listBox1.Size = new System.Drawing.Size(152, 342);
		    this.listBox1.TabIndex = 0;
		    this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
		    // 
		    // textBox1
		    // 
		    this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
		    		    		    | System.Windows.Forms.AnchorStyles.Left) 
		    		    		    | System.Windows.Forms.AnchorStyles.Right)));
		    this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
		    this.textBox1.Location = new System.Drawing.Point(170, 12);
		    this.textBox1.Multiline = true;
		    this.textBox1.Name = "textBox1";
		    this.textBox1.ReadOnly = true;
		    this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		    this.textBox1.Size = new System.Drawing.Size(164, 318);
		    this.textBox1.TabIndex = 1;
		    this.textBox1.WordWrap = false;
		    // 
		    // button1
		    // 
		    this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		    this.button1.Location = new System.Drawing.Point(204, 347);
		    this.button1.Name = "button1";
		    this.button1.Size = new System.Drawing.Size(75, 23);
		    this.button1.TabIndex = 2;
		    this.button1.Text = "OK";
		    this.button1.UseVisualStyleBackColor = true;
		    this.button1.Click += new System.EventHandler(this.Button1_Click);
		    // 
		    // ViewEnvContentsForm
		    // 
		    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		    this.ClientSize = new System.Drawing.Size(346, 382);
		    this.Controls.Add(this.button1);
		    this.Controls.Add(this.textBox1);
		    this.Controls.Add(this.listBox1);
		    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		    this.Name = "ViewEnvContentsForm";
		    this.ShowIcon = false;
		    this.Text = "View Environment Contents";
		    this.ResumeLayout(false);
		    this.PerformLayout();
		}
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TextBox textBox1;
	}
}
