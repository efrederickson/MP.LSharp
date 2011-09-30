/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/24/2011
 * Time: 2:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LSharp.Studio.Debugger
{
	partial class DebugManagerForm
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
			this.SuspendLayout();
			// 
			// DebugManagerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(298, 38);
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DebugManagerForm";
			this.ShowIcon = false;
			this.Text = "Debugger";
			this.TopMost = true;
			this.Activated += new System.EventHandler(this.DebugManagerForm_Activated);
			this.Deactivate += new System.EventHandler(this.DebugManagerForm_Deactivate);
			this.Enter += new System.EventHandler(this.DebugManagerForm_Enter);
			this.Leave += new System.EventHandler(this.DebugManagerForm_Leave);
			this.MouseEnter += new System.EventHandler(this.DebugManagerForm_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.DebugManagerForm_MouseLeave);
			this.ResumeLayout(false);
		}
	}
}
