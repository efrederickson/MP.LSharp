namespace LSharp.Studio.Core
{
	partial class OutputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputForm));
        	this.outputToolStrip = new System.Windows.Forms.ToolStrip();
        	this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
        	this.tscboOutputTypes = new System.Windows.Forms.ToolStripComboBox();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.tsbClearAll = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.tsbToggleWordWrap = new System.Windows.Forms.ToolStripButton();
        	this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
        	this.txtOutput = new Alsing.Windows.Forms.SyntaxBoxControl();
        	this.outputToolStrip.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// outputToolStrip
        	// 
        	this.outputToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.outputToolStrip.AutoSize = false;
        	this.outputToolStrip.Dock = System.Windows.Forms.DockStyle.None;
        	this.outputToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.outputToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.toolStripLabel1,
        	        	        	this.tscboOutputTypes,
        	        	        	this.toolStripSeparator1,
        	        	        	this.tsbClearAll,
        	        	        	this.toolStripSeparator2,
        	        	        	this.tsbToggleWordWrap});
        	this.outputToolStrip.Location = new System.Drawing.Point(0, 0);
        	this.outputToolStrip.Name = "outputToolStrip";
        	this.outputToolStrip.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
        	this.outputToolStrip.Size = new System.Drawing.Size(504, 25);
        	this.outputToolStrip.TabIndex = 2;
        	this.outputToolStrip.Text = "toolStrip1";
        	// 
        	// toolStripLabel1
        	// 
        	this.toolStripLabel1.Name = "toolStripLabel1";
        	this.toolStripLabel1.Size = new System.Drawing.Size(113, 22);
        	this.toolStripLabel1.Text = "Show output from:  ";
        	// 
        	// tscboOutputTypes
        	// 
        	this.tscboOutputTypes.AutoSize = false;
        	this.tscboOutputTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.tscboOutputTypes.Margin = new System.Windows.Forms.Padding(0);
        	this.tscboOutputTypes.Name = "tscboOutputTypes";
        	this.tscboOutputTypes.Size = new System.Drawing.Size(300, 23);
        	this.tscboOutputTypes.Sorted = true;
        	this.tscboOutputTypes.SelectedIndexChanged += new System.EventHandler(this.tscboOutputTypes_SelectedIndexChanged);
        	// 
        	// toolStripSeparator1
        	// 
        	this.toolStripSeparator1.Name = "toolStripSeparator1";
        	this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
        	// 
        	// tsbClearAll
        	// 
        	this.tsbClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.tsbClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbClearAll.Name = "tsbClearAll";
        	this.tsbClearAll.Size = new System.Drawing.Size(23, 22);
        	this.tsbClearAll.Text = "Clear All";
        	this.tsbClearAll.Click += new System.EventHandler(this.tsbClearAll_Click);
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
        	// 
        	// tsbToggleWordWrap
        	// 
        	this.tsbToggleWordWrap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.tsbToggleWordWrap.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbToggleWordWrap.Name = "tsbToggleWordWrap";
        	this.tsbToggleWordWrap.Size = new System.Drawing.Size(23, 22);
        	this.tsbToggleWordWrap.Text = "Toggle Word Wrap";
        	this.tsbToggleWordWrap.Click += new System.EventHandler(this.tsbToggleWordWrap_Click);
        	// 
        	// syntaxDocument1
        	// 
        	this.syntaxDocument1.Folding = false;
        	this.syntaxDocument1.Lines = new string[] {
        	        	""};
        	this.syntaxDocument1.MaxUndoBufferSize = 1000;
        	this.syntaxDocument1.Modified = false;
        	this.syntaxDocument1.UndoStep = 0;
        	// 
        	// txtOutput
        	// 
        	this.txtOutput.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
        	this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.txtOutput.AutoListPosition = null;
        	this.txtOutput.AutoListSelectedText = "a123";
        	this.txtOutput.AutoListVisible = false;
        	this.txtOutput.BackColor = System.Drawing.Color.White;
        	this.txtOutput.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
        	this.txtOutput.CopyAsRTF = false;
        	this.txtOutput.Document = this.syntaxDocument1;
        	this.txtOutput.FontName = "Courier new";
        	this.txtOutput.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        	this.txtOutput.InfoTipCount = 1;
        	this.txtOutput.InfoTipPosition = null;
        	this.txtOutput.InfoTipSelectedIndex = 1;
        	this.txtOutput.InfoTipVisible = false;
        	this.txtOutput.Location = new System.Drawing.Point(0, 28);
        	this.txtOutput.LockCursorUpdate = false;
        	this.txtOutput.Name = "txtOutput";
        	this.txtOutput.ParseOnPaste = true;
        	this.txtOutput.ShowScopeIndicator = false;
        	this.txtOutput.Size = new System.Drawing.Size(504, 270);
        	this.txtOutput.SmoothScroll = true;
        	this.txtOutput.SplitviewH = -4;
        	this.txtOutput.SplitviewV = -4;
        	this.txtOutput.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
        	this.txtOutput.TabIndex = 3;
        	this.txtOutput.Text = "";
        	this.txtOutput.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
        	// 
        	// OutputForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(504, 298);
        	this.Controls.Add(this.txtOutput);
        	this.Controls.Add(this.outputToolStrip);
        	this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
        	        	        	| WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
        	        	        	| WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
        	        	        	| WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
        	this.HideOnClose = true;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "OutputForm";
        	this.TabText = "Output";
        	this.Text = "Output";
        	this.outputToolStrip.ResumeLayout(false);
        	this.outputToolStrip.PerformLayout();
        	this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ToolStrip outputToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscboOutputTypes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbClearAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbToggleWordWrap;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
        private Alsing.Windows.Forms.SyntaxBoxControl txtOutput;
    }
}