/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/8/2011
 * Time: 4:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LSharp.Studio.Core
{
	partial class CodeEditingForm
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
            this.components = new System.ComponentModel.Container();
            this.syntaxBoxControl1 = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.SuspendLayout();
            // 
            // syntaxBoxControl1
            // 
            this.syntaxBoxControl1.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.syntaxBoxControl1.AutoListPosition = null;
            this.syntaxBoxControl1.AutoListSelectedText = "a123";
            this.syntaxBoxControl1.AutoListVisible = false;
            this.syntaxBoxControl1.BackColor = System.Drawing.Color.White;
            this.syntaxBoxControl1.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.syntaxBoxControl1.CopyAsRTF = true;
            this.syntaxBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.syntaxBoxControl1.Document = this.syntaxDocument1;
            this.syntaxBoxControl1.FontName = "Courier new";
            this.syntaxBoxControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.syntaxBoxControl1.InfoTipCount = 1;
            this.syntaxBoxControl1.InfoTipPosition = null;
            this.syntaxBoxControl1.InfoTipSelectedIndex = 1;
            this.syntaxBoxControl1.InfoTipVisible = false;
            this.syntaxBoxControl1.Location = new System.Drawing.Point(0, 0);
            this.syntaxBoxControl1.LockCursorUpdate = false;
            this.syntaxBoxControl1.Name = "syntaxBoxControl1";
            this.syntaxBoxControl1.ParseOnPaste = true;
            this.syntaxBoxControl1.ShowGutterMargin = false;
            this.syntaxBoxControl1.ShowScopeIndicator = false;
            this.syntaxBoxControl1.ShowTabGuides = true;
            this.syntaxBoxControl1.ShowWhitespace = true;
            this.syntaxBoxControl1.Size = new System.Drawing.Size(560, 368);
            this.syntaxBoxControl1.SmoothScroll = false;
            this.syntaxBoxControl1.SplitviewH = -4;
            this.syntaxBoxControl1.SplitviewV = -4;
            this.syntaxBoxControl1.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.syntaxBoxControl1.TabIndex = 0;
            this.syntaxBoxControl1.Text = "syntaxBoxControl1";
            this.syntaxBoxControl1.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            this.syntaxBoxControl1.TextChanged += new System.EventHandler(this.SyntaxBox1_TextChanged);
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // CodeEditingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 368);
            this.Controls.Add(this.syntaxBoxControl1);
            this.Name = "CodeEditingForm";
            this.Text = "Code Editing Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CodeEditingForm_FormClosing);
            this.ResumeLayout(false);

		}
		private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
        private Alsing.Windows.Forms.SyntaxBoxControl syntaxBoxControl1;
	}
}
