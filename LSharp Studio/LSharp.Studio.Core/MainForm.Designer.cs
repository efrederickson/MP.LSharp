/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/8/2011
 * Time: 3:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LSharp.Studio
{
	partial class MainForm
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
		    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
		    this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
		    this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		    this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.MenuStrip = new System.Windows.Forms.MenuStrip();
		    this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		    this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		    this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
		    this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		    this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		    this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.closeCurrentWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		    this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		    this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		    this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		    this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		    this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.showOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
		    this.runInteractiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.viewEnvironmentContentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.helpToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		    this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.referenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.contextMenuStrip1.SuspendLayout();
		    this.MenuStrip.SuspendLayout();
		    this.SuspendLayout();
		    // 
		    // dockPanel1
		    // 
		    this.dockPanel1.ActiveAutoHideContent = null;
		    this.dockPanel1.ContextMenuStrip = this.contextMenuStrip1;
		    this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		    this.dockPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
		    this.dockPanel1.Location = new System.Drawing.Point(0, 24);
		    this.dockPanel1.Name = "dockPanel1";
		    this.dockPanel1.Size = new System.Drawing.Size(697, 393);
		    this.dockPanel1.TabIndex = 0;
		    // 
		    // contextMenuStrip1
		    // 
		    this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.closeToolStripMenuItem,
		    		    		    this.closeAllToolStripMenuItem});
		    this.contextMenuStrip1.Name = "contextMenuStrip1";
		    this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
		    // 
		    // closeToolStripMenuItem
		    // 
		    this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
		    this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
		    this.closeToolStripMenuItem.Text = "Close";
		    this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
		    // 
		    // closeAllToolStripMenuItem
		    // 
		    this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
		    this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
		    this.closeAllToolStripMenuItem.Text = "Close All";
		    this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
		    // 
		    // MenuStrip
		    // 
		    this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.fileToolStripMenuItem1,
		    		    		    this.editToolStripMenuItem1,
		    		    		    this.toolsToolStripMenuItem1,
		    		    		    this.compileToolStripMenuItem,
		    		    		    this.helpToolStripMenuItem2});
		    this.MenuStrip.Location = new System.Drawing.Point(0, 0);
		    this.MenuStrip.Name = "MenuStrip";
		    this.MenuStrip.Size = new System.Drawing.Size(697, 24);
		    this.MenuStrip.TabIndex = 2;
		    this.MenuStrip.Text = "menuStrip1";
		    // 
		    // fileToolStripMenuItem1
		    // 
		    this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.newToolStripMenuItem1,
		    		    		    this.openToolStripMenuItem1,
		    		    		    this.toolStripSeparator,
		    		    		    this.saveToolStripMenuItem,
		    		    		    this.saveAsToolStripMenuItem,
		    		    		    this.toolStripSeparator1,
		    		    		    this.printToolStripMenuItem,
		    		    		    this.printPreviewToolStripMenuItem,
		    		    		    this.toolStripSeparator2,
		    		    		    this.exitToolStripMenuItem,
		    		    		    this.closeCurrentWindowToolStripMenuItem});
		    this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
		    this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
		    this.fileToolStripMenuItem1.Text = "&File";
		    // 
		    // newToolStripMenuItem1
		    // 
		    this.newToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem1.Image")));
		    this.newToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
		    this.newToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
		    this.newToolStripMenuItem1.Size = new System.Drawing.Size(239, 22);
		    this.newToolStripMenuItem1.Text = "&New";
		    this.newToolStripMenuItem1.Click += new System.EventHandler(this.NewToolStripMenuItem1Click);
		    // 
		    // openToolStripMenuItem1
		    // 
		    this.openToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem1.Image")));
		    this.openToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
		    this.openToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
		    this.openToolStripMenuItem1.Size = new System.Drawing.Size(239, 22);
		    this.openToolStripMenuItem1.Text = "&Open";
		    this.openToolStripMenuItem1.Click += new System.EventHandler(this.OpenToolStripMenuItem1Click);
		    // 
		    // toolStripSeparator
		    // 
		    this.toolStripSeparator.Name = "toolStripSeparator";
		    this.toolStripSeparator.Size = new System.Drawing.Size(236, 6);
		    // 
		    // saveToolStripMenuItem
		    // 
		    this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
		    this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
		    this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
		    this.saveToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
		    this.saveToolStripMenuItem.Text = "&Save";
		    this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
		    // 
		    // saveAsToolStripMenuItem
		    // 
		    this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
		    this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
		    		    		    | System.Windows.Forms.Keys.S)));
		    this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
		    this.saveAsToolStripMenuItem.Text = "Save &As";
		    this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
		    // 
		    // toolStripSeparator1
		    // 
		    this.toolStripSeparator1.Name = "toolStripSeparator1";
		    this.toolStripSeparator1.Size = new System.Drawing.Size(236, 6);
		    // 
		    // printToolStripMenuItem
		    // 
		    this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
		    this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.printToolStripMenuItem.Name = "printToolStripMenuItem";
		    this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
		    this.printToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
		    this.printToolStripMenuItem.Text = "&Print";
		    // 
		    // printPreviewToolStripMenuItem
		    // 
		    this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
		    this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
		    this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
		    this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
		    // 
		    // toolStripSeparator2
		    // 
		    this.toolStripSeparator2.Name = "toolStripSeparator2";
		    this.toolStripSeparator2.Size = new System.Drawing.Size(236, 6);
		    // 
		    // exitToolStripMenuItem
		    // 
		    this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
		    this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
		    this.exitToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
		    this.exitToolStripMenuItem.Text = "E&xit";
		    this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
		    // 
		    // closeCurrentWindowToolStripMenuItem
		    // 
		    this.closeCurrentWindowToolStripMenuItem.Name = "closeCurrentWindowToolStripMenuItem";
		    this.closeCurrentWindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
		    this.closeCurrentWindowToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
		    this.closeCurrentWindowToolStripMenuItem.Text = "Close Current Window";
		    this.closeCurrentWindowToolStripMenuItem.Click += new System.EventHandler(this.closeCurrentWindowToolStripMenuItem_Click);
		    // 
		    // editToolStripMenuItem1
		    // 
		    this.editToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.undoToolStripMenuItem,
		    		    		    this.redoToolStripMenuItem,
		    		    		    this.toolStripSeparator3,
		    		    		    this.cutToolStripMenuItem,
		    		    		    this.copyToolStripMenuItem,
		    		    		    this.pasteToolStripMenuItem,
		    		    		    this.toolStripSeparator4,
		    		    		    this.selectAllToolStripMenuItem});
		    this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
		    this.editToolStripMenuItem1.Size = new System.Drawing.Size(39, 20);
		    this.editToolStripMenuItem1.Text = "&Edit";
		    // 
		    // undoToolStripMenuItem
		    // 
		    this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
		    this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
		    this.undoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
		    this.undoToolStripMenuItem.Text = "&Undo";
		    this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItemClick);
		    // 
		    // redoToolStripMenuItem
		    // 
		    this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
		    this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
		    this.redoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
		    this.redoToolStripMenuItem.Text = "&Redo";
		    this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItemClick);
		    // 
		    // toolStripSeparator3
		    // 
		    this.toolStripSeparator3.Name = "toolStripSeparator3";
		    this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
		    // 
		    // cutToolStripMenuItem
		    // 
		    this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
		    this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
		    this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
		    this.cutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
		    this.cutToolStripMenuItem.Text = "Cu&t";
		    this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItemClick);
		    // 
		    // copyToolStripMenuItem
		    // 
		    this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
		    this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
		    this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
		    this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
		    this.copyToolStripMenuItem.Text = "&Copy";
		    this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItemClick);
		    // 
		    // pasteToolStripMenuItem
		    // 
		    this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
		    this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
		    this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
		    this.pasteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
		    this.pasteToolStripMenuItem.Text = "&Paste";
		    this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItemClick);
		    // 
		    // toolStripSeparator4
		    // 
		    this.toolStripSeparator4.Name = "toolStripSeparator4";
		    this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
		    // 
		    // selectAllToolStripMenuItem
		    // 
		    this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
		    this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
		    this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
		    this.selectAllToolStripMenuItem.Text = "Select &All";
		    this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItemClick);
		    // 
		    // toolsToolStripMenuItem1
		    // 
		    this.toolsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.optionsToolStripMenuItem1,
		    		    		    this.pluginsToolStripMenuItem,
		    		    		    this.showOutputToolStripMenuItem});
		    this.toolsToolStripMenuItem1.Name = "toolsToolStripMenuItem1";
		    this.toolsToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
		    this.toolsToolStripMenuItem1.Text = "&Tools";
		    // 
		    // optionsToolStripMenuItem1
		    // 
		    this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
		    this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
		    this.optionsToolStripMenuItem1.Text = "&Options";
		    this.optionsToolStripMenuItem1.Click += new System.EventHandler(this.optionsToolStripMenuItem1_Click);
		    // 
		    // pluginsToolStripMenuItem
		    // 
		    this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
		    this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
		    this.pluginsToolStripMenuItem.Text = "[Plugins]";
		    this.pluginsToolStripMenuItem.Visible = false;
		    // 
		    // showOutputToolStripMenuItem
		    // 
		    this.showOutputToolStripMenuItem.Checked = true;
		    this.showOutputToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
		    this.showOutputToolStripMenuItem.Name = "showOutputToolStripMenuItem";
		    this.showOutputToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
		    this.showOutputToolStripMenuItem.Text = "Show Output";
		    this.showOutputToolStripMenuItem.Click += new System.EventHandler(this.ShowOutputToolStripMenuItemClick);
		    // 
		    // compileToolStripMenuItem
		    // 
		    this.compileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.buildToolStripMenuItem,
		    		    		    this.runToolStripMenuItem,
		    		    		    this.toolStripSeparator6,
		    		    		    this.runInteractiveToolStripMenuItem,
		    		    		    this.viewEnvironmentContentsToolStripMenuItem});
		    this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
		    this.compileToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
		    this.compileToolStripMenuItem.Text = "Build";
		    // 
		    // buildToolStripMenuItem
		    // 
		    this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
		    this.buildToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
		    this.buildToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
		    this.buildToolStripMenuItem.Text = "Build";
		    this.buildToolStripMenuItem.Click += new System.EventHandler(this.BuildToolStripMenuItemClick);
		    // 
		    // runToolStripMenuItem
		    // 
		    this.runToolStripMenuItem.Name = "runToolStripMenuItem";
		    this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
		    this.runToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
		    this.runToolStripMenuItem.Text = "Run";
		    this.runToolStripMenuItem.Click += new System.EventHandler(this.RunToolStripMenuItemClick);
		    // 
		    // toolStripSeparator6
		    // 
		    this.toolStripSeparator6.Name = "toolStripSeparator6";
		    this.toolStripSeparator6.Size = new System.Drawing.Size(264, 6);
		    // 
		    // runInteractiveToolStripMenuItem
		    // 
		    this.runInteractiveToolStripMenuItem.Name = "runInteractiveToolStripMenuItem";
		    this.runInteractiveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
		    this.runInteractiveToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
		    this.runInteractiveToolStripMenuItem.Text = "Run Interactive";
		    this.runInteractiveToolStripMenuItem.Click += new System.EventHandler(this.runInteractiveToolStripMenuItem_Click);
		    // 
		    // viewEnvironmentContentsToolStripMenuItem
		    // 
		    this.viewEnvironmentContentsToolStripMenuItem.Name = "viewEnvironmentContentsToolStripMenuItem";
		    this.viewEnvironmentContentsToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
		    this.viewEnvironmentContentsToolStripMenuItem.Text = "Run && Vie&w Environment Contents...";
		    this.viewEnvironmentContentsToolStripMenuItem.Click += new System.EventHandler(this.ViewEnvironmentContentsToolStripMenuItem_Click);
		    // 
		    // helpToolStripMenuItem2
		    // 
		    this.helpToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.aboutToolStripMenuItem,
		    		    		    this.helpToolStripMenuItem,
		    		    		    this.referenceToolStripMenuItem});
		    this.helpToolStripMenuItem2.Name = "helpToolStripMenuItem2";
		    this.helpToolStripMenuItem2.Size = new System.Drawing.Size(44, 20);
		    this.helpToolStripMenuItem2.Text = "&Help";
		    // 
		    // aboutToolStripMenuItem
		    // 
		    this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
		    this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
		    this.aboutToolStripMenuItem.Text = "&About...";
		    this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
		    // 
		    // helpToolStripMenuItem
		    // 
		    this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
		    this.helpToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
		    this.helpToolStripMenuItem.Text = "&Help...";
		    this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
		    // 
		    // referenceToolStripMenuItem
		    // 
		    this.referenceToolStripMenuItem.Name = "referenceToolStripMenuItem";
		    this.referenceToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
		    this.referenceToolStripMenuItem.Text = "&Reference";
		    this.referenceToolStripMenuItem.Click += new System.EventHandler(this.ReferenceToolStripMenuItem_Click);
		    // 
		    // MainForm
		    // 
		    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		    this.ClientSize = new System.Drawing.Size(697, 417);
		    this.Controls.Add(this.dockPanel1);
		    this.Controls.Add(this.MenuStrip);
		    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		    this.IsMdiContainer = true;
		    this.MainMenuStrip = this.MenuStrip;
		    this.Name = "MainForm";
		    this.Opacity = 0.99D;
		    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		    this.Text = "LSharp Studio";
		    this.Load += new System.EventHandler(this.MainForm_Load);
		    this.contextMenuStrip1.ResumeLayout(false);
		    this.MenuStrip.ResumeLayout(false);
		    this.MenuStrip.PerformLayout();
		    this.ResumeLayout(false);
		    this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem viewEnvironmentContentsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem referenceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showOutputToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem2;
		internal System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
		internal System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem1;
		internal System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		internal System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		internal System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
		internal System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		internal System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		internal System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		internal System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
		internal System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
		internal System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
		internal System.Windows.Forms.MenuStrip MenuStrip;
		internal WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripMenuItem closeCurrentWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem runInteractiveToolStripMenuItem;
	}
}
