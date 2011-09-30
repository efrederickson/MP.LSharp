/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/24/2011
 * Time: 2:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LSharp.Studio.Debugger
{
	/// <summary>
	/// Description of DebugManagerForm.
	/// </summary>
	public partial class DebugManagerForm : Form
	{
		public DebugManagerForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
//			LSharp.Studio.MainForm.Instance.Activated += delegate { this.TopMost = true; };
//			LSharp.Studio.MainForm.Instance.Deactivate += delegate {  this.TopMost = false; };
		}
		
		void DebugManagerForm_Enter(object sender, EventArgs e)
		{
			this.Opacity = 1;
		}
		
		void DebugManagerForm_Leave(object sender, EventArgs e)
		{
			this.Opacity = 0.8;
		}
		
		void DebugManagerForm_MouseEnter(object sender, EventArgs e)
		{
			this.Opacity = 1;
		}
		
		void DebugManagerForm_MouseLeave(object sender, EventArgs e)
		{
			this.Opacity = 0.8;
		}
		
		void DebugManagerForm_Activated(object sender, EventArgs e)
		{
			this.Opacity = 1;
		}
		
		void DebugManagerForm_Deactivate(object sender, EventArgs e)
		{
			this.Opacity = 0.8;
		}
	}
}
