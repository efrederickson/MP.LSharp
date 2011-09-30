/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/8/2011
 * Time: 3:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using LSharp.Studio.Core.Forms;
using System.Windows.Forms;
using LSharp.Studio.Plugins;
using LSharp.Studio.Core;
using System.CodeDom.Compiler;

namespace LSharp.Studio
{
	/// <summary>
	/// The main L# Studio Form
	/// </summary>
	public partial class MainForm : Form
	{
		public static MainForm Instance;
		OutputForm output = new OutputForm();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			AddForm(output);
			Instance = this;
		}
		
		public void AddForm(WeifenLuo.WinFormsUI.Docking.DockContent dc)
		{
			dc.Show(dockPanel1);
		}
		
		bool createdADocument = false;
		public void LoadFile(string filename)
		{
		    CodeEditingForm frm = new CodeEditingForm("");
		    frm.LoadFile(filename);
		    AddForm(frm);
		    createdADocument = true;
		}
		
		private int documentcount = 1;
		void NewToolStripMenuItem1Click(object sender, EventArgs e)
		{
            CodeEditingForm frm1 = new CodeEditingForm("LSharp Script " + documentcount + ".ls");
			frm1.TabText = "LSharp Script " + documentcount + ".ls";
            documentcount++;
            AddForm(frm1);
		}
		
