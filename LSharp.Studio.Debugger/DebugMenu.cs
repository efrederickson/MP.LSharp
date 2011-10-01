/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/24/2011
 * Time: 1:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LSharp.Studio.Debugger
{
	/// <summary>
	/// Description of UserControl1.
	/// </summary>
	public partial class DebugMenu : UserControl
	{
	    string arguments = "";
		Debugger debugger = new Debugger();
		public DebugMenu()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void StartDebuggingMenuItem_Click(object sender, EventArgs e)
		{
			debugger.Start(LSharp.Studio.MainForm.Instance.GetActiveCodeEditor().TextBox,
			               LSharp.Studio.MainForm.Instance.GetActiveCodeEditor().SyntaxDoc, 
			               arguments);
		}
		
		void BreakMenuItem_Click(object sender, EventArgs e)
		{
			debugger.Stop();
		}
		
		void StopMenuItem_Click(object sender, EventArgs e)
		{
			debugger.Stop();
		}
		
		void StepOverMenuItem_Click(object sender, EventArgs e)
		{
			debugger.StepOver();
		}
		
		void ToolStripButton1_Click(object sender, EventArgs e)
		{
		    GetArgsForm GAF = new GetArgsForm();
		    if (GAF.ShowDialog() == DialogResult.OK)
		        arguments = GAF.RESULT;
		}
	}
}
