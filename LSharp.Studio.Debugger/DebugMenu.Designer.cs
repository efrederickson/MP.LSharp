/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/24/2011
 * Time: 1:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LSharp.Studio.Debugger
{
	public partial class DebugMenu
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
		    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugMenu));
		    this.toolStrip1 = new System.Windows.Forms.ToolStrip();
		    this.startDebuggingMenuItem = new System.Windows.Forms.ToolStripButton();
		    this.breakMenuItem = new System.Windows.Forms.ToolStripButton();
		    this.stopMenuItem = new System.Windows.Forms.ToolStripButton();
		    this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		    this.stepOverMenuItem = new System.Windows.Forms.ToolStripButton();
		    this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		    this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
		    this.toolStrip1.SuspendLayout();
		    this.SuspendLayout();
		    // 
		    // toolStrip1
		    // 
		    this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
		    this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.startDebuggingMenuItem,
		    		    		    this.breakMenuItem,
		    		    		    this.stopMenuItem,
		    		    		    this.toolStripSeparator1,
		    		    		    this.stepOverMenuItem,
		    		    		    this.toolStripSeparator2,
		    		    		    this.toolStripButton1});
		    this.toolStrip1.Location = new System.Drawing.Point(0, 0);
		    this.toolStrip1.Name = "toolStrip1";
		    this.toolStrip1.Size = new System.Drawing.Size(514, 25);
		    this.toolStrip1.TabIndex = 0;
		    this.toolStrip1.Text = "toolStrip1";
		    // 
		    // startDebuggingMenuItem
		    // 
		    this.startDebuggingMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		    this.startDebuggingMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startDebuggingMenuItem.Image")));
		    this.startDebuggingMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.startDebuggingMenuItem.Name = "startDebuggingMenuItem";
		    this.startDebuggingMenuItem.Size = new System.Drawing.Size(23, 22);
		    this.startDebuggingMenuItem.Text = "Start";
		    this.startDebuggingMenuItem.Click += new System.EventHandler(this.StartDebuggingMenuItem_Click);
		    // 
		    // breakMenuItem
		    // 
		    this.breakMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		    this.breakMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("breakMenuItem.Image")));
		    this.breakMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.breakMenuItem.Name = "breakMenuItem";
		    this.breakMenuItem.Size = new System.Drawing.Size(23, 22);
		    this.breakMenuItem.Text = "Stop";
		    this.breakMenuItem.Click += new System.EventHandler(this.BreakMenuItem_Click);
		    // 
		    // stopMenuItem
		    // 
		    this.stopMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		    this.stopMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopMenuItem.Image")));
		    this.stopMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.stopMenuItem.Name = "stopMenuItem";
		    this.stopMenuItem.Size = new System.Drawing.Size(23, 22);
		    this.stopMenuItem.Text = "Kill";
		    this.stopMenuItem.Click += new System.EventHandler(this.StopMenuItem_Click);
		    // 
		    // toolStripSeparator1
		    // 
		    this.toolStripSeparator1.Name = "toolStripSeparator1";
		    this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
		    // 
		    // stepOverMenuItem
		    // 
		    this.stepOverMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		    this.stepOverMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stepOverMenuItem.Image")));
		    this.stepOverMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.stepOverMenuItem.Name = "stepOverMenuItem";
		    this.stepOverMenuItem.Size = new System.Drawing.Size(23, 22);
		    this.stepOverMenuItem.Text = "Step Over";
		    this.stepOverMenuItem.Click += new System.EventHandler(this.StepOverMenuItem_Click);
		    // 
		    // toolStripSeparator2
		    // 
		    this.toolStripSeparator2.Name = "toolStripSeparator2";
		    this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
		    // 
		    // toolStripButton1
		    // 
		    this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		    this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
		    this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.toolStripButton1.Name = "toolStripButton1";
		    this.toolStripButton1.Size = new System.Drawing.Size(111, 22);
		    this.toolStripButton1.Text = "Specify Arguments";
		    this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
		    // 
		    // DebugMenu
		    // 
		    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		    this.Controls.Add(this.toolStrip1);
		    this.Name = "DebugMenu";
		    this.Size = new System.Drawing.Size(514, 25);
		    this.toolStrip1.ResumeLayout(false);
		    this.toolStrip1.PerformLayout();
		    this.ResumeLayout(false);
		    this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton stepOverMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton stopMenuItem;
		private System.Windows.Forms.ToolStripButton breakMenuItem;
		private System.Windows.Forms.ToolStripButton startDebuggingMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip1;
	}
}