		void OpenToolStripMenuItem1Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "L# Scripts (*.ls)|*.ls|All Files (*.*)|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				CodeEditingForm frm = new CodeEditingForm("");
				frm.LoadFile(dlg.FileName);
				AddForm(frm);
			}
		}
		
		void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			((ICodeEditor) dockPanel1.ActiveDocument).Save();
		}
		
		void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
		{
			((ICodeEditor) dockPanel1.ActiveDocument).SaveAs();
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void UndoToolStripMenuItemClick(object sender, EventArgs e)
		{
			((ICodeEditor) dockPanel1.ActiveDocument).TextBox.Undo();
		}
		
		void RedoToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("Cannot ReDo on this object!");
			//((ICodeEditor) dockPanel1.ActiveDocument).TextBox.Redo();
		}
		
		void CutToolStripMenuItemClick(object sender, EventArgs e)
		{
			((ICodeEditor) dockPanel1.ActiveDocument).TextBox.Cut();
		}
		
		void CopyToolStripMenuItemClick(object sender, EventArgs e)
		{
			((ICodeEditor) dockPanel1.ActiveDocument).TextBox.Copy();
		}
		
		void PasteToolStripMenuItemClick(object sender, EventArgs e)
		{
			((ICodeEditor) dockPanel1.ActiveDocument).TextBox.Paste();
		}
		
		void SelectAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			((ICodeEditor) dockPanel1.ActiveDocument).TextBox.SelectAll();
		}
		
		void BuildToolStripMenuItemClick(object sender, EventArgs e)
		{
			((ICodeEditor) dockPanel1.ActiveDocument).Save();
			string _fn = ((CodeEditingForm) dockPanel1.ActiveDocument).Filename;
            if (string.IsNullOrEmpty(_fn))
            {
                Console.WriteLine("Cannot Compile: No Open Document!");
                return;
            }
            CompilerResults r;
            switch (LSharp.Studio.Core.Properties.Settings.Default.CompileType)
            {
                case "Exe":
                    r = LSharp.Compiler.Compile(new string[] { _fn }, LSharp.Compiler.OutputType.Exe);
                    break;
                case "WinFormsExe":
                    r = LSharp.Compiler.Compile(new string[] { _fn }, LSharp.Compiler.OutputType.WinFormsExe);
                    break;
                case "Dll":
                    r = LSharp.Compiler.Compile(new string[] { _fn }, LSharp.Compiler.OutputType.Dll);
                    break;
                default:
                    r = LSharp.Compiler.Compile(new string[] { _fn }, LSharp.Compiler.OutputType.Exe);
                    break;
            }
			if (r == null ) 
			{
				Console.WriteLine("Failed to Compile!");
				return;
			}
			if (r.Errors.Count > 0)
			{
				foreach (CompilerError err in r.Errors)
					Console.WriteLine(err.ToString());
			}
			else
			{
				Console.WriteLine("Compiled to " + System.IO.Path.GetDirectoryName(_fn) + "\\" + System.IO.Path.GetFileNameWithoutExtension(_fn) + (LSharp.Studio.Core.Properties.Settings.Default.CompileType == "Dll" ? ".dll" : ".exe"));
			}
		}
		
		void RunToolStripMenuItemClick(object sender, EventArgs e)
		{
			((ICodeEditor) dockPanel1.ActiveDocument).Save();
			string _fn = ((CodeEditingForm) dockPanel1.ActiveDocument).Filename;
            if (string.IsNullOrEmpty(_fn))
            {
                Console.WriteLine("Cannot Compile: No Open Document!");
                return;
            }
            CompilerResults r;
            switch (LSharp.Studio.Core.Properties.Settings.Default.CompileType)
            {
                case "Exe":
                    r = LSharp.Compiler.Compile(new string[] { _fn }, LSharp.Compiler.OutputType.Exe);
                    break;
                case "WinFormsExe":
                     r = LSharp.Compiler.Compile(new string[] { _fn }, LSharp.Compiler.OutputType.WinFormsExe);
                    break;
                case "Dll":
                     r = LSharp.Compiler.Compile(new string[] { _fn }, LSharp.Compiler.OutputType.Dll);
                    break;
                default:
                    r = LSharp.Compiler.Compile(new string[] { _fn }, LSharp.Compiler.OutputType.Exe);
                    break;
            }
			if (r == null ) 
			{
				Console.WriteLine("Failed to Compile!");
				return;
			}
			if (r.Errors.Count > 0)
			{
				foreach (CompilerError err in r.Errors)
					Console.WriteLine(err.ToString());
			}
			else
			{
				Console.WriteLine("Compiled to " + System.IO.Path.GetDirectoryName(_fn) + "\\" + System.IO.Path.GetFileNameWithoutExtension(_fn) + (LSharp.Studio.Core.Properties.Settings.Default.CompileType == "Dll" ? ".dll" : ".exe"));
				Process.Start(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(_fn), System.IO.Path.GetFileNameWithoutExtension(_fn) + (LSharp.Studio.Core.Properties.Settings.Default.CompileType == "Dll" ? ".dll" : ".exe")));
			}
		}
		
		void ShowOutputToolStripMenuItemClick(object sender, EventArgs e)
		{
			showOutputToolStripMenuItem.Checked = !showOutputToolStripMenuItem.Checked;
			output.Visible = showOutputToolStripMenuItem.Checked;
		}

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!createdADocument)
                NewToolStripMenuItem1Click(sender, e);
        }

        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new OptionsForm().ShowDialog();
        }

        private void runInteractiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _fn = ((CodeEditingForm) dockPanel1.ActiveDocument).Filename;
            if (string.IsNullOrEmpty(_fn))
            {
                Console.WriteLine("Cannot Run: No Open Document!");
                return;
            }
            // REPL after
            
            Process.Start(Application.StartupPath + "\\lsi.exe", "\"" + _fn + "\"" + " /repl");
        }

        private void closeCurrentWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dockPanel1.ActiveContent.DockHandler.Close();
        }
		
		void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AboutForm().ShowDialog();
		}
		
		void HelpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new HelpForm().ShowDialog();
		}
		
		void ReferenceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			WeifenLuo.WinFormsUI.Docking.DockContent dc = new WeifenLuo.WinFormsUI.Docking.DockContent();
			WebBrowser wb = new WebBrowser();
			wb.Navigate(Application.StartupPath + "\\reference.html");
			wb.Dock = DockStyle.Fill;
			dc.Controls.Add(wb);
			dc.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
			dc.TabText = "L# Help - Reference";
			AddForm(dc);
		}
		
		void ViewEnvironmentContentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new ViewEnvContentsForm(new LSharp.Environment(), ((ICodeEditor) dockPanel1.ActiveDocument).TextBox.Text).ShowDialog();
		}
		
		public CodeEditingForm GetActiveCodeEditor()
		{
			return (CodeEditingForm) dockPanel1.ActiveDocument;
		}
		
		void CloseToolStripMenuItem_Click(object sender, EventArgs e)
		{
		    if (dockPanel1.ActiveDocument != null)
		      dockPanel1.ActiveDocument.DockHandler.Close();
		}
		
		void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
		    for (int i = dockPanel1.DocumentsCount; i > 0; i--)
		        dockPanel1.ActiveDocument.DockHandler.Close();
		}
	}
}
